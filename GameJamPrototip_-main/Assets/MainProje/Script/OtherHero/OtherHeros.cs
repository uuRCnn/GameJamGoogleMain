using System;
using Cysharp.Threading.Tasks;
using Script.Helper;
using Script.Hero;
using Script.Manager;
using Script.Manager.Inputt;
using UnityEngine;

namespace Script.OtherHero
{
  enum isDcotrEnum
  {
    No,
    Yes,
    Realdoktor,
  }

  public class OtherHeros : MonoBehaviour
  {
    [SerializeField] private GameObject UItext;

    [SerializeField] private isDcotrEnum isDcotrcanavar;

    [SerializeField] private GameObject doktorCanavarı;
    [SerializeField] private GameObject Hayaletcanavarı;
    [SerializeField] private GameObject otomat;


    [SerializeField] private GameObject gerçekDoktor;


    [SerializeField] private GameObject bariyerCollider;

    [SerializeField] GameObject[] ŞekerObjectler;

    [SerializeField] GameObject[] EngellerIbjectler;


    [SerializeField] private GameObject EndGameEOBject;

    [SerializeField] private SpriteRenderer PlayerSpireREnder;

    [SerializeField] AudioClip doktorSes;

    private void Awake()
    {
      if (isDcotrcanavar == isDcotrEnum.No)
        return;

      ŞekerObjectler = GameObject.FindGameObjectsWithTag("Şeker");
    }

    public void ShowTextUI()
    {
      UItext.SetActive(true);

      if (isDcotrcanavar == isDcotrEnum.Yes)
      {
        StartCanavarDoktorTalkFade();
      }

      if (isDcotrcanavar == isDcotrEnum.Realdoktor)
      {
        StartRealydoktroTalkFade();
      }
    }


    public void DeActiveUI()
    {
      if (isDcotrcanavar == isDcotrEnum.Yes || isDcotrcanavar == isDcotrEnum.Realdoktor)
      {
        return;
      }

      UItext.SetActive(false);
    }

    private async void StartRealydoktroTalkFade()
    {
      await UniTask.WaitForSeconds(12f);

      FadeEffect.Instance.FadeIn();

      await UniTask.WaitForSeconds(3f);

      gerçekDoktor.SetActive(false);

      await UniTask.WaitForSeconds(2f);

      EndGameEOBject.SetActive(true);
    }

    private async void StartCanavarDoktorTalkFade()
    {
      await UniTask.WaitForSeconds(7f);

      CinemachineManager.Instance.SarsıntıImpulse();

      InputManager.Instance.DeadthAction();

      await UniTask.WaitForSeconds(5f);

      FadeEffect.Instance.FadeIn();

      await UniTask.WaitForSeconds(1f);

      doktorCanavarı.SetActive(false);
      Hayaletcanavarı.SetActive(false);
      otomat.SetActive(false);

      foreach (var şekerler in ŞekerObjectler)
      {
        şekerler.SetActive(false);
      }

      foreach (var engel in EngellerIbjectler)
      {
        engel.SetActive(true);
      }

      bariyerCollider.SetActive(true);

      gerçekDoktor.SetActive(true);

      await UniTask.WaitForSeconds(3f);

      UItext.SetActive(false);

      await UniTask.WaitForSeconds(0.5f);

      FadeEffect.Instance.FadeOut();

      CinemachineManager.Instance.StartGameImpulse();

      KüçükHeroCollider.Instance.levelState = 2;

      AudioManager.Instance.PlaySoundEffect(doktorSes, 0.5f);
    }
  }
}