namespace treetop_tree_house_src.Storages
{
    public readonly struct Tree
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Height;

        public Tree(int x, int y, int height)
        {
            X = x;
            Y = y;
            Height = height;
        }

        public bool IsVisibleFrom(Tree other) =>
            other.Height < Height;
    }
}