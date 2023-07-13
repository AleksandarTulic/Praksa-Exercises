using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleMapper.Models;
using SampleMapper.Models.DTOs.Incoming;
using SampleMapper.Models.DTOs.Outgoing;

namespace SampleMapper.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private static List<Driver> drivers = new List<Driver>();

    private readonly ILogger<DriversController> _logger;

    private readonly IMapper _mapper;

    public DriversController(
        ILogger<DriversController> logger,
        IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetDrivers()
    {
        var items = drivers.Where(x => x.Status == 1).ToList();

        var driverList = _mapper.Map<IEnumerable<DriverDto>>(items);
        return Ok(driverList);
    }

    [HttpPost]
    public IActionResult CreateDriver(DriverCreationDto data)
    {
        /*
        ModelState.IsValid indicates if it was possible to bind the incoming values from the 
        request to the model correctly and whether any explicitly specified validation rules 
        were broken during the model binding process
        */
        var _driver = _mapper.Map<Driver>(data);

        if(ModelState.IsValid)
        {
            drivers.Add(_driver);

            return CreatedAtAction("GetDriver", new {_driver.Id}, data);
        }

        return new JsonResult("Something went wrong") {StatusCode = 500};
    }

    [HttpGet("{id}")]
    public IActionResult GetDriver(Guid id)
    {
        var item = drivers.FirstOrDefault(x => x.Id == id);

        if(item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDriver(Guid id, Driver item)
    {
        if(id != item.Id)
            return BadRequest();

        var existItem = drivers.FirstOrDefault(x => x.Id == id);

        if(existItem == null)
            return NotFound();

        existItem.FirstName = item.FirstName;
        existItem.LastName = item.LastName;
        existItem.DriverNumber = item.DriverNumber;
        existItem.WorldChampionships = item.WorldChampionships;


        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDriver(Guid id)
    {
        var existItem = drivers.FirstOrDefault(x => x.Id == id);

        if(existItem == null)
            return NotFound();

        existItem.Status = 0;

        return Ok(existItem);
    }
}