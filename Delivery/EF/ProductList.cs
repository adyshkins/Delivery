//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Delivery.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductList
    {
        public int IDDelivery { get; set; }
        public int IDProduct { get; set; }
        public int ProductQuantity { get; set; }
    
        public virtual Delivery Delivery { get; set; }
        public virtual Product Product { get; set; }
    }
}