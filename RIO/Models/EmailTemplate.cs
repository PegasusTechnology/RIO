using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("EmailTemplate")]
    public class EmailTemplate
    {

        #region Public Properties

        public int EmailTemplateId { get; set; }

        [Required]
        [StringLength(150)]
        public string TemplateCode { get; set; }

        [StringLength(150)]
        public string From { get; set; }

        [StringLength(1000)]
        public string To { get; set; }

        [StringLength(1000)]
        public string Cc { get; set; }

        [StringLength(1000)]
        public string Bcc { get; set; }

        [StringLength(500)]
        public string Subject { get; set; }

        [DataType(DataType.Html)]
        public string Body { get; set; }
        
        public bool IsActive { get; set; }

        #endregion

    }
}