using IBetWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBetWinApp.Managers
{
    public class DataStoreManager
    {
        private static DataStoreManager sharedManager;
        public static DataStoreManager SharedManager
        {
            get
            {
                if (sharedManager == null)
                {
                    sharedManager = new DataStoreManager();
                }
                return sharedManager;
            }
        }

        public UserModel CurrentUser { get; set; }
    }
}
