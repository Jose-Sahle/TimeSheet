/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 28/03/2020 02:44:43
**********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using SHL.IRetorno.Model;

using SHL.Syncronism.Model;
using SHL.Syncronism.DataLayer;

namespace SHL.Syncronism.BusinessLayer
{ 
	public sealed partial class PARAMETER_BL
	{	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="retornos"></param>
		/// <returns></returns>
		public Boolean ValidateToInsert(PARAMETER entity, ref List<RETORNO> retornos)
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
		public Boolean ValidateToUpdate(PARAMETER entity, ref List<RETORNO> retornos)
		{
			Boolean ret = true;

			//SHLSTUDIO_USER_AREA_START_2
			//SHLSTUDIO_USER_AREA_END_2
						
			return ret;
		}
	
		/// <summary>
		/// Select all records
		/// </summary>");
		public List<PARAMETER> SelectList(String Group)
		{		
			PARAMETER entity = new PARAMETER();
			PARAMETER_DL oPARAMETER_DL = new PARAMETER_DL();
			
			return oPARAMETER_DL.SelectList(Group, entity);
		}

		/// <summary>
		/// Select a record by filter
		/// </summary>");
		public PARAMETER Select(String Group, PARAMETER entity)
		{		
			PARAMETER_DL oPARAMETER_DL = new PARAMETER_DL();
			
			return oPARAMETER_DL.Select(Group, entity);
		}

		/// <summary>
		/// Select some records by filter
		/// </summary>");
		public List<PARAMETER> SelectList(String Group, PARAMETER entity)
		{		
			PARAMETER_DL oPARAMETER_DL = new PARAMETER_DL();
			
			return oPARAMETER_DL.SelectList(Group, entity);
		}

		/// <summary>
		/// Insert a record in the table PARAMETER
		/// </summary>");
		/// <param name="Group"></param>
		/// <param name="entity"></param>
		/// <param name="retornos"></param>
		public void Insert(String Group, PARAMETER entity, ref List<RETORNO> retornos)
		{		
			PARAMETER_DL oPARAMETER_DL = new PARAMETER_DL();
		   
			if (ValidateToInsert(entity, ref retornos))
				oPARAMETER_DL.Insert(Group, entity);
		}

		/// <summary>
		/// Insert a record in the table PARAMETER inside a transaction
		/// </summary>");		
		/// <param name="Group"></param>
		/// <param name="oSqlTransaction"></param>
		/// <param name="entity"></param>
		/// <param name="retornos"></param>
		public void Insert(String Group, PARAMETER entity, SqlTransaction oSqlTransaction, ref List<RETORNO> retornos)
		{		
			PARAMETER_DL oPARAMETER_DL = new PARAMETER_DL();
			
			if (ValidateToInsert(entity, ref retornos))
				oPARAMETER_DL.Insert(Group, oSqlTransaction, entity);
		}

		/// <summary>
		/// Update a record in the table PARAMETER
		/// </summary>");
		public void Update(String Group, PARAMETER entity, ref List<RETORNO> retornos)
		{		
			PARAMETER_DL oPARAMETER_DL = new PARAMETER_DL();
			
			if (ValidateToUpdate(entity, ref retornos))
				oPARAMETER_DL.Update(Group, entity);
		}

		/// <summary>
		/// Update a record in the table PARAMETER with transaction
		/// </summary>");
		public void Update(String Group, PARAMETER entity, SqlTransaction oSqlTransaction, ref List<RETORNO> retornos)
		{		
			PARAMETER_DL oPARAMETER_DL = new PARAMETER_DL();
			
			if (ValidateToUpdate(entity, ref retornos))
				oPARAMETER_DL.Update(Group, oSqlTransaction, entity);
		}

		/// <summary>
		/// Delete a record from table PARAMETER
		/// </summary>");
		public void Delete(String Group, PARAMETER entity)
		{		
			PARAMETER_DL oPARAMETER_DL = new PARAMETER_DL();
			
			oPARAMETER_DL.Delete(Group, entity);
		}

		/// <summary>
		/// Delete a record from table PARAMETER with transaction
		/// </summary>");
		public void Delete(String Group, PARAMETER entity, SqlTransaction oSqlTransaction)
		{		
			PARAMETER_DL oPARAMETER_DL = new PARAMETER_DL();
			
			oPARAMETER_DL.Delete(Group, oSqlTransaction, entity);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Group"></param>
		/// <returns></returns>
		public SqlTransaction GetTransaction(String Group)
		{
			SqlTransaction transaction = null;
			
			PARAMETER_DL oPARAMETER_DL = new PARAMETER_DL();

			transaction = oPARAMETER_DL.GetTransaction(Group);

			return transaction;
		}			
	}
}
