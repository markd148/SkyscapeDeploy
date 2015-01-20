using com.vmware.vcloud.sdk.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.SourceLevel(Levels.Off);

            string user = ""; // Username
            string pass = ""; // Password
            string org = ""; // Organsiation Id
            string url = "https://api.vcd.portal.skyscapecloud.com";

            try
            {

            SkyScapeDeploy.Credentials.SetCredentials(user, pass, org, url);
            SkyScapeDeploy.Client.Init();
            
            ////ENVIRONMENT INFO
            Console.WriteLine("Getting Environment Info:");
            SkyScapeDeploy.VCloud.GetEnvironmentInfo();
            Console.WriteLine("End");

            //LIST OF ORGS
            Console.WriteLine("Getting List of available Organisations:");
            {
                foreach (string s in SkyScapeDeploy.VCloud.GetOrganisations())
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("End");
            ////**************************

            Console.WriteLine("Loading vApp from JSON");

            Console.WriteLine(SkyScapeDeploy.Deployment.YmlToXml("vapp1.json"));

            Console.ReadLine();

            }

            catch (UnauthorizedAccessException e)
            {
                Logger.Log(TraceLevel.Critical, e.Message);
                Console.WriteLine(e.Message);
            }
            catch (VCloudException e)
            {
                Logger.Log(TraceLevel.Critical, e.Message);
                Console.WriteLine(e.Message);
            }

            catch (System.IO.IOException e)
            {
                Logger.Log(TraceLevel.Critical, e.Message);
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Logger.Log(TraceLevel.Critical, e.Message);
                Console.WriteLine(e.Message);
            }

        }
    }
}
