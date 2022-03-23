namespace Eurodiffusion
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public abstract class GraphAlgorithm : IAlgorithm
    {
        protected const int GRID_MAX_VALUE = 11;
        protected const int MinCountriesAmount = 1;

        protected List<Country> Countries;

        protected int EuroDiffusionDays;
        public abstract void StartEuroDiffusion();

        public string GetResultString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var country in Countries.OrderBy(x => x.DaysToComplete))
            {
                str.Append($"{country.Name} {country.DaysToComplete}" + "\n");
            }
            return str.ToString();
        }
    }
}
