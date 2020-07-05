using CoffeeRank.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace CoffeeRank
{
    public class XMLParser
    {
        public static List<CoffeeType> GetCoffeeTypesList()
        {
            CoffeeTypesList rawData = null;

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            }
            Stream stream = assembly.GetManifestResourceStream("CoffeeRank.CoffeeTypes.xml");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(CoffeeTypesList));
                rawData = (CoffeeTypesList)serializer.Deserialize(reader);
            }
            return rawData.coffeeTypes;
        }
    }
}
