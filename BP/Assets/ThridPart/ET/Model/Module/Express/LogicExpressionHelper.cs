using System;
using System.Collections.Generic;
using System.Text;

namespace ET
{
    public static class LogicExpressionHelper
    {
        private static Stack<char> opStack = new Stack<char>();
        private static Stack<char> numStack = new Stack<char>();
        private static StringBuilder strBuild = new StringBuilder();
        private static Stack<char> rpnFormula = new Stack<char>();
        private static Stack<bool> resultStack = new Stack<bool>();

        private static HashSet<char> AllOp = new HashSet<char>() { '(', ')', '&', '|' };

        private static void Clear()
        {
            opStack.Clear();
            opStack.Push('#');
            numStack.Clear();
            strBuild.Clear();
            rpnFormula.Clear();
            resultStack.Clear();
        }

        //第一句是表达式，第二个是表达式里的操作数转换为T或者F的逻辑
        ////CalExpression("(2&51|7+3)|63",
        //s=>
        //        {
        //            if (s.Length != 1) return false;
        //            else return true;
        //        })
        // 比如上面这个例子里，表达式里的非操作符（即 (),&,| 这四个以外的字符）都会被分割为一个个字符串。
        // 传入的Func中，根据字符串返回一个bool结果。
        public static bool CalExpression(string formula, Func<string, bool> replaceAction)
        {
            Clear();
            for (int i = 0; i < formula.Length;)
            {
                char c = formula[i];
                int opNum = GetOperationLevel(c);
                //操作数
                if (opNum == 0)
                {
                    int index = GetCompleteValue(formula.Substring(i, formula.Length - i));
                    bool result = replaceAction(formula.Substring(i, index));
                    numStack.Push(result? 'T' : 'F');
                    i = i + index;
                }
                else
                {
                    if (formula[i] == '(')
                    {
                        opStack.Push(formula[i]);
                    }
                    else if (formula[i] == ')')
                    {
                        MoveOperator(opStack, numStack);
                    }
                    else
                    {
                        if (opStack.Peek() == '(')
                        {
                            opStack.Push(formula[i]);
                        }
                        else
                        {
                            JudgeOperator(opStack, numStack, formula[i]);
                        }
                    }

                    i++;
                }
            }

            if (opStack.Count != 0)
            {
                while (opStack.Count != 0 && opStack.Peek() != '#')
                {
                    numStack.Push(opStack.Pop());
                }
            }

            foreach (char s in numStack)
            {
                rpnFormula.Push(s);
            }

            return CalcRPNFormula(rpnFormula);
        }

        private static int GetCompleteValue(string formula)
        {
            int index = formula.Length;
            for (int i = 0; i < formula.Length; i++)
            {
                int num = GetOperationLevel(formula[i]);
                if (num != 0)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private static void MoveOperator(Stack<char> opStack, Stack<char> numStack)
        {
            char s = opStack.Pop();
            if (s == '(')
            {
            }
            else
            {
                numStack.Push(s);
                MoveOperator(opStack, numStack);
            }
        }

        private static void JudgeOperator(Stack<char> opStack, Stack<char> numStack, char x)
        {
            int xNum = GetOperationLevel(x);
            int opNum = GetOperationLevel(opStack.Peek());
            if (xNum > opNum || numStack.Peek() == '(')
            {
                opStack.Push(x);
            }
            else
            {
                char opStr = opStack.Pop();
                numStack.Push(opStr);
                JudgeOperator(opStack, numStack, x);
            }
        }

        private static int GetOperationLevel(char c)
        {
            switch (c)
            {
                case '&':
                    return 1;
                case '|':
                    return 1;
                case '#':
                    return -1;
                case '(':
                    return -1;
                case ')':
                    return -1;
                default:
                    return 0;
            }
        }

        private static bool CalcRPNFormula(Stack<char> rpnFormula)
        {
            while (rpnFormula.Count > 0)
            {
                char rpnStr = rpnFormula.Pop();
                int num = GetOperationLevel(rpnStr);
                if (num == 0)
                {
                    resultStack.Push(rpnStr == 'T');
                }
                else
                {
                    CalcResult(resultStack, rpnStr);
                }
            }

            return resultStack.Pop();
        }

        private static void CalcResult(Stack<bool> resultStack, char operatorStr)
        {
            if (resultStack.Count >= 2)
            {
                if (operatorStr == '&')
                {
                    bool num2 = resultStack.Pop();
                    bool num1 = resultStack.Pop();
                    resultStack.Push(num1 & num2);
                }
                else if (operatorStr == '|')
                {
                    bool num2 = resultStack.Pop();
                    bool num1 = resultStack.Pop();
                    resultStack.Push(num1 | num2);
                }
            }
        }
    }
}