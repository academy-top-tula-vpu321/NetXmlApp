using NetXmlApp;
using System.Xml;
using System.Xml.Serialization;

Employee billy = new Employee()
{
    Name = "Billy",
    BirthDate = new(1997, 8, 20),
    Company = new()
    {
        Title = "Mail Group",
        Address = new()
        {
            City = "Moscow",
            Street = "Neglinskaya"
        }
    }
};

string xmlFileName = "employees.xml";

XmlDocument xmlDocument = new XmlDocument();
xmlDocument.Load(xmlFileName);

XmlElement? root = xmlDocument.DocumentElement;

if(root is not null)
{

    //foreach(XmlElement e in root)
    //{
    //    Console.WriteLine(e.Name);
    //    foreach(XmlNode attr in e.Attributes)
    //        Console.WriteLine($"\t{attr.Name} => {attr.Value}");
    //    foreach (XmlNode n in e.ChildNodes)
    //    {
    //        Console.WriteLine($"\t{n.Name}");
    //        foreach(XmlNode n2 in n.ChildNodes)
    //            Console.WriteLine($"\t\t{n2.Name}");
    //    }
    //}

    //ElementsPrint(root);


    // Add Elements
    //XmlElement xmlElement = xmlDocument.CreateElement(nameof(Employee));

    //XmlAttribute xmlAttributePosition = xmlDocument.CreateAttribute("position");
    //XmlText xmlTextAttributePosition = xmlDocument.CreateTextNode("developer");
    //xmlAttributePosition.AppendChild(xmlTextAttributePosition);
    //xmlElement.Attributes.Append(xmlAttributePosition);

    //XmlElement childElement = xmlDocument.CreateElement(nameof(Employee.Name));

    //childElement.InnerText = billy.Name;
    //xmlElement.AppendChild(childElement);

    //childElement = xmlDocument.CreateElement(nameof(Employee.BirthDate));
    //childElement.InnerText = billy.BirthDate.ToString();
    //xmlElement.AppendChild(childElement);

    //childElement = xmlDocument.CreateElement(nameof(Employee.Company));
    //childElement.AppendChild(xmlDocument.CreateElement("Title"));
    //xmlElement.AppendChild(childElement);

    //root.AppendChild(xmlElement);
    //xmlDocument.Save(xmlFileName);

    var nodeDel = root.LastChild;
    if(nodeDel is not null)
        root.RemoveChild(nodeDel);

    xmlDocument.Save(xmlFileName);
}

void ElementsPrint(XmlElement element, int level = 0)
{
    string tabs = new String('\t', level);

    Console.WriteLine();

    Console.WriteLine($"{tabs}Element: {element.Name}");
    Console.WriteLine($"{tabs}Value: {element.InnerText}");
    //Console.WriteLine($"{tabs}Xml Value: {element.InnerXml}");

    Console.WriteLine($"{tabs}Attributes:");
    foreach (XmlAttribute attribute in element.Attributes)
        Console.WriteLine($"{tabs}{attribute.Name}={attribute.Value}");

    foreach (XmlNode node in element)
    {
        if (node.NodeType == XmlNodeType.Element)
            ElementsPrint((node as XmlElement)!, level + 1);
    }

}