using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triatlon
{
    internal class Versenyzo
    {
        public string Name { get; set; }
        public int szuletesiev { get; set; }
        public int rajtszam { get; set; }
        public string nem { get; set; }
        public string evkategoria { get; set; }
        public TimeSpan UszasIdeje { get; set; }
        public TimeSpan elsodepobantoltottido { get; set; }
        public TimeSpan kerekparozasideje { get; set; }
        public TimeSpan masodikdepobantoltottido { get; set; }
        public TimeSpan futasideje { get; set; }
        public TimeSpan Osszido => UszasIdeje + elsodepobantoltottido + kerekparozasideje + masodikdepobantoltottido + futasideje;

        public override string ToString()
        {
            return $"Név: {Name}\nSzületési év: {szuletesiev}\nRajtszám: {rajtszam}\nNem: {nem}\nKategória: {evkategoria}\n\nIdőeredmények:" +
                $"\nÚszás ideje: {UszasIdeje}\nElső depóban töltött idő: {elsodepobantoltottido}\nKerékpározás ideje: {kerekparozasideje}" +
                $"\nMásodik depóban töltött idő: {masodikdepobantoltottido}\nFutás ideje: {futasideje}";
        }
    }
}
