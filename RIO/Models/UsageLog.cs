using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("UsageLog")]
    public class UsageLog
    {

        #region Public Properties

        public int UsageLogId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [DataType(DataType.Url)]
        [StringLength(500)]
        public string Url { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        [StringLength(1000)]
        public string ActionDetails { get; set; }

        [StringLength(50)]
        public string Device { get; set; }

        [StringLength(100)]
        public string Browser { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LogDate { get; set; }

        #endregion

    }
}