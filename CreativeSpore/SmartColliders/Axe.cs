using System;
using System.Collections;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000369 RID: 873
	public class Axe : MagicMain
	{
		// Token: 0x06001D9A RID: 7578 RVA: 0x0022DCBC File Offset: 0x0022BEBC
		protected override void Awake()
		{
			base.Awake();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.col2d = base.GetComponent<CircleCollider2D>();
			this.spriteSrc = base.transform.Find("Sprite").GetComponent<SpriteRenderer>();
			this.animator = base.GetComponent<Animator>();
			this.eSe = base.GetComponent<EnemySoundEffect>();
		}

		// Token: 0x06001D9B RID: 7579 RVA: 0x0022DD24 File Offset: 0x0022BF24
		private void OnTriggerEnter2D(Collider2D other)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (this.enemySW)
			{
				if ((other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && currentAnimatorStateInfo.fullPathHash == Axe.ANISTS_Idle)
				{
					this.isBreak = true;
					base.GetComponent<Rigidbody2D>().simulated = false;
					this.animator.SetTrigger("EndLife");
				}
			}
			else if (!this.enemySW)
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
						this.ExpPlus(component.enemyLevel);
						Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x = vector.x;
						float y = vector.y;
						switch (this.lvl)
						{
						case 1:
							component.RPCActionDamageAxe(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 2:
							component.RPCActionDamageAxe(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 3:
							component.RPCActionDamageAxe(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 4:
							component.RPCActionDamageAxe(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 5:
							component.RPCActionDamageAxe(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 6:
							component.RPCActionDamageAxe(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 7:
							component.RPCActionDamageAxe(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 8:
							component.RPCActionDamageAxe(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 9:
							component.RPCActionDamageAxe(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
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
						this.ExpPlus(component2.enemyLevel);
						Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x2 = vector2.x;
						float y2 = vector2.y;
						switch (this.lvl)
						{
						case 1:
							component2.RPCActionDamageAxe(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 2:
							component2.RPCActionDamageAxe(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 3:
							component2.RPCActionDamageAxe(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 4:
							component2.RPCActionDamageAxe(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 5:
							component2.RPCActionDamageAxe(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 6:
							component2.RPCActionDamageAxe(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 7:
							component2.RPCActionDamageAxe(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 8:
							component2.RPCActionDamageAxe(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 9:
							component2.RPCActionDamageAxe(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
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
						this.ExpPlus(component3.enemyLevel);
						Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x3 = vector3.x;
						float y3 = vector3.y;
						switch (this.lvl)
						{
						case 1:
							component3.ActionDamageAxe(this.iNT * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 2:
							component3.ActionDamageAxe(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 3:
							component3.ActionDamageAxe(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 4:
							component3.ActionDamageAxe(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 5:
							component3.ActionDamageAxe(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 6:
							component3.ActionDamageAxe(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 7:
							component3.ActionDamageAxe(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 8:
							component3.ActionDamageAxe(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 9:
							component3.ActionDamageAxe(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						}
						component4.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
			}
		}

		// Token: 0x06001D9C RID: 7580 RVA: 0x0022E85C File Offset: 0x0022CA5C
		private void OnTriggerStay2D(Collider2D other)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (this.enemySW)
			{
				if ((other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && currentAnimatorStateInfo.fullPathHash == Axe.ANISTS_Idle)
				{
					this.isBreak = true;
					base.GetComponent<Rigidbody2D>().simulated = false;
					this.animator.SetTrigger("EndLife");
				}
			}
			else if (!this.enemySW)
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
						this.ExpPlus(component.enemyLevel);
						Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x = vector.x;
						float y = vector.y;
						switch (this.lvl)
						{
						case 1:
							component.RPCActionDamageAxe(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 2:
							component.RPCActionDamageAxe(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 3:
							component.RPCActionDamageAxe(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 4:
							component.RPCActionDamageAxe(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 5:
							component.RPCActionDamageAxe(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 6:
							component.RPCActionDamageAxe(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 7:
							component.RPCActionDamageAxe(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 8:
							component.RPCActionDamageAxe(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 9:
							component.RPCActionDamageAxe(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
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
						this.ExpPlus(component2.enemyLevel);
						Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x2 = vector2.x;
						float y2 = vector2.y;
						switch (this.lvl)
						{
						case 1:
							component2.RPCActionDamageAxe(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 2:
							component2.RPCActionDamageAxe(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 3:
							component2.RPCActionDamageAxe(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 4:
							component2.RPCActionDamageAxe(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 5:
							component2.RPCActionDamageAxe(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 6:
							component2.RPCActionDamageAxe(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 7:
							component2.RPCActionDamageAxe(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 8:
							component2.RPCActionDamageAxe(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 9:
							component2.RPCActionDamageAxe(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
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
						this.ExpPlus(component3.enemyLevel);
						Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x3 = vector3.x;
						float y3 = vector3.y;
						switch (this.lvl)
						{
						case 1:
							component3.ActionDamageAxe(this.iNT * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 2:
							component3.ActionDamageAxe(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 3:
							component3.ActionDamageAxe(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 4:
							component3.ActionDamageAxe(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 5:
							component3.ActionDamageAxe(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 6:
							component3.ActionDamageAxe(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 7:
							component3.ActionDamageAxe(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 8:
							component3.ActionDamageAxe(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 9:
							component3.ActionDamageAxe(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						}
						component4.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
					}
				}
			}
		}

		// Token: 0x06001D9D RID: 7581 RVA: 0x0022F358 File Offset: 0x0022D558
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (base.GetComponent<Rigidbody2D>().velocity.y < -6f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, -6f);
			}
			this.timer += Time.deltaTime;
			if (this.timer > 5f && currentAnimatorStateInfo.fullPathHash == Axe.ANISTS_Idle && !this.destroyCheck)
			{
				this.animator.SetTrigger("FadeOut");
				this.destroyCheck = true;
			}
			if (this.grounded && currentAnimatorStateInfo.fullPathHash == Axe.ANISTS_Idle)
			{
				this.isBreak = true;
				base.GetComponent<Rigidbody2D>().simulated = false;
				this.animator.SetTrigger("EndLife");
			}
		}

		// Token: 0x06001D9E RID: 7582 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x06001D9F RID: 7583 RVA: 0x0022F44C File Offset: 0x0022D64C
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

		// Token: 0x06001DA0 RID: 7584 RVA: 0x0022F908 File Offset: 0x0022DB08
		private void ExpPlus(int lvl)
		{
			if (this.mineSW)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expAxe += 1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expAxe += 2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expAxe += 3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expAxe += 4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expAxe += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expAxe += 6f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x06001DA1 RID: 7585 RVA: 0x0022FA33 File Offset: 0x0022DC33
		public void AfterImageEnabled()
		{
			this.afterImageEnabled = true;
		}

		// Token: 0x06001DA2 RID: 7586 RVA: 0x0022FA3C File Offset: 0x0022DC3C
		public void AfterImageDisabled()
		{
			this.afterImageEnabled = false;
		}

		// Token: 0x06001DA3 RID: 7587 RVA: 0x0022FA48 File Offset: 0x0022DC48
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

		// Token: 0x06001DA4 RID: 7588 RVA: 0x0022FA63 File Offset: 0x0022DC63
		public void SoundEffectCall(int num)
		{
			if (!this.isBreak)
			{
				this.eSe.SoundEffectPlay(0);
			}
		}

		// Token: 0x06001DA5 RID: 7589 RVA: 0x0022FA7C File Offset: 0x0022DC7C
		public void Action()
		{
			base.GetComponent<Rigidbody2D>().simulated = true;
			this.grounded = false;
			this.destroyCheck = false;
			this.isBreak = false;
			this.timer = 0f;
			this.animator.ResetTrigger("EndLife");
			this.animator.ResetTrigger("FadeOut");
			this.animator.Play("Axe_Idle");
			if (base.transform.localScale.x > 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(1.5f, 6f);
			}
			else if (base.transform.localScale.x < 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, 6f);
			}
		}

		// Token: 0x06001DA6 RID: 7590 RVA: 0x0022FB58 File Offset: 0x0022DD58
		public void ActionAfterImage()
		{
			if (!this.isBreak)
			{
				if (base.transform.localScale.x > 0f)
				{
					int num = this.axeLevel;
					if (num != 1)
					{
						if (num != 2)
						{
							if (num == 3)
							{
								this.instantiateManager.AxeAfterImage3(this.spriteSrc.transform.position.x, this.spriteSrc.transform.position.y, this.spriteSrc.transform.rotation.eulerAngles.z, 0);
							}
						}
						else
						{
							this.instantiateManager.AxeAfterImage2(this.spriteSrc.transform.position.x, this.spriteSrc.transform.position.y, this.spriteSrc.transform.rotation.eulerAngles.z, 0);
						}
					}
					else
					{
						this.instantiateManager.AxeAfterImage(this.spriteSrc.transform.position.x, this.spriteSrc.transform.position.y, this.spriteSrc.transform.rotation.eulerAngles.z, 0);
					}
				}
				else if (base.transform.localScale.x < 0f)
				{
					int num2 = this.axeLevel;
					if (num2 != 1)
					{
						if (num2 != 2)
						{
							if (num2 == 3)
							{
								this.instantiateManager.AxeAfterImage3(this.spriteSrc.transform.position.x, this.spriteSrc.transform.position.y, this.spriteSrc.transform.rotation.eulerAngles.z, 1);
							}
						}
						else
						{
							this.instantiateManager.AxeAfterImage2(this.spriteSrc.transform.position.x, this.spriteSrc.transform.position.y, this.spriteSrc.transform.rotation.eulerAngles.z, 1);
						}
					}
					else
					{
						this.instantiateManager.AxeAfterImage(this.spriteSrc.transform.position.x, this.spriteSrc.transform.position.y, this.spriteSrc.transform.rotation.eulerAngles.z, 1);
					}
				}
			}
		}

		// Token: 0x06001DA7 RID: 7591 RVA: 0x0008FD35 File Offset: 0x0008DF35
		public void DestroyCall()
		{
			base.Invoke("GameObjectFalse", 0.2f);
		}

		// Token: 0x06001DA8 RID: 7592 RVA: 0x0022FE58 File Offset: 0x0022E058
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x040031C5 RID: 12741
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Axe_Idle");

		// Token: 0x040031C6 RID: 12742
		public bool afterImageEnabled;

		// Token: 0x040031C7 RID: 12743
		[NonSerialized]
		public Animator animator;

		// Token: 0x040031C8 RID: 12744
		private SpriteRenderer spriteSrc;

		// Token: 0x040031C9 RID: 12745
		private CircleCollider2D col2d;

		// Token: 0x040031CA RID: 12746
		private PlayerStatus playerStatus;

		// Token: 0x040031CB RID: 12747
		private EnemySoundEffect eSe;

		// Token: 0x040031CC RID: 12748
		public GameObject ownerObj;

		// Token: 0x040031CD RID: 12749
		public bool enemySW;

		// Token: 0x040031CE RID: 12750
		public int lvl;

		// Token: 0x040031CF RID: 12751
		public float iNT;

		// Token: 0x040031D0 RID: 12752
		public float dEX;

		// Token: 0x040031D1 RID: 12753
		public float sWDamage;

		// Token: 0x040031D2 RID: 12754
		public float berserk;

		// Token: 0x040031D3 RID: 12755
		public InstantiateManager instantiateManager;

		// Token: 0x040031D4 RID: 12756
		public float timer;

		// Token: 0x040031D5 RID: 12757
		public bool destroyCheck;

		// Token: 0x040031D6 RID: 12758
		public bool isBreak;

		// Token: 0x040031D7 RID: 12759
		public bool mineSW;

		// Token: 0x040031D8 RID: 12760
		public int playerNumber;

		// Token: 0x040031D9 RID: 12761
		public float returnTime = 0.3f;

		// Token: 0x040031DA RID: 12762
		public int skillNumber;

		// Token: 0x040031DB RID: 12763
		public int axeLevel;
	}
}
