<h1 align="center"><ins>ASP.NET inlämning: Bmerketo |  Carl Andersson</ins></h1>
<h2 align="center"><ins>Hur man startar:</ins></h2>
<p>1. Börja med att gå in i mappen Contexts och dubbelklicka på filerna forms-database.mdf och identity-database.mdf. </p>
<p>2. Gå in i server explorer och högerklicka på forms-database.mdf och kopiera connection stringen. Gå sedan in i  appsettings.json och klistra in den under "Sql". Gör sedan samma sak för identity-database.mdf och klistra in den under "IdentityDatabase".</p>
<p>3. Starta sedan programmet.</p>
<hr>
<h2 align="center"><ins>Inloggning</ins></h2>
<h4 align="center">Just nu finns det inga konton i databasen. Det första kontot som skapas tilldelas admin. </h4>

<hr>
<h2 align="center"><ins>Startsidan</ins><br></h2><h4 align="center">(Det går att trycka på alla produkter för att komma till deras specifika produktsida)</h4>
<h4 align="center"><ins>Showcase</ins></h4>
<p>När sidan startas upp så ser du först en stor showcase där det slumpas ut olika produkter i kolletionen "Featured". Tryck på shopknappen för att se produktsidan för den specifika produkten.</p>
<h4 align="center"><ins>Best Collection</ins></h4>
<p>I Best Collection så kommer de åtta nyaste produkterna ut. Dessa produkter är med i kollektionen "New". Ifall du tryck på kategoriknapparna så kommer du till produktsidan och ser alla produkter i den kategorien som väljs.</p>
<h4 align="center"><ins>Sales</ins></h4>
<p align="center">Här visas 2 slumpmässiga produkter upp som är med i kollektionen "OnSales".</p>
<h4 align="center"><ins>Top Selling & blogg</ins></h4>
<p>Här visas de 6 nyaste produkterna ut som är med i kollektionen "Popular". Under "Top selling products in this week" så slumpas det ut 3 stycken produkter som är med i "Popular". Här syns beskrivningen under samt en rating.</p>
<br>
<hr>
<h2 align="center"><ins>Navbar</ins></h2>
<h4 align="center"><ins>Home</ins></h4>
<p align="center">Tryck här för att komma till startsidan.</p>
<h4 align="center"><ins>Products</ins></h4>
<p align="center">Tryck här för att komma till produktsidan.</p>
<h4 align="center"><ins>Contact</ins></h4>
<p align="center">Tryck här för att komma till kontaktsidan. Här går det att skicka ett meddelande till butiken. Detta meddelande samt vilken person som skickat, sparas i databasen.</p>
<h4 align="center"><ins>Admin</ins></h4>
<p align="center">Denna flik har du tillgång till ifall du är admin, mer om den nedan.</p>
<h4 align="center"><img src="https://i.imgur.com/jxG9OgN.png" width="25px"></h4>
<p align="center">Denna symbol ser du om du är inloggad. Detta är en dropdown, där du kan välja mellan att se din profil eller att logga ut.</p>
<h4 align="center"><ins>Login<ins></h4>
<p align="center">Denna ser du ifall du inte är inloggad. Här kan du logga in. (Du registrerar ett nytt konto genom att trycka på "Not registered? Click here to sign up")</p>
<hr>
<h2 align="center"><ins>Admin</ins></h2>
<h4 align="center">Om du är inloggad som admin så har du tillgång en admin-dashboard. Där finns det fem olika val du kan göra. (Valen finns även att göra i admin headern)</h4>
<p align="center"><ins>Add a new product:</ins><br>
Här kan du skapa en ny produkt, du får välja produktnamn, produktpris, kategori, vilken kollektion samt beskrivning. Kryssar du i att produkten är "On Sale" så får du även skriva in ett nytt discount price.</p>
<p align="center"><ins>Create a new user:</ins><br>
Här skapar du en ny användare, likt som du gör ifall du registrerar ett nytt konto på startsidan.</p>
<p align="center"><ins>See & manage all users:</ins><br>
Här kan du se alla användare som finns samt redigera ifall du vill att användare ska vara admin eller användare.</p>
<p align="center"><ins>Your profile:</ins><br>
Trycker du här så går du till användarprofilen för den som är inloggad.</p>
<p align="center"><ins>Go back to bmerketo:</ins><br>
Tryck här ifall du vill gå tillbaka till startsidan.</p>
<hr>

