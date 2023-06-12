namespace MovLib.Helpers
{
    public static class ValueValidationHelper
    {
        public static bool IsAnyValueNull(params object[] values)
        {
            foreach (object value in values)
            {
                if (value is null)
                    return true;
            }

            return false;
        }
    }
}
