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
    
    public partial class CompetenceWorker
    {
        public int IdCompetenceWorker { get; set; }
        public int IdWorker { get; set; }
        public int IdCompetence { get; set; }
    
        public virtual Competence Competence { get; set; }
        public virtual Worker Worker { get; set; }
    }
}