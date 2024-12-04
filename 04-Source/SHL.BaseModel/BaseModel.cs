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
using SHL.Types;

namespace SHL.Data.Base
{
    public abstract class BaseModel<T>
    {
        #region [ Constructors ] 
        public BaseModel()
        {
        }

        public BaseModel(IDataReader dataReader)
        {
            this.LoadProperties(dataReader);
        }
        #endregion

        #region [ Load Methods]
        private void LoadProperties(IDataReader dataReader)
        {
            String columnname = String.Empty;
            
            try
            {
                //map all class properties
                PropertyInfo[] properties = this.GetType().GetProperties();

                //map the fields inside the DataReader
                string[] fieldsDr = new string[dataReader.FieldCount + 1];
                for (int i = 0; i <= dataReader.FieldCount - 1; i++)
                {
                    fieldsDr[i] = dataReader.GetName(i).ToUpper();
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
                        if (Array.IndexOf(fieldsDr, propertyInfo.Name.ToUpper()) >= 0)
                        {
                            columnname = propertyInfo.Name;
                            if (!dataReader[propertyInfo.Name].Equals(System.DBNull.Value))
                            {
                                try
                                {
                                    propertyInfo.SetValue(this, dataReader[propertyInfo.Name], null);
                                }
                                catch (ArgumentException ex)
                                {
                                    if (ex.HResult == -2147024809)
                                    {
                                        propertyInfo.SetValue(this, dataReader[propertyInfo.Name].ToString(), null);
                                    }
                                    else
                                    //verifica se o campo foi preenchido com espaços em branco.
                                    if (!string.IsNullOrEmpty(dataReader[propertyInfo.Name].ToString()))
                                    {
                                        propertyInfo.SetValue(this, Convert.ChangeType(dataReader[propertyInfo.Name], propertyInfo.PropertyType), null);
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                String msg = String.Format("Coluna: {0}", columnname);
                IRetornoException irex = new IRetornoException(msg, ex);
                irex.Trace = ex.Message;
                irex.Dt = DateTime.Now;
                irex.Status = "2";
                throw irex;
            }
        }
        #endregion
    }
}
