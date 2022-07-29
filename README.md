# DirectoryApp
This application is a simple directory. You may create,edit or view new members from here.

Projede PostgreSql ile Entity Framework Code First kullandım.
Projeyi çalıştırmak için önce Update-Database -Connection "CONNECTIONSTRING"
komutunu DirectoryApp.Models projesini startup project seçerek çalıştırmalısınız.

Mikroservis yapısını Ocelot kütüphanesini kullanarak kurdum.
DirectoryApp.Gateway: Bütün istekleri karşılayan rest api,

	* Buradan CrudService veya ReportService'e yönlendirmeler yapılır.
	* Configuration ayarları ocelot.json üzerinden yapılır.
	
DirectoryApp.CrudService: Rehbere contact ekleme, çıkarma, silme, iletişim bilgisi ekleme,
silme gibi işlemlerin hepsi burada yapılır. Aynı zamanda RabbitMq üzerinden gelen rapor
istekleri de önce buraya gelecek, veri alınacak ve sonrası için ReportService'de işlemler
devam edecek.

DirectoryApp.ReportService: Alınan veri ile excel dosyasının oluşturulması,
rapor hazırlanma aşamalarının kaydedilmesi (Hazırlanıyor, Tamamlandı vb.) gibi kısımlar burada
işleyecek. Ancak bu kısmı tamamlayamadım.

DirectoryApp.BrokerListener: RabbitMq queue'sunu dinleyen CrudService ile iletişime geçen,
aldığı veriyi ReportService'e gönderen servis. Burada biraz orchestrator gibi davranıyor da diyebiliriz.
(Servislere yaptığı istekler yine DirectoryApp.Gateway üzerinden gerçekleşir)

Projenin test edilebilmesi için VS üzerinden bu 4 uygulamayı Startup project olarak seçebilirsiniz.

Projenin son hali development branch'indedir.