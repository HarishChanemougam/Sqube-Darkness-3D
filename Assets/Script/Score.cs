using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _initialPosition;
    [SerializeField] TextMeshProUGUI _scoreText;

    private void Update()
    {
        _scoreText.text = (_player.position.z - _initialPosition.position.z).ToString("0");
    }
}
