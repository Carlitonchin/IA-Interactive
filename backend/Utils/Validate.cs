namespace backend.Utils
{
    public static class Validate
    {
        public static bool EmptyOrNull(string s)
        {
            return s == null || s.Trim().Length == 0;
        }
    }
}
