using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sketcher : MonoBehaviour
{

    public Material paintColor;
    public List<Vector3> thePath;
    public GameObject cursor;
    public bool drawing;
    public LineRenderer lr;


    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startDrawing()
    {
        drawing = true;
        lr.enabled = true;
        StartCoroutine(draw());
    }

    public void stopDrawing()
    {
        drawing = false;
    }

    IEnumerator draw()
    {
        while (drawing)
        {
            //only draw another segment if we've moved 0.15f from last point
            if (thePath.Count == 0 || (cursor.transform.position - thePath[thePath.Count - 1]).sqrMagnitude > 0.0015f)
            {
                //append a point to our array
                thePath.Add(cursor.transform.position);
                //have the line renderer automatically include it in the drawn path
                lr.SetVertexCount(thePath.Count);
                lr.SetPosition(thePath.Count - 1, thePath[thePath.Count - 1]);
            }
            yield return null;
        }
    }


}
