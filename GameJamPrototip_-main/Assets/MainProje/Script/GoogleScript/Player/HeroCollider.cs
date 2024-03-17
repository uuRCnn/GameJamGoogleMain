using System;
using Cysharp.Threading.Tasks;
using Script;
using Script.GoogleScript;
using Script.GoogleScript.Slime;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace MainProje.Script.Hero
{
  public class HeroCollider : Singleton<HeroCollider>
  {
    public LayerMask                   slimeLayerMask;
    float                              startGameforThisPosition = 5;
    [SerializeField] private Transform playerTranfsrom;
    // private void OnTriggerEnter(Collider other) 
    // {
    //   if (other.CompareTag("StartGameCollider"))
    //   {
    //     Debug.Log("çalıştı");
    //
    //     ownGameManager.isGameStart = true;
    //     ownGameManager.GameStart?.Invoke();
    //   }
    // }

    private void Update()
    {
      StartGame();
    }

    public async void AltSilindirSkillC(float dmg)
    {
      var time = 0f;
      while (time <= 1.5f)
      {
        await UniTask.WaitForSeconds(0.5f);

        var List = Physics.CapsuleCastAll(
          playerTranfsrom.position,
          playerTranfsrom.position + Vector3.down * 2,
          3f,
          Vector3.down,
          40,
          layerMask: slimeLayerMask);


        foreach (var li in List)
        {
          var slimeHealth = li.collider.GetComponent<SlimeHealth>();
          slimeHealth?.TakeDamage(dmg);
        }

        UIManager.Instance.SpawnCEffeckt();

        // todo: ses ekle
        time += 0.5f;
      }
    }

    private void OnDrawGizmos()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(playerTranfsrom.position + Vector3.down * 2, 1.5f); //C için

      Gizmos.color = Color.blue;
      Gizmos.DrawWireSphere(playerTranfsrom.position, 6); //X için
    }

    public async void BüyükYuvarlakSkillX(float dmg)
    {
      float time = 0;
      while (time <= 3.5f)
      {
        await UniTask.WaitForSeconds(0.5f);

        var list = Physics.SphereCastAll( // x için
          playerTranfsrom.position,
          6,
          Vector3.down,
          40,
          layerMask: slimeLayerMask);

        foreach (var li in list)
        {
          var slimeHealth = li.collider.GetComponent<SlimeHealth>();
          Debug.Log(slimeHealth);
          Debug.Log(li.collider.name);
          slimeHealth?.TakeDamage(dmg);
        }

        time += 0.5f;
      }
    }

    private void StartGame()
    {
      if (playerTranfsrom.transform.position.y < startGameforThisPosition && !OwnGameManager.isGameStart)
      {
        OwnGameManager.isGameStart = true;
        OwnGameManager.GameStart?.Invoke();
      }
    }
  }
}