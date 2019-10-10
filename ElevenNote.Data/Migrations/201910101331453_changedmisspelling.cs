namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmisspelling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Note", "ModeifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "ModeifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Note", "ModifiedUtc");
        }
    }
}
