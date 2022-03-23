namespace Eurodiffusion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Country
    {
        private readonly int _countryLength;
        private readonly int _countryHeight;

        public List<City> Cities { get; set; }
        public string Name { get; set; }

        public bool IsFulfilled { get; private set; }
        public int DaysToComplete { get; set; }

        public Country(InputCoordinates coordinates, string countryName)
        {
            _countryLength = Math.Abs(coordinates.XL - coordinates.XH) + 1;
            _countryHeight = Math.Abs(coordinates.YL - coordinates.YH) + 1;

            IsFulfilled = false;
            Name = countryName;

            InitCities(coordinates, countryName);
        }

        public bool CheckIsCountryFulfilled(int days)
        {
            IsFulfilled = Cities.Select(x => x).All(x => x.IsFulfilled);
            if (IsFulfilled)
                DaysToComplete = days;
            return IsFulfilled;
        }

        private void InitCities(InputCoordinates coordinates, string countryName)
        {
            Cities = new List<City>(_countryLength);
            
            // TODO: Linq
            for (int i = 0; i < _countryLength; i++)
            {
                for (int j = 0; j < _countryHeight; j++)
                {
                    Cities.Add(new City(
                        i + coordinates.XL,
                        j + coordinates.YL,
                        countryName)
                    );
                }
            }
        }
    }
}
