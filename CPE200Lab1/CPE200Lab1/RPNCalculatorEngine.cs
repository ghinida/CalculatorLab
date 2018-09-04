using System;
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
			Stack<string> numberStack = new Stack<string>();
			string[] numbers = str.Split(' ');
			foreach (string number in numbers)
			{
				if (isOperator(number))
				{
					string secondOperand = numberStack.Pop();
					string firstOperand = numberStack.Pop();
					string answer = calculate(number, firstOperand, secondOperand);
					numberStack.Push(answer);
				}
				else
				{
					numberStack.Push(number);
				}
			}
			return numberStack.Pop();

		}
	}
}
