using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work_6
{
    public class Condenser : Fridge
    {
        //Конденсатор — це теплообмінний компонент, який допомагає відводити тепло від холодоагенту.
        //Він охолоджує холодоагент під високим тиском і високою температурою, передаючи тепло навколишньому повітрю або воді.

        //max припустий тиск
        public const int MINPreasurre = 120;

        //min припустий тиск
        public const int MAXPreasurre = 180;

        //поточний тиск
        public int preassure = 160;

        /// <summary>
        /// конструктор який задає початкове значення тиску 160
        /// </summary>
        public Condenser()
        {
            preassure = 160;
        }

        /// <summary>
        /// зміна тиску на потрібний тиск
        /// </summary>
        /// <param name="temperature">поточна темепература</param>
        private void ChangePreassureCondes(int temperature)
        {
            if (temperature == Compressor.MINTemp)
            {
                preassure = MINPreasurre;
                Console.WriteLine("Preassure: " + preassure);
                return;
            }
            if (temperature == Compressor.MAXTemp)
            {
                preassure = MAXPreasurre;
                Console.WriteLine("Preassure: " + preassure);
                return;
            }
            if (temperature < Compressor.MAXTemp && temperature > Compressor.MINTemp)
            {
                Random random = new Random();
                preassure = random.Next(MINPreasurre, MAXPreasurre);
                Console.WriteLine("Preassure: " + preassure);
                return;
            }
            if (temperature > Compressor.MAXTemp)
            {
                preassure = 200;
                CondenserException CondesBreack = new CondenserException("Too high preassure! Risk of explosion!");
                throw CondesBreack;
            }
            if (temperature < Compressor.MINTemp)
            {
                preassure = 100;
                CondenserException CondesBreack = new CondenserException("Too low preassure! Risk of leaking Refrigerant!");
                throw CondesBreack;
            }
        }

        /// <summary>
        /// зміна тиску
        /// </summary>
        public void ChangePreassure()
        {
            Console.WriteLine("Changing of preassure due to change of temperature:");
            int temp = Convert.ToInt32(Console.ReadLine());
            try
            {
                ChangePreassureCondes(temp);
            }
            catch (CondenserException CondesBreack)
            {
                Console.WriteLine(CondesBreack.Message);
            }
        }

        /// <summary>
        /// перевизначений метод для відправлення звіту про роботу 
        /// </summary>
        /// <returns>звіт про рпоботу</returns>
        public override string ReportComponent()
        {
            string info = "Condenser: ";
            if (preassure > MINPreasurre && preassure < MAXPreasurre)
            {
                info = info + "all right";
                return info;
            }
            if (preassure > MAXPreasurre)
            {
                info = info + "breakdown because of high preassure";
                return info;
            }
            if (preassure < MINPreasurre)
            {
                info = info + "breackdown because of low preassure";
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
            string info = "Condenser: ";
            info = info + "Some info about how to repair Condenser";
            return info;
        }

    }

    internal class CondenserException : ApplicationException
    {
        // повідомлення про збій в роботі
        private string messageDetails;

        /// <summary>
        /// конструктор без параметрів для класу вийнятку
        /// </summary>
        public CondenserException()
        {
            messageDetails = "";
        }

        /// <summary>
        /// конструктор з параметрами для класу вийнятку
        /// </summary>
        /// <param name="messageDetails">детальне повідомлення про збій</param>
        public CondenserException(string messageDetails)
        {
            this.messageDetails = messageDetails;
        }


        /// <summary>
        /// превизначена віртуальна властивість Message 
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Format("Message about breakdown of Condenser: {0}", messageDetails); ;
            }
        }
    }
}
