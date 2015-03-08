using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("ItemRequest")]
    public class ItemRequest
    {

        #region Public Properties

        public int ItemRequestId { get; set; }

        public int ItemId { get; set; }

        [Column("RequestorId")]
        public int UserId { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RequestedDateFrom { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RequestedDateTo { get; set; }

        [DataType(DataType.MultilineText)]
        public int Remarks { get; set; }

        public RequestStatus RequestStatus { get; set; }
        
        public bool IsActive { get; set; }

        #endregion

    }

    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}