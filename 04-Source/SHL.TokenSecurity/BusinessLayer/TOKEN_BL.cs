/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 02/12/2018 16:22:03
**********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

using SHL.IRetorno.Model;

using SHL.TokenSecurity.Model;
using SHL.TokenSecurity.DataLayer;

namespace SHL.TokenSecurity.Business
{ 
    /// <summary>
    /// Token bl.
    /// </summary>
	public sealed partial class TOKEN_BL
	{
        /// <summary>
        /// Validates to insert.
        /// </summary>
        /// <returns><c>true</c>, if to insert was validated, <c>false</c> otherwise.</returns>
        /// <param name="entity">Entity.</param>
        /// <param name="retornos">Retornos.</param>
		public Boolean ValidateToInsert(TOKEN entity, ref List<RETORNO> retornos)
		{
			Boolean ret = true;

			//SHLSTUDIO_USER_AREA_START_1
			//SHLSTUDIO_USER_AREA_END_1
						
			return ret;
		}
				
        /// <summary>
        /// Validates to update.
        /// </summary>
        /// <returns><c>true</c>, if to update was validated, <c>false</c> otherwise.</returns>
        /// <param name="entity">Entity.</param>
        /// <param name="retornos">Retornos.</param>
		public Boolean ValidateToUpdate(TOKEN entity, ref List<RETORNO> retornos)
		{
			Boolean ret = true;

			//SHLSTUDIO_USER_AREA_START_2
			//SHLSTUDIO_USER_AREA_END_2
						
			return ret;
		}
	
		/// <summary>
		/// Select all records
		/// </summary>");
		public List<TOKEN> SelectList()
		{		
			TOKEN entity = new TOKEN();
			TOKEN_DL oTOKEN_DL = new TOKEN_DL();

			return oTOKEN_DL.SelectList(entity);
		}

		/// <summary>
		/// Select a record by filter
		/// </summary>");
		public TOKEN Select(TOKEN entity)
		{		
			TOKEN_DL oTOKEN_DL = new TOKEN_DL();

            return oTOKEN_DL.Select(entity);
		}

		/// <summary>
		/// Select some records by filter
		/// </summary>");
		public List<TOKEN> SelectList(TOKEN entity)
		{		
			TOKEN_DL oTOKEN_DL = new TOKEN_DL();
			
			return oTOKEN_DL.SelectList(entity);
		}

		/// <summary>
		/// Insert a record in the table TOKEN
		/// </summary>");
		public Int32 Insert(TOKEN entity, ref List<RETORNO> retornos)
		{		
			TOKEN_DL oTOKEN_DL = new TOKEN_DL();		   
			Int32 id = 0;

            if (ValidateToInsert(entity, ref retornos))
				id = oTOKEN_DL.Insert(entity);
				
			return id;
		}

		/// <summary>
		/// Insert a record in the table TOKEN inside a transaction
		/// </summary>");
		public Int32 Insert(TOKEN entity, SQLiteTransaction oSqlTransaction, ref List<RETORNO> retornos)
		{		
			TOKEN_DL oTOKEN_DL = new TOKEN_DL();
			Int32 id = 0;

            if (ValidateToInsert(entity, ref retornos))
				id = oTOKEN_DL.Insert(entity, oSqlTransaction);
			
			return id; 
		}

		/// <summary>
		/// Update a record in the table TOKEN
		/// </summary>");
		public void Update(TOKEN entity, ref List<RETORNO> retornos)
		{		
			TOKEN_DL oTOKEN_DL = new TOKEN_DL();

            if (ValidateToUpdate(entity, ref retornos))
				oTOKEN_DL.Update(entity);
		}

		/// <summary>
		/// Update a record in the table TOKEN with transaction
		/// </summary>");
		public void Update(SQLiteTransaction oSqlTransaction, TOKEN entity, ref List<RETORNO> retornos)
		{		
			TOKEN_DL oTOKEN_DL = new TOKEN_DL();

            if (ValidateToUpdate(entity, ref retornos))
				oTOKEN_DL.Update(oSqlTransaction, entity);
		}

		/// <summary>
		/// Delete a record from table TOKEN
		/// </summary>");
		public void Delete(TOKEN entity)
		{		
			TOKEN_DL oTOKEN_DL = new TOKEN_DL();

            oTOKEN_DL.Delete(entity);
		}

		/// <summary>
		/// Delete a record from table TOKEN with transaction
		/// </summary>");
		public void Delete(SQLiteTransaction oSqlTransaction, TOKEN entity)
		{		
			TOKEN_DL oTOKEN_DL = new TOKEN_DL();

            oTOKEN_DL.Delete(oSqlTransaction, entity);
		}	
	
        /// <summary>
        /// Gets the transaction.
        /// </summary>
        /// <returns>The transaction.</returns>
		public SQLiteTransaction GetTransaction()
		{
			SQLiteTransaction transaction = null;
			
			TOKEN_DL oTOKEN_DL = new TOKEN_DL();

			transaction = oTOKEN_DL.GetTransaction();

			return transaction;
		}        
	}
}
