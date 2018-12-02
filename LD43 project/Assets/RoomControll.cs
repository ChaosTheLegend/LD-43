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
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            var Pcollider = player.GetComponent<Collider2D>();
            var Pbounds = Pcollider.bounds;
            Pbounds.size *= 0.99999f;
            if (bounds.Intersects(Pbounds))
            {
                State = RoomState.active;
            }

            Doors.transform.GetComponent<DoorControll>().open = true;
        }
        if (State == RoomState.active)
        {
            if (Enemies.transform.childCount == 0)
            {
                State = RoomState.cleared;
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
