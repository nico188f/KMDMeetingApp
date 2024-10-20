using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Activities
{
    public class JobInterview : Activity
    {
        public string CandidateName { get; set; } = String.Empty;
    }
}