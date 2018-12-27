using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200036D RID: 877
	public class BoneATK : MagicMain
	{
		// Token: 0x06001DC5 RID: 7621 RVA: 0x00231ABB File Offset: 0x0022FCBB
		protected override void Awake()
		{
			base.Awake();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06001DC6 RID: 7622 RVA: 0x00231AE4 File Offset: 0x0022FCE4
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "EnemyShield")
			{
				this.grounded = true;
			}
			else if (other.tag == "DestroyObject")
			{
				this.grounded = true;
			}
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				EnemyBody component = other.transform.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component) == 1)
				{
					if (this.mineSW)
					{
						float f = Mathf.Round(this.iNT / 7f * this.berserk);
						int num = Mathf.RoundToInt(f);
						if (num < 1)
						{
							num = 1;
						}
						this.playerStatus.damage += num;
						if (!component.ownATKHitted)
						{
							component.ownATKHitted = true;
						}
					}
					this.ExpPlus(component.enemyLevel);
					Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x = vector.x;
					float y = vector.y;
					if (!this.somaMagic)
					{
						switch (this.lvl)
						{
						case 1:
							component.RPCActionDamageBone(this.iNT / 7f * this.berserk, this.dEX, x, y);
							break;
						case 2:
							component.RPCActionDamageBone(this.iNT * 1.225f / 7f * this.berserk, this.dEX, x, y);
							break;
						case 3:
							component.RPCActionDamageBone(this.iNT * 1.45f / 7f * this.berserk, this.dEX, x, y);
							break;
						case 4:
							component.RPCActionDamageBone(this.iNT * 1.675f / 7f * this.berserk, this.dEX, x, y);
							break;
						case 5:
							component.RPCActionDamageBone(this.iNT * 1.9f / 7f * this.berserk, this.dEX, x, y);
							break;
						case 6:
							component.RPCActionDamageBone(this.iNT * 2.125f / 7f * this.berserk, this.dEX, x, y);
							break;
						case 7:
							component.RPCActionDamageBone(this.iNT * 2.35f / 7f * this.berserk, this.dEX, x, y);
							break;
						case 8:
							component.RPCActionDamageBone(this.iNT * 2.575f / 7f * this.berserk, this.dEX, x, y);
							break;
						case 9:
							component.RPCActionDamageBone(this.iNT * 2.8f / 7f * this.berserk, this.dEX, x, y);
							break;
						}
					}
					else if (this.somaMagic)
					{
						switch (this.lvl)
						{
						case 1:
							component.RPCActionDamageBone(this.iNT * this.berserk, this.dEX, x, y);
							break;
						case 2:
							component.RPCActionDamageBone(this.iNT * 1.225f * this.berserk, this.dEX, x, y);
							break;
						case 3:
							component.RPCActionDamageBone(this.iNT * 1.45f * this.berserk, this.dEX, x, y);
							break;
						case 4:
							component.RPCActionDamageBone(this.iNT * 1.675f * this.berserk, this.dEX, x, y);
							break;
						case 5:
							component.RPCActionDamageBone(this.iNT * 1.9f * this.berserk, this.dEX, x, y);
							break;
						case 6:
							component.RPCActionDamageBone(this.iNT * 2.125f * this.berserk, this.dEX, x, y);
							break;
						case 7:
							component.RPCActionDamageBone(this.iNT * 2.35f * this.berserk, this.dEX, x, y);
							break;
						case 8:
							component.RPCActionDamageBone(this.iNT * 2.575f * this.berserk, this.dEX, x, y);
							break;
						case 9:
							component.RPCActionDamageBone(this.iNT * 2.8f * this.berserk, this.dEX, x, y);
							break;
						}
					}
					component.ReciveBoolReturn(this.returnTime, "Bone", this.playerNumber);
				}
			}
			else if (other.tag == "EnemyBodyAttackSp")
			{
				EnemyBody component2 = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component2) == 1)
				{
					if (this.mineSW)
					{
						float f2 = Mathf.Round(this.iNT / 7f * this.berserk);
						int num2 = Mathf.RoundToInt(f2);
						if (num2 < 1)
						{
							num2 = 1;
						}
						this.playerStatus.damage += num2;
						if (!component2.ownATKHitted)
						{
							component2.ownATKHitted = true;
						}
					}
					this.ExpPlus(component2.enemyLevel);
					Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x2 = vector2.x;
					float y2 = vector2.y;
					if (!this.somaMagic)
					{
						switch (this.lvl)
						{
						case 1:
							component2.RPCActionDamageBone(this.iNT / 7f * this.berserk, this.dEX, x2, y2);
							break;
						case 2:
							component2.RPCActionDamageBone(this.iNT * 1.225f / 7f * this.berserk, this.dEX, x2, y2);
							break;
						case 3:
							component2.RPCActionDamageBone(this.iNT * 1.45f / 7f * this.berserk, this.dEX, x2, y2);
							break;
						case 4:
							component2.RPCActionDamageBone(this.iNT * 1.675f / 7f * this.berserk, this.dEX, x2, y2);
							break;
						case 5:
							component2.RPCActionDamageBone(this.iNT * 1.9f / 7f * this.berserk, this.dEX, x2, y2);
							break;
						case 6:
							component2.RPCActionDamageBone(this.iNT * 2.125f / 7f * this.berserk, this.dEX, x2, y2);
							break;
						case 7:
							component2.RPCActionDamageBone(this.iNT * 2.35f / 7f * this.berserk, this.dEX, x2, y2);
							break;
						case 8:
							component2.RPCActionDamageBone(this.iNT * 2.575f / 7f * this.berserk, this.dEX, x2, y2);
							break;
						case 9:
							component2.RPCActionDamageBone(this.iNT * 2.8f / 7f * this.berserk, this.dEX, x2, y2);
							break;
						}
					}
					else if (this.somaMagic)
					{
						switch (this.lvl)
						{
						case 1:
							component2.RPCActionDamageBone(this.iNT * this.berserk, this.dEX, x2, y2);
							break;
						case 2:
							component2.RPCActionDamageBone(this.iNT * 1.225f * this.berserk, this.dEX, x2, y2);
							break;
						case 3:
							component2.RPCActionDamageBone(this.iNT * 1.45f * this.berserk, this.dEX, x2, y2);
							break;
						case 4:
							component2.RPCActionDamageBone(this.iNT * 1.675f * this.berserk, this.dEX, x2, y2);
							break;
						case 5:
							component2.RPCActionDamageBone(this.iNT * 1.9f * this.berserk, this.dEX, x2, y2);
							break;
						case 6:
							component2.RPCActionDamageBone(this.iNT * 2.125f * this.berserk, this.dEX, x2, y2);
							break;
						case 7:
							component2.RPCActionDamageBone(this.iNT * 2.35f * this.berserk, this.dEX, x2, y2);
							break;
						case 8:
							component2.RPCActionDamageBone(this.iNT * 2.575f * this.berserk, this.dEX, x2, y2);
							break;
						case 9:
							component2.RPCActionDamageBone(this.iNT * 2.8f * this.berserk, this.dEX, x2, y2);
							break;
						}
					}
					component2.ReciveBoolReturn(this.returnTime, "Bone", this.playerNumber);
				}
			}
			else if (other.tag == "EnemyBodyAttackBoss01")
			{
				Boss01BodyDetect component3 = other.GetComponent<Boss01BodyDetect>();
				EnemyBody component4 = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component4) == 1)
				{
					if (this.mineSW)
					{
						float f3 = Mathf.Round(this.iNT / 7f * this.berserk);
						int num3 = Mathf.RoundToInt(f3);
						if (num3 < 1)
						{
							num3 = 1;
						}
						this.playerStatus.damage += num3;
						if (!component4.ownATKHitted)
						{
							component4.ownATKHitted = true;
						}
					}
					this.ExpPlus(component3.enemyLevel);
					Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x3 = vector3.x;
					float y3 = vector3.y;
					if (!this.somaMagic)
					{
						switch (this.lvl)
						{
						case 1:
							component4.RPCActionDamageBone(this.iNT / 7f * this.berserk, this.dEX, x3, y3);
							break;
						case 2:
							component4.RPCActionDamageBone(this.iNT * 1.225f / 7f * this.berserk, this.dEX, x3, y3);
							break;
						case 3:
							component4.RPCActionDamageBone(this.iNT * 1.45f / 7f * this.berserk, this.dEX, x3, y3);
							break;
						case 4:
							component4.RPCActionDamageBone(this.iNT * 1.675f / 7f * this.berserk, this.dEX, x3, y3);
							break;
						case 5:
							component4.RPCActionDamageBone(this.iNT * 1.9f / 7f * this.berserk, this.dEX, x3, y3);
							break;
						case 6:
							component4.RPCActionDamageBone(this.iNT * 2.125f / 7f * this.berserk, this.dEX, x3, y3);
							break;
						case 7:
							component4.RPCActionDamageBone(this.iNT * 2.35f / 7f * this.berserk, this.dEX, x3, y3);
							break;
						case 8:
							component4.RPCActionDamageBone(this.iNT * 2.575f / 7f * this.berserk, this.dEX, x3, y3);
							break;
						case 9:
							component4.RPCActionDamageBone(this.iNT * 2.8f / 7f * this.berserk, this.dEX, x3, y3);
							break;
						}
					}
					else if (this.somaMagic)
					{
						switch (this.lvl)
						{
						case 1:
							component4.RPCActionDamageBone(this.iNT * this.berserk, this.dEX, x3, y3);
							break;
						case 2:
							component4.RPCActionDamageBone(this.iNT * 1.225f * this.berserk, this.dEX, x3, y3);
							break;
						case 3:
							component4.RPCActionDamageBone(this.iNT * 1.45f * this.berserk, this.dEX, x3, y3);
							break;
						case 4:
							component4.RPCActionDamageBone(this.iNT * 1.675f * this.berserk, this.dEX, x3, y3);
							break;
						case 5:
							component4.RPCActionDamageBone(this.iNT * 1.9f * this.berserk, this.dEX, x3, y3);
							break;
						case 6:
							component4.RPCActionDamageBone(this.iNT * 2.125f * this.berserk, this.dEX, x3, y3);
							break;
						case 7:
							component4.RPCActionDamageBone(this.iNT * 2.35f * this.berserk, this.dEX, x3, y3);
							break;
						case 8:
							component4.RPCActionDamageBone(this.iNT * 2.575f * this.berserk, this.dEX, x3, y3);
							break;
						case 9:
							component4.RPCActionDamageBone(this.iNT * 2.8f * this.berserk, this.dEX, x3, y3);
							break;
						}
					}
					component4.ReciveBoolReturn(this.returnTime, "Bone", this.playerNumber);
				}
			}
		}

		// Token: 0x06001DC7 RID: 7623 RVA: 0x002328F0 File Offset: 0x00230AF0
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (base.GetComponent<Rigidbody2D>().velocity.y < -6f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, -6f);
			}
			if (!this.grounded && currentAnimatorStateInfo.fullPathHash == BoneATK.ANISTS_Idle)
			{
				this.timer += Time.deltaTime;
				if (this.timer > 7.5f && !this.destroyCheck)
				{
					this.animator.SetTrigger("FadeOut");
					this.destroyCheck = true;
				}
			}
			if (this.grounded && currentAnimatorStateInfo.fullPathHash == BoneATK.ANISTS_Idle && !this.destroyCheck)
			{
				this.animator.SetTrigger("EndLife");
				this.animator.SetTrigger("FadeOut");
				if (!this.destroyVelocity)
				{
					if (base.transform.localScale.x > 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 2f);
						this.destroyVelocity = true;
					}
					else if (base.transform.localScale.x < 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 2f);
						this.destroyVelocity = true;
					}
				}
			}
		}

		// Token: 0x06001DC8 RID: 7624 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x06001DC9 RID: 7625 RVA: 0x00232A84 File Offset: 0x00230C84
		public void Action()
		{
			this.grounded = false;
			this.destroyCheck = false;
			this.destroyVelocity = false;
			this.timer = 0f;
			this.animator.ResetTrigger("EndLife");
			this.animator.ResetTrigger("FadeOut");
			this.animator.Play("BoneATK_Idle");
			if (base.transform.localScale.x > 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 6f);
			}
			else if (base.transform.localScale.x < 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 6f);
			}
		}

		// Token: 0x06001DCA RID: 7626 RVA: 0x00232B54 File Offset: 0x00230D54
		private int ReturnBool(int num, EnemyBody targetEnemyBody)
		{
			int num2 = 0;
			switch (num)
			{
			case 1:
				if (!targetEnemyBody.canRecive_Bone)
				{
					num2++;
				}
				break;
			case 2:
				if (!targetEnemyBody.canRecive_Bone1)
				{
					num2++;
				}
				break;
			case 3:
				if (!targetEnemyBody.canRecive_Bone2)
				{
					num2++;
				}
				break;
			case 4:
				if (!targetEnemyBody.canRecive_Bone3)
				{
					num2++;
				}
				break;
			case 5:
				if (!targetEnemyBody.canRecive_Bone4)
				{
					num2++;
				}
				break;
			case 6:
				if (!targetEnemyBody.canRecive_Bone5)
				{
					num2++;
				}
				break;
			case 7:
				if (!targetEnemyBody.canRecive_Bone6)
				{
					num2++;
				}
				break;
			case 8:
				if (!targetEnemyBody.canRecive_Bone7)
				{
					num2++;
				}
				break;
			case 9:
				if (!targetEnemyBody.canRecive_Bone8)
				{
					num2++;
				}
				break;
			case 10:
				if (!targetEnemyBody.canRecive_Bone9)
				{
					num2++;
				}
				break;
			}
			return num2;
		}

		// Token: 0x06001DCB RID: 7627 RVA: 0x00232C64 File Offset: 0x00230E64
		private void ExpPlus(int lvl)
		{
			if (this.mineSW)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expBone += 1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expBone += 2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expBone += 3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expBone += 4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expBone += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expBone += 6f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x06001DCC RID: 7628 RVA: 0x0008FD35 File Offset: 0x0008DF35
		public void DestroyCall()
		{
			base.Invoke("GameObjectFalse", 0.2f);
		}

		// Token: 0x06001DCD RID: 7629 RVA: 0x00232D8F File Offset: 0x00230F8F
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x040031FF RID: 12799
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.BoneATK_Idle");

		// Token: 0x04003200 RID: 12800
		public static readonly int ANISTS_EndLife = Animator.StringToHash("Base Layer.BoneATK_Destroy");

		// Token: 0x04003201 RID: 12801
		[NonSerialized]
		public Animator animator;

		// Token: 0x04003202 RID: 12802
		private PlayerStatus playerStatus;

		// Token: 0x04003203 RID: 12803
		public GameObject ownerObj;

		// Token: 0x04003204 RID: 12804
		public InstantiateManager instantiateManager;

		// Token: 0x04003205 RID: 12805
		public float timer;

		// Token: 0x04003206 RID: 12806
		public bool destroyCheck;

		// Token: 0x04003207 RID: 12807
		public bool destroyVelocity;

		// Token: 0x04003208 RID: 12808
		public int lvl;

		// Token: 0x04003209 RID: 12809
		public float iNT;

		// Token: 0x0400320A RID: 12810
		public float dEX;

		// Token: 0x0400320B RID: 12811
		public bool mineSW;

		// Token: 0x0400320C RID: 12812
		public int playerNumber;

		// Token: 0x0400320D RID: 12813
		public float returnTime = 0.3f;

		// Token: 0x0400320E RID: 12814
		public float berserk;

		// Token: 0x0400320F RID: 12815
		public bool somaMagic;
	}
}
