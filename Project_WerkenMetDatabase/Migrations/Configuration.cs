namespace Project_WerkenMetDatabase.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Hosting;

    internal sealed class Configuration : DbMigrationsConfiguration<Project_WerkenMetDatabase.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Project_WerkenMetDatabase.Models.ApplicationDbContext context)
        {
            ////1. Maak lijst
            //var Presidents = new List<President>()
            //{
            //    new President() {Name = "George Washington",StartDate = new DateTime(1789,01,01) , EndDate = new DateTime(1796,01,01), Opmerking="De eerste president van de USA" },
            //    new President() {Name = "Richard Nixon",StartDate = new DateTime(1969,01,01), EndDate = new DateTime(1974,01,01), Opmerking="President tijdens de Vietnam oorlog" },
            //    new President() {Name = "Bill Clinton",StartDate = new DateTime(1993,01,01), EndDate = new DateTime(2001,01,01), Opmerking="Heeft geen sex gehad" },
            //    new President() {Name = "Barack Obama",StartDate = new DateTime(2009,01,01), EndDate = new DateTime(2017,01,01), Opmerking="De eerste zwarte president" },
            //    new President() {Name = "Donald Trump",StartDate = new DateTime(2017,01,01), EndDate = new DateTime(2017,01,01), Opmerking="Gaat een muur bouwen" },
            //    new President() {Name = "Franklin D. Roosevelt",StartDate = new DateTime(1933,01,01), EndDate = new DateTime(1945,01,01), Opmerking="President tijdends Wereld Oorlog 2" },
            //    new President() {Name = "Dwight D. Eisenhower",StartDate = new DateTime(1953,01,01), EndDate = new DateTime(1961,01,01), Opmerking="Generaal tijdens Wereld Oorlog 2" },
            //    new President() {Name = "Ulysses S. Grant",StartDate = new DateTime(1869,01,01), EndDate = new DateTime(1877,01,01), Opmerking="Generaal tijdens de burger oorlog" },
            //    new President() {Name = "Abraham Lincoln",StartDate = new DateTime(1861,01,01), EndDate = new DateTime(1865,01,01), Opmerking="Afschaffing van slavernij" }
            //};

            //1. maak lijst
            var vPresidents = new List<President>();
            //2. GetFileme
            string vFileName = this.MapPath("/Data/TestData.txt");

            string[] vLines = File.ReadAllLines(vFileName);

            foreach (string line in vLines)
            {
                string[] fields = line.Split(',');
                string[] dates = fields[2].Split('-');
                vPresidents.Add(new President()
                {
                    Name = fields[1],
                    StartDate = new DateTime(int.Parse(dates[0]), 1, 1),
                    EndDate = new DateTime(int.Parse(dates[1]), 1, 1),
                    Opmerking = fields[3]

                });
            }


            //3. AddOrUpdate
            context.Presidents.AddOrUpdate(p => p.Name, vPresidents.ToArray());
        }

        private string MapPath(string seedFile)
        {
            if(HttpContext.Current != null)
            {
                return HostingEnvironment.MapPath(seedFile);
            }

            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName, ".." + seedFile.TrimStart('~').Replace('/', '\\'));

            return path;
        }
    }
}
