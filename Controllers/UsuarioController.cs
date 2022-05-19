using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ATIVIDADE_2.Models;
using Microsoft.AspNetCore.Http;

namespace ATIVIDADE_2.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {

            UsuarioRepository ur = new UsuarioRepository();
            Usuario user = ur.ValidarLogin(usuario);

            if (user == null)
            {
                ViewBag.Message = "Falha no login!";
                return View();

            }
            else
            {
                ViewBag.Message = "Você está logado!";


                HttpContext.Session.SetInt32("IdUsuario", user.Id);
                HttpContext.Session.SetString("NomeUsuario", user.Nome);


                return View();
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        public IActionResult Lista()
        {
            //validação = se nao tiver logado, chama a View de login
            if (HttpContext.Session.GetInt32("IdUsuario")==null)
            return RedirectToAction("Login","Usuario");

            UsuarioRepository ur = new UsuarioRepository();

            List<Usuario> listagem = ur.Listar();

            return View(listagem);
        }


        public IActionResult Remover(int Id)
        {
            //validação = se nao tiver logado, chama a View de login
            if (HttpContext.Session.GetInt32("IdUsuario")==null)
            return RedirectToAction("Login","Usuario");

            UsuarioRepository ur = new UsuarioRepository();
            Usuario userEncontrado = ur.BuscarPorID(Id);
            ur.Remover(userEncontrado);
            return RedirectToAction("Lista", "Usuario");

        }

        public IActionResult Editar(int Id)
        {
            //validação = se nao tiver logado, chama a View de login
            if (HttpContext.Session.GetInt32("IdUsuario")==null)
            return RedirectToAction("Login","Usuario");

            UsuarioRepository ur = new UsuarioRepository();
            Usuario UserEncontrado = ur.BuscarPorID(Id);
            return View(UserEncontrado);


        }


        [HttpPost]

        public IActionResult Editar(Usuario usuario)
        {
            UsuarioRepository ur = new UsuarioRepository();
            ur.Atualizar(usuario);
            return RedirectToAction("Lista", "Usuario");

        }


        public IActionResult Cadastro()
        {
            //******restrição somente na PacotesTuristicosController*****
            return View();

        }


        [HttpPost]

        public IActionResult Cadastro(Usuario usuario)
        {
            UsuarioRepository ur = new UsuarioRepository();
            ur.Inserir(usuario);
            @ViewBag.Menssage = "Cadastro realizado com sucesso";
            return View();

        }
    }

}