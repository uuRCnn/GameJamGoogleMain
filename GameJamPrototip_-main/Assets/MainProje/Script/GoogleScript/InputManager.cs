using System;
using MainProje.Script.GoogleScript.Player;
using MainProje.Script.Hero;
using UnityEngine;

namespace Script.GoogleScript
{
  public class InputManager : Singleton<InputManager>
  {
    private float CouldDownZ = 0;
    private float CouldDownX = 0;
    private float CouldDownC = 0;

    private void Update()
    {
      if (!OwnGameManager.isGameStart)
        return;


      if (Input.GetKey(KeyCode.Space) && Skils.Instance.spaceAmount > 0)
      {
        Skils.Instance.SpaceSkil();
      }
      else
      {
        Skils.Instance.SetSpeed(Skils.Instance.sabitSpeed);
        Skils.Instance.isDmgSkillUsing = false;
        if (Skils.Instance.spaceAmount <= 1f)
        {
          Skils.Instance.spaceAmount += Time.deltaTime / 10;
        }
      }


      if (Input.GetKeyDown(KeyCode.Z) && CouldDownZ >= 1f)
      {
        Skils.Instance.ZSkil();
        UIManager.Instance.SkilzUI.SetActive(false);
        CouldDownZ = 0;
      }
      else if (CouldDownZ >= 1f)
      {
        UIManager.Instance.SkilzUI.SetActive(true);
      }
      else
      {
        CouldDownZ += Time.deltaTime / 13;
      }


      if (Input.GetKeyDown(KeyCode.X) && CouldDownX >= 1f)
      {
        Skils.Instance.XSkil();
        UIManager.Instance.SkilxUI.SetActive(false);
        CouldDownX = 0;
      }
      else if (CouldDownX >= 1f)
      {
        UIManager.Instance.SkilxUI.SetActive(true);
      }
      else
      {
        CouldDownX += Time.deltaTime / 6;
      }

      if (Input.GetKeyDown(KeyCode.C) && CouldDownC >= 1f)
      {
        Skils.Instance.CSkil();
        UIManager.Instance.SkilcUI.SetActive(false);
        CouldDownC = 0;
      }
      else if (CouldDownC >= 1f)
      {
        UIManager.Instance.SkilcUI.SetActive(true);
      }
      else
      {
        CouldDownC += Time.deltaTime / 9;
      }
    }
  }
}