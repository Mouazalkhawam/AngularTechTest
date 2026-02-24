namespace AngularTechTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSuppliesAndEmployeeSupplies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeSupplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        SupplyId = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Supplies", t => t.SupplyId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.SupplyId);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplyName = c.String(),
                        SupplyType = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSupplies", "SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.EmployeeSupplies", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeSupplies", new[] { "SupplyId" });
            DropIndex("dbo.EmployeeSupplies", new[] { "EmployeeId" });
            DropTable("dbo.Supplies");
            DropTable("dbo.EmployeeSupplies");
        }
    }
}
