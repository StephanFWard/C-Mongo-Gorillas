using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoGorillas2.Types;
using MongoGorillas2.Database.Interface;
using MongoGorillas2.Database.Concrete;

namespace MongoGorillas2.Repository
{
public static class GorillaRepository
{
    private static IDatabase<Gorilla> _db = new MongoDatabase<Gorilla>("Gorilla");

    public static Gorilla Spawn()
    {
        Gorilla Gorilla = new Gorilla() { Name = "Test", Age = 10, Gold = 100 };

        // Save object.
        if (!_db.Add(Gorilla))
        {
            Gorilla = null;
        }

        return Gorilla;
    }

    public static bool Remove(Gorilla Gorilla)
    {
        return _db.Delete(Gorilla);
    }

    public static IEnumerable<Gorilla> ToList()
    {
        return _db.Query.AsEnumerable();
    }
}
}
