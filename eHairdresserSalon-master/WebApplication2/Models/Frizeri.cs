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
    
    public partial class Frizeri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Frizeri()
        {
            this.DodatniTretmaniOcjenes = new HashSet<DodatniTretmaniOcjene>();
            this.Takmicenjas = new HashSet<Takmicenja>();
            this.Terminis = new HashSet<Termini>();
            this.UslugeOcjenes = new HashSet<UslugeOcjene>();
        }
    
        public int FrizerID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public byte[] ProfilnaSlika { get; set; }
        public string LozinkaSalt { get; set; }
        public string LozinkaHash { get; set; }
        public byte[] SlikaThumb { get; set; }
        public string Opis { get; set; }
        public Nullable<int> VrstaUslugeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DodatniTretmaniOcjene> DodatniTretmaniOcjenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Takmicenja> Takmicenjas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Termini> Terminis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UslugeOcjene> UslugeOcjenes { get; set; }
        public virtual VrsteUsluga VrsteUsluga { get; set; }
    }
}
