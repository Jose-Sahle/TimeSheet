/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 07/03/2019 21:26:05
**********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SHL.Base.Base;
using SHL.Data.Base;
using SHL.TimeSheet.Model;

namespace SHL.TimeSheet.DataLayer
{

	public sealed partial class TIMESHEET_DL : BaseDAL<TIMESHEET>
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
		/// Select and return all records from table TIMESHEET
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
		/// Select and return all records from table TIMESHEET
		/// </summary>
		public List<TIMESHEET> SelectList(String Group)
		{
			TIMESHEET entity = new TIMESHEET();
			
			SQLHelper.Group = Group;
			
			return base.ReturnList(Group, GetSelectString(), CreateParameters(entity, true));		
		}

		/// <summary>
		/// Select a record with a filter
		/// </summary>
		public TIMESHEET Select(String Group, TIMESHEET entity)
		{
			SQLHelper.Group = Group;
		
			return base.ReturnUnique(Group, GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Select a record with a filter
		/// </summary>
		public TIMESHEET Select(String Group, SqlTransaction oSqlTransaction, TIMESHEET entity)
		{
			SQLHelper.Group = Group;

			return base.ReturnUnique(Group, GetSelectString(), oSqlTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Select some records with a filter
		/// </summary>
		public List<TIMESHEET> SelectList(String Group, TIMESHEET entity)
		{
			SQLHelper.Group = Group;
			
			return base.ReturnList(Group, GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Insert a record in the table TIMESHEET
		/// </summary>
		public Int32 Insert(String Group, TIMESHEET entity)
		{
			SQLHelper.Group = Group;
			
			return Insert(Group, null, entity);
		}

		/// <summary>
		/// Insert a record in the table TIMESHEET with transction
		/// </summary>
		public Int32 Insert(String Group, SqlTransaction oSqlTransaction, TIMESHEET entity)
		{
			SQLHelper.Group = Group;
			
			return Convert.ToInt32(SQLHelper.ExecuteNonQuery(GetInsertString(), oSqlTransaction, CreateParameters(entity, false), "@IdReturn"));
		}

		/// <summary>
		/// Update a record in the table TIMESHEET
		/// </summary>
		public void Update(String Group, TIMESHEET entity)
		{
			SQLHelper.Group = Group;
			
			Update(Group, null, entity);
		}

		/// <summary>
		/// Update a record in the table TIMESHEET with transaction
		/// </summary>
		public void Update(String Group, SqlTransaction oSqlTransaction, TIMESHEET entity)
		{
			SQLHelper.Group = Group;
			
			SQLHelper.ExecuteNonQuery(GetUpdateString(), oSqlTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Delete a record from table TIMESHEET
		/// </summary>
		public void Delete(String Group, TIMESHEET entity)
		{
			SQLHelper.Group = Group;
			
			Delete(Group, null, entity);
		}

		/// <summary>
		/// Delete a record from table TIMESHEET with transaction
		/// </summary>
		public void Delete(String Group, SqlTransaction oSqlTransaction, TIMESHEET entity)
		{
			SQLHelper.Group = Group;
			
			SQLHelper.ExecuteNonQuery(GetDeleteString(), oSqlTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Carrega os Parametros com ou sem ID
		/// </summary>
		private ArrayList CreateParameters(TIMESHEET entity, bool pid)
		{
			ArrayList parameters = new ArrayList();

			SQLHelper.AddParameter(ref parameters, "@ID_TIMESHEET", entity.ID_TIMESHEET);
			SQLHelper.AddParameter(ref parameters, "@DATE_RG", entity.DATE_RG);
			SQLHelper.AddParameter(ref parameters, "@START_AM", entity.START_AM);
			SQLHelper.AddParameter(ref parameters, "@END_AM", entity.END_AM);
			SQLHelper.AddParameter(ref parameters, "@START_PM", entity.START_PM);
			SQLHelper.AddParameter(ref parameters, "@END_PM", entity.END_PM);
			SQLHelper.AddParameter(ref parameters, "@DESCRIPTION", entity.DESCRIPTION);

			return parameters;
		}
		
		private String GetInsertString()
		{
			String sql = String.Empty;
			
			sql = "INSERT INTO TIMESHEET\n";
			sql +="(\n";
			sql += "	 [DATE_RG]\n";
			sql += "	,[START_AM]\n";
			sql += "	,[END_AM]\n";
			sql += "	,[START_PM]\n";
			sql += "	,[END_PM]\n";
			sql += "	,[DESCRIPTION]\n";
			sql +=")\n";
			sql += "VALUES\n";
			sql += "(\n";
			sql += "	 @DATE_RG\n";
			sql += "	,@START_AM\n";
			sql += "	,@END_AM\n";
			sql += "	,@START_PM\n";
			sql += "	,@END_PM\n";
			sql += "	,@DESCRIPTION\n";
			sql += ")";

			sql += "SET @IdReturn = SCOPE_IDENTITY()\n";

			return sql;
		}
		
		private String GetUpdateString()
		{
			String sql = String.Empty;
			
			sql  = "UPDATE \n";
			sql += "	TIMESHEET \n";
			sql += "SET \n";
			sql += "	 [DATE_RG] = @DATE_RG\n";
			sql += "	,[START_AM] = @START_AM\n";
			sql += "	,[END_AM] = @END_AM\n";
			sql += "	,[START_PM] = @START_PM\n";
			sql += "	,[END_PM] = @END_PM\n";
			sql += "	,[DESCRIPTION] = @DESCRIPTION\n";
			sql += "WHERE 1 = 1\n";
			sql += "  AND ([ID_TIMESHEET] = @ID_TIMESHEET OR @ID_TIMESHEET IS NULL)\n";
			sql += "  AND ([DATE_RG] = @DATE_RG OR @DATE_RG IS NULL)\n";
			
			return sql;
		}
		
		
		private String GetDeleteString()
		{
			String sql = String.Empty;
			
			sql = "DELETE FROM  \n";
			sql += "	TIMESHEET \n";
			sql += "WHERE 1 = 1\n";
			sql += "  AND ([ID_TIMESHEET] = @ID_TIMESHEET OR @ID_TIMESHEET IS NULL)\n";
			
			return sql;
		}

		private String GetSelectString()
		{
			String sql = String.Empty;
			
			sql = "SELECT  \n";
			sql += "	[ID_TIMESHEET],\n";
			sql += "	[DATE_RG],\n";
			sql += "	[START_AM],\n";
			sql += "	[END_AM],\n";
			sql += "	[START_PM],\n";
			sql += "	[END_PM],\n";
			sql += "	[DESCRIPTION]\n";
			sql += "FROM   TIMESHEET  WITH (NOLOCK)\n";
			sql += "WHERE 1 = 1\n";
			sql += "  AND ([ID_TIMESHEET] = @ID_TIMESHEET OR @ID_TIMESHEET IS NULL)\n";
			sql += "  AND ([DATE_RG] = @DATE_RG OR @DATE_RG IS NULL)\n";
			sql += "  AND ([START_AM] >= @START_AM OR @START_AM IS NULL)\n";
			sql += "  AND ([END_AM] <= @END_AM OR @END_AM IS NULL)\n";
			sql += "  AND ([START_PM] >= @START_PM OR @START_PM IS NULL)\n";
			sql += "  AND ([END_PM] <= @END_PM OR @END_PM IS NULL)\n";
			sql += "  AND ([DESCRIPTION] = @DESCRIPTION OR @DESCRIPTION IS NULL)\n";
				
			return sql;
		}
	}// Close out the class and namespace
}

