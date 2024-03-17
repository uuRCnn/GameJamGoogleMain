using UnityEngine;

namespace MainProje.Script.GoogleScript.Slime
{
  public class SlimeUIHealthBar : MonoBehaviour
  {
    [SerializeField] private Transform cameraTransfrom;

    [SerializeField] private Transform bossSlimeTransform;

    private readonly Vector3   barHereStop = new(-4.5f, 12f, -1.5f);
    private          Transform thisBarTransform;

    private void Awake()
    {
      thisBarTransform = GetComponent<Transform>();
    }

    private void Update()
    {
      thisBarTransform.LookAt(cameraTransfrom);

      var barNewTranform = bossSlimeTransform.position + barHereStop;

      thisBarTransform.SetPositionAndRotation(barNewTranform, thisBarTransform.rotation);
    }
  }
}