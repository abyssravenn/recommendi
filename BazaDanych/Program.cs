using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazaDanych
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            DataClasses1DataContext dc = new DataClasses1DataContext();

            Game gg = new Game();
            gg.Id = 100000;
            gg.Name = "Bardzo fajna gra";
            gg.Details = "cos tam";

            dc.Game.InsertOnSubmit(gg);
            dc.SubmitChanges();
            

        }
    }
}
