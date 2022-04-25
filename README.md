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
-----------------------------------------------

Atualização 23/04/2022 - 18:50
Finalizei a verificação da pessoa estar cadastrada em alguma equipe antes de cadastrar ela na proxima. Está funcionando corretamente, agora a pessoa só pode ser cadastrada numa unica equipe. Ao cadastrar uma equipe aparece somente as pessoas que estão disponiveis. Ao editar uma equipe é permitido selecionar tanto quem está disponivel como quem ja faz parte da equipe. Ao salvar as alterações, as pessoas que não foram mais selecionadas praquela equipe tambem voltam a ficar disponivel. Ao excluir uma equipe, todas as pessoas que estavam nela voltam a ficar disponivel.
Fim de toda a parte de cadastro do MVC (eu acho).
----------------------------------------------

Atualização 24/04/2022 - 23:45
Criado o controller e a view pra tratar o documento e gerar a rota. Importação do excel feito pelo MVC, direto na controller de documentos, portanto será deletado o consoleapp e o serviço que fazia isso. Filtro pelo serviço funcionando. Filtro pela cidade pra saber qual equipe está disponivel para atuar naquela cidade tbm está funcionando. Seleção dinamica dos campos da planilha base pra gerar o documento final tbm está ok. 
-----------------------------------------------

Atualização 25/04/2022 - 12:37 - "Socorro"
Funcionando o preenchimento do word corretamente, exportando o arquivo de forma automatica na pasta do sistema. Foi pedido hj que fosse criado o botão pra download do arquivo gerado, mas ainda não fiz. Falta criar a View de Create pra ter alguma coisa pra aparecer quando terminar a geração do documento, por enquanto está dando tela de erro.


----------------------------------------------
Falta Fazer:
Falta fazer o login do usuario, e agora falta o botão de download que foi pedido hj.
