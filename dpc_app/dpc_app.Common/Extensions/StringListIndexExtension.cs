namespace dpc_app.Common.Extensions
{
    public static class StringListIndexExtension
    {
        private const int SingleCount = 1;
        private const int ZeroCount = 0;

        public static int HandleWordIndex(int count)
        {
            if (count.Equals(SingleCount) || count.Equals(ZeroCount))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
