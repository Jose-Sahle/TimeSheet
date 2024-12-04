/**********************************************************
  AUTHOR	: #AUTHOR#
  VERSION	: #VERSION#
  DATE		: #DATETIME#
**********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using SHL.IRetorno.Model;

using #NAMESPACEENTITY#;
using #NAMESPACEDAL#;

namespace #NAMESPACEBLL#
{ 
	public sealed partial class #TABLEWITHOUTPREFIXTABLE##SUFFIXBLL#
	{
		public Boolean ValidateToInsert(#TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# entity, ref List<RETORNO> retornos)
		{
			Boolean ret = true;

			//SHLSTUDIO_USER_AREA_START_1
			//SHLSTUDIO_USER_AREA_END_1
						
			return ret;
		}
				
		public Boolean ValidateToUpdate(#TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# entity, ref List<RETORNO> retornos)
		{
			Boolean ret = true;

			//SHLSTUDIO_USER_AREA_START_2
			//SHLSTUDIO_USER_AREA_END_2
						
			return ret;
		}
	
		/// <summary>
		/// Select all records
		/// </summary>");
		public List<#TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY#> SelectList(String Group)
		{		
			#TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# entity = new #TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY#();
			#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# = new #TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#();
			
			return o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#.SelectList(Group, entity);
		}

		/// <summary>
		/// Select a record by filter
		/// </summary>");
		public #TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# Select(String Group, #TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# entity)
		{		
			#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# = new #TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#();
			
			return o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#.Select(Group, entity);
		}

		/// <summary>
		/// Select some records by filter
		/// </summary>");
		public List<#TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY#> SelectList(String Group, #TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# entity)
		{		
			#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# = new #TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#();
			
			return o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#.SelectList(Group, entity);
		}

		/// <summary>
		/// Insert a record in the table #TABLEWITHOUTPREFIXTABLE#
		/// </summary>");
		public void Insert(String Group, #TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# entity, ref List<RETORNO> retornos)
		{		
			#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# = new #TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#();		   
			
			if (ValidateToInsert(entity, ref retornos))
				o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#.Insert(Group, entity);
						}

		/// <summary>
		/// Insert a record in the table #TABLEWITHOUTPREFIXTABLE# inside a transaction
		/// </summary>");
		public void Insert(String Group, #TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# entity, SqlTransaction oSqlTransaction, ref List<RETORNO> retornos)
		{		
			#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# = new #TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#();

			if (ValidateToInsert(entity, ref retornos))
				o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#.Insert(Group, oSqlTransaction, entity);
			
		}

		/// <summary>
		/// Update a record in the table #TABLEWITHOUTPREFIXTABLE#
		/// </summary>");
		public void Update(String Group, #TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# entity, ref List<RETORNO> retornos)
		{		
			#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# = new #TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#();
			
			if (ValidateToUpdate(entity, ref retornos))
				o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#.Update(Group, entity);
		}

		/// <summary>
		/// Update a record in the table #TABLEWITHOUTPREFIXTABLE# with transaction
		/// </summary>");
		public void Update(String Group, SqlTransaction oSqlTransaction, #TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# entity, ref List<RETORNO> retornos)
		{		
			#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# = new #TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#();
			
			if (ValidateToUpdate(entity, ref retornos))
				o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#.Update(Group, oSqlTransaction, entity);
		}

		/// <summary>
		/// Delete a record from table #TABLEWITHOUTPREFIXTABLE#
		/// </summary>");
		public void Delete(String Group, #TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# entity)
		{		
			#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# = new #TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#();
			
			o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#.Delete(Group, entity);
		}

		/// <summary>
		/// Delete a record from table #TABLEWITHOUTPREFIXTABLE# with transaction
		/// </summary>");
		public void Delete(String Group, SqlTransaction oSqlTransaction, #TABLEWITHOUTPREFIXTABLE##SUFFIXENTITY# entity)
		{		
			#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# = new #TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#();
			
			o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#.Delete(Group, oSqlTransaction, entity);
		}	
	
		public SqlTransaction GetTransaction(String Group)
		{
			SqlTransaction transaction = null;
			
			#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL# = new #TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#();

			transaction = o#TABLEWITHOUTPREFIXTABLE##SUFFIXDAL#.GetTransaction(Group);

			return transaction;
		}			
	}
}