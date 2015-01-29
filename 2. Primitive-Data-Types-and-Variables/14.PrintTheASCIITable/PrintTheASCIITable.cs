using System;
using System.Text;

class PrintTheASCIITable
{
    static void Main()
    {
        char[] specialChar = new char[] { '\u2022', '\u25D8', '\u25CB', '\u25D9', '\u2642', '\u2640', '\u266A' };

        Console.OutputEncoding = Encoding.Unicode;
        Encoding encodingOEMUnitedStates = Encoding.GetEncoding(437);

        Console.WriteLine("{0} \u2192 {1}", 0, "NULL");
        for (int i = 1; i < 255; i++)
        {
            if (i == 7 || i == 32 || i == 127)
            {
                if (i == 7)
                {
                    for (int j = 0; j < specialChar.Length; j++)
                    {
                        Console.WriteLine("{0} \u2192 {1}", i + j, specialChar[j]);
                    }
                    i += specialChar.Length;
                }
                else if (i == 32)
                {
                    Console.WriteLine("{0} \u2192 {1}", i, "SPACE");
                }
                else if (i == 127)
                {
                    Console.WriteLine("{0} \u2192 {1}", i, '⌂');
                }
            }
            else
            {
                string character = encodingOEMUnitedStates.GetString(new byte[] { (byte)i });
                Console.WriteLine("{0} \u2192 {1}", i, character);
            }
        }
        Console.WriteLine("255 -> nbsp");
    }
}