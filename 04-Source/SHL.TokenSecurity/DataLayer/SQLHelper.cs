/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 25/11/2018 13:50:29
**********************************************************/
using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;
using SHL.TokenSecurity;

namespace SHL.TokenSecurity.DataLayer
{
    /// <summary>
    /// SQLH elper.
    /// </summary>
	public static class SQLHelper
	{
		private static String ConnectionString = String.Empty;
		// Time out em minutos COMMAND_TIMEOUT/60.
		private const int COMMAND_TIMEOUT = 60;

		/// <summary>
		/// Get the database transaction
		/// </summary>
		public static SQLiteTransaction GetTransaction()
		{
			SQLiteConnection oConnection = GetConnection();
			SQLiteTransaction oTransaction;

			try 
			{
				OpenDatabase(ref oConnection);
			}
			finally 
			{ 
				oTransaction = oConnection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted); 
			}

			return oTransaction;
		}

		/// <summary>
		/// Retorna a String de Conexo
		/// </summary>
		/// <returns>A conexo configurada.</returns>
		public static String GetConnectionString()
		{
			String connectionstring = String.Empty;

			String curdir = Directory.GetCurrentDirectory();
			
            connectionstring = String.Format("Data Source=App_data/tokensecurity.db; Version = 3", curdir);

            return connectionstring;
        }

		/// <summary>		
		/// Obt??uma conex??para o banco de dados padr??o
		/// </summary>
		public static SQLiteConnection GetConnection()
		{
			return new SQLiteConnection(GetConnectionString());
		}

        /// <summary>
        /// Sets the connection.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
		public static void SetConnection(String connectionString)
		{
			ConnectionString = connectionString;
		}

		#region ExecuteNonQuery functions
			/// <summary>
			/// Execute a stored procedure.
			/// </summary>
			/// <param name="commandText">The stored procedure to execute.</param>
			public static void ExecuteNonQuery(string commandText)
			{
				SQLiteConnection connection = GetConnection();
				ExecuteNonQuery(connection, commandText);
			}

			/// <summary>
			/// Executes the stored procedure on the specified <see cref="SQLiteConnection"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			public static void ExecuteNonQuery(SQLiteConnection connection, String commandText)
			{
				ExecuteNonQuery(connection, null, commandText);
			}

			/// <summary>
			/// Executes the stored procedure on the specified <see cref="SQLiteConnection"/> within the specified <see cref="SQLiteTransaction"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="transaction">The transaction to participate in.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			public static void ExecuteNonQuery(SQLiteConnection connection, SQLiteTransaction transaction, String commandText)
			{
				if (connection.State == ConnectionState.Closed)
				{
					OpenDatabase(ref connection);
				}

				SQLiteCommand command = CreateCommand(connection, transaction, commandText);
				command.ExecuteNonQuery();
			}

			/// <summary>
			/// Executes the stored procedure with the specified parameters.
			/// </summary>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			public static void ExecuteNonQuery(String commandText, ArrayList parameters)
			{
				SQLiteConnection connection = GetConnection();
				ExecuteNonQuery(connection, commandText, parameters);

			}

            /// <summary>
            /// Executes the non query.
            /// </summary>
            /// <param name="commandText">Command text.</param>
            /// <param name="transaction">Transaction.</param>
            /// <param name="parameters">Parameters.</param>
			public static void ExecuteNonQuery(string commandText, SQLiteTransaction transaction, ArrayList parameters)
			{
				SQLiteConnection connection;
				
				if (transaction == null)
					connection = GetConnection();
				else
					connection = transaction.Connection;
					
				ExecuteNonQuery(connection, transaction, commandText, parameters);

			}

			/// <summary>
			/// Executes the stored procedure with the specified parameters on the specified connection.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			public static void ExecuteNonQuery(SQLiteConnection connection, string commandText, ArrayList parameters)
			{
				ExecuteNonQuery(connection, null, commandText, parameters);
			}

			/// <summary>
			/// Executes the stored procedure with the specified parameters on the specified <see cref="SQLiteConnection"/> within the specified <see cref="SQLiteTransaction"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="transaction">The transaction to participate in.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			public static void ExecuteNonQuery(SQLiteConnection connection, SQLiteTransaction transaction, String commandText, ArrayList parameters)
			{
				if (connection.State == ConnectionState.Closed)
				{
					OpenDatabase(ref connection);
				}
				
				SQLiteCommand command = CreateCommand(connection, transaction, commandText, parameters);
				
				command.ExecuteNonQuery();
			}

