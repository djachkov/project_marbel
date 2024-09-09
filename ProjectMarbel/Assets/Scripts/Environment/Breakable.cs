using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject _replacement;
    [SerializeField] private float _breakForce = 2;
    [SerializeField] private float _collisionMultiplier = 50;
    [SerializeField] private bool _broken;
    private string buildingSmall = "building_small_broken";
    private string buildingMedium = "building_medium_broken";
    private string buildingBig = "building_big_broken";
    private string buildingHuge = "building_huge_broken";

    //[SerializeField] private AudioClip _explosion;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int Score(Collision collision)
    {
        GameObject building = _replacement;
        string name = building.name;
        Debug.Log("Score: " + name);
        if (name == buildingSmall)
            return 10;
        else if (name == buildingMedium)
            return 15;
        else if (name == buildingBig)
            return 25;
        else if (name == buildingHuge)
            return 50;
        return 0;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (_broken) return;
        int player = 0;
        if (collision.collider.CompareTag("Player_1"))
        {
            player = 1;
        }
        else if (collision.collider.CompareTag("Player_2"))
        {
            player = 2;
        }
        if (player > 0 || collision.collider.CompareTag("CannonBall"))
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
                if (player > 0)
                {
                    int score = Score(collision);
                    PersistentDataManager.Instance.AddScore(player, score);
                }
            }
        }
    }
}
