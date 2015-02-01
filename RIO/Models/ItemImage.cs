using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("ItemImage")]
    public class ItemImage
    {

        #region Public Properties

        public int ItemImageId { get; set; }

        public int ItemId { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required]
        [StringLength(500)]
        public string ImagePath { get; set; }

        #endregion

    }
}