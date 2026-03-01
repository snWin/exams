using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XmlChecker
{
	class Program
	{

		//Count is correct
	public static void Main()
		{
			string xmlContent = @"
			<RandomTag123 RandomAttribute1=""2.0"" RandomAttribute2=""2022-10-07T09:12:41Z"">
			  <RandomTag456 RandomAttribute3=""27012023-005"" RandomAttribute4=""100"" RandomAttribute5=""999"">
				<RandomTag789 RandomAttribute6=""Normal"" RandomAttribute7=""1"" />
				<RandomTag101112 RandomAttribute8="""" RandomAttribute9=""1101-01-001-A0001A01-R"" RandomAttribute10=""0"" RandomAttribute11=""1"" RandomAttribute12=""2022-11-11"" />
			  </RandomTag456>
			  <RandomTag456 RandomAttribute3=""27012023-006"" RandomAttribute4=""100"" RandomAttribute5=""999"">
				<RandomTag789 RandomAttribute6=""Normal"" RandomAttribute7=""1"" />
				<RandomTag101112 RandomAttribute8="""" RandomAttribute9=""1101-01-001-A0001A01-R"" RandomAttribute10=""0"" RandomAttribute11=""1"" RandomAttribute12=""2022-11-11"" />
			  </RandomTag456>
			</RandomTag123>";

			//<Messages>
			//    <Message>Content 1</Message>
			//    <Message>Content 2</Message>
			//    <Message>Content 3</Message>
			//</Messages>";

			
			try
			{
				// Returns the parsed XDocument
				XDocument doc = XDocument.Parse(xmlContent);

				// Count all child elements named 'Message'
				//int messageCount = doc.Descendants("Messages").Count();
				int messageCount = doc.Descendants("RandomTag456").Count();

				Console.WriteLine("Parsed successfully. It is valid xml.");
				Console.WriteLine($"Number of messages: {messageCount}");

			}
			catch (XmlException ex)
			{
				// Throws exception if parsing fails
				Console.WriteLine($"Invalid XML: {ex.Message}");
			}
			
		}
	}
}
