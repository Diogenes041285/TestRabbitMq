# TestRabbitMq
Console simples para mostrar o envio e busca de mensagens no RabbitMQ

Instalação do RabbitMQ (windows):

https://www.rabbitmq.com/install-windows.html#installer

Erlang (pré-requisito):

https://erlang.org/download/otp_versions_tree.html

Caso ocorra erro ao abrir o Rabbit tente o seguinte:

1 - Adicione as variáveis de ambiente:

nome : ERLANG_HOME
valor: C:\Program Files (x86)\erl6.4

2- Adicione %ERLANG_HOME%\bin na variavel PATH:

valor: "%ERLANG_HOME%\bin"

*cuidado para não apagar os outros caminhos da PATH

3 - Reincie o windows

4- Exclua a pasta c:\Users\--USERNAME--\AppData\Roaming\RabbitMQ\db\

*pode excluir sem medo

5- Abra o "RabbitMQ command prompt" (sbin directory):

Execute:
rabbitmq-plugins enable rabbitmq_management

6 - Aguarde um pouco e chame o link

http://localhost:15672/
