using System.Text;

namespace Braile_API.Model
{
	public class BrailleMap
	{			
		
		
		private static readonly Dictionary<char, string> BrailleMapping = new Dictionary<char, string>
		{
			{'a', "1"},
			{'b', "12"},
			{'c', "14"},
			{'d', "145"},
			{'e', "15"},
			{'f', "124"},
			{'g', "1245"},
			{'h', "125"},
			{'i', "24"},
			{'j', "245"},
			{'k', "13"},
			{'l', "123"},
			{'m', "134"},
			{'n', "1345"},
			{'o', "135"},
			{'p', "1234"},
			{'q', "12345"},
			{'r', "1235"},
			{'s', "234"},
			{'t', "2345"},
			{'u', "136"},
			{'v', "1236"},
			{'w', "2456"},
			{'x', "1346"},
			{'y', "13456"},
			{'z', "1356"}
		};

			public static string ConvertToBraille(string text)
			{
				var brailleBuilder = new StringBuilder();
				for (int i = 0; i < text.Length; i++)
				{
					if (BrailleMapping.TryGetValue(text[i], out var brailleCode))
					{
						brailleBuilder.Append(brailleCode);
					}
				}
				return brailleBuilder.ToString();
			}

			public static Dictionary<char, int> GetDotCount(string text)
			{
				var totalDotCount = 0;
				var dotCounts = new Dictionary<char, int>();
				foreach (char c in text.ToLower())
				{
					if (BrailleMapping.TryGetValue(c, out var brailleCode))
					{
						int count = brailleCode.Length;
						totalDotCount += count;
						if (dotCounts.ContainsKey(c))
						{
							dotCounts[c] += count;
						}
						else
						{
							dotCounts[c] = count;
						}
					}
				}
				return dotCounts;
		}
	}
		

}

