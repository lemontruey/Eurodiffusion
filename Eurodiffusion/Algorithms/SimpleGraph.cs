namespace Eurodiffusion
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class SimpleGraph : GraphAlgorithm
    {
        public SimpleGraph(InputParams inputParams)
        {
            Countries = new Agregator(inputParams).Countries;
        }

        public override void StartEuroDiffusion()
        {
            if (Countries.Count < MinCountriesAmount)
                return;

            bool isMapFull = false;
            while (!isMapFull)
            {
                EuroDiffusionDays++;

                Countries
                    .SelectMany(c => c.Cities.Select(city => city))
                    .Where(city => city != null)
                    .ToList()
                    .ForEach(city => city.TransferCoinsToNeighbours());


                Countries
                    .SelectMany(c => c.Cities.Select(city => city))
                    .Where(city => city != null)
                    .ToList()
                    .ForEach(city => city.FinalizeCoinBalancePerDay(Countries.Count));

                bool isAnyCountriesFull = true;
                foreach (var country in Countries.Where(x => !x.IsFulfilled))
                {
                    if (!country.CheckIsCountryFulfilled(EuroDiffusionDays))
                        isAnyCountriesFull = false;
                }

                isMapFull = isAnyCountriesFull;
            }
        }
    }
}
