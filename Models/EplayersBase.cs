using System.Collections.Generic;
using System.IO;

namespace BEEPlayers.Models
{
    public class EplayersBase
    {
        public void CriarPastaEArquivo(string _caminho){
            string pasta = _caminho.Split("/")[0];
            string arquivo = _caminho.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Close();
            }
        }

        public List<string> LerTodasAsLinhasCsv(string _caminho){
            List<string> linhas = new List<string>();

            using (StreamReader arquivo = new StreamReader(_caminho))
            {
                string linha;
                while ((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }

        public void ReescreverCsv(string _caminho, List<string> linhas){
            using (StreamWriter output = new StreamWriter(_caminho))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}