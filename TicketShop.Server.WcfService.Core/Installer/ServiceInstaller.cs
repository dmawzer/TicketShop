using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Domain.Model;
using TicketShop.Core.Messages.Executer;
using TicketShop.Core.Messages.Request;
using TicketShop.Core.Messages.Response;
using TicketShop.Server.MessageHandler;
using TicketShop.Server.Service;
using TicketShop.Server.Service.Core;

namespace TicketShop.Server.WcfService.Core.Installer
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IGenericService<City>>()
                .ImplementedBy<GenericService<City>>()
                .Named("GenericCityService"),

                Component.For<IGenericService<Country>>()
                .ImplementedBy<GenericService<Country>>()
                .Named("GenericCountryService"),

                Component.For<IGenericService<County>>()
                .ImplementedBy<GenericService<County>>()
                .Named("GenericCountyService"),

                Component.For<IGenericService<Driver>>()
                .ImplementedBy<GenericService<Driver>>()
                .Named("GenericDriverService"),

                Component.For<IGenericService<Journey>>()
                .ImplementedBy<GenericService<Journey>>()
                .Named("GenericJourneyService"),

                Component.For<IGenericService<JourneyAddress>>()
                .ImplementedBy<GenericService<JourneyAddress>>()
                .Named("GenericJourneyAddressService"),

                Component.For<IGenericService<Passenger>>()
                .ImplementedBy<GenericService<Passenger>>()
                .Named("GenericPassengerService"),

                Component.For<IGenericService<Ticket>>()
                .ImplementedBy<GenericService<Ticket>>()
                .Named("GenericTicketService"),

                Component.For<IGenericService<Vehicle>>()
                .ImplementedBy<GenericService<Vehicle>>()
                .Named("GenericVehicleService"));


            container.Register(
                Component.For<IGenericMessageHandler<GetModelByIdRequest, GenericResponse<City>>>()
                    .ImplementedBy<GenericGetModelByIdMessageHandler<City>>()
                    .Named("CityGetByIdMessageHandler"),

                    Component.For<IGenericMessageHandler<GetModelByIdRequest, GenericResponse<Country>>>()
                    .ImplementedBy<GenericGetModelByIdMessageHandler<Country>>()
                    .Named("CountryGetByIdMessageHandler"),

                    Component.For<IGenericMessageHandler<GetModelByIdRequest, GenericResponse<County>>>()
                    .ImplementedBy<GenericGetModelByIdMessageHandler<County>>()
                    .Named("CountyGetByIdMessageHandler"),

                    Component.For<IGenericMessageHandler<GetModelByIdRequest, GenericResponse<Driver>>>()
                    .ImplementedBy<GenericGetModelByIdMessageHandler<Driver>>()
                    .Named("DriverGetByIdMessageHandler"),

                    Component.For<IGenericMessageHandler<GetModelByIdRequest, GenericResponse<Journey>>>()
                    .ImplementedBy<GenericGetModelByIdMessageHandler<Journey>>()
                    .Named("JourneyGetByIdMessageHandler"),

                    Component.For<IGenericMessageHandler<GetModelByIdRequest, GenericResponse<JourneyAddress>>>()
                    .ImplementedBy<GenericGetModelByIdMessageHandler<JourneyAddress>>()
                    .Named("JourneyAddressGetByIdMessageHandler"),

                    Component.For<IGenericMessageHandler<GetModelByIdRequest, GenericResponse<Passenger>>>()
                    .ImplementedBy<GenericGetModelByIdMessageHandler<Passenger>>()
                    .Named("PassengerGetByIdMessageHandler"),

                 Component.For<IGenericMessageHandler<GetModelByIdRequest, GenericResponse<Ticket>>>()
                    .ImplementedBy<GenericGetModelByIdMessageHandler<Ticket>>()
                    .Named("TicketGetByIdMessageHandler"),

                 Component.For<IGenericMessageHandler<GetModelByIdRequest, GenericResponse<Vehicle>>>()
                    .ImplementedBy<GenericGetModelByIdMessageHandler<Vehicle>>()
                    .Named("VehicleGetByIdMessageHandler"),



                Component.For<IGenericMessageHandler<GenericSaveRequest<City>, GenericResponse<City>>>()
                    .ImplementedBy<GenericSaveMessageHandler<City>>()
                    .Named("CitySaveMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericSaveRequest<Country>, GenericResponse<Country>>>()
                    .ImplementedBy<GenericSaveMessageHandler<Country>>()
                    .Named("CountrySaveMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericSaveRequest<County>, GenericResponse<County>>>()
                    .ImplementedBy<GenericSaveMessageHandler<County>>()
                    .Named("CountySaveMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericSaveRequest<Driver>, GenericResponse<Driver>>>()
                    .ImplementedBy<GenericSaveMessageHandler<Driver>>()
                    .Named("DriverSaveMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericSaveRequest<Journey>, GenericResponse<Journey>>>()
                    .ImplementedBy<GenericSaveMessageHandler<Journey>>()
                    .Named("JourneySaveMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericSaveRequest<JourneyAddress>, GenericResponse<JourneyAddress>>>()
                    .ImplementedBy<GenericSaveMessageHandler<JourneyAddress>>()
                    .Named("JourneyAddressSaveMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericSaveRequest<Passenger>, GenericResponse<Passenger>>>()
                    .ImplementedBy<GenericSaveMessageHandler<Passenger>>()
                    .Named("PassengerSaveMessageHandler"),

                 Component.For<IGenericMessageHandler<GenericSaveRequest<Ticket>, GenericResponse<Ticket>>>()
                    .ImplementedBy<GenericSaveMessageHandler<Ticket>>()
                    .Named("TicketSaveMessageHandler"),

                 Component.For<IGenericMessageHandler<GenericSaveRequest<Vehicle>, GenericResponse<Vehicle>>>()
                    .ImplementedBy<GenericSaveMessageHandler<Vehicle>>()
                    .Named("VehicleSaveMessageHandler"),



                Component.For<IGenericMessageHandler<GenericDeleteRequest<City>, GenericResponse<City>>>()
                    .ImplementedBy<GenericDeleteMessageHandler<City>>()
                    .Named("CityDeleteMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericDeleteRequest<Country>, GenericResponse<Country>>>()
                    .ImplementedBy<GenericDeleteMessageHandler<Country>>()
                    .Named("CountryDeleteMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericDeleteRequest<County>, GenericResponse<County>>>()
                    .ImplementedBy<GenericDeleteMessageHandler<County>>()
                    .Named("CountyDeleteMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericDeleteRequest<Driver>, GenericResponse<Driver>>>()
                    .ImplementedBy<GenericDeleteMessageHandler<Driver>>()
                    .Named("DriverDeleteMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericDeleteRequest<Journey>, GenericResponse<Journey>>>()
                    .ImplementedBy<GenericDeleteMessageHandler<Journey>>()
                    .Named("JourneyDeleteMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericDeleteRequest<JourneyAddress>, GenericResponse<JourneyAddress>>>()
                    .ImplementedBy<GenericDeleteMessageHandler<JourneyAddress>>()
                    .Named("JourneyAddressDeleteMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericDeleteRequest<Passenger>, GenericResponse<Passenger>>>()
                    .ImplementedBy<GenericDeleteMessageHandler<Passenger>>()
                    .Named("PassengerDeleteMessageHandler"),

                 Component.For<IGenericMessageHandler<GenericDeleteRequest<Ticket>, GenericResponse<Ticket>>>()
                    .ImplementedBy<GenericDeleteMessageHandler<Ticket>>()
                    .Named("TicketDeleteMessageHandler"),

                 Component.For<IGenericMessageHandler<GenericDeleteRequest<Vehicle>, GenericResponse<Vehicle>>>()
                    .ImplementedBy<GenericDeleteMessageHandler<Vehicle>>()
                    .Named("VehicleDeleteMessageHandler"),



                Component.For<IGenericMessageHandler<GenericListRequest<City>, GenericResponse<IList<City>>>>()
                    .ImplementedBy<GenericListMessageHandler<City>>()
                    .Named("CityListMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericListRequest<Country>, GenericResponse<IList<Country>>>>()
                   .ImplementedBy<GenericListMessageHandler<Country>>()
                   .Named("CountryListMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericListRequest<County>, GenericResponse<IList<County>>>>()
                   .ImplementedBy<GenericListMessageHandler<County>>()
                   .Named("CountyListMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericListRequest<Driver>, GenericResponse<IList<Driver>>>>()
                   .ImplementedBy<GenericListMessageHandler<Driver>>()
                   .Named("DriverListMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericListRequest<Journey>, GenericResponse<IList<Journey>>>>()
                   .ImplementedBy<GenericListMessageHandler<Journey>>()
                   .Named("JourneyListMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericListRequest<JourneyAddress>, GenericResponse<IList<JourneyAddress>>>>()
                   .ImplementedBy<GenericListMessageHandler<JourneyAddress>>()
                   .Named("JourneyAddressListMessageHandler"),

                    Component.For<IGenericMessageHandler<GenericListRequest<Passenger>, GenericResponse<IList<Passenger>>>>()
                   .ImplementedBy<GenericListMessageHandler<Passenger>>()
                   .Named("PassengerListMessageHandler"),

                 Component.For<IGenericMessageHandler<GenericListRequest<Ticket>, GenericResponse<IList<Ticket>>>>()
                   .ImplementedBy<GenericListMessageHandler<Ticket>>()
                   .Named("TicketListMessageHandler"),

                 Component.For<IGenericMessageHandler<GenericListRequest<Vehicle>, GenericResponse<IList<Vehicle>>>>()
                   .ImplementedBy<GenericListMessageHandler<Vehicle>>()
                   .Named("VehicleListMessageHandler")
                     );

            container.Register(
                Component.For<IMessageHandlerSelector>()
                .ImplementedBy<DefaultMessageHandlerSelector>()
                .DependsOn(Dependency.OnValue("windsorContainer", container))
                .Named("DefaultMessageHandlerSelector"),

            Component.For<IMessageExecuter>()
                         .ImplementedBy<DefaultMessageExecuter>()
                         .Named("DefaultMessageExecuter"),

                Component.For<IMessageExecuter>()
                    .ImplementedBy<MessageExecuter>()
                    .Named("MessageExecuter")
                    .DependsOn(Dependency.OnComponent("messageExecuter", "DefaultMessageExecuter"))
                );
        }
    }
}
