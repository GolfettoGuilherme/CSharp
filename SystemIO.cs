using System.IO 
using System.Windows.Forms;

namespace ProjetoLeituraArquivo{
	public class Leitura{

		public TextBox txbTexto = new TextBox();

		private void frm1_Load(){

			if(File.Exists("texto.txt")){
				using(StreamReader leitor = File.Open("texto.txt")){
					txbTexto.Text = leitor.ReadToEnd();	
				}	
			}	
		}

		private void btnSalvar_Click(object sender, EventArgs e){
			using(Stream saida = File.OpenWrite("texto.txt"))
		    using(StreamWriter escritor = new StreamWriter(saida)){
		    	escritor.Write(texto.Text);	
		    }
		}
		
	}
}
