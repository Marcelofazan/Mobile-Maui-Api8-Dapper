## 🚀 AppMobile-MAUI-Login-Pessoa

Exemplo de criação de Login de App Mobile MAUI Xamarin Forms consumindo WebAPI.

### O que você vai encontrar neste projeto
| Tecnologia | Descrição |
|-----------|-----------|
| **HTTPClient**  | Classe primária utilizada para enviar solicitações HTTP e receber respostas de recursos identificados por um URI. |
| **XAML**  | Linguagem baseada em XML, para definir interfaces de usuário de forma declarativa para Android, iOS, macOS e Windows. |

### Execução da aplicação
Executa a aplicação Backend **WebAPI-Mobile-MySQL** que se encontra no Github.

  - [WebAPI-Mobile-MySQL](https://github.com/Marcelofazan/apinet8-mobile-mysql)
  
O banco de dados é MySQL e deve estar hospedado Online , onde será maninupado por essa aplicação através de emulador Android .NET MAUI.

#### 🧪 Execução Inicial de Endpoints (Postman)

**(PessoaService.cs)**
- Necessário alterar link da API hospedada. 

```json
https://[LINKWEB].tryasp.net/api/pessoa
```

#### Rotas dos métodos 
| Metodo | Descrição |
|-----------|-----------|
| Metodo: GET | /api/Pessoa |
| Metodo: POST | /api/Pessoa |
