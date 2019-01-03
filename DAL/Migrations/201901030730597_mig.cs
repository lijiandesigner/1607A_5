namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GoTimes");
            AddColumn("dbo.Clocks", "Hours", c => c.DateTime(nullable: false));
            DropColumn("dbo.GoTimes", "GoTimeIsd");
            AddColumn("dbo.Departs", "CreateTime", c => c.String());
            AddColumn("dbo.GoTimes", "GoTimeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Leaves", "StaffName", c => c.Int(nullable: false));
            AddColumn("dbo.Salaries", "StaffName", c => c.String());
            AddPrimaryKey("dbo.GoTimes", "GoTimeId");

        }
        
        public override void Down()
        {
            AddColumn("dbo.GoTimes", "GoTimeIsd", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.GoTimes");
            DropColumn("dbo.Salaries", "StaffName");
            DropColumn("dbo.Leaves", "StaffName");
            DropColumn("dbo.GoTimes", "GoTimeId");
            DropColumn("dbo.Departs", "CreateTime");
            DropColumn("dbo.Clocks", "Hours");
            AddPrimaryKey("dbo.GoTimes", "GoTimeIsd");
        }
    }
}
