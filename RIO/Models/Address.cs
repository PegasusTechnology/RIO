using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RIO.Models
{
    [Table("Address")]
    public class Address
    {

        #region Public Properties

        public int AddressId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [DisplayName("Address Line 1")]
        [Required]
        [StringLength(500)]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        [Required]
        [StringLength(500)]
        public string AddressLine2 { get; set; }

        [DisplayName("Address Line 3")]
        [StringLength(500)]
        public string AddressLine3 { get; set; }

        [DataType(DataType.PostalCode)]
        [Required]
        public int PinCode { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        public virtual State State { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        [DisplayName("Set As Default")]
        public bool IsDefault { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        #endregion

    }
}