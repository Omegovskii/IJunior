using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private Coroutine _activeCoroutine;
    private float _recoveryRate = 0.3f;
    private float _requiredVolume;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    public void PlaySound()
    {
        _requiredVolume = _maxVolume;

        if(_audio.volume == 0)
        {
            _audio.Play();
        }

        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    public void StopSound()
    {
        _requiredVolume = _minVolume;
        StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private void Start()
    {
        _audio.volume = 0;
    }

    private IEnumerator ChangeVolume()
    {
        while (_audio.volume != _requiredVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _requiredVolume, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}
