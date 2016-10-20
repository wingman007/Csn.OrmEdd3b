namespace Csn.OrmEdd.Models
{
    using System;
    using System.Collections.Generic;
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public List<Phone> Phones { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}",
                Id, Name, 
                FamilyName, 
                BirthDate.ToString("yyyy-MM-dd"),
                Address);
        }
    }
}