            /// <summary>
            /// Executes the non query.
            /// </summary>
            /// <returns>The non query.</returns>
            /// <param name="commandText">Command text.</param>
            /// <param name="parameters">Parameters.</param>
            /// <param name="ReturnParameter">Return parameter.</param>
			public static Int64 ExecuteNonQuery(String commandText, ArrayList parameters, String ReturnParameter)
			{
				SQLiteConnection connection = GetConnection();
				
				return ExecuteNonQuery(commandText, parameters, connection, ReturnParameter);
			}

            /// <summary>
            /// Executes the non query.
            /// </summary>
            /// <returns>The non query.</returns>
            /// <param name="commandText">Command text.</param>
            /// <param name="parameters">Parameters.</param>
            /// <param name="connection">Connection.</param>
            /// <param name="ReturnParameter">Return parameter.</param>
			public static Int64 ExecuteNonQuery(String commandText, ArrayList parameters, SQLiteConnection connection, String ReturnParameter)
			{
				Int64 vRetorno = 0;
				SQLiteTransaction transaction = null;

				OpenDatabase(ref connection);
				
				SQLiteCommand command = CreateCommand(connection, transaction, commandText, parameters);

				//SQLiteParameter retVal = command.Parameters.Add(ReturnParameter, DbType.Int32);
				//retVal.Direction = ParameterDirection.Output;
				
				command.ExecuteNonQuery();
				
				//vRetorno = Convert.ToInt32(retVal.Value);
				
				return vRetorno;
			}

            /// <summary>
            /// Executes the non query.
            /// </summary>
            /// <returns>The non query.</returns>
            /// <param name="commandText">Command text.</param>
            /// <param name="transaction">Transaction.</param>
            /// <param name="parameters">Parameters.</param>
            /// <param name="ReturnParameter">Return parameter.</param>
			public static Int64 ExecuteNonQuery(string commandText, SQLiteTransaction transaction, ArrayList parameters, String ReturnParameter)
			{
				Int64 vRetorno = 0;
				SQLiteConnection connection;
				
				if (transaction == null)
				{
					connection = GetConnection();
					
					OpenDatabase(ref connection);
				}
				else
				{
					connection = transaction.Connection;
				}

				SQLiteCommand command = CreateCommand(connection, transaction, commandText, parameters);

				//SQLiteParameter retVal = command.Parameters.Add(ReturnParameter, DbType.Int32);
				//retVal.Direction = ParameterDirection.Output;
				
				//vRetorno = command.ExecuteNonQuery();
				command.ExecuteNonQuery();

				//vRetorno = Convert.ToInt32(retVal.Value);
				
				return vRetorno;
			}

            /// <summary>
            /// Executes the non query.
            /// </summary>
            /// <param name="commandText">Command text.</param>
            /// <param name="transaction">Transaction.</param>
			public static void ExecuteNonQuery(String commandText, SQLiteTransaction transaction)
			{
				SQLiteCommand command = new SQLiteCommand();
				
				command.Connection = transaction.Connection;
				command.CommandText = commandText;
				command.CommandTimeout = COMMAND_TIMEOUT;
				command.CommandType = CommandType.Text;
				command.Transaction = transaction;
				
				command.ExecuteNonQuery();
			}
		#endregion

		#region ExecuteReader functions
			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="SQLiteDataReader"/>.
			/// </summary>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>A <see cref="SQLiteDataReader"/> containing the results of the stored procedure execution.</returns>
			public static SQLiteDataReader ExecuteReader(string commandText)
			{
				SQLiteConnection connection = GetConnection();
				
				OpenDatabase(ref connection);
				
				return ExecuteReader(connection, commandText);
			}

			/// <summary>
			/// Executes the stored procedure on the specified <see cref="SQLiteConnection"/> and returns the result as a <see cref="SQLiteDataReader"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>A <see cref="SQLiteDataReader"/> containing the results of the stored procedure execution.</returns>
			public static SQLiteDataReader ExecuteReader(SQLiteConnection connection, String commandText)
			{
				return ExecuteReader(connection, null, commandText);
			}

