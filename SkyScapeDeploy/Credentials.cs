using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyScapeDeploy
{
    public class Credentials
    {
        private static string user;
        private static string pass;
        private static string org;
        private static string url;

        private static bool isSet = false;

        public static void SetCredentials(string User, string Pass, string Org, string Url)
        {

            user = User;
            pass = Pass;
            org = Org;
            url = Url;
            isSet = true;
        }

        public static string GetUser()
        {
            return user;
        }

        public static string GetPass()
        {
            return pass;
        }

        public static string GetOrg()
        {
            return org;
        }

        public static string GetUrl()
        {
            return url;
        }

        public static bool IsSet()
        {

            return isSet;
        }

    }
}
