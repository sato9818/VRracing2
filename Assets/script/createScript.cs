using UnityEngine;
using System.Collections;

public class createScript : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    public GameObject green1;
    public GameObject green2;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;


    int border = 1000;
    int enemyBorder = 80;
    int itemBorder = 100;

    void Update()
    {
        if (transform.position.z > border)
        {
            CreateMap();
        }
        if (transform.position.z > enemyBorder)
        {
            CreateEnemy();
        }
        if (transform.position.z > itemBorder)
        {
            CreateItem();
        }
    }

    void CreateMap()
    {
        if (green1.transform.position.z < border)
        {
            border += 2000;
            Vector3 temp = new Vector3(0, 0.05f, border);
            green1.transform.position = temp;
        }
        else if (green2.transform.position.z < border)
        {
            border += 2000;
            Vector3 temp = new Vector3(0, 0.05f, border);
            green2.transform.position = temp;
        }
    }

    void CreateEnemy()
    {
        if (Random.Range(0, 3) == 0)
        {
            Instantiate(enemy1, new Vector3(-5f, 0f, enemyBorder + 250f), enemy1.transform.rotation);
        }
        if (Random.Range(0, 3) == 0)
        {
            Instantiate(enemy2, new Vector3(-1.8f, 0f, enemyBorder + 250f), enemy2.transform.rotation);
        }
        if (Random.Range(0, 3) == 0)
        {
            Instantiate(enemy3, new Vector3(1.8f, 0f, enemyBorder + 250f), enemy3.transform.rotation);
        }
        if (Random.Range(0, 3) == 0)
        {
            Instantiate(enemy4, new Vector3(5f, 0f, enemyBorder + 250f), enemy4.transform.rotation);
        }
        enemyBorder += 80;
    }

    void CreateItem()
    {
        if (Random.Range(0, 3) == 0)
        {
            Instantiate(item1, new Vector3(-5f, 0.5f, itemBorder + 250f), item1.transform.rotation);
        }
        if (Random.Range(0, 3) == 0)
        {
            Instantiate(item2, new Vector3(-1.8f, 0.5f, itemBorder + 250f), item2.transform.rotation);
        }
        if (Random.Range(0, 3) == 0)
        {
            Instantiate(item3, new Vector3(1.8f, 0.5f, itemBorder + 250f), item3.transform.rotation);
        }
        if (Random.Range(0, 3) == 0)
        {
            Instantiate(item4, new Vector3(5f, 0.5f, itemBorder + 250f), item4.transform.rotation);
        }
        itemBorder += 100;
    }
}