using System.IO;

namespace DemoTypingTest.Utils
{
    public static class TestUtil
    {
        private static readonly List<string> ShortWords;
        private static readonly List<string> MediumWords;
        private static readonly List<string> LongWords;

        static TestUtil()
        {
            try
            {
                string basePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "TestFiles");

                ShortWords = ExtractWords(Path.Combine(basePath, "ShortTest.txt"));
                MediumWords = ExtractWords(Path.Combine(basePath, "MediumTest.txt"));
                LongWords = ExtractWords(Path.Combine(basePath, "LongTest.txt"));
            }
            catch (Exception e)
            {
                throw new Exception("Error initializing TestUtil", e);
            }
        }

        public static List<string> GenerateTest(int amountShortWords, int amountMediumWords,
            int amountLongWords)
        {
            List<string> test = new List<string>();

            Random random = new Random();

            GenerateRandomWords(test, ShortWords, amountShortWords, random);
            GenerateRandomWords(test, MediumWords, amountMediumWords, random);
            GenerateRandomWords(test, LongWords, amountLongWords, random);

            return ShuffleList(test);
        }

        private static void GenerateRandomWords(List<string> test, List<string> sourceWords,
            int amount, Random random)
        {
            List<string> availableWords = new List<string>(sourceWords);
            for (int i = 0; i < amount; i++)
            {
                string randomWord = availableWords[random.Next(availableWords.Count)];
                test.Add(randomWord);
                availableWords.Remove(randomWord);
            }
        }

        private static List<string> ShuffleList(List<string> list)
        {
            List<string> shuffledList = new List<string>(list);
            shuffledList = shuffledList.OrderBy(x => Guid.NewGuid()).ToList();
            return shuffledList;
        }

        private static List<string> ExtractWords(string path)
        {
            try
            {
                string[] words = File.ReadAllText(path).Split(',');
                return words.ToList();
            }
            catch (IOException e)
            {
                throw new ApplicationException($"Error reading words file: {path}", e);
            }
        }
    }
}
