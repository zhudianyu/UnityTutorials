
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

public static class Bezier
{
    public static Vector3 GetPoint(Vector3 p0,Vector3 p1,Vector3 p2,float t)
    {
        return Vector3.Lerp(Vector3.Lerp(p0,p1,t), Vector3.Lerp(p1,p2,t), t);
    }
}
