using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net;
using com.vmware.vcloud.sdk;
using com.vmware.vcloud.sdk.admin;
using com.vmware.vcloud.sdk.utility;
using com.vmware.vcloud.api.rest.schema;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace SkyScapeDeploy
{
    public class VCloud
    {
        public static void GetEnvironmentInfo()
        {

            Dictionary<string, ReferenceType> orgsList = Client.vClient.GetOrgRefsByName();
            foreach (ReferenceType orgRef in orgsList.Values)
            {
                foreach (ReferenceType vdcRef in Organization.GetOrganizationByReference(Client.vClient, orgRef)
                        .GetVdcRefs())
                {
                    Vdc vdc = Vdc.GetVdcByReference(Client.vClient, vdcRef);
                    Console.WriteLine("Vdc: " + vdcRef.name + " : "
                            + vdc.Resource.AllocationModel);
                    foreach (ReferenceType vAppRef in Vdc.GetVdcByReference(
                            Client.vClient, vdcRef).GetVappRefs())
                    {
                        Console.WriteLine("Vapp: " + vAppRef.name);
                        Vapp vapp = Vapp.GetVappByReference(Client.vClient, vAppRef);
                        List<VM> vms = vapp.GetChildrenVms();
                        foreach (VM vm in vms)
                        {
                            Console.WriteLine("Vm : " + vm.Resource.name);
                            Console.WriteLine("Status : " + vm.GetVMStatus());
                            Console.WriteLine("CPU : " + vm.GetCpu().GetNoOfCpus());
                            Console.WriteLine("Memory : " + vm.GetMemory().GetMemorySize() + "Mb");
                            foreach (VirtualDisk disk in vm.GetDisks())
                                try
                                {
                                    if (disk.IsHardDisk())
                                        Console.WriteLine("HardDisk : " + disk.GetHardDiskSize() + "Mb");
                                }
                                catch (Exception e)
                                {
                                    Logger.Log(TraceLevel.Critical, e.Message);
                                    Console.WriteLine(e.Message);
                                }
                        }

                    }

                }
            }

        }

        public static List<string> GetOrganisations()
        {
            List<string> Orgs = new List<string>();

            Dictionary<string, ReferenceType> orgsList = Client.vClient.GetOrgRefsByName();

            foreach (ReferenceType orgRef in orgsList.Values)
            {
                Orgs.Add(orgRef.name);
            }

            return Orgs;
        }


    }

}