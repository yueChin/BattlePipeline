using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;

namespace ET
{
	public static partial class StringHelper
	{
		public static IEnumerable<byte> ToBytes(this string str)
		{
			byte[] byteArray = Encoding.Default.GetBytes(str);
			return byteArray;
		}

		public static byte[] ToByteArray(this string str)
		{
			byte[] byteArray = Encoding.Default.GetBytes(str);
			return byteArray;
		}

	    public static byte[] ToUtf8(this string str)
	    {
            byte[] byteArray = Encoding.UTF8.GetBytes(str);
            return byteArray;
        }

		public static byte[] HexToBytes(this string hexString)
		{
			if (hexString.Length % 2 != 0)
			{
				throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
			}

			var hexAsBytes = new byte[hexString.Length / 2];
			for (int index = 0; index < hexAsBytes.Length; index++)
			{
				string byteValue = "";
				byteValue += hexString[index * 2];
				byteValue += hexString[index * 2 + 1];
				hexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}
			return hexAsBytes;
		}

		public static string Fmt(this string text, params object[] args)
		{
			return string.Format(text, args);
		}

		public static string ToString<T>(this List<T> list, string splitStr = ",")
		{
			StringBuilder sb = new StringBuilder();
			foreach (T t in list)
			{
				sb.Append(t);
				sb.Append(splitStr);
			}
			return sb.ToString();
		}

		public static bool IsNullOrEmpty(this string str)
		{
			return String.IsNullOrEmpty(str);
		}

		public static Vector3 Filter(this Vector3 self)
		{
			int x = (int) (self.x * 1000);
			int y  =(int) (self.y * 1000);
			int z  =(int) (self.z * 1000);
			return new Vector3(x, y , z );
		}
		
		public static Vector3 FilterBack(this Vector3 self)
		{
			float x = self.x / 1000.0f;
			float y  =self.y / 1000.0f;
			float z  =self.z / 1000.0f;
			return new Vector3(x, y , z );
		}
		
		public static Quaternion Filter(this Quaternion self)
		{
			int x = (int) (self.x * 1000);
			int y  =(int) (self.y * 1000);
			int z  =(int) (self.z * 1000);
			return new Quaternion(x , y , z,self.w);
		}
		
		public static Quaternion FilterBack(this Quaternion self)
		{
			float x = (self.x / 1000.0f);
			float y = (self.y / 1000.0f);
			float z = (self.z / 1000.0f);
			return new Quaternion(x , y , z,self.w);
		}
	}
}