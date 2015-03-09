using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RIO.Helpers
{
    public static class ConfigurationHelper
    {

        #region Protected Properties

        public static string UploadFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadFolder"];
            }
        }

        public static string ThumbnailWidth
        {
            get
            {
                return ConfigurationManager.AppSettings["ThumbnailWidth"];
            }
        }

        public static string ThumbnailHeight
        {
            get
            {
                return ConfigurationManager.AppSettings["ThumbnailHeight"];
            }
        }

        public static string MaximumImageSizeBytes
        {
            get
            {
                return ConfigurationManager.AppSettings["MaximumImageSizeBytes"];
            }
        }

        public static string AllowedImageExtensions
        {
            get
            {
                return ConfigurationManager.AppSettings["AllowedImageExtensions"];
            }
        }

        #endregion

    }
}