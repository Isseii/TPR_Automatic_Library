using System;
using System.IO;
using Zad2Serializer.ObjectModel;
using Zad2Serializer.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Zad2ConsoleApp
{
    class Program
    {
        static ABC changeType(A a, B b, C c)
        {

          

            Console.WriteLine("Choose type A / B / C" + "\n");
            char x = Convert.ToChar(Console.ReadLine());
            switch (x)
            {
                case 'A':
                    {
                        return a;
                    }
                case 'B':
                    {
                        return b;
                    }
                case 'C':
                    {
                        return c;
                    }
                case 'a':
                    {
                        return a;
                    }
                case 'b':
                    {
                        return b;
                    }
                case 'c':
                    {
                        return c;
                    }
                default:
                    {
                        return a;
                    }
            }

        }


        static void Main(string[] args)
        {

            int y = 10;



            A a;
            B b;
            C c;

            a = new A("Dominik", "Karski", 3333, new DateTime(2019, 12, 1), null);
            b = new B("Sebastian", "Kujawski", 9669, new DateTime(2019, 10, 1), null);
            c = new C("Winston", "Churchill", 5321, new DateTime(2020, 1, 2), null);

            a.ObjB = b;
            b.ObjC = c;
            c.ObjA = a;
            int x = -1;
            ABC holder = a;


            while (x != 0)
            {
                Console.Clear();
                Console.WriteLine("JSON serialization (1)");
                Console.WriteLine("JSON deserialization (2)");
                Console.WriteLine("Custom serialization (3)");
                Console.WriteLine("Custom deserialization (4)");
                Console.WriteLine("Change type from " + holder.GetType().Name +" (5)");
                Console.WriteLine("XML serialization (6)");
                Console.WriteLine("XML deserialization (7)");
                Console.WriteLine("XML to XHTML transformation (8)");
                Console.WriteLine("Quit (0)");
                x = Convert.ToInt32(Console.ReadLine());
                switch(x){
                    case 1:
                        {
                            JSONSerialization<ABC> serialize = new JSONSerialization<ABC>("AConsoleResultJSON.json", holder);
                            serialize.Serialize();
                            Console.WriteLine("Object " + holder.GetType().Name + " serialized to JSON format" + "\n");
                            break;
                        }                
                    case 2:
                        {

                            JSchemaGenerator generator = new JSchemaGenerator();
                        
                            JSchema schema = generator.Generate(typeof(A));

                            string fileName = "AConsoleJsonDesTmp.json";
                            JSONSerialization<ABC> serialize = new JSONSerialization<ABC>(fileName, holder);
                            serialize.Serialize();
                            JSONSerialization<ABC> tmp = new JSONSerialization<ABC>(fileName, holder);
                            string jsonText = File.ReadAllText(fileName);
                            JObject schemaTest = JObject.Parse(jsonText);

                            IList<string> errorMessages;
                            bool valid = schemaTest.IsValid(schema, out errorMessages); 
                            if (valid)
                            {
                                ABC desResult = tmp.Deserialize();
                                Console.WriteLine("Object " + holder.GetType().Name + " deserialized from JSON format" + "\n");
                                Console.WriteLine(desResult.ToString());
                                break;
                            }

                            Console.WriteLine(errorMessages);
                            Console.WriteLine("Validation Error");
                            break;
                        }
                    case 3:
                        {
                            CustomSerialization<ABC> serialize = new CustomSerialization<ABC>("AConsoleSerializationResultCustom.txt", holder);
                            serialize.Serialize();
                            Console.WriteLine("Object " + holder.GetType().Name + "serialized to custom format" + "\n");
                            break;
                        }
                    case 4:
                        {
                            string fileName = "AConsoleCustomDesTmp.txt";
                            CustomSerialization<ABC> serialize = new CustomSerialization<ABC>(fileName, holder);
                            serialize.Serialize();
                            CustomSerialization<ABC> tmp = new CustomSerialization<ABC>(fileName, holder);
                            ABC desResult = tmp.Deserialize();
                            Console.WriteLine("Object " + holder.GetType().Name +" deserialized from Custom format" + "\n");
                            Console.WriteLine(desResult.ToString());

                            break;
                        }
                    case 5:
                        {
                            holder = changeType(a, b, c);
                            Console.WriteLine("Object type changed to " + holder.GetType().Name);
                            break;
                        }
                    case 6:
                        {
                            XMLSerialization<ABC> serialize = new XMLSerialization<ABC>("AConsoleResultXML.xml", holder);
                            serialize.Serialize();
                            Console.WriteLine("Object " + holder.GetType().Name + " serialized to XML format" + "\n");
                            break;
                        }
                    case 7:
                        {
                            string fileName = "AConsoleResultXML.xml";
                            XMLSerialization<ABC> serialize = new XMLSerialization<ABC>(fileName, holder);
                            serialize.Serialize();
                            XMLSerialization<ABC> tmp = new XMLSerialization<ABC>(fileName, holder);
                            ABC desResult = tmp.Deserialize();
                            Console.WriteLine("Object " + holder.GetType().Name + " deserialized from XML format" + "\n");
                            Console.WriteLine(desResult.ToString());
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Level of recursion: ");
                            y = Convert.ToInt32(Console.ReadLine());
                            string fileName = "AConsoleResultXML.xml";
                            if (!File.Exists(fileName))
                            {
                                Console.WriteLine("Nie odnaleziono pliku xml.");
                                break;
                            }

                            XPathDocument myXPathDoc = new XPathDocument(fileName);

                          
                            string xsltCode = "<?xml version='1.0' encoding='UTF-8'?><xsl:stylesheet version ='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform' xmlns:json='http://james.newtonking.com/projects/json'><xsl:output method = 'xml' doctype-system='http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd' doctype-public='-//W3C//DTD XHTML 1.0 Transitional//EN' indent='yes' omit-xml-declaration='yes'/><xsl:template name = 'writeobj' ><xsl:param name = 'obj' select='root'/>	<xsl:param name = 'count' select='1'/><xsl:choose><xsl:when test = '$obj/@json:ref' ><xsl:call-template name = 'writeobj' > <xsl:with-param name = 'obj' select='root'/><xsl:with-param name = 'count' select='$count'/></xsl:call-template></xsl:when><xsl:otherwise><xsl:if test='$count > 0'><tr xmlns = 'http://www.w3.org/1999/xhtml' xml:lang='pl' lang='pl' >Type: <xsl:value-of select = '$obj/@json:type' />Name: <xsl:value-of select = '$obj/Name' />LastName: <xsl:value-of select = '$obj/LastName' />Number: <xsl:value-of select = '$obj/Number' />Date: <xsl:value-of select = '$obj/Date'/><xsl:if test='$count > 1'>ObjRef: </xsl:if></tr> <xsl:if test='$obj/ObjA'><xsl:call-template name = 'writeobj' ><xsl:with-param name = 'obj' select='$obj/ObjA'/><xsl:with-param name = 'count' select='$count - 1'/></xsl:call-template></xsl:if><xsl:if test='$obj/ObjB'><xsl:call-template name = 'writeobj' ><xsl:with-param name = 'obj' select='$obj/ObjB'/><xsl:with-param name = 'count' select='$count - 1'/></xsl:call-template></xsl:if><xsl:if test='$obj/ObjC'><xsl:call-template name = 'writeobj' ><xsl:with-param name = 'obj' select='$obj/ObjC'/><xsl:with-param name ='count' select='$count - 1'/></xsl:call-template> </xsl:if></xsl:if></xsl:otherwise></xsl:choose></xsl:template> <xsl:template match = '/' ><html xmlns='http://www.w3.org/1999/xhtml' xml:lang='pl' lang='pl'><head> <title>Wynik serializacji</title> <style type = 'text/css' >mh2{,font - family: Helvetica;,margin - left: 2 %;,}   </style> </head>  <body style = 'background-color:#2c2f33; color:#7289da' ><table style='background-color:#222222'  xmlns='http://www.w3.org/1999/xhtml' xml:lang='pl' lang='pl' ><xsl:call-template name = 'writeobj' ><xsl:with-param name = 'obj' select='root'/><xsl:with-param name = 'count' select='"+y+"'/></xsl:call-template></table> </body> </html></xsl:template>	</xsl:stylesheet>";

                            XslCompiledTransform objXslTrans = new XslCompiledTransform();
                            objXslTrans.Load(new XmlTextReader(new StringReader(xsltCode)));

                            string xsltFilePath = "toxhtml.xslt";
                            if (!File.Exists(xsltFilePath))
                            {
                                Console.WriteLine("Nie odnaleziono pliku xslt.");
                                break;
                            }

                            XmlTextWriter myWriter = new XmlTextWriter("result.xhtml", null);
                            objXslTrans.Transform(myXPathDoc, null, myWriter);
              

                            Console.WriteLine("Stworzono plik result.xhtml");
                            break;
                        }
                }
                Console.WriteLine("\n" + "Press Key to Continue");
                Console.ReadKey();

            }
            
    }
    }

}