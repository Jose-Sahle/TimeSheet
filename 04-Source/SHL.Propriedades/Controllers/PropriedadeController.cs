using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SHL.Propriedades.Controllers
{
    /// <summary>
    /// Propriedade controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PropriedadeController : ControllerBase
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns>The connection string.</returns>
        /// <param name="grupo">Grupo.</param>
        /// <param name="propriedade">Propriedade.</param>
        [HttpGet("{grupo}, {propriedade}")]
        public ActionResult<string> GetConnectionString(String grupo, String propriedade)
        {
            return PropertyReader.GetProperty(grupo, propriedade);
        }
    }
}
