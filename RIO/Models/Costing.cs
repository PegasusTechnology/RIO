﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("Costing")]
    public class Costing
    {

        #region Public Properties

        public int CostingId { get; set; }

        [DisplayName("Costing")]
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
       
        public bool IsActive { get; set; }

        #endregion

    }
}