using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectA.ult
{
    internal class IOHelper

    {
        private const int maxOps = 1000000;
        public static string[] readDataFromFile(string fileName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            try
            {
                string path = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, @fileName);
                StreamReader reader = new StreamReader(path);
                string line = reader.ReadLine();
                string[] data = new string[maxOps];
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
    }
}
