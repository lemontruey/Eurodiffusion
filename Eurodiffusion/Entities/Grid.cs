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

        private int _euroDiffusionDays = 1;

        public Grid(InputParams inputParams)
        {
            _countries = new Country[inputParams.CountryCount];
            _grid = new City[GRID_MAX_VALUE, GRID_MAX_VALUE];

            InitGrid(inputParams);
        }

        public string GetResultString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var country in _countries)
            {
                str.Append($"{country.Name} {_euroDiffusionDays}" + "\n");
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
                for (int i = 0; i < _grid.GetLength(0); i++)
                {
                    for (int j = 0; j < _grid.GetLength(1); j++)
                    {
                        if (_grid[i, j] != null)
                            _grid[i, j].TransferCoinsToNeighbours(GetNeighboursCities(i, j));
                    }
                }
                

                //подсчёт в конце дня
                //ещё один цикл необходим, т.к. происходят внешние манипуляции с перемещением
                for (int i = 0; i < _grid.GetLength(0); i++)
                {
                    for (int j = 0; j < _grid.GetLength(1); j++)
                    {
                        if (_grid[i, j] != null)
                            _grid[i, j].FinalizeCoinBalancePerDay();
                    }
                }

                isMapFull = _countries.All(x => x.IsFulfilled);
                _euroDiffusionDays++;
            }
        }
    }
}
