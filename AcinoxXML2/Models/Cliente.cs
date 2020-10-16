using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcinoxXML2.Models
{
    /// <summary>Entidad Cliente</summary>        
    /// <value>Clase cliente.</value>        
    /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
    /// <datetime>15/10/2020.</datetime>
    public class Cliente
    {
        /// <summary>Propiedad de clase</summary>        
        /// <value>Cod</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Cod { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Nif</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Nif { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Razons</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Razons { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Codcondp</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Codcondp { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Limitrg</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public decimal Limitrg { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Prov</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Prov { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Criterio1_ZONA</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Criterio1_ZONA { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Criterio2_SUBZONA</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Criterio2_SUBZONA { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Lrcomp</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public UInt32 Lrcomp { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Viasp</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Viasp { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>ClasifContable</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string ClasifContable { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Lsegcredito</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public decimal Lsegcredito { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Fchcadsegcred</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public DateTime Fchcadsegcred { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Tipoentidad</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Tipoentidad { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Sector</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Sector { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Fchaltaerp</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public DateTime Fchaltaerp { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Fchinitact</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public DateTime Fchinitact { get; set; }

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
        /// <value>Ind3</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Ind3 { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Ind4</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Ind4 { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Ind5</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Ind5 { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Ind6</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Ind6 { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Ind7</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Ind7 { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Ind8</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Ind8 { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>Ind9</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string Ind9 { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>TieneAval</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string TieneAval { get; set; }

        /// <summary>Propiedad de clase</summary>        
        /// <value>TipoAval</value>        
        /// <author>Manuel Cepeda - INTERGRUPO\mcepeda.</author>         
        /// <datetime>15/10/2020.</datetime>
        public string TipoAval { get; set; }
    }
}
