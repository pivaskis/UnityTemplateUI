using Service.Window.Runtime.Data;
using UnityEngine;

namespace Service.Window.Runtime.Api
{
	public class Window : MonoBehaviour
	{
		[SerializeField] private WindowType _type;

		public WindowType Type => _type;
	}
}