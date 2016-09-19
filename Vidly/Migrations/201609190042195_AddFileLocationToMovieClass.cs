namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileLocationToMovieClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "FileLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "FileLocation");
        }
    }
}
