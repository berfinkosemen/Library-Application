# Library-Application


<p>Program .net c# dilinde geliştirilmiş olup, Visual Studio tümleşik geliştirme ortamı  (IDE) kullanılmıştır. Görüntü işlemek için Iron OCR kütüphanesi kullanılmıştır. Database olarak MySql seçilmiştir.
  
Program başlatıldığında ana sayfa açılır. Ana sayfadan kullanıcı veya yönetici girişinin seçilmesine göre giriş ekranları açılır. Database üzerinden çekilen bilgilerin kullanıcıdan alınan bilgiler ile karşılaştırılması üzerine kullanıcı veya yönetici giriş yapar. Hatalı bilgi girimi durumunda yanlış şifre ya da kullanıcı adı girildiği belirtilir. Kayıtlı olmayan kullanıcı siteye üye olabilir. Kullanıcı giriş yapar ise ısbn veya kitap ismine göre kitap arama ve listeleme yapabilir. Kullanıcı kitap almak isterse üzerinde teslim tarihi geçmiş kitap olup olmadığı, kullanıcı üzerinde kayıtlı kitap sayısı, istenilen kitabın başka bir kullanıcı üzerine kayıtlı olup olmaması durumu database den çekilen bilgiler eşliğinde kontrol edilir. Koşulların sağlanması durumunda kullanıcı kitap alabilir. 	Kullanıcı kitap iade etmek istediğinde iade etmek istediği kitabın kullanıcı üzerinde kayıtlı olup olmadığı kontrol edilir ve koşul sağlanırsa kullanıcı kitabı iade eder bunun ardından ilgili database tabloları güncellenir. Yöneticinin giriş yapması durumunda, yönetici kitap resmi ve kitabın adını girerek sisteme kitap ekleyebilir. Sistem zamanını istenilen tarihe ilerletebilir. Kullanıcıların üzerindeki kitapları görüntüleyebilir.

Kullanılan Fonksiyonlar
•	protected void Page_Load(object sender, EventArgs e)
Bu fonksiyon program çalışmaya başladığı anda sistem zaman tablosu boş ise bugünün zamanını tabloya insert eder.
•	protected void btnUpload_Click(object sender, EventArgs e) 
Bu fonksiyon dosyadan resim yükleme işlemi gerçekleştirir. Aynı zamanda yüklenen resmin üerindeki yazıları iron OCR kullanarak okur. Çeşitli adımların uygulanması sonucu resmin üzerindeki ısbn numarası bir değişkenin üzerine atanır.
•	protected void insert_Click(object sender, EventArgs e)
Kullanıcıdan kitabın adınında alınmasıyla bir önceki fonksiyonda bulunan isbn numarası ile kitap database e kaydedilir.
•	protected void Selection_Change(object sender, EventArgs e)
Bu fonksiyon seçilen tarihi bugünün tarihi olarak ayarlar.
•	protected void list_Click(object sender, EventArgs e)
Kullanıcıların üzerinde hangi kitaplar var. Kitapların alınma ve teslim tarihlerini listeler.
•	protected void btn_login_Click(object sender, EventArgs e)
Database den çekilen kullanıcı bilgileriyle girilen bilgileri karşılaştırır. Bunun sonucuna bağlı giriş yapar ya da uyarı verir.
•	protected void btn_register_Click(object sender, EventArgs e)
Kullanıcı adı ve şifre bilgileri ile yeni bir üyelik oluşturur.
•	protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
Listeleme yapmak istediğimiz kriterin seçimini gerçekleştiriyor.
•	protected void btn_list_Click(object sender, EventArgs e)
Seçilen kritere göre tablo listeleme işleminni gerçekleştirir.
•	protected void btn_rent_Click(object sender, EventArgs e)
Isbn veya kitap ismine göre seçilen kitabın, kullanıcının üzerinde teslim tarihi geçmiş kitap olmaması, kullanıcı üzerinde üçten fazla kayıtlı kitap olmaması, istenilen kitabın başka bir kullanıcı üzerine kayıtlı olmaması durumunda alınmasına onay verir. Gerekli tablolarda güncellemeler yapar.
•	protected void btnUpload_Click(object sender, EventArgs e) 
Bu fonksiyon dosyadan resim yükleme işlemi gerçekleştirir. Aynı zamanda yüklenen resmin üerindeki yazıları iron OCR kullanarak okur. Çeşitli adımların uygulanması sonucu resmin üzerindeki ısbn numarası bir değişkenin üzerine atanır.
•	protected void insert_Click(object sender, EventArgs e)
Bulunan ısbn numarasını ve database den alınan kişinin üzerine kayıtlı ısbn numarasını alır ve karşılaştırma yapar. Eğer iade edilmek istenen kitap kişinin üzerine kayıtlı ise kitap iade işlemini gerçekleştirir. Gerekli tabloları günceller.
•	protected void btn_login_Click(object sender, EventArgs e)
Database den çekilen kullanıcı bilgileriyle girilen bilgileri karşılaştırır. Bunun sonucuna bağlı giriş yapar ya da uyarı verir.

Karşılaşılan problemler ve çözüm yaklaşımları
•	Ocr kütüphanesinin yüklenmesi bölümünde zorluk yaşanıldı.Gerekli kaynakların bulunması ile sorun çözülmüş oldu.
•	Iron OCR ile kitap resimlerinden isbn numaralarının alınması durumunda sıkıntı yaşandı. Kitap resimlerinin tarayıp alınması ile sorun çözülmüş oldu.
•	Tarih değiştirme konusunda sıkıntı yaşandı. Database yardımı ile tarih in tutulmasıyla sorun çözülmüş oldu.
•	Bootstrap kullanılarak sayfa tasarımı yaparken navbarların kulllanımında zorlanıldı.


