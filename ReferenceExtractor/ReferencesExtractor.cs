
using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenceExtractor
{
	class ReferencesExtractor
	{
		public static string GetAllReferencesText(string aContent)
		{
			var aIndex = aContent.LastIndexOf("\nReferences", StringComparison.InvariantCultureIgnoreCase);
			return aContent.Substring(aIndex);
		}

		public static IList<string> GetAllReferences(string aContent)
		{
			IList<string> aReferences = new List<string>();

			int aCurrentRefereneIndex = 1;

			while (string.IsNullOrWhiteSpace(aContent) == false)
			{
				var aReferenceStartIndex = aContent.IndexOf(string.Format("\n{0}.", aCurrentRefereneIndex),
					StringComparison.InvariantCultureIgnoreCase);
				var aReferenceEndIndex = aContent.IndexOf(string.Format("\n{0}.", aCurrentRefereneIndex + 1),
					StringComparison.InvariantCultureIgnoreCase);
				if (aReferenceStartIndex < 0 || aReferenceEndIndex < 0)
					break;
				var aReferenceText = aContent.Substring(aReferenceStartIndex, aReferenceEndIndex - aReferenceStartIndex);
				aContent = aContent.Substring(aReferenceEndIndex);
				aCurrentRefereneIndex ++;

				aReferences.Add(aReferenceText);
			}
			return aReferences;
		}

	}
}
