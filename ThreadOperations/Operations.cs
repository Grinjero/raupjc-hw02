using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadOperations
{
    public class Operations
    {
        public static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static int GetTheMagicNumber()
        {
            return IKnowIGuyWhoKnowsAGuy().Result;
        }
        private async static Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) +  await IKnowWhoKnowsThis(5);
        }
        private async static Task<int> IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSum(n);
        }
        public async static Task<int> FactorialDigitSum(int n)
        {
            int result = 1;

            for(int i = 1; i <= n; ++i)
            {
                result *= i;
            }

            return result;
        }
    }
}
