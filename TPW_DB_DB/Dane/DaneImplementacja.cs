using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class DaneImplementacja : DaneAPI
    {
        private Logger logger;

        public override void DodajLogi(string wiadomosc)
        {
            this.logger.Dodaj_logi(wiadomosc);
        }

        public override void KoniecZapisow()
        {
            this.logger.koniecZapisow();
        }

        public override Kula KulaStworz(double predkosc, int srednica, double waga)
        {
            return new Kula(predkosc, srednica, waga);
        }

        public override void LoggerStworz(string filePath)
        {
           this.logger = new Logger(filePath);
        }

        public override Plansza PlanszaStworz()
        {
            return new Plansza();
        }

        public override void ZapiszLogi()
        {
            this.logger.zapiszLogi();
        }
    }
}
