namespace MyApp.Models
{
    public class Game
    {
        public required List<int> Numbers { get; set; }
        public int? SelectedNumber { get; set; }
        public int CorrectNumber { get; set; }
        public string Message { get; set; }
    }
}
