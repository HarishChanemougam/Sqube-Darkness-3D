using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    internal float speed;
    [SerializeField] float _speed;
    [SerializeField] float _lifeTime;
    [SerializeField] int _damageToGive;

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        _lifeTime -= Time.deltaTime;

        if(_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        collision.gameObject.GetComponent<PlayerHealth>().HurtEnmey(_damageToGive);
        Destroy(gameObject);
        }
    }
}
