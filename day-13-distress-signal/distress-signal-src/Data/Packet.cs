namespace distress_signal_src.Data
{
    public class Packet
    {
        private readonly string _left;
        private readonly string _right;

        public Packet(string left, string right)
        {
            _left = left;
            _right = right;
        }

        public bool IsRightOrder() =>
            true;
    }
}