namespace Eurodiffusion
{
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Grid
    {
        private const int GRID_MAX_VALUE = 11;
        private const int MIN_COUNTRIES_AMOUNT = 1;

        private readonly Country[] _countries;
        private readonly City[,] _grid;

        private int _euroDiffusionDays = 0;

        public Grid(InputParams inputParams)
        {
            _countries = new Country[inputParams.CountryCount];
            _grid = new City[GRID_MAX_VALUE, GRID_MAX_VALUE];

            InitGrid(inputParams);
        }

        public string GetResultString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var country in _countries.OrderBy(x => x.DaysToComplete))
            {
                str.Append($"{country.Name} {country.DaysToComplete}" + "\n");
            }
            return str.ToString();
        }

        public void StartEuroDiffusion()
        {
            if (_countries.Length < MIN_COUNTRIES_AMOUNT)
                return;

            bool isMapFull = false;
            while (!isMapFull)
            {
                _euroDiffusionDays++;
                for (int i = 0; i < _grid.GetLength(0); i++)
                {
                    for (int j = 0; j < _grid.GetLength(1); j++)
                    {
                        if (_grid[i, j] != null)
                            _grid[i, j].TransferCoinsToNeighbours(GetNeighboursCities(i, j));
                    }
                }
                
                for (int i = 0; i < _grid.GetLength(0); i++)
                {
                    for (int j = 0; j < _grid.GetLength(1); j++)
                    {
                        if (_grid[i, j] != null)
                            _grid[i, j].FinalizeCoinBalancePerDay(_countries.Length);
                    }
                }

                bool isAnyCountryFull = true;
                foreach (var country in _countries.Where(x => !x.IsFulfilled))
                {
                    if (!country.CheckIsCountryFulfilled(_euroDiffusionDays))
                        isAnyCountryFull = false;
                }

                isMapFull = isAnyCountryFull;
            }
        }
    }
}
