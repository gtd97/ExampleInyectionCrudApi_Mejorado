using System;
using System.Collections.Generic;
using System.Text;

namespace Student.DataAccess.Dao.Integration.Tests.Utils
{
    public interface IoCSupportedTest<TModule> where TModule : IModule, new()
    {
        private IContainer container;

        public IoCSupportedTest()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new TModule());

            container = builder.Build();
        }

        protected TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            container.Dispose();
        }
    }
}
