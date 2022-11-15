using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Bullet _bullet;

    private void Start()
    {
        Bullet bulletCopy = Instantiate<Bullet>(_bullet);
    }
}
