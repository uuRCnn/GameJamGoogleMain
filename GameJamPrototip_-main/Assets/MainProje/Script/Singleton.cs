using UnityEngine;

namespace Script
{
  public class Singleton<T> : MonoBehaviour where T : Component
  {
    public static T Instance { get; private set; }

    public virtual void Awake()
    {
      if (Instance == null)
        // -<                                                                         --> bilgi = bu This as T = bu T tipinde ise ata demek. Degilse Null ata.
        Instance = this as T;
      else
        Destroy(gameObject);
    }
  }
}