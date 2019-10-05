namespace DictionaryEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeWordTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TYPE_WORD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        TYPE_TEXT = c.String(),
                        DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.WORD", "TYPE_WORD_ID", c => c.Guid(nullable: false));
            AddColumn("dbo.WORD", "SOUND", c => c.String());
            CreateIndex("dbo.WORD", "TYPE_WORD_ID");
            AddForeignKey("dbo.WORD", "TYPE_WORD_ID", "dbo.TYPE_WORD", "ID", cascadeDelete: true);
            DropColumn("dbo.WORD", "TYPE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WORD", "TYPE", c => c.String());
            DropForeignKey("dbo.WORD", "TYPE_WORD_ID", "dbo.TYPE_WORD");
            DropIndex("dbo.WORD", new[] { "TYPE_WORD_ID" });
            DropColumn("dbo.WORD", "SOUND");
            DropColumn("dbo.WORD", "TYPE_WORD_ID");
            DropTable("dbo.TYPE_WORD");
        }
    }
}
