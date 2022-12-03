using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    [SerializeField] GameObject door;
    // Start is called before the first frame update
    [SerializeField] GameObject maintransform;
    [SerializeField] GameObject point;
    float timer;
    public bool doordelete = false;
    
    private void Start()
    {
        maintransform.transform.position = point.transform.position;
        maintransform.transform.rotation = point.transform.rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //door.active = false;
       // this.gameObject.active = false;
        timer = 0;
        doordelete = true;
    }
    private void Update()
    {
        
        if(doordelete)
        {
            maintransform.transform.position = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z - 3);
            maintransform.transform.rotation = door.transform.rotation;
            timer += Time.deltaTime;

            if (timer > 1.0f && gameObject.active)
            {
                door.active = false;
                //this.gameObject.active = false;
                timer = 0;

            }else if(timer > 0.5f && door.active == false)
            {
                maintransform.transform.position = point.transform.position;
                maintransform.transform.rotation = point.transform.rotation;
                doordelete = false;
                this.gameObject.active = false;
            }
        }
    }
}
