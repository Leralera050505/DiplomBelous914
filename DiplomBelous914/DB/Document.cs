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
    
    public partial class Document
    {
        public int IdDocument { get; set; }
        public int IdService { get; set; }
        public string DocumentTemplate { get; set; }
    
        public virtual Service Service { get; set; }
    }
}
