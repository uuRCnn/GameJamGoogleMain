using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MainProje.Script.GoogleScript
{
  public class SpawnManager : MonoBehaviour
  {
    [SerializeField] public GameObject[] spawnObjects;

    private void Start()
    {
      // SpawnSlimes();
    }

    private async void SpawnSlimes()
    {
      await UniTask.WaitForSeconds(1f);

      var randomSlime = Random.Range(1, 10);

      var randomX = Random.Range(-80, 80);

      var randomZ = Random.Range(-80, 80);

      Instantiate(spawnObjects[randomSlime], new Vector3(randomX, 45, randomZ), Quaternion.identity);
    }
  }
}