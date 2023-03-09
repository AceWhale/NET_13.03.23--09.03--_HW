using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace _09._03._23_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument x = XDocument.Load("File.xml");
            XElement e = x.Root;
            #region Add
            e.Add(new XElement("phone",
                new XAttribute("name", "A72"),
                new XElement("creator", "Samsung"),
                new XElement("price", "12000"),
                new XElement("date", "2020")));
            x.Save("File.xml");
            #endregion

            #region Search
            var search = x.Element("phone")?
                .Elements("phone")?
                .FirstOrDefault(p => p.Attribute("name")?.Value == "A72");
            var name_s = search?.Attribute("name")?.Value;
            var company_s = search?.Element("creator")?.Value;
            var price_s = search?.Element("price")?.Value;
            var date_s = search?.Element("date")?.Value;
            Console.WriteLine($"Name: {name_s}  Age: {company_s}  Price: {price_s}  Date: {date_s}");
            #endregion

            #region Edit
            var tom = x.Element("phone")?
                .Elements("phone")
                .FirstOrDefault(p => p.Attribute("name")?.Value == "A72");

            if (tom != null)
            {
                var name_e = tom.Attribute("name");
                if (name_e != null) name_e.Value = "iPhone 13";
                var company_e = tom.Element("creator");
                if (company_e != null) company_e.Value = "Apple";
                var price_e = tom.Element("price");
                if (company_e != null) company_e.Value = "40000";
                var date_e = tom.Element("date");
                if (company_e != null) company_e.Value = "2021";
                x.Save("File.xml");
            }
            #endregion

            #region Show
            var name_sh = search?.Attribute("name")?.Value;
            var company_sh = search?.Element("creator")?.Value;
            var price_sh = search?.Element("price")?.Value;
            var date_sh = search?.Element("date")?.Value;
            Console.WriteLine($"Name: {name_sh}  Age: {company_sh}  Price: {price_sh}  Date: {date_sh}");
            #endregion

            #region Delete
            if (e != null)
            {
                var bob = e.Elements("phone")
                    .FirstOrDefault(p => p.Attribute("name")?.Value == "A72");
                if (bob != null)
                {
                    bob.Remove();
                    x.Save("File.xml");
                }
            }
            #endregion
        }
    }
}
