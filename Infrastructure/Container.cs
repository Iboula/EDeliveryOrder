//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class Container
    {
        public int ContainerID { get; set; }
        public Nullable<int> BadID { get; set; }
        public string ContainerNumber { get; set; }
        public Nullable<int> ContainerSize { get; set; }
        public string ContainerType { get; set; }
        public Nullable<decimal> ContainerTare { get; set; }
        public Nullable<decimal> CargoWeight { get; set; }
    
        public virtual Bad Bad { get; set; }
    }
}
