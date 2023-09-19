# Sprint 1 - 19/09/2023 - 26/09/2023

## Aplicativo Xamarin
**Descrição:** Criar um aplicativo em Xamarin [Get Started](https://learn.microsoft.com/en-us/xamarin/get-started/), que possui apenas 1 tela: 
* Tela1: 
  * Botão com a label "Enviar Ordem"
    * Ação: Enviar um texto em formato de FIX(exemplos em anexo) para a **API AspNet.Core** de forma que:
      * A cada envio:
        * trocar o campo 55 para um texto random (max 20 caracteres)
        * trocar o campo 44 para um número decimal random no range (0-100. Ex: 24.00)


## API AspNet.Core
**Descrição:** Criar uma API em AspNet.Core [Get Started](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio), que possui apenas 1 endpoint:
* Criar um objeto Order com as seguintes propriedades:
  * Account (string)
  * Symbol (string)
  * Price (decimal)
* Endpoint /order
  * POST
    * Recebe um texto em formato [FIX](https://en.wikipedia.org/wiki/Financial_Information_eXchange), mapeia para esse objeto Order e escreve em um .txt com o modo 'Append' as três propriedades