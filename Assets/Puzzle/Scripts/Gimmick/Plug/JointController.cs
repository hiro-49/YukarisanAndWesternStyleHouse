using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointController : MonoBehaviour
{
    LineRenderer line;
    SpringJoint2D springJoint;
    GameObject connectionObj;

    public void Init(GameObject obj)
    {
        line = GetComponent<LineRenderer>();
        springJoint = GetComponent<SpringJoint2D>();
        connectionObj = obj;
        springJoint.connectedBody = connectionObj.GetComponent<Rigidbody2D>();
        StartCoroutine(FrequencyEdit());
        //ラインの設定
        line.positionCount = 2;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startWidth = 10f;
        line.endWidth = 10f;
        line.startColor = Color.black;
        line.endColor = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (connectionObj != null) DrawLine();
    }

    void DrawLine()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, connectionObj.transform.position);
    }

    IEnumerator FrequencyEdit()
    {
        springJoint.frequency = 0.2f;
        yield return new WaitForSeconds(0.5f);
        springJoint.frequency = 0.5f;
        yield return new WaitForSeconds(0.5f);
        springJoint.frequency = 0.8f;
    }
}
