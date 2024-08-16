using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleStats : MonoBehaviour
{

    [SerializeField] public float scale = 1.0f;
    [SerializeField] public float mass = 1.0f;
    [SerializeField] public string marbleName = "Add Name Here";
    [SerializeField] public  Material defaultMaterial;


    private GameObject obj;
    private Vector3 offset;
    private Vector3 scale_vector;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        float scale_offset = ((scale - 1.0f) * 0.3f) / 2;
        //Debug.Log(scale_offset);
        if (scale_offset != 0.0f)
        {
            offset = new Vector3(0,scale_offset,0);

            float scaled = scale * obj.transform.localScale.x;
            scale_vector = new Vector3(scaled,scaled,scaled);

            var pos_obj = obj.transform.position;
            obj.transform.position = pos_obj + offset;

            obj.transform.localScale = scale_vector;
        }
    }
}
