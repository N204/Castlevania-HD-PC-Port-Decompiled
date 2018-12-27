using System;
using UnityEngine;

namespace Anima2D
{
	// Token: 0x020000F9 RID: 249
	public static class MathUtils
	{
		// Token: 0x06000642 RID: 1602 RVA: 0x000652B8 File Offset: 0x000634B8
		public static float SignedAngle(Vector3 a, Vector3 b, Vector3 forward)
		{
			float num = Vector3.Angle(a, b);
			float num2 = Mathf.Sign(Vector3.Dot(forward, Vector3.Cross(a, b)));
			return num * num2;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x000652E3 File Offset: 0x000634E3
		public static float Fmod(float value, float mod)
		{
			return Mathf.Abs(value % mod + mod) % mod;
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x000652F4 File Offset: 0x000634F4
		public static float SegmentDistance(Vector3 point, Vector3 a, Vector3 b)
		{
			Vector2 lhs = b - a;
			Vector2 rhs = point - a;
			float num = Vector2.Dot(lhs, rhs);
			if (num <= 0f)
			{
				return rhs.magnitude;
			}
			if (num >= lhs.sqrMagnitude)
			{
				return (point - b).magnitude;
			}
			return MathUtils.LineDistance(point, a, b);
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0006535C File Offset: 0x0006355C
		public static float SegmentSqrtDistance(Vector3 point, Vector3 a, Vector3 b)
		{
			Vector2 lhs = b - a;
			Vector2 rhs = point - a;
			float num = Vector2.Dot(lhs, rhs);
			if (num <= 0f)
			{
				return rhs.sqrMagnitude;
			}
			if (num >= lhs.sqrMagnitude)
			{
				return (point - b).sqrMagnitude;
			}
			return MathUtils.SqrtLineDistance(point, a, b);
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x000653C3 File Offset: 0x000635C3
		public static float LineDistance(Vector3 point, Vector3 a, Vector3 b)
		{
			return Mathf.Sqrt(MathUtils.SqrtLineDistance(point, a, b));
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x000653D4 File Offset: 0x000635D4
		public static float SqrtLineDistance(Vector3 point, Vector3 a, Vector3 b)
		{
			float num = Mathf.Abs((b.y - a.y) * point.x - (b.x - a.x) * point.y + b.x * a.y - b.y * a.x);
			return num * num / ((b.y - a.y) * (b.y - a.y) + (b.x - a.x) * (b.x - a.x));
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00065479 File Offset: 0x00063679
		public static void WorldFromMatrix4x4(this Transform transform, Matrix4x4 matrix)
		{
			transform.localScale = matrix.GetScale();
			transform.rotation = matrix.GetRotation();
			transform.position = matrix.GetPosition();
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0006549F File Offset: 0x0006369F
		public static void LocalFromMatrix4x4(this Transform transform, Matrix4x4 matrix)
		{
			transform.localScale = matrix.GetScale();
			transform.localRotation = matrix.GetRotation();
			transform.localPosition = matrix.GetPosition();
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x000654C8 File Offset: 0x000636C8
		public static Quaternion GetRotation(this Matrix4x4 matrix)
		{
			float num = Mathf.Sqrt(1f + matrix.m00 + matrix.m11 + matrix.m22) / 2f;
			float num2 = 4f * num;
			float x = (matrix.m21 - matrix.m12) / num2;
			float y = (matrix.m02 - matrix.m20) / num2;
			float z = (matrix.m10 - matrix.m01) / num2;
			return new Quaternion(x, y, z, num);
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x00065548 File Offset: 0x00063748
		public static Vector3 GetPosition(this Matrix4x4 matrix)
		{
			float m = matrix.m03;
			float m2 = matrix.m13;
			float m3 = matrix.m23;
			return new Vector3(m, m2, m3);
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00065578 File Offset: 0x00063778
		public static Vector3 GetScale(this Matrix4x4 m)
		{
			float x = Mathf.Sqrt(m.m00 * m.m00 + m.m01 * m.m01 + m.m02 * m.m02);
			float y = Mathf.Sqrt(m.m10 * m.m10 + m.m11 * m.m11 + m.m12 * m.m12);
			float z = Mathf.Sqrt(m.m20 * m.m20 + m.m21 * m.m21 + m.m22 * m.m22);
			return new Vector3(x, y, z);
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0006562C File Offset: 0x0006382C
		public static Rect ClampRect(Rect rect, Rect frame)
		{
			return new Rect
			{
				xMin = Mathf.Clamp(rect.xMin, 0f, frame.width - 1f),
				yMin = Mathf.Clamp(rect.yMin, 0f, frame.height - 1f),
				xMax = Mathf.Clamp(rect.xMax, 1f, frame.width),
				yMax = Mathf.Clamp(rect.yMax, 1f, frame.height)
			};
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x000656CE File Offset: 0x000638CE
		public static Vector2 ClampPositionInRect(Vector2 position, Rect frame)
		{
			return new Vector2(Mathf.Clamp(position.x, frame.xMin, frame.xMax), Mathf.Clamp(position.y, frame.yMin, frame.yMax));
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0006570C File Offset: 0x0006390C
		public static Rect OrderMinMax(Rect rect)
		{
			if (rect.xMin > rect.xMax)
			{
				float xMin = rect.xMin;
				rect.xMin = rect.xMax;
				rect.xMax = xMin;
			}
			if (rect.yMin > rect.yMax)
			{
				float yMin = rect.yMin;
				rect.yMin = rect.yMax;
				rect.yMax = yMin;
			}
			return rect;
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0006577C File Offset: 0x0006397C
		public static float RoundToMultipleOf(float value, float roundingValue)
		{
			if (roundingValue == 0f)
			{
				return value;
			}
			return Mathf.Round(value / roundingValue) * roundingValue;
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x00065795 File Offset: 0x00063995
		public static float GetClosestPowerOfTen(float positiveNumber)
		{
			if (positiveNumber <= 0f)
			{
				return 1f;
			}
			return Mathf.Pow(10f, (float)Mathf.RoundToInt(Mathf.Log10(positiveNumber)));
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x000657BE File Offset: 0x000639BE
		public static float RoundBasedOnMinimumDifference(float valueToRound, float minDifference)
		{
			if (minDifference == 0f)
			{
				return MathUtils.DiscardLeastSignificantDecimal(valueToRound);
			}
			return (float)Math.Round((double)valueToRound, MathUtils.GetNumberOfDecimalsForMinimumDifference(minDifference), MidpointRounding.AwayFromZero);
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x000657E4 File Offset: 0x000639E4
		public static float DiscardLeastSignificantDecimal(float v)
		{
			int digits = Mathf.Clamp((int)(5f - Mathf.Log10(Mathf.Abs(v))), 0, 15);
			return (float)Math.Round((double)v, digits, MidpointRounding.AwayFromZero);
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x00065816 File Offset: 0x00063A16
		public static int GetNumberOfDecimalsForMinimumDifference(float minDifference)
		{
			return Mathf.Clamp(-Mathf.FloorToInt(Mathf.Log10(minDifference)), 0, 15);
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0006582C File Offset: 0x00063A2C
		public static Vector3 Unskin(Vector3 skinedPosition, Matrix4x4 localToWorld, BoneWeight boneWeight, Matrix4x4[] bindposes, Transform[] bones)
		{
			Matrix4x4 matrix4x = bones[boneWeight.boneIndex0].localToWorldMatrix * bindposes[boneWeight.boneIndex0];
			Matrix4x4 matrix4x2 = bones[boneWeight.boneIndex1].localToWorldMatrix * bindposes[boneWeight.boneIndex1];
			Matrix4x4 matrix4x3 = bones[boneWeight.boneIndex2].localToWorldMatrix * bindposes[boneWeight.boneIndex2];
			Matrix4x4 matrix4x4 = bones[boneWeight.boneIndex3].localToWorldMatrix * bindposes[boneWeight.boneIndex3];
			Matrix4x4 identity = Matrix4x4.identity;
			for (int i = 0; i < 16; i++)
			{
				ref Matrix4x4 ptr = ref matrix4x;
				int index;
				matrix4x[index = i] = ptr[index] * boneWeight.weight0;
				ptr = ref matrix4x2;
				int index2;
				matrix4x2[index2 = i] = ptr[index2] * boneWeight.weight1;
				ptr = ref matrix4x3;
				int index3;
				matrix4x3[index3 = i] = ptr[index3] * boneWeight.weight2;
				ptr = ref matrix4x4;
				int index4;
				matrix4x4[index4 = i] = ptr[index4] * boneWeight.weight3;
				identity[i] = matrix4x[i] + matrix4x2[i] + matrix4x3[i] + matrix4x4[i];
			}
			return localToWorld.MultiplyPoint3x4(identity.inverse.MultiplyPoint3x4(skinedPosition));
		}
	}
}
