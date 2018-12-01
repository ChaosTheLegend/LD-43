using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2 : MonoBehaviour {

    public Transform start;
    public Transform[] end;
    public int[] exitdir;

    [HideInInspector]
    public Vector3 dis;
    [HideInInspector]
    public Vector3 center;

    // Use this for initialization
    void Awake()
    {
        if (start != null)
            dis = start.position - transform.position;
        center = GetComponent<CompositeCollider2D>().bounds.center;
    }
    private void Start()
    {
        transform.position = transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (start)
            Gizmos.DrawSphere(start.position, 0.5f);
        Gizmos.color = Color.red;
        foreach (Transform _end in end)
        {
            if (_end)
                Gizmos.DrawSphere(_end.position, 0.5f);
        }
    }
}
