namespace Masha.Foundation
{
    using System;
    using System.Text;

    public class Writer<T>
    {
        internal string log;
        internal T value;
        public bool HasValue { get; private set; }

        internal Writer(T value, string str)
        {
            log = string.IsNullOrEmpty(str) ? string.Empty : str;
            this.value = value;
        }
    }
}
