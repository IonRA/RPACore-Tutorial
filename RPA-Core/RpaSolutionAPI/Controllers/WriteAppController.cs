using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rpa.Domain.Models;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Models;

namespace RpaSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteAppController : ControllerBase
    {
        private readonly IWriteAppManager _writeAppManger;

        public WriteAppController(IWriteAppManager writeAppManager) => _writeAppManger = writeAppManager;

        [HttpPost("CreateWriteApp")]
        public async Task<IActionResult> CreateWriteAppAsync(WriteAppModel writeApp)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("Invalid data provided");
            }

            try
            {
                WriteApp writeAppEntity = new WriteApp { IdSolution = writeApp.IdSolution, Message = writeApp.Message, PID = writeApp.PID };
                await _writeAppManger.CreateAsync(writeAppEntity);
                return Ok(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateWriteApp")]
        public async Task<IActionResult> UpdateWriteComponent(WriteApp writeApp)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("Invalid model");
            }

            try
            {
                if (await _writeAppManger.UpdateAsync(writeApp) == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteWriteApp")]
        public async Task<IActionResult> DeleteWriteAppAsync(Guid id)
        {
            try
            {
                await _writeAppManger.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetWriteApp")]
        public async Task<IActionResult> GetCloseAppAsync(Expression<Func<WriteApp, bool>> expression)
        {
            try
            {
                var component = await _writeAppManger.GetAsync(expression);

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

        [HttpGet("GetAllWriteApps")]
        public async Task<IActionResult> GetAllCloseAppsAsync()
        {
            try
            {
                var componenets = await _writeAppManger.GetAllAsync();

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
