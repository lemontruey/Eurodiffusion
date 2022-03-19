namespace Eurodiffusion
{
    using System.Linq;
    using System;
    using System.Collections.Generic;

    public static class Initializer
    {
        public static List<InputParams> Initialize(string inputString)
        {
            var inputParams = new List<InputParams>();
            var currentParameter = new InputParams();

            string[] partialStrings = inputString.Split('\n');
            foreach (var partialString in partialStrings.Where(x => IsDigitsOnly(x)))
            {
                currentParameter.CountryCount = Convert.ToInt32(partialString);
                for (int i = 0; i < currentParameter.CountryCount; i++)
                {
                    partialString
                }
            }

            return inputParams;
        }

        private static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
