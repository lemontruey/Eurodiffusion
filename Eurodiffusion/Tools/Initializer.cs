namespace Eurodiffusion
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class Initializer
    {
        public static List<InputParams> Initialize(string inputString)
        {
            var inputParams = new List<InputParams>();

            string[] partialStrings = inputString.Replace("\r", "").Replace("\0", "").Split('\n');
            for (int i = 0; i < partialStrings.Length; i++)
            {
                var inputParameter = new InputParams();
                if (IsDigitsOnly(partialStrings[i].Trim()))
                {
                    int countryCount = partialStrings[i].ToInt32();
                    inputParameter.CountryCount = countryCount;
                    inputParameter.CountryName = new string[countryCount];
                    inputParameter.Coordinates = new InputCoordinates[countryCount];

                    if (countryCount == 0) break;

                    for (int j = i + 1, iterator = 0; j <= i + countryCount; j++, iterator++)
                    {
                        try
                        {
                            string[] str = Regex.Replace(partialStrings[j], @"\s+", " ").Split(' ');
                            inputParameter.CountryName[iterator] = str[0];
                            inputParameter.Coordinates[iterator] = new InputCoordinates(
                                str[1].ToInt32(),
                                str[2].ToInt32(),
                                str[3].ToInt32(),
                                str[4].ToInt32()
                            );
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Suggested input format: " + "\n\n" +
                                              "Number of countries (:integer)" + "\n" +
                                              "CountryName(:string) xl yl xh yh" + "\n" +
                                              "(1 <= xl <= xh <= 10)" + "\n" +
                                              "(1 <= yl <= yh <= 10)" + "\n");
                            throw;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
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
                if (!char.IsDigit(c))
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
