using RIO.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace RIO.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ValidateImageAttribute : ValidationAttribute
    {

        #region Protected Overrides

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            HttpPostedFileBase file = value as HttpPostedFileBase;

            //// The file is required.
            //if (file == null)
            //{
            //    return new ValidationResult("Please upload a file!");
            //}

            if (file != null)
            {
                // The maximum allowed file size
                if (file.ContentLength > Convert.ToInt32(ConfigurationHelper.MaximumImageSizeBytes))
                {
                    return new ValidationResult("Image is too big. Please try image with size less than 2 MB.");
                }

                // Only image files can be uploaded.
                string extension = Path.GetExtension(file.FileName);
                if (string.IsNullOrEmpty(extension) || !ConfigurationHelper.AllowedImageExtensions.Contains(extension))
                {
                    return new ValidationResult(string.Format("Uploaded file is not an image. Please upload an image ({0}).",
                        ConfigurationHelper.AllowedImageExtensions));
                }
            }

            // Everything OK.
            return ValidationResult.Success;
        }

        #endregion

    }
}