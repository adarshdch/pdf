using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace ReferenceExtractor
{

	class Converter
	{
		public static string Convert()
		{
			const string strPath = @"C:\D\EBSCO\pdf\data\samples\10.1177_0003319714535238.pdf";
			using (var reader = new PdfReader(strPath))
			{
				var text = new StringBuilder();

				for (int i = 1; i <= reader.NumberOfPages; i++)
				{
					text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
				}
				
				File.WriteAllText(@"d:\test.txt", text.ToString());
				
				return text.ToString();
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write(Converter.Convert());
			Console.ReadKey();
		}


	}
}
