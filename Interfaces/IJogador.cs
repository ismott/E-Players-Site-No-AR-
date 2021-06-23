using System.Collections.Generic;
using BEEPlayers.Models;

namespace BEEPlayers.Interfaces
{
    public interface IJogador
    {
        void Criar(Jogador j);

        List<Jogador> LerTodas();

        void Alterar(Jogador j);

        void Deletar(int id);
    }
}