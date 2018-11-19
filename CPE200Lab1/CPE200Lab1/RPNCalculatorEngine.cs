using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    /// <summary>
    /// RPNCalculatorEngine class.
    /// This class is a sub-class to CalculatorEngine.
    /// </summary>
    /// <returns>
    /// Value in stack.
    /// </returns>
    public class RPNCalculatorEngine : CalculatorEngine
    {
        /// <summary>
        /// Process Function
        /// This Function split an input to number or operator
        /// Then push the result from spliting method into stack
        /// Checking the elements that will be push into stack
        /// If it is a number then push it to stack
        /// If it is an operator then pop 2 elements in stack and calculate.
        /// The result from calculate method will be push into stack.
        /// The stack must has only 1 element in the end.
        /// </summary>
        /// <param name="str">  input </param>
        public new string Process(string str)
        {
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;
            int checkInStack = 0;

            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(token, firstOperand, secondOperand, 4);
                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            foreach (string R in rpnStack) {
                checkInStack++;
                if (checkInStack != 1)
                    return "E";
            }
            result = rpnStack.Pop();
            return result;
        }
    }
}
