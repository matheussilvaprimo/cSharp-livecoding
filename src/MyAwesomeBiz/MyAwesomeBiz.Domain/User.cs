using System;
using System.Collections.Generic;

namespace MyAwesomeBiz.Domain
{
    public class User : BaseEntity
    {
        public string FullName {get; set;}
        public string FullAddress {get; set;}
        public string UserName {get; set;}
        public string Email {get; set;}
        public int Age {get; set;}
        public DateTime DateOfBirth {get; set;}
        public DateTime CreationDate {get; set;}   
        public List<Order> Orders {get;set;}     
    }
}
