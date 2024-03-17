using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using MainProje.Script.Hero;
using Script.Hero;
using Script.Hero.Movingg;
using Script.OtherHero;
using UnityEngine;

namespace Script.Manager.Inputt
{
  internal partial class InputManager
  {
    [SerializeField] private AudioClip InerractnioSpoun;
    [SerializeField] private AudioClip dmgsound;
    [SerializeField] private AudioClip deatsound;

    public async void DeadthAction()
    {
      CinemachineManager.Instance.SarsıntıImpulse();

      AudioManager.Instance.PlaySoundEffect(deatsound, 0.5f);

      isDying = true;
      Moving.Instance.stopMoving = true;

      animController.DeathAnim();

      await UniTask.WaitForSeconds(6f);

      animController.animator.CrossFade("Idle", 1f);
      await UniTask.WaitForSeconds(2f);
      isDying = false;
      Moving.Instance.stopMoving = false;
      // Time.timeScale = 0;
    }

    public async void FlinchAction() // uçurumdan sarkma.
    {
      CinemachineManager.Instance.SarsıntıImpulse();

      isFliching = true;

      AudioManager.Instance.PlaySoundEffect(dmgsound, 0.5f);

      Moving.Instance.stopMoving = true;

      animController.FlinchAnim();

      HeroMain.Instance.playerTransform.DORotate(
        new Vector3(6, 6, 6),
        0.7f);

      await UniTask.WaitForSeconds(0.7f);

      HeroMain.Instance.playerTransform.DORotate(
        new Vector3(-5, -5, -5),
        0.7f);

      await UniTask.WaitForSeconds(0.7f);

      HeroMain.Instance.playerTransform.DORotate(
        new Vector3(3, 3, 3),
        0.7f);

      await UniTask.WaitForSeconds(0.7f);

      HeroMain.Instance.playerTransform.DORotate(
        new Vector3(-2, -2, -2),
        0.7f);

      Moving.Instance.stopMoving = false;

      isFliching = false;
    }

    private async void InterAction()
    {
      isInteact = true;

      // if (HeroCollider.Instance.otherHerosScript != null)
        // HeroCollider.Instance.otherHerosScript.ShowTextUI();

      Moving.Instance.stopMoving = true;

      AudioManager.Instance.PlaySoundEffect(InerractnioSpoun, 0.5f);

      HeroMain.Instance.playerTransform.DORotate(
        new Vector3(8, 8, 8),
        0.2f);

      HeroMain.Instance.playerTransform.DOScale(
        new Vector3(0.35f, 0.35f, 0.35f),
        0.2f);

      animController.AttackAnim();

      await UniTask.WaitForSeconds(0.3f);

      HeroMain.Instance.playerTransform.DORotate(
        new Vector3(0, 0, 0),
        0.1f);

      HeroMain.Instance.playerTransform.DOScale(
        new Vector3(0.3f, 0.3f, 0.3f),
        0.1f);

      Moving.Instance.stopMoving = false;

      isInteact = false;
    }

    private async void JumpAction()
    {
      isJuming = true;

      HeroMain.Instance.playerTransform.DOLocalJump(
        HeroMain.Instance.playerTransform.position,
        2f,
        1,
        1);

      animController.JumpAnim();

      await UniTask.WaitForSeconds(1);

      isJuming = false;
    }
  }
}