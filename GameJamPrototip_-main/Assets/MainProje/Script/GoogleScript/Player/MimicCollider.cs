using MainProje.Script.GoogleScript.Controler;
using UnityEngine;

namespace MainProje.Script.GoogleScript.Player
{
  public class MimicCollider : Singleton<MimicCollider>
  {
    [SerializeField] private Transform heroTransform;

    private void Update()
    {
      transform.position = heroTransform.position;
    }
  }
}