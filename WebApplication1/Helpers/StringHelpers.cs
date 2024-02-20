namespace NetRestaurantAPI.Helpers
{
    public static class StringHelpers
    {
        public static string LimpaCpf(string cpf)
        {
            return cpf.Replace("-", "").Replace(".", "").Replace(" ", "");
        }
    }
}
