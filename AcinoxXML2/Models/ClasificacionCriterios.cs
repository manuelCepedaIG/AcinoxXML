// ----------------------------------------------------------------------------
// <copyright file="ClasificacionCriterios.cs" company="Intergrupo S.A.">
//     COPYRIGHT(C) 2020, Intergrupo S.A.
// </copyright>
// <author>Sinthia Rodriguez.  - srodriguezv@intergrupo.com.</author>
// <email>srodriguezv@intergrupo.com.</email>
// <date>16/10/2020.</date>
// <summary>Expone las propiedades de la clase..</summary>
// ----------------------------------------------------------------------------

namespace AcinoxXML2.Models
{
    /// <summary>Obtiene o establece las propiedades para la clasificacion de criterios.</summary>        
	/// <author>Sinthia Rodriguez - srodriguezv@intergrupo.com.</author>
	/// <date>16/10/2020</date>
    public class ClasificacionCriterios
    {
        /// <summary>Obtiene o establece el id.</summary>        
		/// <value>Valor de codcliente.</value>        
		/// <author>Sinthia Rodriguez - INTERGRUPO\srodriguezv.</author>         
		/// <datetime>6/10/2020.</datetime>
        public string Id { get; set; }

        /// <summary>Obtiene o establece el codigo.</summary>        
        /// <value>Valor de codcliente.</value>        
        /// <author>Sinthia Rodriguez - INTERGRUPO\srodriguezv.</author>         
        /// <datetime>6/10/2020.</datetime>
        public string Codigo { get; set; }

        /// <summary>Obtiene o establece las descripciones.</summary>        
		/// <value>Valor de codcliente.</value>        
		/// <author>Sinthia Rodriguez - INTERGRUPO\srodriguezv.</author>         
		/// <datetime>6/10/2020.</datetime>
        public string Descripcion { get; set; }
    }
}
