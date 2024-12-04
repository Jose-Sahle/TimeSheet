/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 28/03/2020 02:49:05
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
using SHL.Task.BusinessLayer;
using SHL.Task.Model;

using System.Data.SqlClient;

namespace SHL.Task.Controllers
{ 
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class  TaskController : ControllerBase
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
		public List<TASK> SelectAll(String grupo)
		{
			TASK_BL bl = new TASK_BL();
			TASK entity = new TASK();

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
		public List<TASK> Select(String grupo, [FromBody] TASK entity)
		{
			TASK_BL bl = new TASK_BL();

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
		public List<RETORNO> Insert(String grupo, [FromBody] TASK entity)
		{
			TASK_BL bl = new TASK_BL();
			List<RETORNO> retornos = new List<RETORNO>();

			try
			{
				bl.Insert(grupo, entity, ref retornos);
			}
			catch (IRetornoException ex)
			{
				RETORNO retorno = new RETORNO();
				retorno.transacao = "TASK - Insert";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				RETORNO retorno = new RETORNO();
				retorno.transacao = "TASK - Insert";
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
		public List<RETORNO> Update(String grupo, [FromBody] TASK entity)
		{
			TASK_BL bl = new TASK_BL();
			List<RETORNO> retornos = new List<RETORNO>();
			RETORNO retorno = null;
			
			try
			{
				bl.Update(grupo, entity, ref retornos);
				
				retorno = new RETORNO();
				retorno.transacao = String.Format("ID_TASK={0}", entity.ID_TASK);
				retorno.status = "0";
				retorno.mensagem = "Registro atualizado com sucesso!";
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}
			catch (IRetornoException ex)
			{
				retorno = new RETORNO();
				retorno.transacao = "TASK - Update";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				retorno = new RETORNO();
				retorno.transacao = "TASK - Update";
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
		public List<RETORNO> Delete(String grupo, [FromBody] TASK entity)
		{
			TASK_BL bl = new TASK_BL();
			List<RETORNO> retornos = new List<RETORNO>();
			RETORNO retorno = null;
			
			try
			{
				bl.Delete(grupo, entity);
				
				retorno = new RETORNO();
				retorno.transacao = String.Format("ID_TASK={0}", entity.ID_TASK);
				retorno.status = "0";
				retorno.mensagem = "Registro excluido com sucesso!";
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}
			catch (IRetornoException ex)
			{
				retorno = new RETORNO();
				retorno.transacao = "TASK - Delete";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				retorno = new RETORNO();
				retorno.transacao = "TASK - Delete";
				retorno.status = "2";
				retorno.mensagem = e.Message;
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}

			return retornos;
		}
	}    
}
