using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200036E RID: 878
	public class Bumeran : MagicMain
	{
		// Token: 0x06001DD0 RID: 7632 RVA: 0x00232DEB File Offset: 0x00230FEB
		protected override void Awake()
		{
			base.Awake();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.animator = base.GetComponent<Animator>();
			this.eSe = base.GetComponent<EnemySoundEffect>();
		}

		// Token: 0x06001DD1 RID: 7633 RVA: 0x00232E20 File Offset: 0x00231020
		private void OnTriggerEnter2D(Collider2D other)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
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

		// Token: 0x06001DD2 RID: 7634 RVA: 0x00233764 File Offset: 0x00231964
		private void OnTriggerStay2D(Collider2D other)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
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

		// Token: 0x06001DD3 RID: 7635 RVA: 0x0023406C File Offset: 0x0023226C
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			this.timer += Time.deltaTime;
			if (this.timer > 5f && currentAnimatorStateInfo.fullPathHash == Bumeran.ANISTS_Idle && !this.destroyCheck)
			{
				this.animator.SetTrigger("Break");
				this.destroyCheck = true;
			}
			if (this.grounded && currentAnimatorStateInfo.fullPathHash == Bumeran.ANISTS_Idle)
			{
				this.isBreak = true;
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, 2f);
				base.GetComponent<Rigidbody2D>().simulated = false;
				this.animator.SetTrigger("Break");
			}
			if (currentAnimatorStateInfo.fullPathHash == Bumeran.ANISTS_Idle)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(this.veloX, this.veloY);
			}
			if (currentAnimatorStateInfo.fullPathHash == Bumeran.ANISTS_Break && currentAnimatorStateInfo.normalizedTime > 1f)
			{
				this.GameObjectFalse();
			}
			if (base.transform.localScale.x > 0f)
			{
				if (this.veloX > -5f)
				{
					this.veloX -= this.tyouseiX;
				}
				if (this.timer < 1f)
				{
					this.veloY += this.tyouseiY;
				}
				else if (this.timer >= 1f && this.veloY > -4f)
				{
					this.veloY -= this.tyouseiY;
				}
			}
			else if (base.transform.localScale.x < 0f)
			{
				if (this.veloX < 5f)
				{
					this.veloX += this.tyouseiX;
				}
				if (this.timer < 1f)
				{
					this.veloY += this.tyouseiY;
				}
				else if (this.timer >= 1f && this.veloY > -4f)
				{
					this.veloY -= this.tyouseiY;
				}
			}
		}

		// Token: 0x06001DD4 RID: 7636 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x06001DD5 RID: 7637 RVA: 0x002342D4 File Offset: 0x002324D4
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

		// Token: 0x06001DD6 RID: 7638 RVA: 0x00234790 File Offset: 0x00232990
		private void ExpPlus(int lvl)
		{
			if (this.mineSW)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expBumeran += 1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expBumeran += 2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expBumeran += 3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expBumeran += 4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expBumeran += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expBumeran += 6f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x06001DD7 RID: 7639 RVA: 0x002348BB File Offset: 0x00232ABB
		public void SoundEffectCall(int num)
		{
			if (!this.isBreak)
			{
				this.eSe.SoundEffectPlay(0);
			}
		}

		// Token: 0x06001DD8 RID: 7640 RVA: 0x002348D4 File Offset: 0x00232AD4
		public void Action()
		{
			base.GetComponent<Rigidbody2D>().simulated = true;
			this.grounded = false;
			this.destroyCheck = false;
			this.isBreak = false;
			this.timer = 0f;
			this.animator.ResetTrigger("Break");
			this.animator.Play("Bumeran_Idle");
			this.veloY = 0f;
			if (base.transform.localScale.x > 0f)
			{
				this.veloX = 5f;
			}
			else if (base.transform.localScale.x < 0f)
			{
				this.veloX = -5f;
			}
		}

		// Token: 0x06001DD9 RID: 7641 RVA: 0x0023498D File Offset: 0x00232B8D
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04003210 RID: 12816
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Bumeran_Idle");

		// Token: 0x04003211 RID: 12817
		public static readonly int ANISTS_Break = Animator.StringToHash("Base Layer.Bumeran_Break");

		// Token: 0x04003212 RID: 12818
		[NonSerialized]
		public Animator animator;

		// Token: 0x04003213 RID: 12819
		private PlayerStatus playerStatus;

		// Token: 0x04003214 RID: 12820
		private EnemySoundEffect eSe;

		// Token: 0x04003215 RID: 12821
		public int lvl;

		// Token: 0x04003216 RID: 12822
		public float iNT;

		// Token: 0x04003217 RID: 12823
		public float dEX;

		// Token: 0x04003218 RID: 12824
		public float sWDamage;

		// Token: 0x04003219 RID: 12825
		public float berserk;

		// Token: 0x0400321A RID: 12826
		public InstantiateManager instantiateManager;

		// Token: 0x0400321B RID: 12827
		public float timer;

		// Token: 0x0400321C RID: 12828
		public bool destroyCheck;

		// Token: 0x0400321D RID: 12829
		public bool isBreak;

		// Token: 0x0400321E RID: 12830
		public bool mineSW;

		// Token: 0x0400321F RID: 12831
		public int playerNumber;

		// Token: 0x04003220 RID: 12832
		public float returnTime = 0.3f;

		// Token: 0x04003221 RID: 12833
		public int skillNumber;

		// Token: 0x04003222 RID: 12834
		public float veloX;

		// Token: 0x04003223 RID: 12835
		public float veloY;

		// Token: 0x04003224 RID: 12836
		public float tyouseiX = 0.05f;

		// Token: 0x04003225 RID: 12837
		public float tyouseiY = 0.05f;
	}
}
