/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 07/03/2019 21:26:05
**********************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using SHL.Data.Base;
using SHL.Task.Model;

namespace SHL.TimeSheet.Model
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public sealed partial class TIMESHEET : BaseModel<TIMESHEET>
	{
		
		//Create the Constructors/Destructors methods
		#region [ Constructors/Destructors ]
		/// <summary>
		/// 
		/// </summary>
		public TIMESHEET()
		{
			TASKS = new List<TASK>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="reader"></param>
		public TIMESHEET(IDataReader reader) : base(reader)
		{
			TASKS = new List<TASK>();
		}
		#endregion

		// Create the class members variables
		#region [ Private Members ]
		Nullable<Int32> _id_timesheet;
		Nullable<DateTime> _date_rg;
		Nullable<DateTime> _date_rg_end;
		Nullable<TimeSpan> _start_am;
		Nullable<TimeSpan> _end_am;
		Nullable<TimeSpan> _start_pm;
		Nullable<TimeSpan> _end_pm;
		String _description;
		#endregion

		#region [ Properties ]
		/// <summary>
		/// 
		/// </summary>
		public Nullable<Int32> ID_TIMESHEET
		{
			get { return _id_timesheet; }
			set { _id_timesheet = value; }
		}		
			
		/// <summary>
		/// 
		/// </summary>
		public Nullable<DateTime> DATE_RG
		{
			get { return _date_rg; }
			set { _date_rg = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public Nullable<DateTime> DATE_RG_END
		{
			get { return _date_rg_end; }
			set { _date_rg_end = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public Nullable<TimeSpan> START_AM
		{
			get { return _start_am; }
			set { _start_am = value; }
		}	
		
		/// <summary>
		/// 
		/// </summary>
		public Nullable<TimeSpan> END_AM
		{
			get { return _end_am; }
			set { _end_am = value; }
		}	
		
		/// <summary>
		/// 
		/// </summary>
		public Nullable<TimeSpan> START_PM
		{
			get { return _start_pm; }
			set { _start_pm = value; }
		}	
		
		/// <summary>
		/// 
		/// </summary>
		public Nullable<TimeSpan> END_PM
		{
			get { return _end_pm; }
			set { _end_pm = value; }
		}	
		
		/// <summary>
		/// 
		/// </summary>
		public String DESCRIPTION
		{
			get { return _description; }
			set { _description = value; }
		}	
		
		/// <summary>
		/// 
		/// </summary>
		public List<TASK> TASKS { get; set; }
		#endregion
		
		//SHLSTUDIO_USER_AREA_START_1
		//SHLSTUDIO_USER_AREA_END_1		
	}
}

