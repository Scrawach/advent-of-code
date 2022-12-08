namespace supply_stacks_src
{
    public interface IStorage
    {
        char Take(int from);
        void Put(char symbol, int to);
        string Top();
    }
}