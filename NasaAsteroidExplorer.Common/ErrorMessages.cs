namespace NasaAsteroidExplorer.Common
{
    public class ErrorMessages
    {
        public const string FutureDate = "This date is in the future. Please enter a valid date!";
        public const string ApiFailed = "NASA API request failed: ";
        public const string InvalidRange = "Date range must not exceed 7 days.";
        public const string EndBeforeStart = "End date cannot be earlier than start date.";
        public const string NoAsteroidsFound = "No asteroids found for the selected date range.";
        public const string InvalidExportRange = "Invalid date range for export.";
    }
}
