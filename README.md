Aplicativo .NET MAUI Blazor Hybrid completo que demonstra como configurar a autenticação e a autorização de forma eficaz. Neste projeto, você aprenderá a criar um sistema de login seguro e baseado em funções, onde as permissões são gerenciadas com base nas funções do usuário. Por exemplo, um usuário administrador pode excluir registros, enquanto usuários regulares podem apenas visualizar dados. Este guia prático inclui tudo o que você precisa para criar um sistema de autenticação robusto em um aplicativo .NET MAUI Blazor.

O que está incluído.
AuthenticationService: esta classe manipula sessões de usuário, garantindo que elas persistam com segurança no armazenamento, mesmo se o aplicativo estiver fechado.

CustomAuthenticationStateProvider: uma implementação do AuthenticationStateProvider para gerenciar sessões de usuário com base em suas funções.

Login e Logout: login seguro e sessões persistentes usando o Secure Storage.

Acesso baseado em função: controle o acesso a componentes e ações específicos, como o botão de exclusão, que é restrito a usuários administradores.

Injeção de dependência: acesse facilmente AuthenticationService e CustomAuthenticationStateProvider em todo o aplicativo.

Pontos-chave do projeto
Gerenciamento de sessão do usuário: implementado com armazenamento seguro e serialização JSON, mantendo os usuários conectados com segurança.

Permissões baseadas em função: permite que administradores acessem determinados recursos enquanto restringem usuários regulares.

Persistência de sessão: utiliza a funcionalidade "Lembrar de mim" para persistir a sessão.

Ajustes da interface do usuário: o aplicativo exibe ou oculta elementos da IU, como o botão de exclusão, com base na função do usuário.

Recurso de logout: limpa as sessões do usuário de forma eficaz para garantir o logout seguro.

Este projeto também se integra a um banco de dados SQLite para salvar e recuperar dados. Para obter detalhes adicionais sobre o uso do SQLite no .NET MAUI
