using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work_6
{
    public class Evaporator : BaseComponent
    {
        //Випарник розташований всередині холодильника і відповідає за поглинання тепла з внутрішньої камери.
        //Холодоагент низького тиску та низької температури надходить у випарник, спричиняючи охолодження навколишнього повітря.
        //Цей процес охолоджує внутрішню частину холодильника.

        //максимальна кількість охолождуюючої рідини
        public const double MAXVOLUMEREFRIG = 200;
        //мінімальна кількість охолождуюючої рідини
        public const double MINVOLUMEREFRIG = 100;

        //кількість охолоджуючої рідини
        public double volumeRefrig;

        /// <summary>
        /// перевизначений метод для відправлення звіту про роботу 
        /// </summary>
        /// <returns>звіт про рпоботу</returns>
        public override string ReportComponent()
        {
            string info = "Evaporator: ";
            if (volumeRefrig > MINVOLUMEREFRIG && volumeRefrig < MAXVOLUMEREFRIG)
            {
                info = info + "all right";
                return info;
            }
            if (volumeRefrig > MAXVOLUMEREFRIG)
            {
                info = info + "breakdown because of lack of refrigerant liquid! Add some liquid.";
                return info;
            }
            if (volumeRefrig < MINVOLUMEREFRIG)
            {
                info = info + "breackdown because of leak of refrigerany liquid! Remove some liquid.";
                return info;
            }
            else return base.ReportComponent();
        }

        /// <summary>
        /// перевизначений метод для відправлення звіту про поломку
        /// </summary>
        /// <returns></returns>
        public override string ReportBreackdown()
        {
            string info = "Evaporator: ";
            info = info + "Some info about how to repair Condenser";
            return info;
        }
    }
}
