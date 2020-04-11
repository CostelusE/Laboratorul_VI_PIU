using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Proiect
{
    class StocareFactory
    {
        private const string FORMAT_SALVARE = "NumeFisier";
        private const string NUME_FISIER = "FormatSalvare";
        public static IStocareData GetAdministratorStocare()
        {
            var formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            var numeFisier = ConfigurationManager.AppSettings[NUME_FISIER];
            if (formatSalvare != null)
            {

             
                  
                        return new AdministrareAgenda_FisierText(numeFisier + "." + formatSalvare);

                
            }

            return null;
        }
    }
}
