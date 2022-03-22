namespace Eurodiffusion
{
    using System.Linq;
    using System.Text;
    public abstract class GraphAlgorithm : IAlgorithm
    {
        protected const int GRID_MAX_VALUE = 11;
        protected const int MIN_COUNTRIES_AMOUNT = 1;

        protected Country[] _countries;
        protected City[,] _grid;

        protected int _euroDiffusionDays;
        public abstract void StartEuroDiffusion();

        public string GetResultString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var country in _countries.OrderBy(x => x.DaysToComplete))
            {
                str.Append($"{country.Name} {country.DaysToComplete}" + "\n");
            }
            return str.ToString();
        }
    }
}
