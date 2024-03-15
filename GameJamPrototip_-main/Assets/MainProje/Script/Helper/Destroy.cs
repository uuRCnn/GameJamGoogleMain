using System;
using UnityEngine;

namespace Script.Helper
{
  public class Destroy : MonoBehaviour
  {
    [SerializeField] private float destroyTime;

    private void Start()
    {
      Destroy(gameObject, destroyTime);
    }
    
    
  }
}