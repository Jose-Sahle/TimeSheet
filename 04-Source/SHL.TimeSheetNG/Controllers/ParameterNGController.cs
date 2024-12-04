using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SHL.IRetorno.Model;
using SHL.ITimeSheetNG.Model;
using SHL.Syncronism.Model;
using SHL.Utils;

namespace SHL.TimeSheetNG.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterNGController : ControllerBase
    {
        /// <summary>
        /// Selects all.
        /// </summary>
        /// <returns>The all.</returns>
        [HttpGet]
        [Route("SelectAll/")]
        public PARAMETERNG SelectAll(String tokensecurity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            PARAMETERNG response = new PARAMETERNG();
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                response.records = (List<PARAMETER>)Util.ControllerSelect<List<PARAMETER>>(grupo, Util.BuscarValorPropriedade("URLS", "Parameter"), "Parameter", "SelectAll");
                #else
                if (!Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    response.errors = retornos;
                else
                    response.records = (List<PARAMETER>)Util.ControllerSelect<List<PARAMETER>>(grupo, Util.BuscarValorPropriedade("URLS", "Parameter"), "Parameter", "SelectAll");
                #endif
            }
            catch (Exception e)
            {
                RETORNO retorno = new RETORNO();
                retorno.status = "1";
                retorno.mensagem = "Falha ao processar a consulta de registros";
                retorno.trace = e.Message;
                retorno.dt_retorno = DateTime.Now;

                if (response.errors == null)
                    response.errors = new List<RETORNO>();

                response.errors.Add(retorno);
            }

            return response;
        }

        /// <summary>
        /// Select the specified entity.
        /// </summary>
        /// <param name="tokensecurity"></param>
        /// <param name="entity"></param>
        /// <returns>The select.</returns>
        [HttpPost]
        [Route("Select/")]
        public PARAMETERNG Select(String tokensecurity, [FromBody] PARAMETER entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            PARAMETERNG response = new PARAMETERNG();
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                response.records =  (List<PARAMETER>)Util.ControllerPostT<List<PARAMETER>>(grupo, Util.BuscarValorPropriedade("URLS", "Parameter"), "Parameter", "Select", entity);
                #else
                if (!Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    response.errors = retornos;
                else
                    response.records = (List<PARAMETER>)Util.ControllerPostT<List<PARAMETER>>(grupo, Util.BuscarValorPropriedade("URLS", "Parameter"), "Parameter", "Select", entity);
                #endif

            }
            catch (Exception e)
            {
                RETORNO retorno = new RETORNO();
                retorno.status = "1";
                retorno.mensagem = "Falha ao processar a consulta de registros";
                retorno.trace = e.Message;
                retorno.dt_retorno = DateTime.Now;

                if (response.errors == null)
                    response.errors = new List<RETORNO>();

                response.errors.Add(retorno);
            }

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokensecurity"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Insert/")]
        public List<RETORNO> Insert(String tokensecurity, [FromBody] PARAMETER entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                    retornos = (List<RETORNO>)Util.ControllerPost(grupo, Util.BuscarValorPropriedade("URLS", "Parameter"), "Parameter", "Insert", entity);
                #else
                if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    retornos = (List<RETORNO>)Util.ControllerPost(grupo, Util.BuscarValorPropriedade("URLS", "Parameter"), "Parameter", "Insert", entity);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokensecurity"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update/")]
        public List<RETORNO> Update(String tokensecurity, [FromBody] PARAMETER entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                retornos = (List<RETORNO>)Util.ControllerPut(grupo, Util.BuscarValorPropriedade("URLS", "Parameter"), "Parameter", "Update", entity);
                #else
                if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    retornos = (List<RETORNO>)Util.ControllerPut(grupo, Util.BuscarValorPropriedade("URLS", "Parameter"), "Parameter", "Update", entity);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokensecurity"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/")]
        public List<RETORNO> Delete(String tokensecurity, [FromBody] PARAMETER entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                retornos = (List<RETORNO>)Util.ControllerDelete(grupo, Util.BuscarValorPropriedade("URLS", "Parameter"), "Parameter", "Delete", entity);
                #else
                if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    retornos = (List<RETORNO>)Util.ControllerDelete(grupo, Util.BuscarValorPropriedade("URLS", "Parameter"), "Parameter", "Delete", entity);
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
