using System;
using System.Collections;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020002D1 RID: 721
	public class Asyutarute_Range : MagicMain
	{
		// Token: 0x06001643 RID: 5699 RVA: 0x0010C0CC File Offset: 0x0010A2CC
		protected override void Awake()
		{
			base.Awake();
			this.eSE = base.GetComponent<EnemySoundEffect>();
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06001644 RID: 5700 RVA: 0x0010C0EC File Offset: 0x0010A2EC
		private void Update()
		{
			this.timer += Time.deltaTime;
			int num = this.type;
			if (num != 1)
			{
				if (num != 3)
				{
					if (num == 5)
					{
						if (this.time > 1f)
						{
							this.GameObjectFalse();
						}
						base.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
						this.time += Time.deltaTime * this.speed;
					}
				}
				else if (!this.destroyCheck)
				{
					this.v = base.transform.position;
					this.v.y = Mathf.Sin(this.angle) * this.range;
					this.angle += this.yspeed;
					base.transform.position = new Vector2(base.transform.position.x, this.startYPos + this.v.y);
					if (base.transform.localScale.x > 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(this.timer * 6f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
					else if (base.transform.localScale.x < 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.timer * 6f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
					if (this.v.y >= 0.25f && this.count == 0)
					{
						if (base.transform.localScale.x > 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 0, this.size, 20f);
						}
						else if (base.transform.localScale.x < 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 1, this.size, -20f);
						}
						this.size += 0.2f;
						this.count = 1;
					}
					if (this.v.y >= 0.45f && this.count == 1)
					{
						if (base.transform.localScale.x > 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 0, this.size, 0f);
						}
						else if (base.transform.localScale.x < 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 1, this.size, 0f);
						}
						this.size += 0.2f;
						this.count = 2;
					}
					if (this.v.y <= 0.25f && this.count == 2)
					{
						if (base.transform.localScale.x > 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 0, this.size, -20f);
						}
						else if (base.transform.localScale.x < 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 1, this.size, 20f);
						}
						this.size += 0.2f;
						this.count = 3;
					}
					if (this.v.y <= -0.25f && this.count == 3)
					{
						if (base.transform.localScale.x > 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 0, this.size, -20f);
						}
						else if (base.transform.localScale.x < 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 1, this.size, 20f);
						}
						this.size += 0.2f;
						this.count = 4;
					}
					if (this.v.y <= -0.45f && this.count == 4)
					{
						if (base.transform.localScale.x > 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 0, this.size, 0f);
						}
						else if (base.transform.localScale.x < 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 1, this.size, 0f);
						}
						this.size += 0.2f;
						this.count = 5;
					}
					if (this.v.y >= -0.25f && this.count == 5)
					{
						if (base.transform.localScale.x > 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 0, this.size, 20f);
						}
						else if (base.transform.localScale.x < 0f)
						{
							this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 1, this.size, -20f);
						}
						this.size += 0.2f;
						this.count = 0;
					}
					if (this.timer > 1.5f)
					{
						this.GameObjectFalse();
						this.destroyCheck = true;
					}
				}
			}
			else
			{
				AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
				if (!this.destroyCheck)
				{
					if (!this.grounded)
					{
						if (currentAnimatorStateInfo.fullPathHash == Asyutarute_Range.ANISTS_Idle)
						{
							if (base.transform.localScale.x < 0f)
							{
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(this.timer * 6f, base.GetComponent<Rigidbody2D>().velocity.y);
							}
							else if (base.transform.localScale.x > 0f)
							{
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.timer * 6f, base.GetComponent<Rigidbody2D>().velocity.y);
							}
							switch (this.type2)
							{
							case 1:
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, this.timer * 8f);
								break;
							case 2:
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, this.timer * 6f);
								break;
							case 3:
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, this.timer * 4f);
								break;
							case 4:
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, this.timer * 2f);
								break;
							case 6:
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, this.timer * -1f);
								break;
							case 7:
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, this.timer * -2f);
								break;
							case 8:
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, this.timer * -3f);
								break;
							case 9:
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, this.timer * -4f);
								break;
							}
						}
					}
					else if (this.grounded)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
						this.animator.SetTrigger("Out");
						this.destroyCheck = true;
					}
					if (this.timer > 15f)
					{
						this.GameObjectFalse();
					}
				}
			}
		}

		// Token: 0x06001645 RID: 5701 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x06001646 RID: 5702 RVA: 0x0010CC14 File Offset: 0x0010AE14
		public void Action()
		{
			this.angle = 0f;
			this.startYPos = base.transform.position.y;
			this.grounded = false;
			this.timer = 0f;
			this.timer2 = 0f;
			this.destroyCheck = false;
			this.action = false;
			this.count = 0;
			this.size = 1.2f;
			this.time = 0f;
			switch (this.type)
			{
			case 1:
				this.animator.Play("Asyutarute_Miryou_In");
				break;
			case 2:
				this.animator.Play("Asyutarute_Wind_Idle");
				break;
			case 3:
				if (base.transform.localScale.x > 0f)
				{
					this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 0, this.size, 0f);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 1, this.size, 0f);
				}
				break;
			case 5:
				this.startPos = base.transform.position;
				break;
			}
		}

		// Token: 0x06001647 RID: 5703 RVA: 0x0010CDC8 File Offset: 0x0010AFC8
		private IEnumerator EnumInstantShot(float delay, int val, float sizeVal)
		{
			yield return new WaitForSeconds(delay);
			if (val == 1)
			{
				if (base.transform.localScale.x > 0f)
				{
					this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 0, this.size, 0f);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.instantiateManager.EnemyAsyutaruteRange3(base.transform.position.x, base.transform.position.y, this.atkVal, 1, this.size, 0f);
				}
			}
			yield break;
		}

		// Token: 0x06001648 RID: 5704 RVA: 0x0010CDF4 File Offset: 0x0010AFF4
		private Vector3 BezierCurve(Vector3 pt1, Vector3 pt2, Vector3 ctrlPt, float t)
		{
			if (t > 1f)
			{
				t = 1f;
			}
			Vector3 result = default(Vector3);
			float num = 1f - t;
			result.x = num * num * pt1.x + 2f * num * t * ctrlPt.x + t * t * pt2.x;
			result.y = num * num * pt1.y + 2f * num * t * ctrlPt.y + t * t * pt2.y;
			result.z = num * num * pt1.z + 2f * num * t * ctrlPt.z + t * t * pt2.z;
			return result;
		}

		// Token: 0x06001649 RID: 5705 RVA: 0x0010CEBF File Offset: 0x0010B0BF
		public void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04001FEF RID: 8175
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Asyutarute_Miryou_Idle");

		// Token: 0x04001FF0 RID: 8176
		public InstantiateManager instantiateManager;

		// Token: 0x04001FF1 RID: 8177
		private EnemySoundEffect eSE;

		// Token: 0x04001FF2 RID: 8178
		private Animator animator;

		// Token: 0x04001FF3 RID: 8179
		public float timer;

		// Token: 0x04001FF4 RID: 8180
		public float timer2;

		// Token: 0x04001FF5 RID: 8181
		public float atkVal;

		// Token: 0x04001FF6 RID: 8182
		public bool destroyCheck;

		// Token: 0x04001FF7 RID: 8183
		public bool action;

		// Token: 0x04001FF8 RID: 8184
		public int type;

		// Token: 0x04001FF9 RID: 8185
		public int type2;

		// Token: 0x04001FFA RID: 8186
		public int count;

		// Token: 0x04001FFB RID: 8187
		public float size;

		// Token: 0x04001FFC RID: 8188
		public Vector2 v;

		// Token: 0x04001FFD RID: 8189
		private Vector3 startPos;

		// Token: 0x04001FFE RID: 8190
		public Vector3 targetPos;

		// Token: 0x04001FFF RID: 8191
		public Vector3 posHokan;

		// Token: 0x04002000 RID: 8192
		private float time;

		// Token: 0x04002001 RID: 8193
		public float speed = 1f;

		// Token: 0x04002002 RID: 8194
		private float angle;

		// Token: 0x04002003 RID: 8195
		private float range = 0.5f;

		// Token: 0x04002004 RID: 8196
		private float yspeed = 0.5f;

		// Token: 0x04002005 RID: 8197
		private float startYPos;
	}
}
