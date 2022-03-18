namespace Eurodiffusion
{
    public class City
    {
        private readonly int _axisX;
        private readonly int _axisY;
        private readonly string _countryName;

        public City(int axisX, int axisY, string countryName)
        {
            _axisX = axisX;
            _axisY = axisY;
            _countryName = countryName;
        }
    }
}
