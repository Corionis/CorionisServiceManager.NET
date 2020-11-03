using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceProcess;

namespace CorionisServiceManager.NET
{
    public class Services
    {
        private Config cfg;
        public ServiceController[] allServices { get; set; }
        public List<MonitoredService> monitoredServices { get; set; }
        public ServiceController[] selectedServices { get; set; }

        public Services(ref Config theCfg)
        {
            this.cfg = theCfg;
        }

        public void GetAllServices()
        {
            allServices = ServiceController.GetServices();
            Array.Sort(allServices, new ServiceComparer());
        }

        public void GetSelectedServices()
        {
            if (allServices == null)
            {
                GetAllServices();
            }

            int i = 0;
            selectedServices = new ServiceController[cfg.SelectedServiceIds.Length];
            monitoredServices = new List<MonitoredService>();

            foreach (Config.ServiceIdNamePair servicePair in cfg.SelectedServiceIds)
            {
                if (servicePair.Identifier.Length > 0)
                {
                    foreach (var service in allServices)
                    {
                        if (service.ServiceName.Equals(servicePair.Identifier))
                        {
                            selectedServices[i] = service;

                            MonitoredService mon = new MonitoredService();
                            mon.Picked = false;
                            mon.Name = servicePair.Name; // saved variation
                            mon.Identifier = service.ServiceName;
                            mon.Startup = service.StartType.ToString();
                            mon.Status = service.Status.ToString();
                            monitoredServices.Add(mon);
                            ++i;
                        }
                    }
                }
            }
        }
    }

    public class MonitoredService
    {
        public bool Picked { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Startup { get; set; }
        public string Status { get; set; }
    }

    class ServiceComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(((ServiceController)x).DisplayName, ((ServiceController)y).DisplayName);
        }
    }

}
