using triatlon;

List<Versenyzo> versenyzok = new List<Versenyzo>();

StreamReader sr = new StreamReader("forras.txt");

while(!sr.EndOfStream)
{
    string[] line = sr.ReadLine().Split(";");

    Versenyzo versenyzo = new Versenyzo();

    versenyzo.Name = line[0];
    versenyzo.szuletesiev = int.Parse(line[1]);
    versenyzo.rajtszam = int.Parse(line[2]);
    versenyzo.nem = line[3];
    versenyzo.evkategoria = line[4];
    versenyzo.UszasIdeje = TimeSpan.ParseExact(line[5], "hh\\:mm\\:ss", null);
    versenyzo.elsodepobantoltottido = TimeSpan.ParseExact(line[6], "hh\\:mm\\:ss", null);
    versenyzo.kerekparozasideje = TimeSpan.ParseExact(line[7], "hh\\:mm\\:ss", null);
    versenyzo.masodikdepobantoltottido = TimeSpan.ParseExact(line[8], "hh\\:mm\\:ss", null);
    versenyzo.futasideje = TimeSpan.ParseExact(line[9], "hh\\:mm\\:ss", null);

    versenyzok.Add(versenyzo);
}

sr.Close();

Console.WriteLine($"{versenyzok.Count} versenyző fejezte be a versenyt");

int elitversenyzok = versenyzok.Count(x => x.evkategoria == "elit");

Console.WriteLine($"{elitversenyzok} db elit versenyző van.");

double noiatlageletkor = versenyzok.Where(x => x.nem == "n").Average(x => DateTime.Now.Year - x.szuletesiev);

Console.WriteLine($"A női átlag életkor {noiatlageletkor}");

double kerekparozasosszido = versenyzok.Sum(x => x.kerekparozasideje.TotalHours);

Console.WriteLine($"Kerékpározás összidő: {Math.Round(kerekparozasosszido, 2)} óra");

double atlaguszaselit = versenyzok.Where(x => x.evkategoria == "elit junior").Average(x => x.UszasIdeje.TotalMinutes);

Console.WriteLine($"Átlagos úszási idő elit junior kategóriában: {atlaguszaselit} perc");

var ferfiGyoztes = versenyzok.Where(v => v.nem == "f").OrderBy(v => v.Osszido).FirstOrDefault();

Console.WriteLine();
Console.WriteLine(ferfiGyoztes.ToString());
Console.WriteLine();

var korkategoriak = versenyzok.GroupBy(v => v.evkategoria);
foreach (var kategoria in korkategoriak)
{
    Console.WriteLine($"Korcsoport: {kategoria.Key} - Befejezők száma: {kategoria.Count()}");
}
Console.WriteLine();

var atlagDepoIdoKorcsoportonkent = versenyzok.GroupBy(v => v.evkategoria)
    .Select(g => new
    {
        Korosztaly = g.Key,
        AtlagDepoIdo = g.Average(v => v.elsodepobantoltottido.TotalMinutes + v.masodikdepobantoltottido.TotalMinutes)
    });

foreach (var item in atlagDepoIdoKorcsoportonkent)
{
    Console.WriteLine($"Korcsoport: {item.Korosztaly} - Átlag depó idő: {Math.Round(item.AtlagDepoIdo, 2)} perc");
}