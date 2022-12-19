namespace cathode_ray_tube_src.Logic.Strengths.Abstract
{
    public interface IStrengthCalculatePolicy
    {
        int Calculate(int numberOfCycle, int value);
    }
}