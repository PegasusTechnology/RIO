using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("ItemRequiredDocument")]
    public class ItemRequiredDocument
    {

        #region Public Properties

        public int ItemRequiredDocumentId { get; set; }

        public int ItemId { get; set; }

        public int IdentityProofId { get; set; }

        #endregion

    }
}