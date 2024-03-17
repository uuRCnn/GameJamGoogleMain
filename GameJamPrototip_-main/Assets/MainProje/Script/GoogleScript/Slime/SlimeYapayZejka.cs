using MainProje.Script.GoogleScript.Player;
using UnityEngine;

namespace MainProje.Script.GoogleScript.Slime
{
  public class SlimeYapayZejka : MonoBehaviour
  {
    public enum SlimeRütbe
    {
      AskerSlime,
      KingSlime,
      KingSlimeUzun
    }

    [SerializeField] private EnemyAi   slimeAi;
    [SerializeField] private Transform ownSlaimeTransform;

    [SerializeField] private GameObject player;


    [SerializeField] private LayerMask playerLayerMask;

    [SerializeField] public SlimeRütbe currentSlimEnum;

    private PlayerHealth _playerHealth;

    private float dmgTime;
    private bool  JustOneAttack;

    private float slimeScaleBoyut;

    private void Awake()
    {
      player = GameObject.FindWithTag("Player");
      _playerHealth = player.GetComponent<PlayerHealth>();
      slimeAi.waypoints[0] = player.transform;
    }


    private void Start() // todo bunu yukrı taşıdım dogru çalışyromu dene
    {
      // if (OwnGameManager.isGameStart)
      //   AttackPlayer();
      //
      //
      // if (currentSlimEnum == SlimeRütbe.KingSlime || currentSlimEnum == SlimeRütbe.KingSlimeUzun)
      //   KingSlimeScale();
      // else
      //   RandomScale();
      //
      //
      // AttackPlayer();
      //
      // slimeScaleBoyut = ownSlaimeTransform.localScale.x;
    }

    private void Update()
    {
      var Distance = Vector3.Distance( // *1.2f 'in nedeni: Biraz alaçakta oluyor onu yukarı çektim.
        ownSlaimeTransform.position + new Vector3(0, ownSlaimeTransform.position.y * 1.2f, 0),
        player.transform.position);

      if (Skils.Instance.isDmgSkillUsing) return; // skill kullanıyors dmg almaması için return atıyoruz.

      if (Distance < slimeScaleBoyut && dmgTime > 0.5f)
      {
        // DMG ALDII !!!
        _playerHealth.PlayerTakeDamage(0.5f * slimeScaleBoyut);
        dmgTime = 0;
      }
      else
      {
        dmgTime += Time.deltaTime;
      }
    }


    private void OnEnable()
    {
      slimeAi.OnAttack += SlimeAttack;

      if (OwnGameManager.isGameStart)
        AttackPlayer();


      if (currentSlimEnum == SlimeRütbe.KingSlime || currentSlimEnum == SlimeRütbe.KingSlimeUzun)
        KingSlimeScale();
      else
        RandomScale();


      AttackPlayer();

      slimeScaleBoyut = ownSlaimeTransform.localScale.x;
    }

    private void AttackPlayer()
    {
      slimeAi.currentState = SlimeAnimationState.Walk;
    }

    private void RandomScale()
    {
      var randomScale = Random.Range(1.5f, 4.5f);
      ownSlaimeTransform.localScale = new Vector3(randomScale, randomScale, randomScale);
    }

    private void KingSlimeScale()
    {
      var kingScale = 8f;

      ownSlaimeTransform.localScale = new Vector3(kingScale, kingScale, kingScale);
    }

    // private void OnDrawGizmos()
    // {
    //   Gizmos.color = Color.red;
    //   Gizmos.DrawWireSphere(
    //     ownSlaimeTransform.position + new Vector3(0, ownSlaimeTransform.position.y * 1.2f, 0),
    //     slimeScaleBoyut / 2.2f);
    // }

    private void SlimeAttack()
    {
      var Distance = Vector3.Distance( // *1.2f 'in nedeni: Biraz alaçakta oluyor onu yukarı çektim.
        ownSlaimeTransform.position + new Vector3(0, ownSlaimeTransform.position.y * 1.2f, 0),
        player.transform.position);


      if (Distance < slimeScaleBoyut) _playerHealth.PlayerTakeDamage(3 * slimeScaleBoyut);
      // DMG ALDII !!!
    }
  }
}