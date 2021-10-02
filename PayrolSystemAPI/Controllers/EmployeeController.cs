using Microsoft.AspNetCore.Mvc;
using PayrolSystemAPI.Abstractions;
using PayrolSystemAPI.Data;
using PayrolSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PayrolSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        ApplicationDbContext context;
        ILogger logger;
        public EmployeeController(ApplicationDbContext _context, ILogger _logger) {
            context = _context;
            logger = _logger;
        }

        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            var records = new List<Employee>();
            try
            {
                records = await context.Employees.ToListAsync();
                return records;
            }
            catch (Exception ex) {
                logger.CreateLog(ex.Message);
            }
            return records;
        }
    }
}
