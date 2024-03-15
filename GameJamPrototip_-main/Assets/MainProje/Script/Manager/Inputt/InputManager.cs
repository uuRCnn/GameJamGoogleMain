using System;
using Script.Hero.Animation;
using Script.OtherHero;
using UnityEngine;

namespace Script.Manager.Inputt
{
  internal partial class InputManager : Singleton<InputManager>
  {
    public bool isJuming;
    public bool isInteact;
    public bool isFliching;
    public bool isDying;

    // OtherHeros[] otherHerosScript = FindObjectsOfType<OtherHeros>();

    [SerializeField] private AnimationsControl animController;

    private void Update()
    {
      if (Input.GetKey(KeyCode.E) && !isInteact && !isJuming && !isFliching && !isDying) InterAction();

      if (Input.GetKey(KeyCode.Space) && !isInteact && !isJuming && !isFliching && !isDying) JumpAction();

      // if (Input.GetKey(KeyCode.Q) && !isInteact && !isJuming && !isFliching && !isDying) FlinchAction();

      // if (Input.GetKey(KeyCode.F) && !isInteact && !isJuming && !isFliching && !isDying) DeadthAction();
    }
  }
}