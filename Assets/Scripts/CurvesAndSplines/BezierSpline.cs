//============================================
//
//    Author: zhudianyu
//
//    2017-09-20 15:36:38Z
//
//============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BezierSpline : MonoBehaviour
{

    public Vector3[] points;

    public int CurveCount
    {
        get
        {
            return (points.Length - 1) / 3;
        }
    }
    public Vector3 GetPoint(float t)
    {
        int i;
        if(t >= 1)
        {
            t = 1;
            i = points.Length - 4;
        }
        else
        {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }
        return transform.TransformPoint(Bezier.GetPoint(points[i], points[i+1], points[i+2], points[i+3], t));
    }

    public Vector3 GetVelocity(float t)
    {
        int i;
        if (t >= 1)
        {
            t = 1;
            i = points.Length - 4;
        }
        else
        {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }
        return transform.TransformPoint(
            Bezier.GetFirstDerivative(points[i], points[i+1], points[i+2], points[i+3], t)) - transform.position;
    }

    public Vector3 GetDirection(float t)
    {
        return GetVelocity(t).normalized;
    }

    public void Reset()
    {
        points = new Vector3[] 
        {
			new Vector3(1f, 0f, 0f),
			new Vector3(2f, 0f, 0f),
			new Vector3(3f, 0f, 0f),
			new Vector3(4f, 0f, 0f)
		};
    }

    public void AddCurve()
    {
        Vector3 pt = points[points.Length - 1];
        Array.Resize(ref points, points.Length + 3);
        pt.x += 1;
        points[points.Length - 3] = pt;
        pt.x += 1;
        points[points.Length - 2] = pt;
        pt.x += 1;
        points[points.Length - 1] = pt;
    }
}
