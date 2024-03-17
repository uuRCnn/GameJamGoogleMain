using System;
using System.Collections;
using MainProje.Script.GoogleScript.Controler;
using Script.GoogleScript;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Script.Manager
{
  public enum MusicName : byte
  {
    GamePlay,
  }

  // todo: Zamanı gelince burayı ayarla
  public class AudioManager : Singleton<AudioManager>
  {
    // ==> Components <==
    // ========================================================================================
    private const float VolumeSteps = 0.01f;

    [SerializeField]                 private AudioSource gamePlaySourceMusic;
    [SerializeField] [Range(0f, 1f)] private float       maxMusicVolume;

    [Header("SFX")] [SerializeField] private AudioSource sfxSource;

    [SerializeField] private Slider musicslider;
    [SerializeField] private Slider sfxSldier;

    [SerializeField] private So so;


    [SerializeField] private AudioClip zSound;
    [SerializeField] private AudioClip xSound;
    [SerializeField] private AudioClip cSound;
    [SerializeField] private AudioClip Sonciclip;
    // [SerializeField] private AudioClip cli5;


    [SerializeField] public AudioClip[] dmgClips;
    [SerializeField] public AudioClip[] takeDmgClips;

    // ==> Unity Event Functions <==
    // ========================================================================================
    private void Start()
    {
      // gamePlaySourceMusic.PlayOneShot(); 
      // PlayMusic(MusicName.IntroMenu);


      musicslider.value = so.MusicVoluem;
      gamePlaySourceMusic.volume = so.MusicVoluem;

      sfxSource.volume = so.SoundVoluem;
      sfxSldier.value = so.SoundVoluem;
    }


    private void Update()
    {
      if (Skils.Instance.isPRessZZZ)
      {
        gamePlaySourceMusic.volume = musicslider.value / 3;
        sfxSource.volume = sfxSldier.value / 3;

        so.SoundVoluem = sfxSldier.value / 3;
        so.MusicVoluem = musicslider.value / 3;
      }
      else
      {
        gamePlaySourceMusic.volume = musicslider.value;
        sfxSource.volume = sfxSldier.value;

        so.SoundVoluem = sfxSldier.value;
        so.MusicVoluem = musicslider.value;
      }

      // gamePlaySourceMusic.volume = maxMusicVolume;
    }

    // ==> Main Functions <==
    // ========================================================================================
    private void PlayMusic(MusicName musicToPlay)
    {
      AudioSourceStart(gamePlaySourceMusic, true);
    }

    // -<                                                                             -->  musicToPlay Çaldıgında diger Sourc'ları durdurur
    private void StopMusic(MusicName musicToPlay)
    {
      AudioSourceStop(gamePlaySourceMusic);
    }


#region ==> Public Functions <==
    // =========================================================================

    public void PlaySoundEffect(AudioClip clip, float volume = 1f)
    {
      sfxSource.PlayOneShot(clip, volume);
    }
#endregion

#region ==> Little Functions <==
    // =========================================================================


    private static void VolumeUp(AudioSource audioSource)
    {
      audioSource.volume += VolumeSteps;
    }

    private static void VolumeDown(AudioSource audioSource)
    {
      audioSource.volume -= VolumeSteps;
    }

    private static void AudioSourceStop(AudioSource audioSource)
    {
      audioSource.Stop();
      audioSource.enabled = false;
    }

    // -<                                                                             --> isVolumeStartZero = Muzigin sesi yavaştan açılsın istiyorsan true yap.
    private void AudioSourceStart(AudioSource audioSource,
                                  bool        isVolumeStartZero = false)
    {
      audioSource.enabled = true;
      audioSource.volume = isVolumeStartZero ? 0 : maxMusicVolume;
      audioSource.Play();
    }
#endregion


    public void RandomEfxDamage()
    {
      var random = Random.Range(1, dmgClips.Length);

      float random2 = Random.Range(0.3f, 0.9f);

      var clips = dmgClips[random];

      PlaySoundEffect(clips, random2);
    }

    public void RandomEfxTakdeDmg()
    {
      var random = Random.Range(1, takeDmgClips.Length);

      float random2 = Random.Range(0.3f, 0.9f);


      var clips = takeDmgClips[random];

      PlaySoundEffect(clips, random2);
    }

    public void PlaySondClipt()
    {
      PlaySoundEffect(Sonciclip);
    }


    public void SkiZZZZZ()
    {
      float random2 = Random.Range(0.6f, 0.9f);

      PlaySoundEffect(zSound, random2);
    }

    public void SkillXXXXX()
    {
      float random2 = Random.Range(0.6f, 0.9f);

      PlaySoundEffect(xSound, random2);
    }


    public void SkillCCCCCC()
    {
      float random2 = Random.Range(0.6f, 0.9f);

      PlaySoundEffect(cSound, random2);
    }
  }
}