using UnityEngine;

namespace MainProje.Script.GoogleScript.Controler
{
  [CreateAssetMenu(fileName = "So", menuName = "ScriptableObjects/So", order = 0)]
  public class So : ScriptableObject
  {
    public float SoundVoluem = 0.1f;
    public float MusicVoluem = 0.1f;
  }
}