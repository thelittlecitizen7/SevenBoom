using System;
using System.Collections.Generic;
using System.Text;

namespace SevenBoom
{
    public class Utils
    {
        public static bool IsDigitExistInNumber(int number,int digit) 
        {
            bool isNumberExist = false;
            int num = number;
            while (num != 0 && !isNumberExist) 
            {
                int moduloNumber = num % 10;
                if (moduloNumber % 10 == digit) 
                {
                    isNumberExist = true;
                }
                num = num / 10;
            }
            return isNumberExist;
        }
    }
}
