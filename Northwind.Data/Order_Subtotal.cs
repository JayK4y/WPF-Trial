//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Northwind.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Subtotal
    {
        public int OrderID { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
