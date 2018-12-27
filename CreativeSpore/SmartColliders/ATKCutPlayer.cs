using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200046F RID: 1135
	public class ATKCutPlayer : MonoBehaviour
	{
		// Token: 0x06002B16 RID: 11030 RVA: 0x00476B60 File Offset: 0x00474D60
		private void Awake()
		{
			if (base.transform.parent.GetComponent<PlayerController>() != null)
			{
				this.playerCtrl = base.transform.parent.GetComponent<PlayerController>();
				this.myPV = base.transform.parent.GetComponent<PhotonView>();
			}
			this.col2d = base.GetComponent<BoxCollider2D>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06002B17 RID: 11031 RVA: 0x00476BD8 File Offset: 0x00474DD8
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				if (this.playerCtrl_Shanoa != null && (other.transform.parent.name == "Enemy_Kani" || other.transform.parent.name == "Enemy_FinalGuard"))
				{
					int num = UnityEngine.Random.Range(0, 9);
					if (num == 5)
					{
						this.playerCtrl_Shanoa.CV_Anim();
					}
				}
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
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y, 2);
						}
						else if (this.subATK)
						{
							this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y, 2);
						}
					}
					else if (this.playerCtrl_Add1 != null)
					{
						this.ExpPlus2(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageCut(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK, this.playerCtrl_Add1.dEX, x, y, 2);
					}
					else if (this.playerCtrl_Alucard != null)
					{
						this.enemyBody.RPCActionDamageCut((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK, this.playerCtrl_Alucard.dEX, x, y, 2);
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num2 = Mathf.RoundToInt(f);
							if (num2 < 1)
							{
								num2 = 1;
							}
							this.playerStatus.damage += num2;
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							float f2 = 0f;
							if (!this.subATK)
							{
								f2 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							else if (this.subATK)
							{
								f2 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							int num3 = Mathf.RoundToInt(f2);
							if (num3 < 1)
							{
								num3 = 1;
							}
							this.playerStatus.damage += num3;
						}
						else if (this.playerCtrl_Add1 != null)
						{
							float f3 = Mathf.Round(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK);
							int num4 = Mathf.RoundToInt(f3);
							if (num4 < 1)
							{
								num4 = 1;
							}
							this.playerStatus.damage += num4;
						}
						else if (this.playerCtrl_Alucard != null)
						{
							float f4 = Mathf.Round((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK);
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
			else if (other.tag == "EnemyBodyAttackSp")
			{
				if (this.playerCtrl_Shanoa != null && other.transform.parent.parent.name == "Enemy_Kani")
				{
					int num6 = UnityEngine.Random.Range(0, 9);
					if (num6 == 5)
					{
						this.playerCtrl_Shanoa.CV_Anim();
					}
				}
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
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2, 2);
						}
						else if (this.subATK)
						{
							this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2, 2);
						}
					}
					else if (this.playerCtrl_Add1 != null)
					{
						this.ExpPlus2(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageCut(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK, this.playerCtrl_Add1.dEX, x2, y2, 2);
					}
					else if (this.playerCtrl_Alucard != null)
					{
						this.enemyBody.RPCActionDamageCut((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK, this.playerCtrl_Alucard.dEX, x2, y2, 2);
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f5 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num7 = Mathf.RoundToInt(f5);
							if (num7 < 1)
							{
								num7 = 1;
							}
							this.playerStatus.damage += num7;
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							float f6 = 0f;
							if (!this.subATK)
							{
								f6 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							else if (this.subATK)
							{
								f6 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							int num8 = Mathf.RoundToInt(f6);
							if (num8 < 1)
							{
								num8 = 1;
							}
							this.playerStatus.damage += num8;
						}
						else if (this.playerCtrl_Add1 != null)
						{
							float f7 = Mathf.Round(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK);
							int num9 = Mathf.RoundToInt(f7);
							if (num9 < 1)
							{
								num9 = 1;
							}
							this.playerStatus.damage += num9;
						}
						else if (this.playerCtrl_Alucard != null)
						{
							float f8 = Mathf.Round((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK);
							int num10 = Mathf.RoundToInt(f8);
							if (num10 < 1)
							{
								num10 = 1;
							}
							this.playerStatus.damage += num10;
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
						this.ExpPlus(this.bB.enemyLevel);
						this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 2);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.bB.ActionDamageCut(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3, 2);
						}
						else if (this.subATK)
						{
							this.bB.ActionDamageCut(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3, 2);
						}
					}
					else if (this.playerCtrl_Add1 != null)
					{
						this.ExpPlus2(this.bB.enemyLevel);
						this.bB.ActionDamageCut(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK, this.playerCtrl_Add1.dEX, x3, y3, 2);
					}
					else if (this.playerCtrl_Alucard != null)
					{
						this.bB.ActionDamageCut((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK, this.playerCtrl_Alucard.dEX, x3, y3, 2);
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f9 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num11 = Mathf.RoundToInt(f9);
							if (num11 < 1)
							{
								num11 = 1;
							}
							this.playerStatus.damage += num11;
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							float f10 = 0f;
							if (!this.subATK)
							{
								f10 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							else if (this.subATK)
							{
								f10 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							int num12 = Mathf.RoundToInt(f10);
							if (num12 < 1)
							{
								num12 = 1;
							}
							this.playerStatus.damage += num12;
						}
						else if (this.playerCtrl_Add1 != null)
						{
							float f11 = Mathf.Round(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK);
							int num13 = Mathf.RoundToInt(f11);
							if (num13 < 1)
							{
								num13 = 1;
							}
							this.playerStatus.damage += num13;
						}
						else if (this.playerCtrl_Alucard != null)
						{
							float f12 = Mathf.Round((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK);
							int num14 = Mathf.RoundToInt(f12);
							if (num14 < 1)
							{
								num14 = 1;
							}
							this.playerStatus.damage += num14;
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

		// Token: 0x06002B18 RID: 11032 RVA: 0x0047791C File Offset: 0x00475B1C
		private void ExpPlus(int lvl)
		{
			if (this.playerCtrl != null && this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expMainWeapon01 += 1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expMainWeapon01 += 2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expMainWeapon01 += 3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expMainWeapon01 += 4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expMainWeapon01 += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expMainWeapon01 += 6f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x06002B19 RID: 11033 RVA: 0x00477A60 File Offset: 0x00475C60
		private void ExpPlus2(int lvl)
		{
			if (this.playerCtrl != null && this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expMainWeapon02 += 1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expMainWeapon02 += 2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expMainWeapon02 += 3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expMainWeapon02 += 4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expMainWeapon02 += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expMainWeapon02 += 6f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x06002B1A RID: 11034 RVA: 0x00477BA1 File Offset: 0x00475DA1
		private void Update()
		{
			if (!this.col2d.enabled && this.hitedATK)
			{
				this.enemyBody = null;
				this.currentEnemyBody = null;
				this.bB = null;
				this.currentBB = null;
				this.hitedATK = false;
			}
		}

		// Token: 0x0400518E RID: 20878
		public bool hitedATK;

		// Token: 0x0400518F RID: 20879
		private PlayerStatus playerStatus;

		// Token: 0x04005190 RID: 20880
		private BoxCollider2D col2d;

		// Token: 0x04005191 RID: 20881
		public PhotonView myPV;

		// Token: 0x04005192 RID: 20882
		private EnemyBody enemyBody;

		// Token: 0x04005193 RID: 20883
		private EnemyBody currentEnemyBody;

		// Token: 0x04005194 RID: 20884
		private Boss01BodyDetect bB;

		// Token: 0x04005195 RID: 20885
		private Boss01BodyDetect currentBB;

		// Token: 0x04005196 RID: 20886
		private PlayerController playerCtrl;

		// Token: 0x04005197 RID: 20887
		public PlayerController_Shanoa playerCtrl_Shanoa;

		// Token: 0x04005198 RID: 20888
		public PlayerController_Add1 playerCtrl_Add1;

		// Token: 0x04005199 RID: 20889
		public PlayerController_Alucard playerCtrl_Alucard;

		// Token: 0x0400519A RID: 20890
		public bool subATK;
	}
}
