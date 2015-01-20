using com.vmware.vcloud.sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyScapeDeploy
{
    public class Client
    {
        public static vCloudClient vClient;
        
        public static void Init(){
            if (Credentials.IsSet())
            {

                vClient = new vCloudClient(Credentials.GetUrl(), com.vmware.vcloud.sdk.constants.Version.V5_1);
                string user = Credentials.GetUser()+"@"+Credentials.GetOrg();
                string pass = Credentials.GetPass();
                vClient.Login(user,pass);
                Console.WriteLine("SkyScape Login Successful.\n");

            }
        }
        
    }
}
