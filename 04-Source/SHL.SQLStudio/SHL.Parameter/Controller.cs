/**********************************************************
  AUTHOR	: #AUTHOR#
  VERSION	: #VERSION#
  DATE		: #DATETIME#
**********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

using SHL.Types;
using SHL.IRetorno.Model;
using #NAMESPACEBLL#;
using #NAMESPACEENTITY#;

using System.Data.SqlClient;

namespace Controllers
{ 
	[Route("api/[controller]")]
	[ApiController]
	public class  <firstupper>#TABLE#</firstupper>Controller : ControllerBase
	{
		//SHLSTUDIO_USER_AREA_START_1
		//SHLSTUDIO_USER_AREA_END_1

		/// <summary>
		/// 
		/// </summary>
		/// <param name="grupo"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("SelectAll/")]
		public List<#TABLEWITHOUTPREFIXTABLE#> SelectAll(String grupo)
		{
			#TABLEWITHOUTPREFIXTABLE##SUFFIXBLL# bl = new #TABLEWITHOUTPREFIXTABLE##SUFFIXBLL#();
			#TABLEWITHOUTPREFIXTABLE# entity = new #TABLEWITHOUTPREFIXTABLE#();

			return bl.SelectList(grupo, entity);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="grupo"></param>
		/// <param name="entity"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("Select/")]
		public List<#TABLEWITHOUTPREFIXTABLE#> Select(String grupo, [FromBody] #TABLEWITHOUTPREFIXTABLE# entity)
		{
			#TABLEWITHOUTPREFIXTABLE##SUFFIXBLL# bl = new #TABLEWITHOUTPREFIXTABLE##SUFFIXBLL#();

			return bl.SelectList(grupo, entity);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="grupo"></param>
		/// <param name="entity"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("Insert/")]
		public List<RETORNO> Insert(String grupo, [FromBody] #TABLEWITHOUTPREFIXTABLE# entity)
		{
			#TABLEWITHOUTPREFIXTABLE##SUFFIXBLL# bl = new #TABLEWITHOUTPREFIXTABLE##SUFFIXBLL#();
			List<RETORNO> retornos = new List<RETORNO>();

			try
			{
				bl.Insert(grupo, entity, ref retornos);
			}
			catch (IRetornoException ex)
			{
				RETORNO retorno = new RETORNO();
				retorno.transacao = "#TABLEWITHOUTPREFIXTABLE# - Insert";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				RETORNO retorno = new RETORNO();
				retorno.transacao = "#TABLEWITHOUTPREFIXTABLE# - Insert";
				retorno.status = "2";
				retorno.mensagem = e.Message;
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}

			return retornos;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="grupo"></param>
		/// <param name="entity"></param>
		/// <returns></returns>
		[HttpPut]
		[Route("Update/")]
		public List<RETORNO> Update(String grupo, [FromBody] #TABLEWITHOUTPREFIXTABLE# entity)
		{
			#TABLEWITHOUTPREFIXTABLE##SUFFIXBLL# bl = new #TABLEWITHOUTPREFIXTABLE##SUFFIXBLL#();
			List<RETORNO> retornos = new List<RETORNO>();
			RETORNO retorno = null;
			
			try
			{
				bl.Update(grupo, entity, ref retornos);
				
				retorno = new RETORNO();
				retorno.transacao = String.Format("ID_#TABLEWITHOUTPREFIXTABLE#={0}", entity.ID_#TABLEWITHOUTPREFIXTABLE#);
				retorno.status = "0";
				retorno.mensagem = "Registro atualizado com sucesso!";
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}
			catch (IRetornoException ex)
			{
				retorno = new RETORNO();
				retorno.transacao = "#TABLEWITHOUTPREFIXTABLE# - Update";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				retorno = new RETORNO();
				retorno.transacao = "#TABLEWITHOUTPREFIXTABLE# - Update";
				retorno.status = "2";
				retorno.mensagem = e.Message;
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}

			return retornos;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="grupo"></param>
		/// <param name="entity"></param>
		/// <returns></returns>
		[HttpDelete]
		[Route("Delete/")]
		public List<RETORNO> Delete(String grupo, [FromBody] #TABLEWITHOUTPREFIXTABLE# entity)
		{
			#TABLEWITHOUTPREFIXTABLE##SUFFIXBLL# bl = new #TABLEWITHOUTPREFIXTABLE##SUFFIXBLL#();
			List<RETORNO> retornos = new List<RETORNO>();
			RETORNO retorno = null;
			
			try
			{
				bl.Delete(grupo, entity);
				
				retorno = new RETORNO();
				retorno.transacao = String.Format("ID_#TABLEWITHOUTPREFIXTABLE#={0}", entity.ID_#TABLEWITHOUTPREFIXTABLE#);
				retorno.status = "0";
				retorno.mensagem = "Registro excluido com sucesso!";
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}
			catch (IRetornoException ex)
			{
				retorno = new RETORNO();
				retorno.transacao = "#TABLEWITHOUTPREFIXTABLE# - Delete";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				retorno = new RETORNO();
				retorno.transacao = "#TABLEWITHOUTPREFIXTABLE# - Delete";
				retorno.status = "2";
				retorno.mensagem = e.Message;
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}

			return retornos;
		}
	}    
}