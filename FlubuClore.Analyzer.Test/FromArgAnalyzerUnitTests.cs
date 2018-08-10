﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace FlubuClore.Analyzer.Tests
{
    [TestClass]
    public class FromArgAnalyzerUnitTests : CodeFixVerifier
    {
        [TestMethod]
        public void FromArgSupportedPropertyTypeTest()
        {
            var test = @"
using System;
using System.IO;
using FlubuCore.Context;
using FlubuCore.Context.FluentInterface;
using FlubuCore.Context.FluentInterface.Interfaces;
using FlubuCore.Scripting;
using FlubuCore.Targeting;
using Moq;

namespace FlubuCore.WebApi.Tests
{
   public class FromArgAttribute : Attribute
    {
        public FromArgAttribute(string argKey, string help = null)
        {
            ArgKey = argKey;
            Help = help;
        }

        public string ArgKey { get; }

        public string Help { get; }
    }

    public class SimpleScript : DefaultBuildScript
    {

        [FromArg(""t"")]
        public Int64 Test { get; set; }

        protected override void ConfigureBuildProperties(IBuildPropertiesContext context)
        {
        }

        protected override void ConfigureTargets(ITaskContext session)
        {
        }
    }
}";
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void FromArgNotSupportedPropertyTypeTest()
        {
            var test = @"
using System;
using System.IO;
using FlubuCore.Context;
using FlubuCore.Context.FluentInterface;
using FlubuCore.Context.FluentInterface.Interfaces;
using FlubuCore.Scripting;
using FlubuCore.Targeting;
using Moq;

namespace FlubuCore.WebApi.Tests
{
   public class FromArgAttribute : Attribute
    {
        public FromArgAttribute(string argKey, string help = null)
        {
            ArgKey = argKey;
            Help = help;
        }

        public string ArgKey { get; }

        public string Help { get; }
    }

    public class SimpleScript : DefaultBuildScript
    {

        [FromArg(""t"")]
        public object Test { get; set; }

        protected override void ConfigureBuildProperties(IBuildPropertiesContext context)
        {
        }

        protected override void ConfigureTargets(ITaskContext session)
        {
        }
    }
}";
            var expected = new DiagnosticResult
            {
                Id = "FlubuCore_FromArgUnsuportedPropertyType",
                Message = String.Format("FromArg does not support type '{0}' on property.",  "Object"),
                Severity = DiagnosticSeverity.Warning,
                Locations =
                    new[] {
                        new DiagnosticResultLocation("Test0.cs", 29, 10)
                    }
            };

            VerifyCSharpDiagnostic(test, expected);
        }

        
        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new FromArgAnalyzer();
        }
    }
}