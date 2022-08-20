using UnityEngine;

namespace ET
{
	public struct Sector
	{
		public float range;
		public Vector2 Origin;
		public Vector2 Dir;
		public float HalfTheta;
	}

	public static class MathHelper
	{
		public static Vector3 RayCastV2ToV3(Vector2 pos)
		{
            return new Vector3(pos.x, 0, pos.y);
		}

		public static Vector3 RayCastXYToV3(float x, float y)
        {
			return new Vector3(x, 0, y);
		}

		public static Vector3 RayCastV3ToV3(Vector3 pos)
		{
			return new Vector3(pos.x, 0, pos.z);
		}

		public static Quaternion GetVector3ToQuaternion(Vector3 source, Vector3 dire)
		{
			Vector3 nowPos = source;
			if (nowPos == dire)
			{
				return new Quaternion();
			}
			Vector3 direction = (dire - nowPos).normalized;
			return Quaternion.LookRotation(direction, Vector3.up);
		}

        public static float Distance2D(Unit u1, Unit u2)
        {
            Vector2 v1 = new Vector2(u1.Position.x, u1.Position.z);
            Vector2 v2 = new Vector2(u2.Position.x, u2.Position.z);
            return Vector2.Distance(v1, v2);
        }

        public static float Distance2D(Vector3 v1, Vector3 v2)
        {
            Vector2 d1 = new Vector2(v1.x, v1.z);
            Vector2 d2 = new Vector2(v2.x, v2.z);
            return Vector2.Distance(d1, d2);
        }

		public static float Vector3ToAngle360(Vector3 from, Vector3 to)
		{
			float angle = Vector3.Angle(from, to);
			Vector3 cross = Vector3.Cross(from, to);
			return cross.y > 0? angle : 360 - angle;
		}
        /// <summary>
        ///  求点到直线的距离，采用数学公式Ax+By+C = 0; d = A*p.x + B * p.y + C / sqrt(A^2 + B ^ 2)
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <param name="point"></param>
        /// <returns></returns>
	    public static float DistanceOfPointToVector(Vector3 startPoint, Vector3 endPoint, Vector3 point)
	    {
            Vector2 startVe2 = startPoint.IgnoreYAxis();
            Vector2 endVe2 = endPoint.IgnoreYAxis();
            float A = endVe2.y - startVe2.y;
            float B = startVe2.x - endVe2.x;
            float C = endVe2.x * startVe2.y - startVe2.x * endVe2.y;
            float denominator = Mathf.Sqrt(A * A + B * B);
            Vector2 pointVe2 = point.IgnoreYAxis();
            return Mathf.Abs((A * pointVe2.x + B * pointVe2.y + C) / denominator);
        }
        /// <summary>
        /// 勾股定理
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float GGTheorem(float x, float y)
        {
            return Mathf.Sqrt(x * x + y * y);
        }
        /// <summary>
        /// 去掉三维向量的Y轴，把向量投射到xz平面。
        /// </summary>
        /// <param name="vector3"></param>
        /// <returns></returns>
	    public static Vector2 IgnoreYAxis(this Vector3 vector3)
	    {
            return new Vector2(vector3.x, vector3.z);
        }
        /// <summary>
        /// 判断目标点是否位于向量的左边
        /// </summary>
        /// <returns>True is on left, false is on right</returns>
        public static bool PointOnLeftSideOfVector(this Vector3 vector3, Vector3 originPoint, Vector3 point)
        {
            Vector2 originVec2 = originPoint.IgnoreYAxis();

            Vector2 pointVec2 = (point.IgnoreYAxis() - originVec2).normalized;

            Vector2 vector2 = vector3.IgnoreYAxis();

            float verticalX = originVec2.x;

            float verticalY = (-verticalX * vector2.x) / vector2.y;

            Vector2 norVertical = (new Vector2(verticalX, verticalY)).normalized;

            float dotValue = Vector2.Dot(norVertical, pointVec2);

            return dotValue < 0f;
        }

        public static bool IsPointInsideCircle(Sector sector, Vector2 target)
        {
	        var d = target - sector.Origin;
	        if (d.sqrMagnitude > sector.range * sector.range)
	        {
		        return false;
	        }

	        d = d.normalized;

	        if (Vector3.Dot(d, sector.Dir ) >= Mathf.Cos(sector.HalfTheta))
		        return true;
	        return false;

        }

        // 以origin为底边,dir为方向,长度为length,宽度为width的矩形
        public static bool IsPointInsideRect(float length, float width, Vector3 origin, Vector3 originDir, Vector3 target)
        {
	        var vDir = GetVerticalDir(originDir);
	        var halfWidth = vDir * width / 2;
	        var pointA = origin - halfWidth;
	        var pointB = origin + halfWidth;
	        var pointC = pointB + originDir * length;
	        var pointD = pointA + originDir * length;
	        var ab = pointB - pointA;
	        var cd = pointD - pointC;
	        var ae = target - pointA;
	        var ce = target - pointC;

	        if (Vector3.Dot(Vector3.Cross(ab, ae), Vector3.Cross(cd, ce)) < 0)
	        {
		        return false;
	        }

	        var bc = pointC - pointB;
	        var da = pointA - pointD;
	        var be = target - pointB;
	        var de = target - pointD;

	        
	        if (Vector3.Dot(Vector3.Cross(bc, be), Vector3.Cross(da, de)) < 0)
	        {
		        return false;
	        }


	        return true;
        }


        public static Vector3 GetVerticalDir(Vector3 _dir)
        {
	        //（_dir.x,_dir.z）与（？，1）垂直，则_dir.x * ？ + _dir.z * 1 = 0
	        if (_dir.z == 0)
	        {
		        return new Vector3(0, 0, -1);
	        }
	        else
	        {
		        return new Vector3(-_dir.z / _dir.x, 0, 1).normalized;
	        }
        }
        
        
        // 计算线段与点的最短平方距离
        // x0 线段起点
        // u  线段方向至末端点
        // x  任意点
        static float SegmentPointSqrDistance(Vector2 x0, Vector2 u, Vector2 x) {
	        float t = Vector2.Dot(x - x0, u) / u.sqrMagnitude;
	        return (x - (x0 + Mathf.Clamp(t, 0, 1) * u)).sqrMagnitude;
        }
        
        public static Vector3 ToV3(this OpVector3 proto)
        {
	        return new Vector3() { x = proto.X, y = proto.Y, z = proto.Z };
        }

        public static OpVector3 ToProto(this Vector3 v3)
        {
	        return new OpVector3() { X = v3.x, Y = v3.y, Z = v3.z };
        }

        public static Vector2 ToV2(this Vector3 v3)
        {
	        return new Vector2(v3.x, v3.z);
        }

        public static Vector3 ToV3(this Vector2 v2, float y = 0)
        {
	        return new Vector3(v2.x, y, v2.y);
        }
	}
}