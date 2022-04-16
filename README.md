# Teste de conhecimentos Cidade alta

Exercicio desenvolvido pela cidade alta com objetivo de testar conhecimentos tecnicos

# Contextualizacao:

- Sistema para gestão de codigo penal
- Necessario logar com usuario, e com role do usuario tem mais permissoes
  - user: pegar informacoes de todos status ou por id, e pega todas informacoes dos codigo penais ou por id
  - admin: tudo que user faz + criacao de novos usuarios, criacao, atualizacao e remocao de status e codigo penais

# Requisitos:
- CRUD de Usuário:
  - UserName - String
  - Password - String
  - Role - String
- CRUD de Status:
  - Name - String
- CRUD de codigo penal:
  - Name - String
  - Description - String
  - Penalty - Decimal
  - PrisonTime - int
  - StatusId - String
  - CreateDate - DateTime
  - UpdateDate - DateTime
  - CreateUserId - String
  - UpdateUserId - String

# Tecnologias

- Backend:
  - .net core 6 + Entity FrameWork
  - Banco de dados SQL.


# HOW TO

## Start server


## DataBase

Configurar sua conexao do sql dentro de appsettings.json

## Autenticacao

Para realizar autenticacao, chamar primeiro a rota de log in, logar com usuario admin, voce recebera um token, e com o token
autorizar as chamadas, dentro do swagger e possivel autenticar com o botao authenticate localizado na parte superior direita
colocando no padrao "Bearer {tokenRecebidoPeloLogin}"

- Assim que rodar "dotnet ef database update" um usuario com role de admin ja sera criado. login: admin, senha: admin


# DOCUMENTACAO

## Rotas Status

- POST api/CriminalCode
  - Cria codigo penal novo

  - Body:
    - Name: String, obrigatorio.
    - Description: String, obrigatorio.
    - Penalty: Decimal, obrigatorio.
    - PrisonTime: int, obrigatorio.
    - StatusId: String, obrigatorio.
    - CreateDate: DateTime, obrigatorio.
    - UpdateDate: DateTime, obrigatorio.
    - CreateUserId: String, obrigatorio.
    - UpdateUserId: String, obrigatorio.

  - Params:
    - Nao requer params.
  
  - Possiveis Retornos:
    - 200 
      - codigo penal criado com sucesso
    - 401
      - nao tem permissao para criar codigo penal novos
    - 500
      - Erro interno ao criar o codigo penal

- GET api/CriminalCode
  - Lista todos codigo penal

  - Body:
    - page: Int, obrigatorio.
    - sort: String.
    - filter: String.

  - Params:
    - Nao requer params.
  
  - Possiveis Retornos:
    - 200 
      - body com lista de codigo penal
    - 401
      - nao tem permissao para listar codigo penal 
    - 500
      - Erro interno ao listar codigo penal
  

- GET api/CriminalCode/getById/{id}
  - Lista codigo penal especifico.

  - Body:
    - Nao requer body

  - Params:
    - Id: String, obrigatorio.

  - Possiveis Retornos:
    - 200
      - Body com informacao do CriminalCode
    - 401
      - nao tem permissao para listar codigo penal 
    - 404
      - ID do CriminalCode nao encontrado


- PUT api/CriminalCode/
  - Atualiza CriminalCode especifico.

  - Body:
    - Name: String, obrigatorio.
    - Description: String, obrigatorio.
    - Penalty: Decimal, obrigatorio.
    - PrisonTime: int, obrigatorio.
    - StatusId: String, obrigatorio.

  - Params:
    - Id: int, obrigatorio.

  - Possiveis Retornos:
    - 200
      - atualizacao feita com sucesso
    - 401
      - nao tem permissao para atualizar codigo penal
    - 500
      - Erro interno ao criar o codigo penal


- DELETE api/CriminalCode/{Id}
  - Deleta CriminalCode especifico.

  - Body:
    - Nao requer body

  - Params:
    - Id: String, obrigatorio.
  
  - Possiveis Retornos:
    - 200
      - CriminalCode deleta com sucesso
    - 401
      - nao tem permissao para remover codigo penal
    - 404
      - ID do CriminalCode nao encontrado


## Rotas User

- POST api/User/login
  - realiza o login

  - Body:
    - UserName: String, obrigatorio.
    - Senha: String, obrigatorio.

  - Params:
    - Nao requer params.

  - Possiveis Retornos:
    - 200 
      - body com informacoes do user logado
    - 500
      - Senha errada
      - User nao encontrado

- POST api/User/register
  - Registra user novo

  - Body:
    - UserName: String, obrigatorio.
    - Senha: String, obrigatorio.
    - Role: String, obrigatorio.

  - Params:
    - Nao requer params.

  - Possiveis Retornos:
    - 200 
      - User criado com sucesso
    - 401
      - nao tem permissao para criar user
    - 500
      - Erro interno ao criar usuario


- GET /user/getById/{id}
  - Lista Usuario especifico.

  - Body:
    - Nao requer body

  - Params:
    - Id: String, obrigatorio.
  
  - Possiveis Retornos:
    - 200
      - Body com informacao do user
    - 401
      - nao tem permissao para listar usuario especifico
    - 404
      - ID do user nao encontrado

- PUT api/User/
  - Atualiza usuario especifico.

  - Body:
    - UserName: String, obrigatorio.
    - Password: String, obrigatorio.
    - Role: String, obrigatorio.

  - Params:
    - Id: int, obrigatorio.

  - Possiveis Retornos:
    - 200
      - atualizacao feita com sucesso
    - 401
      - nao tem permissao para atualizar codigo penal
    - 500
      - Erro interno ao criar o codigo penal


- DELETE /users/:userId
  - Deleta Usuario especifico.

  - Body:
    - Nao requer body

  - Params:
    - Id: String, obrigatorio.
  
  - Possiveis Retornos:
    - 200
      - body com a mensagem "User deletado com sucesso"
    - 401
      - nao tem permissao para remover user
    - 404
      - ID do user nao encontrado

## Rotas Status

- POST api/Status
  - Cria status novo

  - Body:
    - Name: String, obrigatorio.

  - Params:
    - Nao requer params.
  
  - Possiveis Retornos:
    - 200 
      - status criado com sucesso
    - 401
      - nao tem permissao para criar status novos
    - 500
      - Erro interno ao criar o status

- GET api/Status
  - Lista todos status

  - Body:
    - Nao requer body

  - Params:
    - Nao requer params.
  
  - Possiveis Retornos:
    - 200 
      - body com lista de status
    - 401
      - nao tem permissao para listar status
    - 500
      - Erro interno ao listar status
  

- GET api/Status/getById/{id}
  - Lista status especifico.

  - Body:
    - Nao requer body

  - Params:
    - Id: String, obrigatorio.

  - Possiveis Retornos:
    - 200
      - Body com informacao do Status
    - 401
      - nao tem permissao para listar status
    - 404
      - ID do status nao encontrado


- PUT api/Status
  - Atualiza status especifico.

  - Body:
    - Name: String, obrigatorio.

  - Params:
    - Id: Int, obrigatorio.

  - Possiveis Retornos:
    - 200
      - atualizacao feita com sucesso
    - 401
      - nao tem permissao para atualizar status
    - 500
      - Erro interno ao criar o status


- DELETE api/Status/{Id}
  - Deleta status especifico.

  - Body:
    - Nao requer body

  - Params:
    - Id: String, obrigatorio.
  
  - Possiveis Retornos:
    - 200
      - Status deleta com sucesso
    - 404
      - ID do status nao encontrado
