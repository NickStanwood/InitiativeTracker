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
            using(XmlWriter xw = XmlWriter.Create(filePath, new XmlWriterSettings { Indent = true}))
            {
                serializer.Serialize(xw, model);
            }
        }

        public static EncounterModel? Deserialize(string filePath)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(EncounterModel));
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    return serializer.Deserialize(fs) as EncounterModel;
                }
            }
            catch
            {
                return null;
            }
            
        }
    }
}
