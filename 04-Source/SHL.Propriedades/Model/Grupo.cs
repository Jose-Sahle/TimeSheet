using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHL.Propriedades.Model
{
    /// <summary>
    /// Grupo.
    /// </summary>
    public class GRUPO
    {
        /// <summary>
        /// Gets or sets the nome.
        /// </summary>
        /// <value>The nome.</value>
        public String Nome { get; set; }
        /// <summary>
        /// Gets or sets the propriedades.
        /// </summary>
        /// <value>The propriedades.</value>
        public List<PROPRIEDADE> Propriedades { get; set; }
    }
}
