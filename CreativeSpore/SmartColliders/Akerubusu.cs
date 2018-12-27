using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000343 RID: 835
	public class Akerubusu : MagicMain
	{
		// Token: 0x06001C58 RID: 7256 RVA: 0x001E5380 File Offset: 0x001E3580
		protected override void Awake()
		{
			base.Awake();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.animator = base.GetComponent<Animator>();
			this.eSE = base.GetComponent<EnemySoundEffect>();
		}

		// Token: 0x06001C59 RID: 7257 RVA: 0x001E53B8 File Offset: 0x001E35B8
		private void OnTriggerEnter2D(Collider2D other)
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
					if (this.mineSW)
					{
						component.StatusCurseRandom(x, y);
					}
					switch (this.lvl)
					{
					case 1:
						component.RPCActionDamageAkerubusu(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 2:
						component.RPCActionDamageAkerubusu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 3:
						component.RPCActionDamageAkerubusu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 4:
						component.RPCActionDamageAkerubusu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 5:
						component.RPCActionDamageAkerubusu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 6:
						component.RPCActionDamageAkerubusu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 7:
						component.RPCActionDamageAkerubusu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 8:
						component.RPCActionDamageAkerubusu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 9:
						component.RPCActionDamageAkerubusu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
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
					if (this.mineSW)
					{
						component2.StatusCurseRandom(x2, y2);
					}
					switch (this.lvl)
					{
					case 1:
						component2.RPCActionDamageAkerubusu(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 2:
						component2.RPCActionDamageAkerubusu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 3:
						component2.RPCActionDamageAkerubusu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 4:
						component2.RPCActionDamageAkerubusu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 5:
						component2.RPCActionDamageAkerubusu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 6:
						component2.RPCActionDamageAkerubusu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 7:
						component2.RPCActionDamageAkerubusu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 8:
						component2.RPCActionDamageAkerubusu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 9:
						component2.RPCActionDamageAkerubusu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
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
					if (this.mineSW)
					{
						component4.StatusCurseRandom(x3, y3);
					}
					switch (this.lvl)
					{
					case 1:
						component3.ActionDamageAkerubusu(this.iNT * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 2:
						component3.ActionDamageAkerubusu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 3:
						component3.ActionDamageAkerubusu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 4:
						component3.ActionDamageAkerubusu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 5:
						component3.ActionDamageAkerubusu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 6:
						component3.ActionDamageAkerubusu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 7:
						component3.ActionDamageAkerubusu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 8:
						component3.ActionDamageAkerubusu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 9:
						component3.ActionDamageAkerubusu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					}
					component4.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
				}
			}
		}

		// Token: 0x06001C5A RID: 7258 RVA: 0x001E5CF4 File Offset: 0x001E3EF4
		private void OnTriggerStay2D(Collider2D other)
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
					if (this.mineSW)
					{
						component.StatusCurseRandom(x, y);
					}
					switch (this.lvl)
					{
					case 1:
						component.RPCActionDamageAkerubusu(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 2:
						component.RPCActionDamageAkerubusu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 3:
						component.RPCActionDamageAkerubusu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 4:
						component.RPCActionDamageAkerubusu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 5:
						component.RPCActionDamageAkerubusu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 6:
						component.RPCActionDamageAkerubusu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 7:
						component.RPCActionDamageAkerubusu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 8:
						component.RPCActionDamageAkerubusu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 9:
						component.RPCActionDamageAkerubusu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
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
					if (this.mineSW)
					{
						component2.StatusCurseRandom(x2, y2);
					}
					switch (this.lvl)
					{
					case 1:
						component2.RPCActionDamageAkerubusu(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 2:
						component2.RPCActionDamageAkerubusu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 3:
						component2.RPCActionDamageAkerubusu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 4:
						component2.RPCActionDamageAkerubusu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 5:
						component2.RPCActionDamageAkerubusu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 6:
						component2.RPCActionDamageAkerubusu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 7:
						component2.RPCActionDamageAkerubusu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 8:
						component2.RPCActionDamageAkerubusu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 9:
						component2.RPCActionDamageAkerubusu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
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
					if (this.mineSW)
					{
						component4.StatusCurseRandom(x3, y3);
					}
					switch (this.lvl)
					{
					case 1:
						component3.ActionDamageAkerubusu(this.iNT * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 2:
						component3.ActionDamageAkerubusu(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 3:
						component3.ActionDamageAkerubusu(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 4:
						component3.ActionDamageAkerubusu(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 5:
						component3.ActionDamageAkerubusu(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 6:
						component3.ActionDamageAkerubusu(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 7:
						component3.ActionDamageAkerubusu(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 8:
						component3.ActionDamageAkerubusu(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 9:
						component3.ActionDamageAkerubusu(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					}
					component4.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
				}
			}
		}

		// Token: 0x06001C5B RID: 7259 RVA: 0x001E6630 File Offset: 0x001E4830
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (base.transform.localScale.x > 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, base.GetComponent<Rigidbody2D>().velocity.y);
			}
			else if (base.transform.localScale.x < 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, base.GetComponent<Rigidbody2D>().velocity.y);
			}
			this.timer += Time.deltaTime;
			if (this.timer > 0.5f && currentAnimatorStateInfo.fullPathHash == Akerubusu.ANISTS_Idle && !this.destroyCheck)
			{
				this.animator.SetTrigger("EndLife");
				base.Invoke("GameObjectFalse", 1f);
				this.destroyCheck = true;
			}
			if (this.grounded && currentAnimatorStateInfo.fullPathHash == Akerubusu.ANISTS_Idle)
			{
				this.animator.SetTrigger("EndLife");
				base.Invoke("GameObjectFalse", 1f);
				this.destroyCheck = true;
			}
		}

		// Token: 0x06001C5C RID: 7260 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x06001C5D RID: 7261 RVA: 0x001E6784 File Offset: 0x001E4984
		public void Action()
		{
			this.eSE.SoundEffectPlay(0);
			this.grounded = false;
			this.destroyCheck = false;
			this.timer = 0f;
			this.animator.ResetTrigger("EndLife");
			this.animator.Play("Akerubusu_Idle");
			this.ActionAfterImage();
		}

		// Token: 0x06001C5E RID: 7262 RVA: 0x001E67DC File Offset: 0x001E49DC
		public void ActionAfterImage()
		{
			if (!this.destroyCheck)
			{
				if (base.transform.localScale.x > 0f)
				{
					this.instantiateManager.AkerubusuAfterImage(base.transform.position.x, base.transform.position.y, 0);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.instantiateManager.AkerubusuAfterImage(base.transform.position.x, base.transform.position.y, 1);
				}
				base.Invoke("ActionAfterImage", 0.2f);
			}
		}

		// Token: 0x06001C5F RID: 7263 RVA: 0x001E68AC File Offset: 0x001E4AAC
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

		// Token: 0x06001C60 RID: 7264 RVA: 0x001E6D68 File Offset: 0x001E4F68
		private void ExpPlus(int lvl)
		{
			if (this.mineSW)
			{
				if (!this.albusSKill)
				{
					switch (lvl)
					{
					case 0:
						this.playerStatus.expAkerubusu += 1f * this.playerStatus.masterRing;
						break;
					case 1:
						this.playerStatus.expAkerubusu += 2f * this.playerStatus.masterRing;
						break;
					case 2:
						this.playerStatus.expAkerubusu += 3f * this.playerStatus.masterRing;
						break;
					case 3:
						this.playerStatus.expAkerubusu += 4f * this.playerStatus.masterRing;
						break;
					case 4:
						this.playerStatus.expAkerubusu += 5f * this.playerStatus.masterRing;
						break;
					case 5:
						this.playerStatus.expAkerubusu += 6f * this.playerStatus.masterRing;
						break;
					}
				}
				else if (this.albusSKill)
				{
					switch (lvl)
					{
					case 0:
						this.playerStatus.expMaxShot += 1f * this.playerStatus.masterRing;
						break;
					case 1:
						this.playerStatus.expMaxShot += 2f * this.playerStatus.masterRing;
						break;
					case 2:
						this.playerStatus.expMaxShot += 3f * this.playerStatus.masterRing;
						break;
					case 3:
						this.playerStatus.expMaxShot += 4f * this.playerStatus.masterRing;
						break;
					case 4:
						this.playerStatus.expMaxShot += 5f * this.playerStatus.masterRing;
						break;
					case 5:
						this.playerStatus.expMaxShot += 6f * this.playerStatus.masterRing;
						break;
					}
				}
			}
		}

		// Token: 0x06001C61 RID: 7265 RVA: 0x001E6FC1 File Offset: 0x001E51C1
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04002E85 RID: 11909
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Akerubusu_Idle");

		// Token: 0x04002E86 RID: 11910
		[NonSerialized]
		public Animator animator;

		// Token: 0x04002E87 RID: 11911
		private PlayerStatus playerStatus;

		// Token: 0x04002E88 RID: 11912
		public GameObject ownerObj;

		// Token: 0x04002E89 RID: 11913
		public InstantiateManager instantiateManager;

		// Token: 0x04002E8A RID: 11914
		private EnemySoundEffect eSE;

		// Token: 0x04002E8B RID: 11915
		public float timer;

		// Token: 0x04002E8C RID: 11916
		public bool destroyCheck;

		// Token: 0x04002E8D RID: 11917
		public int lvl;

		// Token: 0x04002E8E RID: 11918
		public float iNT;

		// Token: 0x04002E8F RID: 11919
		public float dEX;

		// Token: 0x04002E90 RID: 11920
		public float sWDamage;

		// Token: 0x04002E91 RID: 11921
		public float berserk;

		// Token: 0x04002E92 RID: 11922
		public bool mineSW;

		// Token: 0x04002E93 RID: 11923
		public int playerNumber;

		// Token: 0x04002E94 RID: 11924
		public float returnTime = 0.3f;

		// Token: 0x04002E95 RID: 11925
		public int skillNumber;

		// Token: 0x04002E96 RID: 11926
		public bool albusSKill;
	}
}
