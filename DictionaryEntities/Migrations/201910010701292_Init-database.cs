namespace DictionaryEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EXAMPLE",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        MEANING_ID = c.Guid(nullable: false),
                        TEXT = c.String(),
                        DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MEANING", t => t.MEANING_ID, cascadeDelete: true)
                .Index(t => t.MEANING_ID);
            
            CreateTable(
                "dbo.MEANING",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        WORD_ID = c.Guid(nullable: false),
                        TEXT = c.String(),
                        DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.WORD", t => t.WORD_ID, cascadeDelete: true)
                .Index(t => t.WORD_ID);
            
            CreateTable(
                "dbo.WORD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        TEXT = c.String(),
                        TYPE = c.String(),
                        PRONOUNCE = c.String(),
                        DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MEANING", "WORD_ID", "dbo.WORD");
            DropForeignKey("dbo.EXAMPLE", "MEANING_ID", "dbo.MEANING");
            DropIndex("dbo.MEANING", new[] { "WORD_ID" });
            DropIndex("dbo.EXAMPLE", new[] { "MEANING_ID" });
            DropTable("dbo.WORD");
            DropTable("dbo.MEANING");
            DropTable("dbo.EXAMPLE");
        }
    }
}
