using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DescargaFTP
{
    class ReadParameters
    {
        public string readParameter(string parametro)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("../../Res/Strings.xml");
            XmlNodeList xnList = xml.SelectNodes(parametro);
            return xnList[0].InnerText;

        }




    }
}
