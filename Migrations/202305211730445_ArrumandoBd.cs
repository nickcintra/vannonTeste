namespace vannon_teste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArrumandoBd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Id", "dbo.Usuarios");
            DropIndex("dbo.Clientes", new[] { "Id" });
            DropPrimaryKey("dbo.Clientes");
            AlterColumn("dbo.Clientes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Clientes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Clientes");
            AlterColumn("dbo.Clientes", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Clientes", "Id");
            CreateIndex("dbo.Clientes", "Id");
            AddForeignKey("dbo.Clientes", "Id", "dbo.Usuarios", "Id");
        }
    }
}
