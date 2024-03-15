using System;
using UnityEngine;

// ReSharper disable InvertIf

namespace Script.Hero.Movingg
{
  internal partial class Moving : Singleton<Moving>
  {
    // ==> Unity Event Functions <==
    // ========================================================================================

    private void Start()
    {
      _lastPosition = transform.position;
    }

    private void Update()
    {
      _isMoving();
      MovingInput();
      Animations();
    }


    // ==> Main Functions <==
    // ========================================================================================
    private void MovingInput()
    {
      if (stopMoving)
        return;


      if (InputKey(KeyCode.LeftShift) && isMoving)
      {
        SpeedMain = 1.8f * _speedPowerForRun;
        isRuning = true;
        animController.RunAnim();
      }
      else
      {
        SpeedMain = _speedPowerForRun;
        isRuning = false;
      }


      if (InputKey(KeyCode.A) && isCanGoLeft && !_isGoingRight)
      {
        InputController(MovingDirection.GoToLeft);
      }
      else
      {
        _isGoingLeft = false;
        _goLeftImpulse = SmoothMovingDefult(_goLeftImpulse);
      }

      if (InputKey(KeyCode.D) && isCanGoRight && !_isGoingLeft)
      {
        InputController(MovingDirection.GoToRight);
      }
      else
      {
        _isGoingRight = false;
        _goRightImpulse = SmoothMovingDefult(_goRightImpulse);
      }

      if (InputKey(KeyCode.W) && isCanGoUp && !_isGoingDown)
      {
        InputController(MovingDirection.GoToUp);
      }
      else
      {
        _isGoingUp = false;
        _goUpImpulse = SmoothMovingDefult(_goUpImpulse);
      }

      if (InputKey(KeyCode.S) && isCanGoDown && !_isGoingUp)
      {
        InputController(MovingDirection.GoToDown);
      }
      else
      {
        _isGoingDown = false;
        _goDownImpulse = SmoothMovingDefult(_goDownImpulse);
      }
    }

    private void InputController(MovingDirection movingDirection)
    {
      switch (movingDirection)
      {
        case MovingDirection.GoToLeft:
          _isGoingLeft = true;
          _goLeftImpulse = SmoothMoving(_goLeftImpulse);
          MoveHorizantal(-1 * _goLeftImpulse);
          TurnFaceToLeft(true);
          break;
        case MovingDirection.GoToRight:
          _isGoingRight = true;
          _goRightImpulse = SmoothMoving(_goRightImpulse);
          MoveHorizantal(1 * _goRightImpulse);
          TurnFaceToLeft(false);
          break;
        case MovingDirection.GoToUp:
          _isGoingUp = true;
          _goUpImpulse = SmoothMoving(_goUpImpulse);
          MoveVertical(1 * _goUpImpulse);
          break;
        case MovingDirection.GoToDown:
          _isGoingDown = true;
          _goDownImpulse = SmoothMoving(_goDownImpulse);
          MoveVertical(-1 * _goDownImpulse);
          break;
        default:
          throw new ArgumentOutOfRangeException(
            nameof(movingDirection), movingDirection, null);
      }
    }
  }
}