using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("State")]
    public class State
    {

        public int StateID { get; set; }

        public int CountryID { get; set; }

        [StringLength(250)]
        [Required]
        public string StateName { get; set; }

        public virtual ICollection<City> CityCollection { get; set; }

    }
}