namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Author", c => c.String(nullable: false));
            AddColumn("dbo.Books", "Category", c => c.String());
            AddColumn("dbo.Books", "DateTaken", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "DateReturned", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LibraryCards", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LibraryCards", "FullName", c => c.String());
            DropColumn("dbo.Books", "DateReturned");
            DropColumn("dbo.Books", "DateTaken");
            DropColumn("dbo.Books", "Category");
            DropColumn("dbo.Books", "Author");
        }
    }
}
