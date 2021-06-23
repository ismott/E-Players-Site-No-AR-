using System;
using BEEPlayers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEEPlayers.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {

        Jogador jogadorModel = new Jogador();
        
        [Route("Listar")]
        public IActionResult Index(){
            ViewBag.jogadores = jogadorModel.LerTodas();       
            return View();
        }
        
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){
            Jogador novoJogador = new Jogador();

            novoJogador.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            novoJogador.Nome = form["Nome"];
            novoJogador.Email = form["Email"];
            novoJogador.Senha = form["Senha"];

            jogadorModel.Criar(novoJogador);
            ViewBag.jogadores = jogadorModel.LerTodas();
            
            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id){
            jogadorModel.Deletar(id);
            ViewBag.Equipes = jogadorModel.LerTodas();
            return LocalRedirect("~/Equipe/Listar");
        }
    }
}