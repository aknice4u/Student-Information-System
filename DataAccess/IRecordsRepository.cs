using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public interface IRecordsRepository<entity> where entity : class
    {

       IEnumerable<entity> SelectAll();

       entity SelectByID(object id);
       void Insert(entity obj);
       void Update(entity obj);
        void Delete(object id);
        void Save();

    }
}
