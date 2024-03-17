using Cysharp.Threading.Tasks;
using MainProje.Script.GoogleScript.Controler;
using MainProje.Script.GoogleScript.Slime;
using UnityEngine;

namespace MainProje.Script.GoogleScript.Player
{
  public class HeroCollider : Singleton<HeroCollider>
  {
    public                   LayerMask slimeLayerMask;
    [SerializeField] private Transform playerTranfsrom;
    private readonly         float     startGameforThisPosition = 5;
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

    private void OnDrawGizmos()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(playerTranfsrom.position + Vector3.down * 2, 1.5f); //C için

      Gizmos.color = Color.blue;
      Gizmos.DrawWireSphere(playerTranfsrom.position, 6); //X için
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
          slimeLayerMask);


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
          slimeLayerMask);

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