using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SkyScapeDeploy
{
   public class Deployment
    {

       public static string YmlToXml(string filename)
       {
           XmlAttributes atts = new XmlAttributes();
           atts.Xmlns = true;
           XNamespace ovf = "http://schemas.dmtf.org/ovf/envelope/1";
           string vm = "http://www.vmware.com/vcloud/v1.5";

           string fullfilename = Directory.GetCurrentDirectory() + @"\templates\" + filename;
           string json = File.ReadAllText(fullfilename);
           XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
           StringWriter sw = new StringWriter();
           XmlTextWriter xw = new XmlTextWriter(sw);
           xw.Formatting = System.Xml.Formatting.Indented;
           xw.WriteStartDocument();
           xw.WriteStartElement("vapp");
           xw.WriteAttributeString("xmlns", "ovf", null, vm);

           doc.WriteTo(xw);


           return sw.ToString();
       }

    }
}
