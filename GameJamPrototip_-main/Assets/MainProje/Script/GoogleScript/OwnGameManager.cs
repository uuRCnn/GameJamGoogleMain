using System;
using Cinemachine;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using MainProje.Script.GoogleScript.Controler;
using UnityEngine;

namespace MainProje.Script.GoogleScript
{
  public class OwnGameManager : Singleton<OwnGameManager>
  {
    public static bool isGameStart;


    public static Action GameStart;

    [SerializeField] private Transform                VirtualCameraTransform;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Transform                DirectionLightTrasnfrom;


    public bool isSmileKingDie;
    public bool isUuzunKingDie;
    public bool isAllBossDie;

    private readonly Vector3 asılRotationVector = new(45, 22, 0);

    private bool isSkipStart;

    private async void Start()
    {
      Skils.Instance.SetSpeed(0);
      // CameraZoomOut(8, 80);

      await UniTask.WaitForSeconds(25);


      if (isSkipStart)
        return;


      GameStartFunc();
    }

    private void Update()
    {
      if (isSmileKingDie && isUuzunKingDie)
      {
        isAllBossDie = true;
        UIManager.Instance.WinUI();
        // todo: oyunu bitir
      }
    }

    private void OnEnable()
    {
      GameStart += EventCamereZoomOut;
    }

    public void GameStartFunc()
    {
      isSkipStart = true;

      UIManager.Instance.wasd.SetActive(false);
      UIManager.Instance.girişTExt.SetActive(false);

      UIManager.Instance.CloseSettinMenu();
      // todo: textleri burda kapatki Skip butonuda dogru çalışsın
      Skils.Instance.SetSpeed(8);
      CameraZoomOut(4, 35);
      CamereRotations();

      DirecitolightRotation();
    }

    private void CamereRotations() //todo: text ile 10 15 sn sonra bu çalışacak
    {
      VirtualCameraTransform.DOLocalRotate(asılRotationVector, 4f).SetEase(Ease.InOutSine);
    }

    private void CameraZoomOut(float time, float endValueforView)
    {
      DOTween.To(() =>
        _virtualCamera.m_Lens.FieldOfView, x =>
        _virtualCamera.m_Lens.FieldOfView = x, endValueforView, time);
    }

    private async void EventCamereZoomOut()
    {
      CameraZoomOut(2, 30);

      await UniTask.WaitForSeconds(4f);

      CameraZoomOut(7, 18);
    }

    private void DirecitolightRotation()
    {
      DirectionLightTrasnfrom.DOLocalRotate(
        new Vector3(0, 360, 0), 16f).SetEase(Ease.InOutSine);
    }

    public void SkipButon()
    {
      isSkipStart = true;
    }
  }
}