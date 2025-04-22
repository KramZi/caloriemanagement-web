namespace CaloriesManagementWeb.ViewModel
{
    public class CalculatorViewModel
    {
        public float? Age { get; set; }
        public string? Gender { get; set; }
        public float? Height { get; set; }
        public string? Height_Unit { get; set; }
        public float? Weight { get; set; }
        public string? Weight_Unit { get; set; }
        public float? Activity { get; set; }
        public float? TDEE { get; set; }
        public int? DailyCalories { get; set; }
        public bool PostMethod { get; set; } = false;
    }
}
