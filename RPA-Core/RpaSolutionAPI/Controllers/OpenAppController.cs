using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rpa.Domain.Models;
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
        public async Task<IActionResult> CreateOpenAppAsync(OpenAppModel openApp)
        {
            //check if the assigned object respects all the established requirements (i.e if it has the name of the app
            //it tries to open, and so on...)
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            //_openAppManager it's used to call library's methods to do the dirty work
            try
            {
                OpenApp openAppEntity = new OpenApp { AppName = openApp.AppName, UseShell = openApp.UseShell, IdSolution = openApp.IdSolution };

                await _openAppManager.CreateAsync(openAppEntity);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("AlterOpenApp")]
        public async Task<IActionResult> AlterOpenAppAsync(OpenApp openApp)
        {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid model");

            //Alter method returns the altered object if found otherwse it returns null
            try
            {
                if (await _openAppManager.UpdateAsync(openApp) == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetOpenApp")]
        public async Task<IActionResult> GetOpenAppAsync(Expression<Func<OpenApp, bool>> expression)
        {
            //retrive OpenApp object from Db, if exists
            try
            {
                var component = await _openAppManager.GetAsync(expression);

                if (component == null)
                    return NotFound();

                return Ok(component);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAllOpenApps")]
        public async Task<IActionResult> GetAllOpenAppAsync()
        {
            //retrive all OpenApp objects from Db, if exists
            try
            {
                var components = await _openAppManager.GetAllAsync();

                if (components == null)
                    return NotFound();

                return Ok(components);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteOpenApp")]
        public async Task<IActionResult> DeleteOpenAppAsync(Guid id)
        {
            try
            {
                await _openAppManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}