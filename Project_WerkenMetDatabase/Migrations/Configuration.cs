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
           

            ////1. maak lijst
            //var vPresidents = new List<President>();
            ////2. GetFileme
            //string vFileName = this.MapPath("/Data/TestData.txt");

            //string[] vLines = File.ReadAllLines(vFileName);

            //foreach (string line in vLines)
            //{
            //    string[] fields = line.Split(',');
            //    string[] dates = fields[2].Split('-');
            //    vPresidents.Add(new President()
            //    {
            //        Name = fields[1],
            //        StartDate = new DateTime(int.Parse(dates[0]), 1, 1),
            //        EndDate = new DateTime(int.Parse(dates[1]), 1, 1),
            //        Opmerking = fields[3]

            //    });
            //}


            ////3. AddOrUpdate
            //context.Presidents.AddOrUpdate(p => p.Name, vPresidents.ToArray());
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
