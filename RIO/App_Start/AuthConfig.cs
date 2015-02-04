using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using RIO.Models;

namespace RIO
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //P@$$word1 - James Bonda - iam_invincible@outlook.com
            OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "0000000040140814",
                clientSecret: "QkX9bqz0h1kE-wB5aDluDVoWp6UEXh9T");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //P@$$word1 - James Bonda
            OAuthWebSecurity.RegisterFacebookClient(
                appId: "541694889266197",
                appSecret: "35fd71113ae77e5329ecf8001c7f12c1");

            OAuthWebSecurity.RegisterGoogleClient();

            OAuthWebSecurity.RegisterYahooClient();
        }
    }
}
