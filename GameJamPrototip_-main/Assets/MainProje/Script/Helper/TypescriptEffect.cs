using System.Collections;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

// ReSharper disable IteratorNeverReturns
// ReSharper disable RedundantAssignment

// ReSharper disable ForCanBeConvertedToForeach

namespace Script.Helper
{
  public class TypescriptEffect : MonoBehaviour
  {
    // ==> Components <==
    // ========================================================================================
    /* Properties Comments
       text : Text to animate
       typescriptWaitingTime : The waiting time between char animations on typescript
       scaleAnimationTime : Time to animate the scale
       scaleCurve : Curve for the scale animation
        _textUI : The ProGUI text on the UI
     */
    [TextArea] [SerializeField] private string          text;
    [SerializeField]            private float           typescriptWaitingTime;
    [SerializeField]            private float           scaleAnimationTime;
    [SerializeField]            private AnimationCurve  scaleCurve;
    [SerializeField]            private TextMeshProUGUI _textUI;
    // ==> Unity Event Functions <==
    // ========================================================================================

    private void OnEnable()
    {
      // -<                                                                           --> Get the components needed for animating the text
      _textUI = GetComponent<TextMeshProUGUI>();
      StartCoroutine(Effect());
    }


    // ==> Main Functions <==
    // ========================================================================================

    private IEnumerator Effect()
    {
      while (true)
      {
        var animText = string.Empty;
        _textUI.text = animText;

        // -<                                                                         --> With a loop we create a typescript effect assigning character per character
        // -<                                                                         --> in animText var and waiting X time
        for (var i = 0; i < text.Length; i++)
        {
          animText += text[i];
          _textUI.text = animText;
          yield return new WaitForSeconds(typescriptWaitingTime);
        }

        // -<                                                                         --> Curve animation time
        float curveDeltaTime = 0;
        // -<                                                                         --> The initial scale of the object
        var initialScale = new Vector2(1, 1);
        // -<                                                                         --> Vector 2 for the new scale
        var scaleValues = initialScale;

        // -<                                                                         --> Scale animation block
        while (curveDeltaTime <= scaleAnimationTime)
        {
          curveDeltaTime += Time.deltaTime;
          var scaleCurveValue = scaleCurve.Evaluate(curveDeltaTime);
          scaleValues = new Vector2(scaleCurveValue, scaleCurveValue);
          transform.localScale = scaleValues;
          yield return new WaitForEndOfFrame();
        }
      }
    }
  }
}