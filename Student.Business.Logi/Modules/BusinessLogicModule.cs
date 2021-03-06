﻿using Autofac;
using Student.Common.Logic.Log4Net;
//using Student.DataAccess.Dao;
using Student.DataAccess.Dao.Contracts;
using Student.DataAccess.Dao.Modules;
using Student.DataAccess.Dao.Repository.StoreProcedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Logi.Modules
{
    public class BusinessLogicModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<RepositoryStoreProcedureStudent>()
                .As<IRepository>()
                .InstancePerDependency();

            /*
            builder
                .RegisterType<RepositoryStudent>()
                .As<IRepository>()
                .InstancePerDependency();
            */

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerDependency();


            // Cada module, se encarga de inyectar las clases de su capa
            builder.RegisterModule(new DataAccessDaoModule());

            base.Load(builder);
        }
    }
}
