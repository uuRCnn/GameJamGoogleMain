using UnityEngine;
using UnityEngine.UI;

namespace Script.Helper
{
  [RequireComponent(typeof(Image))]
  public class OnUIButtonHover : MonoBehaviour
  {
    // ==> Components <==
    // ========================================================================================
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite hoverSprite;

    private Image _buttonImageUI;

    // ==> Unity Event Functions <==
    // ========================================================================================

    private void Start()
    {
      _buttonImageUI = GetComponent<Image>();
    }

    // -<                                                                             --> bu butonun üstündeyse çalışır
    public void OnHover(bool isHover)
    {
      // -<                                                                           --> mouse üstünde ise sprite'ı değişir
      _buttonImageUI.sprite = isHover ? hoverSprite : normalSprite;
    }
  }
}