# Gest�o de Equipamentos

## Descri��o

Sistema de gest�o de equipamentos: O projeto foi desenvolvido com o uso da linguagem C#. O sistema funciona dentro do sistema ConsoleApp do DotNet. 
O sistema tem como objetivo o cadastro de equipamentos, onde o usu�rio pode cadastrar, visualisar equipamentos cadastrados, editar cadastro de equipamentos e excluir equipamentos cadastrados.
O sistema tamb�m permite a gestao de manuten��o de equipamentos, permitindo que o usu�rio cadastre, visualize, edite e exclua  chamadas de manuten��o cadastradas na op��o Manuten��o.

O sistema � simples e f�cil de usar, com um menu interativo que permite ao usu�rio navegar pelas op��es dispon�veis. 
O sistema tamb�m possui valida��es para garantir que os dados inseridos sejam v�lidos e consistentes.

 ### Na vers�o atual, o sistema permite: 
	
- cadastro de equipamentos tendo como entradas:

 1. Nome do equipamento.
 2. Fabricante.
 3. Valor de aquisi��o do equipamento.
 4. Data de fabrica��o do equipamento.
 5.  O Sietam gera automaticamente um numero de ID para cada equipamento cadastrado, e um numero de seri� baseando-se 
 nas tr�s primeiras letras do nome do equipamento e o seu ID gerado.


- Cadastro de  chamadas de manuten��o de equipamentos tendo como entradas:
 
 1. T�tulo da chamda.
 2. Descri��o da chamada.
 3. Data de abertura da chamada.
 4. Quantidade de dias de chamada em aberto.



- Acesso de Menus:

1. **Menu principal:**
 a. Cadastro de equipamentos.
 b. Editar equipamento cadastrado.
 c. Visualizar equipamentos cadastrados.
 d. Excluir equipamentos cadastrados.
 e. Menu de manuten��o.

2. **Menu de manuten��o:**	
 a. Criar chamadas de manuten��o. 
 b. Editar chamadas cadastrados.
 c. Visualizar chamadas cadastradas.
 d. Excluir chamadas cadastradas.
 
# Como ultilizar:

1. Clone o repositorio ou baixe o codigo fonte.
2. Abra o Terminal ou prompt de Comando e navegue at� a pasta raiz.
3. Utilize o camando abaixo para restaurar as depend�ncias do projeto.

```
dotnet restore
```


4. Compile a solu��o utilizando o comando:
```
 dotnet build --configuration Release
```
5.Para executar o projeto compilando em tempo real
```
dotnet run --project RoboTupiniquim2025.ConsoleApp
```

6. Para executar o arquivo compilado, navegue at� a pasta /GestaoDeEquipamentos.ConsoleApp/bin/Release/net8.0/ e execute o arquivo:
GestaoDeEquipamentos.ConsoleApp.exe
	

	
	

	
	
 
	