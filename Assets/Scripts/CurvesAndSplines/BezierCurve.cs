using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{

    public Vector3[] points;

    public void Reset()
    {
        points = new Vector3[]
        {
            new Vector3(1f,0f,0f),
            new Vector3(2f,0f,0f),
            new Vector3(3f,0f,0f),
            new Vector3(4f,0f,0f)
        };
    }
    public Vector3 GetPoint(float t)
    {
        return transform.TransformPoint(Bezier.GetPoint(points[0], points[1], points[2], points[3], t));
    }
    /// <summary>
    /// 获取切线 因为是一个速度向量不是一个点 所以不应该收到位置的影响 所以我们在转换后相减
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public Vector3 GetVelocity(float t)
    {
        return transform.TransformPoint(Bezier.GetFirstDerivative(points[0], points[1], points[2], points[3], t)) - transform.position;
    }

    public Vector3 GetDirection(float t)
    {
        return GetVelocity(t).normalized;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
