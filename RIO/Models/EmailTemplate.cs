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
        public string EmailTemplateCode { get; set; }

        [StringLength(150)]
        public string EmailFrom { get; set; }

        [StringLength(1000)]
        public string EmailTo { get; set; }

        [StringLength(1000)]
        public string EmailCc { get; set; }

        [StringLength(1000)]
        public string EmailBcc { get; set; }

        [StringLength(500)]
        public string EmailSubject { get; set; }

        [DataType(DataType.Html)]
        public string EmailBody { get; set; }

        #endregion

    }
}