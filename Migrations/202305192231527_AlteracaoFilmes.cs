namespace vannon_teste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoFilmes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filme", "genero", c => c.String());
            DropColumn("dbo.Filme", "gênero");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Filme", "gênero", c => c.String());
            DropColumn("dbo.Filme", "genero");
        }
    }
}
