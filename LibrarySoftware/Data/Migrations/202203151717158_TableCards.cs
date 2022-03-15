namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableCards : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LibraryCards", "EGN", c => c.String(nullable: false));
            AddColumn("dbo.LibraryCards", "Email", c => c.String());
            AddColumn("dbo.LibraryCards", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.LibraryCards", "ExpirationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LibraryCards", "ExpirationDate");
            DropColumn("dbo.LibraryCards", "DateCreated");
            DropColumn("dbo.LibraryCards", "Email");
            DropColumn("dbo.LibraryCards", "EGN");
        }
    }
}
