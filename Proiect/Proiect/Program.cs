using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Proiect
{
    class Program
    {
        static void Main(string[] args)
        {
            //Date pentru formular
            FormularAgenda form1 = new FormularAgenda();
            form1.Show();
            Application.Run();

            //Date pentru consola

            Console.ForegroundColor = ConsoleColor.Green;
            var afis_agenda = string.Format("\n\n{0,60}","AGENDA");
            Console.WriteLine("\n{0}",afis_agenda);
            DateTime d = DateTime.Now;
            Console.WriteLine("\n{0,67}",d);
            Console.ReadKey();
            
            //Creare si citire date din fisierul text

            Agenda[] agenda;
            IStocareData adminPersoane = StocareFactory.GetAdministratorStocare();
            int contor;
            agenda  = adminPersoane.GetPersoane(out contor);
            Console.ForegroundColor = ConsoleColor.White;
            string optiune;
            do
            {
                Console.Clear();
                Console.WriteLine("A. Adaugare persoane in agenda prin intermediul constructorilor");
                Console.WriteLine("T. Adaugare persoane in agenda prin intermediul citirii de la tastatura");
                Console.WriteLine("P. Afisare persoane din agenda in consola");
                Console.WriteLine("C. Comparare a 2 persoane din agenda dupa varsta");
                Console.WriteLine("M. Cautare persoana dupa nume si modificare acestuia");
                Console.WriteLine("X. Iesire program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {


                    case "A":

                        Grup serviciu = Grup.Serviciu;
                        Provenienta provenienta = Provenienta.Germania;
                        var persoana1 = new Agenda("Popescu", "Ioan", "23.6.1989", "0752024987", "popescuion@yahoo.com",serviciu,provenienta);
                        agenda[contor++] = persoana1;
                        adminPersoane.AddSPersoana_InFisier(persoana1);
                        var persoana2 = new Agenda("Ionescu Radu 8.12.1992 075898782 radu_ionescu@gmail.com Familie Romania");
                        agenda[contor++] = persoana2;
                        adminPersoane.AddSPersoana_InFisier(persoana2);
                        var persoana3 = new Agenda("Rusu Lacry 19.10.2003 2345678091 lacryrusu@student.usv.ro Prieteni Spania");
                        agenda[contor++] = persoana3;
                        adminPersoane.AddSPersoana_InFisier(persoana3);

                        break;


                    case "T":

                        Console.WriteLine("Introdu numele persoanei pe care vrei sa o adaugi in agenda:");
                        string _nume = Console.ReadLine();
                        Console.WriteLine("Introdu prenumele persoanei pe care vrei sa o adaugi in agenda:");
                        string _prenume = Console.ReadLine();
                        Console.WriteLine("Introdu data nasterii a persoanei pe care vrei sa o adaugi in agenda:");
                        string _data_nastere = Console.ReadLine();
                        Console.WriteLine("Introdu numarul de telefon al persoanei pe care vrei sa o adaugi in agenda:");
                        string _nr_telefon = Console.ReadLine();
                        Console.WriteLine("Introdu adresa de email a persoanei pe care vrei sa o adaugi in agenda:");
                        string _adresa_email = Console.ReadLine();
                        Console.WriteLine("Introdu grupul in care ai vrea sa fie introdusa persoana:");
                        string grup0 = Console.ReadLine();
                        Grup grup1= (Grup)Enum.Parse(typeof(Grup), grup0);
                        Console.WriteLine("Introdu tara de provenienta a persoanei pe care doresti sa o introdui in agenda:");
                        string provenienta0 = Console.ReadLine();
                        Provenienta provenienta1 = (Provenienta)Enum.Parse(typeof(Provenienta), provenienta0);
                        var persoana4 = new Agenda(_nume, _prenume, _data_nastere, _nr_telefon, _adresa_email,grup1,provenienta1);
                        agenda[contor++] = persoana4;
                        adminPersoane.AddSPersoana_InFisier(persoana4);
                        Console.ReadKey();

                        break;


                    case "P":

                           if (contor == 0) //validare
                        {
                            Console.WriteLine("Nu se poate realiza optiunea selectata din pricina lipsei personelor din agenda");
                            Console.WriteLine("Introdu o persoana in agenda si apoi selceteaza din nou optiunea curenta");
                            Console.ReadKey();
                            break;
                        }

                        var header = string.Format("{0,-12}{1,8}{2,20}{3,21}{4,29}{5,15}{6,26}\n"
                                                    ,"Nume", "Prenume", "Data de nastere", "Numar de telefon", "Adresa de email", "Grup", "Tara de provenienta");
                        Console.WriteLine(header);
                        for (int i = 0; i < contor; i++)
                            Console.WriteLine(agenda[i].ConversieLaSir());
                        Console.ReadKey();

                        break;

                    case "M":

                        if (contor == 0)  //validare
                        {
                            Console.WriteLine("Nu se poate realiza optiunea selectata din pricina lipsei personelor din agenda");
                            Console.WriteLine("Introdu o persoana in agenda si apoi selceteaza din nou optiunea curenta");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Alege persoana careia vrei sa-i modifici numele?");
                        for (int l = 0; l < contor; l++)
                            Console.WriteLine("{0}.{1}",l+1,agenda[l].NumeComplet);
                        int id = Convert.ToInt32(Console.ReadLine());
                        if (id > contor)
                            id = ValidareDate(id, contor);  //validare

                        Console.WriteLine("Introdu numele nou pe care ai dori sa-l atribui persoanei selectate:");
                            string nume_nou = Console.ReadLine();

                        Console.WriteLine("Introdu prenumele nou pe care ai dori sa-l atribui persoanei selectate:");
                            string prenume_nou = Console.ReadLine();

                        agenda[id - 1].CautaSiModifica(nume_nou, prenume_nou);
                        adminPersoane.ModificareDateFisier(agenda, contor);
                        Console.ReadKey();

                        break;


                    case "C":

                        if (contor == 0 || contor==1)   //validare
                        {
                            Console.WriteLine("Nu se poate realiza optiunea selectata din pricina lipsei personelor din agenda");
                            Console.WriteLine("Introdu o persoana in agenda si apoi selceteaza din nou optiunea curenta");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Alegeti 2 persoane din agenda pe care doriti sa le comparati");
                        for (int j = 0; j < contor; j++)
                            Console.WriteLine("{0}.{1}", j+1, agenda[j].NumeComplet);

                        Console.WriteLine("Alegeti indexul primei persoana pe care doriti sa o comparati");
                        int pers1 = Convert.ToInt32(Console.ReadLine());
                        if (pers1 > contor)
                            pers1 = ValidareDate(pers1, contor);  //validare

                        Console.WriteLine("Alegeti indexul celei de-a doua persoane pe care doriti sa o comparati");
                        int pers2 = Convert.ToInt32(Console.ReadLine());
                        if(pers2 > contor)
                            pers2 = ValidareDate(pers2, contor);   //validare

                        if (agenda[pers1 - 1].ComparareVarsta(agenda[pers2 - 1]) == 0)
                            Console.WriteLine("{0} si {1} au aceeasi varsta", agenda[pers1 - 1].NumeComplet, agenda[pers2 - 1].NumeComplet);
                            
                        else if (agenda[pers1 - 1].ComparareVarsta(agenda[pers2 - 1]) == 1)
                            Console.WriteLine("{0} este mai mare decat {1} ", agenda[pers1 - 1].NumeComplet, agenda[pers2 - 1].NumeComplet);

                        else

                            Console.WriteLine("{0} este mai mare decat {1} ", agenda[pers2 - 1].NumeComplet, agenda[pers1 - 1].NumeComplet);
                        Console.WriteLine("{0} -> ({1})", agenda[pers1 - 1].NumeComplet, agenda[pers1 - 1].getDataNastere);
                        Console.WriteLine("{0} -> ({1})", agenda[pers2 - 1].NumeComplet, agenda[pers2 - 1].getDataNastere);
                        Console.ReadKey();

                        break;

                }
            } while (optiune.ToUpper() != "X");
            Console.ReadKey();
        }

        public static int ValidareDate(int id, int contor)
        {
            while (id > contor)
            {
                Console.WriteLine("Optiune gresita\nAlegeti o optiune existenta");
                id = Convert.ToInt32(Console.ReadLine());
            }
            return id;
        }
      

    }

}
