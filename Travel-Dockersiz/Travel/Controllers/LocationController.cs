using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel.Business.Abstract;
using Travel.Business.DTOs.Location;

namespace Travel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationController : ControllerBase
	{
		private ILocationService _service { get; set; }
		public LocationController(ILocationService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var locations = await _service.GetLocationsAsync();
			return Ok(locations); //200 + data
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetLocationById(int id)
		{
			var location = await _service.GetLocationByIdAsync(id);
			if (location != null)
			{
				return Ok(location);//200 + data
			}
			return BadRequest(); //400
		}

		[HttpPost]
		public async Task<IActionResult> Post(CreateLocationDTO location)
		{
			var createdLocation = await _service.CreateLocationAsync(location);
			return Ok(createdLocation); //200 + data
		}
		[HttpPut]
		public async Task<IActionResult> Put(UpdateLocationDTO location)
		{
			return Ok(await _service.UpdateLocationAsync(location));//200 + data
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (await _service.GetLocationByIdAsync(id) != null)
			{
				await _service.DeleteLocationAsync(id);
				return Ok();//200 + data
			}
			return BadRequest();//400
		}
	}
}
