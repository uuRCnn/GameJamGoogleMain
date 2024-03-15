using System;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Script.Manager
{
  public enum AllGameImpulseEnum
  {
    Impulse1,
    Impulse2,
    Impulse3,
    Impulse4,
    Impulse5
  }

  public class CinemachineManager : Singleton<CinemachineManager>
  {
    [SerializeField] private CinemachineImpulseSource startGameImpulse;
    [SerializeField] private CinemachineImpulseSource sarıntıImpulseToDmg;
    [SerializeField] private CinemachineImpulseSource allGameImpulse;

    [SerializeField] public CinemachineVirtualCamera cmVirtualCamera;

    private void Start()
    {
      StartGameImpulse();

      AllGameImpulseSetting(AllGameImpulseEnum.Impulse1);
      AllGameImpulseFunc();
    }

    public void StartGameImpulse()
    {
      startGameImpulse.GenerateImpulse();
    }


    public void SarsıntıImpulse()
    {
      sarıntıImpulseToDmg.GenerateImpulse();
    }

    public async void AllGameImpulseFunc()
    {
      while (true)
      {
        allGameImpulse.GenerateImpulse();
        RandomSarsıntı();
        await UniTask.WaitForSeconds(8);
      }
    }

    private async void RandomSarsıntı()
    {
      var Random = UnityEngine.Random.Range(1, 10);

      if (Random > 4)
        return;

      await UniTask.WaitForSeconds(Random);

      SarsıntıImpulse();
    }

    public void AllGameImpulseSetting(AllGameImpulseEnum allGameImpulseEnum)
    {
      allGameImpulse.m_DefaultVelocity = allGameImpulseEnum switch
      {
        AllGameImpulseEnum.Impulse1 => new Vector3(0, 0, -1),
        AllGameImpulseEnum.Impulse2 => new Vector3(0, 0, -2),
        AllGameImpulseEnum.Impulse3 => new Vector3(0, 0, -3),
        AllGameImpulseEnum.Impulse4 => new Vector3(0, 0, -4),
        AllGameImpulseEnum.Impulse5 => new Vector3(0, 0, -5),
        _ => throw new ArgumentOutOfRangeException(
          nameof(allGameImpulseEnum), allGameImpulseEnum, null)
      };
      sarıntıImpulseToDmg.m_DefaultVelocity = allGameImpulseEnum switch
      {
        AllGameImpulseEnum.Impulse1 => new Vector3(-0.1f, -0.1f, -0.1f),
        AllGameImpulseEnum.Impulse2 => new Vector3(-0.2f, -0.2f, -0.2f),
        AllGameImpulseEnum.Impulse3 => new Vector3(-0.4f, -0.4f, -0.4f),
        AllGameImpulseEnum.Impulse4 => new Vector3(-0.6f, -0.6f, -0.6f),
        AllGameImpulseEnum.Impulse5 => new Vector3(-0.8f, -0.8f, -0.8f),
        _ => throw new ArgumentOutOfRangeException(
          nameof(allGameImpulseEnum), allGameImpulseEnum, null)
      };
      UIManager.Instance.akılSaglıgıSlider.value = allGameImpulseEnum switch
      {
        AllGameImpulseEnum.Impulse1 => 0.2f,
        AllGameImpulseEnum.Impulse2 => 0.4f,
        AllGameImpulseEnum.Impulse3 => 0.6f,
        AllGameImpulseEnum.Impulse4 => 0.8f,
        AllGameImpulseEnum.Impulse5 => 1f,
        _ => throw new ArgumentOutOfRangeException(
          nameof(allGameImpulseEnum), allGameImpulseEnum, null)
      };
    }
  }
}