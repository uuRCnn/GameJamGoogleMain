using UnityEngine;

namespace Script.Hero
{
  public class HeroMain : Singleton<HeroMain>
  {
    // ==> Components <==
    // =========================================================================

    // -> Player <-
    [SerializeField] public Transform      playerTransform;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public GameObject     parrentObject;
  }
}