using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("Item")]
    public class Item
    {

        #region Public Properties

        public int ItemId { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public Address Address { get; set; }

        [DisplayName("Item Name")]
        [Required]
        [StringLength(150)]
        public string ItemName { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Item Description")]
        [StringLength(1000)]
        public string ItemDescription { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public int Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Posted Date")]
        public DateTime PostedDate { get; set; }

        public ICollection<Costing> Costing { get; set; }

        public ICollection<ItemRequiredDocument> RequiredDocuments { get; set; }

        public ICollection<ItemImage> Images { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        #endregion

    }
}