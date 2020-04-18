using System;

namespace dpc_app.Common.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(string source, string searchItem, StringComparison stringComparison)
        {
            return source?.IndexOf(searchItem, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
