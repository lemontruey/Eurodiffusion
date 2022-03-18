namespace Eurodiffusion
{
    using System.Linq;
    using System.Linq.Expressions;
    public class Grid
    {
        private const int GRID_MAX_VALUE = 11;

        private readonly Country[] _countries;
        private readonly City[,] _grid;

        public Grid(InputParams inputParams)
        {
            _countries = new Country[inputParams.CountryCount];
            _grid = new City[GRID_MAX_VALUE, GRID_MAX_VALUE];

            InitGrid(inputParams);
        }

        private void InitGrid(InputParams inputParams)
        {
            for (int i = 0; i < inputParams.CountryCount; i++)
            {
                var inputCoordinates = inputParams.Coordinates[i];
                var inputCountryName = inputParams.CountryName[i];

                _countries[i] = new Country(inputCoordinates, inputCountryName);

                CopyCities(_countries[i]);
            }
        }

        private void CopyCities(Country country)
        {
        }

        public void StartEuroDiffusion()
        {

        }
    }
}
