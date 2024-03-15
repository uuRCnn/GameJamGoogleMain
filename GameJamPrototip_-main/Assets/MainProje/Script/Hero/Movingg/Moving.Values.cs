using Script.Hero.Animation;
using UnityEngine;

namespace Script.Hero.Movingg
{
  // ==> Enums
  public enum MovingDirection : byte
  {
    GoToLeft,
    GoToRight,
    GoToUp,
    GoToDown
  }

  internal partial class Moving
  {
    private static float _horizontalInput;


    // ==> Components <==
    // ========================================================================================
    [SerializeField] private AnimationsControl animController;
    // ==> Values <==
    //                                                                                --> isCanGo = Duvarlara çarpma durumunu kontrol eder (isCanGo = gidebilir mi)
    public bool isCanGoRight = true;
    public bool isCanGoLeft  = true;
    public bool isCanGoUp    = true;
    public bool isCanGoDown  = true;

    public bool stopMoving;
    public bool isMoving;
    public bool isRuning;
    // ==> Values <==
    private readonly float _speedPowerForRun = 7f;

    private float _goDownImpulse;
    private float _goLeftImpulse;

    // -<                                                                             --> bunlar 0 ila 1 arasında değer alır
    private float _goRightImpulse;
    private float _goUpImpulse;


    //todo: -<                                                                        --> bu readonly olursa çalışırmı dene.
    private bool _isFaceLookingToLeft;


    private bool _isGoingDown;
    private bool _isGoingLeft;

    // -<                                                                             -->  isGoing = Karakterin gittiği yönü kontrol eder (isGoing = gidiyor mu)
    private bool _isGoingRight;
    private bool _isGoingUp;

    private Vector2 _lastPosition;
    private Vector2 _movedirection;
    private float   SpeedMain = 7f;
  }
}