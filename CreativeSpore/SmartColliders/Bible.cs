using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200036B RID: 875
	public class Bible : MonoBehaviour
	{
		// Token: 0x06001DB1 RID: 7601 RVA: 0x0023006D File Offset: 0x0022E26D
		private void Awake()
		{
			this.spriteSrc = base.transform.Find("Sprite").GetComponent<SpriteRenderer>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06001DB2 RID: 7602 RVA: 0x002300AC File Offset: 0x0022E2AC
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
					switch (this.lvl)
					{
					case 1:
						component.RPCActionDamageBible(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 2:
						component.RPCActionDamageBible(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 3:
						component.RPCActionDamageBible(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 4:
						component.RPCActionDamageBible(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 5:
						component.RPCActionDamageBible(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 6:
						component.RPCActionDamageBible(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 7:
						component.RPCActionDamageBible(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 8:
						component.RPCActionDamageBible(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 9:
						component.RPCActionDamageBible(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
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
						component2.RPCActionDamageBible(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 2:
						component2.RPCActionDamageBible(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 3:
						component2.RPCActionDamageBible(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 4:
						component2.RPCActionDamageBible(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 5:
						component2.RPCActionDamageBible(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 6:
						component2.RPCActionDamageBible(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 7:
						component2.RPCActionDamageBible(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 8:
						component2.RPCActionDamageBible(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 9:
						component2.RPCActionDamageBible(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
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
						component3.ActionDamageBible(this.iNT * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 2:
						component3.ActionDamageBible(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 3:
						component3.ActionDamageBible(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 4:
						component3.ActionDamageBible(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 5:
						component3.ActionDamageBible(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 6:
						component3.ActionDamageBible(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 7:
						component3.ActionDamageBible(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 8:
						component3.ActionDamageBible(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 9:
						component3.ActionDamageBible(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					}
					component4.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
				}
			}
		}

		// Token: 0x06001DB3 RID: 7603 RVA: 0x002309A4 File Offset: 0x0022EBA4
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
					switch (this.lvl)
					{
					case 1:
						component.RPCActionDamageBible(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 2:
						component.RPCActionDamageBible(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 3:
						component.RPCActionDamageBible(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 4:
						component.RPCActionDamageBible(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 5:
						component.RPCActionDamageBible(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 6:
						component.RPCActionDamageBible(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 7:
						component.RPCActionDamageBible(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 8:
						component.RPCActionDamageBible(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
						break;
					case 9:
						component.RPCActionDamageBible(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
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
						component2.RPCActionDamageBible(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 2:
						component2.RPCActionDamageBible(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 3:
						component2.RPCActionDamageBible(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 4:
						component2.RPCActionDamageBible(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 5:
						component2.RPCActionDamageBible(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 6:
						component2.RPCActionDamageBible(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 7:
						component2.RPCActionDamageBible(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 8:
						component2.RPCActionDamageBible(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
						break;
					case 9:
						component2.RPCActionDamageBible(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
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
						component3.ActionDamageBible(this.iNT * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 2:
						component3.ActionDamageBible(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 3:
						component3.ActionDamageBible(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 4:
						component3.ActionDamageBible(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 5:
						component3.ActionDamageBible(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 6:
						component3.ActionDamageBible(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 7:
						component3.ActionDamageBible(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 8:
						component3.ActionDamageBible(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					case 9:
						component3.ActionDamageBible(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x3, y3);
						break;
					}
					component4.ReciveBoolReturn(this.returnTime, "Skill" + this.skillNumber, this.playerNumber);
				}
			}
		}

		// Token: 0x06001DB4 RID: 7604 RVA: 0x0023129C File Offset: 0x0022F49C
		private void Update()
		{
			this.timeCounter += Time.deltaTime * this.speed;
			this.width += Time.deltaTime;
			this.heigth += Time.deltaTime;
			float num = Mathf.Cos(this.timeCounter) * this.width;
			float num2 = Mathf.Sin(this.timeCounter) * this.heigth;
			base.transform.position = new Vector2(this.baseX + num, this.baseY + num2);
		}

		// Token: 0x06001DB5 RID: 7605 RVA: 0x00231334 File Offset: 0x0022F534
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

		// Token: 0x06001DB6 RID: 7606 RVA: 0x002317F0 File Offset: 0x0022F9F0
		private void ExpPlus(int lvl)
		{
			if (this.mineSW)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expBible += 1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expBible += 2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expBible += 3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expBible += 4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expBible += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expBible += 6f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x06001DB7 RID: 7607 RVA: 0x0023191B File Offset: 0x0022FB1B
		public void AfterImageEnabled()
		{
			this.afterImageEnabled = true;
		}

		// Token: 0x06001DB8 RID: 7608 RVA: 0x00231924 File Offset: 0x0022FB24
		public void AfterImageDisabled()
		{
			this.afterImageEnabled = false;
		}

		// Token: 0x06001DB9 RID: 7609 RVA: 0x00231930 File Offset: 0x0022FB30
		public void Action()
		{
			this.destroyCheck = false;
			this.width = 0f;
			this.heigth = 0f;
			this.timeCounter = 0f;
			this.baseX = base.transform.position.x;
			this.baseY = base.transform.position.y;
			this.ActionAfterImage();
		}

		// Token: 0x06001DBA RID: 7610 RVA: 0x002319A0 File Offset: 0x0022FBA0
		public void ActionAfterImage()
		{
			if (!this.destroyCheck)
			{
				this.instantiateManager.BiblePageAfterImage(this.spriteSrc.transform.position.x, this.spriteSrc.transform.position.y, this.spriteSrc.transform.rotation.eulerAngles.z);
				base.Invoke("ActionAfterImage", 0.3f);
			}
		}

		// Token: 0x06001DBB RID: 7611 RVA: 0x00231A24 File Offset: 0x0022FC24
		public void DestroyCall()
		{
			base.Invoke("GameObjectFalse", 0.1f);
			this.destroyCheck = true;
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x00231A3D File Offset: 0x0022FC3D
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x040031E4 RID: 12772
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Bible_Idle");

		// Token: 0x040031E5 RID: 12773
		[NonSerialized]
		public Animator animator;

		// Token: 0x040031E6 RID: 12774
		private PlayerStatus playerStatus;

		// Token: 0x040031E7 RID: 12775
		private SpriteRenderer spriteSrc;

		// Token: 0x040031E8 RID: 12776
		public GameObject ownerObj;

		// Token: 0x040031E9 RID: 12777
		public bool destroyCheck;

		// Token: 0x040031EA RID: 12778
		public bool afterImageEnabled;

		// Token: 0x040031EB RID: 12779
		public int lvl;

		// Token: 0x040031EC RID: 12780
		public float iNT;

		// Token: 0x040031ED RID: 12781
		public float dEX;

		// Token: 0x040031EE RID: 12782
		public float sWDamage;

		// Token: 0x040031EF RID: 12783
		public float berserk;

		// Token: 0x040031F0 RID: 12784
		public bool mineSW;

		// Token: 0x040031F1 RID: 12785
		public int playerNumber;

		// Token: 0x040031F2 RID: 12786
		public float returnTime = 0.3f;

		// Token: 0x040031F3 RID: 12787
		public int skillNumber;

		// Token: 0x040031F4 RID: 12788
		public int bibleLevel;

		// Token: 0x040031F5 RID: 12789
		public GameObject biblePages;

		// Token: 0x040031F6 RID: 12790
		public InstantiateManager instantiateManager;

		// Token: 0x040031F7 RID: 12791
		public float timeCounter;

		// Token: 0x040031F8 RID: 12792
		public float width;

		// Token: 0x040031F9 RID: 12793
		public float heigth;

		// Token: 0x040031FA RID: 12794
		public float speed;

		// Token: 0x040031FB RID: 12795
		public float baseX;

		// Token: 0x040031FC RID: 12796
		public float baseY;
	}
}
