using System;

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

        public Grid(List<InputParams> inputParams)
        {
            foreach (var parameter in inputParams)
            {
                _countries = new Country[parameter.CountryCount];
                _grid = new City[GRID_MAX_VALUE, GRID_MAX_VALUE];

                InitGrid(parameter);
            }
        }

        public string GetResultString()
        {
            StringBuilder str = new StringBuilder();
            for(int i = 0; i < _countries.Length; i++)
            {
                str.Append($"Case Number { i + 1 }");
                str.Append($"{_countries[i].Name} {_euroDiffusionDays}");
            }
            return "";
        }

        public void StartEuroDiffusion()
        {
            if (_countries.Length < MIN_COUNTRIES_AMOUNT)
                return;

            bool is_map_full = false;
            while (!is_map_full)
            {
                for (int dimension = 0; dimension < _grid.Rank; dimension++)
                {
                    for (int i = 0; i < _grid.GetLength(dimension); i++)
                    {
                        for (int j = 0; j < _grid.GetLength(dimension); j++)
                        {
                            if (_grid[i, j] != null)
                                _grid[i, j].TransferCoinsToNeighbours(GetNeighboursCities(i, j));
                        }
                    }
                }

                //подсчёт в конце дня
                //ещё один цикл необходим, т.к. происходят внешние манипуляции с перемещением
                for (int dimension = 0; dimension < _grid.Rank; dimension++)
                {
                    for (int i = 0; i < _grid.GetLength(dimension); i++)
                    {
                        for (int j = 0; j < _grid.GetLength(dimension); j++)
                        {
                            if (_grid[i, j] != null)
                                _grid[i, j].FinalizeCoinBalancePerDay();
                        }
                    }
                }

                is_map_full = _countries.All(x => x.IsFulfilled);
                _euroDiffusionDays++;
            }
        }
    }
}
