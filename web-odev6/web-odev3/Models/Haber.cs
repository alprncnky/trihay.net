//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web_odev3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Haber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Haber()
        {
            this.Yorum1 = new HashSet<Yorum1>();
        }
    
        public int HaberID { get; set; }
        public byte[] haber_resmi { get; set; }
        public string haber_yazisi { get; set; }
        public Nullable<int> haber_turu { get; set; }
        public string haber_baslik { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum1> Yorum1 { get; set; }
    }
}
