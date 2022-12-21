namespace monkey_in_the_middle_src.Logic.TestPolicy.Abstract
{
    public interface IWorryLevelPolicy
    {
        bool IsCriticalLevel(long worry);
    }
}