namespace Masha.Foundation
{
    using System;
    using System.Text;
    using static Masha.Foundation.Core;

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

        public Result<T> AsResult => value;
        public Option<T> AsOption => value;

        public string Log => log;
    }
}
