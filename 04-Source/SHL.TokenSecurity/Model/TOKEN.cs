/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 02/12/2018 16:22:04
**********************************************************/
using System;
using System.Data; 
using System.Reflection;
using System.Collections.Generic;

namespace SHL.TokenSecurity.Model
{
    /// <summary>
    /// Token.
    /// </summary>
	[Serializable]
	public sealed partial class TOKEN : BaseModel<TOKEN>
	{
		//Create the Constructors/Destructors methods
		#region [ Constructors/Destructors ]
            /// <summary>
            /// Initializes a new instance of the <see cref="T:SHL.TokenSecurity.Model.TOKEN"/> class.
            /// </summary>
			public TOKEN()
			{
			}
            
            /// <summary>
            /// Initializes a new instance of the <see cref="T:SHL.TokenSecurity.Model.TOKEN"/> class.
            /// </summary>
            /// <param name="reader">Reader.</param>
			public TOKEN(IDataReader reader) : base(reader)
			{
			}
		#endregion

		// Create the class members variables
		#region [ Private Members ]
			Nullable<Int64> _ID_TOKEN;
			String _KEY;
			String _URL;
            String _CREDENCIAL;
            String _NOW;
		#endregion

		#region [ Properties ]
            /// <summary>
            /// Gets or sets the identifier token.
            /// </summary>
            /// <value>The identifier token.</value>
			public Nullable<Int64> ID_TOKEN
            {
				get { return _ID_TOKEN; }
				set { _ID_TOKEN = value; }
			}		
            		
            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            /// <value>The key.</value>
			public String KEY
			{
				get { return _KEY; }
				set { _KEY= value; }
			}		

            /// <summary>
            /// Gets or sets the URL.
            /// </summary>
            /// <value>The URL.</value>
			public String URL
			{
				get { return _URL; }
				set { _URL = value; }
			}		

            /// <summary>
            /// Gets or sets the credencial.
            /// </summary>
            /// <value>The credencial.</value>
			public String CREDENCIAL
			{
				get { return _CREDENCIAL; }
				set { _CREDENCIAL = value; }
			}		

            /// <summary>
            /// Gets or sets the now.
            /// </summary>
            /// <value>The now.</value>
			public String NOW
			{
				get { return _NOW; }
				set { _NOW = value; }
			}	
        #endregion
		
		//SHLSTUDIO_USER_AREA_START_1
		//SHLSTUDIO_USER_AREA_END_1
		
	}
}

