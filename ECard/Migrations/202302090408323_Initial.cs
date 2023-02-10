namespace ECard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 60),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BannerName = c.String(nullable: false, maxLength: 100),
                        Slogan = c.String(maxLength: 500),
                        Image = c.String(maxLength: 500),
                        Active = c.Boolean(nullable: false),
                        GroupId = c.Int(nullable: false),
                        Url = c.String(maxLength: 500),
                        Sort = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConfigSites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Facebook = c.String(maxLength: 500),
                        Youtube = c.String(maxLength: 500),
                        Twitter = c.String(maxLength: 500),
                        Instagram = c.String(maxLength: 500),
                        LiveChat = c.String(maxLength: 4000),
                        Image = c.String(),
                        Favicon = c.String(),
                        GoogleMap = c.String(maxLength: 4000),
                        GoogleAnalytics = c.String(maxLength: 4000),
                        Place = c.String(),
                        Title = c.String(maxLength: 200),
                        AboutText = c.String(),
                        Description = c.String(maxLength: 500),
                        Hotline = c.String(maxLength: 50),
                        Zalo = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        InfoContact = c.String(),
                        InfoFooter = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 100),
                        Body = c.String(maxLength: 4000),
                        Title = c.String(maxLength: 200),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Body = c.String(),
                        ListImage = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Sort = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Url = c.String(maxLength: 300),
                        TitleMeta = c.String(maxLength: 100),
                        DescriptionMeta = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Contacts");
            DropTable("dbo.ConfigSites");
            DropTable("dbo.Banners");
            DropTable("dbo.Admins");
        }
    }
}
