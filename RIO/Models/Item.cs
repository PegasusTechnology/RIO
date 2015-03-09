using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace RIO.Models
{
    [Table("Item")]
    public class Item
    {

        #region Constructors

        public Item()
        {
            //PostedUserId = WebSecurity.CurrentUserId;
            PostedDate = DateTime.Now;
            IsActive = true;
        }

        #endregion

        #region Public Properties

        public int ItemId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [ForeignKey("User")]
        public int? PostedUserId { get; set; }

        public virtual User User { get; set; }

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

        public virtual ICollection<ItemCosting> ItemCosting { get; set; }

        public virtual ICollection<ItemRequiredDocument> RequiredDocuments { get; set; }

        public virtual ICollection<ItemImage> Images { get; set; }

        public bool IsActive { get; set; }

        #endregion

    }
}