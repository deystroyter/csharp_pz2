using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedorovAD___Pz_2
{
    abstract class Software
    {
        /// <summary>
        /// Название программного обеспечения
        /// </summary>
        protected string Name;
        /// <summary>
        /// Издатель программного обеспечения
        /// </summary>
        protected string Creator;
        /// <summary>
        /// Доступность программного обеспечения
        /// </summary>
        protected bool Availability;
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
    class FreeSoft : Software
    {
        /// <summary>
        /// Конструктор класса FreeSoft
        /// </summary>
        public FreeSoft(string SoftName,string SoftCreator)
        {
            Name = SoftName;
            Creator = SoftCreator;
            Availability = true;

        }
        public override void GetInfo()
        {
            Console.WriteLine($"Название ПО: {Name}");
            Console.WriteLine($"Издатель: {Creator}");
        }
        public override bool GetAvailability()
        {
            return Availability;
        }
    }
    /// <summary>
    /// Класс для условно-бесплатного ПО
    /// </summary>
    class Shareware : Software
    {
        /// <summary>
        /// Дата установки ПО
        /// </summary>
        DateTime InstallDate;
        /// <summary>
        /// Дней бесплатной лицензии
        /// </summary>
        uint FreeLicenseDays;
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
        public override void GetInfo()
        {
            Console.WriteLine($"Название ПО: {Name}");
            Console.WriteLine($"Издатель: {Creator}");
            Console.WriteLine($"Дата установки: {InstallDate}");
            Console.WriteLine($"Дней бесплатной лицензии: {FreeLicenseDays}");
        }
        public override bool GetAvailability()
        {
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
    class CommercialSoft : Software
    {
        /// <summary>
        /// Дата установки ПО
        /// </summary>
        DateTime InstallDate;
        /// <summary>
        /// Дней лицензии
        /// </summary>
        uint LicenseDays;
        /// <summary>
        /// Цена
        /// </summary>
        float Price;

        public CommercialSoft(string SoftName, string SoftCreator, float SoftPrice, DateTime SoftInstallDate, uint SoftDays)
        {
            Name = SoftName;
            Creator = SoftCreator;
            Price = SoftPrice;
            InstallDate = SoftInstallDate;
            LicenseDays = SoftDays;
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Название ПО: {Name}");
            Console.WriteLine($"Издатель: {Creator}");
            Console.WriteLine($"Цена: {Price}");
            Console.WriteLine($"Дата установки: {InstallDate}");
            Console.WriteLine($"Дней лицензии: {LicenseDays}");
        }
        public override bool GetAvailability()
        {
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
