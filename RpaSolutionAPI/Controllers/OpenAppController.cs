using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RpaCrudLibrary.Interfaces;
using RpaCrudLibrary.Models;

namespace RpaSolutionAPI.Controllers
{
    [Route("api/openapp")]
    [ApiController]
    public class OpenAppController : ControllerBase
    {
        //readonly fields have to be assigned before constructor exits, after that they can't change their value
        //_openAppManager is a service assigned in constructor by DI
        private readonly IOpenAppManager _openAppManager;


        //the cosntructor is written in expression-bodied form (similar to lambda expressions)
        //openAppManager is instanceated by DI
        public OpenAppController(IOpenAppManager openAppManager) => _openAppManager = openAppManager;

        //the attributes like [HttpPost("<actionName>")], specifies the http verb to wich the action shall respond
        //and the calling name from Uri
        [HttpPost("CreateOpenApp")]
        public ActionResult CreateOpenApp(OpenApp openApp)
        {
            //check if the assigned object respects all the established requirements (i.e if it has the name of the app
            //it tries to open, and so on...)
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            //_openAppManager it's used to call library's methods to do the dirty work
            _openAppManager.Create(openApp);

            return Ok();
        }

        [HttpPut("AlterOpenApp")]
        public ActionResult AlterOpenApp(int id, OpenApp openApp)
        {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid model");

            //Alter method returns the altered object if found otherwse it returns null
            if (_openAppManager.Alter(id, openApp) == null)
                return NotFound();

            return Ok();
        }

        [HttpGet("GetOpenApp")]
        public ActionResult GetOpenApp(int id)
        {
            //retrive OpenApp object from Db, if exists
            var component = _openAppManager.Get(id);

            if (component == null)
                return NotFound();

            return Ok(component);
        }

        [HttpDelete("DeleteOpenApp")]
        public ActionResult DeleteOpenApp(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid id");

            _openAppManager.Delete(id);

            return Ok();
        }
    }
}