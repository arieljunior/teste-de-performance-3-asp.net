using asp_tp3_ariel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_tp3_ariel.FakeDB
{
    public class Banco
    {
        private static List<PessoaModel> ListaPessoas = new List<PessoaModel>();

        public void adicionarPessoa(PessoaModel p) //Método que recebe uma pessoa
        {
            PessoaModel pessoa = new PessoaModel() // Instâncio uma nova pessoa
            {
                Id = ListaPessoas.Count() + 1, //Obtenho o tamano da lista (.Count()) que retorna um Int e adiciono mais 1 para o id nunca ser repetido
                Nome = p.Nome,                 //Complemento essa instância com a pessoa que recebi através do método
                Sobrenome = p.Sobrenome,
                DataNascimento = p.DataNascimento
            };

            ListaPessoas.Add(pessoa);
        }

        public List<PessoaModel> getListaPessoas() //Metodo que retorna a lista
        {
            return ListaPessoas;
        }

        public PessoaModel BuscarPessoa(int id) //Metodo retorna uma pessoa
        {
            PessoaModel pessoa = new PessoaModel();

            foreach (var p in ListaPessoas) //Varrendo a lista
            {
                if (p.Id == id) // Verifico se o id da lista é igual ao id do parâmetro do método, caso seja, é a pessoa que estava procurando
                {
                    pessoa.Id = p.Id; //incremento a pessoa que instânciei em cima com a pessoa que encontrei na lista
                    pessoa.Nome = p.Nome;
                    pessoa.Sobrenome = p.Sobrenome;
                    pessoa.DataNascimento = p.DataNascimento;
                }
            }

            return pessoa; //Retorno a pessoa. 
                           //Caso a pessoa não seja encontrada no foreach, esta pessoa estará vazia
        }

        public void AtualizarPessoa(PessoaModel pessoa)
        {
            foreach(var p in ListaPessoas)
            {
                if (p.Id == pessoa.Id) //Caso o id encontrado na lista seja igual o id da pessoa recebido como parâmetro
                {
                    p.Nome = pessoa.Nome; //Atualizo os dados na lista com os dados que foram passados nesse método
                    p.Sobrenome = pessoa.Sobrenome;
                    p.DataNascimento = pessoa.DataNascimento;
                    break; //Paro o foreach. não há necessitade de continuar varrendo se já encontramos e atualizamos a pessoa
                }
            }
        }

        public void RemoverPessoa(PessoaModel pessoa)
        {
            int posicaoEncontrada = ListaPessoas.FindIndex(x => x.Id == pessoa.Id); //Pego a posição (index) na lista onde os id's são iguais
            ListaPessoas.Remove(ListaPessoas[posicaoEncontrada]); //Removo passando a posição encontrada
        }


    }
}