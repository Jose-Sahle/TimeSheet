/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 28/03/2020 02:49:05
**********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using SHL.Base.Base;
using SHL.Data.Base;

using SHL.Task.Model;

namespace SHL.Task.DataLayer
{
	public sealed partial class TASK_DL : BaseDAL<TASK>
	{	
		private String GetSelectStringValidate(String property, String table, String value)
		{
			StringBuilder sql = new StringBuilder();

			sql.Append("SELECT COUNT(1) AS 'COUNT'");
			sql.Append(" FROM ");
			sql.Append(table.ToUpper());
			sql.Append(" WHERE ");
			sql.Append(property.ToUpper() + " = '" + value + "'");

			return sql.ToString();
		}
		
		/// <summary>
		/// Select and return all records from table TASK
		/// </summary>
		public Int32 SelectValidate(String Group, String property, String table, String value)
		{
			SQLHelper.Group = Group;

			int ret = 0;
			var reader = SQLHelper.ExecuteReader(GetSelectStringValidate(property, table, value));
			if (reader.Read()) { ret = Convert.ToInt32(reader["COUNT"]); }
			
			return ret;
		}
		
		/// <summary>
		/// Select a record with a filter
		/// </summary>
		public TASK Select(String Group, TASK entity)
		{
			return base.ReturnUnique(Group, GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Select some records with a filter
		/// </summary>
		public List<TASK> SelectList(String Group)
		{			
			TASK entity = new TASK();
			
			SQLHelper.Group = Group;
			
			return base.ReturnList(Group, GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Select some records with a filter
		/// </summary>
		public List<TASK> SelectList(String Group, TASK entity)
		{			
			return base.ReturnList(Group, GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Select some records with a filter
		/// </summary>
		public List<TASK> SelectList(String Group, SqlTransaction oSqlTransaction, TASK entity)
		{
			return base.ReturnList(Group, GetSelectString(), oSqlTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Insert a record in the table TASK
		/// </summary>
		public Int32 Insert(String Group, TASK entity)
		{
			SqlTransaction transaction = null;
			
			SQLHelper.Group = Group;
			
			return Insert(Group, transaction, entity);
		}

		/// <summary>
		/// Insert a record in the table TASK with transction
		/// </summary>
		public Int32 Insert(String Group, SqlTransaction oSqlTransaction, TASK entity)
		{
			SQLHelper.Group = Group;
			
			return Convert.ToInt32(SQLHelper.ExecuteNonQuery(GetInsertString(), oSqlTransaction, CreateParameters(entity, false), "@IdReturn"));
		}

		/// <summary>
		/// Update a record in the table TASK
		/// </summary>
		public void Update(String Group, TASK entity)
		{
			SqlTransaction transaction = null;
			
			SQLHelper.Group = Group;
			
			Update(Group, transaction, entity);
		}

		/// <summary>
		/// Update a record in the table TASK with transaction
		/// </summary>
		public void Update(String Group, SqlTransaction oSqlTransaction, TASK entity)
		{
			SQLHelper.Group = Group;
			
			SQLHelper.ExecuteNonQuery(GetUpdateString(), oSqlTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Delete a record from table TASK
		/// </summary>
		public void Delete(String Group, TASK entity)
		{
			SqlTransaction transaction = null;
			
			SQLHelper.Group = Group;

			Delete(Group, transaction, entity);
		}

		/// <summary>
		/// Delete a record from table TASK with transaction
		/// </summary>
		public void Delete(String Group, SqlTransaction oSqlTransaction, TASK entity)
		{
			SQLHelper.Group = Group;
			
			SQLHelper.ExecuteNonQuery(GetDeleteString(), oSqlTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Carrega os Parametros com ou sem ID
		/// </summary>
		private ArrayList CreateParameters(TASK entity, bool pid)
		{
			ArrayList parameters = new ArrayList();

			SQLHelper.AddParameter(ref parameters, "@ID_TASK", entity.ID_TASK); 
			SQLHelper.AddParameter(ref parameters, "@START_TM", entity.START_TM);
			SQLHelper.AddParameter(ref parameters, "@END_TM", entity.END_TM);
			SQLHelper.AddParameter(ref parameters, "@DESCRIPTION", entity.DESCRIPTION);
			SQLHelper.AddParameter(ref parameters, "@INDICE_PROJECT", entity.INDICE_PROJECT);
			SQLHelper.AddParameter(ref parameters, "@ID_TIMESHEET", entity.ID_TIMESHEET);
			SQLHelper.AddParameter(ref parameters, "@ID_PROJECT", entity.ID_PROJECT);

			return parameters;
		}
		
		private String GetInsertString()
		{
			String sql = String.Empty;
			
			sql = "INSERT INTO TASK\n";
			sql +="(\n";
			sql += "	[START_TM]\n";
			sql += "	,[END_TM]\n";
			sql += "	,[DESCRIPTION]\n";
			sql += "	,[INDICE_PROJECT]\n";
			sql += "	,[ID_TIMESHEET]\n";
			sql += "	,[ID_PROJECT]\n";
			sql +=")\n";
			sql += "VALUES\n";
			sql += "(\n";
			sql += "	@START_TM\n";
			sql += "	,@END_TM\n";
			sql += "	,@DESCRIPTION\n";
			sql += "	,@INDICE_PROJECT\n";
			sql += "	,@ID_TIMESHEET\n";
			sql += "	,@ID_PROJECT\n";
			sql += ")\n\n";

			sql += "SET @IdReturn = SCOPE_IDENTITY()\n";

			return sql;
		}
		
		private String GetUpdateString()
		{
			String sql = String.Empty;
			
			sql  = "UPDATE \n";
			sql += "	TASK \n";
			sql += "SET \n";
			sql += "	[START_TM] = @START_TM\n";
			sql += "	,[END_TM] = @END_TM\n";
			sql += "	,[DESCRIPTION] = @DESCRIPTION\n";
			sql += "	,[INDICE_PROJECT] = @INDICE_PROJECT\n";
			sql += "	,[ID_TIMESHEET] = @ID_TIMESHEET\n";
			sql += "	,[ID_PROJECT] = @ID_PROJECT\n";
			sql += "WHERE [ID_TASK] = @ID_TASK\n";
			
			return sql;
		}
		
		
		private String GetDeleteString()
		{
			String sql = String.Empty;
			
			sql = "DELETE FROM  \n";
			sql += "	TASK \n";
			sql += "WHERE ([ID_TASK] = @ID_TASK OR @ID_TASK IS NULL)\n";
			sql += "AND ([ID_TIMESHEET] = @ID_TIMESHEET OR @ID_TIMESHEET IS NULL)\n";
			return sql;
		}

		private String GetSelectString()
		{
			String sql = String.Empty;
			
			sql = "SELECT  \n";
			sql += "	T.[ID_TASK],\n";
			sql += "	T.[START_TM],\n";
			sql += "	T.[END_TM],\n";
			sql += "	T.[DESCRIPTION],\n";
			sql += "	T.[INDICE_PROJECT],\n";
			sql += "	T.[ID_TIMESHEET],\n";
			sql += "	T.[ID_PROJECT],\n";
			sql += "	P.[NAME] AS [PROJECTNAME]\n";
			sql += "FROM		TASK  T WITH (NOLOCK) \n";
			sql += "LEFT JOIN   PROJECT P WITH (NOLOCK)\n";
			sql += "	 ON T.ID_PROJECT = P.ID_PROJECT \n";
			sql += "WHERE 1 = 1\n";
			sql += "  AND (T.[START_TM] = @START_TM OR @START_TM IS NULL)\n";
			sql += "  AND (T.[END_TM] = @END_TM OR @END_TM IS NULL)\n";
			sql += "  AND (T.[DESCRIPTION] = @DESCRIPTION OR @DESCRIPTION IS NULL)\n";
			sql += "  AND (T.[INDICE_PROJECT] = @INDICE_PROJECT OR @INDICE_PROJECT IS NULL)\n";
			sql += "  AND (T.[ID_TIMESHEET] = @ID_TIMESHEET OR @ID_TIMESHEET IS NULL)\n";
			sql += "  AND (T.[ID_PROJECT] = @ID_PROJECT OR @ID_PROJECT IS NULL)\n";
				
			return sql;
		}
	}// Close out the class and namespace
}

