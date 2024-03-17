using Cysharp.Threading.Tasks;
using DG.Tweening;
using MainProje.Script.GoogleScript.Controler;
using MainProje.Script.GoogleScript.Player;
using MainProje.Script.GoogleScript.Slime;
using MimicSpace;
using UnityEngine;

namespace MainProje.Script.GoogleScript
{
  public class Skils : Singleton<Skils>
  {
    [SerializeField] private Mimic    mimicScript;
    [SerializeField] private Movement movementScript;

    [SerializeField] private Transform playerTransfRom;

    [SerializeField] private Light directionLight;

    [SerializeField] private GameObject[] spawnObjectsGroupList;

    public float spaceAmount;

    public bool isDmgSkillUsing;

    public          bool  isPRessZZZ;
    public readonly float sabitHeight = 0.5f;
    public readonly float sabitLight  = 0.3f;
    public readonly float sabitScale  = 1f;

    public readonly float sabitSpeed = 8f;

    private void Update()
    {
      UIManager.Instance.spaceSlider.value = spaceAmount;
    }

    public void SetSpeed(float speed)
    {
      DOTween.To(() =>
        movementScript.speed, x =>
        movementScript.speed = x, speed, 0.5f);
    }

    public void SetScale(float scale)
    {
      DOTween.To(() =>
        playerTransfRom.localScale, x =>
        playerTransfRom.localScale = x, new Vector3(scale, scale, scale), 1f);
    }

    private void SetHeight(float height)
    {
      DOTween.To(() =>
        movementScript.height, x =>
        movementScript.height = x, height, 0.5f);
    }


    public void SpaceSkil()
    {
      spaceAmount -= Time.deltaTime / 5;

      SetSpeed(20);

      isDmgSkillUsing = true;
    }

    public async void ZSkil() // yıldırım çarpptırma, bazılarına dmg vurur. (Bu tamam)
    {
      isPRessZZZ = true;
      isDmgSkillUsing = true;
      AudioManager.Instance.SkiZZZZZ();
      PlayerHealth.Instance.PlauyerHealtUpp();

      AllTakeDamageAnim();
      directionLight.intensity = 1;
      await UniTask.WaitForSeconds(0.1f);

      directionLight.intensity = 0.3f;
      await UniTask.WaitForSeconds(0.1f);
      // AudioManager.Instance.SkiZZZZZ();

      AllTakeDamageAnim();
      directionLight.intensity = 1;
      await UniTask.WaitForSeconds(0.1f);

      directionLight.intensity = 0.3f;
      await UniTask.WaitForSeconds(0.1f);
      // AudioManager.Instance.SkiZZZZZ();

      AllTakeDamageAnim();
      directionLight.intensity = 1;
      await UniTask.WaitForSeconds(0.1f);

      directionLight.intensity = 0.3f;
      await UniTask.WaitForSeconds(0.1f);

      directionLight.intensity = 0.3f;
      await UniTask.WaitForSeconds(0.1f);
      AllTakeDamageAnim();
      // AudioManager.Instance.SkiZZZZZ();

      directionLight.intensity = 1;
      await UniTask.WaitForSeconds(0.1f);

      directionLight.intensity = sabitLight;
      await UniTask.WaitForSeconds(0.1f);

      AllTakeDamageAnim();
      // AudioManager.Instance.SkiZZZZZ();

      isPRessZZZ = false;

      isDmgSkillUsing = false;
    }

    public async void XSkil() // büyüme, tood: Dmg vurması lazım 
    {
      isDmgSkillUsing = true;

      SetScale(20);

      SkillActive.Instance.isXSkillActive = true;
      AudioManager.Instance.SkillXXXXX();
      var defaultLegDistance = mimicScript.minLegDistance;

      mimicScript.minLegDistance = 100;

      await UniTask.WaitForSeconds(3);

      mimicScript.minLegDistance = defaultLegDistance;

      SkillActive.Instance.isXSkillActive = false;

      SetScale(sabitScale);

      isDmgSkillUsing = false;
    }

    public async void CSkil() // boyunu uzatma ve 
    {
      isDmgSkillUsing = true;

      SetHeight(5);

      AudioManager.Instance.SkillCCCCCC();
      SkillActive.Instance.isCSkillActive = true;

      await UniTask.WaitForSeconds(5);

      SetHeight(sabitHeight);

      SkillActive.Instance.isCSkillActive = false;

      isDmgSkillUsing = false;


      // tam altına dogru effetk oluştur vurma effetki. ve dmg vursun
    }

    // * * * * * * * * *  * ** ** 

    private void AllTakeDamageAnim() //dmg vurmaz sadece animasyonunu çalıştırır
    {
      // var randomCount = Random.Range(1, spawnObjectsGroupList.Length);
      for (var i = 0; i < spawnObjectsGroupList.Length; i++)
        foreach (var slime in
                 spawnObjectsGroupList[i].GetComponentsInChildren<SlimeHealth>())
          slime.TakeDamage(3);
    }
  }
}