using rucksack_reorganization_src.Logic.Abstract;

namespace rucksack_reorganization_src.Logic
{
    public class Priority : IPriority
    {
        public int Convert(char symbol)
        {
            var offset = char.IsUpper(symbol) ? 'A' - 26 : 'a';
            return symbol - offset + 1;
        }
    }
}