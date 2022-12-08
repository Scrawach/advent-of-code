using System.Collections.Generic;
using System.Text;
using supply_stacks_src.Storages.Abstract;

namespace supply_stacks_src.Storages
{
    public class Storage : IStorage
    {
        private readonly Stack<char>[] _stacks;

        public Storage(Stack<char>[] stacks) =>
            _stacks = stacks;

        public char Take(int @from) =>
            _stacks[@from].Pop();

        public void Put(char symbol, int to) =>
            _stacks[to].Push(symbol);

        public string Top()
        {
            var builder = new StringBuilder();
            foreach (var stack in _stacks)
            {
                if (stack.Count > 0)
                    builder.Append(stack.Peek());
            }
            return builder.ToString();
        }
    }
}