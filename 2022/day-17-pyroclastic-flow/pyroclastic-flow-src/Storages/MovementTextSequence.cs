using System.Linq;
using pyroclastic_flow_src.Data;
using pyroclastic_flow_src.Storages.Abstract;

namespace pyroclastic_flow_src.Storages
{
    public class MovementTextSequence : IMovementSequence
    {
        private readonly IText _text;
        private string _line;
        private int _index = -1;

        public MovementTextSequence(IText text) =>
            _text = text;

        public Vector2 NextDirection()
        {
            if (string.IsNullOrWhiteSpace(_line))
                _line = _text.Lines().First();
            
            _index++;

            if (_index > _line.Length - 1)
                _index = 0;
            
            var nextDirection = _line[_index];
            
            return nextDirection == '>'
                ? Vector2.Right
                : Vector2.Left;
        }
    }
}