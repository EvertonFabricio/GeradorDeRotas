Andamento atual do projeto - 21/04/2022 - 8:50.
API de Pessoa, Cidade, Usuario e equipe funcionando corretamente pelo swagger com banco de dados em MongoDB
Serviço de Busca nas API's criado para todas as funcões: Buscar todos, buscar individual, criar, editar e remover. Falta fazer apenas para api de equipe, para as outras já está pronto e funcionando.
MVC criado. Alterado a Home para uma melhor interação com usuario. Interagindo com as API's de pessoa, cidade e usuario, com todas as funções funcionando corretamente e tudo em português. 
Esboço da leitura do excel criado com a biblioteca EPPlus e funcionando parcialmente. 
Até o momento isso é tudo o que está feito. 
----------------------------------------------

Atualização 21/04/2022 - 15:50.
Atualizei o console app que faz a leitura do arquivo xlsx. Funcionando corretamente. Importa xml, ordena por cep, exporta em txt o documento todo de forma ordenada (txt apenas para teste e confirmação de que está funcionando). 
Comecei a implementar a exportação pra docx, template feito e exportando corretamente, mas ainda não pega os dados da planilha importada para preencher os dados. Será o proximo passo de hj!
----------------------------------------------

Atualização 21/04/2022 - 20:55.
MVC para criação das equipes funcionando parcialmente. Mostra as equipes no index, adiciono novas pessoa com checkbox de pessoas cadastradas e lista de cidades cadastradas, e removo equipe completa. Está com erro na edição de equipe ja cadastrada. Não dei andamento no preenchimento do word para exportação. 
-----------------------------------------------

Atualização 22/04/2022 - 22:25.
Finalizei quase todo o MVC. Edição de equipe que estava com erro foi corrigido. Fiz perfumeria para adicionar e editar equipes, colocando o dropdown de cidade e o checkbox de pessoa em ordem alfabetica. Travei a alteração do nome da equipe, só é possivel alterar as pessoas e a cidade de atuação. Todos os cadastros pela api ja estavam verificando se ja existe o nome cadastrado, agora todas os cadastros do MVC tbm estão verificando. Pra finalizar o MVC falta apenas verificar se uma pessoa já está em alguma equipe antes de adicionar. Por hora todas as pessoas podem ser adicionadas em todas as equipes. 








----------------------------------------------
Falta Fazer: verificar se a pessoa ja está em uma equipe antes de adicionar na outra, importação do excel pelo MVC (por enquanto está funcionando chumbado no consoleApp), Selecionar apenas os campos que deseja do Excel, Filtrar pela cidade (ordenação já ta feita), Preencher o word (layout ja ta pronto), e por ultimo o login do usuario.
