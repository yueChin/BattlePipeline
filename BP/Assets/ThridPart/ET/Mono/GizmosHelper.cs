using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    public static class GizmosHelper
    {
        public static void DrawCircle(Transform transform, Color m_Color, Vector3 center, float delta, float radius)
        {
            if (delta < 0.01f) delta = 0.01f;
            // 设置矩阵
            Matrix4x4 defaultMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;

            // 设置颜色
            Color defaultColor = Gizmos.color;
            Gizmos.color = m_Color;

            // Debug.Log(center.x + "  " + center.y + "  " + center.z);

            // 绘制圆环
            Vector3 beginPoint = Vector3.zero;
            Vector3 firstPoint = Vector3.zero;
            for (float theta = -Mathf.PI; theta <= Mathf.PI; theta += delta)
            {
                float x = radius * Mathf.Cos(theta);
                float z = radius * Mathf.Sin(theta);
                //if (x < 0 || z < 0)
                //{
                //    Debug.Log("x "+ x);
                //    Debug.Log("z " + z);
                //}
                Vector3 endPoint = new Vector3(x, center.y, z);
                if (firstPoint == Vector3.zero)
                {
                    firstPoint = endPoint;
                }
                else
                {
                    Gizmos.DrawLine(beginPoint, endPoint);
                }
                beginPoint = endPoint;
            }

            // 绘制最后一条线段
            Gizmos.DrawLine(firstPoint, beginPoint);

            // 恢复默认颜色
            Gizmos.color = defaultColor;

            // 恢复默认矩阵
            Gizmos.matrix = defaultMatrix;
        }

        public static void DrawCylinder(Transform transform,Color m_Color, float radius)
        {
            var v3 = new Vector3(0, 3, 0);
            GizmosHelper.DrawCircle(transform, m_Color, -v3, 0.2f, radius);
            GizmosHelper.DrawCircle(transform, m_Color, v3, 0.2f, radius);
            // 画几根竖线
            // 设置矩阵
            Matrix4x4 defaultMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;
            // 设置颜色
            Color defaultColor = Gizmos.color;
            Gizmos.color = m_Color;


            Gizmos.DrawLine(-v3, v3);
            Gizmos.DrawLine(-v3 + new Vector3(-radius, 0, 0), v3 + new Vector3(-radius, 0, 0));
            Gizmos.DrawLine(-v3 + new Vector3(radius, 0, 0), v3 + new Vector3(radius, 0, 0));

            Gizmos.DrawLine(-v3 + new Vector3(0, 0, -radius), v3 + new Vector3(0, 0, -radius));
            Gizmos.DrawLine(-v3 + new Vector3(0, 0, radius), v3 + new Vector3(0, 0, radius));

            // 恢复默认矩阵
            Gizmos.matrix = defaultMatrix;
            Gizmos.color = defaultColor;

        }
    }
}
