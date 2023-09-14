using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Services;
using Logic.Services;
using Logic.Models;
using AutoMapper;
using Warehouse_Trainee_Task.Resources;
using Warehouse_Trainee_Task.Validators;
using Serilog;

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

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _departmentService.GetDepartments();
            var departmentResources = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(departments);

            _logger.LogDebug("LogDebug ---------- GET Departments");

            return Ok(departmentResources);
        }

        // GET: api/Departments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            if (id == null)
                return BadRequest();

            var department = await _departmentService.GetDepartmentById(id);

            if (department == null)
                return NotFound();

            var departmentResource = _mapper.Map<Department,  DepartmentResource>(department);

            _logger.LogDebug("LogDebug ---------- GET DepartmentById");

            return Ok(departmentResource);
        }

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment([FromBody] SaveDepartmentResource saveDepartmentResource)
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
            var department = await _departmentService.GetDepartmentById(newDepartment.Id);
            var departmentResource = _mapper.Map<Department, DepartmentResource>(department);

            _logger.LogDebug("LogDebug ---------- POST Department");
            return Ok(departmentResource);
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

            var oldDepartment = await _departmentService.GetDepartmentById(id);

            if (oldDepartment == null)
                return NotFound();

            var newDepartment = _mapper.Map<SaveDepartmentResource, Department>(saveDepartmentResource);

            await _departmentService.UpdateDepartment(newDepartment, oldDepartment);

            var department = await _departmentService.GetDepartmentById(id);
            var departmentResource = _mapper.Map<Department, DepartmentResource>(department);

            return Ok(departmentResource);
        }


        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (id == null)
            {
                _logger.LogError("LogError ------- DELETE Department");
                return BadRequest();
            }

            var department = await _departmentService.GetDepartmentById(id);

            if (department is null)
                return NotFound();

            await _departmentService.DeleteDepartment(department);

            return NoContent();
        }
    }
}
