﻿using ExecuteRoslyn.Declarations.Native.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteRoslyn.Declarations.Native
{
    public class Variable : IDeclaration
    {
        public string? Name { get; set; }
        public string? Modifier { get; set; }
    }
}
