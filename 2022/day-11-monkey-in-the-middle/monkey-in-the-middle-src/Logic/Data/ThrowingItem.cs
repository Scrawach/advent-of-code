namespace monkey_in_the_middle_src.Logic.Data
{
    public class ThrowingItem
    {
        public readonly Item Item;
        public readonly int TargetMonkeyId;

        public ThrowingItem(Item item, int targetMonkeyId)
        {
            Item = item;
            TargetMonkeyId = targetMonkeyId;
        }
    }
}