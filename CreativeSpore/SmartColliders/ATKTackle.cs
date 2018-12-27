using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200047A RID: 1146
	public class ATKTackle : MonoBehaviour
	{
		// Token: 0x06002B50 RID: 11088 RVA: 0x0048D3D8 File Offset: 0x0048B5D8
		private void Awake()
		{
			this.col2d = base.GetComponent<CircleCollider2D>();
			this.myPV = base.transform.parent.GetComponent<PhotonView>();
			if (base.transform.parent.GetComponent<PlayerController>() != null)
			{
				this.playerCtrl = base.transform.parent.GetComponent<PlayerController>();
			}
		}

		// Token: 0x06002B51 RID: 11089 RVA: 0x0048D438 File Offset: 0x0048B638
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
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageTackle(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageTackle(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.berserkerMeiruATK, this.playerCtrl_Jonathan.dEX, x, y);
					}
					else if (this.playerCtrl_Add1 != null)
					{
						this.ExpPlus2(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageTackle(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK, this.playerCtrl_Add1.dEX, x, y);
					}
					else if (this.playerCtrl_Alucard != null)
					{
						this.enemyBody.RPCActionDamageTackle((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK, this.playerCtrl_Alucard.dEX, x, y);
					}
					if (this.myPV.isMine)
					{
						int num = 0;
						if (this.playerCtrl != null)
						{
							float f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.4f);
							num = Mathf.RoundToInt(f);
						}
						else if (this.playerCtrl_Jonathan != null)
						{
							float f = Mathf.Round(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.berserkerMeiruATK * 2.4f);
							num = Mathf.RoundToInt(f);
						}
						else if (this.playerCtrl_Add1 != null)
						{
							float f = Mathf.Round(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK * 2.4f);
							num = Mathf.RoundToInt(f);
						}
						else if (this.playerCtrl_Alucard != null)
						{
							float f = Mathf.Round((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK * 2.4f);
							num = Mathf.RoundToInt(f);
						}
						if (num < 1)
						{
							num = 1;
						}
						this.playerStatus.damage += num;
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
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageTackle(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageTackle(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.berserkerMeiruATK, this.playerCtrl_Jonathan.dEX, x2, y2);
					}
					else if (this.playerCtrl_Add1 != null)
					{
						this.ExpPlus2(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageTackle(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK, this.playerCtrl_Add1.dEX, x2, y2);
					}
					else if (this.playerCtrl_Alucard != null)
					{
						this.enemyBody.RPCActionDamageTackle((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK, this.playerCtrl_Alucard.dEX, x2, y2);
					}
					if (this.myPV.isMine)
					{
						int num2 = 0;
						if (this.playerCtrl != null)
						{
							float f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.4f);
							num2 = Mathf.RoundToInt(f2);
						}
						else if (this.playerCtrl_Jonathan != null)
						{
							float f2 = Mathf.Round(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.berserkerMeiruATK * 2.4f);
							num2 = Mathf.RoundToInt(f2);
						}
						else if (this.playerCtrl_Add1 != null)
						{
							float f2 = Mathf.Round(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK * 2.4f);
							num2 = Mathf.RoundToInt(f2);
						}
						else if (this.playerCtrl_Alucard != null)
						{
							float f2 = Mathf.Round((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK * 2.4f);
							num2 = Mathf.RoundToInt(f2);
						}
						if (num2 < 1)
						{
							num2 = 1;
						}
						this.playerStatus.damage += num2;
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
						this.bB.ActionDamageTackle(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						this.ExpPlus(this.bB.enemyLevel);
						this.bB.ActionDamageTackle(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.berserkerMeiruATK, this.playerCtrl_Jonathan.dEX, x3, y3);
					}
					else if (this.playerCtrl_Add1 != null)
					{
						this.ExpPlus2(this.bB.enemyLevel);
						this.bB.ActionDamageTackle(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK, this.playerCtrl_Add1.dEX, x3, y3);
					}
					else if (this.playerCtrl_Alucard != null)
					{
						this.bB.ActionDamageTackle((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK, this.playerCtrl_Alucard.dEX, x3, y3);
					}
					if (this.myPV.isMine)
					{
						int num3 = 0;
						if (this.playerCtrl != null)
						{
							float f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.4f);
							num3 = Mathf.RoundToInt(f3);
						}
						else if (this.playerCtrl_Jonathan != null)
						{
							float f3 = Mathf.Round(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.berserkerMeiruATK * 2.4f);
							num3 = Mathf.RoundToInt(f3);
						}
						else if (this.playerCtrl_Add1 != null)
						{
							float f3 = Mathf.Round(this.playerCtrl_Add1.aTK * this.playerCtrl_Add1.berserkerMeiruATK * 2.4f);
							num3 = Mathf.RoundToInt(f3);
						}
						else if (this.playerCtrl_Alucard != null)
						{
							float f3 = Mathf.Round((float)(5 * this.playerCtrl_Alucard.lvlSoulOfWolf) * this.playerCtrl_Alucard.berserkerMeiruATK * 2.4f);
							num3 = Mathf.RoundToInt(f3);
						}
						if (num3 < 1)
						{
							num3 = 1;
						}
						this.playerStatus.damage += num3;
						if (!this.enemyBody.ownATKHitted)
						{
							this.enemyBody.ownATKHitted = true;
						}
					}
					this.hitedATK = true;
				}
			}
		}

		// Token: 0x06002B52 RID: 11090 RVA: 0x0048DE88 File Offset: 0x0048C088
		private void Update()
		{
			if (this.playerStatus == null)
			{
				this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			}
			if (!this.col2d.enabled && this.hitedATK)
			{
				this.enemyBody = null;
				this.currentEnemyBody = null;
				this.bB = null;
				this.currentBB = null;
				this.hitedATK = false;
			}
		}

		// Token: 0x06002B53 RID: 11091 RVA: 0x0048DEFC File Offset: 0x0048C0FC
		private void ExpPlus(int lvl)
		{
			if (this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expMainWeapon01 += 1.2f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expMainWeapon01 += 2.4f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expMainWeapon01 += 3.6f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expMainWeapon01 += 3.8f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expMainWeapon01 += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expMainWeapon01 += 6.2f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x06002B54 RID: 11092 RVA: 0x0048E02C File Offset: 0x0048C22C
		private void ExpPlus2(int lvl)
		{
			if (this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expMainWeapon02 += 1.2f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expMainWeapon02 += 2.4f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expMainWeapon02 += 3.6f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expMainWeapon02 += 3.8f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expMainWeapon02 += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expMainWeapon02 += 6.2f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x04005225 RID: 21029
		public bool hitedATK;

		// Token: 0x04005226 RID: 21030
		private PlayerStatus playerStatus;

		// Token: 0x04005227 RID: 21031
		private CircleCollider2D col2d;

		// Token: 0x04005228 RID: 21032
		private PhotonView myPV;

		// Token: 0x04005229 RID: 21033
		private EnemyBody enemyBody;

		// Token: 0x0400522A RID: 21034
		private EnemyBody currentEnemyBody;

		// Token: 0x0400522B RID: 21035
		private Boss01BodyDetect bB;

		// Token: 0x0400522C RID: 21036
		private Boss01BodyDetect currentBB;

		// Token: 0x0400522D RID: 21037
		private PlayerController playerCtrl;

		// Token: 0x0400522E RID: 21038
		public PlayerController_Jonathan playerCtrl_Jonathan;

		// Token: 0x0400522F RID: 21039
		public PlayerController_Add1 playerCtrl_Add1;

		// Token: 0x04005230 RID: 21040
		public PlayerController_Alucard playerCtrl_Alucard;
	}
}
