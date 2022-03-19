namespace Eurodiffusion
{
    using System.Text;

    internal class Validator
    {
        private const int CityMax = 20;
        private const int CityMin = 0;
        private const int CityMinCoordinate = 1;
        private const int CityMaxCoordinate = 10;

        private int countryCount;
        private int cityXL;
        private int cityYL;
        private int cityXH;
        private int cityYH;

        private StringBuilder validationStringBuilder;

        public bool IsValid { get; set; } = false;

        public Validator(
            int _countryCount = 0,
            int _cityXL = 0,
            int _cityYL = 0,
            int _cityXH = 0,
            int _cityYH = 0
            )
        {
            countryCount = _countryCount;
            cityXL = _cityXL;
            cityYL = _cityYL;
            cityXH = _cityXH;
            cityYH = _cityYH;

            Validate();
        }

        public string GetValidationString()
        {
            return validationStringBuilder.ToString();
        }

        private void Validate()
        {
            validationStringBuilder = new StringBuilder();

            if (countryCount < CityMin)
                validationStringBuilder.Append($"City minimum value is incorrect. Minimum is {CityMin}");
            if (countryCount > CityMax)
                validationStringBuilder.Append($"City maximum value is incorrect. Maximum is {CityMax}");

            if (!(CityMinCoordinate <= cityXL && cityXL <= cityXH && cityXH <= CityMaxCoordinate))
                validationStringBuilder.Append($"City coordinates values is incorrect. {CityMinCoordinate} <= cityXL <= cityXH <= {CityMaxCoordinate}");

            if (!(CityMinCoordinate <= cityXL && cityYL <= cityYH && cityYH <= CityMaxCoordinate))
                validationStringBuilder.Append($"City coordinates values is incorrect. {CityMinCoordinate} <= cityYL <= cityYH <= {CityMaxCoordinate}");

            if (validationStringBuilder.Capacity == 0)
                IsValid = true;
        }
    }
}
