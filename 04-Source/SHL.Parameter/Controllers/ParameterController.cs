/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 28/03/2020 02:42:27
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
using SHL.Syncronism.BusinessLayer;
using SHL.Syncronism.Model;

using System.Data.SqlClient;

namespace SHL.Parameter.Controllers
{ 
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class  ParameterController : ControllerBase
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
		public List<PARAMETER> SelectAll(String grupo)
		{
			PARAMETER_BL bl = new PARAMETER_BL();
			PARAMETER entity = new PARAMETER();

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
		public List<PARAMETER> Select(String grupo, [FromBody] PARAMETER entity)
		{
			PARAMETER_BL bl = new PARAMETER_BL();

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
		public List<RETORNO> Insert(String grupo, [FromBody] PARAMETER entity)
		{
			PARAMETER_BL bl = new PARAMETER_BL();
			List<RETORNO> retornos = new List<RETORNO>();

			try
			{
				bl.Insert(grupo, entity, ref retornos);
			}
			catch (IRetornoException ex)
			{
				RETORNO retorno = new RETORNO();
				retorno.transacao = "PARAMETER - Insert";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				RETORNO retorno = new RETORNO();
				retorno.transacao = "PARAMETER - Insert";
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
		public List<RETORNO> Update(String grupo, [FromBody] PARAMETER entity)
		{
			PARAMETER_BL bl = new PARAMETER_BL();
			List<RETORNO> retornos = new List<RETORNO>();
			RETORNO retorno = null;
			
			try
			{
				bl.Update(grupo, entity, ref retornos);
				
				retorno = new RETORNO();
				retorno.transacao = String.Format("KEY={0}", entity.KEY);
				retorno.status = "0";
				retorno.mensagem = "Registro atualizado com sucesso!";
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}
			catch (IRetornoException ex)
			{
				retorno = new RETORNO();
				retorno.transacao = "PARAMETER - Update";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				retorno = new RETORNO();
				retorno.transacao = "PARAMETER - Update";
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
		public List<RETORNO> Delete(String grupo, [FromBody] PARAMETER entity)
		{
			PARAMETER_BL bl = new PARAMETER_BL();
			List<RETORNO> retornos = new List<RETORNO>();
			RETORNO retorno = null;
			
			try
			{
				bl.Delete(grupo, entity);
				
				retorno = new RETORNO();
				retorno.transacao = String.Format("KEY={0}", entity.KEY);
				retorno.status = "0";
				retorno.mensagem = "Registro excluido com sucesso!";
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}
			catch (IRetornoException ex)
			{
				retorno = new RETORNO();
				retorno.transacao = "PARAMETER - Delete";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				retorno = new RETORNO();
				retorno.transacao = "PARAMETER - Delete";
				retorno.status = "2";
				retorno.mensagem = e.Message;
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}

			return retornos;
		}
	}    
}
