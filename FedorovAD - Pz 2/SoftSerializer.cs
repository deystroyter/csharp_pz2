using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FedorovAD___Pz_2
{
    /// <summary>
    /// Класс, осуществляющий сериализацию
    /// </summary>
    public class SoftSerializer
    {
        /// <summary>
        /// Сериализатор FreeSoft
        /// </summary>
        private XmlSerializer FreeSoftSerializer;

        /// <summary>
        /// Сериализатор Shareware
        /// </summary>
        private XmlSerializer SharewareSerializer;

        /// <summary>
        /// Сериализатор треугольников
        /// </summary>
        private XmlSerializer CommercialSoftSerializer;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public SoftSerializer()
        {
            FreeSoftSerializer = new XmlSerializer(typeof(FreeSoft));
            SharewareSerializer = new XmlSerializer(typeof(Shareware));
            CommercialSoftSerializer = new XmlSerializer(typeof(CommercialSoft));
        }

        public void Serialize(Stream stream, Object o)
        {
            switch (o.GetType().Name)
            {
                case "FreeSoft":
                    FreeSoftSerializer.Serialize(stream, o);
                    break;
                case "Shareware":
                    SharewareSerializer.Serialize(stream, o);
                    break;
                case "CommercialSoft":
                    CommercialSoftSerializer.Serialize(stream, o);
                    break;
                default:
                    Console.WriteLine("Привет, я default!");
                    break;
            }
        }
    }
}
