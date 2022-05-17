namespace projectA.ult
{
    internal class IOHelper

    {
        private const int maxOps = 1;
        private static string workingDirectory = Environment.CurrentDirectory;
        public static string[] readDataFromFile(string fileName)
        {
            try
            {
                string[] data = new string[maxOps];
                string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @fileName);
                StreamReader reader = new StreamReader(path);
                string line = reader.ReadLine();
                Array.Resize(ref data, int.Parse(line));
                int index = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    data[index] = line;
                    index++;
                }
                reader.Close();
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Xay ra loi khi doc du lieu: " + e.Message);
                return null;
            }
        }

        public static void writeToFile(string fileName, double[] data)
        {
            try
            {
                string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @fileName);
                StreamWriter writer = new StreamWriter(path);
                foreach (double item in data)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Xay ra loi khi xuat du lieu: " + e.Message);
            }

        }
    }
}
