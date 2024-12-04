/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 28/03/2020 02:49:05
**********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using SHL.IRetorno.Model;

using SHL.Task.Model;
using SHL.Task.DataLayer;

namespace SHL.Task.BusinessLayer
{ 
	public sealed partial class TASK_BL
	{	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="retornos"></param>
		/// <returns></returns>
		public Boolean ValidateToInsert(TASK entity, ref List<RETORNO> retornos)
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
		public Boolean ValidateToUpdate(TASK entity, ref List<RETORNO> retornos)
		{
			Boolean ret = true;

			//SHLSTUDIO_USER_AREA_START_2
			//SHLSTUDIO_USER_AREA_END_2
						
			return ret;
		}
	
		/// <summary>
		/// Select all records
		/// </summary>");
		public List<TASK> SelectList(String Group)
		{		
			TASK entity = new TASK();
			TASK_DL oTASK_DL = new TASK_DL();

			return oTASK_DL.SelectList(Group, entity);
		}

		/// <summary>
		/// Select a record by filter
		/// </summary>");
		public TASK Select(String Group, TASK entity)
		{		
			TASK_DL oTASK_DL = new TASK_DL();
			
			return oTASK_DL.Select(Group, entity);
		}

		/// <summary>
		/// Select some records by filter
		/// </summary>");
		public List<TASK> SelectList(String Group, TASK entity)
		{		
			TASK_DL oTASK_DL = new TASK_DL();
			
			return oTASK_DL.SelectList(Group, entity);
		}

		/// <summary>
		/// Insert a record in the table TASK
		/// </summary>");
		/// <param name="Group"></param>
		/// <param name="entity"></param>
		/// <param name="retornos"></param>
		public void Insert(String Group, TASK entity, ref List<RETORNO> retornos)
		{		
			TASK_DL oTASK_DL = new TASK_DL();
		   
			if (ValidateToInsert(entity, ref retornos))
				oTASK_DL.Insert(Group, entity);
		}

		/// <summary>
		/// Insert a record in the table TASK inside a transaction
		/// </summary>");		
		/// <param name="Group"></param>
		/// <param name="oSqlTransaction"></param>
		/// <param name="entity"></param>
		/// <param name="retornos"></param>
		public void Insert(String Group,  TASK entity, SqlTransaction oSqlTransaction, ref List<RETORNO> retornos)
		{		
			TASK_DL oTASK_DL = new TASK_DL();
			
			if (ValidateToInsert(entity, ref retornos))
				oTASK_DL.Insert(Group, oSqlTransaction, entity);
		}

		/// <summary>
		/// Update a record in the table TASK
		/// </summary>");
		public void Update(String Group, TASK entity, ref List<RETORNO> retornos)
		{		
			TASK_DL oTASK_DL = new TASK_DL();
			
			if (ValidateToUpdate(entity, ref retornos))
				oTASK_DL.Update(Group, entity);
		}

		/// <summary>
		/// Update a record in the table TASK with transaction
		/// </summary>");
		public void Update(String Group, TASK entity, SqlTransaction oSqlTransaction, ref List<RETORNO> retornos)
		{		
			TASK_DL oTASK_DL = new TASK_DL();
			
			if (ValidateToUpdate(entity, ref retornos))
				oTASK_DL.Update(Group, oSqlTransaction, entity);
		}

		/// <summary>
		/// Delete a record from table TASK
		/// </summary>");
		public void Delete(String Group, TASK entity)
		{		
			TASK_DL oTASK_DL = new TASK_DL();
			
			oTASK_DL.Delete(Group, entity);
		}

		/// <summary>
		/// Delete a record from table TASK with transaction
		/// </summary>");
		public void Delete(String Group, TASK entity, SqlTransaction oSqlTransaction)
		{		
			TASK_DL oTASK_DL = new TASK_DL();
			
			oTASK_DL.Delete(Group, oSqlTransaction, entity);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Group"></param>
		/// <returns></returns>
		public SqlTransaction GetTransaction(String Group)
		{
			SqlTransaction transaction = null;
			
			TASK_DL oTASK_DL = new TASK_DL();

			transaction = oTASK_DL.GetTransaction(Group);

			return transaction;
		}			
	}
}
