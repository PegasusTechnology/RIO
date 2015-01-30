using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("Country")]
    public class Country
    {
     
        public int CountryID { get; set; }

        [StringLength(250)]
        [Required]
        public string CountryName { get; set; }
     
        public virtual ICollection<State> StateCollection { get; set; } 

    }
}