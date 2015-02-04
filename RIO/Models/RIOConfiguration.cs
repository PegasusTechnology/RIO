using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("Configuration")]
    public class RIOConfiguration
    {

        #region Public Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConfigurationId { get; set; }

        [Required]
        [StringLength(250)]
        public string Key { get; set; }

        [Required]
        [StringLength(1000)]
        public string Value { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        #endregion

    }
}