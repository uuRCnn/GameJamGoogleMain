using System;
using Cysharp.Threading.Tasks;
using Microlight.MicroBar;
using Script.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.GoogleScript
{
  public class UIManager : Singleton<UIManager>
  {
    [SerializeField] private GameObject SkillsUI;
    [SerializeField] private GameObject RedScreen;
    [SerializeField] public  GameObject wasd;

    [SerializeField] public Slider spaceSlider;

    [SerializeField] public GameObject SkilzUI;
    [SerializeField] public GameObject SkilxUI;
    [SerializeField] public GameObject SkilcUI;

    [Header("SettingMenu")]
    [SerializeField] private GameObject SettingMenu;

    [SerializeField] private GameObject settingButton; // action için
    [SerializeField] private GameObject music; // action için
    [SerializeField] private GameObject soundsfx; // action için
    [SerializeField] private GameObject settingExit; // action için


    [SerializeField] public MicroBar _hpBarPlayer;
    [SerializeField] public MicroBar _hpBarKingKısa;
    [SerializeField] public MicroBar _hpBarKingUzun;

    [SerializeField] private GameObject Yaraslar;


    [SerializeField] public GameObject CskillEffect;
    [SerializeField] public GameObject cSkillTransfrmSpawn;


    [SerializeField] public GameObject SlimeDmgEffect;

    [SerializeField] public GameObject kinhDieEFfect;

    [SerializeField] public GameObject girişTExt;


    [SerializeField] private GameObject UIWin;
    [SerializeField] private GameObject UIlose;


    [SerializeField] private GameObject SOnPatlama;

    [SerializeField] private GameObject PlayerTar;

    private void Start()
    {
      if (_hpBarPlayer != null) _hpBarPlayer.Initialize(100);
      if (_hpBarKingKısa != null) _hpBarKingKısa.Initialize(700);
      if (_hpBarKingUzun != null) _hpBarKingUzun.Initialize(400);
    }

    private void Update()
    {
      if (OwnGameManager.isGameStart)
      {
        Yaraslar.SetActive(true);
      }
    }

    public void SpawnCEffeckt()
    {
      Instantiate(CskillEffect, cSkillTransfrmSpawn.transform.position, new Quaternion(0, 0, 0, 90));
    }

    public void CloseSettinMenu()
    {
      Time.timeScale = 1;
      SettingMenu.SetActive(false);
    }

    public void OpenSettingMenu()
    {
      Time.timeScale = 0;
      SettingMenu.SetActive(true);
    }

    public void RePlay()
    {
      Time.timeScale = 1;

      SceneManager.LoadScene(0);
    }

    public void WinUI()
    {
      // Time.timeScale = 0;

      UIWin.SetActive(true);
    }

    public void LoseUI()
    {
      // Time.timeScale = 0;

      UIlose.SetActive(true);

      Skils.Instance.SetSpeed(0);

      PAtlama();
    }


    private async void PAtlama()
    {
      var x = 0;
      AudioManager.Instance.PlaySondClipt();
      while (x < 20)
      {
        var random = UnityEngine.Random.Range(0, 360);

        var randomSclae = UnityEngine.Random.Range(1f, 10f);
        var obeh = Instantiate(SOnPatlama, PlayerTar.transform.position, Quaternion.identity);
        obeh.transform.localScale = new Vector3(randomSclae, randomSclae, randomSclae);
        await UniTask.WaitForSeconds(0.1f);
        x++;
      }
    }
  }
}