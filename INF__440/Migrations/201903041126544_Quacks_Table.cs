namespace INF__440.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quacks_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quacks",
                c => new
                    {
                        Quack_Id = c.Int(nullable: false, identity: true),
                        Quack_Title = c.String(nullable: false),
                        Date_Created = c.Int(nullable: false),
                        Quack_Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Quack_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Quacks");
        }
    }
}
