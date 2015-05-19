namespace Stromblom.Portfolio.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Image2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Image2");
        }
    }
}
