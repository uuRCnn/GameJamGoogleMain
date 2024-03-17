using MainProje.Script.GoogleScript.Controler;

namespace MainProje.Script.GoogleScript.Player
{
  public class SkillActive : Singleton<SkillActive>
  {
    public bool isXSkillActive;
    public bool isCSkillActive;


    private void Update()
    {
      if (isXSkillActive)
      {
        HeroCollider.Instance.BüyükYuvarlakSkillX(6f);
        isXSkillActive = false;
      }

      if (isCSkillActive)
      {
        HeroCollider.Instance.AltSilindirSkillC(12f); //20den aşagısı bara işlemiyor
        isCSkillActive = false;
      }
    }
  }
}