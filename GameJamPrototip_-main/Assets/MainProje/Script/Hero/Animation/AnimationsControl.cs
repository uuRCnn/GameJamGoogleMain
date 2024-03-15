using System;
using Script.Hero.Movingg;
using Script.Manager.Inputt;
using UnityEngine;

namespace Script.Hero.Animation
{
  // ==> Enums
  public enum AnimStates : byte
  {
    Idle,
    Walk,
    Run,
    Jump,
    Attack,
    Death,
    Flinch,
    NullIdle
  }

  public class AnimationsControl : MonoBehaviour
  {
    // ==> Components <==
    // ========================================================================================
    [SerializeField] public Animator animator;

    private HeroAnimStateController _heroAnimStateController;

    // ==> Unity Event Functions <==
    // ========================================================================================
    private void Awake()
    {
      _heroAnimStateController = new HeroAnimStateController(animator);
    }


    // ==> Main Functions <==
    // ========================================================================================
    private void AnimController(AnimStates animStates)
    {
      switch (animStates)
      {
        case AnimStates.Idle:
          Idle();
          break;
        case AnimStates.Walk:
          Walk();
          break;
        case AnimStates.Run:
          Run();
          break;
        case AnimStates.Jump:
          Jump();
          break;
        case AnimStates.Attack:
          Attack();
          break;
        case AnimStates.Death:
          Death();
          break;
        case AnimStates.Flinch:
          Flinch();
          break;
        case AnimStates.NullIdle:
          NullIdle();
          break;
        default:
          throw new ArgumentOutOfRangeException(
            nameof(animStates), animStates, null);
      }
    }

#region ==> Public AnimState Functions <==
    // ========================================================================================

    public void IdleAnim()
    {
      AnimController(AnimStates.Idle);
    }

    public void WalkAnim()
    {
      AnimController(AnimStates.Walk);
    }

    public void RunAnim()
    {
      AnimController(AnimStates.Run);
    }

    public void JumpAnim()
    {
      AnimController(AnimStates.Jump);
    }

    public void AttackAnim()
    {
      AnimController(AnimStates.Attack);
    }

    public void DeathAnim()
    {
      AnimController(AnimStates.Death);
    }

    public void FlinchAnim()
    {
      AnimController(AnimStates.Flinch);
    }

    public void NullIdleAnim()
    {
      AnimController(AnimStates.NullIdle);
    }
#endregion

#region ==> AnimController Little Functions <==
    // ========================================================================================

    private void Idle()
    {
      if (!Moving.Instance.isMoving &&
          !InputManager.Instance.isJuming &&
          !InputManager.Instance.isInteact &&
          !InputManager.Instance.isFliching &&
          !InputManager.Instance.isDying)
        _heroAnimStateController.ChangeState(AnimStates.Idle);
    }

    private void Walk()
    {
      if (!Moving.Instance.isRuning &&
          !InputManager.Instance.isJuming)
        _heroAnimStateController.ChangeState(AnimStates.Walk);
    }

    private void Run()
    {
      if (!InputManager.Instance.isJuming)
        _heroAnimStateController.ChangeState(AnimStates.Run);
    }

    private void Jump()
    {
      _heroAnimStateController.ChangeState(AnimStates.Jump);
    }

    // * * * * * * * * * * * *

    private void Flinch()
    {
      _heroAnimStateController.ChangeState(AnimStates.Flinch);
    }

    private void Death()
    {
      _heroAnimStateController.ChangeState(AnimStates.Death);
    }

    private void Attack()
    {
      _heroAnimStateController.ChangeState(AnimStates.Attack);
    }

    private void NullIdle()
    {
      _heroAnimStateController.ChangeState(AnimStates.NullIdle);
    }
#endregion
  }
}