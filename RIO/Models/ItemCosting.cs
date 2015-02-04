using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("ItemCosting")]
    public class ItemCosting
    {

        #region Public Properties

        public int ItemCostingId { get; set; }

        public int ItemId { get; set; }

        public int CostingId { get; set; }

        #endregion

    }
}