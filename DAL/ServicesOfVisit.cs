//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServicesOfVisit
    {
        public int ServicesOfVisitId { get; set; }
        public int Visit { get; set; }
        public int Service { get; set; }
    
        public virtual Service Service1 { get; set; }
        public virtual Visit Visit1 { get; set; }
    }
}
