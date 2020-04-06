using System;

namespace MyAwesomeBiz.Domain
{
    public class Order : BaseEntity
    {
        public virtual User Buyer {get;set;}
        public string Details {get;set;}
        public DateTime PurchaseDate {get;set;}
    }
}