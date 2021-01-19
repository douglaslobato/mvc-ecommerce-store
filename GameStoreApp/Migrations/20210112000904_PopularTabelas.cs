using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreApp.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //categorias
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES('PS4','Jogos para plataforma PS4')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES('XBOX','Jogos para plataforma XBOX One')");

             //jogos
            migrationBuilder.Sql("INSERT INTO Jogos(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsJogoPreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='PS4'),'Jogo do Spider Man','Jogo incrivel do homem aranha encare essa aventura',1, 'https://images-americanas.b2w.io/produtos/01/00/img/2173276/7/2173276793_1GG.jpg','https://images-americanas.b2w.io/produtos/01/00/img/2173276/7/2173276793_1GG.jpg', 1 ,'Spider-Man', 249.90)");
            migrationBuilder.Sql("INSERT INTO Jogos(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsJogoPreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='PS4'),'Jogo dos Vingadores','Jogo incrivel dos vingadores jogue com todos os personagens',1,'https://images-americanas.b2w.io/produtos/01/00/img/1897089/6/1897089643_1GG.jpg','https://images-americanas.b2w.io/produtos/01/00/img/1897089/6/1897089643_1GG.jpg',0,'The Avengers', 189.90)");
            migrationBuilder.Sql("INSERT INTO Jogos(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsJogoPreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='XBOX'),'Jogo do GTA V','Jogo mundo aberto para se divertir com muitas missões',1,'https://images-americanas.b2w.io/produtos/01/00/img/134472/5/134472530_1GG.jpg','https://images-americanas.b2w.io/produtos/01/00/img/134472/5/134472530_1GG.jpg',0,'GTA V', 134.00)");
            migrationBuilder.Sql("INSERT INTO Jogos(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsJogoPreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='XBOX'),'Jogo de Futebol lançamento FIFA 21','Jogo do FIFA mais novo lançamento, se divirta no modo online e no modo carreira',1,'https://images-americanas.b2w.io/produtos/01/00/img/2070508/5/2070508547_1GG.jpg','https://images-americanas.b2w.io/produtos/01/00/img/2070508/5/2070508547_1GG.jpg',1,'FIFA 21', 179.90)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Jogos");
        }
    }
}
