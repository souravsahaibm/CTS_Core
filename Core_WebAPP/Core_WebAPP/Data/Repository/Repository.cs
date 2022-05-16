using Core_WebAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebAPP.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDBContext _dbcontext;

        public Repository(AppDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Contact> AllContact()
        {
            return _dbcontext.Contact.OrderBy(a => a.Id).ToList();
        }

        public Contact getById(int id)
        {
            return _dbcontext.Contact.Where(a => a.Id == id).FirstOrDefault();
        }

        public void createContact(Contact obj)
        {
            _dbcontext.Add(obj);
            //savechanges();
        }
        public bool savechanges()
        {
            return _dbcontext.SaveChanges() > 0;
        }
    }
}
