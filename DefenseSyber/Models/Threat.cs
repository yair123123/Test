using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefenseSyber.Models
{
    internal class Threat
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }

        public int CalculationSeverity()
        {
            Dictionary<string, int> calculationTargetValue = new()
            {
                { "Web Server", 10 },
                { "Database", 15 },
                { "User Credentials", 20 }
            };
            int TargetValue = calculationTargetValue.GetValueOrDefault(Target, 5);
            int result = (Volume * Sophistication) + TargetValue;
            return result;
        }
    }
}
