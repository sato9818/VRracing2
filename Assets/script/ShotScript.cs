using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {
	public Transform Item;
    public Transform onItem;

	public GameObject parentObject;
	Transform Obj;

	void Start()
	{
		parentObject = GameObject.FindGameObjectWithTag("Button");
	}

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
        Obj = (Transform)Instantiate (Item, onItem.position , Quaternion.identity);
		Obj.transform.parent = parentObject.transform;
    }
}
