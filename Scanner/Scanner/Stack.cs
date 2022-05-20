using System; 

namespace Scanner
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

        public bool Pop(ref string data)
        {
            if (top < 0)
            {
                return false;
            }
            else
            {
                data = stack[top--];
                return true;
            }
        }

        public bool GetTop(ref string data)
        {
            if (top >= 0)
            {
                data = stack[top];
                return true;
            }
            return false;
        }        
    }
}