			/// <summary>
			/// Executes the stored procedure on the specified <see cref="SQLiteConnection"/> within the specified <see cref="SQLiteTransaction"/> and returns the result as a <see cref="SQLiteDataReader"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="transaction">The transaction to participate in.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>A <see cref="SQLiteDataReader"/> containing the results of the stored procedure execution.</returns>
			public static SQLiteDataReader ExecuteReader(SQLiteConnection connection, SQLiteTransaction transaction, String commandText)
			{
				if (connection.State == ConnectionState.Closed)
				{ 
				OpenDatabase(ref connection); 
				}
				
				SQLiteCommand command = CreateCommand(connection, transaction, commandText);
				
				return command.ExecuteReader(CommandBehavior.CloseConnection);
			}

			/// <summary>
			/// Executes the stored procedure with the specified parameters and returns the result as a <see cref="SQLiteDataReader"/>.
			/// </summary>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>A <see cref="SQLiteDataReader"/> containing the results of the stored procedure execution.</returns>
			public static SQLiteDataReader ExecuteReader(String commandText, ArrayList parameters)
			{
				SQLiteConnection connection = GetConnection();
				
				OpenDatabase(ref connection);
				
				return ExecuteReader(connection, commandText, parameters);
			}

			/// <summary>
			/// Executes the stored procedure on the specified <see cref="SQLiteConnection"/> with the specified parameters and returns the result as a <see cref="SQLiteDataReader"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>A <see cref="SQLiteDataReader"/> containing the results of the stored procedure execution.</returns>
			public static SQLiteDataReader ExecuteReader(SQLiteConnection connection, string commandText, ArrayList parameters)
			{
				return ExecuteReader(connection, null, commandText, parameters);
			}

			/// <summary>
			/// Executes the stored procedure on the specified <see cref="SQLiteConnection"/> within the specified <see cref="SQLiteTransaction"/> with the specified parameters and returns the result as a <see cref="SQLiteDataReader"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="transaction">The transaction to participate in.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>A <see cref="SQLiteDataReader"/> containing the results of the stored procedure execution.</returns>
			public static SQLiteDataReader ExecuteReader(SQLiteConnection connection, SQLiteTransaction transaction, string commandText, ArrayList parameters)
			{
				if (connection.State == ConnectionState.Closed)
				{
					OpenDatabase(ref connection);
				}
				
				SQLiteCommand command = CreateCommand(connection, transaction, commandText, parameters);
				
				return command.ExecuteReader(CommandBehavior.CloseConnection);
			}
		#endregion

		#region ExecuteScalar functions
			/// <summary>
			/// Executes the stored procedure, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.
			/// </summary>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
			public static object ExecuteScalar(string commandText)
			{
				using (SQLiteConnection connection = GetConnection())
				{
					return ExecuteScalar(connection, commandText);
				}
			}

			/// <summary>
			/// Executes the stored procedure on the specified <see cref="SQLiteConnection"/>, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
			public static object ExecuteScalar(SQLiteConnection connection, string commandText)
			{
				return ExecuteScalar(connection, null, commandText);
			}

			/// <summary>
			/// Executes the stored procedure on the specified <see cref="SQLiteConnection"/> within the specified <see cref="SQLiteTransaction"/>, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="transaction">The transaction to participate in.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
			public static object ExecuteScalar(SQLiteConnection connection, SQLiteTransaction transaction, string commandText)
			{
				
				if (connection.State == ConnectionState.Closed)
				{ 
					OpenDatabase(ref connection); 
				}
				
				using (SQLiteCommand command = CreateCommand(connection, transaction, commandText))
				{
					return command.ExecuteScalar();
				}
				
			}

			/// <summary>
			/// Executes the stored procedure with the specified parameters, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.
			/// </summary>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
			public static object ExecuteScalar(string commandText, ArrayList parameters)
			{
				using (SQLiteConnection connection = GetConnection())
				{
					return ExecuteScalar(connection, commandText, parameters);
				}
			}

			/// <summary>
			/// Executes the stored procedure on the specified <see cref="SQLiteTransaction"/> with the specified parameters, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
			public static object ExecuteScalar(SQLiteConnection connection, string commandText, ArrayList parameters)
			{
				return ExecuteScalar(connection, null, commandText, parameters);
			}

