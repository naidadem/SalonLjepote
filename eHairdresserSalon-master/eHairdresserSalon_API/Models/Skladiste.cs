
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace eHairdresserSalon_API.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Skladiste
{

    public int SkladisteID { get; set; }

    public int TretmanID { get; set; }

    public Nullable<int> Kolicina { get; set; }



    public virtual DodatniTretmani DodatniTretmani { get; set; }

}

}
