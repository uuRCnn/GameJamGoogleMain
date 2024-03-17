using MainProje.Script.GoogleScript.Controler;
using MainProje.Script.Helper;
using UnityEngine;

namespace MainProje.Script.GoogleScript.Player
{
  public class PlayerHealth : Singleton<PlayerHealth>
  {
    public                   float      health = 100;
    [SerializeField] private GameObject UIFade;

    private bool workonce;

    private void Start()
    {
      workonce = true;
    }

    private void Update()
    {
      // UIManager.Instance.healthBar.value = health / 100;
      UIManager.Instance._hpBarPlayer.UpdateHealthBar(health);

      if (health <= 100) health += Time.deltaTime * 5;

      if (health <= 0 && workonce)
      {
        UIFade.SetActive(true);
        FadeEffect.Instance.FadeIn();
        UIManager.Instance.LoseUI();

        workonce = false;
        // öldü
      }
    }


    public void PlayerTakeDamage(float dmg)
    {
      health -= dmg;

      AudioManager.Instance.RandomEfxTakdeDmg();
    }

    public void PlauyerHealtUpp()
    {
      health += 70;
    }
  }
}