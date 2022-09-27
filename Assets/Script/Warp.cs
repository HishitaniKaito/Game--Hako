using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] GameObject pos;
    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = pos.transform.position;
    }

}
