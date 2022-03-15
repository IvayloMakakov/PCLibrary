namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.BookCardRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        LibraryCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.LibraryCards", t => t.LibraryCardId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.LibraryCardId);
            
            CreateTable(
                "dbo.LibraryCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookCardRelations", "LibraryCardId", "dbo.LibraryCards");
            DropForeignKey("dbo.BookCardRelations", "BookId", "dbo.Books");
            DropIndex("dbo.BookCardRelations", new[] { "LibraryCardId" });
            DropIndex("dbo.BookCardRelations", new[] { "BookId" });
            DropTable("dbo.LibraryCards");
            DropTable("dbo.BookCardRelations");
            DropTable("dbo.Books");
        }
    }
}
