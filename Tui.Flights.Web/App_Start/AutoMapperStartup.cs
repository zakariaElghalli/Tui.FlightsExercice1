using AutoMapper;
using Tui.BusinessEntities.Entities;
using Tui.Presentation.Models;

namespace Tui.Presentation
{
    public class AutoMapperStartup : Profile
    {
        public AutoMapperStartup()
        {
            CreateMap<AirPlaneViewModel, AirPlane>();
            CreateMap<AirPlane, AirPlaneViewModel>();
            CreateMap<Airport, AirPortViewModel>();
            CreateMap< AirPortViewModel, Airport>();
            CreateMap<Flight, FlightViewModel>();
            CreateMap< FlightViewModel, Flight>();
        }
    }
}