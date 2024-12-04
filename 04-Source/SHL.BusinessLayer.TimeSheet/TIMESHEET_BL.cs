/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 07/03/2019 21:26:05
**********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using SHL.IRetorno.Model;

using SHL.TimeSheet.Model;
using SHL.TimeSheet.DataLayer;
using SHL.Task.Model;
using SHL.Task.BusinessLayer;
using SHL.Project.Model;
using SHL.Project.BusinessLayer;

namespace SHL.TimeSheet.BusinessLayer
{ 
	/// <summary>
	/// 
	/// </summary>
	public sealed partial class TIMESHEET_BL
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="retornos"></param>
		/// <returns></returns>
		public Boolean ValidateToInsert(TIMESHEET entity, ref List<RETORNO> retornos)
		{
			Boolean ret = true;

			//SHLSTUDIO_USER_AREA_START_1
			//SHLSTUDIO_USER_AREA_END_1
						
			return ret;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="retornos"></param>
		/// <returns></returns>
		public Boolean ValidateToUpdate(TIMESHEET entity, ref List<RETORNO> retornos)
		{
			Boolean ret = true;

			//SHLSTUDIO_USER_AREA_START_2
			//SHLSTUDIO_USER_AREA_END_2
						
			return ret;
		}
	
		/// <summary>
		/// Select all records
		/// </summary>");
		public List<TIMESHEET> SelectList(String Group)
		{		
			TIMESHEET entity = new TIMESHEET();
			TIMESHEET_DL oTIMESHEET_DL = new TIMESHEET_DL();
			TASK_BL oTASK_BL = new TASK_BL();
			TASK oTASK = null;

			List<TIMESHEET> oTIMESHEETLIST = oTIMESHEET_DL.SelectList(Group, entity);

			if(oTIMESHEETLIST != null)
			{
				foreach(TIMESHEET timesheet in oTIMESHEETLIST)
				{
					oTASK = new TASK();
					oTASK.ID_TIMESHEET = timesheet.ID_TIMESHEET;
					timesheet.TASKS = oTASK_BL.SelectList(Group, oTASK);
				}
			}

			return oTIMESHEETLIST;
		}

		/// <summary>
		/// Select a record by filter
		/// </summary>");
		public TIMESHEET Select(String Group, TIMESHEET entity)
		{		
			TIMESHEET_DL oTIMESHEET_DL = new TIMESHEET_DL();
			TASK_BL oTASK_BL = new TASK_BL();
			TIMESHEET oTIMESHEET = new TIMESHEET();
			TASK oTASK = new TASK();

			oTIMESHEET = oTIMESHEET_DL.Select(Group, entity);

			if(oTIMESHEET != null)
			{
				oTASK.ID_TIMESHEET = oTIMESHEET.ID_TIMESHEET;
				oTIMESHEET.TASKS = oTASK_BL.SelectList(Group, oTASK);
			}

			return oTIMESHEET;
		}

		/// <summary>
		/// Select some records by filter
		/// </summary>");
		public List<TIMESHEET> SelectList(String Group, TIMESHEET entity)
		{		
			TIMESHEET_DL oTIMESHEET_DL = new TIMESHEET_DL();
			TASK_BL oTASK_BL = new TASK_BL();
			TASK oTASK = null;

			List<TIMESHEET> oTIMESHEETLIST = oTIMESHEET_DL.SelectList(Group, entity);

			if(oTIMESHEETLIST != null && oTIMESHEETLIST.Count > 0)
			{
				foreach(TIMESHEET timesheet in oTIMESHEETLIST)
				{
					oTASK = new TASK();
					oTASK.ID_TIMESHEET = timesheet.ID_TIMESHEET;
					timesheet.TASKS = oTASK_BL.SelectList(Group, oTASK);
				}
			}

			return oTIMESHEETLIST;
		}

		/// <summary>
		/// Insert a record in the table TIMESHEET
		/// </summary>");
		public void Insert(String Group, TIMESHEET entity, ref List<RETORNO> retornos)
		{		
			TIMESHEET_DL oTIMESHEET_DL = new TIMESHEET_DL();
			SqlTransaction oSqlTransaction = null;

			try
			{
				if (ValidateToInsert(entity, ref retornos))
				{
					oSqlTransaction = oTIMESHEET_DL.GetTransaction(Group);
					Insert(Group, entity, oSqlTransaction, ref retornos);
					oSqlTransaction.Commit();
				}
			}
			catch (Exception ex)
			{
				if (oSqlTransaction != null)
					oSqlTransaction.Rollback();

				throw ex;
			}
		}

		/// <summary>
		/// Insert a record in the table TIMESHEET inside a transaction
		/// </summary>");
		public void Insert(String Group, TIMESHEET entity, SqlTransaction oSqlTransaction, ref List<RETORNO> retornos)
		{		
			TIMESHEET_DL oTIMESHEET_DL = new TIMESHEET_DL();
			TASK_BL oTASK_BL = new TASK_BL();
			List<RETORNO> retornostask = new List<RETORNO>();
			PROJECT_BL projectbl = new PROJECT_BL();
			PROJECT project = null;

			try
			{
				if (ValidateToInsert(entity, ref retornos))
				{
					entity.ID_TIMESHEET = oTIMESHEET_DL.Insert(Group, oSqlTransaction, entity);

					if(entity.TASKS != null)
					{
						foreach(TASK task in entity.TASKS)
						{
							project = new PROJECT();

							project.NAME = task.PROJECTNAME;
							project = projectbl.Select(Group, project);

							task.ID_TIMESHEET = entity.ID_TIMESHEET;
							task.ID_PROJECT = project.ID_PROJECT;
							oTASK_BL.Insert(Group, task, oSqlTransaction, ref retornostask);

							if(retornostask != null && retornostask.Count > 0)
							{
								foreach (RETORNO retorno in retornostask)
									retornos.Add(retorno);

								throw new Exception("Rollback");
							}
						}
					}
				}
				else
				{
					throw new Exception("Not validated");
				}
			}
			catch(Exception ex)
			{
				if (oSqlTransaction != null)
					oSqlTransaction.Rollback();

				throw ex;
			}
			
		}

		/// <summary>
		/// Update a record in the table TIMESHEET
		/// </summary>");
		public void Update(String Group, TIMESHEET entity, ref List<RETORNO> retornos)
		{		
			TIMESHEET_DL oTIMESHEET_DL = new TIMESHEET_DL();
			SqlTransaction oSqlTransaction = null;

			try
			{
				if (ValidateToUpdate(entity, ref retornos))
				{
					oSqlTransaction = oTIMESHEET_DL.GetTransaction(Group);
					Update(Group, entity, oSqlTransaction, ref retornos);
					oSqlTransaction.Commit();
				}
			}
			catch (Exception ex)
			{
				oSqlTransaction.Rollback();

				throw ex;
			}
		}

		/// <summary>
		/// Update a record in the table TIMESHEET with transaction
		/// </summary>");
		public void Update(String Group, TIMESHEET entity, SqlTransaction oSqlTransaction, ref List<RETORNO> retornos)
		{		
			TIMESHEET_DL oTIMESHEET_DL = new TIMESHEET_DL();
			TASK_BL oTASK_BL = new TASK_BL();
			TASK oTASK = new TASK();
			List<RETORNO> retornostask = new List<RETORNO>();
			PROJECT_BL projectbl = new PROJECT_BL();
			PROJECT project = null;

			try
			{								
				if (ValidateToUpdate(entity, ref retornos))
				{
					entity.ID_TIMESHEET = oTIMESHEET_DL.Select(Group, new TIMESHEET() { DATE_RG = entity.DATE_RG }).ID_TIMESHEET;

					oTIMESHEET_DL.Update(Group, oSqlTransaction, entity);

					oTASK.ID_TIMESHEET = entity.ID_TIMESHEET;
					oTASK_BL.Delete(Group, oTASK, oSqlTransaction);

					if (entity.TASKS != null)
					{
						foreach (TASK task in entity.TASKS)
						{
							project = new PROJECT();

							project.NAME = task.PROJECTNAME;
							project = projectbl.Select(Group, project);

							task.ID_TIMESHEET = entity.ID_TIMESHEET;
							task.ID_PROJECT = project.ID_PROJECT;
							oTASK_BL.Insert(Group, task, oSqlTransaction, ref retornostask);

							if (retornostask != null && retornostask.Count > 0)
							{
								foreach (RETORNO retorno in retornostask)
									retornos.Add(retorno);

								throw new Exception("Rollback");
							}
						}
					}
				}
				else
				{
					throw new Exception("Not validated");
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Delete a record from table TIMESHEET
		/// </summary>");
		public void Delete(String Group, TIMESHEET entity)
		{		
			TIMESHEET_DL oTIMESHEET_DL = new TIMESHEET_DL();
			SqlTransaction oSqlTransaction = null;

			try
			{
				oSqlTransaction = oTIMESHEET_DL.GetTransaction(Group);

				Delete(Group, entity, oSqlTransaction);

				oSqlTransaction.Commit();
			}
			catch (Exception ex)
			{
				if (oSqlTransaction != null)
					oSqlTransaction.Rollback();

				throw ex;
			}
		}

		/// <summary>
		/// Delete a record from table TIMESHEET with transaction
		/// </summary>");
		public void Delete(String Group, TIMESHEET entity, SqlTransaction oSqlTransaction)
		{		
			TIMESHEET_DL oTIMESHEET_DL = new TIMESHEET_DL();
			TASK_BL oTASK_BL = new TASK_BL();
			TASK oTASK = new TASK();

			try
			{
				oTASK.ID_TIMESHEET = entity.ID_TIMESHEET;
				
				oTASK_BL.Delete(Group, oTASK, oSqlTransaction);

				oTIMESHEET_DL.Delete(Group, oSqlTransaction, entity);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Group"></param>
		/// <returns></returns>
		public SqlTransaction GetTransaction(String Group)
		{
			SqlTransaction transaction = null;
			
			TIMESHEET_DL oTIMESHEET_DL = new TIMESHEET_DL();

			transaction = oTIMESHEET_DL.GetTransaction(Group);

			return transaction;
		}			
	}
}
