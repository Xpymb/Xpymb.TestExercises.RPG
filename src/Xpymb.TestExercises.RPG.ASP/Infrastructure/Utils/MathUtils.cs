namespace Xpymb.TestExercises.RPG.ASP.Infrastructure.Utils;

public static class MathUtils
{
    /// <summary>
    /// Calculate distance between two 2D points
    /// </summary>
    /// <returns>Distance</returns>
    public static double Distance(int sourceX, int sourceY, int targetX, int targetY)
    {
        return Math.Sqrt(Math.Pow(Math.Abs(sourceX - targetX), 2) + Math.Pow(Math.Abs(sourceY - targetY), 2));
    }
}