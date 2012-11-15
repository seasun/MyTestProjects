using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EF.Experience.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class School : DbContext {
        public DbSet<Person> Persons { get; set; }
    }
}