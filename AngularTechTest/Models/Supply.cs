using System;

namespace AngularTechTest.Models
{
    public class Supply
    {
        public int Id { get; set; }
        public string SupplyName { get; set; }
        public string SupplyType { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
    }

    public class EmployeeSupply
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int SupplyId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Status { get; set; } 

       
        public virtual Employee Employee { get; set; }
        public virtual Supply Supply { get; set; }
    }
}