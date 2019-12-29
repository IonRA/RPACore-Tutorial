using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Models;

namespace RpaSolutionAPI.Controllers
{
    [Route("rpa-solution-api/[controller]")]
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
        public async Task<IActionResult> CreateOpenAppAsync(OpenApp openApp)
        {
            //check if the assigned object respects all the established requirements (i.e if it has the name of the app
            //it tries to open, and so on...)
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            //_openAppManager it's used to call library's methods to do the dirty work
            await _openAppManager.CreateAsync(openApp);

            return Ok();
        }

        [HttpPut("AlterOpenApp")]
        public async Task<IActionResult> AlterOpenAppAsync(OpenApp openApp)
        {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid model");

            //Alter method returns the altered object if found otherwse it returns null
            if (await _openAppManager.UpdateAsync(openApp) == null)
                return NotFound();

            return Ok();
        }

        [HttpGet("GetOpenApp")]
        public async Task<IActionResult> GetOpenAppAsync(Expression<Func<OpenApp, bool>> expression)
        {
            //retrive OpenApp object from Db, if exists
            var component = await _openAppManager.GetAsync(expression);

            if (component == null)
                return NotFound();

            return Ok(component);
        }

        [HttpGet("GetAllOpenApps")]
        public async Task<IActionResult> GetAllOpenAppAsync()
        {
            //retrive all OpenApp objects from Db, if exists
            var component = await _openAppManager.GetAllAsync();

            if (component == null)
                return NotFound();

            return Ok(component);
        }

        [HttpDelete("DeleteOpenApp")]
        public async Task<IActionResult> DeleteOpenAppAsync(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid id");

            await _openAppManager.DeleteAsync(id);

            return Ok();
        }
    }
}