			/// <summary>
			/// Executes the stored procedure on the specified <see cref="SQLiteTransaction"/> within the specified <see cref="SQLiteTransaction"/> with the specified parameters, and returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="transaction">The transaction to participate in.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
			public static object ExecuteScalar(SQLiteConnection connection, SQLiteTransaction transaction, string commandText, ArrayList parameters)
			{
				if (connection.State == ConnectionState.Closed)
				{ 
					OpenDatabase(ref connection); 
				}
				
				using (SQLiteCommand command = CreateCommand(connection, transaction, commandText, parameters))
				{
					return command.ExecuteScalar();
				}
			}
		#endregion

		#region ExecuteDataSet functions
			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataSet"/>.
			/// </summary>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>A <see cref="DataSet"/> containing the results of the stored procedure execution.</returns>
			public static DataSet ExecuteDataSet(string commandText)
			{
				using (SQLiteConnection connection = GetConnection())
				{
					using (SQLiteCommand command = CreateCommand(connection, commandText))
					{
						return CreateDataSet(command);
					}
				}
			}

			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataSet"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>A <see cref="DataSet"/> containing the results of the stored procedure execution.</returns>
			public static DataSet ExecuteDataSet(SQLiteConnection connection, string commandText)
			{
				using (SQLiteCommand command = CreateCommand(connection, commandText))
				{
					return CreateDataSet(command);
				}
			}


			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataSet"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="transaction">The transaction to participate in.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>A <see cref="DataSet"/> containing the results of the stored procedure execution.</returns>
			public static DataSet ExecuteDataSet(SQLiteConnection connection, SQLiteTransaction transaction, string commandText)
			{
				using (SQLiteCommand command = CreateCommand(connection, transaction, commandText))
				{
					return CreateDataSet(command);
				}
			}

			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataSet"/>.
			/// </summary>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>A <see cref="DataSet"/> containing the results of the stored procedure execution.</returns>
			public static DataSet ExecuteDataSet(string commandText, ArrayList parameters)
			{
				using (SQLiteConnection connection = GetConnection())
				{
					using (SQLiteCommand command = CreateCommand(connection, commandText, parameters))
					{
						return CreateDataSet(command);
					}
				}
			}

			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataSet"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>A <see cref="DataSet"/> containing the results of the stored procedure execution.</returns>
			public static DataSet ExecuteDataSet(SQLiteConnection connection, string commandText, ArrayList parameters)
			{
				using (SQLiteCommand command = CreateCommand(connection, commandText, parameters))
				{
					return CreateDataSet(command);
				}
			}


			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataSet"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="transaction">The transaction to participate in.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>A <see cref="DataSet"/> containing the results of the stored procedure execution.</returns>
			public static DataSet ExecuteDataSet(SQLiteConnection connection, SQLiteTransaction transaction, string commandText, ArrayList parameters)
			{
				using (SQLiteCommand command = CreateCommand(connection, transaction, commandText, parameters))
				{
					return CreateDataSet(command);
				}
			}
		#endregion

		#region ExecuteDataTable functions
			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataTable"/>.
			/// </summary>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>A <see cref="DataTable"/> containing the results of the stored procedure execution.</returns>
			public static DataTable ExecuteDataTable(string commandText)
			{
				using (SQLiteConnection connection = GetConnection())
				{
					using (SQLiteCommand command = CreateCommand(connection, commandText))
					{
						return CreateDataTable(command);
					}
				}
			}

			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataTable"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>A <see cref="DataTable"/> containing the results of the stored procedure execution.</returns>
			public static DataTable ExecuteDataTable(SQLiteConnection connection, string commandText)
			{
				using (SQLiteCommand command = CreateCommand(connection, commandText))
				{
					return CreateDataTable(command);
				}
			}


			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataTable"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="transaction">The transaction to participate in.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <returns>A <see cref="DataTable"/> containing the results of the stored procedure execution.</returns>
			public static DataTable ExecuteDataTable(SQLiteConnection connection, SQLiteTransaction transaction, string commandText)
			{
				using (SQLiteCommand command = CreateCommand(connection, transaction, commandText))
				{
					return CreateDataTable(command);
				}
			}

			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataTable"/>.
			/// </summary>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>A <see cref="DataTable"/> containing the results of the stored procedure execution.</returns>
			public static DataTable ExecuteDataTable(string commandText, ArrayList parameters)
			{
				using (SQLiteConnection connection = GetConnection())
				{
					using (SQLiteCommand command = CreateCommand(connection, commandText, parameters))
					{
						return CreateDataTable(command);
					}
				}
			}

			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataTable"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>A <see cref="DataTable"/> containing the results of the stored procedure execution.</returns>
			public static DataTable ExecuteDataTable(SQLiteConnection connection, string commandText, ArrayList parameters)
			{
				using (SQLiteCommand command = CreateCommand(connection, commandText, parameters))
				{
					return CreateDataTable(command);
				}
			}


