using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an_3.DataProviders
{
    class DataProvider
    {
        // Singletong to create just one database object entire application

        private static DataProvider _ins;
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new DataProvider();
                }
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public ShopCakeEntities DB { get; set; }

        private DataProvider()
        {
            DB = new ShopCakeEntities();
        }
    }
}
