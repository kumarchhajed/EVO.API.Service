using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EVO.API.Service.Models;

namespace EVO.API.Service.Interfaces
{
    public interface IContactInfoRepository
    {
        IEnumerable<ContactInformation> GetAll();
        void Add(ContactInformation contactInformation);
        void Update(int id,ContactInformation contactInformation);
        void Delete(int id); 
    }
}