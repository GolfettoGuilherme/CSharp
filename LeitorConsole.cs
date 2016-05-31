using System;

namespace projetoConsole{

	public class Program{

		static void Main(){
			Console.WriteLine("Digite seu texto:");
			using(TextReader leitor = Console.In){
				string leitor.ReadLine();
				while(linha != null){
					Console.WriteLine(linha);
					linha = leitor.ReadLine();
				}	
			}
			
		}
	}
}
