using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
   public Animation Animation;
   public AudioSource AudioSource;

   public void OnButtonPressed()
   {
      Animation.Play();
      AudioSource.Play();
   }
}
