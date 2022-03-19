using System.Collections.Generic;

namespace Eurodiffusion
{
    public partial class Grid
    {
        private const int GRID_MAX_VALUE = 11;
        private const int MIN_COUNTRIES_AMOUNT = 1;

        private readonly Country[] _countries;
        private readonly City[,] _grid;

        private int _euroDiffusionDays = 1;

        public Grid(List<InputParams> inputParams)
        {
            foreach (var parameter in inputParams)
            {
                _countries = new Country[parameter.CountryCount];
                _grid = new City[GRID_MAX_VALUE, GRID_MAX_VALUE];

                InitGrid(parameter);
            }
        }

        public void StartEuroDiffusion()
        {
            if (_countries.Length < MIN_COUNTRIES_AMOUNT)
                return;

            bool is_map_full = false;
            while (!is_map_full)
            {
                for (int i = 0; i < _grid.Length; i++)
                {
                    for (int j = 0; j < _grid.Length; j++)
                    {
                        if (_grid[i, j] != null) 
                            _grid[i, j].TransferCoinsToNeighbours( GetNeighboursCities(i, j) );
                    }
                }


            }
        }
    }
}
