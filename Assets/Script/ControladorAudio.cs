using UnityEngine;
using UnityEngine.Audio;

public class ControladorAudio : MonoBehaviour
{
    public static ControladorAudio _CA;

    [Header("=== FX Menu ===")]
    public AudioClip fxSelect;
    public AudioClip fxBack;
    public AudioClip fxConfirm;

    [Header("=== FX Ambiente ===")]
    public AudioClip vento;
    public AudioClip chuva;

    [Header("=== FX Player ===")]
    public AudioClip passo;
    public AudioClip ataque;
    public AudioClip dano;

    [Header("=== FX Músicas ===")]
    public AudioClip musicaMenu;
    public AudioClip musicaGameplay;

    private AudioSource fxSource;
    private AudioSource musicSource;

    void Awake()
    {
        if (_CA != null && _CA != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _CA = this;
            DontDestroyOnLoad(gameObject); // persiste entre cenas
        }

        fxSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
    }

    // FX únicos
    public void TocarFX(AudioClip clip)
    {
        if (clip != null)
            fxSource.PlayOneShot(clip);
    }

    // Músicas (com transição suave opcional)
    public void TocarMusica(AudioClip novaMusica, float fadeTime = 1f)
    {
        StopAllCoroutines();
        StartCoroutine(FadeMusic(novaMusica, fadeTime));
    }

    private System.Collections.IEnumerator FadeMusic(AudioClip novaMusica, float fadeTime)
    {
        float startVolume = musicSource.volume;

        // Fade out
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0, t / fadeTime);
            yield return null;
        }

        musicSource.Stop();
        musicSource.clip = novaMusica;
        musicSource.Play();

        // Fade in
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(0, startVolume, t / fadeTime);
            yield return null;
        }

        musicSource.volume = startVolume;
    }

    public void PararMusica()
    {
        musicSource.Stop();
    }
}
