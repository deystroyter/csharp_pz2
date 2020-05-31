using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FedorovAD___Pz_2
{
    [Serializable]
    public abstract class Software
    {
        /// <summary>
        /// Название программного обеспечения
        /// </summary>
        public string Name;
        /// <summary>
        /// Издатель программного обеспечения
        /// </summary>
        public string Creator;
        /// <summary>
        /// Доступность программного обеспечения
        /// </summary>
        public bool Availability;
        /// <summary>
        /// Получить информацию об ПО
        /// </summary>
        public abstract void GetInfo();
        /// <summary>
        /// Получить информацию о доступности об ПО
        /// </summary>
        public abstract bool GetAvailability();
    }
    /// <summary>
    /// Класс для бесплатного ПО
    /// </summary>
    [Serializable]
    public class FreeSoft : Software
    {
        /// <summary>
        /// Конструктор класса FreeSoft
        /// </summary>
        public FreeSoft(string SoftName, string SoftCreator)
        {
            Name = SoftName;
            Creator = SoftCreator;
            Availability = true;

        }
        /// <summary>
        /// Конструктор класса FreeSoft без параметров
        /// </summary>
        public FreeSoft()
        {

        }

        public override void GetInfo()
        {
            Trace.WriteLine("Вызван метод FreeSoft.GetInfo()...");
            Console.WriteLine($"Название ПО: {Name}");
            Console.WriteLine($"Издатель: {Creator}");
        }
        public override bool GetAvailability()
        {
            Trace.WriteLine("Вызван метод FreeSoft.GetAvailability()...");
            return Availability;
        }
    }
    /// <summary>
    /// Класс для условно-бесплатного ПО
    /// </summary>
    [Serializable]
    public class Shareware : Software
    {
        /// <summary>
        /// Дата установки ПО
        /// </summary>
        public DateTime InstallDate;
        /// <summary>
        /// Дней бесплатной лицензии
        /// </summary>
        public uint FreeLicenseDays;
        /// <summary>
        /// Конструктор класса Shareware
        /// </summary>
        public Shareware(string SoftName, string SoftCreator, DateTime SoftInstallDate, uint SoftDays)
        {
            Name = SoftName;
            Creator = SoftCreator;
            InstallDate = SoftInstallDate;
            FreeLicenseDays = SoftDays;
        }
        /// <summary>
        /// Конструктор класса Shareware без параметров
        /// </summary>
        public Shareware()
        {

        }
        public override void GetInfo()
        {
            Trace.WriteLine("Вызван метод Shareware.GetInfo()...");
            Console.WriteLine($"Название ПО: {Name}");
            Console.WriteLine($"Издатель: {Creator}");
            Console.WriteLine($"Дата установки: {InstallDate}");
            Console.WriteLine($"Дней бесплатной лицензии: {FreeLicenseDays}");
        }
        public override bool GetAvailability()
        {
            Trace.WriteLine("Вызван метод Shareware.GetAvailability()...");
            if (InstallDate.AddDays(FreeLicenseDays) < DateTime.Now)
            { 
                Availability = false;
                return Availability;
            }
            else 
            { 
                Availability = true;
                return Availability;
            }
        }
    }

    /// <summary>
    /// Класс для платного ПО
    /// </summary>
    [Serializable]
    public class CommercialSoft : Software
    {
        /// <summary>
        /// Дата установки ПО
        /// </summary>
        public DateTime InstallDate;

        /// <summary>
        /// Дней лицензии
        /// </summary>
        public uint LicenseDays;

        /// <summary>
        /// Цена
        /// </summary>
        public float Price;

        /// <summary>
        /// Конструктор класса CommercialSoft
        /// </summary>
        public CommercialSoft(string SoftName, string SoftCreator, float SoftPrice, DateTime SoftInstallDate, uint SoftDays)
        {
            Name = SoftName;
            Creator = SoftCreator;
            Price = SoftPrice;
            InstallDate = SoftInstallDate;
            LicenseDays = SoftDays;
        }
        /// <summary>
        /// Конструктор класса CommercialSoft без параметров
        /// </summary>
        public CommercialSoft()
        {

        }

        public override void GetInfo()
        {
            Trace.WriteLine("Вызван метод CommercialSoft.GetInfo()...");
            Console.WriteLine($"Название ПО: {Name}");
            Console.WriteLine($"Издатель: {Creator}");
            Console.WriteLine($"Цена: {Price}");
            Console.WriteLine($"Дата установки: {InstallDate}");
            Console.WriteLine($"Дней лицензии: {LicenseDays}");
        }
        public override bool GetAvailability()
        {
            Trace.WriteLine("Вызван метод Shareware.GetAvailability()...");
            if (InstallDate.AddDays(LicenseDays) < DateTime.Now)
            {
                Availability = false;
                return Availability;
            }
            else
            {
                Availability = true;
                return Availability;
            }
        }
    }
}
