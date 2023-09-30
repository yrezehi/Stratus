using Stratus.Declarations.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stratus.Generator
{
    public class ClassBuilder
    {
        protected Class Class;

        private ClassBuilder() { 
            
            Class = new Class(); 
        }

        public static ClassBuilder Builder() => new ClassBuilder();

        public ClassBuilder WithName(string name)
        {
            Class.Name = name;
            return this;
        }

        public Class Build() => Class;
    }
}
