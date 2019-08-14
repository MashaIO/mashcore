namespace Masha.Foundation
{
    using System;
    using System.Collections.Generic;

    public interface ISettings
    {
        Option<string> Get(string key);
        Option<string> GetAsPlain(string key);
        Option<IList<string>> GetAsList(string key);
        Option<IDictionary<string, string>> GetAsDictionary(string key);
        Option<T> Get<T>(string key, T defaultValue = default);
    }
}