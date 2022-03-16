namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "DateTaken", c => c.DateTime());
            AlterColumn("dbo.Books", "DateReturned", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "DateReturned", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "DateTaken", c => c.DateTime(nullable: false));
        }
    }
}
