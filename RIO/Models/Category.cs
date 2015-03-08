using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("Category")]
    public class Category
    {

        #region Public Properties

        public int CategoryId { get; set; }

        [DisplayName("Category")]
        [Required]
        [StringLength(1000)]
        public string CategoryName { get; set; }

        [DisplayName("Sort Order")]
        public int SortOrder { get; set; }

        [DisplayName("Hierarchy Level")]
        public int HierarchyLevel { get; set; }

        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }
       
        public bool IsActive { get; set; }

        #endregion

    }
}