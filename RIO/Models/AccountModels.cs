using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
using System.Web.Security;

namespace RIO.Models
{
    public class RIOContext : DbContext
    {
        public RIOContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Costing> Costing { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<EmailTemplate> EmailTemplate { get; set; }

        public DbSet<IdentityProof> IdentityProof { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<ItemCosting> ItemCosting { get; set; }

        public DbSet<ItemImage> ItemImage { get; set; }

        public DbSet<ItemRequest> ItemRequest { get; set; }

        public DbSet<ItemRequiredDocument> ItemRequiredDocument { get; set; }

        public DbSet<RIOConfiguration> RIOConfiguration { get; set; }

        public DbSet<State> State { get; set; }

        public DbSet<UsageLog> UsageLog { get; set; }

        public DbSet<UserRating> UserRating { get; set; }

        public DbSet<ExternalUserInformation> ExternalUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }

    [Table("User")]
    public class User
    {

        #region Public Properties

        public int UserId { get; set; }

        [DisplayName("User Name")]
        [Required]
        [StringLength(500)]
        public string UserName { get; set; }

        [DisplayName("First Name")]
        //[Required]
        [StringLength(500)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        //[Required]
        [StringLength(500)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        //[Required]
        public string EmailId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        //[Required]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone")]
        public int Phone { get; set; }

        [DataType(DataType.ImageUrl)]
        [StringLength(500)]
        public string Photo { get; set; }

        [NotMapped]
        public int KarmaPoint { get; set; }
        
        public bool IsActive { get; set; }

        #endregion

    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Personal page link")]
        public string Link { get; set; }

    }

    [Table("ExtraUserInformation")]
    public class ExternalUserInformation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Link { get; set; }
        public bool? Verified { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
