using System;
using UnityEngine;

public class CircleSound : MonoBehaviour
{
   public AudioSource audioSource;

   private void Awake() => 
      audioSource = transform.GetComponent<AudioSource>();

   private void OnCollisionEnter2D(Collision2D other) => 
      audioSource.Play();
}
