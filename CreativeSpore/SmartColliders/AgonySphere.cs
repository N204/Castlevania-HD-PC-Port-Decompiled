using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000342 RID: 834
	public class AgonySphere : MagicMain
	{
		// Token: 0x06001C4E RID: 7246 RVA: 0x001E3AA0 File Offset: 0x001E1CA0
		protected override void Awake()
		{
			base.Awake();
			this.eSE = base.GetComponent<EnemySoundEffect>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.col2d = base.transform.Find("ATKCol").GetComponent<CircleCollider2D>();
			this.audioS = base.GetComponent<AudioSource>();
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06001C4F RID: 7247 RVA: 0x001E3B08 File Offset: 0x001E1D08
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!this.enemySW)
			{
				if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
				{
					EnemyBody component = other.transform.parent.GetComponent<EnemyBody>();
					if (this.ReturnBool(this.playerNumber, this.skillNumber, component) == 1)
					{
						if (this.mineSW)
						{
							float f = Mathf.Round(this.iNT * this.sWDamage * this.berserk);
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
						Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x = vector.x;
						float y = vector.y;
						switch (this.lvl)
						{
						case 1:
							component.RPCActionDamageNitensu(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 2:
							component.RPCActionDamageNitensu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 3:
							component.RPCActionDamageNitensu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 4:
							component.RPCActionDamageNitensu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 5:
							component.RPCActionDamageNitensu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 6:
							component.RPCActionDamageNitensu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 7:
							component.RPCActionDamageNitensu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 8:
							component.RPCActionDamageNitensu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 9:
							component.RPCActionDamageNitensu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						}
						component.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
				else if (other.tag == "EnemyBodyAttackSp")
				{
					EnemyBody component2 = other.transform.parent.parent.GetComponent<EnemyBody>();
					if (this.ReturnBool(this.playerNumber, this.skillNumber, component2) == 1)
					{
						if (this.mineSW)
						{
							float f2 = Mathf.Round(this.iNT * this.sWDamage * this.berserk);
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
						Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x2 = vector2.x;
						float y2 = vector2.y;
						switch (this.lvl)
						{
						case 1:
							component2.RPCActionDamageNitensu(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 2:
							component2.RPCActionDamageNitensu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 3:
							component2.RPCActionDamageNitensu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 4:
							component2.RPCActionDamageNitensu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 5:
							component2.RPCActionDamageNitensu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 6:
							component2.RPCActionDamageNitensu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 7:
							component2.RPCActionDamageNitensu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 8:
							component2.RPCActionDamageNitensu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 9:
							component2.RPCActionDamageNitensu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						}
						component2.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
				else if (other.tag == "EnemyBodyAttackBoss01")
				{
					Boss01BodyDetect component3 = other.GetComponent<Boss01BodyDetect>();
					EnemyBody component4 = other.transform.parent.parent.GetComponent<EnemyBody>();
					if (this.ReturnBool(this.playerNumber, this.skillNumber, component4) == 1)
					{
						if (this.mineSW)
						{
							float f3 = Mathf.Round(this.iNT * this.sWDamage * this.berserk);
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
						Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x3 = vector3.x;
						float y3 = vector3.y;
						switch (this.lvl)
						{
						case 1:
							component3.ActionDamageNitensu(this.iNT * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 2:
							component3.ActionDamageNitensu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 3:
							component3.ActionDamageNitensu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 4:
							component3.ActionDamageNitensu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 5:
							component3.ActionDamageNitensu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 6:
							component3.ActionDamageNitensu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 7:
							component3.ActionDamageNitensu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 8:
							component3.ActionDamageNitensu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 9:
							component3.ActionDamageNitensu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						}
						component4.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
			}
		}

		// Token: 0x06001C50 RID: 7248 RVA: 0x001E43E8 File Offset: 0x001E25E8
		private void OnTriggerStay2D(Collider2D other)
		{
			if (!this.enemySW)
			{
				if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
				{
					EnemyBody component = other.transform.parent.GetComponent<EnemyBody>();
					if (this.ReturnBool(this.playerNumber, this.skillNumber, component) == 1)
					{
						if (this.mineSW)
						{
							float f = Mathf.Round(this.iNT * this.sWDamage * this.berserk);
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
						Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x = vector.x;
						float y = vector.y;
						switch (this.lvl)
						{
						case 1:
							component.RPCActionDamageNitensu(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 2:
							component.RPCActionDamageNitensu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 3:
							component.RPCActionDamageNitensu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 4:
							component.RPCActionDamageNitensu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 5:
							component.RPCActionDamageNitensu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 6:
							component.RPCActionDamageNitensu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 7:
							component.RPCActionDamageNitensu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 8:
							component.RPCActionDamageNitensu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 9:
							component.RPCActionDamageNitensu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						}
						component.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
				else if (other.tag == "EnemyBodyAttackSp")
				{
					EnemyBody component2 = other.transform.parent.parent.GetComponent<EnemyBody>();
					if (this.ReturnBool(this.playerNumber, this.skillNumber, component2) == 1)
					{
						if (this.mineSW)
						{
							float f2 = Mathf.Round(this.iNT * this.sWDamage * this.berserk);
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
						Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x2 = vector2.x;
						float y2 = vector2.y;
						switch (this.lvl)
						{
						case 1:
							component2.RPCActionDamageNitensu(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 2:
							component2.RPCActionDamageNitensu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 3:
							component2.RPCActionDamageNitensu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 4:
							component2.RPCActionDamageNitensu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 5:
							component2.RPCActionDamageNitensu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 6:
							component2.RPCActionDamageNitensu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 7:
							component2.RPCActionDamageNitensu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 8:
							component2.RPCActionDamageNitensu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 9:
							component2.RPCActionDamageNitensu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						}
						component2.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
				else if (other.tag == "EnemyBodyAttackBoss01")
				{
					Boss01BodyDetect component3 = other.GetComponent<Boss01BodyDetect>();
					EnemyBody component4 = other.transform.parent.parent.GetComponent<EnemyBody>();
					if (this.ReturnBool(this.playerNumber, this.skillNumber, component4) == 1)
					{
						if (this.mineSW)
						{
							float f3 = Mathf.Round(this.iNT * this.sWDamage * this.berserk);
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
						Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x3 = vector3.x;
						float y3 = vector3.y;
						switch (this.lvl)
						{
						case 1:
							component3.ActionDamageNitensu(this.iNT * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 2:
							component3.ActionDamageNitensu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 3:
							component3.ActionDamageNitensu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 4:
							component3.ActionDamageNitensu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 5:
							component3.ActionDamageNitensu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 6:
							component3.ActionDamageNitensu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 7:
							component3.ActionDamageNitensu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 8:
							component3.ActionDamageNitensu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 9:
							component3.ActionDamageNitensu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						}
						component4.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
			}
		}

		// Token: 0x06001C51 RID: 7249 RVA: 0x001E4CC8 File Offset: 0x001E2EC8
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (currentAnimatorStateInfo.fullPathHash == AgonySphere.ANISTS_Out && currentAnimatorStateInfo.normalizedTime > 1f)
			{
				this.GameObjectFalse();
			}
			if (!this.destroyCheck)
			{
				if (base.transform.localScale.x > 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, base.GetComponent<Rigidbody2D>().velocity.y);
				}
				else if (base.transform.localScale.x < 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, base.GetComponent<Rigidbody2D>().velocity.y);
				}
				if (this.grounded)
				{
					this.animator.SetTrigger("Break");
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
					this.destroyCheck = true;
				}
				else if (!this.grounded)
				{
					this.timer += Time.deltaTime;
				}
				if (this.timer > 8f)
				{
					this.animator.SetTrigger("Break");
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
					this.destroyCheck = true;
				}
			}
		}

		// Token: 0x06001C52 RID: 7250 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x06001C53 RID: 7251 RVA: 0x001E4E44 File Offset: 0x001E3044
		public void Action()
		{
			this.animator.ResetTrigger("Break");
			this.animator.Play("AgonySphere_Spawn", 0, 0f);
			this.timer = 0f;
			this.grounded = false;
			this.destroyCheck = false;
		}

		// Token: 0x06001C54 RID: 7252 RVA: 0x001E4E90 File Offset: 0x001E3090
		private int ReturnBool(int num, int skillNum, EnemyBody targetEnemyBody)
		{
			int num2 = 0;
			switch (num)
			{
			case 1:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft)
					{
						num2++;
					}
					break;
				}
				break;
			case 2:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp1)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown1)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight1)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft1)
					{
						num2++;
					}
					break;
				}
				break;
			case 3:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp2)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown2)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight2)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft2)
					{
						num2++;
					}
					break;
				}
				break;
			case 4:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp3)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown3)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight3)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft3)
					{
						num2++;
					}
					break;
				}
				break;
			case 5:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp4)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown4)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight4)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft4)
					{
						num2++;
					}
					break;
				}
				break;
			case 6:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp5)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown5)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight5)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft5)
					{
						num2++;
					}
					break;
				}
				break;
			case 7:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp6)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown6)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight6)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft6)
					{
						num2++;
					}
					break;
				}
				break;
			case 8:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp7)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown7)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight7)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft7)
					{
						num2++;
					}
					break;
				}
				break;
			case 9:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp8)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown8)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight8)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft8)
					{
						num2++;
					}
					break;
				}
				break;
			case 10:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp9)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown9)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight9)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft9)
					{
						num2++;
					}
					break;
				}
				break;
			}
			return num2;
		}

		// Token: 0x06001C55 RID: 7253 RVA: 0x001E5349 File Offset: 0x001E3549
		public void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04002E72 RID: 11890
		public static readonly int ANISTS_Out = Animator.StringToHash("Base Layer.AgonySphere_Out");

		// Token: 0x04002E73 RID: 11891
		private PlayerStatus playerStatus;

		// Token: 0x04002E74 RID: 11892
		public InstantiateManager instantiateManager;

		// Token: 0x04002E75 RID: 11893
		private CircleCollider2D col2d;

		// Token: 0x04002E76 RID: 11894
		private AudioSource audioS;

		// Token: 0x04002E77 RID: 11895
		private Animator animator;

		// Token: 0x04002E78 RID: 11896
		private EnemySoundEffect eSE;

		// Token: 0x04002E79 RID: 11897
		public float timer;

		// Token: 0x04002E7A RID: 11898
		public int lvl;

		// Token: 0x04002E7B RID: 11899
		public float iNT;

		// Token: 0x04002E7C RID: 11900
		public float dEX;

		// Token: 0x04002E7D RID: 11901
		public float sWDamage;

		// Token: 0x04002E7E RID: 11902
		public float berserk;

		// Token: 0x04002E7F RID: 11903
		public bool mineSW;

		// Token: 0x04002E80 RID: 11904
		public bool destroyCheck;

		// Token: 0x04002E81 RID: 11905
		public bool enemySW;

		// Token: 0x04002E82 RID: 11906
		public int playerNumber;

		// Token: 0x04002E83 RID: 11907
		public int skillNumber;

		// Token: 0x04002E84 RID: 11908
		public float returnTime = 0.3f;
	}
}
