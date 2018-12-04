using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControll : MonoBehaviour {

    public enum RoomState {inactive, active, cleared}
    public RoomState State;
    public GameObject Doors;
    public GameObject Enemies;
    public GameObject Layout;
    Bounds bnd;


    void Update () {
        if (State == RoomState.inactive)
        {
            var collider = Layout.GetComponent<CompositeCollider2D>();
            var bounds = collider.bounds;
            bounds.size *= 0.89f;
            bnd = bounds;
            bnd.center = transform.position;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            var Pcollider = player.GetComponent<Collider2D>();
            var Pbounds = Pcollider.bounds;
            Pbounds.size *= 0.99999f;
            Pbounds.center = player.transform.position;

            if (bounds.Intersects(Pbounds))
            {
                State = RoomState.active;
            }

            Doors.transform.GetComponent<DoorControll>().open = true;
        }
        if (State == RoomState.active)
        {
            try
            {

                if (GameObject.FindGameObjectWithTag("Boss").transform.GetChild(1).name == "BossHead" && GameObject.FindGameObjectWithTag("Boss").transform.parent == transform)
                {
                    GameObject.FindGameObjectWithTag("Boss").transform.GetChild(1).GetComponent<BossControll>().active = true;
                    Doors.transform.GetComponent<DoorControll>().open = false;
                    return;
                }
            else if (GameObject.FindGameObjectWithTag("Boss").transform.GetChild(1).name != "BossHead")
            {
                State = RoomState.cleared;
            }
            }
            catch { }

            if (Enemies.transform.childCount == 0)
            {
                State = RoomState.cleared;
            }
            else
            {
                GameObject[] enemies = new GameObject[Enemies.transform.childCount];
                for (int i = 0; i < Enemies.transform.childCount; i++)
                {
                    enemies[i] = Enemies.transform.GetChild(i).gameObject;
                    enemies[i].GetComponent<EnemyMovement>().active = true;
                }
            }
            Doors.transform.GetComponent<DoorControll>().open = false;
        }

        if (State == RoomState.cleared)
        {
            Doors.transform.GetComponent<DoorControll>().open = true;
        }



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(bnd.center,bnd.size);
    }
}
