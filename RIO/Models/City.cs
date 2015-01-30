using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("City")]
    public class City
    {

        public int CityID { get; set; }

        public int StateID { get; set; }

        [StringLength(250)]
        [Required]
        public string CityName { get; set; }

    }
}