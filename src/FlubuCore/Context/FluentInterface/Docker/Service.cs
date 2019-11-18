
//-----------------------------------------------------------------------
// <auto-generated />
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Tasks.Docker.Service;

namespace FlubuCore.Context.FluentInterface.Docker
{
    public class Service
    {  
        
            
        /// <summary>
        /// Create a new service
        /// </summary>
            public DockerServiceCreateTask ServiceCreate(string image ,  string command = null ,  params string[] arg)
            {
                return new DockerServiceCreateTask(image,  command,  arg);
            }


            
        /// <summary>
        /// Display detailed information on one or more services
        /// </summary>
            public DockerServiceInspectTask ServiceInspect(params string[] service)
            {
                return new DockerServiceInspectTask(service);
            }


            
        /// <summary>
        /// Fetch the logs of a service or task
        /// </summary>
            public DockerServiceLogsTask ServiceLogs(string service)
            {
                return new DockerServiceLogsTask(service);
            }


            
        /// <summary>
        /// List services
        /// </summary>
            public DockerServiceLsTask ServiceLs()
            {
                return new DockerServiceLsTask();
            }


            
        /// <summary>
        /// List the tasks of one or more services
        /// </summary>
            public DockerServicePsTask ServicePs(params string[] service)
            {
                return new DockerServicePsTask(service);
            }


            
        /// <summary>
        /// Revert changes to a service's configuration
        /// </summary>
            public DockerServiceRollbackTask ServiceRollback(string service)
            {
                return new DockerServiceRollbackTask(service);
            }


            
        /// <summary>
        /// Scale one or multiple replicated services
        /// </summary>
            public DockerServiceScaleTask ServiceScale()
            {
                return new DockerServiceScaleTask();
            }


            
        /// <summary>
        /// Update a service
        /// </summary>
            public DockerServiceUpdateTask ServiceUpdate(string service)
            {
                return new DockerServiceUpdateTask(service);
            }

        
    }
}
