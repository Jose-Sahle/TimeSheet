/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 07/03/2019 21:26:05
**********************************************************/
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using SHL.TimeSheet.BusinessLayer;

using SHL.IRetorno.Model;
using SHL.Types;
using SHL.Syncronism;
using SHL.Syncronism.Model;
using System.Data.SqlClient;

namespace SHL.Syncronism.Controllers
{ 
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class  SyncronismController : ControllerBase
	{
		//SHLSTUDIO_USER_AREA_START_1
		//SHLSTUDIO_USER_AREA_END_1

		/// <summary>
		/// 
		/// </summary>
		/// <param name="grupo"></param>
		/// <param name="entities"></param>
		/// <returns></returns>
		[HttpPost]
        [Route("Sendto/")]
        public List<RETORNO> Sendto(String grupo, [FromBody] List<SYNCRONISM> entities)
        {
			List<RETORNO> retornos = null;
			SqlTransaction transaction = null;
			TIMESHEET_BL timesheetbl = null;

			try
			{
				if (entities == null || entities.Count == 0)
					throw new IRetornoException("Nenhum registro para sincronizar");

				timesheetbl = new TIMESHEET_BL();

				transaction = timesheetbl.GetTransaction(grupo);

				foreach (SYNCRONISM entity in entities)
				{
					switch(entity.TABLENAME)
					{
						case "TIMESHEET":
							TreatFunctions.TreatTimeSheet(grupo, entity, ref transaction, ref retornos);
							break;
						case "PARAMETER":
							TreatFunctions.TreatParameter(grupo, entity, ref transaction, ref retornos);
							break;
						case "PROJECT":
							TreatFunctions.TreatProject(grupo, entity, ref transaction, ref retornos);
							break;
						case "TASK":
							TreatFunctions.TreatTask(grupo, entity, ref transaction, ref retornos);
							break;
					}
				}

				transaction.Commit();
			}
			catch (IRetornoException ex)
			{
				transaction.Rollback();

				if (retornos == null)
					retornos = new List<RETORNO>();

				RETORNO retorno = new RETORNO();
				retorno.dt_retorno = DateTime.Now;
				retorno.status = "1";
				retorno.mensagem = String.Format("{0}\r\n{1}", ex.Message, ex.Trace);
				retornos.Add(retorno);
			}
			catch (Exception e)
			{
				transaction.Rollback();

				if (retornos == null)
					retornos = new List<RETORNO>();

				RETORNO retorno = new RETORNO();
				retorno.dt_retorno = DateTime.Now;
				retorno.status = "1";
				retorno.mensagem = String.Format("{0}\r\n{1}", e.Message, e.InnerException.Message);
				retornos.Add(retorno);
			}

			return retornos;
        }
	}    
}
