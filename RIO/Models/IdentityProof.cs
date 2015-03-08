using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("IdentityProof")]
    public class IdentityProof
    {

        #region Public Properties

        public int IdentityProofId { get; set; }

        [DisplayName("Identity Proof")]
        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [DisplayName("Sort Order")]
        public int SortOrder { get; set; }
       
        public bool IsActive { get; set; }

        #endregion

    }
}