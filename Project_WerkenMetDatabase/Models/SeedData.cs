using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_WerkenMetDatabase.Models
{
    public class SeedData
    {
        //Fields
        private ApplicationDbContext db = new ApplicationDbContext();

        //Methods

        public string RunSeed()
        {
            //Controle
            if ( HasData<Category>() && HasData<Nominee>() && HasData<President>())
            {               
                return "Cannot run Seed, Data already present in tables";
            }
            //Run Seed        
            RunSeedFromFile<Category>("Categories",';');
            RunSeedFromFile<Nominee>("Nominees", ';');
            //RunSeedFromFile<President>("TestData", ',');

            return "Seed... Complete!";
        }

        public string RemoveSeedData<T>() where T:class
        {
            db.Set<T>().RemoveRange(db.Set<T>());
            db.SaveChanges();
            return "Data bye bye";
        }

        // Private Methods

        private void RunSeedFromFile<T>(string fileName, char splitOn) where T:class, new()
        {
            // Lees het bestand
            string vFullFileName = HttpContext.Current.Server.MapPath(@"/Data/" + fileName + ".txt");
            string[] vLines = System.IO.File.ReadAllLines(vFullFileName);

            // loop
            foreach (string line in vLines)
            {
                string[] vFields = line.Split(splitOn);

                db.Set<T>().Add(CreateObject<T>(vFields));
            }

            // Opslaan
            db.SaveChanges();
        }

        private T CreateObject<T>(string[] fields) where T:class, new()
        {
            
            // Create new Object, intantiate new Object, Pass in arguments for properties
            return (T)Activator.CreateInstance(typeof(T), new Object[] { fields });
        }
      
        public bool HasData<T>() where T:class
        {
            return db.Set<T>().Any();
        }
    }
}