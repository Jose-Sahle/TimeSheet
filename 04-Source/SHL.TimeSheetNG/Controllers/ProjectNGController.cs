using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SHL.IRetorno.Model;
using SHL.ITimeSheetNG.Model;
using SHL.Project.Model;
using SHL.Utils;

namespace SHL.TimeSheetNG.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectNGController : ControllerBase
    {
        /// <summary>
        /// Selects all.
        /// </summary>
        /// <returns>The all.</returns>
        [HttpGet]
        [Route("SelectAll/")]
        public PROJECTNG SelectAll(String tokensecurity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            PROJECTNG response = new PROJECTNG();
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                response.records = (List<PROJECT>)Util.ControllerSelect<List<PROJECT>>(grupo, Util.BuscarValorPropriedade("URLS", "Project"), "Project", "SelectAll");
                #else
                if (!Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    response.errors = retornos;
                else
                    response.records = (List<PROJECT>)Util.ControllerSelect<List<PROJECT>>(grupo, Util.BuscarValorPropriedade("URLS", "Project"), "Project", "SelectAll");
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
        public PROJECTNG Select(String tokensecurity, [FromBody] PROJECT entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            PROJECTNG response = new PROJECTNG();
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                response.records =  (List<PROJECT>)Util.ControllerPostT<List<PROJECT>>(grupo, Util.BuscarValorPropriedade("URLS", "Project"), "Project", "Select", entity);
                #else
                if (!Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    response.errors = retornos;
                else
                    response.records = (List<PROJECT>)Util.ControllerPostT<List<PROJECT>>(grupo, Util.BuscarValorPropriedade("URLS", "Project"), "Project", "Select", entity);
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
        public List<RETORNO> Insert(String tokensecurity, [FromBody] PROJECT entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                retornos = (List<RETORNO>)Util.ControllerPost(grupo, Util.BuscarValorPropriedade("URLS", "Project"), "Project", "Insert", entity);
                #else
                if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    retornos = (List<RETORNO>)Util.ControllerPost(grupo, Util.BuscarValorPropriedade("URLS", "Project"), "Project", "Insert", entity);
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
        public List<RETORNO> Update(String tokensecurity, [FromBody] PROJECT entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                retornos = (List<RETORNO>)Util.ControllerPut(grupo, Util.BuscarValorPropriedade("URLS", "Project"), "Project", "Update", entity);
                #else
                if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    retornos = (List<RETORNO>)Util.ControllerPut(grupo, Util.BuscarValorPropriedade("URLS", "Project"), "Project", "Update", entity);
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
        public List<RETORNO> Delete(String tokensecurity, [FromBody] PROJECT entity)
        {
            String url = String.Empty;
            String grupo = "SHL";
            List<RETORNO> retornos = new List<RETORNO>();

            try
            {
                url = HttpContext.Request.Path;

                #if DEBUG
                retornos = (List<RETORNO>)Util.ControllerDelete(grupo, Util.BuscarValorPropriedade("URLS", "Project"), "Project", "Delete", entity);
                #else
                if (Util.ValidateAccess(grupo, tokensecurity, url, ref retornos))
                    retornos = (List<RETORNO>)Util.ControllerDelete(grupo, Util.BuscarValorPropriedade("URLS", "Project"), "Project", "Delete", entity);
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
