using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FiscalYearRepo<entity> : IRecordsRepository<entity> where entity : class
    {
        private StudentsContext db = null;
        private DbSet<entity> table = null;
        public FiscalYearRepo()
        {
            this.db = new StudentsContext();
            table = db.Set<entity>();
        }
        public IEnumerable<entity> SelectAll()
        {
            return table.ToList();
        }


        public entity SelectByID(object id)
        {
            return table.Find(id);
        }
        public void Insert(entity obj)
        {
            table.Add(obj);
        }
        public void Update(entity obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            entity existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
