namespace Eurodiffusion
{
    using System;

    public class Country
    {
        public City[,] Cities { get; set; }

        public Country(InputCoordinates coordinates, string countryName)
        {
            int countryLength = Math.Abs(coordinates.XL - coordinates.XH);
            int countryHeight = Math.Abs(coordinates.YL - coordinates.YH);

            Cities = new City[countryLength, countryHeight];

            InitCities(coordinates, countryName);
        }

        private void InitCities(InputCoordinates coordinates, string countryName)
        {
            for (int i = coordinates.XL; i <= coordinates.XH; i++)
            {
                for (int j = coordinates.YL; j <= coordinates.YH; j++)
                {
                    Cities[i,j] = new City(i, j, countryName);
                }
            }
        }
    }
}
