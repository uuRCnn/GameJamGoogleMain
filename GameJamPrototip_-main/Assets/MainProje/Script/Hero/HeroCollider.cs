using System;
using Script.Manager;
using Script.Manager.Inputt;
using Script.OtherHero;
using UnityEngine;

namespace Script.Hero
{
  public class HeroCollider : Singleton<HeroCollider>
  {
    [SerializeField] private GameObject eButton;
    [SerializeField] public  OtherHeros otherHerosScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
        Debug.Log("Player gözüktü");
        otherHerosScript = other.GetComponent<OtherHeros>();
        eButton.SetActive(true);
      }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
        otherHerosScript.DeActiveUI();
        otherHerosScript = null;
        eButton.SetActive(false);
      }

    }
  }
}