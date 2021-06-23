using System.Collections.Generic;
using BEEPlayers.Models;

namespace BEEPlayers.Interfaces
{
    public interface IEquipe
    {
         void Criar(Equipe e);

         List<Equipe> LerTodas();

         void Alterar(Equipe e);

         void Deletar(int id);
    }
}