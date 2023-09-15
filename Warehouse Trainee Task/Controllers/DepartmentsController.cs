using AutoMapper;
using Logic.Models;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Warehouse_Trainee_Task.Resources;
using Warehouse_Trainee_Task.Validators;

namespace Warehouse_Trainee_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentResource> _logger;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper, ILogger<DepartmentResource> logger)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentResource>>> GetDepartments()
        {
            _logger.LogDebug("LogDebug ---------- GET Departments");

            var departments = await _departmentService.GetDepartments();
            var departmentResources = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(departments);

            return Ok(departmentResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentResource>> GetDepartment(int id)
        {
            _logger.LogDebug("LogDebug ---------- GET DepartmentById");

            var department = await _departmentService.GetDepartmentById(id);

            if (department == null)
                return NotFound();

            var departmentResource = _mapper.Map<Department, DepartmentResource>(department);

            return Ok(departmentResource);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentResource>> PostDepartment([FromBody] SaveDepartmentResource saveDepartmentResource)
        {
            var validator = new SaveDepartmentResourceValidator();
            var validationResult = await validator.ValidateAsync(saveDepartmentResource);

            if (!validationResult.IsValid)
            {
                _logger.LogError("LogError ------- POST Department");
                return BadRequest();
            }

            var mappedDepartment = _mapper.Map<SaveDepartmentResource, Department>(saveDepartmentResource);
            var newDepartment = await _departmentService.CreateDepartment(mappedDepartment);

            var departmentResource = _mapper.Map<Department, DepartmentResource>(newDepartment);

            _logger.LogDebug("LogDebug ---------- POST Department");
            return Ok(departmentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, [FromBody] SaveDepartmentResource saveDepartmentResource)
        {
            var validator = new SaveDepartmentResourceValidator();
            var validationResult = await validator.ValidateAsync(saveDepartmentResource);

            bool invalidRequest = id == 0 || !validationResult.IsValid;

            if (invalidRequest)
            {
                _logger.LogError("LogError ------- PUT Department");
                return BadRequest();
            }

            _logger.LogDebug("LogDebug ---------- PUT Department");

            var oldDepartment = await _departmentService.GetDepartmentById(id);

            if (oldDepartment == null)
                return NotFound();

            var newDepartment = _mapper.Map<SaveDepartmentResource, Department>(saveDepartmentResource);

            await _departmentService.UpdateDepartment(newDepartment, oldDepartment);

            var department = await _departmentService.GetDepartmentById(id);
            var departmentResource = _mapper.Map<Department, DepartmentResource>(department);

            return Ok(departmentResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentService.GetDepartmentById(id);

            _logger.LogDebug("LogDebug ---------- DELETE Department");

            if (department is null)
                return NotFound();

            await _departmentService.DeleteDepartment(department);

            return NoContent();
        }
    }
}
