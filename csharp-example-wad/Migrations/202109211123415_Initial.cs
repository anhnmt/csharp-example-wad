namespace csharp_example_wad.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 255, unicode: false),
                        FullName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Gender = c.Boolean(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.Id, unique: true, name: "Id")
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.CustomerTypes",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "TypeId", "dbo.CustomerTypes");
            DropIndex("dbo.Customers", new[] { "TypeId" });
            DropIndex("dbo.Customers", "Id");
            DropTable("dbo.CustomerTypes");
            DropTable("dbo.Customers");
        }
    }
}
