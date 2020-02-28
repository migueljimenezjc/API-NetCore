using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API.Entities.Entities
{
    public class Receipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string provider { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public DateTime date { get; set; }
        public string commentary { get; set; }
    }
}
