﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rpa.Domain.Models;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Models;

namespace RpaSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloseAppController : ControllerBase
    {
        private readonly ICloseAppManager _closeAppManager;

        public CloseAppController(ICloseAppManager closeAppManager) => _closeAppManager = closeAppManager;

        [HttpPost("CreateCloseApp")]
        public async Task<IActionResult> CreateCloseAppAsync(CloseAppModel closeApp)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("Invalid data provided");
            }

            try
            {
                CloseApp closeAppEntity = new CloseApp { IdSolution = closeApp.IdSolution, PID = closeApp.PID };
                await _closeAppManager.CreateAsync(closeAppEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateCloseApp")]
        public async Task<IActionResult> UpdateCloseAppAsync(CloseApp closeApp)
        {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid model");

            //Alter method returns the altered object if found otherwse it returns null
            try
            {
                if (await _closeAppManager.UpdateAsync(closeApp) == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteCloseApp")]
        public async Task<IActionResult> DeleteCloseAppAsync(Guid id)
        {
            try
            {
                await _closeAppManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetCloseApp")]
        public async Task<IActionResult> GetCloseAppAsync(Guid id)
        {
            try
            {
                var component = await _closeAppManager.GetAsync( x => x.ComponentId == id );
                
                if (component == null)
                {
                    return NotFound();
                }
                return Ok(component);

            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAllCloseApps")]
        public async Task<IActionResult> GetAllCloseAppsAsync()
        {
            try
            {
                var componenets = await _closeAppManager.GetAllAsync();

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