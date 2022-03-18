namespace Eurodiffusion
{
    public class City
    {
        private const int BASE_CITY_AMOUNT = 1;

        public int axisXPosition { get; set; }
        public int axisYPosition { get; set; }
        public string countryName { get; set; }

        public int AmountRevenue { get; set; }

        public City(int axisXPosition, int axisYPosition, string countryName)
        {
            this.axisXPosition = axisXPosition;
            this.axisYPosition = axisYPosition;
            this.countryName = countryName;

            AmountRevenue = BASE_CITY_AMOUNT;
        }
    }
}
