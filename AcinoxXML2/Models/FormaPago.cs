﻿/// ----------------------------------------------------------------------------
/// <copyright file="FormaPago.cs" company="Intergrupo S.A.">
///     COPYRIGHT(C) 2020, Intergrupo S.A.
/// </copyright>
/// <author>Manuel Cepeda.  - mcepeda@intergrupo.com.</author>
/// <email>mcepeda@intergrupo.com.</email>
/// <date>15/10/2020.</date>
/// <summary>Expone las propiedades de la clase.</summary>
/// ----------------------------------------------------------------------------

namespace AcinoxXML2.Models
{
    /// <summary>Entidad FormaPago</summary>        
    /// <value>Clase FormaPago.</value>        
    /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
    /// <datetime>15/10/2020.</datetime>
    public class FormaPago
    {
        /// <summary>Propiedad de clase</summary>        
        /// <value>Cod</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Cod { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Desc</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Desc { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Gencart</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public uint Gencart { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Ind1</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Ind1 { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Ind2</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Ind2 { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Numdias</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Numdias { get; set; }
    }
}
