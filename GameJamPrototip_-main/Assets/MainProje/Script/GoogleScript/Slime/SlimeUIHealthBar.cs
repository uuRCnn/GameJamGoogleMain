using System;
using UnityEditor.Media;
using UnityEngine;

namespace Script.GoogleScript.Slime
{
  public class SlimeUIHealthBar : MonoBehaviour
  {
    private                  Transform thisBarTransform;
    [SerializeField] private Transform cameraTransfrom;

    private Vector3 barHereStop = new Vector3(-4.5f, 12f, -1.5f);

    [SerializeField] private Transform bossSlimeTransform;

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