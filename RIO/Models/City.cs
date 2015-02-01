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

        public int StateId { get; set; }

        [DisplayName("City")]
        [Required]
        [StringLength(250)]
        public string CityName { get; set; }

        [DisplayName("Sort Order")]
        public int SortOrder { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        #endregion

    }
}