namespace Eurodiffusion
{
    internal class Country
    {
        private readonly int[,] country;

        public Country(int citiesX, int citiesY)
        {
            country = new int[citiesX, citiesY];

            InitCities(citiesX, citiesY);
        }

        private void InitCities(int citiesX, int citiesY)
        {
            int initBasePointValue = 1;
            for (int i = 0; i < citiesX; i++)
            {
                for (int j = 0; j < citiesY; i++)
                {
                    country[i, j] = initBasePointValue;
                }
            }
        }
    }
}
