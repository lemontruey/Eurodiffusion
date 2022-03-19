namespace Eurodiffusion
{
    using System.Collections.Generic;

    public class City
    {
        private const int INITIAL_CITY_COIN_BALANCE = 1000;

        public int AxisXPosition { get; set; }
        public int AxisYPosition { get; set; }
        public string CountryName { get; set; }
        public bool IsFulfilled { get; }

        public Dictionary<string, int> CoinBalancePerDay { get; set; }
        public Dictionary<string, int> CoinBalance { get; set; }

        public City(int axisXPosition, int axisYPosition, string countryName)
        {
            AxisXPosition = axisXPosition;
            AxisYPosition = axisYPosition;
            CountryName = countryName;
            IsFulfilled = false;

            CoinBalance = new Dictionary<string, int> { { countryName, INITIAL_CITY_COIN_BALANCE } };
        }
        
        public void TransferCoinsToNeighbours(IList<City> neighboursCities)
        {
            foreach (var coinPerDayPair in CoinBalance)
            {
                foreach (var neighbour in neighboursCities)
                {
                    CoinBalance[coinPerDayPair.Key] -= coinPerDayPair.Value;
                    neighbour.CoinBalance[coinPerDayPair.Key] += coinPerDayPair.Value;
                }
            }
        }

        public void FinalizeCoinBalancePerDay()
        {
            foreach (var coinPerDayPair in CoinBalancePerDay)
            {
                CoinBalance[coinPerDayPair.Key] += coinPerDayPair.Value;
                CoinBalancePerDay[coinPerDayPair.Key] = 0;
            }
        }
    }
}
