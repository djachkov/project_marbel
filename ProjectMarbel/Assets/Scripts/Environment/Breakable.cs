using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject _replacement;
    [SerializeField] private float _breakForce = 2;
    [SerializeField] private float _collisionMultiplier = 50;
    [SerializeField] private bool _broken;

    //[SerializeField] private AudioClip _explosion;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision collision)
    {
        if (_broken) return;
        if (collision.collider.CompareTag("Player_1") || collision.collider.CompareTag("Player_2") || collision.collider.CompareTag("CannonBall"))
        {
            if (collision.relativeVelocity.magnitude >= _breakForce)
            {
                _broken = true;
                var replacement = Instantiate(_replacement, transform.position, transform.rotation);

                var rbs = replacement.GetComponentsInChildren<Rigidbody>();
                foreach (var rb in rbs)
                {
                    rb.AddExplosionForce(collision.relativeVelocity.magnitude * _collisionMultiplier, collision.contacts[0].point, 2);
                }

                //AudioSource.PlayClipAtPoint(_explosion,transform.position);
                Destroy(gameObject);
            }
        }
    }
}
