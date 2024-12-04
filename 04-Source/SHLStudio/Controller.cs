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

using #NAMESPACEBLL#;
using #NAMESPACEENTITY#;

using System.Data.SqlClient;
using SHL.IRetorno.Model;

namespace Linx.ERP.TiProdAcItensFiscais.Controllers
{ 
	[Route("api/[controller]")]
	[ApiController]
	public class  <firstupper>#TABLE#</firstupper>Controller : ControllerBase
	{
		//SHLSTUDIO_USER_AREA_START_1
		//SHLSTUDIO_USER_AREA_END_1

		[HttpGet]
		[Route("SelectAll/")]
		public List<#TABLEWITHOUTPREFIXTABLE#> SelectAll(String grupo)
		{
			#TABLEWITHOUTPREFIXTABLE##SUFFIXBLL# bl = new #TABLEWITHOUTPREFIXTABLE##SUFFIXBLL#();
			#TABLEWITHOUTPREFIXTABLE# entity = new #TABLEWITHOUTPREFIXTABLE#();

			return bl.SelectList(grupo, entity);
		}

		[HttpPost]
		[Route("Select/")]
		public List<#TABLEWITHOUTPREFIXTABLE#> Select(String grupo, [FromBody] #TABLEWITHOUTPREFIXTABLE# entity)
		{
			#TABLEWITHOUTPREFIXTABLE##SUFFIXBLL# bl = new #TABLEWITHOUTPREFIXTABLE##SUFFIXBLL#();

			return bl.SelectList(grupo, entity);
		}

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
			catch (Exception ex)
			{
				RETORNO retorno = new RETORNO();
				retorno.transacao = "#TABLEWITHOUTPREFIXTABLE# - Insert";
				retorno.status = "2";
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}

			return retornos;
		}
		
		// POST: api/ClienteVarejo
		[HttpPut]
		[Route("Update/")]
		public List<RETORNO> Update(String grupo, [FromBody] #TABLEWITHOUTPREFIXTABLE# entity)
		{
			#TABLEWITHOUTPREFIXTABLE##SUFFIXBLL# bl = new #TABLEWITHOUTPREFIXTABLE##SUFFIXBLL#();
			List<RETORNO> retornos = new List<RETORNO>();

			try
			{
				bl.Update(grupo, entity, ref retornos);
			}
			catch (Exception ex)
			{
				RETORNO retorno = new RETORNO();
				retorno.transacao = "#TABLEWITHOUTPREFIXTABLE# - Update";
				retorno.status = "2";
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}

			return retornos;
		}
		
		[HttpDelete]
		[Route("Delete/")]
		public List<RETORNO> Delete(String grupo, [FromBody] #TABLEWITHOUTPREFIXTABLE# entity)
		{
			#TABLEWITHOUTPREFIXTABLE##SUFFIXBLL# bl = new #TABLEWITHOUTPREFIXTABLE##SUFFIXBLL#();
			List<RETORNO> retornos = new List<RETORNO>();

			try
			{
				bl.Update(grupo, entity, ref retornos);
			}
			catch (Exception ex)
			{
				RETORNO retorno = new RETORNO();
				retorno.transacao = "#TABLEWITHOUTPREFIXTABLE# - Delete";
				retorno.status = "2";
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}

			return retornos;
		}
	}    
}