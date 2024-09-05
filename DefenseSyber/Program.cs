using DefenseSyber.Models;
using JsonPractice;
using System.Threading;

namespace DefenseSyber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BsTree DefencesTree = new();
            List<Defense> defences = JsonService.ReadFromJson<List<Defense>>("defenceStrategiesBalanced.json");
            defences.ForEach(DefencesTree.Insert);
            DefencesTree.PreOrderPrint();
            //DefencesTree.Remuve(3);
            List<Threat> threats = JsonService.ReadFromJson<List<Threat>>("threats.json");
            StartThreats(threats, DefencesTree);


            // עד כאן התרגיל ללא הבונוס 


            Console.WriteLine("\n");
            Console.WriteLine("Click to proceed to the bonus");
            Console.ReadLine();
            BsTree DefencesTreeBalnced = new();
            List<Defense> defencesBalnced = JsonService.ReadFromJson<List<Defense>>("defenceStrategiesNonBalanced.json");
            defencesBalnced.ForEach(DefencesTreeBalnced.Insert);
            List<TreeNode> a = DefencesTreeBalnced.InOrder();
            DefencesTreeBalnced.PreOrderPrint();
            DefencesTreeBalnced = DefencesTreeBalnced.Balance();
            DefencesTreeBalnced.PreOrderPrint();
        }
        public static void StartThreats(List<Threat> threats, BsTree DefencesTree)
        {
            foreach (var threat in threats)
            {
                Console.WriteLine("------START THREAT--------");
                if (threat.CalculationSeverity() < DefencesTree.FindMim().Value.MinSeverity)
                {
                    Console.WriteLine("Attack severity is below the threshold. Attack is ignored");
                    continue;
                }
                var result = DefencesTree.SearchPreOrder(threat.CalculationSeverity());

                if (result is null)
                {
                    Console.WriteLine("No suitable defence was found. Brace for impact");
                    continue;
                }
                foreach (var item in result.Value.Defenses)
                {
                    Console.WriteLine(item);
                    Thread.Sleep(2000);
                }
                Console.WriteLine("------END THREAT--------");
            }
        }
    }
    static class StringExtensions
    {
        public static string Repeat(this string value, int amount) =>
            string.Concat(Enumerable.Repeat(value, amount));
    }


}
