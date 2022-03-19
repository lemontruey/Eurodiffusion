namespace Eurodiffusion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Country
    {
        private readonly int _countryLength;
        private readonly int _countryHeight;
        private bool _isFulfilled;

        public City[,] Cities { get; set; }
        public string Name { get; set; }

        public bool IsFulfilled
        {
            get
            {
                return CheckCitiesFullness().All(x => x);
            }
            private set => _isFulfilled = value;
        }

        public Country(InputCoordinates coordinates, string countryName)
        {
            _countryLength = Math.Abs(coordinates.XL - coordinates.XH) + 1;
            _countryHeight = Math.Abs(coordinates.YL - coordinates.YH) + 1;

            IsFulfilled = false;
            Name = countryName;
            Cities = new City[_countryLength, _countryHeight];

            InitCities(coordinates, countryName);
        }

        private void InitCities(InputCoordinates coordinates, string countryName)
        {
            for (int i = 0; i < _countryLength; i++)
            {
                for (int j = 0; j < _countryHeight; j++)
                {
                    Cities[i,j] = new City(i + coordinates.XL, j + coordinates.YL, countryName);
                }
            }
        }

        private IEnumerable<bool> CheckCitiesFullness()
        {
            for (int i = 0; i < Cities.GetLength(0); i++)
            {
                for (int j = 0; j < Cities.GetLength(1); j++)
                {
                    yield return Cities[i, j].IsFulfilled;
                }
            }
        }
    }
}
