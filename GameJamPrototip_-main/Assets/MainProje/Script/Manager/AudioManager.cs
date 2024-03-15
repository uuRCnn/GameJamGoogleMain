using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Manager
{
  public enum MusicName : byte
  {
    IntroMenu,
    Lobi,
    GamePlay,
    EndGame
  }

  // todo: Zamanı gelince burayı ayarla
  public class AudioManager : Singleton<AudioManager>
  {
    // ==> Components <==
    // ========================================================================================
    private const float VolumeSteps = 0.01f;

    [Header("Music")] [SerializeField] private AudioSource introMenuSource;
    [SerializeField]                   private AudioSource lobiSource;
    [SerializeField]                   private AudioSource gamePlaySource;
    [SerializeField]                   private AudioSource endGameSource;
    [SerializeField] [Range(0f, 1f)]   private float       maxMusicVolume;

    [Header("SFX")] [SerializeField] private AudioSource sfxSource;

    [SerializeField] private Slider musicslider;

    // ==> Unity Event Functions <==
    // ========================================================================================
    private void Start()
    {
      introMenuSource.PlayOneShot(introMenuSource.clip);
      // PlayMusic(MusicName.IntroMenu);
    }


    private void Update()
    {
      introMenuSource.volume = musicslider.value;
    }

    // ==> Main Functions <==
    // ========================================================================================
    private void PlayMusic(MusicName musicToPlay)
    {
      switch (musicToPlay)
      {
        case MusicName.IntroMenu:
          AudioSourceStart(introMenuSource, true);
          break;
        case MusicName.Lobi:
          AudioSourceStart(lobiSource, true);
          break;
        case MusicName.GamePlay:
          AudioSourceStart(gamePlaySource, true);
          break;
        case MusicName.EndGame:
          AudioSourceStart(endGameSource, true);
          break;
        default:
          throw new ArgumentOutOfRangeException(
            nameof(musicToPlay), musicToPlay, null);
      }
    }

    // -<                                                                             -->  musicToPlay Çaldıgında diger Sourc'ları durdurur
    private void StopMusic(MusicName musicToPlay)
    {
      switch (musicToPlay)
      {
        case MusicName.IntroMenu:
          AudioSourceStop(lobiSource);
          AudioSourceStop(gamePlaySource);
          AudioSourceStop(endGameSource);
          break;
        case MusicName.Lobi:
          AudioSourceStop(introMenuSource);
          break;
        case MusicName.GamePlay:
          AudioSourceStop(introMenuSource);
          break;
        case MusicName.EndGame:
          AudioSourceStop(gamePlaySource);
          break;
        default:
          throw new ArgumentOutOfRangeException(
            nameof(musicToPlay), musicToPlay, null);
      }
    }

    private IEnumerator FadeInMusicToPlayFadeOutCurrentMusic(
      MusicName musicToPlay)
    {
      var volume = 0f;

      // -<                                                                           -->  Repeat until the volume go up to the max
      while (volume <= maxMusicVolume)
      {
        switch (musicToPlay)
        {
          case MusicName.IntroMenu:
            VolumeUp(introMenuSource);

            VolumeDown(lobiSource);
            VolumeDown(gamePlaySource);
            VolumeDown(endGameSource);
            break;
          case MusicName.Lobi:
            VolumeUp(lobiSource);
            VolumeDown(introMenuSource);
            break;
          case MusicName.GamePlay:
            VolumeUp(gamePlaySource);
            VolumeDown(lobiSource);
            break;
          case MusicName.EndGame:
            VolumeUp(endGameSource);
            VolumeDown(gamePlaySource);
            break;
          default:
            throw new ArgumentOutOfRangeException(
              nameof(musicToPlay), musicToPlay, null);
        }

        volume += VolumeSteps;
        yield return new WaitForEndOfFrame();
      }
    }

#region ==> Public Functions <==
    // =========================================================================

    public void PlaySoundEffect(AudioClip clip, float volume = 1f)
    {
      sfxSource.PlayOneShot(clip, volume);
    }

    // -<                                                                             -->  Müzigi değiştirir
    public void SwitchMusicToPlay(MusicName musicName)
    {
      PlayMusic(musicName);
      StartCoroutine(SwitchToMusic(musicName));
    }
#endregion

#region ==> Little Functions <==
    // =========================================================================

    private IEnumerator SwitchToMusic(MusicName musicToPlay)
    {
      //                                                                              -->  (bu fonkisyon bitince alttakine geçer)
      yield return FadeInMusicToPlayFadeOutCurrentMusic(musicToPlay);

      StopAudioOfCurrentMusic(musicToPlay);
    }


    private void StopAudioOfCurrentMusic(MusicName musicToPlay)
    {
      StopMusic(musicToPlay);
    }

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
  }
}