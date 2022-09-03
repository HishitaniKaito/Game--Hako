using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] GameObject pos;
    [SerializeField] Player P = null;
    public void OnCollisionEnter(Collision collision)
    {
        P.worp(pos.transform.position);


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
