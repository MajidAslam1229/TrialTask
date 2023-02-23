using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialTask.Objects
{
    public class ResponseObject
    {
        public bool Success { get; set; } = true;
        public Object Error { get; set; } 
        public Object Data { get; set; }

    }
}
