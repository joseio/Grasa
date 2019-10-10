using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using MetaProject;

namespace Pex4Fun
{
    public class Serializer
    {
        public static void SerializeTests(List<Test> tests, string filePath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Test>), new Type[] {typeof(Int32[])});
            //BY JONATHAN: 12/12/18
            //XmlSerializer ser = new XmlSerializer(typeof(List<Test>), new Type[] { typeof(MetaProgram.List) });
            XmlTextWriter writer = new XmlTextWriter(filePath, Encoding.Unicode);
            ser.Serialize(writer, tests);
            writer.Close();
        }

        public static List<Test> DeserializeTests(string filePath)
        {
            XmlTextReader reader = new XmlTextReader(filePath);
            XmlSerializer ser = new XmlSerializer(typeof(List<Test>), new Type[] {typeof(Int32[])});
            //BY JONATHAN: 12/12/18
            //XmlSerializer ser = new XmlSerializer(typeof(List<Test>), new Type[] { typeof(MetaProgram.List) });
            List<Test> tests = (List<Test>)ser.Deserialize(reader);
            reader.Close();
            return tests;
        }
    }
}
