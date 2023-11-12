namespace DemoTypingTest.Data.Dtos
{
    public class ReadTestDto
    {
        public string? Id { get; set; }
        public string? TextTest { get; set; }
        public int? TotalWords { get; set; }
        public int? TotalCharacters { get; set; }
        public int? IncorrectWords { get; set; }
        public int? IncorrectCharacters { get; set; }
        public int? Time { get; set; }
        public ReadScoreDto? Score { get; set; }
        public ReadApplicationUserDto? User { get; set; }
    }
}
