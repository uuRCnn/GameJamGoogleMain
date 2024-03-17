using System;
using Script;
using UnityEngine;

namespace MainProje.Script.GoogleScript.Player
{
  public class MimicCollider : Singleton<MimicCollider>
  {
    [SerializeField] Transform heroTransform;

    private void Update()
    {
      transform.position = heroTransform.position;
    }
  }
}