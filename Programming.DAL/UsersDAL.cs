using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
   public class UsersDAL:BaseDAL  // Authentication işlemleri için oluşturduğumuz sınıf 
    {
        public Users GetUsersByApiKey(string apiKey)
        {
            return db.Users.FirstOrDefault(x => x.UserKey.ToString() == apiKey);
        }
    }
}
