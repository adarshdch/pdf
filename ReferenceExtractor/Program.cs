using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace ReferenceExtractor
{

	class Converter
	{
		const string strPath = @"C:\D\EBSCO\pdf\data\samples\10.1177_0003319714535238.pdf";
		
		public static string ConvertBasic()
		{
			using (var reader = new PdfReader(strPath))
			{
				var text = new StringBuilder();

				for (int i = reader.NumberOfPages-5; i <= reader.NumberOfPages; i++)
				{
					text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
				}
				
				File.WriteAllText(@"d:\test.txt", text.ToString());
				
				return text.ToString();
			}
		}

		public static string ConvertAdvanced()
		{
			ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();

			using (PdfReader reader = new PdfReader(strPath))
			{
				StringBuilder text = new StringBuilder();

				for (int i = 1; i <= reader.NumberOfPages; i++)
				{
					string thePage = PdfTextExtractor.GetTextFromPage(reader, i, its);
					string[] theLines = thePage.Split('\n');
					foreach (var theLine in theLines)
					{
						text.AppendLine(theLine);
					}
				}
				return text.ToString();
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			//var aContent = Converter.ConvertBasic();
			var aContent = File.ReadAllText(@"D:\test.txt");

			var aReferenceText = ReferencesExtractor.GetAllReferencesText(aContent);
			var aReferencesText = ReferenceExtractor.ReferencesExtractor.GetAllReferences(aReferenceText).ToList();

			aReferencesText.ForEach(Console.WriteLine);
			

			Console.ReadKey();
		}


	}
}
