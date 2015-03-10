using RIO.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RIO.Models.ViewModels
{
    public class ItemCreateViewModel
    {

        #region Public Properties

        public IEnumerable<SelectListItem> Category { get; set; }

        [Required]
        public int? SelectedCategoryId { get; set; }

        public IEnumerable<SelectListItem> Brand { get; set; }

        [Required]
        public int? SelectedBrandId { get; set; }

        public IEnumerable<SelectListItem> Address { get; set; }

        [Required]
        public int? SelectedAddressId { get; set; }

        [DisplayName("Item")]
        [Required]
        [StringLength(150)]
        public string ItemName { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        [StringLength(1000)]
        public string ItemDescription { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public int? Phone { get; set; }

        public IEnumerable<SelectListItem> Costing { get; set; }

        [Required]
        public int? SelectedCostingId { get; set; }

        public IEnumerable<IdentityProof> IdentityProof { get; set; }        

        public int[] SelectedIdentityProofId { get; set; }

        //public virtual ICollection<ItemImage> Images { get; set; }

        [ValidateImage]
        public HttpPostedFileBase Image { get; set; }

        public string ImagePath { get; set; }

        #endregion

    }
}