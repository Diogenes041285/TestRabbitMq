using System;

namespace ConsoleApp1
{
	class Program
	{
			
		static void Main(string[] args)
		{
			var mensagem = new MessageInputModel()
			{
				Content = "Primeira mensagem teste",
				FromId = 1,
				ToId = 2
			};
			
			var rabbit = new TestRabbit();
			//rabbit.PostarMensagem(mensagem);
			rabbit.PegarMensagens();

		}
	}
}
