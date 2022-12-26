namespace pyroclastic_flow_src.Logic.Abstract
{
    public interface ITunnel
    {
        long Height { get; }
        ITunnel AddRocks(long amount);
    }
}