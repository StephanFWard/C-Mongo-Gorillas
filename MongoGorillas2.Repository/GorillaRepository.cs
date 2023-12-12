using System;
using System.Collections.Generic;
using MongoGorillas2.Types;
using MongoGorillas2.Database.Interface;

namespace MongoGorillas2.Repository
{
    public class GorillaRepository
    {
        private readonly IDatabase<Gorilla> _db;

        public GorillaRepository(IDatabase<Gorilla> database)
        {
            _db = database ?? throw new ArgumentNullException(nameof(database));
        }

        public Gorilla Spawn()
        {
            try
            {
                Gorilla gorilla = new Gorilla { Name = "Test", Age = 10, Gold = 100 };

                if (_db.Add(gorilla))
                {
                    return gorilla;
                }

                // Log an error or handle the case where the Gorilla couldn't be added.
                Console.WriteLine("Failed to add Gorilla to the database.");
            }
            catch (Exception ex)
            {
                // Log or handle the exception, e.g., log.Error(ex.Message, ex);
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }

        public bool Remove(Gorilla gorilla)
        {
            try
            {
                return _db.Delete(gorilla);
            }
            catch (Exception ex)
            {
                // Log or handle the exception, e.g., log.Error(ex.Message, ex);
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public IEnumerable<Gorilla> GetGorillas()
        {
            try
            {
                return _db.Query.AsEnumerable();
            }
            catch (Exception ex)
            {
                // Log or handle the exception, e.g., log.Error(ex.Message, ex);
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Gorilla>();
            }
        }
    }
}
