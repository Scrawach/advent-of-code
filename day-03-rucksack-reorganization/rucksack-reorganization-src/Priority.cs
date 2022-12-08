namespace rucksack_reorganization_src
{
    public class Priority
    {
        public static int Convert(char symbol)
        {
            var offset = char.IsUpper(symbol) ? 'A' - 26 : 'a';
            return symbol - offset + 1;
        }
    }
}