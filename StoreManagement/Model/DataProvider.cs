using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Model
{
    public class DataProvider
    {
        private static DataProvider _ins; // instance of data provider, but basically it is StoreManagement entity. Singleton design pattern 
        public static DataProvider Ins { 
            get
            { 
                if (_ins == null) 
                    _ins = new DataProvider(); 
                return _ins; 
            } 
            set { _ins = value; } 
        }
        public StoreManagementEntities1 DB { get; set; }
        private DataProvider()
        {

            DB = new StoreManagementEntities1();
        }
    }
}
