using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Dapper;
using DbUp;
using DbUp.Helpers;
using Docker.DotNet;
using Docker.DotNet.Models;
using Template.Firm.Consumer.Configuration;
using Template.Firm.Consumer.Repositories;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Template.Firm.Consumer.Integration.Test.Repositories
{
    public abstract class RepositoryTestBase
    {
        protected string ConnectionString;
        protected string MssqlContainerName;
        private readonly string _dockerLocalhostUri;
        private readonly int _maxRetryCountForSqlServerConnection;

        protected RepositoryTestBase()
        {

            _dockerLocalhostUri = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? $"npipe://./pipe/docker_engine"
                : $"unix:////var/run/docker.sock";
            _maxRetryCountForSqlServerConnection = 20;
        }
        public async Task StartMssql()
        {
            ConnectionString = $"Data Source=127.0.0.1;User ID=sa;Password=Rdvn4fth;Initial Catalog=master;Timeout=60;";
            MssqlContainerName = string.Format("FirmConsumerIntegrationTest_{0}", DateTime.Now.ToString("yyyyMMddHHmmss"));

            using (var conf = new DockerClientConfiguration(new Uri(_dockerLocalhostUri)))
            using (var client = conf.CreateClient())
            {
                string ImageName = "microsoft/mssql-server-linux";
                string ImageTag = "latest";

                var containers =
                    await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true });
                var container = containers.FirstOrDefault(c => c.Names.Contains("/" + MssqlContainerName));
                if (container == null)
                {
                    // Download image
                    await client.Images.CreateImageAsync(
                        new ImagesCreateParameters() { FromImage = ImageName, Tag = ImageTag }, new AuthConfig(),
                        new Progress<JSONMessage>());

                    // Create the container
                    var config = new Config()
                    {
                        Hostname = "localhost",
                        Env = new List<string>() { "ACCEPT_EULA=Y", "SA_PASSWORD=Rdvn4fth" }
                    };

                    // Configure the ports to expose
                    var hostConfig = new HostConfig()
                    {
                        PortBindings = new Dictionary<string, IList<PortBinding>>
                        {
                            {
                                "1433/tcp",
                                new List<PortBinding> {new PortBinding {HostIP = "127.0.0.1", HostPort = "1433"}}
                            }
                        }
                    };

                    // Create the container
                    var response = await client.Containers.CreateContainerAsync(new CreateContainerParameters(config)
                    {
                        Image = ImageName + ":" + ImageTag,
                        Name = MssqlContainerName,
                        Tty = false,
                        HostConfig = hostConfig,
                    });

                    // Get the container object
                    containers =
                        await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true });
                    container = containers.FirstOrDefault(c => c.Names.Contains("/" + MssqlContainerName));

                    var started = await
                        client.Containers.StartContainerAsync(container.ID, new ContainerStartParameters());


                    if (!started)
                    {
                        Assert.Fail("Cannot start the docker container");
                    }
                }
            }
            
            var tryCount = 0;
            using (var sqlConnect = new SqlConnection(ConnectionString))
            {
                while (tryCount < this._maxRetryCountForSqlServerConnection)
                {
                    try
                    {
                        sqlConnect.Execute("Select 1");
                        break;
                    }
                    catch (Exception)
                    {
                        tryCount++;
                        System.Threading.Thread.Sleep(3000);
                    }
                }
            }
        }

        public async Task InitDatabase()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                await sqlConnection.ExecuteAsync($"CREATE DATABASE TemplateDatabase;");
                ConnectionString = $"Data Source=127.0.0.1;User ID=sa;Password=Rdvn4fth;Initial Catalog=TemplateDatabase;Timeout=60;";
                var upgrader = DeployChanges.To
                    .SqlDatabase(ConnectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .JournalTo(new NullJournal())
                    .Build();
                var result = upgrader.PerformUpgrade();
            }
        }

        public async Task StopMssql()
        {
            using (var conf = new DockerClientConfiguration(new Uri(_dockerLocalhostUri)))
            using (var client = conf.CreateClient())
            {
                var containers =
                    await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true });
                var container = containers.First(c => c.Names.Contains("/" + MssqlContainerName));

                if (container.State.Equals("running"))
                {
                    var started =
                        client.Containers.RemoveContainerAsync(container.ID, new ContainerRemoveParameters() {
                            Force = true,
                        });
                    if (!started.IsCompleted)
                    {
                        Assert.Fail("Cannot stop the docker container");
                    }
                }
            }
        }
    }
}