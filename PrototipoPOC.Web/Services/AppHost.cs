using PrototipoPOC.DAL;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace PrototipoPOC.Web
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("PessoaService", typeof(PessoaService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            //Set JSON web services to return idiomatic JSON camelCase properties
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            
            SetConfig(new EndpointHostConfig { ServiceStackHandlerFactoryPath = "api", DefaultContentType = ContentType.Json });
            Routes
             .Add<Pessoa>("/pessoas")
             .Add<Pessoa>("/pessoas/{Id}")
             .Add<Pessoa>("/pessoas/Nome/{Nome}"); 
        
        }
    }
}