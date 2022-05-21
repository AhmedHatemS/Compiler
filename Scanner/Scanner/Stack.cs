using System; 

namespace Compiler
{
    public class Stack
    {
        static readonly int MAX = 100000;
        int top;
        string[] stack = new string[MAX];

        public bool IsEmpty()
        {
            return (top < 0);
        }
        public bool IsFull()
        {
            return (top >= MAX);
        }
        public Stack()
        {
            top = -1;
        }
        public bool Push(string data)
        {
            if (top >= MAX)
            {
                return false;
            }
            else
            {
                stack[++top] = data;
                return true;
            }
        }

        public string Pop()
        {
            if (top < 0)
            {
                return "";
            }
            return stack[top--];
        }

        public string GetTop()
        {
            if (top >= 0)
            {
                return stack[top];
            }
            return "";
        }        
    }
}
