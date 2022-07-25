using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExSix
{
    public class SignaligTrigger : MonoBehaviour
    {
        [SerializeField] private AudioSource _audio;

        private bool _isInHouse;
        private float _currentVolume;
        private float _maxVolume = 1;
        private float _minVolume = 0;
        private float _deltaVolume;

        private void Update()
        {
            _currentVolume = _audio.volume;
            _deltaVolume = Time.deltaTime / 5;

            if (_isInHouse)
            {
                _audio.volume = Mathf.MoveTowards(_currentVolume, _maxVolume, _deltaVolume);
            }
            else
            {
                _audio.volume = Mathf.MoveTowards(_currentVolume, _minVolume, _deltaVolume);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _audio.Play();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            _isInHouse = true;      
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _isInHouse = false;
        }
    }
}
