namespace INF__440.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuackModelUpdate_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quacks", "Date_Created", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quacks", "Date_Created", c => c.Int(nullable: false));
        }
    }
}
