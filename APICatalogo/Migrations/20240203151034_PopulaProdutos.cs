using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) " +
                   "VALUES('Coca-Cola Diet', 'Refrigerante dietético', 5.50, 'coca_diet.jpg', 50, now(), 1)");

            mb.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) " +
                    "VALUES('Lanche de Atum', 'Lanche de Atum com maionese', 8.00, 'atum.jpg', 10, now(), 2)");

            mb.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaID) " +
                    "VALUES('Bolo de Chocolate', 'Delicioso bolo de chocolate', 15.00, 'bolo_chocolate.jpg', 20, now(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Produtos");
        }
    }
}
