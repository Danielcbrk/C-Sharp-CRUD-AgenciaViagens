using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ATIVIDADE_2.Models;
using Microsoft.AspNetCore.Http;


namespace ATIVIDADE_2.Controllers
{
    public class PacotesTuristicosController : Controller
    {
        public IActionResult Lista()
        {
            //desenvolver o corpo da acao da controller 
            //validação = se nao tiver logado, chama a View de login
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();

            List<PacotesTuristicos> listagem = ur.Listar();

            return View(listagem);

        }



        public IActionResult Remover(int Id)
        {
            //desenvolver o corpo da acao da controller 
            //validação = se nao tiver logado, chama a View de login
            //**if (HttpContext.Session.GetInt32("IdPacotesTuristicos") == null)
            //**return RedirectToAction("Login", "PacotesTuristicos")
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();
            PacotesTuristicos pacEncontrado = ur.BuscarPorID(Id);
            ur.Remover(pacEncontrado);
            return RedirectToAction("Lista", "PacotesTuristicos");
        }

        public IActionResult Editar(int Id)
        {
            //validação = se nao tiver logado, chama a View de login
            //if (HttpContext.Session.GetInt32("IdUsuario") == null)
            //return RedirectToAction("Login","Usuario");

            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();
            PacotesTuristicos pacEncontrado = ur.BuscarPorID(Id);
            return View(pacEncontrado);
            //desenvolver o corpo da acao da controller               
        }

        [HttpPost]
        public IActionResult Editar(PacotesTuristicos pacotesturisticos)
        {
            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();
            ur.Atualizar(pacotesturisticos);
            return RedirectToAction("Lista", "PacotesTuristicos"); //acao,controller
        }


        public IActionResult Cadastro()
        {
            //******restrição somente na PacotesTuristicosController*****
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(PacotesTuristicos pacotesturisticos)
        {
            PacotesTuristicosRepository ur = new PacotesTuristicosRepository();
            ur.Inserir(pacotesturisticos);
            @ViewBag.Message = "Cadastro realizado com sucesso";
            return View();


        }



    }
}