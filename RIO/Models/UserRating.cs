using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("UserRating")]
    public class UserRating
    {

        #region Public Properties

        public int UserRatingId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int Rating { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        public bool ThumbsUp { get; set; }
       
        public bool IsActive { get; set; }

        #endregion

    }
}