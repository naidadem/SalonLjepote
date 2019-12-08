
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
    
public partial class DodatniTretmani
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public DodatniTretmani()
    {

        this.Termini = new HashSet<Termini>();

        this.DodatniTretmaniOcjene = new HashSet<DodatniTretmaniOcjene>();

        this.Skladiste = new HashSet<Skladiste>();

    }


    public int TretmanID { get; set; }

    public string NazivTretmana { get; set; }

    public int Cijena { get; set; }

    public string Opis { get; set; }

    public int VrstaUslugeID { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Termini> Termini { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DodatniTretmaniOcjene> DodatniTretmaniOcjene { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Skladiste> Skladiste { get; set; }

    public virtual VrsteUsluga VrsteUsluga { get; set; }

}

}
