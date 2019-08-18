using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arquitectura.Api.Opciones
{
    public class SwaggerConfig
    {
        public string JsonRoute { get; set; } //= "/swagger/v1/swagger.json";
        public string Descripcion { get; set; } //= "test v1";
        public string UiEndpoint { get; set; }// = "http://localhost:51627/api";
        public string Version { get; set; } //= "v";
    }
}
