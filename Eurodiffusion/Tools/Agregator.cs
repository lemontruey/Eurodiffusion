namespace Eurodiffusion
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Agregator
    {
        public List<Country> Countries { get; }

        public Agregator(InputParams inputParams)
        {
            Countries = new List<Country>(inputParams.CountryCount);

            InitCountries(inputParams);
            InitCityNeighbours();
        }

        private void InitCountries(InputParams inputParams)
        {
            for (int i = 0; i < inputParams.CountryCount; i++)
            {
                var inputCoordinates = inputParams.Coordinates[i];
                var inputCountryName = inputParams.CountryName[i];

                Countries.Add(new Country(inputCoordinates, inputCountryName));
            }
        }

        private void InitCityNeighbours()
        {
            foreach (var city in Countries.SelectMany(c => c.Cities))
            {
                city.NeighbourCities = Countries
                    .SelectMany(c => c.Cities.Select(city => city))
                    .Where(c => Math.Abs(c.AxisXPosition - city.AxisXPosition) == 1)
                    .Where(c => Math.Abs(c.AxisYPosition - city.AxisYPosition) == 1)
                    .ToList();
            }
        }
    }
}
