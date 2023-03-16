# Arquitetura Limpa

Aplica��o demonstrando a utiliza��o da Arquitetura Limpa bem como os limites/fronteiras das suas camadas.  
### Desenho de refer�ncia
![Desenho de refer�ncia](https://github.com/lesandroCuzini/FluxoDeCaixa/blob/main/ArquiteturaLimpa.PNG)

**1.) Entidades:** Nesta arquitetura o banco de dados *n�o* � mais o centro do aplicativo. As **regras de neg�cio** s�o.
Na arquitetura limpa as regras de neg�cios s�o implementadas no n�cleo do aplicativo: nos casos de uso e nas entidades.
Nas entidades deve ser implementadas regras imut�veis.

**2.) Casos de uso:** As entidades imp�em regras de neg�cios de alto n�vel. De uma perspectiva de responsabalidade �nica, eles t�m apenas um motivo para mudar, na verdade provavelmente n�o v�o mudar nada.
Mas algumas regras mudam, � onde entra os casos de uso, essas regras espec�ficas s�o implementadas no caso de uso, desta forma n�o se viola o Princ�pio da Responsabilidade �nica.

**3.) Arquitetura "gritante" (Screaming Architecture):** Tem se a tend�ncia de agrupar as classes por tipo. Mas isso n�o deixa claro o que o aplicativo faz com esses tipos.
Sem mencionar que falha na capacidade de escalar, conforme a aplica��o aumentar, a quantidade entidades por exemplo vai aumentar.
Em vez disso, a *Screaming Architecture* concentra na funcionalidade do aplicativo, ou seja, agrupar tudo por funcionalidade, fazendo com que o aplicativo "grite" suas funcionalidades.
Deve ficar claro o que o aplicativo faz apenas com sua estrutura de arquivos e pastas, sem ler uma �nica linha de c�digo.
Colocando interfaces, entidades e casos de uso na mesma pasta, estamos agrupando por funcionalidade, o aplicativo crescer� organicamente e permanecer� f�cil de navegar.

**4.) Limites das camadas:**
A regra da arquitetura limpa �: todas as depend�ncias apontam para dentro. As entidades est�o no centro do aplicativo, a camada de casos de uso depende das entidades e a camada de infraestrutura depende dos casos de uso.

**5.) Infraestrtura:** Com as entidades, casos de uso e controladores, resta a camada de infraestrutura. Essa camada cont�m adaptadores de banco de dados, chamadas de API terceiros.
A implementa��o da infraestrutura na camada externa tem v�rias vantagens:
 - S�o facilmente substitu�veis.
 - O aplicativo se torna muito test�vel, ao separar infraestrutura resta regras de neg�cio para testar.

# Resumo da aplica��o

No quesito de neg�cio, esta aplica��o tem como objetivo oferecer a gest�o do fluxo de caixa de uma empresa, inicialmente esta aplica��o deve disponibilizar dois recursos: efetuar os lan�amentos de recebimentos e pagamentos, 
e obter o saldo consolidado por dia.  

API Docs: /swagger/index.html  

S�o estes dois _endpoints_ dispon�veis:
 - [POST] /api/Lancamentos: insere lan�amento
 - [GET] /api/Saldos/SaldoDiario: retorna o consolidado di�rio com o saldo

## TO DO:

- [ ] Docker compose
- [ ] Code Quality (ex: SonarQube)
- [ ] Test Coverage
- [ ] CI/CD - GitHub Actions