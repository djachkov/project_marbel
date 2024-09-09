using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleCleaning : MonoBehaviour
{
    [SerializeField] private GameObject[] rubbleParts;
    private float lastCleaningTime;    // stores the last time the rubbles were cleaned
    [SerializeField] float timeInterval = 3.0f;   // The time interval between cleanings


    // Start is called before the first frame update
    void Start()
    {
        lastCleaningTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastCleaningTime >= timeInterval)
        {
            CleanRubbles();
            lastCleaningTime = Time.time;
        }
    }

    void CleanRubbles()
    {
        rubbleParts = GameObject.FindGameObjectsWithTag("Building Parts");
        
        foreach (var part in rubbleParts)
        {
            var partRB = part.GetComponent<Rigidbody>();
            if (partRB.velocity == Vector3.zero && partRB.angularVelocity == Vector3.zero)
            {
                Destroy(part);
            }
        }
    }
}
