namespace Eurodiffusion
{
    public class Grid
    {
        private const int GRID_MAX_VALUE = 12;

        public Country[] Countries { get; }
        public City[,] CityGrid { get; }

        public Grid(InputParams inputParams)
        {
            Countries = new Country[inputParams.CountryCount];
            CityGrid = new City[GRID_MAX_VALUE, GRID_MAX_VALUE];

            InitGrid(inputParams);
        }

        private void InitGrid(InputParams inputParams)
        {
            for (int i = 0; i < inputParams.CountryCount; i++)
            {
                var inputCoordinates = inputParams.Coordinates[i];
                var inputCountryName = inputParams.CountryName[i];

                Countries[i] = new Country(inputCoordinates, inputCountryName);

                CopyCities(Countries[i], inputCoordinates);
            }
        }

        private void CopyCities(Country country, InputCoordinates coordinates)
        {
            for (int x = coordinates.XL, i = 0; x <= coordinates.XH; i++, x++)
            {
                for (int y = coordinates.YL, j = 0; y <= coordinates.YH; j++, y++)
                {
                    CityGrid[x, y] = country.Cities[i, j];
                }
            }
        }
    }
}
