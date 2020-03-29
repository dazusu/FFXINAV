using System.Xml.Serialization;

namespace PathFinder.Common
{
    namespace Servus_v2.Common
    {
        public class PointsOfInterest
        {
            [XmlAttribute("id")]
            public int ID { get; set; }

            [XmlAttribute("name")]
            public string Name { get; set; }

            [XmlAttribute("x")]
            public float X { get; set; }

            [XmlAttribute("y")]
            public float Y { get; set; }

            [XmlAttribute("z")]
            public float Z { get; set; }
        }
    }
}