using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoloutionControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void newRes(int x, int y, bool full)
    {
        Screen.SetResolution(x,y, full);
    }
}
