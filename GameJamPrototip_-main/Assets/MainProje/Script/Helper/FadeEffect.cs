using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Helper
{
  public class FadeEffect : Singleton<FadeEffect>
  {
    // ==> Components <==
    // ========================================================================================
    public static bool CanLoadScene;

    [SerializeField]                    private Image loadingBackground;
    [SerializeField] [Range(0, 0.005f)] private float loadingStepTime;
    [SerializeField] [Range(0, 0.1f)]   private float loadingStepValue;

    // ==> Main Functions <==
    // ========================================================================================

    // -<                                                                             --> Sahne yüklenmesi için ekran rengi kararıyor
    private IEnumerator FadeInEffect()
    {
      var backgroundColor = loadingBackground.color;
      backgroundColor.a = 0;
      loadingBackground.color = backgroundColor;
      loadingBackground.gameObject.SetActive(true);


      var wait = new WaitForSeconds(loadingStepTime);

      while (backgroundColor.a <= 1)
      {
        yield return wait;

        backgroundColor.a += loadingStepValue;
        loadingBackground.color = backgroundColor;
      }

      CanLoadScene = true;

      yield return null;
    }

    // -<                                                                             --> Sahne yüklendi ve ekran rengi açılıyor
    private IEnumerator FadeOutEffect()
    {
      CanLoadScene = false;

      var backgroundColor = loadingBackground.color;

      var wait = new WaitForSeconds(loadingStepTime);

      while (backgroundColor.a >= 0)
      {
        yield return wait;

        backgroundColor.a -= loadingStepValue;
        loadingBackground.color = backgroundColor;
      }

      loadingBackground.gameObject.SetActive(false);

      yield return null;
    }

    private IEnumerator FadeAllEffect()
    {
      yield return StartCoroutine(FadeInEffect());

      yield return new WaitForSeconds(4f);

      yield return StartCoroutine(FadeOutEffect());
    }


#region ==> Public FadeEffect Funtions <==
    // =============================================================================================================

    public void FadeIn()
    {
      StartCoroutine(FadeInEffect());
    }

    public void FadeOut()
    {
      StartCoroutine(FadeOutEffect());
    }

    public void FadeAll()
    {
      StartCoroutine(FadeAllEffect());
    }
#endregion
  }
}