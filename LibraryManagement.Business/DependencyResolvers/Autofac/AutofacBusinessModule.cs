using Autofac;
using Autofac.Extras.DynamicProxy;
using LibraryManagement.Business.Abstract;
using LibraryManagement.Business.CCS;
using LibraryManagement.Business;
using Castle.DynamicProxy;
using LibraryManagement.Core.Utilities.Interceptors;
using LibraryManagement.Core.Utilities.Security.JWT;
using LibraryManagement.DataAccess.Abstract;
using LibraryManagement.DataAccess.Concrete.EfCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Business.Concrete;

namespace LibraryManagement.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();
            builder.RegisterType<EfBookDal>().As<IBookDal>().SingleInstance();

           

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