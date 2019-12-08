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
    
    public partial class Klijenti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klijenti()
        {
            this.DodatniTretmaniOcjenes = new HashSet<DodatniTretmaniOcjene>();
            this.Terminis = new HashSet<Termini>();
            this.UslugeOcjenes = new HashSet<UslugeOcjene>();
            this.KlijentiNagrades = new HashSet<KlijentiNagrade>();
            this.KlijentiTakmicenjas = new HashSet<KlijentiTakmicenja>();
        }
    
        public int KlijentID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Nullable<System.DateTime> DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public string Napomena { get; set; }
        public string LozinkaSalt { get; set; }
        public string LozinkaHash { get; set; }
        public string KorisnickoIme { get; set; }
        public Nullable<int> TerminiCount { get; set; }
        public Nullable<bool> Aktivan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DodatniTretmaniOcjene> DodatniTretmaniOcjenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Termini> Terminis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UslugeOcjene> UslugeOcjenes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KlijentiNagrade> KlijentiNagrades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KlijentiTakmicenja> KlijentiTakmicenjas { get; set; }
    }
}