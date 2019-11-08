
//-----------------------------------------------------------------------
// <auto-generated />
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Context;
using FlubuCore.Tasks;
using FlubuCore.Tasks.Attributes;
using FlubuCore.Tasks.Process;

namespace FlubuCore.Tasks.Docker.Manifest
{
     public partial class DockerManifestCreateTask : ExternalProcessTaskBase<int, DockerManifestCreateTask>
     {
        private string _manifest_list;
private string[] _manifest;

        
        public DockerManifestCreateTask(string manifest_list,  params string[] manifest)
        {
            ExecutablePath = "docker";
            WithArguments("manifest create");
_manifest_list = manifest_list;
_manifest = manifest;

        }

        protected override string Description { get; set; }
        
        /// <summary>
        /// Amend an existing manifest list
        /// </summary>
        [ArgKey("--amend")]
        public DockerManifestCreateTask Amend()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        /// <summary>
        /// Allow communication with an insecure registry
        /// </summary>
        [ArgKey("--insecure")]
        public DockerManifestCreateTask Insecure()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }
        protected override int DoExecute(ITaskContextInternal context)
        {
             WithArguments(_manifest_list);
 WithArguments(_manifest);

            return base.DoExecute(context);
        }

     }
}