namespace dpc_app.Common.Extensions
{
    public static class StringFormatterExtension
    {

        public static string PluraliseFormatter(string wordFormat, int count)
        {
            string[] formList = wordFormat.Split(';');
            int formIndex = StringListIndexExtension.HandleWordIndex(count);
            return $"{count} {formList[formIndex]}";
        }

        public static string DecimalFormmater(int count)
        {
            return string.Format("{0:n0}", count);
        }

    }
}
