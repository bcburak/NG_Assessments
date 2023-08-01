using NewGlobe.AcademyRoute;

public class AcademyRoutePlannerTests
{
    [Fact]
    public void Test_GetDistance_Route_ABC()
    {
        AcademyRoutePlanner planner = CreateTestRoutePlanner();
        var route = new List<char> { 'A', 'B', 'C' };
        int distance = planner.GetDistance(route);
        Assert.Equal(9, distance);
    }

    [Fact]
    public void Test_GetDistance_Route_AEBCD()
    {
        AcademyRoutePlanner planner = CreateTestRoutePlanner();
        var route = new List<char> { 'A', 'E', 'B', 'C', 'D' };
        int distance = planner.GetDistance(route);
        Assert.Equal(22, distance);
    }

    [Fact]
    public void Test_GetDistance_Route_AED()
    {
        AcademyRoutePlanner planner = CreateTestRoutePlanner();
        var route = new List<char> { 'A', 'E', 'D' };
        int distance = planner.GetDistance(route);
        Assert.Equal(-1, distance); // NO SUCH ROUTE
    }

    [Fact]
    public void Test_CountRoutesWithMaxStops_CC_3Stops()
    {
        AcademyRoutePlanner planner = CreateTestRoutePlanner();
        int count = planner.CountRoutesWithMaxStops('C', 'C', 3);
        Assert.Equal(2, count);
    }

    [Fact]
    public void Test_CountRoutesWithExactStops_AC_4Stops()
    {
        AcademyRoutePlanner planner = CreateTestRoutePlanner();
        int count = planner.CountRoutesWithExactStops('A', 'C', 4);
        Assert.Equal(3, count);
    }

    [Fact]
    public void Test_ShortestRoute_AC()
    {
        AcademyRoutePlanner planner = CreateTestRoutePlanner();
        int shortestDistance = planner.ShortestRoute('A', 'C');
        Assert.Equal(9, shortestDistance);
    }

    [Fact]
    public void Test_ShortestRoute_BB()
    {
        AcademyRoutePlanner planner = CreateTestRoutePlanner();
        int shortestDistance = planner.ShortestRoute('B', 'B');
        Assert.Equal(9, shortestDistance);
    }

    [Fact]
    public void Test_CountRoutesWithMaxDistance_CC_LessThan30()
    {
        AcademyRoutePlanner planner = CreateTestRoutePlanner();
        int count = planner.CountRoutesWithMaxDistance('C', 'C', 30);
        Assert.Equal(7, count);
    }

    private AcademyRoutePlanner CreateTestRoutePlanner()
    {
        AcademyRoutePlanner planner = new AcademyRoutePlanner();
        planner.AddRoute('A', 'B', 5);
        planner.AddRoute('B', 'C', 4);
        planner.AddRoute('C', 'D', 8);
        planner.AddRoute('D', 'C', 8);
        planner.AddRoute('D', 'E', 6);
        planner.AddRoute('A', 'D', 5);
        planner.AddRoute('C', 'E', 2);
        planner.AddRoute('E', 'B', 3);
        planner.AddRoute('A', 'E', 7);
        return planner;
    }
}
