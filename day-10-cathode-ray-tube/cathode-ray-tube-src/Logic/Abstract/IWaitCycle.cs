namespace cathode_ray_tube_src.Logic.Abstract
{
    public interface IWaitCycle
    {
        void OnCycleDone(int numberOfCycle, int registerValue);
    }
}