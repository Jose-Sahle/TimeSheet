﻿/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 02/12/2018 16:22:03
**********************************************************/
using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Reflection;
using System.Data.SqlClient;

namespace SHL.TokenSecurity.Model
{
    /// <summary>
    /// Base model.
    /// </summary>
	public abstract class BaseModel<T>
	{
		#region [ Constructors ] 
            /// <summary>
            /// Initializes a new instance of the <see cref="T:SHL.TokenSecurity.Model.BaseModel`1"/> class.
            /// </summary>
			public BaseModel()
			{
			}

            /// <summary>
            /// Initializes a new instance of the <see cref="T:SHL.TokenSecurity.Model.BaseModel`1"/> class.
            /// </summary>
            /// <param name="dataReader">Data reader.</param>
			public BaseModel(IDataReader dataReader)
			{
				this.LoadProperties(dataReader);
			}
		#endregion

		#region [ Load Methods]
			private void LoadProperties(IDataReader dataReader)
			{
				try
				{
					//map all class properties
					PropertyInfo[] properties = this.GetType().GetProperties();
					
					//map the fields inside the DataReader
					string[] fieldsDr = new string[dataReader.FieldCount + 1];
					for (int i = 0; i <= dataReader.FieldCount - 1; i++)
					{
						fieldsDr[i] = dataReader.GetName(i);
					}

					foreach (PropertyInfo propertyInfo in properties)
					{
						if (propertyInfo.PropertyType.IsClass & propertyInfo.PropertyType.Namespace == typeof(T).Namespace)
						{
							object child = null;
							
							child = Activator.CreateInstance(propertyInfo.PropertyType, dataReader);
							propertyInfo.SetValue(this, child, null);
						}
						else
						{						
							if (Array.IndexOf(fieldsDr, propertyInfo.Name) >= 0)
							{						
								if (!dataReader[propertyInfo.Name].Equals(System.DBNull.Value))
								{
									try
									{
										propertyInfo.SetValue(this, dataReader[propertyInfo.Name], null);
									}
									catch (ArgumentException)
									{
										//verifica se o campo foi preenchido com espa??os em branco.
										if (!string.IsNullOrEmpty(dataReader[propertyInfo.Name].ToString()))
										{
											propertyInfo.SetValue(this, Convert.ChangeType(dataReader[propertyInfo.Name], propertyInfo.PropertyType), null);
										}
									}
								}
								else if (propertyInfo.PropertyType.Equals(typeof(string)))
								{
									//seta todas as string n??o preenchidas, para evitar null
									propertyInfo.SetValue(this, string.Empty, null);
								}
							}
						}

					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		#endregion
	}
}
