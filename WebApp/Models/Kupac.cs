using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Kupac : Korisnik
    {
        List<int> porudzbine = new List<int>();
        List<int> omiljeniProizvodi = new List<int>();

        public List<int> Porudzbine { get => porudzbine; set => porudzbine = value; }
        public List<int> OmiljeniProizvodi { get => omiljeniProizvodi; set => omiljeniProizvodi = value; }

        public override string ToString()
        {
            string porudzbineString = string.Join(",", Porudzbine);
            string omiljeniProizvodiString = string.Join(",", OmiljeniProizvodi);

            return $"{KorisnickoIme},{Lozinka},{Ime},{Prezime},{Pol},{Email},{DatumRodjenja},|{porudzbineString}|,|{omiljeniProizvodiString}|";
        }

        public static Kupac Parse(string korisnikString)
        {
            Kupac kupac = new Kupac();

            string[] vrednosti = korisnikString.Split(',');

            if (vrednosti.Length != 9)
            {
                throw new ArgumentException("Invalid format for korisnikString. Expected 9 vrednosti separated by commas.");
            }

            kupac.KorisnickoIme = vrednosti[0];
            kupac.Lozinka = vrednosti[1];
            kupac.Ime = vrednosti[2];
            kupac.Prezime = vrednosti[3];
            kupac.Pol = (Pol)Enum.Parse(typeof(Pol), vrednosti[4]);
            kupac.Email = vrednosti[5];
            kupac.DatumRodjenja = DateTime.Parse(vrednosti[6]);

            string porudzbineString = vrednosti[7].TrimStart('|').TrimEnd('|');
            string[] porudzbineArray = porudzbineString.Split(',');
            kupac.Porudzbine = new List<int>();
            foreach (string porudzbina in porudzbineArray)
            {
                kupac.Porudzbine.Add(int.Parse(porudzbina));
            }

            string omiljeniProizvodiString = vrednosti[8].TrimStart('|').TrimEnd('|');
            string[] omiljeniProizvodiArray = omiljeniProizvodiString.Split(',');
            kupac.OmiljeniProizvodi = new List<int>();
            foreach (string omiljeniProizvod in omiljeniProizvodiArray)
            {
                kupac.OmiljeniProizvodi.Add(int.Parse(omiljeniProizvod));
            }

            return kupac;
        }
    }
}