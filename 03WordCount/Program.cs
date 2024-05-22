namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            SortedDictionary<string, int> wordCount = new();
            using (StreamReader reader = new StreamReader(textFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath,true))
                {
                    using (StreamReader wordsReader = new StreamReader(wordsFilePath))
                    {
                        string[] words = wordsReader.ReadToEnd().Split(" " , StringSplitOptions.RemoveEmptyEntries);
                        string[] textData = reader.ReadToEnd().Split(new string [] { " ", ".", "-", "!", ","}, StringSplitOptions.RemoveEmptyEntries );
                         foreach (var word in textData)
                        {

                            string wordToLower = word.ToLower();


                            for (int i = 0; i < words.Length; i++)
                            {
                                string currWord = words[i];

                                if (wordToLower == currWord)
                                {
                                   
                                    if (!wordCount.ContainsKey(wordToLower))
                                    {
                                        wordCount.Add(wordToLower, 0);
                                    }
                                    wordCount[wordToLower]++;
                                }
                            }


                        }
                         
                        foreach (var word in wordCount.OrderByDescending(x=> x.Value))
                        {
                            writer.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }

                }


            }
        }

    }










}
