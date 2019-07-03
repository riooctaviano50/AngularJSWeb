namespace AngularWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Club = c.String(),
                        Country = c.String(),
                        Age = c.String(),
                    })
                .PrimaryKey(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
        }
    }
}
