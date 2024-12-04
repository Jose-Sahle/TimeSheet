using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SHL.IRetorno.Model;
using SHL.ITimeSheetNG.Model;
using SHL.Task.Model;
using SHL.Utils;

namespace SHL.TimeSheetNG.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskNGController : ControllerBase
    {
        /// <summary>
        /// Selects all.
        /// </summary>
        /// <returns>The all.</returns>
        [HttpGet]
        [Route("SelectAll/")]
        public TASKNG SelectAll(String tokensecurity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            TASKNG response = new TASKNG();
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                response.records = (List<TASK>)Util.ControllerSelect<List<TASK>>(grupo, Util.BuscarValorPropriedade("URLS", "Task"), "Task", "SelectAll");
                #else
                if (!Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    response.errors = retornos;
                else
                    response.records = (List<TASK>)Util.ControllerSelect<List<TASK>>(grupo, Util.BuscarValorPropriedade("URLS", "Task"), "Task", "SelectAll");
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
        /// <returns>The select.</returns>
        /// <param name="entity">Entity.</param>
        [HttpPost]
        [Route("Select/")]
        public TASKNG Select(String tokensecurity, [FromBody] TASK entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            TASKNG response = new TASKNG();
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                response.records =  (List<TASK>)Util.ControllerPostT<List<TASK>>(grupo, Util.BuscarValorPropriedade("URLS", "Task"), "Task", "Select", entity);
                #else
                if (!Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    response.errors = retornos;
                else
                    response.records = (List<TASK>)Util.ControllerPostT<List<TASK>>(grupo, Util.BuscarValorPropriedade("URLS", "Task"), "Task", "Select", entity);
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
        public List<RETORNO> Insert(String tokensecurity, [FromBody] TASK entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                retornos = (List<RETORNO>)Util.ControllerPost(grupo, Util.BuscarValorPropriedade("URLS", "Task"), "Task", "Insert", entity);
                #else
                if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    retornos = (List<RETORNO>)Util.ControllerPost(grupo, Util.BuscarValorPropriedade("URLS", "Task"), "Task", "Insert", entity);
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
        public List<RETORNO> Update(String tokensecurity, [FromBody] TASK entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                retornos = (List<RETORNO>)Util.ControllerPut(grupo, Util.BuscarValorPropriedade("URLS", "Task"), "Task", "Update", entity);
                #else
                if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    retornos = (List<RETORNO>)Util.ControllerPut(grupo, Util.BuscarValorPropriedade("URLS", "Task"), "Task", "Update", entity);
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
        public List<RETORNO> Delete(String tokensecurity, [FromBody] TASK entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                retornos = (List<RETORNO>)Util.ControllerDelete(grupo, Util.BuscarValorPropriedade("URLS", "Task"), "Task", "Delete", entity);
                #else
                if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    retornos = (List<RETORNO>)Util.ControllerDelete(grupo, Util.BuscarValorPropriedade("URLS", "Task"), "Task", "Delete", entity);
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
