namespace vannon_teste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteUsuarioLocacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        Senha = c.String(nullable: false, maxLength: 100),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataLocacao = c.DateTime(nullable: false),
                        Filme_id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Filme", t => t.Filme_id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Filme_id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Cpf = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.Id)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Clientes", "Id", "dbo.Usuarios");
            DropForeignKey("dbo.Locacaos", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Locacaos", "Filme_id", "dbo.Filme");
            DropIndex("dbo.Clientes", new[] { "UsuarioId" });
            DropIndex("dbo.Clientes", new[] { "Id" });
            DropIndex("dbo.Locacaos", new[] { "Usuario_Id" });
            DropIndex("dbo.Locacaos", new[] { "Filme_id" });
            DropTable("dbo.Clientes");
            DropTable("dbo.Locacaos");
            DropTable("dbo.Usuarios");
        }
    }
}
