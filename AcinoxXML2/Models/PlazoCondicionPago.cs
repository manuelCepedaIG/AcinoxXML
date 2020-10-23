// ----------------------------------------------------------------------------
// <copyright file="PlazoCondicionPago.cs" company="Intergrupo S.A.">
//     COPYRIGHT(C) 2020, Intergrupo S.A.
// </copyright>
// <author>Sinthia Rodriguez.  - srodriguezv@intergrupo.com.</author>
// <email>srodriguezv@intergrupo.com.</email>
// <date>22/10/2020.</date>
// <summary>Expone las propiedades de la clase..</summary>
// ----------------------------------------------------------------------------

namespace AcinoxXML2.Models
{
    /// <summary>Obtiene o establece las propiedades para la condicion de pago.</summary>        
	/// <author>Sinthia Rodriguez - srodriguezv@intergrupo.com.</author>
	/// <date>22/10/2020</date>
    public class PlazoCondicionPago
    {
		/// <summary>Obtiene o establece la Descripcion.</summary>        
		/// <value>Valor de Descripcion.</value>        
		/// <author>Sinthia Rodriguez - INTERGRUPO\srodriguezv.</author>         
		/// <datetime>22/10/2020.</datetime>
		public string Descripcion { get; set; }

		/// <summary>Obtiene o establece los Dias.</summary>        
		/// <value>Valor de Dias.</value>        
		/// <author>Sinthia Rodriguez - INTERGRUPO\srodriguezv.</author>         
		/// <datetime>22/10/2020.</datetime>
		public int Dias { get; set; }

		/// <summary>Obtiene o establece el Porcentaje.</summary>        
		/// <value>Valor de Porcentaje.</value>        
		/// <author>Sinthia Rodriguez - INTERGRUPO\srodriguezv.</author>         
		/// <datetime>22/10/2020.</datetime>
		public decimal Porcentaje { get; set; }

		/// <summary>Obtiene o establece el CodigoViaPago.</summary>        
		/// <value>Valor de CodigoViaPago.</value>        
		/// <author>Sinthia Rodriguez - INTERGRUPO\srodriguezv.</author>         
		/// <datetime>22/10/2020.</datetime>
		public string CodigoViaPago { get; set; }

		/// <summary>Obtiene o establece el CodigoPlazo.</summary>        
		/// <value>Valor de CodigoPlazo.</value>        
		/// <author>Sinthia Rodriguez - INTERGRUPO\srodriguezv.</author>         
		/// <datetime>22/10/2020.</datetime>
		public string CodigoPlazo { get; set; }

	}
}