			/// <summary>
			/// Executes the stored procedure and returns the result as a <see cref="DataTable"/>.
			/// </summary>
			/// <param name="connection">The database connection to be used.</param>
			/// <param name="transaction">The transaction to participate in.</param>
			/// <param name="commandText">The stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>A <see cref="DataTable"/> containing the results of the stored procedure execution.</returns>
			public static DataTable ExecuteDataTable(SQLiteConnection connection, SQLiteTransaction transaction, string commandText, ArrayList parameters)
			{
				using (SQLiteCommand command = CreateCommand(connection, transaction, commandText, parameters))
				{
					return CreateDataTable(command);
				}
			}
		#endregion

		#region Utility functions
            /// <summary>
            /// Adds the parameter.
            /// </summary>
            /// <returns>The parameter.</returns>
            /// <param name="vParameter">V parameter.</param>
            /// <param name="oValor">O valor.</param>
			public static ArrayList AddParameter(string vParameter, object oValor)
			{
				vParameter = AddAt(vParameter);
				
				ArrayList parameters = new ArrayList();
				
				parameters.Add(new SQLiteParameter(vParameter, oValor));
				
				return parameters;
			}

            /// <summary>
            /// Adds the parameter.
            /// </summary>
            /// <param name="parameters">Parameters.</param>
            /// <param name="vParameter">V parameter.</param>
            /// <param name="oValor">O valor.</param>
			public static void AddParameter(ref ArrayList parameters, string vParameter, object oValor)
			{
				vParameter = AddAt(vParameter);
				
				parameters.Add(new SQLiteParameter(vParameter, oValor));
			}

			private static string AddAt(string vParameter)
			{
				if (vParameter.Substring(0, 1) != "@")
				{ 
					vParameter.Insert(0, "@"); 
				}
				
				return vParameter;
			}

			private static SQLiteParameter CheckParameter(SQLiteParameter parameter)
			{
				if (parameter.Value == null)
				{
					parameter.Value = DBNull.Value;
				}
				else if ((parameter.DbType == DbType.DateTime ||
							parameter.DbType == DbType.Date ||
							parameter.DbType == DbType.Time
						) && Convert.ToDateTime(parameter.Value) == new DateTime(1900, 1, 1))
				{
					parameter.Value = DBNull.Value;
				}

				return parameter;
			}
		#region CreateCommand
			/// <summary>
			/// Creates, initializes, and returns a <see cref="SQLiteCommand"/> instance.
			/// </summary>
			/// <param name="connection">The <see cref="SQLiteConnection"/> the <see cref="SQLiteCommand"/> should be executed on.</param>
			/// <param name="commandText">The name of the stored procedure to execute.</param>
			/// <returns>An initialized <see cref="SQLiteCommand"/> instance.</returns>
			private static SQLiteCommand CreateCommand(SQLiteConnection connection, string commandText)
			{
				return CreateCommand(connection, null, commandText);
			}

			/// <summary>
			/// Creates, initializes, and returns a <see cref="SQLiteCommand"/> instance.
			/// </summary>
			/// <param name="connection">The <see cref="SQLiteConnection"/> the <see cref="SQLiteCommand"/> should be executed on.</param>
			/// <param name="transaction">The <see cref="SQLiteTransaction"/> the stored procedure execution should participate in.</param>
			/// <param name="commandText">The name of the stored procedure to execute.</param>
			/// <returns>An initialized <see cref="SQLiteCommand"/> instance.</returns>
			private static SQLiteCommand CreateCommand(SQLiteConnection connection, SQLiteTransaction transaction, string commandText)
			{
				SQLiteCommand command = new SQLiteCommand();
				
				command.Connection = connection;
				command.CommandText = commandText;
				command.CommandTimeout = COMMAND_TIMEOUT;
				
				command.CommandType = CommandType.Text;
					
				command.Transaction = transaction;
				
				return command;
			}

