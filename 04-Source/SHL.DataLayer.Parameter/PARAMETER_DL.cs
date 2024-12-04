/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 28/03/2020 02:44:43
**********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using SHL.Base.Base;
using SHL.Data.Base;

using SHL.Syncronism.Model;

namespace SHL.Syncronism.DataLayer
{
	public sealed partial class PARAMETER_DL : BaseDAL<PARAMETER>
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
		/// Select and return all records from table PARAMETER
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
		public PARAMETER Select(String Group, PARAMETER entity)
		{
			return base.ReturnUnique(Group, GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Select some records with a filter
		/// </summary>
		public List<PARAMETER> SelectList(String Group)
		{			
			PARAMETER entity = new PARAMETER();
			
			SQLHelper.Group = Group;
			
			return base.ReturnList(Group, GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Select some records with a filter
		/// </summary>
		public List<PARAMETER> SelectList(String Group, PARAMETER entity)
		{			
			return base.ReturnList(Group, GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Insert a record in the table PARAMETER
		/// </summary>
		public void Insert(String Group, PARAMETER entity)
		{
			SqlTransaction transaction = null;
			
			SQLHelper.Group = Group;
			
			Insert(Group, transaction, entity);
		}

		/// <summary>
		/// Insert a record in the table PARAMETER with transction
		/// </summary>
		public void Insert(String Group, SqlTransaction oSqlTransaction, PARAMETER entity)
		{
			SQLHelper.Group = Group;
			
			SQLHelper.ExecuteNonQuery(GetInsertString(), oSqlTransaction, CreateParameters(entity, false));
		}

		/// <summary>
		/// Update a record in the table PARAMETER
		/// </summary>
		public void Update(String Group, PARAMETER entity)
		{
			SqlTransaction transaction = null;
			
			SQLHelper.Group = Group;
			
			Update(Group, transaction, entity);
		}

		/// <summary>
		/// Update a record in the table PARAMETER with transaction
		/// </summary>
		public void Update(String Group, SqlTransaction oSqlTransaction, PARAMETER entity)
		{
			SQLHelper.Group = Group;
			
			SQLHelper.ExecuteNonQuery(GetUpdateString(), oSqlTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Delete a record from table PARAMETER
		/// </summary>
		public void Delete(String Group, PARAMETER entity)
		{
			SqlTransaction transaction = null;
			
			SQLHelper.Group = Group;

			Delete(Group, transaction, entity);
		}

		/// <summary>
		/// Delete a record from table PARAMETER with transaction
		/// </summary>
		public void Delete(String Group, SqlTransaction oSqlTransaction, PARAMETER entity)
		{
			SQLHelper.Group = Group;
			
			SQLHelper.ExecuteNonQuery(GetDeleteString(), oSqlTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Carrega os Parametros com ou sem ID
		/// </summary>
		private ArrayList CreateParameters(PARAMETER entity, bool pid)
		{
			ArrayList parameters = new ArrayList();

			if (pid) 
			{ 
				SQLHelper.AddParameter(ref parameters, "@KEY", entity.KEY); 
			}

			SQLHelper.AddParameter(ref parameters, "@VALUE", entity.VALUE);

			return parameters;
		}
		
		private String GetInsertString()
		{
			String sql = String.Empty;
			
			sql = "INSERT INTO PARAMETER\n";
			sql +="(\n";
			sql += "	[VALUE]\n";
			sql +=")\n";
			sql += "VALUES\n";
			sql += "(\n";
			sql += "	@VALUE\n";
			sql += ")\n\n";

			sql += "SET @IdReturn = SCOPE_IDENTITY()\n";

			return sql;
		}
		
		private String GetUpdateString()
		{
			String sql = String.Empty;
			
			sql  = "UPDATE \n";
			sql += "	PARAMETER \n";
			sql += "SET \n";
			sql += "	[VALUE] = @VALUE\n";
			sql += "WHERE [KEY] = @KEY\n";
			
			return sql;
		}
		
		
		private String GetDeleteString()
		{
			String sql = String.Empty;
			
			sql = "DELETE FROM  \n";
			sql += "	PARAMETER \n";
			sql += "WHERE [KEY] = @KEY\n";
			
			return sql;
		}

		private String GetSelectString()
		{
			String sql = String.Empty;
			
			sql = "SELECT  \n";
			sql += "	[KEY],\n";
			sql += "	[VALUE]\n";
			sql += "FROM   PARAMETER  WITH (NOLOCK)\n";
			sql += "WHERE 1 = 1\n";
			sql += "  AND ([VALUE] = @VALUE OR @VALUE IS NULL)\n";
				
			return sql;
		}
	}// Close out the class and namespace
}

