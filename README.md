# PhoneBook

Bu proje .Net 5 ile geliştirilmiş web servislerin olduğu bir telefon rehberi uygulamasıdır.

## Teknoloji

- .Net 5.0
- MS-SQL

## Projenin Yapısı ve Ayarlanması

- Projede oluşturulmuş olan katmanlar aşağıdaki gibidir.

![image](https://user-images.githubusercontent.com/93819969/171655264-bb4c6a15-03fc-4a2d-ac93-68cc4c530a0f.png)

- Proje başlangıcı için PhoneBook.DAL katmanındaki "PhoneBookDbContext.cs" dosyası içersine bulunan connection string'i kendi connection string'iniz olarak yazmanız gerekmektedir.

![image](https://user-images.githubusercontent.com/93819969/171656856-a0160580-d47a-4ce5-9307-58a38b675ab2.png)

- Daha sonra Package Manager Console da ```update-database``` yazılarak database update edilmelidir. Bu komut ile beraber veri tabanına örnek veriler girilmiştir.

## Projenin Çalıştırılması

Proje çalıştığında sizi `swagger` ekranı karşılamaktadır.

- Kişi için oluşturulmuş olan kişi ekleme, güncelleme, silme , tüm user'ları listeleme ve bir user'a ait tüm bilgileri getirme taleblerini karşılamak için yazılmış olan API'lar aşağıdaki gibir.

![image](https://user-images.githubusercontent.com/93819969/171660300-c6e8e5cf-13a1-46c1-8fec-5225e5a660c9.png)

- İletişim bilgileri için oluşturulmuş olan ileşitim bilgisi ekleme, silme ve ileşitim bilgisi olarak konuma ait bilgilerin karşılandığı API'lar aşağıdaki gibir.

![image](https://user-images.githubusercontent.com/93819969/171661030-953def39-8026-4950-9c5f-6bb1220b3288.png)

- Contact için yazılmış olan POST methodunda bulunan `InfoType` parametresi için şu verileri kullanabilirsiniz; 
     - PhoneNumber
     - EmailAddress
     - Location
- Aynı şekilde Contact için yazılmış olan POST methodunda bulunan `InfoType` değeri `Location` olarak girilirse `InfoContent` değerini küçük harflerle olacak şekilde istenilen il bilgisi olarak girilebilir. Örneğin `istanbul`, `ankara`, `izmir` vb. 
