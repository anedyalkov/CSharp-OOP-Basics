namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings
    {
        List<string> data = new List<string>();

        public bool IsEmpty()
        {
            return data.Count == 0;
        }

        public void Push(string item)
        {
            data.Add(item);
        }


        public string Pop()
        {
            var popped = string.Empty;
            
            if (!IsEmpty())
            {
                var index = data.Count - 1;
                popped = data[index];
                data.RemoveAt(index);
            }
           
            return popped;
        }

        public string Peek()
        {
            var peeked = string.Empty;

            if (!IsEmpty())
            {
                peeked = data[data.Count - 1];
            }
            
            return peeked;
        }
    }
}
