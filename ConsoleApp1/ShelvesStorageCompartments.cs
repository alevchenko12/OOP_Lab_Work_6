using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work_6
{
    public class ShelvesStorageCompartments: BaseComponent
    {
        //Ці компоненти забезпечують організацію та простір для зберігання всередині холодильника.
        //Полиці дозволяють розділяти та розташовувати харчові продукти,
        //тоді як відділення для зберігання, такі як ящики для овочів або дверні ящики, пропонують спеціальні зони для зберігання різних типів продуктів.

        //кількість овочів в кг які може містити одна шухляда
        public const int amountVeget = 2;

        //кількість фруктів в кг які може містити одна шухляда
        public const int amountFuit = 3;

        //кількість яєць в штуках які може містити однин лоток
        public const int amountEgg = 10;

        public override string ReportComponent()
        {
            Console.WriteLine("ShelvesStorageCompartments: ");
            return base.ReportComponent();
        }

        public override string ReportBreackdown()
        {
            Console.WriteLine("ShelvesStorageCompartments: ");
            return base.ReportBreackdown();
        }
    }
}
