using UnityEngine;

namespace Script.Hero.Animation
{
  public class HeroAnimState
  {
    private readonly Animator _animator;

    public HeroAnimState(Animator animator)
    {
      _animator = animator;
    }

    public void OnEnter(AnimStates animStates)
    {
      _animator.Play(animStates.ToString());
    }
  }

  /// <summary>
  ///   Hero Animasyonlarını burdan çekerek kontrol et.
  /// </summary>
  // ==> Main Functions
  public class HeroAnimStateController
  {
    // ==> Components <==
    // ========================================================================================
    private readonly HeroAnimState _currentState;
    private          AnimStates    _lastAnimState;

    public HeroAnimStateController(Animator animator)
    {
      _currentState = new HeroAnimState(animator);
      _currentState.OnEnter(AnimStates.Idle);

      _lastAnimState = AnimStates.Idle;
    }

    // ==> Main Functions
    // ========================================================================================
    public void ChangeState(AnimStates newAnimState)
    {
      if (_lastAnimState == newAnimState)
        return;

      _lastAnimState = newAnimState;
      _currentState.OnEnter(newAnimState);
    }
  }
}