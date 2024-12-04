/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 28/03/2020 02:49:04
**********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using SHL.Base.Base;
using SHL.Data.Base;

using SHL.Project.Model;

namespace SHL.Project.DataLayer
{
	public sealed partial class PROJECT_DL : BaseDAL<PROJECT>
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
		/// Select and return all records from table PROJECT
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
		public PROJECT Select(String Group, PROJECT entity)
		{
			return base.ReturnUnique(Group, GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Select some records with a filter
		/// </summary>
		public List<PROJECT> SelectList(String Group)
		{			
			PROJECT entity = new PROJECT();
			
			SQLHelper.Group = Group;
			
			return base.ReturnList(Group, GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Select some records with a filter
		/// </summary>
		public List<PROJECT> SelectList(String Group, PROJECT entity)
		{			
			return base.ReturnList(Group, GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Insert a record in the table PROJECT
		/// </summary>
		public Int32 Insert(String Group, PROJECT entity)
		{
			SqlTransaction transaction = null;
			
			SQLHelper.Group = Group;
			
			return Insert(Group, transaction, entity);
		}

		/// <summary>
		/// Insert a record in the table PROJECT with transction
		/// </summary>
		public Int32 Insert(String Group, SqlTransaction oSqlTransaction, PROJECT entity)
		{
			SQLHelper.Group = Group;
			
			return Convert.ToInt32(SQLHelper.ExecuteNonQuery(GetInsertString(), oSqlTransaction, CreateParameters(entity, false), "@IdReturn"));
		}

		/// <summary>
		/// Update a record in the table PROJECT
		/// </summary>
		public void Update(String Group, PROJECT entity)
		{
			SqlTransaction transaction = null;
			
			SQLHelper.Group = Group;
			
			Update(Group, transaction, entity);
		}

		/// <summary>
		/// Update a record in the table PROJECT with transaction
		/// </summary>
		public void Update(String Group, SqlTransaction oSqlTransaction, PROJECT entity)
		{
			SQLHelper.Group = Group;
			
			SQLHelper.ExecuteNonQuery(GetUpdateString(), oSqlTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Delete a record from table PROJECT
		/// </summary>
		public void Delete(String Group, PROJECT entity)
		{
			SqlTransaction transaction = null;
			
			SQLHelper.Group = Group;

			Delete(Group, transaction, entity);
		}

		/// <summary>
		/// Delete a record from table PROJECT with transaction
		/// </summary>
		public void Delete(String Group, SqlTransaction oSqlTransaction, PROJECT entity)
		{
			SQLHelper.Group = Group;
			
			SQLHelper.ExecuteNonQuery(GetDeleteString(), oSqlTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Carrega os Parametros com ou sem ID
		/// </summary>
		private ArrayList CreateParameters(PROJECT entity, bool pid)
		{
			ArrayList parameters = new ArrayList();

			SQLHelper.AddParameter(ref parameters, "@ID_PROJECT", entity.ID_PROJECT); 
			SQLHelper.AddParameter(ref parameters, "@START_DT", entity.START_DT);
			SQLHelper.AddParameter(ref parameters, "@END_DT", entity.END_DT);
			SQLHelper.AddParameter(ref parameters, "@NAME", entity.NAME);
			SQLHelper.AddParameter(ref parameters, "@ALIAS", entity.ALIAS);
			SQLHelper.AddParameter(ref parameters, "@DESCRIPTION", entity.DESCRIPTION);

			return parameters;
		}
		
		private String GetInsertString()
		{
			String sql = String.Empty;

			sql = "INSERT INTO PROJECT\n";
			sql += "(\n";
			sql += "	START_DT\n";
			sql += "	,END_DT\n";
			sql += "	,NAME\n";
			sql += "	,ALIAS\n";
			sql += "	,DESCRIPTION\n";
			sql += ")\n";
			sql += "VALUES\n";
			sql += "(\n";
			sql += "	 @START_DT\n";
			sql += "	,@END_DT\n";
			sql += "	,@NAME\n";
			sql += "	,@ALIAS\n";
			sql += "	,@DESCRIPTION\n";
			sql += ")\n\n";

			sql += "SET @IdReturn = SCOPE_IDENTITY()\n";

			return sql;
		}
		
		private String GetUpdateString()
		{
			String sql = String.Empty;

			sql = "UPDATE \n";
			sql += "	PROJECT \n";
			sql += "SET \n";
			sql += "	START_DT = @START_DT\n";
			sql += "	,END_DT = @END_DT\n";
			sql += "	,NAME = @NAME\n";
			sql += "	,ALIAS = @ALIAS\n";
			sql += "	,DESCRIPTION = @DESCRIPTION\n";
			sql += "WHERE ID_PROJECT = @ID_PROJECT\n";

			return sql;
		}
		
		
		private String GetDeleteString()
		{
			String sql = String.Empty;

			sql = "DELETE FROM  \n";
			sql += "	PROJECT \n";
			sql += "WHERE (ID_PROJECT = @ID_PROJECT OR @ID_PROJECT IS NULL) \n";

			return sql;
		}

		private String GetSelectString()
		{
			String sql = String.Empty;

			sql = "SELECT  \n";
			sql += "	ID_PROJECT,\n";
			sql += "	START_DT,\n";
			sql += "	END_DT,\n";
			sql += "	NAME,\n";
			sql += "	ALIAS,\n";
			sql += "	DESCRIPTION\n";
			sql += "FROM   PROJECT  WITH (NOLOCK)\n";
			sql += "WHERE 1 = 1\n";
			sql += "  AND (START_DT = @START_DT OR @START_DT IS NULL)\n";
			sql += "  AND (END_DT = @END_DT OR @END_DT IS NULL)\n";
			sql += "  AND (NAME = @NAME OR @NAME IS NULL)\n";
			sql += "  AND (ALIAS = @ALIAS OR @ALIAS IS NULL)\n";
			sql += "  AND (DESCRIPTION = @DESCRIPTION OR @DESCRIPTION IS NULL)\n";

			return sql;
		}
	}// Close out the class and namespace
}

