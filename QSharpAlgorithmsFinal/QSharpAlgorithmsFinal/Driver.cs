using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.QSharpAlgorithmsFinal
{
    class Driver
    {
        static void Main(string[] args)
        {
            using (var qsim = new QuantumSimulator())
            {
                // 1. Create the array of bits that are generated in Operations.qs.
                Result[] bitArray = new Result[16];
                // 2. Create the string version of bitArray.
                string[] stringBitArray = new string[16];
                string temp;
                int final;
                // 3. Create string that will be our binary number.
                string joinedString;               

                for (int i = 0; i < 16; i++)
                {
                    // 4. Fill the bit array with a random qubit, returning either a "Zero" or a "One"
                    bitArray[i] = QuantumRandomNumberGenerator.Run(qsim).Result;

                    // 5. Place qubit in a string temp variable. 
                    temp = bitArray[i].ToString();

                    // 6. fill string array with qubit. 
                    stringBitArray[i] = temp;

                    // 7. Convert "Zero" or "One" to 0 or 1 so that we can convert the binary string directly into an integer. 
                    if (stringBitArray[i].Equals("Zero"))
                    {
                        stringBitArray[i] = "0";
                    }
                    else
                    {
                        stringBitArray[i] = "1";
                    }

                    // Repeat 4-7 16 times.
                }                               

                
                // 8. Create a concatenated binary string from the entries of stringBitArray.
                joinedString = string.Join("", stringBitArray);

                // 9. Convert the binary string into an integer in base 2. 
                final = Convert.ToInt32(joinedString, 2);               


                // 10. Display the binary string.
                Console.Write("Random Bit Value: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(joinedString);
                Console.ResetColor();

                Console.WriteLine("****************************");

                //11. Display the final random number.
                Console.Write("ACTUALLY RANDOM 16-Bit Number: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(final);
                Console.ResetColor();

            }
        }
    }
}