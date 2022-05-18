using projectA.ult;

namespace projectA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = IOHelper.readDataFromFile("data/BIEUTHUC.inp");
            double[] result = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                try
                {
                    result[i] = Calculator.execute(data[i]);
                    Console.WriteLine(data[i] + " = " + result[i]);
                }
                catch (Exception e)
                {
                    result[i] = 0;
                    Console.WriteLine("Du lieu khong hop le");
                }
            }
            IOHelper.writeToFile("data/KETQUA.out", result);
        }
    }
}