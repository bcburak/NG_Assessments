// See https://aka.ms/new-console-template for more information

namespace NewGlobe.AcademyRoute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AcademyRoutePlanner planner = new AcademyRoutePlanner();

            // Test Input: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7
            planner.AddRoute('A', 'B', 5);
            planner.AddRoute('B', 'C', 4);
            planner.AddRoute('C', 'D', 8);
            planner.AddRoute('D', 'C', 8);
            planner.AddRoute('D', 'E', 6);
            planner.AddRoute('A', 'D', 5);
            planner.AddRoute('C', 'E', 2);
            planner.AddRoute('E', 'B', 3);
            planner.AddRoute('A', 'E', 7);

            Console.WriteLine("1. Distance of the route A-B-C: " + FormatDistanceOutput(planner.GetDistance(new List<char> { 'A', 'B', 'C' })));
            Console.WriteLine("2. Distance of the route A-E-B-C-D: " + FormatDistanceOutput(planner.GetDistance(new List<char> { 'A', 'E', 'B', 'C', 'D' })));
            Console.WriteLine("3. Distance of the route A-E-D: " + FormatDistanceOutput(planner.GetDistance(new List<char> { 'A', 'E', 'D' })));
            Console.WriteLine("4. Number of trips starting at C and ending at C with a maximum of 3 stops: " + planner.CountRoutesWithMaxStops('C', 'C', 3));
            Console.WriteLine("5. Number of trips starting at A and ending at C with exactly 4 stops: " + planner.CountRoutesWithExactStops('A', 'C', 4));
            Console.WriteLine("6. Length of the shortest route from A to C: " + FormatDistanceOutput(planner.ShortestRoute('A', 'C')));
            Console.WriteLine("7. Length of the shortest route from B to B: " + FormatDistanceOutput(planner.ShortestRoute('B', 'B')));
            Console.WriteLine("8. Number of different routes from C to C with a distance of less than 30: " + planner.CountRoutesWithMaxDistance('C', 'C', 30));
        }
        private static string FormatDistanceOutput(int distance)
        {
            return distance >= 0 ? distance.ToString() : "NO SUCH ROUTE";
        }
    }
}


