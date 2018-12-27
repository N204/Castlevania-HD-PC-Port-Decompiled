using System;
using System.Collections;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200036F RID: 879
	public class Cross : MagicMain
	{
		// Token: 0x06001DDC RID: 7644 RVA: 0x002349D4 File Offset: 0x00232BD4
		protected override void Awake()
		{
			base.Awake();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.col2d = base.GetComponent<CircleCollider2D>();
			this.spriteSrc = base.transform.Find("Sprite").GetComponent<SpriteRenderer>();
			this.animator = base.GetComponent<Animator>();
			this.eSe = base.GetComponent<EnemySoundEffect>();
		}

		// Token: 0x06001DDD RID: 7645 RVA: 0x00234A3C File Offset: 0x00232C3C
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!this.enemySW)
			{
				if (other.tag == "EnemyShield")
				{
					this.grounded = true;
				}
				else if (other.tag == "DestroyObject")
				{
					this.grounded = true;
				}
				if (other.tag == "PlayerBodyEvent")
				{
					PhotonView component = other.transform.parent.GetComponent<PhotonView>();
					if (component.isMine && this.turned)
					{
						this.GameObjectFalse();
					}
				}
				else if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
				{
					EnemyBody component2 = other.transform.parent.GetComponent<EnemyBody>();
					if (this.ReturnBool(this.playerNumber, this.skillNumber, component2) == 1)
					{
						if (this.mineSW)
						{
							float f = Mathf.Round(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk);
							int num = Mathf.RoundToInt(f);
							if (num < 1)
							{
								num = 1;
							}
							this.playerStatus.damage += num;
							if (!component2.ownATKHitted)
							{
								component2.ownATKHitted = true;
							}
						}
						this.ExpPlus(component2.enemyLevel);
						Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x = vector.x;
						float y = vector.y;
						switch (this.lvl)
						{
						case 1:
							component2.RPCActionDamageCross(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 2:
							component2.RPCActionDamageCross(this.iNT * 1.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 3:
							component2.RPCActionDamageCross(this.iNT * 1.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 4:
							component2.RPCActionDamageCross(this.iNT * 1.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 5:
							component2.RPCActionDamageCross(this.iNT * 1.8f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 6:
							component2.RPCActionDamageCross(this.iNT * 2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 7:
							component2.RPCActionDamageCross(this.iNT * 2.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 8:
							component2.RPCActionDamageCross(this.iNT * 2.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 9:
							component2.RPCActionDamageCross(this.iNT * 2.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						}
						component2.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
				else if (other.tag == "EnemyBodyAttackSp")
				{
					EnemyBody component3 = other.transform.parent.parent.GetComponent<EnemyBody>();
					if (this.ReturnBool(this.playerNumber, this.skillNumber, component3) == 1)
					{
						if (this.mineSW)
						{
							float f2 = Mathf.Round(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk);
							int num2 = Mathf.RoundToInt(f2);
							if (num2 < 1)
							{
								num2 = 1;
							}
							this.playerStatus.damage += num2;
							if (!component3.ownATKHitted)
							{
								component3.ownATKHitted = true;
							}
						}
						this.ExpPlus(component3.enemyLevel);
						Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x2 = vector2.x;
						float y2 = vector2.y;
						switch (this.lvl)
						{
						case 1:
							component3.RPCActionDamageCross(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 2:
							component3.RPCActionDamageCross(this.iNT * 1.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 3:
							component3.RPCActionDamageCross(this.iNT * 1.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 4:
							component3.RPCActionDamageCross(this.iNT * 1.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 5:
							component3.RPCActionDamageCross(this.iNT * 1.8f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 6:
							component3.RPCActionDamageCross(this.iNT * 2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 7:
							component3.RPCActionDamageCross(this.iNT * 2.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 8:
							component3.RPCActionDamageCross(this.iNT * 2.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 9:
							component3.RPCActionDamageCross(this.iNT * 2.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						}
						component3.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
				else if (other.tag == "EnemyBodyAttackBoss01")
				{
					Boss01BodyDetect component4 = other.GetComponent<Boss01BodyDetect>();
					EnemyBody component5 = other.transform.parent.parent.GetComponent<EnemyBody>();
					if (this.ReturnBool(this.playerNumber, this.skillNumber, component5) == 1)
					{
						if (this.mineSW)
						{
							float f3 = Mathf.Round(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk);
							int num3 = Mathf.RoundToInt(f3);
							if (num3 < 1)
							{
								num3 = 1;
							}
							this.playerStatus.damage += num3;
							if (!component5.ownATKHitted)
							{
								component5.ownATKHitted = true;
							}
						}
						this.ExpPlus(component4.enemyLevel);
						Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x3 = vector3.x;
						float y3 = vector3.y;
						switch (this.lvl)
						{
						case 1:
							component4.ActionDamageCross(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 2:
							component4.ActionDamageCross(this.iNT * 1.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 3:
							component4.ActionDamageCross(this.iNT * 1.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 4:
							component4.ActionDamageCross(this.iNT * 1.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 5:
							component4.ActionDamageCross(this.iNT * 1.8f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 6:
							component4.ActionDamageCross(this.iNT * 2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 7:
							component4.ActionDamageCross(this.iNT * 2.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 8:
							component4.ActionDamageCross(this.iNT * 2.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 9:
							component4.ActionDamageCross(this.iNT * 2.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						}
						component5.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
			}
		}

		// Token: 0x06001DDE RID: 7646 RVA: 0x00235498 File Offset: 0x00233698
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
							float f = Mathf.Round(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk);
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
						switch (this.lvl)
						{
						case 1:
							component.RPCActionDamageCross(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 2:
							component.RPCActionDamageCross(this.iNT * 1.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 3:
							component.RPCActionDamageCross(this.iNT * 1.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 4:
							component.RPCActionDamageCross(this.iNT * 1.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 5:
							component.RPCActionDamageCross(this.iNT * 1.8f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 6:
							component.RPCActionDamageCross(this.iNT * 2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 7:
							component.RPCActionDamageCross(this.iNT * 2.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 8:
							component.RPCActionDamageCross(this.iNT * 2.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 9:
							component.RPCActionDamageCross(this.iNT * 2.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x, y);
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
							float f2 = Mathf.Round(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk);
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
						switch (this.lvl)
						{
						case 1:
							component2.RPCActionDamageCross(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 2:
							component2.RPCActionDamageCross(this.iNT * 1.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 3:
							component2.RPCActionDamageCross(this.iNT * 1.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 4:
							component2.RPCActionDamageCross(this.iNT * 1.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 5:
							component2.RPCActionDamageCross(this.iNT * 1.8f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 6:
							component2.RPCActionDamageCross(this.iNT * 2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 7:
							component2.RPCActionDamageCross(this.iNT * 2.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 8:
							component2.RPCActionDamageCross(this.iNT * 2.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 9:
							component2.RPCActionDamageCross(this.iNT * 2.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x2, y2);
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
							float f3 = Mathf.Round(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk);
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
						switch (this.lvl)
						{
						case 1:
							component3.ActionDamageCross(this.iNT * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 2:
							component3.ActionDamageCross(this.iNT * 1.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 3:
							component3.ActionDamageCross(this.iNT * 1.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 4:
							component3.ActionDamageCross(this.iNT * 1.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 5:
							component3.ActionDamageCross(this.iNT * 1.8f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 6:
							component3.ActionDamageCross(this.iNT * 2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 7:
							component3.ActionDamageCross(this.iNT * 2.2f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 8:
							component3.ActionDamageCross(this.iNT * 2.4f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 9:
							component3.ActionDamageCross(this.iNT * 2.6f * this.sTAUROLITE * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						}
						component4.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
			}
		}

		// Token: 0x06001DDF RID: 7647 RVA: 0x00235E70 File Offset: 0x00234070
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (!this.grounded && currentAnimatorStateInfo.fullPathHash == Cross.ANISTS_Idle)
			{
				this.timer += Time.deltaTime;
				if (base.transform.localScale.x > 0f)
				{
					if (this.timer < 1f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(3.5f, 0f);
					}
					else if (this.timer >= 1f && this.timer < 1.15f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 0f);
					}
					else if (this.timer >= 1.15f && this.timer < 1.3f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 0f);
					}
					else if (this.timer >= 1.3f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.5f, 0f);
						this.turned = true;
					}
				}
				else if (base.transform.localScale.x < 0f)
				{
					if (this.timer < 1f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.5f, 0f);
					}
					else if (this.timer >= 1f && this.timer < 1.15f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 0f);
					}
					else if (this.timer >= 1.15f && this.timer < 1.3f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 0f);
					}
					else if (this.timer >= 1.3f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(3.5f, 0f);
						this.turned = true;
					}
				}
				if (this.timer > 2.5f && !this.destroyCheck)
				{
					this.animator.SetTrigger("FadeOut");
					this.destroyCheck = true;
				}
			}
			if (this.grounded && currentAnimatorStateInfo.fullPathHash == Cross.ANISTS_Idle)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
				this.animator.SetTrigger("EndLife");
			}
		}

		// Token: 0x06001DE0 RID: 7648 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x06001DE1 RID: 7649 RVA: 0x0023612C File Offset: 0x0023432C
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

		// Token: 0x06001DE2 RID: 7650 RVA: 0x002365E8 File Offset: 0x002347E8
		private void ExpPlus(int lvl)
		{
			if (this.mineSW)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expCross += 1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expCross += 2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expCross += 3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expCross += 4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expCross += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expCross += 6f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x06001DE3 RID: 7651 RVA: 0x00236713 File Offset: 0x00234913
		public void AfterImageEnabled()
		{
			this.afterImageEnabled = true;
		}

		// Token: 0x06001DE4 RID: 7652 RVA: 0x0023671C File Offset: 0x0023491C
		public void AfterImageDisabled()
		{
			this.afterImageEnabled = false;
		}

		// Token: 0x06001DE5 RID: 7653 RVA: 0x00236728 File Offset: 0x00234928
		private IEnumerator AfterImageUpdate()
		{
			for (;;)
			{
				while (this.afterImageEnabled)
				{
					SpriteRenderer spriteCopy = UnityEngine.Object.Instantiate<SpriteRenderer>(this.spriteSrc);
					spriteCopy.transform.position = this.spriteSrc.transform.position;
					spriteCopy.transform.localScale = new Vector2(1.91f, 1.91f);
					spriteCopy.color = new Color(1f, 1f, 1f, 0.2f);
					spriteCopy.sortingLayerName = "ObjectFront";
					spriteCopy.sortingOrder = -1;
					SpriteRenderer[] spList = spriteCopy.GetComponentsInChildren<SpriteRenderer>();
					foreach (SpriteRenderer spriteRenderer in spList)
					{
						if (spriteRenderer.name == "Shadow")
						{
							spriteRenderer.enabled = false;
						}
					}
					UnityEngine.Object.Destroy(spriteCopy.gameObject, 0.3f);
					yield return new WaitForSeconds(0.05f);
				}
				yield return new WaitForSeconds(1f);
			}
			yield break;
		}

		// Token: 0x06001DE6 RID: 7654 RVA: 0x00236744 File Offset: 0x00234944
		public void Action()
		{
			this.eSe.SoundEffectPlay(0);
			this.grounded = false;
			this.destroyCheck = false;
			this.turned = false;
			this.timer = 0f;
			this.animator.ResetTrigger("EndLife");
			this.animator.ResetTrigger("FadeOut");
			this.animator.Play("Cross_Idle");
		}

		// Token: 0x06001DE7 RID: 7655 RVA: 0x002367B0 File Offset: 0x002349B0
		public void ActionAfterImage()
		{
			if (!this.destroyCheck)
			{
				if (base.transform.localScale.x > 0f)
				{
					int num = this.crossLevel;
					if (num != 1)
					{
						if (num == 2)
						{
							this.instantiateManager.CrossAfterImage2(this.spriteSrc.transform.position.x, this.spriteSrc.transform.position.y, this.spriteSrc.transform.rotation.eulerAngles.z, 0);
						}
					}
					else
					{
						this.instantiateManager.CrossAfterImage(this.spriteSrc.transform.position.x, this.spriteSrc.transform.position.y, this.spriteSrc.transform.rotation.eulerAngles.z, 0);
					}
				}
				else if (base.transform.localScale.x < 0f)
				{
					int num2 = this.crossLevel;
					if (num2 != 1)
					{
						if (num2 == 2)
						{
							this.instantiateManager.CrossAfterImage2(this.spriteSrc.transform.position.x, this.spriteSrc.transform.position.y, this.spriteSrc.transform.rotation.eulerAngles.z, 1);
						}
					}
					else
					{
						this.instantiateManager.CrossAfterImage(this.spriteSrc.transform.position.x, this.spriteSrc.transform.position.y, this.spriteSrc.transform.rotation.eulerAngles.z, 1);
					}
				}
			}
		}

		// Token: 0x06001DE8 RID: 7656 RVA: 0x0015DDED File Offset: 0x0015BFED
		public void DestroyCall()
		{
			base.Invoke("GameObjectFalse", 0.5f);
		}

		// Token: 0x06001DE9 RID: 7657 RVA: 0x002369D5 File Offset: 0x00234BD5
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04003226 RID: 12838
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Cross_Idle");

		// Token: 0x04003227 RID: 12839
		public bool afterImageEnabled;

		// Token: 0x04003228 RID: 12840
		public bool turned;

		// Token: 0x04003229 RID: 12841
		[NonSerialized]
		public Animator animator;

		// Token: 0x0400322A RID: 12842
		private SpriteRenderer spriteSrc;

		// Token: 0x0400322B RID: 12843
		private CircleCollider2D col2d;

		// Token: 0x0400322C RID: 12844
		public PhotonView myPV;

		// Token: 0x0400322D RID: 12845
		private PlayerStatus playerStatus;

		// Token: 0x0400322E RID: 12846
		public GameObject ownerObj;

		// Token: 0x0400322F RID: 12847
		public bool enemySW;

		// Token: 0x04003230 RID: 12848
		public InstantiateManager instantiateManager;

		// Token: 0x04003231 RID: 12849
		private EnemySoundEffect eSe;

		// Token: 0x04003232 RID: 12850
		public float timer;

		// Token: 0x04003233 RID: 12851
		public bool destroyCheck;

		// Token: 0x04003234 RID: 12852
		public int lvl;

		// Token: 0x04003235 RID: 12853
		public float iNT;

		// Token: 0x04003236 RID: 12854
		public float dEX;

		// Token: 0x04003237 RID: 12855
		public float sWDamage;

		// Token: 0x04003238 RID: 12856
		public float berserk;

		// Token: 0x04003239 RID: 12857
		public float sTAUROLITE;

		// Token: 0x0400323A RID: 12858
		public bool mineSW;

		// Token: 0x0400323B RID: 12859
		public int playerNumber;

		// Token: 0x0400323C RID: 12860
		public float returnTime = 0.3f;

		// Token: 0x0400323D RID: 12861
		public int skillNumber;

		// Token: 0x0400323E RID: 12862
		public int crossLevel;
	}
}
