using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Threading;
namespace raneen_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread create = new Thread (CreateXMLfile);
            Thread.Join();
            Thread create = new Thread(ReadXMLfile);
        }
        static void CreateXMLfile()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlElement root = xmldoc.CreateElement("team");
            xmldoc.AppendChild(root);
            XmlElement element1 = xmldoc.CreateElement("leader");
            XmlText text1 = xmldoc.CreateTextNode("younes");
            root.AppendChild(element1);
            element1.AppendChild(text1);
            XmlElement root2 = xmldoc.CreateElement("group_membars");
            root.AppendChild(root2);
            XmlElement element3 = xmldoc.CreateElement("membar1");
            XmlText text3 = xmldoc.CreateTextNode("Raneen");
            root2.AppendChild(element3);
            element3.AppendChild(text3);
            XmlElement element4 = xmldoc.CreateElement("membar2");
            XmlText text4 = xmldoc.CreateTextNode("Mohammad");
            root2.AppendChild(element4);
            element4.AppendChild(text4);
            XmlElement element5 = xmldoc.CreateElement("membar3");
            XmlText text5 = xmldoc.CreateTextNode("Amal");
            root2.AppendChild(element5);
            element5.AppendChild(text5);
            XmlElement element6 = xmldoc.CreateElement("membar4");
            XmlText text6 = xmldoc.CreateTextNode("Hussain");
            root2.AppendChild(element6);
            element6.AppendChild(text6);
            xmldoc.Save(@"C:\Users\96655\OneDrive\Desktop\file.xml");
            Console.WriteLine("Successfully, generated team.xml.\n");
        }
        static void ReadXMLfile()
        {
            XmlDocument xmldoc = new XmlDocument();
            Console.WriteLine("team.xml contents:");
            xmldoc.Load(@"C:\Users\96655\OneDrive\Desktop\file.xml");
            string xmlString = xmldoc.OuterXml;
            Console.WriteLine(PrintXML(xmlString) + "\n");
        }


        static string PrintXML(string xml)
        {
            string result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                document.LoadXml(xml);

                writer.Formatting = Formatting.Indented;

                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                mStream.Position = 0;

                StreamReader sReader = new StreamReader(mStream);

                string formattedXml = sReader.ReadToEnd();

                result = formattedXml;
            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
            }

            mStream.Close();
            writer.Close();

            return result;
        }
    }
}