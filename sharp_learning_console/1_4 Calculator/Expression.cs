using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp_learning_console._1_4_Calculator
{
    class Expression
    {
        public delegate void ErrorMessageType();
        class Element
        {
            public int I { set;  get; }
            public char C { set; get; }
            public enum ElenentType
            {
                Symbol,
                Number
            }
            public ElenentType Type { set; get; }

            public Element (int i)
            {
                Type = ElenentType.Number;
                I = i;
            }
            public Element(char c)
            {
                Type = ElenentType.Symbol;
                C = c;
            }
            public bool IsOperation()
            {
                if(Type == ElenentType.Symbol)
                {
                    if(C == '/'
                    || C == '*'
                    || C == '-'
                    || C == '+')
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private List<Element> elements;
        private bool isCorrect;
        public void ConsolePrint()
        {
            foreach(Element k in elements)
            {
                if(k.Type == Element.ElenentType.Symbol)
                {
                    Console.Write($"{k.C}");
                }else
                {
                    Console.Write($"{k.I}");
                }
            }
        }
        private bool BracCheck()
        {

            Stack<char> st = new Stack<char>();
            for (int i = 0; i < elements.Count; i++)
            {
                if(elements[i].C == '(')
                {
                    st.Push('(');
                }else if(elements[i].C == ')')
                {
                    if (st.Count == 0) return false;
                    else st.Pop();
                }
            }
            if (st.Count != 0) return false;
            else return true;

        }
        private bool CorrectionCheck()
        {
            if (elements[0].IsOperation())
            {
                return false;
            }
            if (elements[elements.Count-1].IsOperation())
            {
                return false;
            }
            for (int i=0;i<elements.Count; i++)
            {
                if (i < elements.Count - 1)
                {
                    if (elements[i].Type == Element.ElenentType.Number
                    && elements[i + 1].Type == Element.ElenentType.Number)
                    {
                        return false;
                    }
                    if (elements[i].Type == Element.ElenentType.Number
                    && elements[i + 1].C == '(')
                    {
                        return false;
                    }
                    if (elements[i].Type == Element.ElenentType.Symbol 
                        && elements[i].C!=')'
                        && elements[i + 1].IsOperation())
                    {
                        return false;
                    }
                }                
            }  
            return BracCheck();
        }

        public Expression(string inputStr)
        {
            elements = new List<Element>();
            isCorrect = true;
            for(int i=0; i<inputStr.Length;i++)
            {
                if (inputStr[i] == ' ') continue;
                if (inputStr[i] <= '9' && inputStr[i] >='0')
                {
                    int iElement = inputStr[i] - '0';
                    while (inputStr[i+1] <= '9' && inputStr[i+1] >= '0')
                    {                        
                        i++;
                        iElement *= 10;
                        iElement += inputStr[i] - '0';
                        if (i == inputStr.Length - 1) break;
                    }
                    elements.Add(new Element(iElement));
                }else if(inputStr[i] == '/' 
                    || inputStr[i] == '*' 
                    || inputStr[i] == '-' 
                    || inputStr[i] == '+' 
                    || inputStr[i] == ')' 
                    || inputStr[i] == '(' )
                {
                    char cElement = inputStr[i];
                    elements.Add(new Element(cElement));
                }else
                {
                    isCorrect = false;
                    throw new Exception("Incorrect expression");
                }
            }

            if(isCorrect)
            {
                if(!CorrectionCheck())
                {
                    isCorrect = false;
                    throw new Exception("Incorrect expression");
                }
            }
        }

        private List<Element> ToRPN()
        {
            List<Element> rPN = new List<Element>();
            Stack<Element> st = new Stack<Element>();
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Type == Element.ElenentType.Number) rPN.Add(elements[i]);
                else if (elements[i].C == '(') st.Push(elements[i]);
                else if(elements[i].C == ')')
                {
                    while(st.Peek().C != '(')
                    {
                        rPN.Add(st.Pop());
                    }
                    st.Pop();
                }else if(elements[i].C == '-' || elements[i].C == '+')
                {
                    while(st.Count !=0 && st.Peek().IsOperation())
                    {
                        rPN.Add(st.Pop());
                    }
                    st.Push(elements[i]);
                }else
                {
                    while (st.Count != 0 && (st.Peek().C == '*' || st.Peek().C == '/'))
                    {
                        rPN.Add(st.Pop());
                    }
                    st.Push(elements[i]);
                }
            }
            while(st.Count !=0)
            {
                rPN.Add(st.Pop());
            }
            return rPN;
        }
        public double SolveDouble()
        {
            List<Element> rPN = ToRPN();
            Stack<double> st = new Stack<double>();
            for(int i=0;i<rPN.Count;i++)
            {
                if(rPN[i].Type == Element.ElenentType.Number)
                {
                    st.Push(rPN[i].I);
                }else
                {
                    double b = st.Pop();
                    double a = st.Pop();
                    if(rPN[i].C == '+')
                    {
                        st.Push(a + b);
                    }else if (rPN[i].C == '-')
                    {
                        st.Push(a - b);
                    }
                    else if (rPN[i].C == '/')
                    {
                        st.Push(a / b);
                    }
                    else if (rPN[i].C == '*')
                    {
                        st.Push(a * b);
                    }
                }
            }
            return st.Pop();
        }

        public int SolveInt()
        {
            List<Element> rPN = ToRPN();
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < rPN.Count; i++)
            {
                if (rPN[i].Type == Element.ElenentType.Number)
                {
                    st.Push(rPN[i].I);
                }
                else
                {
                    int b = st.Pop();
                    int a = st.Pop();
                    if (rPN[i].C == '+')
                    {
                        st.Push(a + b);
                    }
                    else if (rPN[i].C == '-')
                    {
                        st.Push(a - b);
                    }
                    else if (rPN[i].C == '/')
                    {
                        st.Push(a / b);
                    }
                    else if (rPN[i].C == '*')
                    {
                        st.Push(a * b);
                    }
                }
            }
            return st.Pop();
        }
        public void ConsolePrintRPN()
        {
            List<Element> rPN = ToRPN();
            foreach (Element k in rPN)
            {
                if (k.Type == Element.ElenentType.Symbol)
                {
                    Console.Write($"{k.C} ");
                }
                else
                {
                    Console.Write($"{k.I} ");
                }
            }
        }

    }
}
