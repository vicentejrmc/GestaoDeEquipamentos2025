# Gestão de Equipamentos

## Descrição

Sistema de gestão de equipamentos: O projeto foi desenvolvido com o uso da linguagem C#. O sistema funciona dentro do sistema ConsoleApp do DotNet. 
O sistema tem como objetivo o cadastro de equipamentos, onde o usuário pode cadastrar, visualisar equipamentos cadastrados, editar cadastro de equipamentos e excluir equipamentos cadastrados.
O sistema também permite a gestao de manutenção de equipamentos, permitindo que o usuário cadastre, visualize, edite e exclua  chamadas de manutenção cadastradas na opção Manutenção.

O sistema é simples e fácil de usar, com um menu interativo que permite ao usuário navegar pelas opções disponíveis. 
O sistema também possui validações para garantir que os dados inseridos sejam válidos e consistentes.

 ### Na versão atual, o sistema permite: 
	
- cadastro de equipamentos tendo como entradas:

 1. Nome do equipamento.
 2. Fabricante.
 3. Valor de aquisição do equipamento.
 4. Data de fabricação do equipamento.
 5.  O Sietam gera automaticamente um numero de ID para cada equipamento cadastrado, e um numero de serié baseando-se 
 nas três primeiras letras do nome do equipamento e o seu ID gerado

- Cadastro de  chamadas de manutenção de equipamentos tendo como entradas:
 
 1. Título da chamda.
 2. Descrição da chamada.
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
 4. Endereço do fabricante.
 
# Como ultilizar:

1. Clone o repositorio ou baixe o codigo fonte.
2. Abra o Terminal ou prompt de Comando e navegue até a pasta raiz.
3. Utilize o camando abaixo para restaurar as dependências do projeto.

```
dotnet restore
```


4. Compile a solução utilizando o comando:
```
 dotnet build --configuration Release
```
5.Para executar o projeto compilando em tempo real
```
dotnet run --project GestaoDeEquipamentos.ConsoleApp
```

6. Para executar o arquivo compilado, navegue até a pasta /GestaoDeEquipamentos.ConsoleApp/bin/Release/net8.0/ e execute o arquivo:
GestaoDeEquipamentos.ConsoleApp.exe
	

	
	

	
	
 
	