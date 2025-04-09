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
 nas tr�s primeiras letras do nome do equipamento e o seu ID gerado

- Cadastro de  chamadas de manuten��o de equipamentos tendo como entradas:
 
 1. T�tulo da chamda.
 2. Descri��o da chamada.
 3. Data de abertura da chamada.
 4. Quantidade de dias de chamada em aberto.
	
- Cadastro de fabricantes tendo como entradas:

 1. Nome do fabricante.
 2. Telefone do fabricante.
 3. E-mail do fabricante.
	
 --------------------------------------------------------------------------------------------------------

 ## Acesso de Menus:

1. **Menu principal:**
 1. Controle de fabricantes.
 2. Controle de equipamentos.
 3. Controle de chamadas.
 4. Sair.

 --------------------------------------------------------------------------------------------------------
	 
2. **Menu de Chamadas:**	
 1. Criar chamadas. 
 2. Editar chamadas.
 3. Visualizar chamadas.
 4. Excluir chamadas.
 
 --------------------------------------------------------------------------------------------------------
	
 3. **Menu de fabricantes**
 1. Nome do fabricante.
 2. Telefone do fabricante.
 3. E-mail do fabricante.
 4. Endere�o do fabricante.
 
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
dotnet run --project GestaoDeEquipamentos.ConsoleApp
```

6. Para executar o arquivo compilado, navegue at� a pasta /GestaoDeEquipamentos.ConsoleApp/bin/Release/net8.0/ e execute o arquivo:
GestaoDeEquipamentos.ConsoleApp.exe
	

	
	

	
	
 
	