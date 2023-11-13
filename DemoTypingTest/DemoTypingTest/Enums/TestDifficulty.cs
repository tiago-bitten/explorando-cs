using System.ComponentModel.DataAnnotations;

namespace DemoTypingTest.Enums
{
    public enum TestDifficulty
    {
        [Display(Name = "Short")]
        Short,

        [Display(Name = "Medium")]
        Medium,

        [Display(Name = "Long")]
        Long
    }
}
