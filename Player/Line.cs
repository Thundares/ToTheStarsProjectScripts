using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer lineRenderer = null;
    private Transform target = null;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (VariablesManager.eTarget == Target.right) 
        {
            //Debug.Log("$$$$$$$$$$$$$$$$");
            VariablesManager.eTarget = Target.none;
            target = GameObject.FindGameObjectWithTag("target").transform;
            lineRenderer.SetPosition(0, (target.position - this.transform.position)/2);
            lineRenderer.SetPosition(1, Vector3.zero);
            StartCoroutine(ThrowLine());
        }
    }

    IEnumerator ThrowLine() 
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.3f);
        lineRenderer.enabled = false;
        yield return null;
    }
}
