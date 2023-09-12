﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Trainee_Task.Data;
using Warehouse_Trainee_Task.Models;

//
namespace Warehouse_Trainee_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly WarehouseContext _context;

        private readonly ILogger<Worker> _logger;

        public WorkersController(WarehouseContext context, ILogger<Worker> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Workers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> GetWorkers()
        {
            if (_context.Workers == null)
            {
                return NotFound();
            }

            _logger.LogDebug("LogDebug ----- GetWorkers");
            return await _context.Workers.ToListAsync();
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            if (worker is null)
            {
                return NotFound();
            }

            _logger.LogDebug("LogDebug ----- GetWorker");

            return worker;
        }

        // PUT: api/Workers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(int? id)
        {
            if (id == null)
                return BadRequest();

            var update = await _context.Workers.FirstOrDefaultAsync(s => s.Id == id);

            if (await TryUpdateModelAsync<Worker>(update, "", s => s.FirstName, s => s.LastName))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "PutWorker Error");
                }
            }

            _logger.LogDebug("LogDebug ----- PutWorker");
            return BadRequest();
        }

        // POST: api/Workers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Worker>> PostWorker(Worker worker)
        {
            if (_context.Workers == null)
            {
                return Problem("Entity set 'WarehouseContext.Workers'  is null.");
            }
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();
            _logger.LogDebug("LogDebug ----- PostWorker");

            return CreatedAtAction("GetWorker", new { id = worker.Id }, worker);
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            if (worker is null)
            {
                return NotFound();
            }

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();

            _logger.LogDebug("LogDebug ----- DeleteWorker");
            return Ok();
        }

        private bool WorkerExists(int id)
        {
            return (_context.Workers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}