using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;

    private AudioSource _audio;

    public AudioClip HitSound { get => hitSound; }

    public void Play(AudioClip clip) => _audio.PlayOneShot(clip);

    public void Play(AudioClip clip, AudioSource source) => source.PlayOneShot(clip);

    public void Play(AudioClip clip, float pitch)
    {
        var clampedPitch = Mathf.Clamp(pitch, 0.1f, 3);
        _audio.PlayOneShot(clip, clampedPitch);
    }

    public void Play(AudioClip clip, float pitch, AudioSource source)
    {
        var clampedPitch = Mathf.Clamp(pitch, 0.1f, 3);
        source.PlayOneShot(clip, clampedPitch);
    }

    public void PlayWithRandomPitch(AudioClip clip, float minPitch, float maxPitch)
    {
        var clampedMinPitch = Mathf.Clamp(minPitch, 0.1f, 3);
        var clampedMaxPitch = Mathf.Clamp(maxPitch, 0.1f, 3);

        if (clampedMinPitch > clampedMaxPitch)
        {
            Debug.LogError("Min pitch is over max pitch");
            return;
        }

        var randomPitch = Random.Range(minPitch, maxPitch);
        _audio.PlayOneShot(clip, randomPitch);
    }

    public void PlayWithRandomPitch(AudioClip clip, float minPitch, float maxPitch, AudioSource source)
    {
        var clampedMinPitch = Mathf.Clamp(minPitch, 0.1f, 3);
        var clampedMaxPitch = Mathf.Clamp(maxPitch, 0.1f, 3);

        if (clampedMinPitch > clampedMaxPitch)
        {
            Debug.LogError("Min pitch is over max pitch");
            return;
        }

        var randomPitch = Random.Range(minPitch, maxPitch);
        source.PlayOneShot(clip, randomPitch);
    }

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
}
