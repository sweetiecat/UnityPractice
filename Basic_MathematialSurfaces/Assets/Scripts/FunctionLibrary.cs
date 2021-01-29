﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
	public delegate Vector3 Function(float u, float v, float t);

	public enum FunctionName { Wave, MultiWave, Ripple, Sphere, Torus }

	static Function[] functions = { Wave, MultiWave, Ripple, Sphere, Torus };
	public static Function GetFunction(FunctionName name)//(int index)
	{
		//if (index == 0)
		//{
		//	return Wave;
		//}
		//else if (index == 1)
		//{
		//	return MultiWave;
		//}
		//else
		//{
		//	return Ripple;
		//}改成下面一行
		//return functions[index];
		return functions[(int)name];
	}
	//public static float Wave(float x, float t)
	//{
	//return Mathf.Sin(Mathf.PI * (x + t));
	//}增加using static UnityEngine.Mathf;便可改寫成下面
	//public static float Wave(float x, float z, float t)
	//{
	//	return Sin(PI * (x +z + t));
	//}更改為下面的函式
	public static Vector3 Wave(float u, float v, float t)
	{
		Vector3 p;
		p.x = u;
		p.y = Sin(PI * (u + v + t));
		p.z = v;
		return p;
	}
	/*public static float MultiWave(float x, float z, float t)//正弦函數
	{
		//float y = Sin(PI * (x + t));
		//y += Sin(2f * PI * (x + t)) * (1f / 2f);
		float y = Sin(PI * (x + 0.5f * t));
		y += 0.5f * Sin(2f * PI * (z + t));
		//return y * (2f / 3f);
		y += Sin(PI * (x + z + 0.25f * t));
		return y * (1f / 2.5f);
	}*/
	public static Vector3 MultiWave(float u, float v, float t)
	{
		Vector3 p;
		p.x = u;
		p.y = Sin(PI * (u + 0.5f * t));
		p.y += 0.5f * Sin(2f * PI * (v + t));
		p.y += Sin(PI * (u + v + 0.25f * t));
		p.y *= 1f / 2.5f;
		p.z = v;
		return p;
	}

	public static Vector3 Ripple(float u, float v, float t)
	{
		float d = Sqrt(u * u + v * v);
		Vector3 p;
		p.x = u;
		p.y = Sin(PI * (4f * d - t));
		p.y /= 1f + 10f * d;
		p.z = v;
		return p;
	}
	/*public static float Ripple(float x, float z, float t)
	{
		//float d = Abs(x);
		float d = Sqrt(x * x + z * z);
		float y = Sin(PI * (4f * d - t));
		return y / (1f + 10f * d);
	}*/
	public static Vector3 Sphere(float u, float v, float t)
	{
		//float r = Cos(0.5f * PI * v);
		//float r = 0.5f + 0.5f * Sin(PI * t);
		//float r = 0.9f + 0.1f * Sin(8f * PI * u);
		//float r = 0.9f + 0.1f * Sin(8f * PI * v);
		float r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t)); 
		float s = r * Cos(0.5f * PI * v);
		Vector3 p;
		p.x = s * Sin(PI * u);
		p.y = r * Sin(0.5f * PI * v);
		p.z = s * Cos(PI * u);
		return p;
	}
	public static Vector3 Torus(float u, float v, float t)
	{
		//float r = 1f;
		//float r1 = 1f;
		//float r2 = 0.5f;
		float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
		float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t));
		//float s = 0.5f + r * Cos(PI * PI * v);
		//float s = 0.5f + r * Cos(PI * v);
		float s = r1 + r2 * Cos(PI * v);
		Vector3 p;
		p.x = s * Sin(PI * u);
		//p.y = r * Sin(PI * PI * v);
		//p.y = r * Sin(PI * v);
		p.y = r2 * Sin(PI * v);
		p.z = s * Cos(PI * u);
		return p;
	}
}
