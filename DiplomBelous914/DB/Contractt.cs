//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiplomBelous914.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contractt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contractt()
        {
            this.ClientContract = new HashSet<ClientContract>();
        }
    
        public int IdContract { get; set; }
        public string NameContract { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<bool> Activity { get; set; }
        public int IdClient { get; set; }
        public string Report { get; set; }
        public Nullable<decimal> FullCost { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientContract> ClientContract { get; set; }
    }
}