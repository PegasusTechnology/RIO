using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("State")]
    public class State
    {

        #region Public Properties

        public int StateId { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        [DisplayName("State")]
        [Required]
        [StringLength(250)]
        public string StateName { get; set; }

        [DisplayName("Sort Order")]
        public int SortOrder { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        
        public bool IsActive { get; set; }

        #endregion

    }
}