namespace NewGlobe.AcademyRoute
{
    public class AcademyRoutePlanner
    {
        private Dictionary<char, Dictionary<char, int>> routes;

        public AcademyRoutePlanner()
        {
            routes = new Dictionary<char, Dictionary<char, int>>();
        }

        public void AddRoute(char start, char end, int distance)
        {
            if (!routes.ContainsKey(start))
                routes[start] = new Dictionary<char, int>();

            routes[start][end] = distance;
        }

        public int GetDistance(List<char> academies)
        {
            int distance = 0;
            for (int i = 0; i < academies.Count - 1; i++)
            {
                if (!routes.ContainsKey(academies[i]) || !routes[academies[i]].ContainsKey(academies[i + 1]))
                    return -1; // Invalid route, return -1
                distance += routes[academies[i]][academies[i + 1]];
            }
            return distance;
        }

        public int CountRoutesWithMaxStops(char start, char end, int maxStops, int currentStops = 0)
        {
            if (currentStops > maxStops)
                return 0;

            if (currentStops > 0 && start == end)
                return 1;

            if (!routes.ContainsKey(start))
                return 0;

            int count = 0;
            foreach (var neighbor in routes[start])
            {
                count += CountRoutesWithMaxStops(neighbor.Key, end, maxStops, currentStops + 1);
            }
            return count;
        }

        public int CountRoutesWithExactStops(char start, char end, int exactStops, int currentStops = 0)
        {
            if (currentStops == exactStops && start == end)
                return 1;

            if (currentStops >= exactStops)
                return 0;

            if (!routes.ContainsKey(start))
                return 0;

            int count = 0;
            foreach (var neighbor in routes[start])
            {
                count += CountRoutesWithExactStops(neighbor.Key, end, exactStops, currentStops + 1);
            }
            return count;
        }

        public int ShortestRoute(char start, char end, int currentDistance = 0, int shortestDistance = int.MaxValue)
        {
            if (!routes.ContainsKey(start))
                return int.MaxValue;

            if (start == end)
                return currentDistance;

            foreach (var neighbor in routes[start])
            {
                int newDistance = ShortestRoute(neighbor.Key, end, currentDistance + neighbor.Value, shortestDistance);
                shortestDistance = Math.Min(shortestDistance, newDistance);
            }
            return shortestDistance == int.MaxValue ? -1 : shortestDistance;
        }

        public int CountRoutesWithMaxDistance(char start, char end, int maxDistance, int currentDistance = 0)
        {
            if (currentDistance >= maxDistance)
                return 0;

            if (start == end && currentDistance > 0)
                return 1;

            if (!routes.ContainsKey(start))
                return 0;

            int count = 0;
            foreach (var neighbor in routes[start])
            {
                count += CountRoutesWithMaxDistance(neighbor.Key, end, maxDistance, currentDistance + neighbor.Value);
            }
            return count;
        }
    }
}
