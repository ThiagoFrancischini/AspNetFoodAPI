# AspNetFoodAPI
Esta API eu desenvolvi com o intuito de terminar um projeto de aplicativo que eu fiz para aprender React Native.

Foi desenvolvida em ASP.NET usando um banco SQLite, utilizando conhecimentos de C#, .Net e SQL. Mais informações sobre tudo que ela faz podem ser encontradas no README do aplicativo no repositório abaixo:
https://github.com/ThiagoFrancischini/ReactNativeFood

# Para executar
- Caso nunca tenha executado uma solução ASP.NET, instale o Visual Studio, e no instalador marque a opção de desenvolvimento Web, para baixar todas dependencias necessarias.
- Selecione a opção de rodar a solução em Http.
- Para expor a API utilizei um proxy, para roda-lo, instale o node.js e utilize o comando "npm install iisexpress-proxy".
- Após o download de todas as dependencias, execute o projeto.
- Após executado edite o arquivo "iis-express-expose.bat" e troque o primeiro numero para a porta local que esta rodando seu projeto, depois troque o segundo numero pela porta que você deseja expor para o aplicativo.
- Rode o arquivo iis-express-expose.bat, se tudo deu certo, uma url irá aparecer do lado do "WIFI", esta url, com seu ip e porta, e ela estará acessível a todos na sua rede. Pegue a url e mude o arquivo de API do app.
  
Link do repositorio do codigo do proxy: https://github.com/icflorescu/iisexpress-proxy 

# Observações e Utils
Esta api é uma api de auxílio, e para não perder tanto tempo nela acabei optando por um banco SQLite, pois facilitava meu versionamento. Também acabei não fazendo fluxo de geração de tokens JWT para deixa-la segura e coisas parecidas. 

  -Comandos para mudar estrutura do banco.  'add-migration {nomeMigracao}' && 'update-database'

# Roadmap
Desenvolver uma interface Web para o administrativo manipular as informações do banco com o intuito de treinar meus conhecimentos de Web.
