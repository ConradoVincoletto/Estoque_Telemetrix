# Web API Controle de estoque Telemetrix

Projeto em Web API em 4 camadas, API, Application, Domain, e Infrastructure, para realizar a relação entre produto e categoria.

# Visão Geral

O projeto consiste em duas entidades, categoria, e produto, com relação 1 para muitos. Desenvolvido em 4 camadas, como supracitado, previligiando a limpa e bem estruturado.

## O Desafio

Foi definido algumas regras de negócio para este projeto, como;

* Um produto não pode ter mais que duas categorias
* O usuário que irá definir o limite de número máximo de produtos na categoria que está criando
* Tanto produto e categoria não poderá ser excluído para fins de auditoria, ele tem que ser inativo e não parecer na consulta
* A propriedade DataCriacao da entidade Categoria, não pode ser alterado no método "Atualizar"

# Video dos Testes

## Categoria
### Consulta, criação da categoria, e atualização
https://github.com/ConradoVincoletto/Estoque_Telemetrix/assets/113942505/3825e137-e43b-42f9-8058-81ab86162485

### Inativando a categoria
https://github.com/ConradoVincoletto/Estoque_Telemetrix/assets/113942505/ff1a22a1-414a-4a2c-a2f7-b8210f45591e

## Produto

### Consulta, criação do produto, atualização, e teste da regra de negócio do limite de produtos por categoria
https://github.com/ConradoVincoletto/Estoque_Telemetrix/assets/113942505/a6132b8c-5a09-4df3-a3e4-17d31602003d

### Inativando o produto
https://github.com/ConradoVincoletto/Estoque_Telemetrix/assets/113942505/4cf4eb47-8805-4ea6-896f-dcc7f9e491d3

# Autor

* LinkedIn --> [Conrado Vincoletto](www.linkedin.com/in/conradovincoletto)







