/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 02/12/2018 16:22:03
**********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

using SHL.TokenSecurity.Model;

namespace SHL.TokenSecurity.DataLayer
{
    /// <summary>
    /// Token dl.
    /// </summary>
	public sealed partial class TOKEN_DL : BaseDAL<TOKEN>
	{	
		/// <summary>
		/// Select a record with a filter
		/// </summary>
		public TOKEN Select(TOKEN entity)
		{
			return base.ReturnUnique(GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Select some records with a filter
		/// </summary>
		public List<TOKEN> SelectList(TOKEN entity)
		{
			return base.ReturnList(GetSelectString(), CreateParameters(entity, true));
		}

		/// <summary>
		/// Insert a record in the table MOTOR_TRANSACAO_MP
		/// </summary>
		public Int32 Insert(TOKEN entity)
		{
            SQLiteTransaction transaction = null;
			
			return Insert(entity, transaction);
		}

		/// <summary>
		/// Insert a record in the table MOTOR_TRANSACAO_MP with transction
		/// </summary>
		public Int32 Insert(TOKEN entity, SQLiteTransaction oSQLiteTransaction)
		{
			return Convert.ToInt32(SQLHelper.ExecuteNonQuery(GetInsertString(), oSQLiteTransaction, CreateParameters(entity, false), "@IdReturn"));
		}

		/// <summary>
		/// Update a record in the table MOTOR_TRANSACAO_MP
		/// </summary>
		public void Update(TOKEN entity)
		{
			SQLiteTransaction transaction = null;
			
			Update(transaction, entity);
		}

		/// <summary>
		/// Update a record in the table MOTOR_TRANSACAO_MP with transaction
		/// </summary>
		public void Update(SQLiteTransaction oSQLiteTransaction, TOKEN entity)
		{
			SQLHelper.ExecuteNonQuery(GetUpdateString(), oSQLiteTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Delete a record from table MOTOR_TRANSACAO_MP
		/// </summary>
		public void Delete(TOKEN entity)
		{
			SQLiteTransaction transaction = null;

			Delete(transaction, entity);
		}

		/// <summary>
		/// Delete a record from table MOTOR_TRANSACAO_MP with transaction
		/// </summary>
		public void Delete(SQLiteTransaction oSQLiteTransaction, TOKEN entity)
		{
			SQLHelper.ExecuteNonQuery(GetDeleteString(), oSQLiteTransaction, CreateParameters(entity, true));
		}

		/// <summary>
		/// Carrega os Parametros com ou sem ID
		/// </summary>
		private ArrayList CreateParameters(TOKEN entity, bool pid)
		{
			ArrayList parameters = new ArrayList();

			if (pid) 
			{ 
				SQLHelper.AddParameter(ref parameters, "@ID_TOKEN", entity.ID_TOKEN); 
			}

			SQLHelper.AddParameter(ref parameters, "@KEY", entity.KEY);
			SQLHelper.AddParameter(ref parameters, "@URL", entity.URL);
            SQLHelper.AddParameter(ref parameters, "@CREDENCIAL", entity.CREDENCIAL);
            SQLHelper.AddParameter(ref parameters, "@NOW", entity.NOW);

			return parameters;
		}
		
		private String GetInsertString()
		{
			String sql = String.Empty;
			
			sql = "INSERT INTO TOKEN\n";
			sql +="(\n";
			sql += "	[KEY]\n";
			sql += "	,[URL]\n";
            sql += "	,[CREDENCIAL]\n";
            sql += "	,[NOW]\n";
			sql +=")\n";
			sql += "VALUES\n";
			sql += "(\n";
			sql += "	 @KEY\n";
			sql += "	,@URL\n";
            sql += "	,@CREDENCIAL\n";
            sql += "	,@NOW\n";
			sql += ");\n\n";
	
			return sql;
		}
		
		private String GetUpdateString()
		{
			String sql = String.Empty;
			
			sql  = "UPDATE \n";
			sql += "	TOKEN \n";
			sql += "SET \n";
			sql += "	[KEY] = @KEY\n";
			sql += "	,[URL] = @URL\n";
            sql += "	,[CREDENCIAL] = @CREDENCIAL\n";
            sql += "	,[NOW] = @NOW\n";
			sql += "WHERE [ID_TOKEN] = @ID_TOKEN\n";
			
			return sql;
		}
		
		
		private String GetDeleteString()
		{
			String sql = String.Empty;
			
			sql = "DELETE FROM  \n";
			sql += "	TOKEN \n";
			sql += "WHERE [ID_TOKEN] = @ID_TOKEN\n";
			
			return sql;
		}

		private String GetSelectString()
		{
			String sql = String.Empty;
			
			sql = "SELECT  \n";
			sql += "	[ID_TOKEN],\n";
			sql += "	[KEY],\n";
			sql += "	[URL],\n";
            sql += "	[CREDENCIAL],\n";
            sql += "	[NOW]\n";
			sql += "FROM   TOKEN \n";
			sql += "WHERE 1 = 1\n";
            sql += "  AND ([ID_TOKEN] = @ID_TOKEN OR @ID_TOKEN IS NULL)\n";
            sql += "  AND ([KEY] = @KEY OR @KEY IS NULL)\n";
            sql += "  AND ([CREDENCIAL] = @CREDENCIAL OR @CREDENCIAL IS NULL)\n";
            sql += "  AND ([URL] = @URL OR @URL IS NULL)\n";
				
			return sql;
		}
	}// Close out the class and namespace
}

