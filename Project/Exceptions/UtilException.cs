﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Exceptions
{
    class UtilException : Exception
    {
        public UtilException(String message) : base(message) { }
    }
}
