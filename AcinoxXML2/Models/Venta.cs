/// ----------------------------------------------------------------------------
/// <copyright file="Sociedad.cs" company="Intergrupo S.A.">
///     COPYRIGHT(C) 2020, Intergrupo S.A.
/// </copyright>
/// <author>Manuel Cepeda.  - mcepeda@intergrupo.com.</author>
/// <email>mcepeda@intergrupo.com.</email>
/// <date>15/10/2020.</date>
/// <summary>Expone las propiedades de la clase.</summary>
/// ----------------------------------------------------------------------------

using System;

namespace AcinoxXML2.Models
{
    /// <summary>Entidad Venta</summary>        
    /// <value>Clase Venta.</value>        
    /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
    /// <datetime>27/10/2020.</datetime>
    public class Venta
    {
        /// <summary>Propiedad de clase</summary>        
        /// <value>CodCli</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>27/10/2020.</datetime>
        public string CodCli { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Anio</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>27/10/2020.</datetime>
        public int Anio { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Mes</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>27/10/2020.</datetime>
        public uint Mes { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Importe</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>27/10/2020.</datetime>
        public decimal Importe { get; set; }
    }
}
