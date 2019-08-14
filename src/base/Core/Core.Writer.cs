namespace Masha.Foundation
{
    using System;

    public static partial class Core
    {
        public static Writer<T> Map<T>(this Writer<T> writer, Func<T, Writer<T>> f)
        {
            if(writer.value != null)
            {
                var result = f(writer.value);
                writer.log = writer.log + "\n" + result.log;
                return result;
            }else
            {
                return writer;
            }
        }

        public static Writer<T> Mapi<T>(this Writer<T> writer, Func<T, Writer<T>> f)
        {
            if (writer.value != null)
            {
                var result = f(writer.value);
                writer.log = writer.log + "\n" + result.log;
                return result;
            }
            else
            {
                return writer;
            }
        }

        public static Writer<T> Writer<T>(T value, string str) => new Writer<T>(value, str);
    }
}
