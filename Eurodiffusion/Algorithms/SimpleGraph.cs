namespace Eurodiffusion
{
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleGraph : GraphAlgorithm
    {
        public SimpleGraph(InputParams inputCoordinates)
        {
            Grid grid = new Grid(inputCoordinates);
            _grid = grid.CityGrid;
            _countries = grid.Countries;
        }

        public override void StartEuroDiffusion()
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

        private List<City> GetNeighboursCities(int x, int y)
        {
            var neighbours = new List<City>();
            if (_grid[x, y + 1] != null) neighbours.Add(_grid[x, y + 1]);
            if (_grid[x + 1, y] != null) neighbours.Add(_grid[x + 1, y]);
            if (_grid[x, y - 1] != null) neighbours.Add(_grid[x, y - 1]);
            if (_grid[x - 1, y] != null) neighbours.Add(_grid[x - 1, y]);

            return neighbours;
        }
    }
}
