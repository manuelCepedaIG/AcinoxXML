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
    /// <summary>Entidad Sociedad</summary>        
    /// <value>Clase Sociedad.</value>        
    /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
    /// <datetime>15/10/2020.</datetime>
    public class Sociedad
    {
        /// <summary>Propiedad de clase</summary>        
        /// <value>Cod</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Cod { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Razons</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Razons { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Nif</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Nif { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Codmoneda</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Codmoneda { get; set; }
    }
}
