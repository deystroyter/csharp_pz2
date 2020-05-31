using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;


namespace FedorovAD___Pz_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var FilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            using (var FStream = new FileStream(Path.Combine(FilePath, "input.txt"), FileMode.Open))
            using (var SReader = new StreamReader(FStream))
            {
                var LogStream = new FileStream(Path.Combine(FilePath, "XMLSerialization.txt"), FileMode.Create);
                var SSerializer = new SoftSerializer();
                int n = int.Parse(SReader.ReadLine());
                Software[] SoftDataBase = new Software[n];

                for (int i = 0; i < n; i++)
                {
                    string recordingLine = SReader.ReadLine();
                    Software record = GetRecordType(recordingLine);
                    SoftDataBase[i] = record;
                    SSerializer.Serialize(LogStream, record);

                }
                FindFullSoft(SoftDataBase);
                FindAvailableSoft(SoftDataBase);
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Вывод всех программ из массива софта
        /// </summary>
        /// <param name="Db">Массив записей</param>
        public static void FindFullSoft(Software[] Db)
        {
            Console.WriteLine("<<<< Полный список софта >>>>");
            Console.WriteLine("-------------------");
            foreach (Software elem in Db)
            {
                    elem.GetInfo();
                    Console.WriteLine("-------------------");
            }
        }
        /// <summary>
        /// Вывод доступных программ из массива софта
        /// </summary>
        /// <param name="Db">Массив записей</param>
        public static void FindAvailableSoft(Software[] Db)
        {
            Console.WriteLine("<<<< Список доступного софта >>>>");
            Console.WriteLine("-------------------");
            foreach (Software elem in Db)
            {
                if (elem.GetAvailability())
                {
                    elem.GetInfo();
                    Console.WriteLine("-------------------");
                }
            }
        }

        /// <summary>
        /// Узнает тип программного обеспечения и создаёт новый элемент этого класса
        /// </summary>
        /// <param name="recordingLine">Строка из файла input.txt</param>
        public static Software GetRecordType(string recordingLine)
        {
            var vals = recordingLine.Split('|');
            switch (vals[0])
            {
                case "FreeSoft":
                    return new FreeSoft(vals[1], vals[2]);
                case "Shareware":
                    return new Shareware(vals[1], vals[2], DateTime.Parse(vals[3]), uint.Parse(vals[4]));
                case "CommercialSoft":
                    return new CommercialSoft(vals[1], vals[2], float.Parse(vals[3]), DateTime.Parse(vals[4]), uint.Parse(vals[5]));
                default:
                    throw new Exception("привет! я ошибочка");
            }
        }
    }
}
