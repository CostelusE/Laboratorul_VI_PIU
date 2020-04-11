using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proiect
{
    public class AdministrareAgenda_FisierText : IStocareData
    {
        //date membrea ale clasei

        private const int PAS_ALOCARE = 20;
        string NumeFisier { get; set; }
        
        //constructor cu parametru de tip string

        public AdministrareAgenda_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();
        }

            //implementare functii din IStocareData

            public void AddSPersoana_InFisier(Agenda persoana)
            {
                try
                {
                    //instructiunea 'using' va apela la final swFisierText.Close();
                    //al doilea parametru setat la 'true' al constructorului StreamWriter indica modul 'append' de deschidere al fisierului
                    using (StreamWriter swFisierText = new StreamWriter(NumeFisier,true))
                    {
                        swFisierText.WriteLine(persoana.ConversieLaSir_PentruFisier());
                    }
                }

                catch (IOException eIO)
                {
                    throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
                }

                catch (Exception eGen)
                {
                    throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
                }
            }


        public Agenda[] GetPersoane(out int nrPersoane)
        {

            Agenda[] persoane = new Agenda[PAS_ALOCARE];

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    nrPersoane = 0;

                    //citeste cate o linie si creaza un obiect de tip Agenda pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        persoane[nrPersoane++] = new Agenda(line);
                        if (nrPersoane == PAS_ALOCARE)
                        {
                            Array.Resize(ref persoane, nrPersoane + PAS_ALOCARE);
                        }
                    }
                    sr.ReadLine();
                   
                }
            }

            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }

            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return persoane;
        }

        public void ModificareDateFisier(Agenda[] persoane , int nrPersoane)
        {

            using (StreamWriter newFisierText = new StreamWriter(NumeFisier))
                for (int j = 0; j < nrPersoane; j++)
                    newFisierText.WriteLine(persoane[j].ConversieLaSir_PentruFisier());
        }
    }
}  
