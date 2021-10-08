using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDbLib.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(30)] //use attribute to designate max length, unique, attributes go in []
        [Required] //will force string column to be not null in db
        public string Code { get; set; }
        [StringLength(30), Required] //can also do multiple attributes in one [] to achieve same goal as above with code
        public string Name { get; set; }
        [Column(TypeName = "decimal(11,2)") ] //type sql uses for column
        public decimal Sales { get; set; }
        public DateTime Created { get; set; }

        public Customer() { }


    }
}
