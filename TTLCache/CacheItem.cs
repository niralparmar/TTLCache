using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTLCache
{
    public class CacheItem
    {
        private string _value;
        public string Value
        {
            get
            {
                return this._value;
            }
        }

        public DateTime CreatedDate { get; set; }

        public CacheItem(string value)
        {
            _value = value;
            CreatedDate = DateTime.Now;
        }
        /// <summary>
        /// If item is already exist and re-inserted , than update the CreatedDate to Current Time
        /// </summary>
        public void UpdateExpiry()
        {
            this.CreatedDate = DateTime.Now;
        }
        /// <summary>
        /// Method to check whether item is expired or not.
        /// </summary>
        /// <param name="expiryDurationInDays"></param>
        /// <returns></returns>
        public bool IsValid(int expiryDurationInDays)
        {
            DateTime expiryDate = this.CreatedDate.AddDays(expiryDurationInDays);
            if (expiryDate > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