			/// <summary>
			/// Creates, initializes, and returns a <see cref="SQLiteCommand"/> instance.
			/// </summary>
			/// <param name="connection">The <see cref="SQLiteConnection"/> the <see cref="SQLiteCommand"/> should be executed on.</param>
			/// <param name="commandText">The name of the stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>An initialized <see cref="SQLiteCommand"/> instance.</returns>
			private static SQLiteCommand CreateCommand(SQLiteConnection connection, string commandText, ArrayList parameters)
			{
				return CreateCommand(connection, null, commandText, parameters);
			}

			/// <summary>
			/// Creates, initializes, and returns a <see cref="SQLiteCommand"/> instance.
			/// </summary>
			/// <param name="connection">The <see cref="SQLiteConnection"/> the <see cref="SQLiteCommand"/> should be executed on.</param>
			/// <param name="transaction">The <see cref="SQLiteTransaction"/> the stored procedure execution should participate in.</param>
			/// <param name="commandText">The name of the stored procedure to execute.</param>
			/// <param name="parameters">The parameters of the stored procedure.</param>
			/// <returns>An initialized <see cref="SQLiteCommand"/> instance.</returns>
			private static SQLiteCommand CreateCommand(SQLiteConnection connection, SQLiteTransaction transaction, string commandText, ArrayList parameters)
			{
				SQLiteCommand command = new SQLiteCommand();
				
				command.Connection = connection;
				command.CommandText = commandText;
				command.CommandTimeout = COMMAND_TIMEOUT;
				command.CommandType = CommandType.Text;
				command.Transaction = transaction;

				// Append each parameter to the command
				foreach (SQLiteParameter parameter in parameters)
				{
					command.Parameters.Add(CheckParameter(parameter));

				}

				return command;
			}
		#endregion CreateCommand

		private static DataSet CreateDataSet(SQLiteCommand command)
		{
			using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command))
			{
				DataSet dataSet = new DataSet();
				
				dataAdapter.Fill(dataSet);
				
				return dataSet;
			}
		}

		private static DataTable CreateDataTable(SQLiteCommand command)
		{
			using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command))
			{
				DataTable dataTable = new DataTable();
				
				dataAdapter.Fill(dataTable);
				
				return dataTable;
			}
		}

		private static void OpenDatabase(ref SQLiteConnection connection)
		{
			Int32 nTry = 0;
			while (true)
			{
				try
				{
					connection.Open();
					
					break;
				}
				catch (SQLiteException sex)
				{
					nTry++;

					if (nTry > 10)
						throw sex;
				}
				catch (Exception ex)
				{
					nTry++;

					if (nTry > 10)
						throw ex;
				}

				Thread.Sleep(2000);
			}
		}
		#endregion

		#region Exception functions
			/// <summary>
			/// Determines if the specified exception is the result of a foreign key violation.
			/// </summary>
			/// <param name="e">The exception to check.</param>
			/// <returns><code>true</code> if the exception is a foreign key violation, otherwise <code>false</code>.</returns>
			public static bool IsForeignKeyContraintException(Exception e)
			{
				SQLiteException sqlex = e as SQLiteException;
				
				if (sqlex != null && sqlex.ErrorCode == 547)
				{
					return true;
				}

				return false;
			}

			/// <summary>
			/// Determines if the specified exception is the result of a unique constraint violation.
			/// </summary>
			/// <param name="e">The exception to check.</param>
			/// <returns><code>true</code> if the exception is a unique constraint violation, otherwise <code>false</code>.</returns>
			public static bool IsUniqueConstraintException(Exception e)
			{
				SQLiteException sqlex = e as SQLiteException;
				
				if (sqlex != null && (sqlex.ErrorCode == 2627 || sqlex.ErrorCode == 2601))
				{
					return true;
				}

				return false;
			}
		#endregion
	}
}



