namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mygra : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clocks",
                c => new
                    {
                        WorkId = c.Int(nullable: false, identity: true),
                        StaffNO = c.String(),
                        StaffName = c.String(),
                        HitTime = c.DateTime(nullable: false),
                        HitSate = c.String(),
                    })
                .PrimaryKey(t => t.WorkId);
            
            CreateTable(
                "dbo.Departs",
                c => new
                    {
                        DepartId = c.Int(nullable: false, identity: true),
                        DepartName = c.String(),
                        DepartDesc = c.String(),
                    })
                .PrimaryKey(t => t.DepartId);
            
            CreateTable(
                "dbo.GoTimes",
                c => new
                    {
                        GoTimeIsd = c.Int(nullable: false, identity: true),
                        AMGoTime = c.DateTime(nullable: false),
                        AMComeTime = c.DateTime(nullable: false),
                        PMGoTime = c.DateTime(nullable: false),
                        PMComeTime = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GoTimeIsd);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                        JobDesc = c.String(),
                        JobMoney = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        LeaveId = c.Int(nullable: false, identity: true),
                        StaffNo = c.Int(nullable: false),
                        StartLeaveTime = c.Int(nullable: false),
                        EndLeaveTime = c.Int(nullable: false),
                        LeaveReason = c.Int(nullable: false),
                        StaffId = c.Int(nullable: false),
                        LeaveSate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        MoneyId = c.Int(nullable: false, identity: true),
                        StaffNo = c.String(),
                        JobMoney = c.Single(nullable: false),
                        PunishMoney = c.Single(nullable: false),
                        AwardMoney = c.Single(nullable: false),
                        LeaveMoney = c.Single(nullable: false),
                        AllowMoney = c.Single(nullable: false),
                        TrueMoney = c.Single(nullable: false),
                        MoneySate = c.String(),
                    })
                .PrimaryKey(t => t.MoneyId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        StaffNo = c.String(),
                        StaffName = c.String(),
                        StaffCard = c.String(),
                        StaffSex = c.String(),
                        StaffAge = c.Int(nullable: false),
                        StaffPhone = c.String(),
                        StaffPhoto = c.String(),
                        DepartId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Staffs");
            DropTable("dbo.Salaries");
            DropTable("dbo.Leaves");
            DropTable("dbo.Jobs");
            DropTable("dbo.GoTimes");
            DropTable("dbo.Departs");
            DropTable("dbo.Clocks");
        }
    }
}
