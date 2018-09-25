using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        public bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }

        public bool isModOpreator(string str)
        {
            if(str == "%")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool thisisOperator(string str)
        {
            switch (str)
            {
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            string[] parts = str.Split(' ');
            if (parts.Length >= 4)
            {
                if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]) && isModOpreator(parts[3]))
                {
                    return modCalculate(parts[1], parts[0], parts[2], 4);
                }
            }
            if (isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2]))
            {
                return calculate(parts[1], parts[0], parts[2], 4);
            }
            else if (isNumber(parts[0]) && thisisOperator(parts[1]))
            {
                return unaryCalculate(parts[1], parts[0], 4);
            }

            else
            {
                return "E";
            }
        }
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));                       
                        parts = result.ToString().Split('.');   
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        } 
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);
                    }
                case "1/x":
                    if(operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));

                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);
                    }
                    break;
                
            }
            return "E";
        }
        public string modCalculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
                case "÷":
                    return (Convert.ToDouble(firstOperand) / (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand)))).ToString();
            }
            return "E";
        }
        public string thismodCalculator(string firstOperand, string secondOperand, int maxOutputSize = 8)
        {

            return (Convert.ToDouble(firstOperand) * (0.01 * Convert.ToDouble(secondOperand))).ToString();
        }

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        parts = result.ToString().Split('.');
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        return result.ToString("N" + remainLength).Contains(".") ? result.ToString("N" + remainLength).TrimEnd('0').TrimEnd('.') : result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    //your code here
                    break;
            }
            return "E";
        }
    }
}
