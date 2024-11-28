# 1likte Backend Developer Case

Bu proje, bir e-ticaret sistemine ait **Sepet Yönetim Servisi**'nin gereksinimlerini karşılamak üzere hazırlanmıştır. Domain-Driven Design (DDD) ve Test-Driven Development (TDD) prensipleri kullanılarak geliştirilmiştir. 

## **Proje Açıklaması**
Bu proje, bir müşterinin sepetine ürün ekleme, çıkarma ve sepetindeki ürünleri görüntüleme gibi temel işlemleri gerçekleştirmesini sağlar. Ayrıca, sepet içerisindeki ürünler farklı mağazalardan gelebilir ve bu durumda mağaza bazlı işlemler desteklenir.

### **Özellikler**
- **Domain-Driven Design (DDD):** İş mantığı domain modellerinde tanımlanmıştır.
- **Test-Driven Development (TDD):** Kod, unit testlerle doğrulanmıştır.
- **SOLID Prensipleri:** Kodun temiz ve sürdürülebilir olmasını sağlamak için uygulanmıştır.
- **KISS Prensibi:** Kod, sade ve anlaşılır şekilde yazılmıştır.

---

## **Kurulum ve Çalıştırma**

### **Gereksinimler**
- .NET 6.0 veya üstü
- Bir IDE (Visual Studio, VS Code vb.)
- Komut Satırı Aracı (Terminal, PowerShell vb.)

### **Projenin Çalıştırılması**
1. **Projeyi klonlayın:**
   ```bash
   git clone https://github.com/enescaakir/1likte_be_case.git
   cd 1likte_be_case
2. **Gerekli bağımlılıkları yükleyin ve projeyi build edin:**
   ```bash
   dotnet restore
   dotnet build
3. **Projeyi klonlayın:**
   ```bash
   dotnet test
