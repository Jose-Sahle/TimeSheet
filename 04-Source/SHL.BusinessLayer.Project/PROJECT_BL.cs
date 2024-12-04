/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 28/03/2020 02:49:03
**********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using SHL.IRetorno.Model;

using SHL.Project.Model;
using SHL.Project.DataLayer;

namespace SHL.Project.BusinessLayer
{ 
	public sealed partial class PROJECT_BL
	{	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="retornos"></param>
		/// <returns></returns>
		public Boolean ValidateToInsert(PROJECT entity, ref List<RETORNO> retornos)
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
		public Boolean ValidateToUpdate(PROJECT entity, ref List<RETORNO> retornos)
		{
			Boolean ret = true;

			//SHLSTUDIO_USER_AREA_START_2
			//SHLSTUDIO_USER_AREA_END_2
						
			return ret;
		}
	
		/// <summary>
		/// Select all records
		/// </summary>");
		public List<PROJECT> SelectList(String Group)
		{		
			PROJECT entity = new PROJECT();
			PROJECT_DL oPROJECT_DL = new PROJECT_DL();
			
			return oPROJECT_DL.SelectList(Group, entity);
		}

		/// <summary>
		/// Select a record by filter
		/// </summary>");
		public PROJECT Select(String Group, PROJECT entity)
		{		
			PROJECT_DL oPROJECT_DL = new PROJECT_DL();
			
			return oPROJECT_DL.Select(Group, entity);
		}

		/// <summary>
		/// Select some records by filter
		/// </summary>");
		public List<PROJECT> SelectList(String Group, PROJECT entity)
		{		
			PROJECT_DL oPROJECT_DL = new PROJECT_DL();
			
			return oPROJECT_DL.SelectList(Group, entity);
		}

		/// <summary>
		/// Insert a record in the table PROJECT
		/// </summary>");
		/// <param name="Group"></param>
		/// <param name="entity"></param>
		/// <param name="retornos"></param>
		public void Insert(String Group, PROJECT entity, ref List<RETORNO> retornos)
		{		
			PROJECT_DL oPROJECT_DL = new PROJECT_DL();
		   
			if (ValidateToInsert(entity, ref retornos))
				oPROJECT_DL.Insert(Group, entity);
		}

		/// <summary>
		/// Insert a record in the table PROJECT inside a transaction
		/// </summary>");		
		/// <param name="Group"></param>
		/// <param name="oSqlTransaction"></param>
		/// <param name="entity"></param>
		/// <param name="retornos"></param>
		public void Insert(String Group,  PROJECT entity, SqlTransaction oSqlTransaction, ref List<RETORNO> retornos)
		{		
			PROJECT_DL oPROJECT_DL = new PROJECT_DL();
			
			if (ValidateToInsert(entity, ref retornos))
				oPROJECT_DL.Insert(Group, oSqlTransaction, entity);
		}

		/// <summary>
		/// Update a record in the table PROJECT
		/// </summary>");
		public void Update(String Group, PROJECT entity, ref List<RETORNO> retornos)
		{		
			PROJECT_DL oPROJECT_DL = new PROJECT_DL();
			
			if (ValidateToUpdate(entity, ref retornos))
				oPROJECT_DL.Update(Group, entity);
		}

		/// <summary>
		/// Update a record in the table PROJECT with transaction
		/// </summary>");
		public void Update(String Group, PROJECT entity, SqlTransaction oSqlTransaction, ref List<RETORNO> retornos)
		{		
			PROJECT_DL oPROJECT_DL = new PROJECT_DL();
			
			if (ValidateToUpdate(entity, ref retornos))
				oPROJECT_DL.Update(Group, oSqlTransaction, entity);
		}

		/// <summary>
		/// Delete a record from table PROJECT
		/// </summary>");
		public void Delete(String Group, PROJECT entity)
		{		
			PROJECT_DL oPROJECT_DL = new PROJECT_DL();
			
			oPROJECT_DL.Delete(Group, entity);
		}

		/// <summary>
		/// Delete a record from table PROJECT with transaction
		/// </summary>");
		public void Delete(String Group, PROJECT entity, SqlTransaction oSqlTransaction)
		{		
			PROJECT_DL oPROJECT_DL = new PROJECT_DL();
			
			oPROJECT_DL.Delete(Group, oSqlTransaction, entity);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Group"></param>
		/// <returns></returns>
		public SqlTransaction GetTransaction(String Group)
		{
			SqlTransaction transaction = null;
			
			PROJECT_DL oPROJECT_DL = new PROJECT_DL();

			transaction = oPROJECT_DL.GetTransaction(Group);

			return transaction;
		}			
	}
}
