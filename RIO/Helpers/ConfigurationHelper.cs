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

        public static string UploadPath
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadPath"];
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

        #endregion

    }
}