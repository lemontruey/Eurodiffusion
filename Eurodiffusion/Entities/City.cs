namespace Eurodiffusion
{
    using System.Collections.Generic;
    using System.Linq;

    public class City
    {
        private const int INITIAL_CITY_COIN_BALANCE = 1000;

        public int AxisXPosition { get; set; }
        public int AxisYPosition { get; set; }
        public string CountryName { get; set; }
        public bool IsFulfilled { get; private set; }

        public Dictionary<string, int> CoinBalancePerDay { get; set; }
        public Dictionary<string, int> CoinBalance { get; set; }

        public City(int axisXPosition, int axisYPosition, string countryName)
        {
            AxisXPosition = axisXPosition;
            AxisYPosition = axisYPosition;
            CountryName = countryName;
            IsFulfilled = false;

            CoinBalance = new Dictionary<string, int> { { countryName, INITIAL_CITY_COIN_BALANCE } };
            CoinBalancePerDay = new Dictionary<string, int> { { countryName, 0 } };
        }
        
        public void TransferCoinsToNeighbours(IList<City> neighboursCities)
        {
            foreach (var coinPerDayPair in CoinBalance)
            {
                foreach (var neighbour in neighboursCities)
                {
                    if (CoinBalance[coinPerDayPair.Key] > 0)
                    {
                        // отправляем же не всё... а одну монету(?)..
                        CoinBalance[coinPerDayPair.Key]--;
                        neighbour.CoinBalancePerDay.Addition(coinPerDayPair.Key, 1);
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
                // костыль или решение?
                if (CoinBalance.Keys.Count == countryCount && CoinBalance.Values.All(x => x > 0))
                    IsFulfilled = true;
            }
        }
    }

    public static class DictionaryExtensions
    {
        public static void Addition(this Dictionary<string, int> dict, string key, int value)
        {
            if (!dict.TryAdd(key, value))
                dict[key] += value;
        }
        public static void Addition(this Dictionary<string, int> dict, KeyValuePair<string, int> valuePair)
        {
            if (!dict.TryAdd(valuePair.Key, valuePair.Value))
                dict[valuePair.Key] += valuePair.Value;
        }
    }
}
