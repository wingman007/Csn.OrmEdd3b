namespace Csn.OrmEdd3b.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonsPhones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FamilyName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "PersonId", "dbo.Persons");
            DropIndex("dbo.Phones", new[] { "PersonId" });
            DropTable("dbo.Phones");
            DropTable("dbo.Persons");
        }
    }
}
