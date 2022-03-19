namespace Eurodiffusion
{
    using System.Collections.Generic;

    public class City
    {
        private const int INITIAL_CITY_COIN_BALANCE = 1000000;
        private const int REPRESENTASTIVE_PORTION = 1000;
        
        private int _coinsTransfered, _beginningDayBalance;

        public int AxisXPosition { get; set; }
        public int AxisYPosition { get; set; }
        public string CountryName { get; set; }

        public Dictionary<string, int> CoinBalance { get; set; }

        public City(int axisXPosition, int axisYPosition, string countryName)
        {
            AxisXPosition = axisXPosition;
            AxisYPosition = axisYPosition;
            CountryName = countryName;

            CoinBalance = new Dictionary<string, int> { { countryName, INITIAL_CITY_COIN_BALANCE } };
        }

        // город перечисляет или страна? 
        // тут данных больше, поэтому пусть сам город перечисляет
        public void TransferCoinsToNeighbours(IList<City> neighboursCities)
        {
            
        }
    }
}
