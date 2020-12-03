namespace Day3
{
    class Slope
    {
        public int StepsRight { get; }

        public int StepsDown { get; }

        public int NumberOfTrees { get; private set; }

        public Slope(int right, int down)
        {
            StepsRight = right;
            StepsDown = down;
            NumberOfTrees = 0;
        }

        public void AddTree()
        {
            NumberOfTrees++;
        }
    }
}
