namespace PrototipoPOC.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telefones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DDD = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Ramal = c.Int(nullable: false),
                        TipoTelefone = c.Int(nullable: false),
                        Pessoa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.Pessoa_Id)
                .Index(t => t.Pessoa_Id);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        CEP = c.Int(nullable: false),
                        Cidade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnderecoPessoas",
                c => new
                    {
                        Endereco_Id = c.Int(nullable: false),
                        Pessoa_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Endereco_Id, t.Pessoa_Id })
                .ForeignKey("dbo.Enderecoes", t => t.Endereco_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pessoas", t => t.Pessoa_Id, cascadeDelete: true)
                .Index(t => t.Endereco_Id)
                .Index(t => t.Pessoa_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.EnderecoPessoas", new[] { "Pessoa_Id" });
            DropIndex("dbo.EnderecoPessoas", new[] { "Endereco_Id" });
            DropIndex("dbo.Telefones", new[] { "Pessoa_Id" });
            DropForeignKey("dbo.EnderecoPessoas", "Pessoa_Id", "dbo.Pessoas");
            DropForeignKey("dbo.EnderecoPessoas", "Endereco_Id", "dbo.Enderecoes");
            DropForeignKey("dbo.Telefones", "Pessoa_Id", "dbo.Pessoas");
            DropTable("dbo.EnderecoPessoas");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Telefones");
            DropTable("dbo.Pessoas");
        }
    }
}
