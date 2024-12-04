/**********************************************************
  AUTHOR	: 
  VERSION	: 1.0.0.0
  DATE		: 05/04/2020 13:05:43
**********************************************************/
using System;

namespace SHL.Syncronism.Model
{
    [Serializable]
    public sealed partial class SYNCRONISM
    {
        /// <summary>
        /// 
        /// </summary>
        public String TABLENAME { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Int32 OPERATION { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public String DATA { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DATE_MODIFICATION { get; set; }
    }
}
