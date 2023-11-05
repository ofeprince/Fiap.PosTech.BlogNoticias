# Fiap.PosTech.BlogNoticias

## Projeto API
Nesse projeto temos o backend que conecta na base de dados sqlServer localizada no Azure. Certifique-se
de que a connection string seja a correta.

A API utiliza autenticacao com Jwt Bearer token, gerado no endpoint de Usuario. A chave do jwt tambem esta no appsettings

As principais operacoes da API sao para o objeto Noticia. Podemos retornar uma lista de noticias, cadastrar uma
 e retornar uma noticia por id

## Projeto de teste
Nesse projeto temos teste para conexao a base de dados e tambem para as operacoes relacionadas ao objeto Noticia
OBS: Certifique-se que as connectionString instanciadas hardcode estejam iguais a connectionString do 
projeto de API.

## Link github do projeto
https://github.com/ofeprince/Fiap.PosTech.BlogNoticias
