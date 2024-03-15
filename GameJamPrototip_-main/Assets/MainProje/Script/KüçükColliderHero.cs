using Script.Manager;
using Script.Manager.Inputt;
using UnityEngine;

namespace Script
{
  public class KüçükHeroCollider : Singleton<KüçükHeroCollider>
  {
    public int levelState = 1;

    private void Update()
    {
      if (levelState == 1)
      {
        CinemachineManager.Instance.AllGameImpulseSetting(AllGameImpulseEnum.Impulse1);
      }

      if (levelState == 2)
      {
        CinemachineManager.Instance.AllGameImpulseSetting(AllGameImpulseEnum.Impulse2);
      }

      if (levelState == 3)
      {
        CinemachineManager.Instance.AllGameImpulseSetting(AllGameImpulseEnum.Impulse3);
      }

      if (levelState == 4)
      {
        CinemachineManager.Instance.AllGameImpulseSetting(AllGameImpulseEnum.Impulse4);
      }

      if (levelState == 5)
      {
        CinemachineManager.Instance.AllGameImpulseSetting(AllGameImpulseEnum.Impulse5);
      }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Level"))
      {
        levelState += 1;
        InputManager.Instance.FlinchAction();
        other.gameObject.SetActive(false);
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (other.CompareTag("Level"))
      {
        if (other.gameObject != null)
        {
          other.gameObject.SetActive(false);
        }
      }
    }
  }
}