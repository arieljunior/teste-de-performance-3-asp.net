using asp_tp3_ariel.FakeDB;
using asp_tp3_ariel.Models;
using asp_tp3_ariel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_tp3_ariel.Controllers
{
    public class PessoaController : Controller
    {
        Banco database = new Banco();

        public ActionResult Index()
        {
            return View(database.getListaPessoas());
        }
        
        public ActionResult Details(int id)
        {
            PessoaModel PessoaEncontrada = database.BuscarPessoa(id);
            return View(PessoaEncontrada);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PessoaModel p)
        {
            try
            {
                database.adicionarPessoa(p);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            PessoaModel PessoaEncontrada = database.BuscarPessoa(id);
            return View(PessoaEncontrada);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(PessoaModel pessoa)
        { 
            try
            {
                database.AtualizarPessoa(pessoa);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            PessoaModel pessoaEncontrada = database.BuscarPessoa(id);
            return View(pessoaEncontrada);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(PessoaModel pessoa)
        {
            try
            {
                database.RemoverPessoa(pessoa);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult BuscarPessoa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarPessoa(string nome)
        {
            try
            {
                var PessoasEncontradas = database.BuscarNome(nome);
                return View(PessoasEncontradas);
            }catch(Exception ex)
            {
                return View();
            }
        }
    }
}
