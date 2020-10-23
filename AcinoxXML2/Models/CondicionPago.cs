// ----------------------------------------------------------------------------
// <copyright file="CondicionPago.cs" company="Intergrupo S.A.">
//     COPYRIGHT(C) 2020, Intergrupo S.A.
// </copyright>
// <author>Sinthia Rodriguez.  - srodriguezv@intergrupo.com.</author>
// <email>srodriguezv@intergrupo.com.</email>
// <date>22/10/2020.</date>
// <summary>Expone las propiedades de la clase..</summary>
// ----------------------------------------------------------------------------

namespace AcinoxXML2.Models
{
	using System.Collections.Generic;

    /// <summary>Obtiene o establece las propiedades para la condicion de pago.</summary>        
	/// <author>Sinthia Rodriguez - srodriguezv@intergrupo.com.</author>
	/// <date>22/10/2020</date>
    public class CondicionPago
    {
		/// <summary>Obtiene o establece el Codigo.</summary>        
		/// <value>Valor de Codigo.</value>        
		/// <author>Sinthia Rodriguez - INTERGRUPO\srodriguezv.</author>         
		/// <datetime>22/10/2020.</datetime>
		public string Codigo { get; set; }

		/// <summary>Obtiene o establece la Descripcion.</summary>        
		/// <value>Valor de Descripcion.</value>        
		/// <author>Sinthia Rodriguez - INTERGRUPO\srodriguezv.</author>         
		/// <datetime>22/10/2020.</datetime>
		public string Descripcion { get; set; }

		/// <summary>Obtiene o establece los Plazos.</summary>        
		/// <value>Valor de Plazos.</value>        
		/// <author>Sinthia Rodriguez - INTERGRUPO\srodriguezv.</author>         
		/// <datetime>22/10/2020.</datetime>
		public List<PlazoCondicionPago> Plazos { get; set; }

	}
}
