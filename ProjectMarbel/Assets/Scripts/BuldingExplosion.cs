using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class BuldingExplosion : MonoBehaviour
{
    GameObject[] buildingParts;
    Rigidbody[] rb;
    
    // Start is called before the first frame update
    void Start()
    {
        buildingParts = GameObject.FindGameObjectsWithTag("Building Parts");
        // Useless Dmitrii's comment in here!
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void oncollisionenter (collision collision)
    //{
      //  if (collision.collider.comparetag("player"))
        //{
         //   foreach 
      //  }
    //}
}
