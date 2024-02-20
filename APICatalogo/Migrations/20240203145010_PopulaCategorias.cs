using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{

    public partial class PopulaCategorias : Migration
    {

        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categorias(Nome, ImagemURL) VALUES ('Bebidas', 'bebibas.jpg')");
            mb.Sql("INSERT INTO Categorias(Nome, ImagemURL) VALUES ('Lanches', 'lanches.jpg')");
            mb.Sql("INSERT INTO Categorias(Nome, ImagemURL) VALUES ('Sobremesas', 'sobremesas.jpg')");
        }

        
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Categorias");
        }
    }
}
