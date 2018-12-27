using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200046A RID: 1130
	public class ATKAlucard : MonoBehaviour
	{
		// Token: 0x06002AF7 RID: 10999 RVA: 0x00470814 File Offset: 0x0046EA14
		private void Awake()
		{
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
			if (this.cCol2d == null)
			{
				this.col2d = base.GetComponent<BoxCollider2D>();
			}
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			if (base.transform.root.GetComponent<PhotonView>().isMine)
			{
				this.mine = true;
			}
		}

		// Token: 0x06002AF8 RID: 11000 RVA: 0x0047088C File Offset: 0x0046EA8C
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody" || other.tag == "EnemyBodyAttackSp")
			{
				if (other.transform.parent.GetComponent<EnemyBody>() != null)
				{
					this.currentEnemyBody = other.transform.parent.GetComponent<EnemyBody>();
				}
				else if (other.transform.parent.parent.GetComponent<EnemyBody>() != null)
				{
					this.currentEnemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
				}
				if (this.hitedATK)
				{
					if (!(this.currentEnemyBody == this.enemyBody))
					{
						this.hitedATK = false;
					}
				}
				if (!this.hitedATK)
				{
					if (other.transform.parent.GetComponent<EnemyBody>() != null)
					{
						this.enemyBody = other.transform.parent.GetComponent<EnemyBody>();
					}
					else if (other.transform.parent.parent.GetComponent<EnemyBody>() != null)
					{
						this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
					}
					Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x = vector.x;
					float y = vector.y;
					if (this.playerCtrl != null)
					{
						if (this.playerCtrl.darkMetamol)
						{
							float num = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlDarkMetamol * this.playerCtrl.bloodStone);
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
								bool flag3 = this.subATK;
								if (flag3)
								{
									if (flag3)
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
								bool flag6 = this.subATK;
								if (flag6)
								{
									if (flag6)
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
								bool flag9 = this.subATK;
								if (flag9)
								{
									if (flag9)
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
											this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
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
										this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
								}
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
								bool flag15 = this.subATK;
								if (flag15)
								{
									if (flag15)
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
											this.enemyBody.RPCActionDamageIndra(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageIndra(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
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
										this.enemyBody.RPCActionDamageIndra(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageIndra(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
								}
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
								bool flag21 = this.subATK;
								if (flag21)
								{
									if (flag21)
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
						case 8:
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
								bool flag24 = this.subATK;
								if (flag24)
								{
									if (flag24)
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
						case 9:
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
											this.enemyBody.RPCActionDamageDragonSlayer(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageDragonSlayer(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
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
										this.enemyBody.RPCActionDamageDragonSlayer(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageDragonSlayer(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusCurseRandom(x, y);
							}
							break;
						}
						case 10:
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
								bool flag30 = this.subATK;
								if (flag30)
								{
									if (flag30)
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
						case 11:
						{
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
								bool flag33 = this.subATK;
								if (flag33)
								{
									if (flag33)
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
								}
							}
							this.InstantiateHealBall(x, y);
							break;
						}
						case 12:
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
								bool flag36 = this.subATK;
								if (flag36)
								{
									if (flag36)
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
								}
							}
							if (this.myPV.isMine)
							{
								this.ExpPlus(this.enemyBody.enemyLevel);
							}
							break;
						}
						case 13:
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
											this.enemyBody.RPCActionDamageVampireKiller(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageVampireKiller(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
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
										this.enemyBody.RPCActionDamageVampireKiller(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageVampireKiller(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
								}
							}
							break;
						}
						case 14:
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
								bool flag42 = this.subATK;
								if (flag42)
								{
									if (flag42)
									{
										this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
									}
								}
								else
								{
									this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
								}
							}
							this.InstantiateMpHealBall(x, y);
							break;
						}
						case 15:
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
								bool flag45 = this.subATK;
								if (flag45)
								{
									if (flag45)
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
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f = 0f;
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
								bool flag48 = this.subATK;
								if (flag48)
								{
									if (flag48)
									{
										f = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK);
									}
								}
								else
								{
									f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
								}
							}
							int num2 = Mathf.RoundToInt(f);
							if (num2 < 1)
							{
								num2 = 1;
							}
							this.playerStatus.damage += num2;
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
					if (other.transform.parent.GetComponent<EnemyBody>() != null)
					{
						this.enemyBody = other.transform.parent.GetComponent<EnemyBody>();
					}
					else if (other.transform.parent.parent.GetComponent<EnemyBody>() != null)
					{
						this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
					}
					Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x2 = vector2.x;
					float y2 = vector2.y;
					if (this.playerCtrl != null)
					{
						if (this.playerCtrl.darkMetamol)
						{
							float num3 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlDarkMetamol * this.playerCtrl.bloodStone);
							if (num3 < 1f)
							{
								num3 = 1f;
							}
							this.playerCtrl.HPMPHeal(num3, 0f);
						}
						switch (this.weaponSwitch)
						{
						case 1:
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
											this.bB.ActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 1);
										}
									}
									else
									{
										this.bB.ActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 1);
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
										this.bB.ActionDamagePoke(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 1);
									}
								}
								else
								{
									this.bB.ActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 1);
								}
							}
							break;
						}
						case 2:
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
											this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
										}
									}
									else
									{
										this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
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
										this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
									}
								}
								else
								{
									this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
								}
							}
							break;
						}
						case 3:
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
											this.bB.ActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.bB.ActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
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
										this.bB.ActionDamageHit(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.bB.ActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							break;
						}
						case 4:
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
											this.bB.ActionDamageAgni(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.bB.ActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
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
										this.bB.ActionDamageAgni(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.bB.ActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							break;
						}
						case 5:
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
											this.bB.ActionDamageRahab(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.bB.ActionDamageRahab(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
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
										this.bB.ActionDamageRahab(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.bB.ActionDamageRahab(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							break;
						}
						case 6:
						{
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
											this.bB.ActionDamageIndra(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.bB.ActionDamageIndra(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
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
										this.bB.ActionDamageIndra(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.bB.ActionDamageIndra(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							break;
						}
						case 7:
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
											this.bB.ActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.bB.ActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
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
										this.bB.ActionDamageKugiBat(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.bB.ActionDamageKugiBat(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							break;
						}
						case 8:
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
											this.bB.ActionDamageAssasinBlade(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.bB.ActionDamageAssasinBlade(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
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
										this.bB.ActionDamageAssasinBlade(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.bB.ActionDamageAssasinBlade(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusPoisonRandom(x2, y2);
							}
							break;
						}
						case 9:
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
											this.bB.ActionDamageDragonSlayer(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.bB.ActionDamageDragonSlayer(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
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
										this.bB.ActionDamageDragonSlayer(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.bB.ActionDamageDragonSlayer(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusCurseRandom(x2, y2);
							}
							break;
						}
						case 10:
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
											this.bB.ActionDamageMilican(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.bB.ActionDamageMilican(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
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
										this.bB.ActionDamageMilican(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.bB.ActionDamageMilican(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
								}
							}
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusStoneRandom(x2, y2);
							}
							break;
						}
						case 11:
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
											this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
										}
									}
									else
									{
										this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
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
										this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
									}
								}
								else
								{
									this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
								}
							}
							this.InstantiateHealBall(x2, y2);
							break;
						}
						case 12:
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
											this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
										}
									}
									else
									{
										this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
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
										this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
									}
								}
								else
								{
									this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
								}
							}
							if (this.myPV.isMine)
							{
								this.ExpPlus(this.enemyBody.enemyLevel);
							}
							break;
						}
						case 13:
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
											this.bB.ActionDamageVampireKiller(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.bB.ActionDamageVampireKiller(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
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
										this.bB.ActionDamageVampireKiller(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.bB.ActionDamageVampireKiller(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
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
											this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
										}
									}
									else
									{
										this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2, 2);
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
										this.bB.ActionDamageCut(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
									}
								}
								else
								{
									this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
								}
							}
							this.InstantiateMpHealBall(x2, y2);
							break;
						}
						case 15:
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
											this.bB.ActionDamageStellaSword(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.bB.ActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
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
										this.bB.ActionDamageStellaSword(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								else
								{
									this.bB.ActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
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
								bool flag96 = this.subATK;
								if (flag96)
								{
									if (flag96)
									{
										f2 = Mathf.Round(this.playerCtrl.aTK_Sub * this.playerCtrl.berserkerMeiruATK);
									}
								}
								else
								{
									f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
								}
							}
							int num4 = Mathf.RoundToInt(f2);
							if (num4 < 1)
							{
								num4 = 1;
							}
							this.playerStatus.damage += num4;
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

		// Token: 0x06002AF9 RID: 11001 RVA: 0x004736D8 File Offset: 0x004718D8
		private void OnTriggerStay2D(Collider2D other)
		{
			if (this.weaponSwitch == 16)
			{
				if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody" || other.tag == "EnemyBodyAttackSp")
				{
					if (other.transform.parent.GetComponent<EnemyBody>() != null)
					{
						this.enemyBody = other.transform.parent.GetComponent<EnemyBody>();
					}
					else if (other.transform.parent.parent.GetComponent<EnemyBody>() != null)
					{
						this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
					}
					Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x = vector.x;
					float y = vector.y;
					if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
					{
						if (this.playerCtrl != null)
						{
							if (this.playerCtrl.darkMetamol)
							{
								float num = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlDarkMetamol * this.playerCtrl.bloodStone);
								if (num < 1f)
								{
									num = 1f;
								}
								this.playerCtrl.HPMPHeal(num, 0f);
							}
							int num2 = this.weaponSwitch;
							if (num2 == 16)
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
												this.enemyBody.RPCActionDamageDark(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
											}
										}
										else
										{
											this.enemyBody.RPCActionDamageDark(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x, y);
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
											this.enemyBody.RPCActionDamageDark(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
										}
									}
									else
									{
										this.enemyBody.RPCActionDamageDark(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
									}
								}
								this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
							}
						}
						if (this.myPV.isMine)
						{
							if (this.playerCtrl != null)
							{
								float f = 0f;
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
												f = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * 2f);
											}
										}
										else
										{
											f = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * 2f);
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
											f = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK);
										}
									}
									else
									{
										f = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK);
									}
								}
								int num3 = Mathf.RoundToInt(f);
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
					}
				}
				else if (other.tag == "EnemyBodyAttackBoss01")
				{
					this.bB = other.GetComponent<Boss01BodyDetect>();
					if (other.transform.parent.GetComponent<EnemyBody>() != null)
					{
						this.enemyBody = other.transform.parent.GetComponent<EnemyBody>();
					}
					else if (other.transform.parent.parent.GetComponent<EnemyBody>() != null)
					{
						this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
					}
					Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x2 = vector2.x;
					float y2 = vector2.y;
					if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
					{
						if (this.playerCtrl != null)
						{
							if (this.playerCtrl.darkMetamol)
							{
								float num4 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK / 50f * (float)this.playerCtrl.lvlDarkMetamol * this.playerCtrl.bloodStone);
								if (num4 < 1f)
								{
									num4 = 1f;
								}
								this.playerCtrl.HPMPHeal(num4, 0f);
							}
							int num5 = this.weaponSwitch;
							if (num5 == 16)
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
												this.bB.ActionDamageDark(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
											}
										}
										else
										{
											this.bB.ActionDamageDark(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * 2f, this.playerCtrl.dEX, x2, y2);
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
											this.bB.ActionDamageDark(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
										}
									}
									else
									{
										this.bB.ActionDamageDark(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
									}
								}
								this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
							}
						}
						if (this.myPV.isMine)
						{
							if (this.playerCtrl != null)
							{
								float f2 = 0f;
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
												f2 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * 2f);
											}
										}
										else
										{
											f2 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK * 2f);
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
											f2 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK);
										}
									}
									else
									{
										f2 = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK);
									}
								}
								int num6 = Mathf.RoundToInt(f2);
								if (num6 < 1)
								{
									num6 = 1;
								}
								this.playerStatus.damage += num6;
							}
							if (!this.enemyBody.ownATKHitted)
							{
								this.enemyBody.ownATKHitted = true;
							}
						}
					}
				}
			}
		}

		// Token: 0x06002AFA RID: 11002 RVA: 0x00473F8C File Offset: 0x0047218C
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

		// Token: 0x06002AFB RID: 11003 RVA: 0x00474070 File Offset: 0x00472270
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

		// Token: 0x06002AFC RID: 11004 RVA: 0x00474180 File Offset: 0x00472380
		private void ExpPlus(int lvl)
		{
			if (this.playerCtrl != null && this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expMuramasa += 1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expMuramasa += 2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expMuramasa += 3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expMuramasa += 4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expMuramasa += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expMuramasa += 6f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x06002AFD RID: 11005 RVA: 0x004742C4 File Offset: 0x004724C4
		private void InstantiateHealBall(float x, float y)
		{
			float num = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK);
			num /= 10f;
			int num2 = Mathf.RoundToInt(num);
			Debug.Log(num2);
			if (num2 < 1)
			{
				num2 = 1;
			}
			this.instantiateManager.PlayerBloodyCroosHealOrb(x, y, num2, base.transform.root.gameObject);
		}

		// Token: 0x06002AFE RID: 11006 RVA: 0x00474330 File Offset: 0x00472530
		private void InstantiateMpHealBall(float x, float y)
		{
			float num = Mathf.Round(this.playerCtrl.iNT * this.playerCtrl.berserkerMeiruATK);
			num /= 10f;
			int num2 = Mathf.RoundToInt(num);
			Debug.Log(num2);
			if (num2 < 1)
			{
				num2 = 1;
			}
			this.instantiateManager.PlayerMpHealOrb(x, y, num2, base.transform.root.gameObject);
		}

		// Token: 0x0400515C RID: 20828
		public bool hitedATK;

		// Token: 0x0400515D RID: 20829
		private PlayerStatus playerStatus;

		// Token: 0x0400515E RID: 20830
		private BoxCollider2D col2d;

		// Token: 0x0400515F RID: 20831
		public CircleCollider2D cCol2d;

		// Token: 0x04005160 RID: 20832
		public PhotonView myPV;

		// Token: 0x04005161 RID: 20833
		private EnemyBody enemyBody;

		// Token: 0x04005162 RID: 20834
		private EnemyBody currentEnemyBody;

		// Token: 0x04005163 RID: 20835
		private Boss01BodyDetect bB;

		// Token: 0x04005164 RID: 20836
		private Boss01BodyDetect currentBB;

		// Token: 0x04005165 RID: 20837
		public PlayerController_Alucard playerCtrl;

		// Token: 0x04005166 RID: 20838
		public int weaponSwitch;

		// Token: 0x04005167 RID: 20839
		public int playerNumber;

		// Token: 0x04005168 RID: 20840
		public bool switchSkill;

		// Token: 0x04005169 RID: 20841
		public bool subATK;

		// Token: 0x0400516A RID: 20842
		public bool tyupakabura;

		// Token: 0x0400516B RID: 20843
		public bool mine;

		// Token: 0x0400516C RID: 20844
		private InstantiateManager instantiateManager;
	}
}
