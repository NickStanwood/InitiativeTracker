using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace InitiativeTracker
{
    internal static class XmlSerializer
    {
        public static void Serialize(string filePath, EncounterModel model)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(EncounterModel));
            using(XmlWriter xw = XmlWriter.Create("C:/temp/test.xml", new XmlWriterSettings { Indent = true}))
            {
                serializer.Serialize(xw, model);
            }
        }

        public static EncounterModel? Deserialize(string filePath)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(EncounterModel));
            using (FileStream fs = new FileStream("C:/temp/test.xml", FileMode.Open, FileAccess.Read))
            {
                return serializer.Deserialize(fs) as EncounterModel;
            }
        }
    }
}
