using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour {

	public GameObject timeText;
    public GameObject scoreText;
	public GameObject GameOverText;
    private float time = 60f;
    private float score = 0.0f;
    private float miss = 0.0f;
    public static int ItemNum = 1;
    void Start() {
        timeText.GetComponent<TextMesh>().text = ((int)time).ToString();
        scoreText.GetComponent<TextMesh>().text = ((int)score).ToString();
    }

    void Update(){
        time -= 1f * Time.deltaTime;
        timeText.GetComponent<TextMesh>().text = ((int)time).ToString();;

        float z;
        z = transform.position.z;
        z -= miss;
        score = z;
        scoreText.GetComponent<TextMesh>().text = "score:"+((int)score).ToString();

		if(time<0.0f){
			GameOver();
		}
    }

	void GameOver ()
	{
		GameOverText.GetComponent<TextMesh>().text = "GameOver!";
		Time.timeScale = 0;
	}

    

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ItemBox")
        {
            //Item.position = onItem.position;
            ItemNum += 1;
            Destroy(col.gameObject);
            
        }else if(col.gameObject.tag == "Enemy")
        {
            miss += 1000f;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            miss += 500f;
        }
    }
}
