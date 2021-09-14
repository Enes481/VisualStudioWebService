using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
    public class BaseDAL
    {

        protected PersonelEntities1 db;
        public BaseDAL()
        {
            db = new PersonelEntities1();
        }

    }
}
