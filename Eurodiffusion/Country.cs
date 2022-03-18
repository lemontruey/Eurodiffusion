namespace Eurodiffusion
{
    using System.Collections.Generic;

    public class Country
    {
        public List<City> Cities { get; set; }

        public Country(InputCoordinates coordinates, string countryName)
        {
            Cities = new List<City>();

            InitCities(coordinates, countryName);
        }

        private void InitCities(InputCoordinates coordinates, string countryName)
        {
            for (int i = coordinates.XL; i <= coordinates.XH; i++)
            {
                for (int j = coordinates.YL; j <= coordinates.YH; j++)
                {
                    Cities.Add(new City(i, j, countryName));
                }
            }
        }
    }
}
