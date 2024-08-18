FROM hub.hurriyetemlak.com/dotnet-core-sdk:2.2 as build-project
ENV ASPNETCORE_ENVIRONMENT=development
WORKDIR /app
COPY ./ ./
RUN dotnet restore
RUN dotnet publish -c Release -o /publish

FROM hub.hurriyetemlak.com/dotnet-core-runtime:2.2
COPY --from=build-project /publish /publish
ENTRYPOINT dotnet /publish/Hemlak.Firm.Consumer.dll --environment $ASPNETCORE_ENVIRONMENT