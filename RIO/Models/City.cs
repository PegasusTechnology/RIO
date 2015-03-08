using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("City")]
    public class City
    {

        #region Public Properties

        public int CityId { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        public virtual State State { get; set; }

        [DisplayName("City")]
        [Required]
        [StringLength(250)]
        public string CityName { get; set; }

        [DisplayName("Sort Order")]
        public int SortOrder { get; set; }
        
        public bool IsActive { get; set; }

        #endregion

    }
}