namespace Eurodiffusion
{
    using System.Collections.Generic;
    using System.Linq;

    public class City
    {
        private const int INITIAL_CITY_COIN_BALANCE = 1000000;
        private const int REPRESENTATIVE_PORTION = 1000;

        public int AxisXPosition { get; set; }
        public int AxisYPosition { get; set; }
        public string CountryName { get; set; }
        public bool IsFulfilled { get; private set; }

        public Dictionary<string, int> CoinBalancePerDay { get; set; }
        public Dictionary<string, int> CoinBalance { get; set; }
        public List<City> NeighbourCities { get; set; }

        public City(int axisXPosition, int axisYPosition, string countryName)
        {
            AxisXPosition = axisXPosition;
            AxisYPosition = axisYPosition;
            CountryName = countryName;
            IsFulfilled = false;

            CoinBalance = new Dictionary<string, int> { { countryName, INITIAL_CITY_COIN_BALANCE } };
            CoinBalancePerDay = new Dictionary<string, int> { { countryName, 0 } };
        }

        public void TransferCoinsToNeighbours()
        {
            foreach (var coinPerDayPair in CoinBalance)
            {
                foreach (var neighbour in NeighbourCities)
                {
                    if (CoinBalance[coinPerDayPair.Key] > 0)
                    {
                        int transactionAmount = coinPerDayPair.Value / REPRESENTATIVE_PORTION;
                        CoinBalance[coinPerDayPair.Key] -= transactionAmount;

                        neighbour.CoinBalancePerDay.Addition(coinPerDayPair.Key, transactionAmount);
                    }
                }
            }
        }

        public void FinalizeCoinBalancePerDay(int countryCount)
        {
            foreach (var coinPerDayPair in CoinBalancePerDay)
            {
                CoinBalance.Addition(coinPerDayPair);
                CoinBalancePerDay[coinPerDayPair.Key] = 0;
            }

            if (!IsFulfilled)
            {
                if (CoinBalance.Keys.Count == countryCount && CoinBalance.Values.All(x => x > 0))
                    IsFulfilled = true;
            }
        }
    }
}
