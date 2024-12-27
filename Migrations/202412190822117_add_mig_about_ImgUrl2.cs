namespace YummyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_about_ImgUrl2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "ImgUrl2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "ImgUrl2");
        }
    }
}
