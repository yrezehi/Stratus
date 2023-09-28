using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratus.Declarations.Native.Abstracts
{
    public interface IDeclaration<T> where T : new()
    {
        public string? Name { get; set; }
        public string? Modifier { get; set; }

        public static T Create(string name, string modifier) => new T();
    }
}
