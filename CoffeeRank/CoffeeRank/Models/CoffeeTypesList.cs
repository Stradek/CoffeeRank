using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CoffeeRank.Models
{
	[XmlRoot(ElementName = "CoffeeType")]
	public class CoffeeType
	{
		[XmlAttribute(AttributeName = "name")]
		public string name { get; set; }
		[XmlAttribute(AttributeName = "country")]
		public string country { get; set; }
		[XmlAttribute(AttributeName = "score")]
		public string score { get; set; }
		[XmlAttribute(AttributeName = "price")]
		public string price { get; set; }
		[XmlAttribute(AttributeName = "website")]
		public string website { get; set; }
		[XmlAttribute(AttributeName = "producer")]
		public string producer { get; set; }
		[XmlAttribute(AttributeName = "aroma")]
		public string aroma { get; set; }
		[XmlAttribute(AttributeName = "acidity")]
		public string acidity { get; set; }
		[XmlAttribute(AttributeName = "body")]
		public string body { get; set; }
		[XmlAttribute(AttributeName = "flavor")]
		public string flavor { get; set; }
		[XmlAttribute(AttributeName = "aftertaste")]
		public string aftertaste { get; set; }
	}

	[XmlRoot(ElementName = "CoffeeTypesList")]
	public class CoffeeTypesList
	{
		[XmlElement(ElementName = "CoffeeType")]
		public List<CoffeeType> coffeeTypes { get; set; }
	}
}
