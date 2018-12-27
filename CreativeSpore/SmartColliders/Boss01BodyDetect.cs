using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020001FD RID: 509
	public class Boss01BodyDetect : MonoBehaviour
	{
		// Token: 0x06000D82 RID: 3458 RVA: 0x0008FD78 File Offset: 0x0008DF78
		private void Awake()
		{
			if (this.enemyBody == null)
			{
				this.enemyBody = base.transform.parent.parent.GetComponent<EnemyBody>();
			}
			if (base.transform.parent.parent.name == "Boss01")
			{
				this.bossStage01 = base.transform.parent.parent.GetComponent<BossStage01>();
			}
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x0008FDF0 File Offset: 0x0008DFF0
		public void ActionDamage(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamage(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamage(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamage(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamage(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamage(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x0008FF64 File Offset: 0x0008E164
		public void ActionDamageMagic(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageMagic(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageMagic(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageMagic(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageMagic(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageMagic(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x000900D8 File Offset: 0x0008E2D8
		public void ActionDamageHit(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageHit(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageHit(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageHit(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageHit(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageHit(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x0009024C File Offset: 0x0008E44C
		public void ActionDamageCut(float damageValue, float dEX, float posX, float posY, int effectVal)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageCut(num, dEX, posX, posY, effectVal);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageCut(num2, dEX, posX, posY, effectVal);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageCut(num4, dEX, posX, posY, effectVal);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageCut(num5, dEX, posX, posY, effectVal);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageCut(num6, dEX, posX, posY, effectVal);
				}
			}
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x000903CC File Offset: 0x0008E5CC
		public void ActionDamagePoke(float damageValue, float dEX, float posX, float posY, int effectVal)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamagePoke(num, dEX, posX, posY, effectVal);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamagePoke(num2, dEX, posX, posY, effectVal);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamagePoke(num4, dEX, posX, posY, effectVal);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamagePoke(num5, dEX, posX, posY, effectVal);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamagePoke(num6, dEX, posX, posY, effectVal);
				}
			}
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x0009054C File Offset: 0x0008E74C
		public void ActionDamageBone(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageBone(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageBone(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageBone(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageBone(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageBone(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x000906C0 File Offset: 0x0008E8C0
		public void ActionDamageFire(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageFire(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageFire(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageFire(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageFire(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageFire(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x00090834 File Offset: 0x0008EA34
		public void ActionDamageIce(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageIce(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageIce(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageIce(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageIce(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageIce(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x000909A8 File Offset: 0x0008EBA8
		public void ActionDamageThun(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageThun(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageThun(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageThun(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageThun(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageThun(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x00090B1C File Offset: 0x0008ED1C
		public void ActionDamageLigh(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageLigh(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageLigh(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageLigh(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageLigh(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageLigh(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x00090C90 File Offset: 0x0008EE90
		public void ActionDamageDark(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageDark(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageDark(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageDark(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageDark(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageDark(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x00090E04 File Offset: 0x0008F004
		public void ActionDamageKick(float damageValue, int comboBoots, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageKick(num, comboBoots, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageKick(num2, comboBoots, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageKick(num4, comboBoots, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageKick(num5, comboBoots, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageKick(num6, comboBoots, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x00090F84 File Offset: 0x0008F184
		public void ActionDamageUpper(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageUpper(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageUpper(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageUpper(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageUpper(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageUpper(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x000910F8 File Offset: 0x0008F2F8
		public void ActionDamageSlidingKick(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageSlidingKick(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageSlidingKick(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageSlidingKick(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageSlidingKick(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageSlidingKick(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x0009126C File Offset: 0x0008F46C
		public void ActionDamageSpinningKick(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageSpinningKick(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageSpinningKick(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageSpinningKick(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageSpinningKick(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageSpinningKick(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x000913E0 File Offset: 0x0008F5E0
		public void ActionDamageTackle(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageTackle(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageTackle(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageTackle(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageTackle(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageTackle(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x00091554 File Offset: 0x0008F754
		public void ActionDamageChain(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageChain(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageChain(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageChain(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageChain(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageChain(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x000916C8 File Offset: 0x0008F8C8
		public void ActionDamageCross(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageCross(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageCross(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageCross(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageCross(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageCross(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x0009183C File Offset: 0x0008FA3C
		public void ActionDamageAxe(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageAxe(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageAxe(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageAxe(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageAxe(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageAxe(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x000919B0 File Offset: 0x0008FBB0
		public void ActionDamageHolyWater(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageHolyWater(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageHolyWater(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageHolyWater(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageHolyWater(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageHolyWater(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x00091B24 File Offset: 0x0008FD24
		public void ActionDamageJavelin(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageJavelin(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageJavelin(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageJavelin(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageJavelin(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageJavelin(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x00091C98 File Offset: 0x0008FE98
		public void ActionDamageTyoukouIsi(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageTyoukouIsi(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageTyoukouIsi(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageTyoukouIsi(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageTyoukouIsi(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageTyoukouIsi(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x00091E0C File Offset: 0x0009000C
		public void ActionDamageBible(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageBible(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageBible(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageBible(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageBible(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageBible(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x00091F80 File Offset: 0x00090180
		public void ActionDamageLAxe(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageLAxe(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageLAxe(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageLAxe(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageLAxe(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageLAxe(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x000920F4 File Offset: 0x000902F4
		public void ActionDamageLHolyWater(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageLHolyWater(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageLHolyWater(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageLHolyWater(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageLHolyWater(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageLHolyWater(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x00092268 File Offset: 0x00090468
		public void ActionDamageLCross(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageLCross(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageLCross(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageLCross(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageLCross(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageLCross(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x000923DC File Offset: 0x000905DC
		public void ActionDamageGroundCross(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageGroundCross(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageGroundCross(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageGroundCross(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageGroundCross(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageGroundCross(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x00092550 File Offset: 0x00090750
		public void ActionDamageThunderCross(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageThunderCross(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageThunderCross(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageThunderCross(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageThunderCross(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageThunderCross(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x000926C4 File Offset: 0x000908C4
		public void ActionDamageKokyuutosu(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageKokyuutosu(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageKokyuutosu(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageKokyuutosu(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageKokyuutosu(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageKokyuutosu(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x00092838 File Offset: 0x00090A38
		public void ActionDamageSpikeMeiru(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageSpikeMeiru(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageSpikeMeiru(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageSpikeMeiru(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageSpikeMeiru(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageSpikeMeiru(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x000929AC File Offset: 0x00090BAC
		public void ActionDamageNitensu(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageNitensu(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageNitensu(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageNitensu(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageNitensu(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageNitensu(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x00092B20 File Offset: 0x00090D20
		public void ActionDamageGurando(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageGurando(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageGurando(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageGurando(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageGurando(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageGurando(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x00092C94 File Offset: 0x00090E94
		public void ActionDamageAkerubusu(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageAkerubusu(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageAkerubusu(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageAkerubusu(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageAkerubusu(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageAkerubusu(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x00092E08 File Offset: 0x00091008
		public void ActionDamageDeKusutosu(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageDeKusutosu(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageDeKusutosu(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageDeKusutosu(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageDeKusutosu(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageDeKusutosu(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x00092F7C File Offset: 0x0009117C
		public void ActionDamageSiKusutosu(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageSiKusutosu(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageSiKusutosu(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageSiKusutosu(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageSiKusutosu(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageSiKusutosu(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x000930F0 File Offset: 0x000912F0
		public void ActionDamageConfodere(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageConfodere(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageConfodere(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageConfodere(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageConfodere(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageConfodere(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x00093264 File Offset: 0x00091464
		public void ActionDamageRoseWhip(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageRoseWhip(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageRoseWhip(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageRoseWhip(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageRoseWhip(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageRoseWhip(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x000933D8 File Offset: 0x000915D8
		public void ActionDamageMedusaWhip(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageMedusaWhip(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageMedusaWhip(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageMedusaWhip(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageMedusaWhip(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageMedusaWhip(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x0009354C File Offset: 0x0009174C
		public void ActionDamageHonooNoMuchi(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageHonooNoMuchi(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageHonooNoMuchi(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageHonooNoMuchi(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageHonooNoMuchi(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageHonooNoMuchi(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x000936C0 File Offset: 0x000918C0
		public void ActionDamageSikkokuNoMuchi(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageSikkokuNoMuchi(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageSikkokuNoMuchi(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageSikkokuNoMuchi(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageSikkokuNoMuchi(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageSikkokuNoMuchi(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x00093834 File Offset: 0x00091A34
		public void ActionDamageVampireKiller(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageVampireKiller(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageVampireKiller(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageVampireKiller(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageVampireKiller(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageVampireKiller(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x000939A8 File Offset: 0x00091BA8
		public void ActionDamageMilican(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageMilican(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageMilican(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageMilican(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageMilican(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageMilican(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x00093B1C File Offset: 0x00091D1C
		public void ActionDamageRahab(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageRahab(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageRahab(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageRahab(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageRahab(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageRahab(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x00093C90 File Offset: 0x00091E90
		public void ActionDamageAgni(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageAgni(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageAgni(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageAgni(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageAgni(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageAgni(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x00093E04 File Offset: 0x00092004
		public void ActionDamageAssasinBlade(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageAssasinBlade(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageAssasinBlade(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageAssasinBlade(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageAssasinBlade(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageAssasinBlade(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x00093F78 File Offset: 0x00092178
		public void ActionDamageStellaSword(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageStellaSword(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageStellaSword(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageStellaSword(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageStellaSword(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageStellaSword(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x000940EC File Offset: 0x000922EC
		public void ActionDamageDragonSlayer(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageDragonSlayer(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageDragonSlayer(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageDragonSlayer(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageDragonSlayer(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageDragonSlayer(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x00094260 File Offset: 0x00092460
		public void ActionDamageWeaponAxe(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageWeaponAxe(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageWeaponAxe(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageWeaponAxe(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageWeaponAxe(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageWeaponAxe(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x000943D4 File Offset: 0x000925D4
		public void ActionDamageVoulvge(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageVoulvge(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageVoulvge(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageVoulvge(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageVoulvge(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageVoulvge(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x00094548 File Offset: 0x00092748
		public void ActionDamageWeaponKnife(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageWeaponKnife(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageWeaponKnife(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageWeaponKnife(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageWeaponKnife(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageWeaponKnife(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x000946BC File Offset: 0x000928BC
		public void ActionDamageCurse(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageCurse(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageCurse(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageCurse(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageCurse(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageCurse(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x00094830 File Offset: 0x00092A30
		public void ActionDamagePoison(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamagePoison(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamagePoison(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamagePoison(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamagePoison(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamagePoison(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x000949A4 File Offset: 0x00092BA4
		public void ActionDamageGungnir(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageGungnir(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageGungnir(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageGungnir(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageGungnir(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageGungnir(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x00094B18 File Offset: 0x00092D18
		public void ActionDamageMyornir(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageMyornir(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageMyornir(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageMyornir(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageMyornir(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageMyornir(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x00094C8C File Offset: 0x00092E8C
		public void ActionDamageBearCrow(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageBearCrow(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageBearCrow(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageBearCrow(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageBearCrow(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageBearCrow(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x00094E00 File Offset: 0x00093000
		public void ActionDamageKugiBat(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageKugiBat(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageKugiBat(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageKugiBat(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageKugiBat(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageKugiBat(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x00094F74 File Offset: 0x00093174
		public void ActionDamageFishHead(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageFishHead(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageFishHead(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageFishHead(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageFishHead(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageFishHead(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x000950E8 File Offset: 0x000932E8
		public void ActionDamageBeruzebubu(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageBeruzebubu(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageBeruzebubu(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageBeruzebubu(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageBeruzebubu(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageBeruzebubu(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x0009525C File Offset: 0x0009345C
		public void ActionDamageRyuukotsuki(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageRyuukotsuki(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageRyuukotsuki(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageRyuukotsuki(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageRyuukotsuki(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageRyuukotsuki(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x000953D0 File Offset: 0x000935D0
		public void ActionDamageIndra(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageIndra(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageIndra(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageIndra(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageIndra(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageIndra(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x00095544 File Offset: 0x00093744
		public void ActionDamageStone(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageStone(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageStone(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageStone(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageStone(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageStone(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x000956B8 File Offset: 0x000938B8
		public void ActionDamageGuardianKnuckle(float damageValue, float dEX, float posX, float posY)
		{
			if (this.bossStage01 != null)
			{
				if (!this.bossStage01.goBrakeLegsAcce)
				{
					float num = damageValue / this.damageCutvalue;
					this.bossStage01.SendAcceDamage(num);
					this.enemyBody.RPCActionDamageGuardianKnuckle(num, dEX, posX, posY);
				}
				else if (this.bossStage01.goBrakeLegsAcce)
				{
					float num2 = damageValue * this.damageUpvalue;
					this.bossStage01.SendAcceDamage(num2);
					this.enemyBody.RPCActionDamageGuardianKnuckle(num2, dEX, posX, posY);
				}
			}
			if (this.bossStage03 != null)
			{
				int num3 = this.coreSwitch;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							if (!this.bossStage03.kneeCoreBreak)
							{
								float num4 = damageValue / this.damageCutvalue;
								this.bossStage03.SendAcceDamage_Knee(num4);
								this.enemyBody.RPCActionDamageGuardianKnuckle(num4, dEX, posX, posY);
							}
						}
					}
					else if (!this.bossStage03.bodyCoreBreak)
					{
						float num5 = damageValue / this.damageCutvalue;
						this.bossStage03.SendAcceDamage_Body(num5);
						this.enemyBody.RPCActionDamageGuardianKnuckle(num5, dEX, posX, posY);
					}
				}
				else if (!this.bossStage03.headCoreBreak)
				{
					float num6 = damageValue / this.damageCutvalue;
					this.bossStage03.SendAcceDamage_Head(num6);
					this.enemyBody.RPCActionDamageGuardianKnuckle(num6, dEX, posX, posY);
				}
			}
		}

		// Token: 0x04001232 RID: 4658
		public float damageCutvalue = 3f;

		// Token: 0x04001233 RID: 4659
		public float damageUpvalue = 1.5f;

		// Token: 0x04001234 RID: 4660
		public EnemyBody enemyBody;

		// Token: 0x04001235 RID: 4661
		private BossStage01 bossStage01;

		// Token: 0x04001236 RID: 4662
		public int enemyLevel;

		// Token: 0x04001237 RID: 4663
		public Enemy_Menace bossStage03;

		// Token: 0x04001238 RID: 4664
		public int coreSwitch;
	}
}
