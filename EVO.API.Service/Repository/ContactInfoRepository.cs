using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using EVO.API.Service.Interfaces;
using EVO.API.Service.Models;

namespace EVO.API.Service.Repository
{
    public class ContactInfoRepository : IContactInfoRepository
    {
        private ContactInfoDbContext db = new ContactInfoDbContext();

        public void Add(ContactInformation contactInformation)
        {
            try
            {
                db.Contacts.Add(contactInformation);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ChangeSatus(int id, bool status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactInformation> GetAll()
        {
            return db.Contacts;
        }


        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.ID == id) > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Update(int id, ContactInformation contactInformation)
        {
            try
            {
                if (ContactExists(id))
                {
                    db.Entry(contactInformation).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                if (ContactExists(id))
                {
                    ContactInformation contact = db.Contacts.Find(id);
                    db.Contacts.Remove(contact);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}