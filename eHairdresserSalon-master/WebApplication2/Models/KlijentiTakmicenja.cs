//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KlijentiTakmicenja
    {
        public int KlijentID { get; set; }
        public int TakmicenjeID { get; set; }
        public Nullable<System.DateTime> DatumPrijave { get; set; }
    
        public virtual Klijenti Klijenti { get; set; }
        public virtual Takmicenja Takmicenja { get; set; }
    }
}
