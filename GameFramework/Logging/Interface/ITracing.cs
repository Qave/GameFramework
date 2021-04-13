using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameFramework.Logging.Interface
{
    public interface ITracing
    {
        TraceSource TraceSource { get; set; }
    }
}
