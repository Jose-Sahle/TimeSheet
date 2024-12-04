using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SHL.IRetorno.Model;
using SHL.ITimeSheetNG.Model;
using SHL.Syncronism.Model;
using SHL.TimeSheet.Model;
using SHL.Utils;

namespace SHL.TimeSheetNG.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SyncronismNGController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokensecurity"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Sendto/")]
        public List<RETORNO> Sendto(String tokensecurity, [FromBody] List<SYNCRONISM> entities)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();
            
            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG 
                retornos =  (List<RETORNO>)Util.ControllerPostT<List<RETORNO>>(grupo, Util.BuscarValorPropriedade("URLS", "Syncronism"), "Syncronism", "Sendto", entities);
                #else
                if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    retornos =  (List<RETORNO>)Util.ControllerPostT<List<RETORNO>>(grupo, Util.BuscarValorPropriedade("URLS", "Syncronism"), "Syncronism", "Sendto", entities);
                #endif

            }
            catch (Exception e)
            {
                RETORNO retorno = new RETORNO();
                retorno.status = "1";
                retorno.mensagem = "Falha ao processar a consulta de registros";
                retorno.trace = e.Message;
                retorno.dt_retorno = DateTime.Now;
                
                if(retornos == null)
                    retornos = new List<RETORNO>();

                retornos.Add(retorno);
            }

            return retornos;
        }
    }
}
