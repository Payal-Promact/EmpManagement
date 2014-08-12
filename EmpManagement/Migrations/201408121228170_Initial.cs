namespace EmpManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmpName = c.String(),
                        EmpDOJ = c.DateTime(nullable: false),
                        EmpContactNo = c.Long(nullable: false),
                        EmpSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeptID = c.Int(nullable: false),
                        Department_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.Department_ID)
                .Index(t => t.Department_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Department_ID", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_ID" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
