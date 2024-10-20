using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Activities
{
    public class Meeting : Activity
    {
        public string Topic { get; set; } = String.Empty;
    }
}