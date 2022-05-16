using Core_WebAPP.Data.Repository;
using Core_WebAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebAPP.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IRepository _dbcontext;
        private readonly ILogger<ContactController> _log;

        public ContactController(IRepository dbcontext, ILogger<ContactController> log)
        {
            _dbcontext = dbcontext;
            _log = log;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAllContacts()
        {
            try
            {
                return Ok(_dbcontext.AllContact());
            }
            catch (Exception ex)
            {
                _log.LogError($"Unable to load contact data, error - {ex}");
            }
            return BadRequest($"Unable to load contact data");
        }
        [HttpGet("{id:int}")]
        public ActionResult<Contact> GetbyId(int id)
        {
            try
            {
                var data = _dbcontext.getById(id);
                if (data != null)
                    return Ok(data);
                else
                    return NotFound($"Data can't found for ID - {id}");
            }
            catch (Exception ex)
            {
                _log.LogError($"Unable to load request for ID {id}, error - {ex}");
            }
            return BadRequest($"Unable to load request for ID { id}");
        }

        [HttpPost]
        public ActionResult<Contact> CreateContact(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbcontext.createContact(contact);
                    if (_dbcontext.savechanges())
                        return Created($"/api/contact/{contact.Id}", contact);
                }
            }
            catch (Exception ex)
            {

                _log.LogError($"Create contact error : {ex}");
            }
            return BadRequest("Create contact bad request");
        }
    }
}
