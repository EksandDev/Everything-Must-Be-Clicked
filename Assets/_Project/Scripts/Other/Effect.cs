using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(ParticleSystem))]
public class Effect : MonoBehaviour
{
    [SerializeField] private float _timeToDeactivate;
    [SerializeField] private AudioClip _hitSound;

    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        StartCoroutine(Deactivate());

        _particleSystem.Play();
        _audioSource.PlayOneShot(_hitSound);
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(_timeToDeactivate);

        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }
}
