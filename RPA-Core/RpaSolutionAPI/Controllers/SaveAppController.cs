using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Models;

namespace RpaSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveAppController : ControllerBase
    {
        private readonly ISaveAppManager _saveAppManager;

        public SaveAppController(ISaveAppManager saveAppManager) => _saveAppManager = saveAppManager;

        [HttpPost("CreateSaveApp")]
        public async Task<IActionResult> CreateCloseAppAsync(SaveApp saveApp)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("Invalid data provided");
            }

            try
            {
                await _saveAppManager.CreateAsync(saveApp);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateSaveApp")]
        public async Task<IActionResult> UpdateSaveAppAsync(SaveApp saveApp)
        {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid model");

            //Alter method returns the altered object if found otherwse it returns null
            try
            {
                if (await _saveAppManager.UpdateAsync(saveApp) == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteSaveApp")]
        public async Task<IActionResult> DeleteCloseAppAsync(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid id");

            try
            {
                await _saveAppManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getSaveApp")]
        public async Task<IActionResult> GetCloseAppAsync(Expression<Func<SaveApp, bool>> expression)
        {
            try
            {
                var component = await _saveAppManager.GetAsync(expression);

                if (component == null)
                {
                    return NotFound();
                }
                return Ok(component);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAllSaveApps")]
        public async Task<IActionResult> GetAllCloseAppsAsync()
        {
            try
            {
                var componenets = await _saveAppManager.GetAllAsync();

                if (componenets == null)
                {
                    return NotFound();
                }

                return Ok(componenets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}