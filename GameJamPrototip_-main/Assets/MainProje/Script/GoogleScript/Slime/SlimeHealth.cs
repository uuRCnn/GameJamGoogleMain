using Cysharp.Threading.Tasks;
using MainProje.Script.GoogleScript.Controler;
using UnityEngine;

namespace MainProje.Script.GoogleScript.Slime
{
  public class SlimeHealth : MonoBehaviour
  {
    public float health = 50; // bazılarına  Unity den ver degerlrei


    [SerializeField] private SlimeDeadEFfect SlimeDeadEFfect;
    private                  EnemyAi         EnemyAi;
    private                  Transform       slimeObject;

    private SlimeYapayZejka slimeYapayZejka;

    private void Awake()
    {
      EnemyAi = GetComponent<EnemyAi>();
      slimeObject = GetComponent<Transform>();
      slimeYapayZejka = GetComponentInChildren<SlimeYapayZejka>();
    }

    private void Update()
    {
      if (health <= 0 && slimeYapayZejka.currentSlimEnum == SlimeYapayZejka.SlimeRütbe.AskerSlime && !SlimeDeadEFfect.isDeadslime)
      {
        SlimeDeadEFfect.SlimeDeadEffect();
        // öldü
        RESpawn();
      }


      if (slimeYapayZejka.currentSlimEnum == SlimeYapayZejka.SlimeRütbe.KingSlime && !SlimeDeadEFfect.isDeadslime)
      {
        UIManager.Instance._hpBarKingKısa.UpdateHealthBar(health);

        if (health <= 0)
        {
          SlimeDeadEFfect.KingSlimeDeadEffect();

          OwnGameManager.Instance.isSmileKingDie = true;
        }
      }

      else if (slimeYapayZejka.currentSlimEnum == SlimeYapayZejka.SlimeRütbe.KingSlimeUzun && !SlimeDeadEFfect.isDeadslime)
      {
        UIManager.Instance._hpBarKingUzun.UpdateHealthBar(health);

        if (health <= 0)
        {
          SlimeDeadEFfect.KingSlimeDeadEffect();

          OwnGameManager.Instance.isUuzunKingDie = true;
        }
      }
    }

    public void TakeDamage(float dmg)
    {
      EnemyAi.currentState = SlimeAnimationState.Damage;
      health -= dmg;

      AudioManager.Instance.RandomEfxDamage();

      Instantiate(UIManager.Instance.SlimeDmgEffect, transform.position, Quaternion.identity);
    }

    private async void RESpawn() //todo: bu kodu test et
    {
      await UniTask.WaitForSeconds(8);

      if (OwnGameManager.Instance.isAllBossDie) return;

      slimeObject.gameObject.SetActive(true);
      health = 50;
    }
  }
}