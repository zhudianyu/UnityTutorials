
//*************************************************************************
//	创建日期:	2017/9/20 星期三 9:23:48
//	文件名称:	Bezier
//   创 建 人:   zhudianyu	
//	版权所有:	zhudianyu
//	说    明:	
//*************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/*
 线性公式
给定点P0、P1，线性贝兹曲线只是一条两点之间的直线。这条线由下式给出：
B(t) = (1 - t) P0 + t P1.
且其等同于线性插值。
二次方公式
二次方贝兹曲线的路径由给定点P0、P1、P2的函数B（t）追踪：
 B(t) = (1 - t) ((1 - t) P0 + t P1) + t ((1 - t) P1 + t P2)
TrueType字型就运用了以贝兹样条组成的二次贝兹曲线。
三次方公式
P0、P1、P2、P3四个点在平面或在三维空间中定义了三次方贝兹曲线。曲线起始于P0走向P1，并从P2的方向来到P3。一般不会经过P1或P2；这两个点只是在那里提供方向资讯。P0和P1之间的间距，
 * 决定了曲线在转而趋进P3之前，走向P2方向的“长度有多长”。
曲线的参数形式为：
 B(t) = (1 - t)2 P0 + 2 (1 - t) t P1 + t2 P2.
现代的成象系统，如PostScript、Asymptote和Metafont，运用了以贝兹样条组成的三次贝兹曲线，用来描绘曲线轮廓。
 */
public static class Bezier
{
    public static Vector3 GetPoint(Vector3 p0,Vector3 p1,Vector3 p2,float t)
    {
        //return Vector3.Lerp(Vector3.Lerp(p0,p1,t), Vector3.Lerp(p1,p2,t), t);
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        // B(t) = (1 - t) ((1 - t) P0 + t P1) + t ((1 - t) P1 + t P2)
        return oneMinusT * oneMinusT * p0 + 2f * oneMinusT * t * p1 + t * t * p2;
    }

    public static Vector3 GetFirstDerivative(Vector3 p0,Vector3 p1,Vector3 p2,float t)
    {
        return 2f * (1 - t) * (p1 - p0) + 2f * t * (p2 - p1);
    }
    /*
     The consolidated function of that becomes B(t) = (1 - t)3 P0 + 3 (1 - t)2 t P1 + 3 (1 - t) t2 P2 + t3 P3 
     * which has as its first derivative B'(t) = 3 (1 - t)2 (P1 - P0) + 6 (1 - t) t (P2 - P1) + 3 t2 (P3 - P2).
     */
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            oneMinusT * oneMinusT * oneMinusT * p0 +
            3f * oneMinusT * oneMinusT * t * p1 +
            3f * oneMinusT * t * t * p2 +
            t * t * t * p3;
    }

    public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            3f * oneMinusT * oneMinusT * (p1 - p0) +
            6f * oneMinusT * t * (p2 - p1) +
            3f * t * t * (p3 - p2);
    }
}
