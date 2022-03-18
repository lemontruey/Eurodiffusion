namespace Eurodiffusion
{
    public class InputParams
    {
        public int CountryCount { get; set; }
        public InputCoordinates[] Coordinates { get; set; }
        public string[] CountryName { get; set; }
    }

    public struct InputCoordinates
    {
        public int XL { get; set; }
        public int YL { get; set; }
        public int XH { get; set; }
        public int YH { get; set; }

        public InputCoordinates(int _xl, int _yl, int _xh, int _yh)
        {
            XL = _xl; YL = _yl; XH = _xh; YH = _yh; 
        }
    }
}
