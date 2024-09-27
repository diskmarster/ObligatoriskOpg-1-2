using ClassLibrary___Til_ObligatoriskOpg;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary___Til_ObligatoriskOpg
{

    public class TrophiesRepository
    {
        // Først laver jeg en liste som hedder _trophies som er en privat liste af Trophy objekter, derefter laver jeg en constructor som tilføjer 5 Trophy objekter til listen:

        private List<Trophy> _trophies = new List<Trophy>();

        public TrophiesRepository()
        {
            _trophies.Add(new Trophy { Id = 1, Competition = "Fodbold", Year = 1996 });
            _trophies.Add(new Trophy { Id = 2, Competition = "Håndbold", Year = 2001 });
            _trophies.Add(new Trophy { Id = 3, Competition = "Tennis", Year = 2014 });
            _trophies.Add(new Trophy { Id = 4, Competition = "Badminton", Year = 2017 });
            _trophies.Add(new Trophy { Id = 5, Competition = "Golf", Year = 2024 });
        }


        // En samlet GET metode som kan filtere på forskellige måder, først tjekker den om listen er null, herhefter tjekker den om der er blevet skrevet "Competition" eller "Year"...:
        public List<Trophy> Get(int? Year = null, string? sortBy = null)
        {
            List<Trophy> list = new List<Trophy>(_trophies);

            // Her tjekker jeg om Year er null, hvis det ikke er null, så filtrere jeg listen efter Year:
            if (Year != null)
            {
                list = list.Where(item => item.Year == Year).ToList();
            }

            // Sortere efter år(Year) eller konkurrence(Competition)
            if (sortBy != null)
            {
                if (sortBy == "competition")
                {
                    list = list.OrderBy(item => item.Competition).ToList();
                }

                if (sortBy == "year")
                {
                    list = list.OrderByDescending(item => item.Year).ToList();
                }
            }

            
            return list;
        }


        public Trophy GetById(int id) // Her laver jeg en metode som hedder GetById som returnere et Trophy objekt som har det id jeg angiver som parameter.
        {
            _trophies.Find(t => t.Id == id);
            if(_trophies != null)
            {
                return _trophies.Find(t => t.Id == id);
            }
            else
            {
                return null;
            }
        }

        public Trophy Add(Trophy trophy) // Her laver jeg en metode som hedder Add som tilføjer et Trophy objekt til listen.
        {
            trophy.Id = _trophies.Max(t => t.Id) + 1;
            if (trophy.Id < 0)
            {
                throw new ArgumentOutOfRangeException("ID must be a non-negative integer.");
            }
            if (string.IsNullOrEmpty(trophy.Competition) || trophy.Competition.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Competition cannot be null and must be at least 3 characters long.");
            }
            _trophies.Add(trophy);
            return trophy;
        }

        public Trophy Remove(int id) // Her laver jeg en metode som hedder Remove som fjerner et Trophy objekt som har det id jeg angiver som parameter.
        {
            Trophy trophy = _trophies.Find(t => t.Id == id);
            if (trophy != null)
            {
                _trophies.Remove(trophy);
                return trophy;
            }
            else
            {
                return null;
            }
            
        }

        public Trophy Update(int id, Trophy values) // Her laver jeg en metode som hedder Update som opdatere et Trophy objekt som har det id jeg angiver som parameter.
        {
            Trophy trophy = _trophies.Find(t => t.Id == id);
            if (trophy != null)
            {
                trophy.Competition = values.Competition;
                trophy.Year = values.Year;
                return trophy;
            }
            else
            {
                return null;
            }
           
        }
    }
}