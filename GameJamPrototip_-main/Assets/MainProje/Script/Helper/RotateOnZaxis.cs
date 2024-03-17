using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MainProje.Script.Helper
{
  public class RotateOnZaxis : MonoBehaviour
  {
    public float rotationSpeed = 1f;

    private Vector3 direction = Vector3.forward;


    private void Start()
    {
      UpdateFunc();
    }
    // ==> Unity Event Functions <==
    // ========================================================================================

    private void Update()
    {
      transform.Rotate(rotationSpeed * Time.deltaTime * direction);
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