namespace rucksack_reorganization_src
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