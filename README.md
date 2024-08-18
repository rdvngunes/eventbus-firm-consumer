# Özet
Release 1.0.0
```
git clone git@bitbucket.org:hemlak/hurriyet-emlak-firm-consumer.git
dotnet restore
dotnet build
dotnet test
cd src/Hurriyet.Emlak.FirmUser.Consumer
dotnet run
```

# İhtiyaçlar

* dotnet 2.2

* docker

# Kurulum

## Ayarlar

### Ayar Dosyaları

Projeye ait 5 farklı ayar dosyası mevcut:

* hostsettings.json
* appsettings.json
* appsettings.development.json
* appsettings.beta.json
* appsettings.production.json

#### hostsettings.json Dosyası

```
{
	"environment": "development"
}
```

Bu dosyadaki environment bilgisi projeye ait diğer ayarların hangi dosyadan çekilmesi gerektiğini gösterir.

#### appsettings\*.json Dosyaları

Bu dosyalarda proje içerisinde kullanılan ayarlar bulunur. Eğer seçilen ortama ait ayar dosyasında bir ayar yoksa appsettings.json dosyasındaki ayarı esas kabul eder.

## Paket Kurulumu

```
dotnet restore
```

## Derleme

```
dotnet build
```

## Çalıştırma

```
dotnet run
```


### Veya Docker ile ...

```bash
docker-compose up
```

### Environment geçmek için

#### Windows
```bash
set ASPNETCORE_ENVIRONMENT=beta 
docker-compose up
```
#### Linux
```bash
ASPNETCORE_ENVIRONMENT=beta docker-compose up
```




# Test

## Çalıştırma

```
dotnet test
```

# Ekstra Bilgiler

## RabbitMq ile localhost üzerinden çalışmak için...

* appsettings.Development.json dosyasında EventBusConnectionConfig altındaki ConnectionString değeri 127.0.0.1 olarak düzenlenir.

* hostsettings.json dosyasındaki environment değeri Development olarak düzenlenir.

* ```docker run -d --hostname my-rabbit -p 15672:15672 -p 5672:5672 --name myrabbitmq rabbitmq:3-management``` çalıtırılır.

* Hangi publisher projesi kullanılıyorsa bu projedeki event bus connection string değeri 127.0.0.1 olarak düzenlenir.

İdare arayüzüne erişim için 127.0.0.1:15672 adresine girilebilir.