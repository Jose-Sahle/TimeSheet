/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 07/03/2019 21:26:05
**********************************************************/
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using SHL.TimeSheet.BusinessLayer;
using SHL.TimeSheet.Model;

using SHL.IRetorno.Model;
using SHL.Types;

namespace SHL.TimeSheet.Controllers
{ 
	[Route("api/[controller]")]
	[ApiController]
	public class  TimesheetController : ControllerBase
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
		public List<TIMESHEET> SelectAll(String grupo)
		{
			TIMESHEET_BL bl = new TIMESHEET_BL();
			TIMESHEET entity = new TIMESHEET();
			List<TIMESHEET> records = new List<TIMESHEET>();

			try
			{
				records = bl.SelectList(grupo, entity);
			}
			catch (IRetornoException ex)
			{
				TIMESHEET record = new TIMESHEET();
				record.description = String.Format("{0}\r\n{1}", ex.Message, ex.Trace);
				records.Add(record);
			}
			catch (Exception e)
			{
				TIMESHEET record = new TIMESHEET();
				record.description = String.Format("{0}\r\n{1}", e.Message, e.InnerException.Message);
				records.Add(record);
			}

			return records;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="grupo"></param>
		/// <param name="entity"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("Select/")]
		public List<TIMESHEET> Select(String grupo, [FromBody] TIMESHEET entity)
		{
			TIMESHEET_BL bl = new TIMESHEET_BL();

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
		public List<RETORNO> Insert(String grupo, [FromBody] TIMESHEET entity)
		{
			TIMESHEET_BL bl = new TIMESHEET_BL();
			List<RETORNO> retornos = new List<RETORNO>();

			try
			{
				bl.Insert(grupo, entity, ref retornos);
			}
			catch (IRetornoException ex)
			{
				RETORNO retorno = new RETORNO();
				retorno.transacao = "TIMESHEET - Insert";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				RETORNO retorno = new RETORNO();
				retorno.transacao = "TIMESHEET - Insert";
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
		public List<RETORNO> Update(String grupo, [FromBody] TIMESHEET entity)
		{
			TIMESHEET_BL bl = new TIMESHEET_BL();
			List<RETORNO> retornos = new List<RETORNO>();
			RETORNO retorno = null;
			
			try
			{
				bl.Update(grupo, entity, ref retornos);
				
				retorno = new RETORNO();
				retorno.transacao = String.Format("id_timesheet={0}", entity.id_timesheet);
				retorno.status = "0";
				retorno.mensagem = "Registro atualizado com sucesso!";
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}
			catch (IRetornoException ex)
			{
				retorno = new RETORNO();
				retorno.transacao = "TIMESHEET - Update";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				retorno = new RETORNO();
				retorno.transacao = "TIMESHEET - Update";
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
		public List<RETORNO> Delete(String grupo, [FromBody] TIMESHEET entity)
		{
			TIMESHEET_BL bl = new TIMESHEET_BL();
			List<RETORNO> retornos = new List<RETORNO>();
			RETORNO retorno = null;
			
			try
			{
				bl.Delete(grupo, entity);
				
				retorno = new RETORNO();
				retorno.transacao = String.Format("id_timesheet={0}", entity.id_timesheet);
				retorno.status = "0";
				retorno.mensagem = "Registro excluído com sucesso!";
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}
			catch (IRetornoException ex)
			{
				retorno = new RETORNO();
				retorno.transacao = "TIMESHEET - Delete";
				retorno.status = ex.Status;
				retorno.mensagem = ex.Message;
				retorno.dt_retorno = ex.Dt;
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				retorno = new RETORNO();
				retorno.transacao = "TIMESHEET - Delete";
				retorno.status = "2";
				retorno.mensagem = e.Message;
				retorno.dt_retorno = DateTime.Now;
				retornos.Add(retorno);
			}

			return retornos;
		}
	}    
}
