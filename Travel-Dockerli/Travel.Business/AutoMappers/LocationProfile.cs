using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Business.DTOs.Location;
using Travel.Entities.Entities;

namespace Travel.Business.AutoMappers
{
	public class LocationProfile: Profile
	{
		public LocationProfile()
		{
			CreateMap<Location, ResponseLocationDTO>();
			CreateMap<ResponseLocationDTO, Location>();

			CreateMap<Location, CreateLocationDTO>();
			CreateMap<CreateLocationDTO, Location>();

			CreateMap<Location, UpdateLocationDTO>();
			CreateMap<UpdateLocationDTO, Location>();

			CreateMap<ResponseLocationDTO, CreateLocationDTO>();
			CreateMap<CreateLocationDTO, ResponseLocationDTO>();

			CreateMap<UpdateLocationDTO, ResponseLocationDTO>();
			CreateMap<ResponseLocationDTO, UpdateLocationDTO>();

		}
	}
}
