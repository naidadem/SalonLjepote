
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
    
public partial class VrsteUsluga
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public VrsteUsluga()
    {

        this.DodatniTretmani = new HashSet<DodatniTretmani>();

        this.Usluge = new HashSet<Usluge>();

        this.Frizeri = new HashSet<Frizeri>();

    }


    public int VrstaUslugeID { get; set; }

    public string Naziv { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DodatniTretmani> DodatniTretmani { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Usluge> Usluge { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Frizeri> Frizeri { get; set; }

}

}
