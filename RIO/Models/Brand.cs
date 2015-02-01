using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("Brand")]
    public class Brand
    {

        #region Public Properties

        public int BrandId { get; set; }

        [DisplayName("Brand")]
        [Required]
        [StringLength(250)]
        public string BrandName { get; set; }

        [DisplayName("Sort Order")]
        public int SortOrder { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        #endregion

    }
}