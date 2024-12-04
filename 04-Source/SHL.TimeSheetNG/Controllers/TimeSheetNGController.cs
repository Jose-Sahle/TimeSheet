using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SHL.IRetorno.Model;
using SHL.ITimeSheetNG.Model;
using SHL.TimeSheet.Model;
using SHL.Utils;

namespace SHL.TimeSheetNG.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetNGController : ControllerBase
    {
        /// <summary>
        /// Selects all.
        /// </summary>
        /// <returns>The all.</returns>
        [HttpGet]
        [Route("SelectAll/")]
        public TIMESHEETNG SelectAll(String tokensecurity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            TIMESHEETNG response = new TIMESHEETNG();
            List<RETORNO> retornos = new List<RETORNO>();
            
            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG 
                    response.records = (List<TIMESHEET>)Util.ControllerSelect<List<TIMESHEET>>(grupo, Util.BuscarValorPropriedade("URLS", "TimeSheet"), "TimeSheet", "SelectAll");
                #else
                    if (!Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                        response.errors = retornos;
                    else
                        response.records = (List<TIMESHEET>)Util.ControllerSelect<List<TIMESHEET>>(grupo, Util.BuscarValorPropriedade("URLS", "TimeSheet"), "TimeSheet", "SelectAll");
                #endif
                
                
            }
            catch (Exception e)
            {
                RETORNO retorno = new RETORNO();
                retorno.status = "1";
                retorno.mensagem = "Falha ao processar a consulta de registros";
                retorno.trace = e.Message;
                retorno.dt_retorno = DateTime.Now;
                
                if(response.errors == null)
                    response.errors = new List<RETORNO>();
                
                response.errors.Add(retorno);
            }

            return response;
        }

        /// <summary>
        /// Select the specified entity.
        /// </summary>
        /// <returns>The select.</returns>
        /// <param name="entity">Entity.</param>
        [HttpPost]
        [Route("Select/")]
        public TIMESHEETNG Select(String tokensecurity, [FromBody] TIMESHEET entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            TIMESHEETNG response = new TIMESHEETNG();
            List<RETORNO> retornos = new List<RETORNO>();
            
            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG 
                    response.records =  (List<TIMESHEET>)Util.ControllerPostT<List<TIMESHEET>>(grupo, Util.BuscarValorPropriedade("URLS", "TimeSheet"), "TimeSheet", "Select", entity);
                #else
                    if (!Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                        response.errors = retornos;
                    else
                        response.records =  (List<TIMESHEET>)Util.ControllerPostT<List<TIMESHEET>>(grupo, Util.BuscarValorPropriedade("URLS", "TimeSheet"), "TimeSheet", "Select", entity);
                #endif
                
            }
            catch (Exception e)
            {
                RETORNO retorno = new RETORNO();
                retorno.status = "1";
                retorno.mensagem = "Falha ao processar a consulta de registros";
                retorno.trace = e.Message;
                retorno.dt_retorno = DateTime.Now;
                
                if(response.errors == null)
                    response.errors = new List<RETORNO>();
                
                response.errors.Add(retorno);
            }

            return response;
        }


        [HttpPost]
        [Route("Insert/")]
        public List<RETORNO> Insert(String tokensecurity, [FromBody] TIMESHEET entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();
            
            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG 
                    retornos = (List<RETORNO>)Util.ControllerPost(grupo, Util.BuscarValorPropriedade("URLS", "TimeSheet"), "TimeSheet", "Insert", entity);
                #else
                    if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                        retornos = (List<RETORNO>)Util.ControllerPost(grupo, Util.BuscarValorPropriedade("URLS", "TimeSheet"), "TimeSheet", "Insert", entity);
                #endif
            }
            catch (Exception ex)
            {
                RETORNO retorno = new RETORNO();
                retorno.dt_retorno = DateTime.Now;
                retorno.mensagem = "Insert - falhou";
                retorno.status = "-1";
                retorno.trace = ex.Message;
                retorno.transacao = String.Empty;
                retornos.Add(retorno);
            }

            return retornos;
        }

        [HttpPut]
        [Route("Update/")]
        public List<RETORNO> Update(String tokensecurity, [FromBody] TIMESHEET entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();
            
            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG 
                    retornos = (List<RETORNO>)Util.ControllerPut(grupo, Util.BuscarValorPropriedade("URLS", "TimeSheet"), "TimeSheet", "Update", entity);
                #else
                    if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                        retornos = (List<RETORNO>)Util.ControllerPut(grupo, Util.BuscarValorPropriedade("URLS", "TimeSheet"), "TimeSheet", "Update", entity);
                #endif
            }
            catch (Exception ex)
            {
                RETORNO retorno = new RETORNO();
                retorno.dt_retorno = DateTime.Now;
                retorno.mensagem = "Update - falhou";
                retorno.status = "-1";
                retorno.trace = ex.Message;
                retorno.transacao = String.Empty;
                retornos.Add(retorno);
            }

            return retornos;
        }

        [HttpDelete]
        [Route("Delete/")]
        public List<RETORNO> Delete(String tokensecurity, [FromBody] TIMESHEET entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();
            
            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG 
                    retornos = (List<RETORNO>)Util.ControllerDelete(grupo, Util.BuscarValorPropriedade("URLS", "TimeSheet"), "TimeSheet", "Delete", entity);
                #else
                    if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                        retornos = (List<RETORNO>)Util.ControllerDelete(grupo, Util.BuscarValorPropriedade("URLS", "TimeSheet"), "TimeSheet", "Delete", entity);
                #endif
            }
            catch (Exception ex)
            {
                RETORNO retorno = new RETORNO();
                retorno.dt_retorno = DateTime.Now;
                retorno.mensagem = "Update - falhou";
                retorno.status = "-1";
                retorno.trace = ex.Message;
                retorno.transacao = String.Empty;
                retornos.Add(retorno);
            }

            return retornos;
        }
    }
}
