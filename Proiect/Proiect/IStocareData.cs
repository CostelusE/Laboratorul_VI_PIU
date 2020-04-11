using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proiect
{
    public interface IStocareData
    {
        void AddSPersoana_InFisier(Agenda persoana);
        Agenda[] GetPersoane(out int nrPersoane);
        void ModificareDateFisier(Agenda[] persoane, int nrPersoane);
    }
}
