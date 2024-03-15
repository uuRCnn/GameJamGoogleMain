using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Script.Helper
{
  public class RotateOnZaxis : MonoBehaviour
  {
    public float rotationSpeed = 1f;

    private Vector3 direction = Vector3.forward;
    // ==> Unity Event Functions <==
    // ========================================================================================

    private void Update()
    {
      transform.Rotate(rotationSpeed * Time.deltaTime * direction);
    }


    private void Start()
    {
      UpdateFunc();
    }

    private async void UpdateFunc()
    {
      while (true)
      {
        await UniTask.WaitForSeconds(2f);

        direction = Vector3.left;

        await UniTask.WaitForSeconds(2f);

        direction = Vector3.up;

        await UniTask.WaitForSeconds(2f);

        direction = Vector3.down;

        await UniTask.WaitForSeconds(2f);

        direction = Vector3.right;
      }
    }
  }
}