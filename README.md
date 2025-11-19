# JadooTravel

# Travel & Tour Reservation Platform

ASP.NET Core MVC 6.0 tabanlı, çok dilli (TR / EN / FR / ES) seyahat ve tur rezervasyon platformu. Kullanıcılar yapay zekâ destekli rota önerileri alabilir, turlar hakkında bilgi edinebilir ve rezervasyon oluşturabilir.

---

## Özellikler

### Çoklu Dil Desteği
![Dil Desteği](images/language.png)  
Özel `LanguageService` ile OpenAI API üzerinden dinamik ve akıcı çeviri desteği.

### Yapay Zeka Rota Önerisi
![AI Rota](images/ai_route.png)  
OpenAI GPT API entegrasyonu ile kişiselleştirilmiş tur tavsiyeleri.

### Rezervasyon Sistemi
![Rezervasyon](images/reservation.png)  
MongoDB üzerinde hızlı ve güvenli rezervasyon yönetimi.

### Dinamik Tur Kartları
![Tur Kartları](images/tour_cards.png)  
Görseller, açıklamalar, fiyat bilgisi ve aktif/pasif duruma göre otomatik güncellenen kart yapısı.

### Admin Paneli
![Admin Panel](images/admin_panel.png)  
ASP.NET Core MVC katmanlı yapı ile CRUD işlemleri ve yönetim kolaylığı.

### ViewComponent & Partial View
![ViewComponent](images/view_component.png)  
Modüler ve tekrar kullanılabilir UI bileşenleri.

### Dependency Injection & AutoMapper
![Dependency Injection](images/dependency_injection.png)  
Temiz, sürdürülebilir ve genişletilebilir kod mimarisi.

---

## Kullanılan Teknolojiler

- Backend: ASP.NET Core MVC 6.0, C#  
- Database: MongoDB (NoSQL)  
- Frontend: HTML, CSS, Bootstrap 5  
- Tools: AutoMapper, Dependency Injection  
- AI Service: OpenAI GPT API  
- Custom Service: `LanguageService` (Dinamik Çoklu Dil Çevirisi)
