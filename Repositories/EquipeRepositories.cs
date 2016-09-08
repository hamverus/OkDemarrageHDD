using Data;
using Entities;

namespace Repositories
{
    public class EquipeRepositories:BasicRepository<Equipe>,IBasicRepository<Equipe>
    {
        public EquipeRepositories(AQLM2Entities context) : base(context)
        {
        }
    }
}