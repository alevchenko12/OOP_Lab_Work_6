using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work_6
{
    public  class Compressor : BaseComponent
    {
        //Компресор відповідає за стиснення та циркуляцію холодоагенту в системі охолодження холодильника.
        //Він підвищує тиск і температуру холодоагенту, дозволяючи йому виділяти тепло під час проходження через конденсатор.

        //max припустима температура
        public const double MAXTemp = 10;

        //min припустима температура
        public const double MINTemp = 0;

        //поточна температура 
        public double temperature = 5;

        /// <summary>
        /// конструктор який задає початкове значення тепмератури 5
        /// </summary>
        public Compressor()
        {
            temperature = 5;
        }

        /// <summary>
        /// зміна температури компресора на рівні компресора
        /// </summary>
        /// <param name="temp">бажана температура</param>
        private void ChangeTempComp(double temp)
        {
            if (temperature == temp)
            {
                Console.WriteLine("The current temperature is that you want");
                return;
            }
            if (temp < MAXTemp && temp > MINTemp)
            {
                this.temperature = temp;
                Console.WriteLine("Temperature has changed");
                Console.WriteLine($"Temperature: {temperature}");
                return;
            }
            if (temp > MAXTemp)
            {
                this.temperature = temp;
                CompressorException CompBreak = new CompressorException("Too high temperature! Overheated!");
                throw CompBreak;
            }
            if (temp < MINTemp)
            {
                this.temperature = temp;
                CompressorException CompBreak = new CompressorException("Too low temperature! Overcooled!");
                throw CompBreak;
            }
        }

        /// <summary>
        /// зміна температури
        /// </summary>
        public void ChangeTemperature()
        { 
            Console.WriteLine("Enter please temperature you want to change to: ");
            Console.WriteLine("Temperature has to be in range from " + MINTemp + " to " + MAXTemp);
            double temp = Convert.ToDouble(Console.ReadLine());
            try
            {
                ChangeTempComp(temp);
            }
            catch(CompressorException CompBreak)
            {
                Console.WriteLine(CompBreak.Message);
            }
        }

        /// <summary>
        /// перевизначений метод для відправлення звіту про роботу 
        /// </summary>
        /// <returns>звіт про рпоботу</returns>
        public override string ReportComponent()
        {

            string info = "Compressor: ";
            if (temperature > MINTemp && temperature < MAXTemp)
            {
                info = info + "all right";
                return info;
            }
            if (temperature > MAXTemp)
            {
                info = info + "breakdown because of overheating";
                return info;
            }
            if (temperature < MINTemp)
            {
                info = info + "breackdown because of overcooling";
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
            string info = "Compressor: ";
            info = info + "Some info about how to repair Compressor";
            return info;
        }
    }

    internal class CompressorException: ApplicationException 
    {
        // повідомлення про збій в роботі
        private string messageDetails;

        /// <summary>
        /// конструктор без параметрів для класу вийнятку
        /// </summary>
        public CompressorException()
        {
            messageDetails = "";
        }

        /// <summary>
        /// конструктор з параметрами для класу вийнятку
        /// </summary>
        /// <param name="messageDetails">детальне повідомлення про збій</param>
        public CompressorException(string messageDetails) 
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
                return string.Format("Message about breakdown of Compressor: {0}", messageDetails); ; 
            }
        }
    }
}
