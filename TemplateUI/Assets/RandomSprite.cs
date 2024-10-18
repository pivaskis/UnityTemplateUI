using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSprite : MonoBehaviour
{
   public SpriteRenderer SpriteRenderer;
   public List<Sprite> sprites;

   private void OnEnable() => 
      SpriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
}
