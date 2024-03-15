using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Helper
{
  public static class Helper
  {
    private static Camera _camera;

    private static PointerEventData    _mousePosition;
    private static List<RaycastResult> _results;

    private static Vector3 _worldPosition;

    public static Camera Camera
    {
      get
      {
        if (_camera == null)
          _camera = Camera.main;

        return _camera;
      }
    }

    /// <summary>
    ///   Oyuncunun mousu bir UI elemanın üstündeyse True döner.
    /// </summary>
    /// <returns></returns>
    public static bool IsOverUI()
    {
      _mousePosition = new PointerEventData(EventSystem.current)
        { position = Input.mousePosition };

      _results = new List<RaycastResult>();
      EventSystem.current.RaycastAll(_mousePosition, _results);

      return _results.Count > 0;
    }

    /// <summary>
    ///   argüman olarak yolladıgın UI elemanının pozisyonunu döndürür.
    ///   (IsOverUI ile kullanılabilir.)
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static Vector2 GetWorlPositionOfUIElement(RectTransform element)
    {
      var camera = Camera;

      RectTransformUtility.ScreenPointToWorldPointInRectangle(
        element, element.position, camera, out var result);

      return result;
    }

    /// <summary>
    ///   Mouse tıklaması Mousun oldugun yerin pozisyonunu döndürür.
    /// </summary>
    /// <returns></returns>
    public static Vector2 GetMouseWorldPosition()
    {
      var screenPosition = Input.mousePosition;

      var camera = Camera;

      _worldPosition.Set(
        screenPosition.x,
        screenPosition.y,
        -camera.transform.position.z);

      var worldPosition =
        camera.ScreenToWorldPoint(_worldPosition);

      return new Vector2(worldPosition.x, worldPosition.y);
    }


    // Extension Method = bunu gerekirse kullan

    // public static void Deneme(ref this float deneme)
    // {
    // Debug.Log(deneme);
    // }
  }
}