using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControll : MonoBehaviour {

    public bool active;
    public float health;
    public float speed;
    public GameObject Head;
    public List<GameObject> Body;
    public GameObject Tail;

    public GameObject BodyPrefab;
    public GameObject TailPreefab;

    public float HitCooldown;
    float CD;
    public Transform path;
    public GameObject projectile;
    public List<Vector3> VisitedPoints;
    public float TimeDelay;
    float tm;
    public int length;
    public float DelayBetweenAttacks;
    float AtkDelay;
    Vector3 dis = Vector3.zero;
    public bool dead = false;
    public float DieTimer;
    float dietm;


    private Transform target;

    public Transform[] ShootingPoints;
    public Transform[] PathPool;
    int CurrentPoint;
    public int attack;
    // Use this for initialization
    void Start () {
        attack = 0;
        for (int i = 0; i < length-2; i++)
        {
            Body.Add(Instantiate(BodyPrefab, transform.position, transform.rotation));
        }
        Tail = Instantiate(TailPreefab, transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        if (tm <= 0)
        {
            tm = TimeDelay;
            VisitedPoints.Add(transform.position);
            
            if (VisitedPoints.Count > 50)
            {
                VisitedPoints.RemoveAt(0);
            }
            
        }

        else
        {
            tm -= Time.deltaTime;
        }

        if (dead)
        {
            if (dietm > 0)
            {
                dietm -= Time.deltaTime;
            }
            die();
            active = false;
        }


        if (active)
        {
            if (AtkDelay <= 0)
            {
                AtkDelay = DelayBetweenAttacks;
                attack = 2;
            }
            else
            {
                AtkDelay -= Time.deltaTime;
            }

            if (CD > 0)
            {
                CD -= Time.deltaTime;
            }


            for (int i = 0; i < Body.Count + 1; i++)
            {
                if (i == Body.Count)
                {
                    if (Vector3.Distance(VisitedPoints[VisitedPoints.Count - i - 1], Tail.transform.position) >= 0.2f)
                    {
                        Tail.transform.Translate((VisitedPoints[VisitedPoints.Count - i - 1] - Tail.transform.position).normalized * speed * Time.deltaTime);
                    }
                    GameObject Timage = Tail.transform.GetChild(0).gameObject;
                    Vector3 tdis = VisitedPoints[VisitedPoints.Count - i - 1] - Timage.transform.position;
                    float tangle = Mathf.Atan2(tdis.y, tdis.x) * Mathf.Rad2Deg;

                    if (tangle > 90 || tangle < -90)
                    {
                        tangle -= 180;
                        Timage.transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        Timage.transform.localScale = new Vector3(1, 1, 1);
                    }
                    Timage.transform.rotation = Quaternion.Euler(0, 0, tangle);
                }
                else
                {
                    if (Vector3.Distance(VisitedPoints[VisitedPoints.Count - i - 1],Body[i].transform.position) >= 0.2f)
                    {
                        Body[i].transform.Translate((VisitedPoints[VisitedPoints.Count - i - 1] - Body[i].transform.position).normalized * speed * Time.deltaTime);
                    }
                    GameObject Bimage = Body[i].transform.GetChild(0).gameObject;
                    Vector3 tdis = VisitedPoints[VisitedPoints.Count - i - 1] - Bimage.transform.position;
                    float tangle = Mathf.Atan2(tdis.y, tdis.x) * Mathf.Rad2Deg;

                    if (tangle > 90 || tangle < -90)
                    {
                        tangle -= 180;
                        Bimage.transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        Bimage.transform.localScale = new Vector3(1, 1, 1);
                    }
                    Bimage.transform.rotation = Quaternion.Euler(0, 0, tangle);
                    
                }
            }

            switch (attack)
            {
                case (0):
                    TracePath(PathPool[0]);
                    break;
                case (1):
                    TracePath(PathPool[1]);
                    break;
                case (2):
                    Shoot();
                    attack = Random.Range(0, 2);
                    break;
            }
            //rotate head
            
            if (target != null)
            {
                dis = target.position - transform.position;
            }
            float angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
           
            if (angle > 90 || angle < -90)
            {
                angle -= 180;
                Head.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                Head.transform.localScale = new Vector3(1, 1, 1);
            }
            Head.transform.rotation = Quaternion.Euler(0, 0, angle);




        }
	}
    void Shoot()
    {
        foreach (Transform point in ShootingPoints)
        {
            Instantiate(projectile, point.position, point.rotation);
        }
    }


    void TracePath(Transform Path)
    {
        path = Path;
        if (target == null)
        {
            CurrentPoint = 0;
            target = path.GetComponent<PathControll>().points[CurrentPoint];
        }


        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            CurrentPoint++;
            if (CurrentPoint > path.GetComponent<PathControll>().points.Length-1)
            {
                CurrentPoint = 0;
                dead = true;
                active = false;
            }
        }

        target = path.GetComponent<PathControll>().points[CurrentPoint];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HitBox") && CD <= 0)
        {
            health -= other.GetComponent<HitboxControll>().Damage;
            CD = HitCooldown;
            if (health <= 0)
            {

            }
        }
    }

    void die()
    {
        if (dietm <= 0)
        {
            dietm = DieTimer;
            if (Tail != null)
            {
                Destroy(Tail);
                return;
            }
            if (Body.Count > 0)
            {
                Destroy(Body[Body.Count-1]);
                Body.RemoveAt(Body.Count - 1);
                return;
            }
            Destroy(gameObject);
            
        }
    }
}
