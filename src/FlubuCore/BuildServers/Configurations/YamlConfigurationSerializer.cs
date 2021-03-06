﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FlubuCore.BuildServers.Configurations
{
    public class YamlConfigurationSerializer
    {
        private const string AutoGeneratedComment = @"# ----------------------
# <auto-generated>
#
#     This file was generated with FlubuCore.
#
#     To regenerate file execute 'flubu {{TargetName}} --ci={CIName}
#
# </auto-generated>
# ----------------------

";

        public string Serialize<T>(T item)
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(LowerCaseNamingConvention.Instance)
                .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
                .IgnoreFields()
                .Build();

            var yaml = serializer.Serialize(item);

            return $"{AutoGeneratedComment}{yaml}";
        }
    }
}
