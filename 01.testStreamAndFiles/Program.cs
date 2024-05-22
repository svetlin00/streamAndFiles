namespace _01.testStreamAndFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader(@"../../../input.txt");
            string inputData = streamReader.ReadToEnd();
            streamReader.Close();
            Console.WriteLine(inputData);
        }
    }
}