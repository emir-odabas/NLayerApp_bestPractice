# NLayer App - Best Practice (.NET 9 & PostgreSQL)

Bu proje, N-Tier (N-Katmanlı) mimari prensiplerine sadık kalınarak modern .NET teknolojileri ile geliştirilmiş bir kurumsal uygulama iskeletidir.

## 🚀 Öne Çıkan Özellikler
- **N-Tier Architecture**: Core, Service, Repository, API ve Web (MVC) katmanları ile modüler yapı.
- **Generic Repository & Unit of Work**: Veri erişim katmanında temiz ve sürdürülebilir bir mimari.
- **Dependency Injection**: Autofac ile gelişmiş ve esnek bağımlılık yönetimi.
- **Mapping**: AutoMapper ile nesne dönüşümleri.
- **Validation**: FluentValidation ile merkezi iş kuralı doğrulamaları.
- **Global Exception Handling**: Tüm sistem için tek noktadan hata yönetimi ve standart hata mesajları.

## 🛠️ Teknik Altyapı Güncellemeleri
Proje başlangıcından itibaren aşağıdaki modernizasyonlar yapılmıştır:
- **Framework**: .NET 6'dan **.NET 9.0** sürümüne yükseltildi.
- **Database**: SQL Server'dan **PostgreSQL**'e geçiş yapıldı.
- **EF Core**: Entity Framework Core 9.0.0 sürümleri kullanıldı.
- **Connectivity**: Ortam uyumluluğu için HTTPS geçici olarak devre dışı bırakıldı, uygulama HTTP protokolü üzerinden çalışmaktadır.

## 🐘 PostgreSQL ve Veritabanı Yönetimi
Uygulama tamamen PostgreSQL uyumlu hale getirilmiştir. 

### Bağlantı Bilgileri:
- **Host**: `localhost`
- **Port**: `5432`
- **Database**: `NLayerDb`
- **Username**: `postgres`
- **Password**: `postgres` (veya `appsettings.json` içinde tanımlı şifre)

### Veritabanını DBeaver ile Yönetme:
1. DBeaver'ı açın ve "New Connection" butonuna tıklayın.
2. Liste içerisinden **PostgreSQL**'i seçin.
3. Host (`localhost`) ve Port (`5432`) bilgilerini girin.
4. Database ismine `NLayerDb`, Username kısmına `postgres` yazın.
5. Şifrenizi girdikten sonra "Test Connection" ile bağlantıyı doğrulayın.

## 🏃 Uygulama Nasıl Çalıştırılır?

Projeyi çalıştırmak için terminalden aşağıdaki komutları kullanabilirsiniz:

1. **Bağımlılıkları Yükle:**
   ```bash
   dotnet restore
   ```

2. **Veritabanını Hazırla (Migration):**
   ```bash
   dotnet ef database update -p NLayer.Repository -s NLayer.API
   ```

3. **Backend ve Frontend'i Başlat:**
   - **API (Port 5197):** `dotnet run --project NLayer.API`
   - **Web (Port 5287):** `dotnet run --project NLayer.Web`

## 🔗 Erişim Linkleri
- **Web Arayüzü (MVC)**: [http://localhost:5287](http://localhost:5287)
- **API Swagger Dokümantasyonu**: [http://localhost:5197/swagger](http://localhost:5197/swagger)

---
*Bu proje, modern yazılım geliştirme standartlarına uygun olarak otomatik olarak optimize edilmiştir.*
