using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000477 RID: 1143
	public class ATKSoma : MonoBehaviour
	{
		// Token: 0x06002B3D RID: 11069 RVA: 0x0048290C File Offset: 0x00480B0C
		private void Awake()
		{
			if (this.cCol2d == null)
			{
				this.col2d = base.GetComponent<BoxCollider2D>();
			}
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			if (base.transform.parent.parent.parent.parent.GetComponent<PhotonView>().isMine)
			{
				this.mine = true;
			}
		}

		// Token: 0x06002B3E RID: 11070 RVA: 0x0048297C File Offset: 0x00480B7C
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				this.currentEnemyBody = other.transform.parent.GetComponent<EnemyBody>();
				if (this.hitedATK)
				{
					if (!(this.currentEnemyBody == this.enemyBody))
					{
						this.hitedATK = false;
					}
				}
				if (!this.hitedATK)
				{
					this.enemyBody = other.transform.parent.GetComponent<EnemyBody>();
					Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x = vector.x;
					float y = vector.y;
					if (this.playerCtrl != null)
					{
						if (this.playerCtrl.lvlSakyubasu > 0)
						{
							float num = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
							if (num < 1f)
							{
								num = 1f;
							}
							this.playerCtrl.HPMPHeal(num, 0f);
						}
						switch (this.weaponSwitch)
						{
						case 1:
						{
							bool flag = this.switchSkill;
							if (flag)
							{
								if (flag)
								{
									bool flag2 = this.subATK;
									if (flag2)
									{
										if (flag2)
										{
											this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
									}
								}
							}
							else
							{
								bool flag3 = this.subATK;
								if (flag3)
								{
									if (flag3)
									{
										this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
								}
							}
							break;
						}
						case 2:
						{
							bool flag4 = this.switchSkill;
							if (flag4)
							{
								if (flag4)
								{
									bool flag5 = this.subATK;
									if (flag5)
									{
										if (flag5)
										{
											this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y, 1);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y, 1);
									}
								}
							}
							else
							{
								bool flag6 = this.subATK;
								if (flag6)
								{
									if (flag6)
									{
										this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 1);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 1);
								}
							}
							break;
						}
						case 3:
						{
							bool flag7 = this.switchSkill;
							if (flag7)
							{
								if (flag7)
								{
									bool flag8 = this.subATK;
									if (flag8)
									{
										if (flag8)
										{
											this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y, 2);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y, 2);
									}
								}
							}
							else
							{
								bool flag9 = this.subATK;
								if (flag9)
								{
									if (flag9)
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
								}
							}
							break;
						}
						case 4:
						{
							bool flag10 = this.switchSkill;
							if (flag10)
							{
								if (flag10)
								{
									bool flag11 = this.subATK;
									if (flag11)
									{
										if (flag11)
										{
											this.enemyBody.RPCActionDamageAssasinBlade(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageAssasinBlade(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
									}
								}
							}
							else
							{
								bool flag12 = this.subATK;
								if (flag12)
								{
									if (flag12)
									{
										this.enemyBody.RPCActionDamageAssasinBlade(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageAssasinBlade(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusPoisonRandom(x, y);
							}
							break;
						}
						case 5:
						{
							bool flag13 = this.switchSkill;
							if (flag13)
							{
								if (flag13)
								{
									bool flag14 = this.subATK;
									if (flag14)
									{
										if (flag14)
										{
											this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
									}
								}
							}
							else
							{
								bool flag15 = this.subATK;
								if (flag15)
								{
									if (flag15)
									{
										this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
								}
							}
							break;
						}
						case 6:
						{
							bool flag16 = this.switchSkill;
							if (flag16)
							{
								if (flag16)
								{
									bool flag17 = this.subATK;
									if (flag17)
									{
										if (flag17)
										{
											this.enemyBody.RPCActionDamageMilican(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageMilican(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
									}
								}
							}
							else
							{
								bool flag18 = this.subATK;
								if (flag18)
								{
									if (flag18)
									{
										this.enemyBody.RPCActionDamageMilican(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageMilican(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusStoneRandom(x, y);
							}
							break;
						}
						case 7:
						{
							bool flag19 = this.switchSkill;
							if (flag19)
							{
								if (flag19)
								{
									bool flag20 = this.subATK;
									if (flag20)
									{
										if (flag20)
										{
											this.enemyBody.RPCActionDamageRahab(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageRahab(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
									}
								}
							}
							else
							{
								bool flag21 = this.subATK;
								if (flag21)
								{
									if (flag21)
									{
										this.enemyBody.RPCActionDamageRahab(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageRahab(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
								}
							}
							break;
						}
						case 14:
						{
							bool flag22 = this.switchSkill;
							if (flag22)
							{
								if (flag22)
								{
									bool flag23 = this.subATK;
									if (flag23)
									{
										if (flag23)
										{
											this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
									}
								}
							}
							else
							{
								bool flag24 = this.subATK;
								if (flag24)
								{
									if (flag24)
									{
										this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
								}
							}
							break;
						}
						case 17:
						{
							float f = 0f;
							switch (this.playerCtrl.lvlTyupakabura)
							{
							case 1:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x, y, 1);
								f = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 2:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 1.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x, y, 1);
								f = Mathf.Round(this.playerCtrl.iNT * 1.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 3:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 1.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x, y, 1);
								f = Mathf.Round(this.playerCtrl.iNT * 1.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 4:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 1.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x, y, 1);
								f = Mathf.Round(this.playerCtrl.iNT * 1.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 5:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 1.8f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x, y, 1);
								f = Mathf.Round(this.playerCtrl.iNT * 1.8f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 6:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x, y, 1);
								f = Mathf.Round(this.playerCtrl.iNT * 2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 7:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 2.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x, y, 1);
								f = Mathf.Round(this.playerCtrl.iNT * 2.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 8:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 2.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x, y, 1);
								f = Mathf.Round(this.playerCtrl.iNT * 2.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 9:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 2.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x, y, 1);
								f = Mathf.Round(this.playerCtrl.iNT * 2.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							}
							int num2 = Mathf.RoundToInt(f);
							if (num2 < 1)
							{
								num2 = 1;
							}
							this.playerStatus.damage += num2;
							if (!this.enemyBody.ownATKHitted)
							{
								this.enemyBody.ownATKHitted = true;
							}
							break;
						}
						case 18:
						{
							bool flag25 = this.switchSkill;
							if (flag25)
							{
								if (flag25)
								{
									bool flag26 = this.subATK;
									if (flag26)
									{
										if (flag26)
										{
											this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y, 3);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y, 3);
									}
								}
							}
							else
							{
								bool flag27 = this.subATK;
								if (flag27)
								{
									if (flag27)
									{
										this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 3);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 3);
								}
							}
							break;
						}
						case 19:
						{
							bool flag28 = this.switchSkill;
							if (flag28)
							{
								if (flag28)
								{
									bool flag29 = this.subATK;
									if (flag29)
									{
										if (flag29)
										{
											this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y, 3);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y, 3);
									}
								}
							}
							else
							{
								bool flag30 = this.subATK;
								if (flag30)
								{
									if (flag30)
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 3);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 3);
								}
							}
							break;
						}
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f2 = 0f;
							bool flag31 = this.switchSkill;
							if (flag31)
							{
								if (flag31)
								{
									bool flag32 = this.subATK;
									if (flag32)
									{
										if (flag32)
										{
											f2 = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f);
										}
									}
									else
									{
										f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f);
									}
								}
							}
							else
							{
								bool flag33 = this.subATK;
								if (flag33)
								{
									if (flag33)
									{
										f2 = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK);
									}
								}
								else
								{
									f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
								}
							}
							int num3 = Mathf.RoundToInt(f2);
							if (num3 < 1)
							{
								num3 = 1;
							}
							this.playerStatus.damage += num3;
						}
						if (!this.enemyBody.ownATKHitted)
						{
							this.enemyBody.ownATKHitted = true;
						}
					}
					this.hitedATK = true;
				}
			}
			else if (other.tag == "EnemyBodyAttackSp")
			{
				this.currentEnemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.hitedATK)
				{
					if (!(this.currentEnemyBody == this.enemyBody))
					{
						this.hitedATK = false;
					}
				}
				if (!this.hitedATK)
				{
					this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
					Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x2 = vector2.x;
					float y2 = vector2.y;
					if (this.playerCtrl != null)
					{
						switch (this.weaponSwitch)
						{
						case 1:
						{
							bool flag34 = this.switchSkill;
							if (flag34)
							{
								if (flag34)
								{
									bool flag35 = this.subATK;
									if (flag35)
									{
										if (flag35)
										{
											this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
									}
								}
							}
							else
							{
								bool flag36 = this.subATK;
								if (flag36)
								{
									if (flag36)
									{
										this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							break;
						}
						case 2:
						{
							bool flag37 = this.switchSkill;
							if (flag37)
							{
								if (flag37)
								{
									bool flag38 = this.subATK;
									if (flag38)
									{
										if (flag38)
										{
											this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 1);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 1);
									}
								}
							}
							else
							{
								bool flag39 = this.subATK;
								if (flag39)
								{
									if (flag39)
									{
										this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 1);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 1);
								}
							}
							break;
						}
						case 3:
						{
							bool flag40 = this.switchSkill;
							if (flag40)
							{
								if (flag40)
								{
									bool flag41 = this.subATK;
									if (flag41)
									{
										if (flag41)
										{
											this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
									}
								}
							}
							else
							{
								bool flag42 = this.subATK;
								if (flag42)
								{
									if (flag42)
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
								}
							}
							break;
						}
						case 4:
						{
							bool flag43 = this.switchSkill;
							if (flag43)
							{
								if (flag43)
								{
									bool flag44 = this.subATK;
									if (flag44)
									{
										if (flag44)
										{
											this.enemyBody.RPCActionDamageAssasinBlade(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageAssasinBlade(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
									}
								}
							}
							else
							{
								bool flag45 = this.subATK;
								if (flag45)
								{
									if (flag45)
									{
										this.enemyBody.RPCActionDamageAssasinBlade(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageAssasinBlade(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusPoisonRandom(x2, y2);
							}
							break;
						}
						case 5:
						{
							bool flag46 = this.switchSkill;
							if (flag46)
							{
								if (flag46)
								{
									bool flag47 = this.subATK;
									if (flag47)
									{
										if (flag47)
										{
											this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
									}
								}
							}
							else
							{
								bool flag48 = this.subATK;
								if (flag48)
								{
									if (flag48)
									{
										this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							break;
						}
						case 6:
						{
							bool flag49 = this.switchSkill;
							if (flag49)
							{
								if (flag49)
								{
									bool flag50 = this.subATK;
									if (flag50)
									{
										if (flag50)
										{
											this.enemyBody.RPCActionDamageMilican(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageMilican(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
									}
								}
							}
							else
							{
								bool flag51 = this.subATK;
								if (flag51)
								{
									if (flag51)
									{
										this.enemyBody.RPCActionDamageMilican(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageMilican(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusStoneRandom(x2, y2);
							}
							break;
						}
						case 7:
						{
							bool flag52 = this.switchSkill;
							if (flag52)
							{
								if (flag52)
								{
									bool flag53 = this.subATK;
									if (flag53)
									{
										if (flag53)
										{
											this.enemyBody.RPCActionDamageRahab(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageRahab(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
									}
								}
							}
							else
							{
								bool flag54 = this.subATK;
								if (flag54)
								{
									if (flag54)
									{
										this.enemyBody.RPCActionDamageRahab(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageRahab(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							break;
						}
						case 14:
						{
							bool flag55 = this.switchSkill;
							if (flag55)
							{
								if (flag55)
								{
									bool flag56 = this.subATK;
									if (flag56)
									{
										if (flag56)
										{
											this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
									}
								}
							}
							else
							{
								bool flag57 = this.subATK;
								if (flag57)
								{
									if (flag57)
									{
										this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							break;
						}
						case 17:
						{
							float f3 = 0f;
							switch (this.playerCtrl.lvlTyupakabura)
							{
							case 1:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x2, y2, 1);
								f3 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 2:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 1.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x2, y2, 1);
								f3 = Mathf.Round(this.playerCtrl.iNT * 1.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 3:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 1.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x2, y2, 1);
								f3 = Mathf.Round(this.playerCtrl.iNT * 1.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 4:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 1.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x2, y2, 1);
								f3 = Mathf.Round(this.playerCtrl.iNT * 1.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 5:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 1.8f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x2, y2, 1);
								f3 = Mathf.Round(this.playerCtrl.iNT * 1.8f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 6:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x2, y2, 1);
								f3 = Mathf.Round(this.playerCtrl.iNT * 2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 7:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 2.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x2, y2, 1);
								f3 = Mathf.Round(this.playerCtrl.iNT * 2.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 8:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 2.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x2, y2, 1);
								f3 = Mathf.Round(this.playerCtrl.iNT * 2.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 9:
								this.enemyBody.RPCActionDamagePoke(this.playerCtrl.iNT * 2.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x2, y2, 1);
								f3 = Mathf.Round(this.playerCtrl.iNT * 2.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							}
							int num4 = Mathf.RoundToInt(f3);
							if (num4 < 1)
							{
								num4 = 1;
							}
							this.playerStatus.damage += num4;
							if (!this.enemyBody.ownATKHitted)
							{
								this.enemyBody.ownATKHitted = true;
							}
							break;
						}
						case 18:
						{
							bool flag58 = this.switchSkill;
							if (flag58)
							{
								if (flag58)
								{
									bool flag59 = this.subATK;
									if (flag59)
									{
										if (flag59)
										{
											this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 3);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 3);
									}
								}
							}
							else
							{
								bool flag60 = this.subATK;
								if (flag60)
								{
									if (flag60)
									{
										this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 3);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 3);
								}
							}
							break;
						}
						case 19:
						{
							bool flag61 = this.switchSkill;
							if (flag61)
							{
								if (flag61)
								{
									bool flag62 = this.subATK;
									if (flag62)
									{
										if (flag62)
										{
											this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 3);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 3);
									}
								}
							}
							else
							{
								bool flag63 = this.subATK;
								if (flag63)
								{
									if (flag63)
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 3);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 3);
								}
							}
							break;
						}
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f4 = 0f;
							bool flag64 = this.switchSkill;
							if (flag64)
							{
								if (flag64)
								{
									bool flag65 = this.subATK;
									if (flag65)
									{
										if (flag65)
										{
											f4 = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f);
										}
									}
									else
									{
										f4 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f);
									}
								}
							}
							else
							{
								bool flag66 = this.subATK;
								if (flag66)
								{
									if (flag66)
									{
										f4 = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK);
									}
								}
								else
								{
									f4 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
								}
							}
							int num5 = Mathf.RoundToInt(f4);
							if (num5 < 1)
							{
								num5 = 1;
							}
							this.playerStatus.damage += num5;
						}
						if (!this.enemyBody.ownATKHitted)
						{
							this.enemyBody.ownATKHitted = true;
						}
					}
					this.hitedATK = true;
				}
			}
			else if (other.tag == "EnemyBodyAttackBoss01")
			{
				this.currentBB = other.transform.GetComponent<Boss01BodyDetect>();
				if (this.hitedATK)
				{
					if (!(this.currentBB == this.bB))
					{
						this.hitedATK = false;
					}
				}
				if (!this.hitedATK)
				{
					this.bB = other.GetComponent<Boss01BodyDetect>();
					this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
					Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x3 = vector3.x;
					float y3 = vector3.y;
					if (this.playerCtrl != null)
					{
						switch (this.weaponSwitch)
						{
						case 1:
						{
							bool flag67 = this.switchSkill;
							if (flag67)
							{
								if (flag67)
								{
									bool flag68 = this.subATK;
									if (flag68)
									{
										if (flag68)
										{
											this.bB.ActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										}
									}
									else
									{
										this.bB.ActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
									}
								}
							}
							else
							{
								bool flag69 = this.subATK;
								if (flag69)
								{
									if (flag69)
									{
										this.bB.ActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									}
								}
								else
								{
									this.bB.ActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
								}
							}
							break;
						}
						case 2:
						{
							bool flag70 = this.switchSkill;
							if (flag70)
							{
								if (flag70)
								{
									bool flag71 = this.subATK;
									if (flag71)
									{
										if (flag71)
										{
											this.bB.ActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3, 1);
										}
									}
									else
									{
										this.bB.ActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3, 1);
									}
								}
							}
							else
							{
								bool flag72 = this.subATK;
								if (flag72)
								{
									if (flag72)
									{
										this.bB.ActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 1);
									}
								}
								else
								{
									this.bB.ActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 1);
								}
							}
							break;
						}
						case 3:
						{
							bool flag73 = this.switchSkill;
							if (flag73)
							{
								if (flag73)
								{
									bool flag74 = this.subATK;
									if (flag74)
									{
										if (flag74)
										{
											this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3, 2);
										}
									}
									else
									{
										this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3, 2);
									}
								}
							}
							else
							{
								bool flag75 = this.subATK;
								if (flag75)
								{
									if (flag75)
									{
										this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 2);
									}
								}
								else
								{
									this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 2);
								}
							}
							break;
						}
						case 4:
						{
							bool flag76 = this.switchSkill;
							if (flag76)
							{
								if (flag76)
								{
									bool flag77 = this.subATK;
									if (flag77)
									{
										if (flag77)
										{
											this.bB.ActionDamageAssasinBlade(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										}
									}
									else
									{
										this.bB.ActionDamageAssasinBlade(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
									}
								}
							}
							else
							{
								bool flag78 = this.subATK;
								if (flag78)
								{
									if (flag78)
									{
										this.bB.ActionDamageAssasinBlade(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									}
								}
								else
								{
									this.bB.ActionDamageAssasinBlade(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusPoisonRandom(x3, y3);
							}
							break;
						}
						case 5:
						{
							bool flag79 = this.switchSkill;
							if (flag79)
							{
								if (flag79)
								{
									bool flag80 = this.subATK;
									if (flag80)
									{
										if (flag80)
										{
											this.bB.ActionDamageStellaSword(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										}
									}
									else
									{
										this.bB.ActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
									}
								}
							}
							else
							{
								bool flag81 = this.subATK;
								if (flag81)
								{
									if (flag81)
									{
										this.bB.ActionDamageStellaSword(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									}
								}
								else
								{
									this.bB.ActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
								}
							}
							break;
						}
						case 6:
						{
							bool flag82 = this.switchSkill;
							if (flag82)
							{
								if (flag82)
								{
									bool flag83 = this.subATK;
									if (flag83)
									{
										if (flag83)
										{
											this.bB.ActionDamageMilican(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										}
									}
									else
									{
										this.bB.ActionDamageMilican(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
									}
								}
							}
							else
							{
								bool flag84 = this.subATK;
								if (flag84)
								{
									if (flag84)
									{
										this.bB.ActionDamageMilican(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									}
								}
								else
								{
									this.bB.ActionDamageMilican(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusStoneRandom(x3, y3);
							}
							break;
						}
						case 7:
						{
							bool flag85 = this.switchSkill;
							if (flag85)
							{
								if (flag85)
								{
									bool flag86 = this.subATK;
									if (flag86)
									{
										if (flag86)
										{
											this.bB.ActionDamageRahab(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										}
									}
									else
									{
										this.bB.ActionDamageRahab(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
									}
								}
							}
							else
							{
								bool flag87 = this.subATK;
								if (flag87)
								{
									if (flag87)
									{
										this.bB.ActionDamageRahab(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									}
								}
								else
								{
									this.bB.ActionDamageRahab(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
								}
							}
							break;
						}
						case 14:
						{
							bool flag88 = this.switchSkill;
							if (flag88)
							{
								if (flag88)
								{
									bool flag89 = this.subATK;
									if (flag89)
									{
										if (flag89)
										{
											this.bB.ActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										}
									}
									else
									{
										this.bB.ActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
									}
								}
							}
							else
							{
								bool flag90 = this.subATK;
								if (flag90)
								{
									if (flag90)
									{
										this.bB.ActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									}
								}
								else
								{
									this.bB.ActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
								}
							}
							break;
						}
						case 17:
						{
							float f5 = 0f;
							switch (this.playerCtrl.lvlTyupakabura)
							{
							case 1:
								this.bB.ActionDamagePoke(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x3, y3, 1);
								f5 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 2:
								this.bB.ActionDamagePoke(this.playerCtrl.iNT * 1.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x3, y3, 1);
								f5 = Mathf.Round(this.playerCtrl.iNT * 1.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 3:
								this.bB.ActionDamagePoke(this.playerCtrl.iNT * 1.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x3, y3, 1);
								f5 = Mathf.Round(this.playerCtrl.iNT * 1.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 4:
								this.bB.ActionDamagePoke(this.playerCtrl.iNT * 1.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x3, y3, 1);
								f5 = Mathf.Round(this.playerCtrl.iNT * 1.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 5:
								this.bB.ActionDamagePoke(this.playerCtrl.iNT * 1.8f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x3, y3, 1);
								f5 = Mathf.Round(this.playerCtrl.iNT * 1.8f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 6:
								this.bB.ActionDamagePoke(this.playerCtrl.iNT * 2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x3, y3, 1);
								f5 = Mathf.Round(this.playerCtrl.iNT * 2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 7:
								this.bB.ActionDamagePoke(this.playerCtrl.iNT * 2.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x3, y3, 1);
								f5 = Mathf.Round(this.playerCtrl.iNT * 2.2f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 8:
								this.bB.ActionDamagePoke(this.playerCtrl.iNT * 2.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x3, y3, 1);
								f5 = Mathf.Round(this.playerCtrl.iNT * 2.4f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							case 9:
								this.bB.ActionDamagePoke(this.playerCtrl.iNT * 2.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage, this.playerCtrl.dEX, x3, y3, 1);
								f5 = Mathf.Round(this.playerCtrl.iNT * 2.6f * this.playerCtrl.berserkerMeiruATK * this.playerCtrl.sWDamage);
								break;
							}
							int num6 = Mathf.RoundToInt(f5);
							if (num6 < 1)
							{
								num6 = 1;
							}
							this.playerStatus.damage += num6;
							if (!this.enemyBody.ownATKHitted)
							{
								this.enemyBody.ownATKHitted = true;
							}
							break;
						}
						case 18:
						{
							bool flag91 = this.switchSkill;
							if (flag91)
							{
								if (flag91)
								{
									bool flag92 = this.subATK;
									if (flag92)
									{
										if (flag92)
										{
											this.bB.ActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3, 3);
										}
									}
									else
									{
										this.bB.ActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3, 3);
									}
								}
							}
							else
							{
								bool flag93 = this.subATK;
								if (flag93)
								{
									if (flag93)
									{
										this.bB.ActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 3);
									}
								}
								else
								{
									this.bB.ActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 3);
								}
							}
							break;
						}
						case 19:
						{
							bool flag94 = this.switchSkill;
							if (flag94)
							{
								if (flag94)
								{
									bool flag95 = this.subATK;
									if (flag95)
									{
										if (flag95)
										{
											this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3, 3);
										}
									}
									else
									{
										this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3, 3);
									}
								}
							}
							else
							{
								bool flag96 = this.subATK;
								if (flag96)
								{
									if (flag96)
									{
										this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 3);
									}
								}
								else
								{
									this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 3);
								}
							}
							break;
						}
						}
					}
					if (this.myPV.isMine && !this.tyupakabura)
					{
						if (this.playerCtrl != null)
						{
							float f6 = 0f;
							bool flag97 = this.switchSkill;
							if (flag97)
							{
								if (flag97)
								{
									bool flag98 = this.subATK;
									if (flag98)
									{
										if (flag98)
										{
											f6 = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f);
										}
									}
									else
									{
										f6 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f);
									}
								}
							}
							else
							{
								bool flag99 = this.subATK;
								if (flag99)
								{
									if (flag99)
									{
										f6 = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK);
									}
								}
								else
								{
									f6 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
								}
							}
							int num7 = Mathf.RoundToInt(f6);
							if (num7 < 1)
							{
								num7 = 1;
							}
							this.playerStatus.damage += num7;
						}
						if (!this.enemyBody.ownATKHitted)
						{
							this.enemyBody.ownATKHitted = true;
						}
					}
					this.hitedATK = true;
				}
			}
		}

		// Token: 0x06002B3F RID: 11071 RVA: 0x004866EC File Offset: 0x004848EC
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				this.currentEnemyBody = other.transform.parent.GetComponent<EnemyBody>();
				this.enemyBody = other.transform.parent.GetComponent<EnemyBody>();
				Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
				float x = vector.x;
				float y = vector.y;
				if (this.playerCtrl != null)
				{
					switch (this.weaponSwitch)
					{
					case 8:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num < 1f)
								{
									num = 1f;
								}
								this.playerCtrl.HPMPHeal(num, 0f);
							}
							bool flag = this.switchSkill;
							if (flag)
							{
								if (flag)
								{
									bool flag2 = this.subATK;
									if (flag2)
									{
										if (flag2)
										{
											this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag3 = this.subATK;
								if (flag3)
								{
									if (flag3)
									{
										this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 9:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num2 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num2 < 1f)
								{
									num2 = 1f;
								}
								this.playerCtrl.HPMPHeal(num2, 0f);
							}
							bool flag4 = this.switchSkill;
							if (flag4)
							{
								if (flag4)
								{
									bool flag5 = this.subATK;
									if (flag5)
									{
										if (flag5)
										{
											this.enemyBody.RPCActionDamageGungnir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageGungnir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag6 = this.subATK;
								if (flag6)
								{
									if (flag6)
									{
										this.enemyBody.RPCActionDamageGungnir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageGungnir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 10:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num3 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num3 < 1f)
								{
									num3 = 1f;
								}
								this.playerCtrl.HPMPHeal(num3, 0f);
							}
							bool flag7 = this.switchSkill;
							if (flag7)
							{
								if (flag7)
								{
									bool flag8 = this.subATK;
									if (flag8)
									{
										if (flag8)
										{
											this.enemyBody.RPCActionDamageMyornir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageMyornir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag9 = this.subATK;
								if (flag9)
								{
									if (flag9)
									{
										this.enemyBody.RPCActionDamageMyornir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageMyornir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 11:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num4 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num4 < 1f)
								{
									num4 = 1f;
								}
								this.playerCtrl.HPMPHeal(num4, 0f);
							}
							bool flag10 = this.switchSkill;
							if (flag10)
							{
								if (flag10)
								{
									bool flag11 = this.subATK;
									if (flag11)
									{
										if (flag11)
										{
											this.enemyBody.RPCActionDamageBearCrow(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageBearCrow(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag12 = this.subATK;
								if (flag12)
								{
									if (flag12)
									{
										this.enemyBody.RPCActionDamageBearCrow(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageBearCrow(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusCurseRandom(base.transform.position.x, base.transform.position.y);
							}
						}
						break;
					case 12:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num5 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num5 < 1f)
								{
									num5 = 1f;
								}
								this.playerCtrl.HPMPHeal(num5, 0f);
							}
							bool flag13 = this.switchSkill;
							if (flag13)
							{
								if (flag13)
								{
									bool flag14 = this.subATK;
									if (flag14)
									{
										if (flag14)
										{
											this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y, 2);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y, 2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag15 = this.subATK;
								if (flag15)
								{
									if (flag15)
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 13:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num6 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num6 < 1f)
								{
									num6 = 1f;
								}
								this.playerCtrl.HPMPHeal(num6, 0f);
							}
							bool flag16 = this.switchSkill;
							if (flag16)
							{
								if (flag16)
								{
									bool flag17 = this.subATK;
									if (flag17)
									{
										if (flag17)
										{
											this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag18 = this.subATK;
								if (flag18)
								{
									if (flag18)
									{
										this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 15:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num7 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num7 < 1f)
								{
									num7 = 1f;
								}
								this.playerCtrl.HPMPHeal(num7, 0f);
							}
							bool flag19 = this.switchSkill;
							if (flag19)
							{
								if (flag19)
								{
									bool flag20 = this.subATK;
									if (flag20)
									{
										if (flag20)
										{
											this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag21 = this.subATK;
								if (flag21)
								{
									if (flag21)
									{
										this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 16:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num8 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num8 < 1f)
								{
									num8 = 1f;
								}
								this.playerCtrl.HPMPHeal(num8, 0f);
							}
							bool flag22 = this.switchSkill;
							if (flag22)
							{
								if (flag22)
								{
									bool flag23 = this.subATK;
									if (flag23)
									{
										if (flag23)
										{
											this.enemyBody.RPCActionDamageIce(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageIce(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag24 = this.subATK;
								if (flag24)
								{
									if (flag24)
									{
										this.enemyBody.RPCActionDamageIce(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageIce(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					}
				}
				if (this.myPV.isMine)
				{
					if (this.playerCtrl != null)
					{
						float f = 0f;
						bool flag25 = this.switchSkill;
						if (flag25)
						{
							if (flag25)
							{
								bool flag26 = this.subATK;
								if (flag26)
								{
									if (flag26)
									{
										f = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f);
									}
								}
								else
								{
									f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f);
								}
							}
						}
						else
						{
							bool flag27 = this.subATK;
							if (flag27)
							{
								if (flag27)
								{
									f = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK);
								}
							}
							else
							{
								f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							}
						}
						int num9 = Mathf.RoundToInt(f);
						if (num9 < 1)
						{
							num9 = 1;
						}
						this.playerStatus.damage += num9;
					}
					if (!this.enemyBody.ownATKHitted)
					{
						this.enemyBody.ownATKHitted = true;
					}
				}
			}
			else if (other.tag == "EnemyBodyAttackSp")
			{
				this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
				Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
				float x2 = vector2.x;
				float y2 = vector2.y;
				if (this.playerCtrl != null)
				{
					switch (this.weaponSwitch)
					{
					case 8:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num10 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num10 < 1f)
								{
									num10 = 1f;
								}
								this.playerCtrl.HPMPHeal(num10, 0f);
							}
							bool flag28 = this.switchSkill;
							if (flag28)
							{
								if (flag28)
								{
									bool flag29 = this.subATK;
									if (flag29)
									{
										if (flag29)
										{
											this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag30 = this.subATK;
								if (flag30)
								{
									if (flag30)
									{
										this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 9:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num11 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num11 < 1f)
								{
									num11 = 1f;
								}
								this.playerCtrl.HPMPHeal(num11, 0f);
							}
							bool flag31 = this.switchSkill;
							if (flag31)
							{
								if (flag31)
								{
									bool flag32 = this.subATK;
									if (flag32)
									{
										if (flag32)
										{
											this.enemyBody.RPCActionDamageGungnir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageGungnir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag33 = this.subATK;
								if (flag33)
								{
									if (flag33)
									{
										this.enemyBody.RPCActionDamageGungnir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageGungnir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 10:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num12 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num12 < 1f)
								{
									num12 = 1f;
								}
								this.playerCtrl.HPMPHeal(num12, 0f);
							}
							bool flag34 = this.switchSkill;
							if (flag34)
							{
								if (flag34)
								{
									bool flag35 = this.subATK;
									if (flag35)
									{
										if (flag35)
										{
											this.enemyBody.RPCActionDamageMyornir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageMyornir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag36 = this.subATK;
								if (flag36)
								{
									if (flag36)
									{
										this.enemyBody.RPCActionDamageMyornir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageMyornir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 11:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num13 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num13 < 1f)
								{
									num13 = 1f;
								}
								this.playerCtrl.HPMPHeal(num13, 0f);
							}
							bool flag37 = this.switchSkill;
							if (flag37)
							{
								if (flag37)
								{
									bool flag38 = this.subATK;
									if (flag38)
									{
										if (flag38)
										{
											this.enemyBody.RPCActionDamageBearCrow(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageBearCrow(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag39 = this.subATK;
								if (flag39)
								{
									if (flag39)
									{
										this.enemyBody.RPCActionDamageBearCrow(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageBearCrow(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusCurseRandom(base.transform.position.x, base.transform.position.y);
							}
						}
						break;
					case 12:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num14 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num14 < 1f)
								{
									num14 = 1f;
								}
								this.playerCtrl.HPMPHeal(num14, 0f);
							}
							bool flag40 = this.switchSkill;
							if (flag40)
							{
								if (flag40)
								{
									bool flag41 = this.subATK;
									if (flag41)
									{
										if (flag41)
										{
											this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag42 = this.subATK;
								if (flag42)
								{
									if (flag42)
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 13:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num15 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num15 < 1f)
								{
									num15 = 1f;
								}
								this.playerCtrl.HPMPHeal(num15, 0f);
							}
							bool flag43 = this.switchSkill;
							if (flag43)
							{
								if (flag43)
								{
									bool flag44 = this.subATK;
									if (flag44)
									{
										if (flag44)
										{
											this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag45 = this.subATK;
								if (flag45)
								{
									if (flag45)
									{
										this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 15:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num16 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num16 < 1f)
								{
									num16 = 1f;
								}
								this.playerCtrl.HPMPHeal(num16, 0f);
							}
							bool flag46 = this.switchSkill;
							if (flag46)
							{
								if (flag46)
								{
									bool flag47 = this.subATK;
									if (flag47)
									{
										if (flag47)
										{
											this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag48 = this.subATK;
								if (flag48)
								{
									if (flag48)
									{
										this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 16:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num17 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num17 < 1f)
								{
									num17 = 1f;
								}
								this.playerCtrl.HPMPHeal(num17, 0f);
							}
							bool flag49 = this.switchSkill;
							if (flag49)
							{
								if (flag49)
								{
									bool flag50 = this.subATK;
									if (flag50)
									{
										if (flag50)
										{
											this.enemyBody.RPCActionDamageIce(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageIce(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag51 = this.subATK;
								if (flag51)
								{
									if (flag51)
									{
										this.enemyBody.RPCActionDamageIce(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageIce(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					}
				}
				if (this.myPV.isMine)
				{
					if (this.playerCtrl != null)
					{
						float f2 = 0f;
						bool flag52 = this.switchSkill;
						if (flag52)
						{
							if (flag52)
							{
								bool flag53 = this.subATK;
								if (flag53)
								{
									if (flag53)
									{
										f2 = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f);
									}
								}
								else
								{
									f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f);
								}
							}
						}
						else
						{
							bool flag54 = this.subATK;
							if (flag54)
							{
								if (flag54)
								{
									f2 = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK);
								}
							}
							else
							{
								f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							}
						}
						int num18 = Mathf.RoundToInt(f2);
						if (num18 < 1)
						{
							num18 = 1;
						}
						this.playerStatus.damage += num18;
					}
					if (!this.enemyBody.ownATKHitted)
					{
						this.enemyBody.ownATKHitted = true;
					}
				}
			}
			else if (other.tag == "EnemyBodyAttackBoss01")
			{
				this.bB = other.GetComponent<Boss01BodyDetect>();
				this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
				Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
				float x3 = vector3.x;
				float y3 = vector3.y;
				if (this.playerCtrl != null)
				{
					switch (this.weaponSwitch)
					{
					case 8:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num19 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num19 < 1f)
								{
									num19 = 1f;
								}
								this.playerCtrl.HPMPHeal(num19, 0f);
							}
							bool flag55 = this.switchSkill;
							if (flag55)
							{
								if (flag55)
								{
									bool flag56 = this.subATK;
									if (flag56)
									{
										if (flag56)
										{
											this.bB.ActionDamageAgni(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.bB.ActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag57 = this.subATK;
								if (flag57)
								{
									if (flag57)
									{
										this.bB.ActionDamageAgni(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.bB.ActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 9:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num20 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num20 < 1f)
								{
									num20 = 1f;
								}
								this.playerCtrl.HPMPHeal(num20, 0f);
							}
							bool flag58 = this.switchSkill;
							if (flag58)
							{
								if (flag58)
								{
									bool flag59 = this.subATK;
									if (flag59)
									{
										if (flag59)
										{
											this.bB.ActionDamageGungnir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.bB.ActionDamageGungnir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag60 = this.subATK;
								if (flag60)
								{
									if (flag60)
									{
										this.bB.ActionDamageGungnir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.bB.ActionDamageGungnir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 10:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num21 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num21 < 1f)
								{
									num21 = 1f;
								}
								this.playerCtrl.HPMPHeal(num21, 0f);
							}
							bool flag61 = this.switchSkill;
							if (flag61)
							{
								if (flag61)
								{
									bool flag62 = this.subATK;
									if (flag62)
									{
										if (flag62)
										{
											this.bB.ActionDamageMyornir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.bB.ActionDamageMyornir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag63 = this.subATK;
								if (flag63)
								{
									if (flag63)
									{
										this.bB.ActionDamageMyornir(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.bB.ActionDamageMyornir(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 11:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num22 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num22 < 1f)
								{
									num22 = 1f;
								}
								this.playerCtrl.HPMPHeal(num22, 0f);
							}
							bool flag64 = this.switchSkill;
							if (flag64)
							{
								if (flag64)
								{
									bool flag65 = this.subATK;
									if (flag65)
									{
										if (flag65)
										{
											this.bB.ActionDamageBearCrow(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.bB.ActionDamageBearCrow(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag66 = this.subATK;
								if (flag66)
								{
									if (flag66)
									{
										this.bB.ActionDamageBearCrow(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.bB.ActionDamageBearCrow(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusCurseRandom(base.transform.position.x, base.transform.position.y);
							}
						}
						break;
					case 12:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num23 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num23 < 1f)
								{
									num23 = 1f;
								}
								this.playerCtrl.HPMPHeal(num23, 0f);
							}
							bool flag67 = this.switchSkill;
							if (flag67)
							{
								if (flag67)
								{
									bool flag68 = this.subATK;
									if (flag68)
									{
										if (flag68)
										{
											this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3, 2);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3, 2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag69 = this.subATK;
								if (flag69)
								{
									if (flag69)
									{
										this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 2);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 2);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 13:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num24 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num24 < 1f)
								{
									num24 = 1f;
								}
								this.playerCtrl.HPMPHeal(num24, 0f);
							}
							bool flag70 = this.switchSkill;
							if (flag70)
							{
								if (flag70)
								{
									bool flag71 = this.subATK;
									if (flag71)
									{
										if (flag71)
										{
											this.bB.ActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.bB.ActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag72 = this.subATK;
								if (flag72)
								{
									if (flag72)
									{
										this.bB.ActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.bB.ActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 15:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num25 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num25 < 1f)
								{
									num25 = 1f;
								}
								this.playerCtrl.HPMPHeal(num25, 0f);
							}
							bool flag73 = this.switchSkill;
							if (flag73)
							{
								if (flag73)
								{
									bool flag74 = this.subATK;
									if (flag74)
									{
										if (flag74)
										{
											this.bB.ActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.bB.ActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag75 = this.subATK;
								if (flag75)
								{
									if (flag75)
									{
										this.bB.ActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.bB.ActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					case 16:
						if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
						{
							if (this.playerCtrl.lvlSakyubasu > 0)
							{
								float num26 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlSakyubasu);
								if (num26 < 1f)
								{
									num26 = 1f;
								}
								this.playerCtrl.HPMPHeal(num26, 0f);
							}
							bool flag76 = this.switchSkill;
							if (flag76)
							{
								if (flag76)
								{
									bool flag77 = this.subATK;
									if (flag77)
									{
										if (flag77)
										{
											this.bB.ActionDamageIce(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
											this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
										}
									}
									else
									{
										this.bB.ActionDamageIce(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
							}
							else
							{
								bool flag78 = this.subATK;
								if (flag78)
								{
									if (flag78)
									{
										this.bB.ActionDamageIce(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
										this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
									}
								}
								else
								{
									this.bB.ActionDamageIce(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
									this.enemyBody.ReciveBoolReturn(0.2f, "ATK", this.playerNumber);
								}
							}
						}
						break;
					}
				}
				if (this.myPV.isMine)
				{
					if (this.playerCtrl != null)
					{
						float f3 = 0f;
						bool flag79 = this.switchSkill;
						if (flag79)
						{
							if (flag79)
							{
								bool flag80 = this.subATK;
								if (flag80)
								{
									if (flag80)
									{
										f3 = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f);
									}
								}
								else
								{
									f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f);
								}
							}
						}
						else
						{
							bool flag81 = this.subATK;
							if (flag81)
							{
								if (flag81)
								{
									f3 = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK);
								}
							}
							else
							{
								f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							}
						}
						int num27 = Mathf.RoundToInt(f3);
						if (num27 < 1)
						{
							num27 = 1;
						}
						this.playerStatus.damage += num27;
					}
					if (!this.enemyBody.ownATKHitted)
					{
						this.enemyBody.ownATKHitted = true;
					}
				}
			}
		}

		// Token: 0x06002B40 RID: 11072 RVA: 0x0048A350 File Offset: 0x00488550
		private void Update()
		{
			if (this.col2d != null && !this.col2d.enabled && this.hitedATK)
			{
				this.enemyBody = null;
				this.currentEnemyBody = null;
				this.bB = null;
				this.currentBB = null;
				this.hitedATK = false;
			}
			if (this.cCol2d != null && !this.cCol2d.enabled && this.hitedATK)
			{
				this.enemyBody = null;
				this.currentEnemyBody = null;
				this.bB = null;
				this.currentBB = null;
				this.hitedATK = false;
			}
			if (this.playerCtrl != null && this.playerNumber != this.playerCtrl.playerNumber)
			{
				this.playerNumber = this.playerCtrl.playerNumber;
			}
		}

		// Token: 0x06002B41 RID: 11073 RVA: 0x0048A434 File Offset: 0x00488634
		private int ReturnBool(int num, EnemyBody targetEnemyBody)
		{
			int num2 = 0;
			switch (num)
			{
			case 1:
				if (!targetEnemyBody.canRecive_ATK)
				{
					num2++;
				}
				break;
			case 2:
				if (!targetEnemyBody.canRecive_ATK1)
				{
					num2++;
				}
				break;
			case 3:
				if (!targetEnemyBody.canRecive_ATK2)
				{
					num2++;
				}
				break;
			case 4:
				if (!targetEnemyBody.canRecive_ATK3)
				{
					num2++;
				}
				break;
			case 5:
				if (!targetEnemyBody.canRecive_ATK4)
				{
					num2++;
				}
				break;
			case 6:
				if (!targetEnemyBody.canRecive_ATK5)
				{
					num2++;
				}
				break;
			case 7:
				if (!targetEnemyBody.canRecive_ATK6)
				{
					num2++;
				}
				break;
			case 8:
				if (!targetEnemyBody.canRecive_ATK7)
				{
					num2++;
				}
				break;
			case 9:
				if (!targetEnemyBody.canRecive_ATK8)
				{
					num2++;
				}
				break;
			case 10:
				if (!targetEnemyBody.canRecive_ATK9)
				{
					num2++;
				}
				break;
			}
			return num2;
		}

		// Token: 0x040051F7 RID: 20983
		public bool hitedATK;

		// Token: 0x040051F8 RID: 20984
		private PlayerStatus playerStatus;

		// Token: 0x040051F9 RID: 20985
		private BoxCollider2D col2d;

		// Token: 0x040051FA RID: 20986
		public CircleCollider2D cCol2d;

		// Token: 0x040051FB RID: 20987
		public PhotonView myPV;

		// Token: 0x040051FC RID: 20988
		private EnemyBody enemyBody;

		// Token: 0x040051FD RID: 20989
		private EnemyBody currentEnemyBody;

		// Token: 0x040051FE RID: 20990
		private Boss01BodyDetect bB;

		// Token: 0x040051FF RID: 20991
		private Boss01BodyDetect currentBB;

		// Token: 0x04005200 RID: 20992
		public PlayerController_Soma playerCtrl;

		// Token: 0x04005201 RID: 20993
		public int weaponSwitch;

		// Token: 0x04005202 RID: 20994
		public int playerNumber;

		// Token: 0x04005203 RID: 20995
		public bool switchSkill;

		// Token: 0x04005204 RID: 20996
		public bool subATK;

		// Token: 0x04005205 RID: 20997
		public bool tyupakabura;

		// Token: 0x04005206 RID: 20998
		public bool mine;
	}
}
