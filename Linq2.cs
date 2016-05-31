var lista = new List<Conta>();

//inserir alguns dados
lista.Add();

//criar uma lista para elementos filtrados
var filtrados = new List<Conta>();
foreach(var c : lista){
	if(c.Saldo > 2000)
		filtrador.Add(c);
}

//MUITO TRABALHO!!

var filtrados = 
			from c in lista
			where c.Saldo > 2000
			select c;

//para saber a o total de saldo das contas

//maneira tradicional
double total = 0.0;
foreach(var c in lista){
	total += c.Saldo;
}

//LINQ
double total = lista.Sum(c => c.Saldo);


//exemplo
var valor = from c in lista
			where c.Titular.StartsWith("G")
			select c
