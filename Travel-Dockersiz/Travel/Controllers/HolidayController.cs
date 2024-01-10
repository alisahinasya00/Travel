using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel.Business.Abstract;
using Travel.Business.DTOs.Holiday;

namespace Travel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HolidayController : ControllerBase
	{
		private IHolidayService _service { get; set; }
		public HolidayController(IHolidayService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(string? location_city, DateTime startDate, int duration)
		{
			if (location_city != null || !startDate.Equals(DateTime.MinValue) || duration != 0)
			{
				return Ok(await _service.GetHolidaysByFilter(location_city, startDate, duration));
			}

			return Ok(await _service.GetHolidaysAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetHolidayById(int id)
		{
			var holiday = await _service.GetHolidayByIdAsync(id);
			if (holiday != null)
			{
				return Ok(holiday);//200 + data
			}
			return BadRequest(); //400
		}

		[HttpPost]
		public async Task<IActionResult> Post(CreateHolidayDTO holiday)
		{
			if (holiday.Location > 0)
			{
				var createdHoliday = await _service.CreateHolidayAsync(holiday);
				return Ok(createdHoliday); //200 + data
			}
			return BadRequest();

		}

		[HttpPut]
		public async Task<IActionResult> Put(UpdateHolidayDTO holiday)
		{
			return Ok(await _service.UpdateHolidayAsync(holiday));//200 + data
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (await _service.GetHolidayByIdAsync(id) != null)
			{
				await _service.DeleteHolidayAsync(id);
				return Ok();//200 + data
			}
			return BadRequest();//400
		}
	}
}
