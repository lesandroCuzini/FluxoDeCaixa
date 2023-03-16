# Arquitetura Limpa

Aplicação demonstrando a utilização da Arquitetura Limpa bem como os limites/fronteiras das suas camadas.  
### Desenho de referência
![Desenho de referência](https://github.com/lesandroCuzini/FluxoDeCaixa/blob/main/ArquiteturaLimpa.PNG)

**1.) Entidades:** Nesta arquitetura o banco de dados *não* é mais o centro do aplicativo. As **regras de negócio** são.
Na arquitetura limpa as regras de negócios são implementadas no núcleo do aplicativo: nos casos de uso e nas entidades.
Nas entidades deve ser implementadas regras imutáveis.

**2.) Casos de uso:** As entidades impõem regras de negócios de alto nível. De uma perspectiva de responsabalidade única, eles têm apenas um motivo para mudar, na verdade provavelmente não vão mudar nada.
Mas algumas regras mudam, é onde entra os casos de uso, essas regras específicas são implementadas no caso de uso, desta forma não se viola o Princípio da Responsabilidade Única.

**3.) Arquitetura "gritante" (Screaming Architecture):** Tem se a tendência de agrupar as classes por tipo. Mas isso não deixa claro o que o aplicativo faz com esses tipos.
Sem mencionar que falha na capacidade de escalar, conforme a aplicação aumentar, a quantidade entidades por exemplo vai aumentar.
Em vez disso, a *Screaming Architecture* concentra na funcionalidade do aplicativo, ou seja, agrupar tudo por funcionalidade, fazendo com que o aplicativo "grite" suas funcionalidades.
Deve ficar claro o que o aplicativo faz apenas com sua estrutura de arquivos e pastas, sem ler uma única linha de código.
Colocando interfaces, entidades e casos de uso na mesma pasta, estamos agrupando por funcionalidade, o aplicativo crescerá organicamente e permanecerá fácil de navegar.

**4.) Limites das camadas:**
A regra da arquitetura limpa é: todas as dependências apontam para dentro. As entidades estão no centro do aplicativo, a camada de casos de uso depende das entidades e a camada de infraestrutura depende dos casos de uso.

**5.) Infraestrtura:** Com as entidades, casos de uso e controladores, resta a camada de infraestrutura. Essa camada contém adaptadores de banco de dados, chamadas de API terceiros.
A implementação da infraestrutura na camada externa tem várias vantagens:
 - São facilmente substituíveis.
 - O aplicativo se torna muito testável, ao separar infraestrutura resta regras de negócio para testar.

# Resumo da aplicação

No quesito de negócio, esta aplicação tem como objetivo oferecer a gestão do fluxo de caixa de uma empresa, inicialmente esta aplicação deve disponibilizar dois recursos: efetuar os lançamentos de recebimentos e pagamentos, 
e obter o saldo consolidado por dia.  

API Docs: /swagger/index.html  

São estes dois _endpoints_ disponíveis:
 - [POST] /api/Lancamentos: insere lançamento
 - [GET] /api/Saldos/SaldoDiario: retorna o consolidado diário com o saldo

## TO DO:

- [ ] Docker compose
- [ ] Code Quality (ex: SonarQube)
- [ ] Test Coverage
- [ ] CI/CD - GitHub Actions