namespace CaloriesManagementWeb.Helpers
{
    public static class Formula
    {
        public static float? MifflinBMR(float? age, float? height, float? weight, string? gender)
        {
            if (gender == "male")
                return (float?)(10 * weight + 6.25 * height - 5 * age + 5);
            if (gender == "female")
                return (float?)(10 * weight + 6.25 * height - 5 * age - 161);
            return null;
        }

        public static float? TDEE(float? age, float? height, float? weight, string? gender, float? activity)
        {
            return MifflinBMR(age, height, weight, gender) * activity;
        }

        public static float? ToCentimeter(float? height, string? unit)
        {
            if (unit == "inch")
                return height * (float)2.54;
            return height;
        }
        public static float? ToKilogram(float? weight, string? unit)
        {
            if (unit == "pound")
                return weight * (float)0.454;
            if (unit == "stone")
                return weight * (float)6.35;
            return weight;
        }
    }
}
