using Autofac;
using Autofac.Integration.WebApi;
using Student.Business.Logi.BusinessLogic;
using Student.Business.Logi.Modules;
using Student.Business.Logic.Contracts;
using Student.Common.Logic.Log4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Student.Business.Facade.Modules
{
    public class StudentApiModule: Autofac.Module
    {
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // .InstancePerDependency -> funciona para cualquier protocolo, dll o http..
            // .InstancePerRequest() -> solo se podra instanciar por HTTP, si ha de ser por http se tendra que hacer su propio modulo

            builder
                .RegisterType<StudentBL>()
                .As<IBusiness>()
                .InstancePerDependency();

           
            builder
                .RegisterGeneric(typeof(FacturaBl<>))
                .As(typeof(IBusinessGeneric<>))
                .AsSelf()
                .InstancePerDependency();
            

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerDependency();


            // Cada module, se encarga de inyectar las clases de su capa
            builder.RegisterModule(new BusinessLogicModule());

            base.Load(builder);
        }
    }
}