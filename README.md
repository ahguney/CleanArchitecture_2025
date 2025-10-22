# CleanArchitecture_2025

Bu proje, .NET platformu üzerinde **Clean Architecture (Temiz Mimari)** prensiplerini uygulayan bir ASP.NET Core çözümüdür. Modern yazılım geliştirme standartlarını, test edilebilirliği ve sürdürülebilirliği odak noktasına alır.

## 🚀 Hakkında

Bu repository, Clean Architecture'ın temel katmanlarını (.NET 9 ve en güncel teknolojileri kullanarak) nasıl uygulayacağınızı gösteren bir başlangıç şablonu veya referans projesi olarak tasarlanmıştır. Amacı, bakımı kolay, esnek ve ölçeklenebilir uygulamalar geliştirmek için sağlam bir temel oluşturmaktır.

## 📐 Temel Prensipler

Proje, Robert C. Martin'in (Uncle Bob) Clean Architecture prensiplerine dayanmaktadır:

* **Bağımsızlık:** Çerçevelerden (framework), veritabanından ve dış servislerden bağımsız bir yapı.
* **Bağımlılık Kuralı (Dependency Rule):** Tüm bağımlılıklar dış katmanlardan iç katmanlara doğru yönelir. `Domain` ve `Application` katmanları, `Infrastructure` veya `WebUI` gibi dış katmanlar hakkında hiçbir şey bilmez.
* **Test Edilebilirlik:** İş mantığı (business logic), UI veya veritabanı olmadan kolayca test edilebilir.

## 📂 Proje Yapısı

Çözüm, standart Clean Architecture katmanlarına ayrılmıştır:

* **Core/Domain (Çekirdek/Alan Adı):**
    * Projenin kalbidir.
    * Varlıkları (Entities), değer nesnelerini (Value Objects) ve alan adı olaylarını (Domain Events) içerir.
    * Hiçbir dış katmana bağımlılığı yoktur.
* **Application (Uygulama):**
    * Uygulamanın iş mantığını (use case'ler) içerir.
    * CQRS (Command Query Responsibility Segregation) modelini uygulamak için `Commands` ve `Queries` barındırır.
    * `MediatR` kütüphanesi ile bu komut ve sorguları yönetir.
    * Dış katmanlarla (Veritabanı, E-posta servisi vb.) `Interface`'ler (Arayüzler) üzerinden iletişim kurar.
* **Infrastructure (Altyapı):**
    * Dış bağımlılıkların ve servislerin implementasyonunu içerir.
    * Veritabanı erişimi (Örn: `Entity Framework Core`), kimlik doğrulama (Örn: `ASP.NET Core Identity`), e-posta gönderimi, dosya sistemi erişimi vb. servisler burada yer alır.
    * `Application` katmanındaki arayüzleri uygular.
* **WebUI / API (Sunum Katmanı):**
    * Kullanıcı arayüzünü (Örn: `Angular`, `React` veya `Blazor`) veya dış dünyaya açılan API (`RESTful API`) uç noktalarını içerir.
    * Projenin giriş noktasıdır.
    * Doğrudan `Application` katmanıyla (genellikle MediatR aracılığıyla) iletişim kurar.
 

  ## 💻 Kullanılan Teknolojiler

Bu çözümde aşağıdaki temel teknolojiler ve kütüphaneler kullanılmıştır:

* **.NET 9**
* **ASP.NET Core 9** (Web API için)
* **Entity Framework Core 9** (ORM için)
* **MediatR** (CQRS , Event, Pipeline)
* **Mapster** (Hızlı ve performanslı DTO - Entity dönüşümleri için, AutoMapper alternatifi)
* **FluentValidation** (Model ve request doğrulaması için)
* **Scrutor** (Assembly tarama ve bağımlılıkların otomatik kaydedilmesi - DI - için)
