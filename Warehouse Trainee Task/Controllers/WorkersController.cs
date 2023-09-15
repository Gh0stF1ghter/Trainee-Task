using AutoMapper;
using Logic.Models;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Services;
using Warehouse_Trainee_Task.Resources;
using Warehouse_Trainee_Task.Validators;

//
namespace Warehouse_Trainee_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly ILogger<WorkerService> _logger;
        private readonly IMapper _mapper;
        private readonly IWorkerService _service;

        public WorkersController(ILogger<WorkerService> logger, IMapper mapper, IWorkerService workerService)
        {
            _logger = logger;
            _mapper = mapper;
            _service = workerService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerResource>>> GetWorkers()
        {
            _logger.LogDebug("LogDebug ---------- GET Products");

            var workers = await _service.GetWorkers();

            var workersResource = _mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerResource>>(workers);

            return Ok(workersResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerResource>> GetWorker(int id)
        {
            _logger.LogDebug("LogDebug ---------- GET WorkerById");

            var worker = await _service.GetWorkerById(id);

            if (worker == null)
            {
                return NotFound();
            }

            var workerResource = _mapper.Map<Worker, WorkerResource>(worker);

            return Ok(workerResource);
        }

        [HttpPost]
        public async Task<ActionResult<WorkerResource>> PostWorker([FromBody] SaveWorkerResource saveWorkerResource)
        {
            var validator = new SaveWorkerResourceValidator();
            var validationResult = validator.Validate(saveWorkerResource);

            if (!validationResult.IsValid)
            {
                _logger.LogError("LogError ---------- POST Worker");
                return BadRequest();
            }

            _logger.LogDebug("LogDebug ---------- POST Worker");

            var mappedWorker = _mapper.Map<SaveWorkerResource, Worker>(saveWorkerResource);
            var newWorker = await _service.CreateWorker(mappedWorker);

            var worker = await _service.GetWorkerById(newWorker.Id);
            var workerResource = _mapper.Map<Worker, WorkerResource>(worker);

            return Ok(workerResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(int id, [FromBody] SaveWorkerResource saveWorkerResource)
        {
            var validator = new SaveWorkerResourceValidator();

            var validationResult = validator.Validate(saveWorkerResource);

            var invalidResult = id == 0 || !validationResult.IsValid;

            if (invalidResult)
            {
                _logger.LogError("LogError ---------- PUT Worker");
                return BadRequest(validationResult.Errors);
            }

            _logger.LogDebug("LogDebug ---------- PUT Worker");


            var oldWorker = await _service.GetWorkerById(id);

            if (oldWorker == null)
                return NotFound();

            var newWorker = _mapper.Map<SaveWorkerResource, Worker>(saveWorkerResource);
            await _service.UpdateWorker(newWorker, oldWorker);

            var worker = _mapper.Map<Worker, WorkerResource>(newWorker);

            return Ok(worker);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            _logger.LogDebug("LogDebug ---------- DELETE Worker");

            var worker = await _service.GetWorkerById(id);

            if (worker == null)
                return NotFound();

            await _service.DeleteWorker(worker);

            return NoContent();
        }
    }
}
