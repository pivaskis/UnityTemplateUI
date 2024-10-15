using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
	public AudioListener audioListener;
	public Toggle togle;

	public void OnSoundValueChanged()
	{
		audioListener.enabled = togle.isOn;
	}
}