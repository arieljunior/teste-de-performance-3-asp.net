using asp_tp3_ariel.FakeDB;
using asp_tp3_ariel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_tp3_ariel.Controllers
{
    public class PessoaController : Controller
    {
        Banco database = new Banco(); //Instanciando a classe que estou usando como banco, para usar os métodos nela

        public ActionResult Index()
        {
            return View(database.getListaPessoas()); //Chamando um método que está no banco fake que retorna uma lista e passando para a View
        }
        
        public ActionResult Details(int id)
        {
            PessoaModel PessoaEncontrada = database.BuscarPessoa(id); //Chamando metodo passando um id(int) que irá me retornar uma pessoa. Estou salvando essa pessoa em uma variável do tipo PessoaModel
            return View(PessoaEncontrada); // Passando a pessoa encontrada para a View (pego através do método BuscarPessoa)
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PessoaModel p) //O parâmetro (PessoaModel) é trazido pela view quando o formulário é preenchido e enviado, realizando um Post
        {
            try
            {
                database.adicionarPessoa(p); //Passo o parâmetro recebido para o método que irá adiciona-lo na lista

                return RedirectToAction("Index"); //retorno pra página inicial (index)
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id) // este id é recebido quando clica em "Edit" na lista
        {
            PessoaModel PessoaEncontrada = database.BuscarPessoa(id); //Faço a busca e salvo em uma variável tipo PessoaModel
            return View(PessoaEncontrada); //Passo pra view
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(PessoaModel pessoa) //no Post do Edit recebo a pessoa atualizada
        {
            try
            {
                database.AtualizarPessoa(pessoa); //chamo o método atualizarPessoa passando a pessoa atualizada
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id) // este id é recebido quando clica em "Delete" na lista
        {
            PessoaModel pessoaEncontrada = database.BuscarPessoa(id); // mesmo trecho usado no método "Edit"
            return View(pessoaEncontrada); // ...
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(PessoaModel pessoa) //Recebo a pessoa que será deletada através do Post
        {
            try
            {
                database.RemoverPessoa(pessoa); //Passo a pessoa pro método para excluir

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
