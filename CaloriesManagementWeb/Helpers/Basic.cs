namespace CaloriesManagementWeb.Helpers
{
    public static class Basic
    {
        public static bool IsValidDate(int date)
        {
            try
            {
                var testDate = new DateTime(date / 10000, date / 100 % 100, date % 100);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            return true;
        }
    }
}
