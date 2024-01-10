using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Business.DTOs.Location;

namespace Travel.Business.Abstract
{
	public interface ILocationService
	{
		Task<ResponseLocationDTO> CreateLocationAsync(CreateLocationDTO locationDto);
		Task<bool> DeleteLocationAsync(long locationId);
		Task<IEnumerable<ResponseLocationDTO>> GetLocationsAsync();
		Task<ResponseLocationDTO> GetLocationByIdAsync(long locationId);
		Task<ResponseLocationDTO> UpdateLocationAsync(UpdateLocationDTO locationDto);
	}
}
