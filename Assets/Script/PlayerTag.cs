using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerTag : MonoBehaviour
{
    #region Singleton
    public static PlayerTag instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] public GameObject player;
    internal float magnitude;
}
