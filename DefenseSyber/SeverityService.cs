using DefenseSyber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DefenseSyber
{
    internal static class SeverityService
    {
        public static bool FindRange(Defense defense, int value)
        {
            if (defense.MinSeverity <= value && defense.MaxSeverity >= value) return true;
            return false;
        }
        public static bool Bigger(Defense defense, int value)
        {
            if (defense.MaxSeverity < value) return true;
            return false;
        }
        public static bool Smaller(Defense defense, int value)
        {
            if (defense.MinSeverity > value) return true;
            return false;
        }


    }

}
