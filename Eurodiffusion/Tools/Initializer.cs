namespace Eurodiffusion
{
    using System;
    using System.Collections.Generic;

    public static class Initializer
    {
        public static List<InputParams> Initialize(string inputString)
        {
            var inputParams = new List<InputParams>();

            string[] partialStrings = inputString.Split('\n');
            for (int i = 0; i < partialStrings.Length; i++)
            {
                var inputParameter = new InputParams();
                if (IsDigitsOnly(partialStrings[i]))
                {
                    int countryCount = partialStrings[i].ToInt32();
                    inputParameter.CountryCount = countryCount;
                    inputParameter.CountryName = new string[countryCount];
                    inputParameter.Coordinates = new InputCoordinates[countryCount];

                    if (countryCount == 0) break;

                    for (int j = i + 1, iterator = 0; j < i + countryCount; j++, iterator++)
                    {
                        string[] str = partialStrings[j].Split(' ');
                        inputParameter.CountryName[iterator] = str[0];
                        inputParameter.Coordinates[iterator] = new InputCoordinates(
                            str[1].ToInt32(),
                            str[2].ToInt32(),
                            str[3].ToInt32(),
                            str[4].ToInt32()
                            );
                    }

                    inputParams.Add(inputParameter);
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

        private static int ToInt32(this string str)
        {
            return Convert.ToInt32(str);
        }
    }
}
