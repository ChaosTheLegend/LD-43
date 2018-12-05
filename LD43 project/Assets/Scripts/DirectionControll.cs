using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionControll : MonoBehaviour {

    public enum direction { up, down, left, right };
    public direction Opening;
    // Use this for initialization
    private Templates temp;
    public bool done = false;
    int MaxLengh = 30;
    int MinLengh = 15;

    private void Awake()
    {
        temp = GameObject.FindGameObjectWithTag("Template").GetComponent<Templates>();
    }
    private void Start()
    {
        Invoke("Spawn",0.1f);
    }
    void Spawn()
    {
        if (!done)
        {
            float RNG = Random.Range(0, 100);
            if (GameObject.FindGameObjectsWithTag("Room").Length >= MaxLengh)
            {
                RNG = 100;
            }
                switch (Opening)
            {
                case (direction.up):
                    if (RNG < 45)
                    {
                        Instantiate(temp.UpWay[Random.Range(0, temp.UpWay.Length)], transform.position, transform.rotation);
                    }
                    else if (RNG < 80)
                    {
                        Instantiate(temp.UpCorridors[Random.Range(0, temp.UpCorridors.Length)], transform.position, transform.rotation);
                    }
                    else
                    {
                        Instantiate(temp.UpEnd[Random.Range(0, temp.UpEnd.Length)], transform.position, transform.rotation);
                    }
                    break;
                case (direction.down):
                    if (RNG < 20)
                    {
                        Instantiate(temp.DownWay[Random.Range(0, temp.DownWay.Length)], transform.position, transform.rotation);
                    }
                    else if (RNG < 70)
                    {
                        Instantiate(temp.DownCorridors[Random.Range(0, temp.DownCorridors.Length)], transform.position, transform.rotation);
                    }
                    else
                    {
                        Instantiate(temp.DownEnd[Random.Range(0, temp.DownEnd.Length)], transform.position, transform.rotation);
                    }
                    break;
                case (direction.left):
                    if (RNG < 20)
                    {
                        Instantiate(temp.LeftWay[Random.Range(0, temp.LeftWay.Length)], transform.position, transform.rotation);
                    }
                    else if (RNG < 70)
                    {
                        Instantiate(temp.LeftCorridors[Random.Range(0, temp.LeftCorridors.Length)], transform.position, transform.rotation);
                    }
                    else
                    {
                        Instantiate(temp.LeftEnd[Random.Range(0, temp.LeftEnd.Length)], transform.position, transform.rotation);
                    }
                    break;
                case (direction.right):
                    if (RNG < 20)
                    {
                        Instantiate(temp.RightWay[Random.Range(0, temp.RightWay.Length)], transform.position, transform.rotation);
                    }
                    else if (RNG < 70)
                    {
                        Instantiate(temp.RightCorridors[Random.Range(0, temp.RightCorridors.Length)], transform.position, transform.rotation);
                    }
                    else
                    {
                        Instantiate(temp.RightEnd[Random.Range(0, temp.RightEnd.Length)], transform.position, transform.rotation);
                    }
                    break;

            }
            done = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!done && other.CompareTag("Spawnpoint"))
        {
            if (other.GetComponent<DirectionControll>().done == false)
            {
                Instantiate(temp.Wall, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            done = true;
        }
    }

}
