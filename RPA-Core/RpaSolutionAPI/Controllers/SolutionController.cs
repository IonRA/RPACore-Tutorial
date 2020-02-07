using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Models;

namespace RpaSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private readonly ISolutionManager _solutionManager;
        public SolutionController(ISolutionManager solutionManager) => _solutionManager = solutionManager;

        [HttpPost("CreateSolution")]
        public async Task<IActionResult> CreateSolutionAsync(Solution solution)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest("Invalid data provided");
            }

            try
            {
                await _solutionManager.CreateAsync(solution);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}