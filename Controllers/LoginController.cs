using System.Collections.Generic;
using BEEPlayers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEEPlayers.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]
        public string MensagemErro { get; set; }
        
        Jogador JogadorModel = new Jogador();

        [Route("Listar")]
        public IActionResult Index(){
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form){
            List<string> JogadoresCSV = JogadorModel.LerTodasAsLinhasCsv("Database/jogador.csv");

            var logado = JogadoresCSV.Find(
                x =>
                x.Split(";")[3] == form["Email"] &&
                x.Split(";")[4] == form["Senha"]
            );

            if (logado != null)
            {
                HttpContext.Session.SetString("_userName", logado.Split(";")[1]);
                return LocalRedirect("~/");
            }
            else
            {
                MensagemErro = "Dados incorretos tente novamente!";
                return LocalRedirect("~/Login/Listar");
            }
        }

        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("_userName");
            return LocalRedirect("~/");
        }
    }
}