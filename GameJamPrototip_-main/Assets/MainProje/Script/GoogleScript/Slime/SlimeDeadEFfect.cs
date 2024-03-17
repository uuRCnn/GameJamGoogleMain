using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Script.GoogleScript.Slime
{
  public class SlimeDeadEFfect : MonoBehaviour
  {
    [SerializeField]         Transform           slimeTransform;
    [SerializeField] private SkinnedMeshRenderer SkinedMeshRenderObject;
    [SerializeField] private Material            ownMaterial;

    [SerializeField] private GameObject KingDieEffect;

    private Color deafulColor;

    public bool isDeadslime;
    bool        isOneTimeDead;

    private void OnEnable()
    {
      if (isOneTimeDead)
      {
        ownMaterial.color = deafulColor;
      }
    }

    private void Start()
    {
      // ownMaterial = SkinedMeshRenderObject.GetComponent<SkinnedMeshRenderer>().materials[0];
      ownMaterial = SkinedMeshRenderObject.materials[0];
      deafulColor = ownMaterial.color;
    }

    public async void SlimeDeadEffect()
    {
      isOneTimeDead = true;
      isDeadslime = true;
      var defaulcolor = ownMaterial.color;
      var deafulScale = slimeTransform.localScale;
      slimeTransform.DOScale(deafulScale * 1.7f, 1f);
      ownMaterial.color = Color.red;

      // YanıopSınsun(defaulcolor);


      await UniTask.WaitForSeconds(1);

      slimeTransform.DOScale(Vector3.zero, 1f);

      await UniTask.WaitForSeconds(1f);

      ownMaterial.color = defaulcolor;
      isDeadslime = false;
      slimeTransform.gameObject.SetActive(false);
    }

    public async void KingSlimeDeadEffect()
    {
      isOneTimeDead = true;
      isDeadslime = true;
      var defaulcolor = ownMaterial.color;
      var deafulSclae = slimeTransform.localScale;
      slimeTransform.DOScale(deafulSclae * 1.5f, 1f);
      ownMaterial.color = Color.red;

      // YanıopSınsun(defaulcolor);
      await UniTask.WaitForSeconds(1);

      slimeTransform.DOScale(deafulSclae, 1f);

      await UniTask.WaitForSeconds(1f);

      slimeTransform.DOScale(deafulSclae * 2f, 1f);

      await UniTask.WaitForSeconds(1);

      slimeTransform.DOScale(deafulSclae, 1f);

      await UniTask.WaitForSeconds(1f);

      slimeTransform.DOScale(deafulSclae * 3.5f, 1f);

      await UniTask.WaitForSeconds(1f);

      slimeTransform.DOScale(deafulSclae, 1f);

      await UniTask.WaitForSeconds(1);

      slimeTransform.DOScale(deafulSclae * 5.5f, 1f);

      await UniTask.WaitForSeconds(1f);

      slimeTransform.DOScale(Vector3.zero, 1f);

      // KingDieEffect.SetActive(true);

      await UniTask.WaitForSeconds(2f);

      ownMaterial.color = defaulcolor;

      isDeadslime = false;
      slimeTransform.gameObject.SetActive(false);
    }

    // private async void YanıopSınsun(Color defautColor)
    // {
    //   while (isDeadslime)
    //   {
    //     await UniTask.WaitForSeconds(0.1f);
    //     ownMaterial.color = defautColor;
    //     await UniTask.WaitForSeconds(0.1f);
    //     ownMaterial.color = Color.red;
    //   }
    // }
  }
}