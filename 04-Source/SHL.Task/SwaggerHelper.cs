using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SHL.Task
{
    /// <summary>
    /// Swagger helper.
    /// </summary>
    public class SwaggerHelper
    {
        /// <summary>
        /// Configures the swagger gen.
        /// </summary>
        /// <param name="swaggerGenOptions">Swagger gen options.</param>
        public static void ConfigureSwaggerGen(SwaggerGenOptions swaggerGenOptions)
        {
            swaggerGenOptions.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
            {
                #if DEBUG
                Title = "TimeSheet - HTTP API (Debug)",
                #else
                Title = "TimeSheet - HTTP API",
                #endif
                Version = "v1",
                Description = "TimeSheet' Microservice HTTP API",
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            swaggerGenOptions.IncludeXmlComments(xmlPath);

            /*xmlPath = Path.Combine(AppContext.BaseDirectory, "SHL.IRetorno.xml");
            swaggerGenOptions.IncludeXmlComments(xmlPath);*/
        }

        /// <summary>
        /// Configures the swagger.
        /// </summary>
        /// <param name="swaggerOptions">Swagger options.</param>
        public static void ConfigureSwagger(SwaggerOptions swaggerOptions)
        {
            swaggerOptions.RouteTemplate = "api-docs/{documentName}/swagger.json";
        }

        /// <summary>
        /// Configures the swagger user interface.
        /// </summary>
        /// <param name="swaggerUIOptions">Swagger UIO ptions.</param>
        public static void ConfigureSwaggerUI(SwaggerUIOptions swaggerUIOptions)
        {
            swaggerUIOptions.RoutePrefix = "api-docs";
            swaggerUIOptions.SwaggerEndpoint("../swagger/v1/swagger.json", "V1 Docs");

        }
    }
}
