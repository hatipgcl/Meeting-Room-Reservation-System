
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RoomManager>().As<IRoomService>().SingleInstance();
            builder.RegisterType<EfRoomDal>().As<IRoomDal>().SingleInstance();

            builder.RegisterType<LocationManager>().As<ILocationService>().SingleInstance();
            builder.RegisterType<EfLocationDal>().As<ILocationDal>().SingleInstance();

            builder.RegisterType<EquipmentManager>().As<IEquipmentService>().SingleInstance();
            builder.RegisterType<EfEquipmentDal>().As<IEquipmentDal>().SingleInstance();

            builder.RegisterType<GenderManager>().As<IGenderService>().SingleInstance();
            builder.RegisterType<EfGenderDal>().As<IGenderDal>().SingleInstance();

            builder.RegisterType<LocationToRoomManager>().As<ILocationToRoomsService>().SingleInstance();
            builder.RegisterType<EfLocationToRoomDal>().As<ILocationToRoomDal>().SingleInstance();
           
            builder.RegisterType<StafftitleManager>().As<IStafftitleService>().SingleInstance();
            builder.RegisterType<EfStafftitleDal>().As<IStafftitleDal>().SingleInstance();


            builder.RegisterType<MeetingRequestManager>().As<IMeetingRequestService>().SingleInstance();
            builder.RegisterType<EfMeetingRequest>().As<IMeetingRequestDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
