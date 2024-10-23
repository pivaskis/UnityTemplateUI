using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
	private const string MusicVolume = "MusicVolume";
	private const string SoundVolume = "SoundVolume";

	public AudioMixer audioMixer;
	public Toggle soundToggle;
	public Toggle musicToggle;

	public void OnSoundValueChanged() => 
		SetGroupEnabled(soundToggle.isOn, SoundVolume);

	public void OnMusicValueChanged() => 
		SetGroupEnabled(musicToggle.isOn, MusicVolume);

	private void SetGroupEnabled(bool enabled, string groupName)
	{
		if (enabled)
			audioMixer.SetFloat(groupName, 0);
		else
			audioMixer.SetFloat(groupName, -80);
	}
}