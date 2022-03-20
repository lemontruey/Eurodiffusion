namespace Eurodiffusion
{
    using System.Collections.Generic;
    public partial class Grid
    {
        private void InitGrid(InputParams inputParams)
        {
            for (int i = 0; i < inputParams.CountryCount; i++)
            {
                var inputCoordinates = inputParams.Coordinates[i];
                var inputCountryName = inputParams.CountryName[i];

                _countries[i] = new Country(inputCoordinates, inputCountryName);

                CopyCities(_countries[i], inputCoordinates);
            }
        }

        private void CopyCities(Country country, InputCoordinates coordinates)
        {
            for (int x = coordinates.XL, i = 0; x <= coordinates.XH; i++, x++)
            {
                for (int y = coordinates.YL, j = 0; y <= coordinates.YH; j++, y++)
                {
                    _grid[x, y] = country.Cities[i, j];
                }
            }
        }

        private List<City> GetNeighboursCities(int x, int y)
        {
            // Order is important, because neighbours are iterating in following order
            // below -> upwards, left -> right, clockwise
            var neighbours = new List<City>();
            if (_grid[x, y + 1] != null) neighbours.Add(_grid[x, y + 1]);
            if (_grid[x + 1, y] != null) neighbours.Add(_grid[x + 1, y]);
            if (_grid[x, y - 1] != null) neighbours.Add(_grid[x, y - 1]);
            if (_grid[x - 1, y] != null) neighbours.Add(_grid[x - 1, y]);

            return neighbours;
        }
    }
}
