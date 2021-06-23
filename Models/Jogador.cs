using System;
using System.Collections.Generic;
using System.IO;
using BEEPlayers.Interfaces;

namespace BEEPlayers.Models
{
    public class Jogador : EplayersBase, IJogador
    {
        public int IdJogador { get; set; }
        
        public string Nome { get; set; }
        
        public int IdEquipe { get; set; }
        
        public string Email { get; set; }

        public string Senha { get; set; }

        public const string CAMINHO = "Database/jogador.csv";
        
        public Jogador(){
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Jogador j){
            return $"{j.IdJogador};{j.Nome};{j.IdEquipe};{j.Email};{j.Senha}";
        }

        public void Criar(Jogador j)
        {
            string[] linha = {Preparar(j)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Jogador> LerTodas()
        {
            List<Jogador> jogadores = new List<Jogador>();

            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador novoJogador = new Jogador();

                novoJogador.IdJogador = Int32.Parse(linha[0]);
                novoJogador.Nome = linha[1];
                novoJogador.IdEquipe = Int32.Parse(linha[2]);
                novoJogador.Email = linha[3];
                novoJogador.Senha = linha[4];
                jogadores.Add(novoJogador);
            }
            return jogadores;
        }

        public void Alterar(Jogador j)
        {
            List<string> linhas = LerTodasAsLinhasCsv(CAMINHO);
            linhas.RemoveAll(x =>x.Split(";")[0] == j.IdEquipe.ToString());
            linhas.Add(Preparar(j));
            ReescreverCsv(CAMINHO, linhas);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasAsLinhasCsv(CAMINHO);
            linhas.RemoveAll(x =>x.Split(";")[0] == id.ToString());
            ReescreverCsv(CAMINHO, linhas);
        }
    }
}