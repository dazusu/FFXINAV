using System.Xml.Serialization;

namespace PathFinder.Common
{
    namespace Servus_v2.Common
    {
        public class HitPoint
        {
            [XmlAttribute("lowerLVLRange")]
            public int LowerLVLRange { get; set; }

            [XmlAttribute("upperLVLRange")]
            public int UpperLVLRange { get; set; }

            [XmlAttribute("x")]
            public float X { get; set; }

            [XmlAttribute("y")]
            public float Y { get; set; }

            [XmlAttribute("z")]
            public float Z { get; set; }
        }
    }
}