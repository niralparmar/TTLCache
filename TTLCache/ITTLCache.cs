using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTLCache
{
    interface ITTLCache
    {
        /// <summary>
        /// Adds new cache item into Cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Add(string key, string value);

        /// <summary>
        /// Gets cached values.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Cached value. Null if item is expired</returns>
        string Get(string key);

        /// <summary>
        /// Current number cached items.
        /// </summary>
        /// <returns>Count of non-expired cache items</returns>
        int Count();

        /// <summary>
        /// Empty current Cache
        /// </summary>
        void Clear();
    }
}
