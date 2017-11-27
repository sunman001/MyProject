using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Owin;


namespace MyReflection
{
    public class Startup
    {
        public void Configruation(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
           // builder.RegisterType<>().As<>();
          
        }
    }
}