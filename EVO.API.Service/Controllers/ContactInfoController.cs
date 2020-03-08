using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EVO.API.Service.Interfaces;
using EVO.API.Service.Models;
using EVO.API.Service.Repository;

namespace EVO.API.Service.Controllers
{
    [RoutePrefix("api/Contacts")]
    public class ContactInfoController : ApiController
    {
        private IContactInfoRepository _contactInfoRepository;
        public ContactInfoController(IContactInfoRepository contactInfoRepository)
        {
            _contactInfoRepository = contactInfoRepository;
        }

        // GET: api/Contacts
        [Route("")]
        public IHttpActionResult Get()
        {
            var result = _contactInfoRepository.GetAll().ToList();
            return Ok(result);
        }

        // PUT: api/Contacts/5
        [Route("{id:int:min(1)}")]
        public IHttpActionResult Put(int id, ContactInformation contactInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != contactInformation.ID)
            {
                return BadRequest();
            }

            _contactInfoRepository.Update(id, contactInformation);

            return Content(HttpStatusCode.Accepted, contactInformation);
        }

        // POST: api/Contacts
        [Route("")]
        public IHttpActionResult Post(ContactInformation contactInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contactInfoRepository.Add(contactInformation);
            return Ok();
        }

        // DELETE: api/Contacts/5
        [Route("{id:int:min(1)}")]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id must be greater then zero");
            }
            _contactInfoRepository.Delete(id);
            return Ok();
        }

    }
}