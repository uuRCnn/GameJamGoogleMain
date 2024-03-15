using UnityEngine;

namespace Script.Hero.Movingg
{
  internal partial class Moving
  {
#region Little Functions
    // ========================================================================================

    private static bool InputKey(KeyCode keyCode)
    {
      var pressTheButton = Input.GetKey(keyCode);
      return pressTheButton;
    }

    private void TurnFaceToLeft(bool isTurnToLeft)
    {
      _isFaceLookingToLeft = isTurnToLeft;
      FlipToFace(_isFaceLookingToLeft);
    }

    private void Animations()
    {
      if (!_isGoingLeft && !_isGoingRight && !_isGoingUp && !_isGoingDown)
        animController.IdleAnim();
    }

    private void FlipToFace(bool newValue)
    {
      HeroMain.Instance.spriteRenderer.flipX = newValue;
    }
#endregion

#region ==> Moving Litle Functions <==
    // ========================================================================================

    private void _isMoving()
    {
      Vector2 position = transform.position;
      isMoving = position != _lastPosition; // bool
      _lastPosition = position;
    }

    private void MoveHere()
    {
      HeroMain.Instance.playerTransform.Translate(
        _movedirection * (Time.deltaTime * SpeedMain));
    }

    private void CalculateDirectionHorizantal(float getAxisHorizantal)
    {
      _movedirection = Vector2.right * getAxisHorizantal;
    }

    private void CalculateDirectionVertical(float getAxisVertical)
    {
      _movedirection = Vector2.up * getAxisVertical;
    }

    // -<                                                                             -->  Hata verdiginden dolayı böyle 2 ayrı fonksiyona böldüm.
    private void MoveHorizantal(float getAxisHorizantal)
    {
      CalculateDirectionHorizantal(getAxisHorizantal);
      MoveHere();
      animController.WalkAnim();
    }

    private void MoveVertical(float getAxisVertical)
    {
      CalculateDirectionVertical(getAxisVertical);
      MoveHere();
      animController.WalkAnim();
    }
#endregion


#region ==> SmoothMoving <==
    // ========================================================================================

    //                                                                                --> karakterin yavaş bir şekilde hızlanmasını sağlar 
    private static float SmoothMoving(float movingValue)
    {
      const float smoothingPower = 2.5f;

      if (movingValue < 1)
      {
        movingValue += Time.deltaTime * smoothingPower;
        return movingValue;
      }

      //                                                                              --> MovingValue = 1; (if koşulu 1 değerini aştıgında, bu değeri 1'e sabitliyoruz. Aynı istedigimiz gibi)
      return 1;
    }

    //                                                                                --> karakterin yavaş bir şekilde hızının düşmesini sağlar (burda sadece Value'sunu düşürürüz.
    private static float SmoothMovingDefult(float movingValue)
    {
      const float smoothingPower = 2.5f;

      if (movingValue > 0)
      {
        movingValue -= Time.deltaTime * smoothingPower;
        return movingValue;
      }

      //                                                                              --> MovingValue = 0; (if koşulu 0 değerini aştıgında, bu değeri 0'e sabitliyoruz. Aynı istedigimiz gibi)
      return 0;
    }
#endregion
  }
}