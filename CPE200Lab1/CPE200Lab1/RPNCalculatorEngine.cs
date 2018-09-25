﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            Stack<string> numbers = new Stack<string>();
            string[] parts = str.Split(' ');
            if (parts.Length == 1)
            {
                return "E";
            }
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    numbers.Push(parts[i]);
                }
                else if (thisisOperator(parts[i]))
                {
                    string first;

					try {
						first = numbers.Peek();
						numbers.Pop();
						numbers.Push(unaryCalculate(parts[i], first, 8));
					}
					catch { }

                    first = numbers.Peek();
					numbers.Pop();
                    numbers.Push(unaryCalculate(parts[i],first,8));
                }
                else if (isModOpreator(parts[i]))
                {
                    string first, second;

					try {
						second = numbers.Peek();
						numbers.Pop();
						first = numbers.Peek();
						numbers.Pop();
						numbers.Push(thismodCalculator(first, second, 8));
					}
					catch {
						return "E";
					}

                }
                else if (isOperator(parts[i]))
                {
					string first, second;
					try {
						second = numbers.Peek();
						numbers.Pop();
						first = numbers.Peek();
						numbers.Pop();
						numbers.Push(calculate(parts[i], first, second, 8));
					}
					catch {
						return "E";
					}
                    /*if (numbers.Count < 2)
                    {
                        return "E";
                    }
                    string first, second;
                    second = numbers.Peek();
                    numbers.Pop();
                    first = numbers.Peek();
                    numbers.Pop();
                    numbers.Push(calculate(parts[i], first, second, 8));*/
                }

            }
            if (numbers.Count == 1)
            {
                return numbers.Peek();
            }
            else
            {
                return "E";
            }
            
        }
    }
}
