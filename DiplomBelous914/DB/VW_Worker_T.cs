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
    
    public partial class VW_Worker_T
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string NameGender { get; set; }
        public string NamePost { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string NameEducation { get; set; }
        public System.DateTime StartStudy { get; set; }
        public System.DateTime EndStudy { get; set; }
        public string Diploma { get; set; }
        public int IdWorker { get; set; }
        public Nullable<int> IdGender { get; set; }
        public Nullable<int> IdPassword { get; set; }
        public Nullable<int> IdPost { get; set; }
    }
}
