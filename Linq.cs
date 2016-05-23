using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //fonte de dados para LINQ
            List<Pessoa> pessoas = CarregarListaPessoa();
            // 1 todas as pessoas com mais de 2 irmãos
            /*IEnumerable<Pessoa> pessoasMaisDoisIrmaos = from pessoa in pessoas
                                        where pessoa.QuantidadeIrmaos > 2
                                        select pessoa;*/
            var pessoasMaisDoisIrmaos = pessoas.Where(p => p.QuantidadeIrmaos > 2); // uau


            /*foreach (var pessoa in pessoas) { 

            }*/
            foreach (Pessoa p in pessoasMaisDoisIrmaos)
            {
                Console.WriteLine("{0}, {1}, {2}", p.Nome, p.Idade, p.QuantidadeIrmaos);
            }
            Console.WriteLine("************************************");
            //nome e idade das pessoas maiores de idade
            /*var pessoasMaioresIdade = from pessoa in pessoas
                                      where pessoa.Idade > 18
                                      orderby pessoa.Idade descending
                                      select new { pessoa.Nome, pessoa.Idade };*/
            var pessoasMaioresIdade = pessoas
                                        .Where(pessoa => pessoa.Idade > 18)
                                        .OrderByDescending(o => o.Nome.Length)
                                        .ThenBy(t=> t.Idade) //colocar varios para mais ordem.
                                        .Select(sel => new {sel.Nome,sel.Idade });
            // UAU !!!

            foreach (var pessoa in pessoasMaioresIdade)
            {
                Console.WriteLine("{0}, {1}", pessoa.Nome, pessoa.Idade);
            }

            Console.ReadKey();



        }

        static List<Pessoa> CarregarListaPessoa()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.Add(new Pessoa
            {
                Nome = "João",
                Idade = 19,
                QuantidadeIrmaos = 2
            });
            pessoas.Add(new Pessoa
            {
                Nome = "Maria",
                Idade = 15,
                QuantidadeIrmaos = 4
            });

            pessoas.Add(new Pessoa
            {
                Nome = "Ana",
                Idade = 50,
                QuantidadeIrmaos = 5
            });

            return pessoas;
        }
    }

    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int QuantidadeIrmaos { get; set; }
    }
}
/* MODELO ANTIGO 
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //fonte de dados para LINQ
            List<Pessoa> pessoas = CarregarListaPessoa();
            // 1 todas as pessoas com mais de 2 irmãos
            IEnumerable<Pessoa> pessoasMaisDoisIrmaos = from pessoa in pessoas
                                        where pessoa.QuantidadeIrmaos > 2
                                        select pessoa;

            /*foreach (var pessoa in pessoas) { 

            }
            foreach (Pessoa p in pessoasMaisDoisIrmaos)
            {
                Console.WriteLine("{0}, {1}, {2}", p.Nome, p.Idade, p.QuantidadeIrmaos);
            }
            Console.WriteLine("************************************");
            //nome e idade das pessoas maiores de idade
            var pessoasMaioresIdade = from pessoa in pessoas
                                      where pessoa.Idade > 18
                                      orderby pessoa.Idade descending
                                      select new { pessoa.Nome, pessoa.Idade };

            foreach (var pessoa in pessoasMaioresIdade)
            {
                Console.WriteLine("{0}, {1}", pessoa.Nome, pessoa.Idade);
            }

            Console.ReadKey();



        }

        static List<Pessoa> CarregarListaPessoa()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.Add(new Pessoa
            {
                Nome = "João",
                Idade = 19,
                QuantidadeIrmaos = 2
            });
            pessoas.Add(new Pessoa
            {
                Nome = "Maria",
                Idade = 15,
                QuantidadeIrmaos = 4
            });

            pessoas.Add(new Pessoa
            {
                Nome = "Ana",
                Idade = 50,
                QuantidadeIrmaos = 5
            });

            return pessoas;
        }
    }

    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int QuantidadeIrmaos { get; set; }
    }
}

 */
