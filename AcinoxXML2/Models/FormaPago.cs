using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
