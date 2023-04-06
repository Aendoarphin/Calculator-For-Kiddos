using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class Volume
    {
        public double result;
        public string[] volumeConversions = {
        "OuncePint", "OunceQuart", "OunceGallon", "PintOunce",
        "PintQuart", "PintGallon", "QuartOunce", "QuartPint",
        "QuartGallon", "GallonOunce", "GallonPint", "GallonQuart"
    };

        public double convertVolume(string conversionType, double value)
        {
            switch (conversionType)
            {
                case "OuncePint":
                    result = value / 16.0;
                    break;
                case "OunceQuart":
                    result = value / 32.0;
                    break;
                case "OunceGallon":
                    result = value / 128.0;
                    break;
                case "PintOunce":
                    result = value * 16.0;
                    break;
                case "PintQuart":
                    result = value / 2.0;
                    break;
                case "PintGallon":
                    result = value / 8.0;
                    break;
                case "QuartOunce":
                    result = value * 32.0;
                    break;
                case "QuartPint":
                    result = value * 2.0;
                    break;
                case "QuartGallon":
                    result = value / 4.0;
                    break;
                case "GallonOunce":
                    result = value * 128.0;
                    break;
                case "GallonPint":
                    result = value * 8.0;
                    break;
                case "GallonQuart":
                    result = value * 4.0;
                    break;
            }
            return result;
        }
    }

}
