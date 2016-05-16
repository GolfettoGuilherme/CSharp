interface ITributavel{
	double CalculaTributo();
}

public abstract class Conta{
    public int numero {get; set};

    public double saldo {get;private set;};

    public Cliente titular {get;set;};

    public abstract void Saca(double valor){
    	if(valor < 0.0){
    		throw new ArgumentException();
    	}
    	if(valor > this.saldo){
    		throw new SaldoInsuficienteException();
    	} else{
			this.saldo -= valor;
    	}
        
    }

    public void Deposita(double valor){
        this.saldo += valor;
    }
}

public class ContaPoupanca : Conta, ITributavel{

	public override void Saca(double valor){
		this.Saldo -= valor + 0.10;
	}
	//obrigado a implementar por assinar a ITributavel
	public double CalculaTributo(){
		return this.Saldo * 0.02;
	}
}

public class ContaCorrente : Conta{

	private static int totalDeContas = 0;

	public ContaCorrente(){
		ContaCorrente.totalDeContas++;
	}

	public override void Saca(double valor){
		this.saldo -= valor + 0.10;
	}

	public static int ProximaConta(){
		return ContaCorrente.totalDeContas + 1;
	}
}

public class ContaInvestimento : Conta, ITributavel{	
	
	public double CalculaTributo(){
		return this.Saldo * 0.03;
	}
}

public class TotalizadorDeContas{

	public int SaldoTotal {get;set;}

	public string Adiciona(Conta c){
		this.SaldoTotal = c.saldo;
	}
}

public class Cliente{

	public string Nome {get; set;}
	public string Rg {get;set;}
	public string Cpf {get;set;}
	public string Documentos {get;set;}

	public Cliente(){
		
	}

	public Cliente(string nome){
		this.Nome = nome;
	}

	public bool PodeAbrirContaSozinho{
		var maiordeIdade = this.idade >= 18;
		var emancipado = this.documentos.contains("emancipacao");
		var possuiCPF = !string.IsNullOrEmpty(this.cpf);
		return (maiordeIdade || emancipacao) && possuiCPF;
	}
}



public class Banco{

	private Conta[] contas;

	private void AdicionaConta(Conta c){
		contas[] = c;
	}

}

public class TotalizadorDeTributos{

	public double Total {get; private set;}

	public void Acumula(ITributavel t){
		Total += t.CalculaTributo();
	}
}

public class SeguroDeVida : ITributavel{

	public double CalculaTributo(){
		return 42.0;
	}
}

public class GerenciadorDeImposto{
 	public double Total { get; private set; }

    public void Adiciona(ITributavel tributavel){
        this.Total += tributavel.CalculaTributos();
    }
}

private void button2_Click(object sender, EventArgs e){
    string textoValorSaque = valorOperacao.Text;
    double valorSaque = Convert.ToDouble(textoValorSaque);
    try{
        contaAtual.Saca(valorSaque);
        MessageBox.Show("Dinheiro Liberado");
    } catch(SaldoInsuficienteException e){
    	MessageBox.Show("Saldo insuficiente");
    } catch(ArgumentException e){
    	MessageBox.Show("Não é possivel sacar valor negativo");
    }
    MostraConta(contaAtual);
}


public class SaldoInsuficienteException : Exception{

}