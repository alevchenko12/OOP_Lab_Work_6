using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work_6
{
    public class Thermostat : BaseComponent
    {
        //Термостат - це термочутливий пристрій, який контролює та регулює температуру всередині холодильника.
        //Він керує роботою компресора, сигналізуючи про ввімкнення або вимкнення для підтримки бажаного налаштування температури.

        public override string ReportComponent()
        {
            Console.WriteLine("Thermostat: ");
            return base.ReportComponent();
        }

        public override string ReportBreackdown()
        {
            Console.WriteLine("Thermostat: ");
            return base.ReportBreackdown();
        }
    }
}
