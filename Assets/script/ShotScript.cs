using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {
	public Transform Item;
    public Transform onItem;

	public void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Button")
		{
			if(TextScript.ItemNum >= 1){
				shot();
				TextScript.ItemNum--;
			}
			
		}

    }
	
	public void shot()
    {
        Instantiate (Item, onItem.position , Item.transform.rotation);
        Rigidbody rb;
        rb = Item.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 400000);
    }
}
