using System;
namespace Csn.OrmEdd.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Number { get; set; }
    }
}
