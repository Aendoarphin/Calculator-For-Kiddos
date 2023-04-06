using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class Length
    {
        public double result;
        // Unit combinations to identify conversion to invoke
        public string[] lengthConversions = {
            "InchFoot", "InchYard", "InchMile", "FootInch",
            "FootYard", "FootMile", "YardInch", "YardFoot",
            "YardMile", "MileInch", "MileYard", "MileFoot"
        };
        //Conversions
        public double convertLength(string conversionType, double value)
        {

            switch (conversionType)
            {
                case "InchFoot":
                    result = value / 12.0;
                    break;
                case "InchYard":
                    result = value / 36.0;
                    break;
                case "InchMile":
                    result = value / 63360.0;
                    break;
                case "FootInch":
                    result = value * 12.0;
                    break;
                case "FootYard":
                    result = value / 3.0;
                    break;
                case "FootMile":
                    result = value / 5280.0;
                    break;
                case "YardInch":
                    result = value * 36.0;
                    break;
                case "YardFoot":
                    result = value * 3.0;
                    break;
                case "YardMile":
                    result = value / 1760.0;
                    break;
                case "MileInch":
                    result = value * 63360.0;
                    break;
                case "MileYard":
                    result = value * 1760.0;
                    break;
                case "MileFoot":
                    result = value * 5280.0;
                    break;

            }
            return result;
        }

    }
}
