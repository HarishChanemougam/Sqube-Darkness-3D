using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;
using System.Runtime.InteropServices.WindowsRuntime;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _startHealth;
    [SerializeField] int _maxHealth;
    [SerializeField] GameOver _gameOver;

    int _currentHealth;

    public event UnityAction _onDammage;
    public event UnityAction _onDie;

    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }

    }

    public int HealthProgress
    {
        get
        {
            { return CurrentHealth / _maxHealth; }
        }
    }

    public bool IsDead => CurrentHealth <= 0;

    private void Start()
    {
        _currentHealth = _startHealth;
        Mathf.Max(_currentHealth, 0);
    }

    internal void Dammage()
    {
        _currentHealth--;
        _onDammage?.Invoke();

        if(IsDead)
        {
            _onDie?.Invoke();
            _gameOver.EndGame();
        }
    }

}
