namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstReader = new (firstInputFilePath, true))
            {
                using (StreamReader secondReader = new StreamReader(secondInputFilePath, true))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath, true))
                    {
                        string firstLine = "";
                        string secondLine = "";
                        while (firstLine != null && secondLine != null )
                        {
                            firstLine =  firstReader.ReadLine();
                            secondLine = secondReader.ReadLine();

                            if (firstLine == null)
                            {
                                while (secondLine != null)
                                {
                                    writer.WriteLine(secondLine);
                                    secondLine= secondReader.ReadLine();
                                    
                                }
                            }
                            if (secondLine == null)
                            {
                                while (firstLine != null)
                                {
                                    writer.WriteLine(firstLine);
                                    firstLine = firstReader.ReadLine();
                                }
                            }
                            if (firstLine == null && secondLine == null)
                            {
                                break;
                            }
                           
                            writer.WriteLine(firstLine);
                            writer.WriteLine(secondLine);

                        }
                    }

                }

            }
        }
    }
}
