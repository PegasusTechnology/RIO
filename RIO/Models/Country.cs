using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("Country")]
    public class Country
    {

        #region Public Properties

        public int CountryId { get; set; }

        [DisplayName("Country")]
        [Required]
        [StringLength(250)]
        public string CountryName { get; set; }

        [DisplayName("Sort Order")]
        public int SortOrder { get; set; }

        public virtual ICollection<State> States { get; set; }
        
        public bool IsActive { get; set; }

        #endregion

    }
}