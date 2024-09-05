using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefenseSyber.Models
{
    internal class Defense
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }

        public Defense(int minSeverity, int maxSeverity, List<string> defenses)
        {
            MinSeverity = minSeverity;
            MaxSeverity = maxSeverity;
            Defenses = defenses;
        }
        public override string ToString()
        {
           string result = $"MinSeverity: {MinSeverity} MaxSeverity: {MaxSeverity} Defenses:[{string.Join(",",Defenses)}]";
            return result;
        }

    }
}
