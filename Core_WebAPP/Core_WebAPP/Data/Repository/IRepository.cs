using Core_WebAPP.ViewModels;
using System.Collections.Generic;

namespace Core_WebAPP.Data.Repository
{
    public interface IRepository
    {
        IEnumerable<Contact> AllContact();
        void createContact(Contact obj);
        Contact getById(int id);
        bool savechanges();
    }
}