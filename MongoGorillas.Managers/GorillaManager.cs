using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Norm;
using MongoGorillas.Repository.Context;
using MongoGorillas.Types;
using MongoGorillas.Managers.Helpers;

namespace MongoGorillas.Managers
{
    public static class GorillaManager
    {
        #region Names

        private static string[] _firstNames = new string[]
        {
            "White",
            "Black",
            "Light",
            "Dark",
            "Evil",
            "Cunning",
            "Magic",
            "Silver",
            "Golden",
            "Slimy"
        };

        private static string[] _lastNames = new string[]
        {
            "Legendary",
            "Sneaky",
            "Cheating",
            "Stealth",
            "Serpent",
            "Ghost",
            "Chimaera",
            "Hippogryph",
            "Spirit",
            "Skeleton"
        };

        #endregion

        public static List<Gorilla> GetAll()
        {
            return DbContext.Current.All<Gorilla>().OrderBy(d => d.Name).ToList();
        }

        public static List<Gorilla> Find(string keyword)
        {
            List<Gorilla> Gorillas = null;

            if (keyword.Length > 0)
            {
                Gorillas = DbContext.Current.All<Gorilla>().Where(d => d.Name.ToLower().Contains(keyword.ToLower())).OrderBy(d => d.Name).ToList();
            }
            else
            {
                Gorillas = GetAll();
            }

            return Gorillas;
        }

        public static void Save(Gorilla Gorilla)
        {
            DbContext.Current.Add(Gorilla);
        }

        public static void Delete(Gorilla Gorilla)
        {
            DbContext.Current.Delete<Gorilla>(d => d.Id == Gorilla.Id);
        }

        #region Helpers

        public static Gorilla CreateRandom()
        {
            Gorilla Gorilla = new Gorilla();
            Gorilla.Name = HelperManager.CreateRandomName(_firstNames, _lastNames);
            Gorilla.Age = HelperManager.RandomGenerator.Next(1, 101);
            Gorilla.Description = "A big Gorilla.";
            Gorilla.Gold = HelperManager.RandomGenerator.Next(1, 1001);
            Gorilla.Weapon = new Breath { Name = "Breath", Description = "A breath attack.", Type = (Breath.BreathType)HelperManager.RandomGenerator.Next(0, 6) };
            Gorilla.MaxHP = HelperManager.RandomGenerator.Next(10, 21);
            Gorilla.HP = Gorilla.MaxHP;
            Gorilla.Realm = RealmManager.CreateRandom();

            return Gorilla;
        }

        #endregion
    }
}