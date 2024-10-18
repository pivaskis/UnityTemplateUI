using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinkSplitter : MonoBehaviour
{
	public string link;
	public List<string> splittedString;

	[ContextMenu("SplitString")]
	public void SplitString()
	{
		var charArray = link.ToCharArray();

		splittedString = new List<string>();

		foreach (char sumbol in charArray)
		{
			splittedString.Add(sumbol.ToString());
		}
		
	}
}