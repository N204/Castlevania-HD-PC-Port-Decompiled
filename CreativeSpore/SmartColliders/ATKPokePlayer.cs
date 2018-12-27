using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000474 RID: 1140
	public class ATKPokePlayer : MonoBehaviour
	{
		// Token: 0x06002B2F RID: 11055 RVA: 0x0047FBEC File Offset: 0x0047DDEC
		private void Awake()
		{
			if (base.transform.parent.GetComponent<PlayerController>() != null)
			{
				this.playerCtrl = base.transform.parent.GetComponent<PlayerController>();
				this.myPV = base.transform.parent.GetComponent<PhotonView>();
			}
			if (base.transform.parent.parent.parent.parent.GetComponent<PlayerController_Shanoa>() != null)
			{
				this.playerCtrl_Shanoa = base.transform.parent.parent.parent.parent.GetComponent<PlayerController_Shanoa>();
				this.myPV = base.transform.parent.parent.parent.parent.GetComponent<PhotonView>();
			}
			this.col2d = base.GetComponent<BoxCollider2D>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06002B30 RID: 11056 RVA: 0x0047FCD8 File Offset: 0x0047DED8
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
						this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 3);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.enemyBody.RPCActionDamagePoke(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y, 3);
						}
						else if (this.subATK)
						{
							this.enemyBody.RPCActionDamagePoke(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y, 3);
						}
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
					int num4 = UnityEngine.Random.Range(0, 9);
					if (num4 == 5)
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
						this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 3);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.enemyBody.RPCActionDamagePoke(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2, 3);
						}
						else if (this.subATK)
						{
							this.enemyBody.RPCActionDamagePoke(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2, 3);
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num5 = Mathf.RoundToInt(f3);
							if (num5 < 1)
							{
								num5 = 1;
							}
							this.playerStatus.damage += num5;
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							float f4 = 0f;
							if (!this.subATK)
							{
								f4 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							else if (this.subATK)
							{
								f4 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							int num6 = Mathf.RoundToInt(f4);
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
						this.bB.ActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 3);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.bB.ActionDamagePoke(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3, 3);
						}
						else if (this.subATK)
						{
							this.bB.ActionDamagePoke(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3, 3);
						}
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
						if (!this.enemyBody.ownATKHitted)
						{
							this.enemyBody.ownATKHitted = true;
						}
					}
					this.hitedATK = true;
				}
			}
		}

		// Token: 0x06002B31 RID: 11057 RVA: 0x00480604 File Offset: 0x0047E804
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

		// Token: 0x06002B32 RID: 11058 RVA: 0x00480745 File Offset: 0x0047E945
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

		// Token: 0x040051D6 RID: 20950
		public bool hitedATK;

		// Token: 0x040051D7 RID: 20951
		private PlayerStatus playerStatus;

		// Token: 0x040051D8 RID: 20952
		private BoxCollider2D col2d;

		// Token: 0x040051D9 RID: 20953
		private PhotonView myPV;

		// Token: 0x040051DA RID: 20954
		private EnemyBody enemyBody;

		// Token: 0x040051DB RID: 20955
		private EnemyBody currentEnemyBody;

		// Token: 0x040051DC RID: 20956
		private Boss01BodyDetect bB;

		// Token: 0x040051DD RID: 20957
		private Boss01BodyDetect currentBB;

		// Token: 0x040051DE RID: 20958
		private PlayerController playerCtrl;

		// Token: 0x040051DF RID: 20959
		private PlayerController_Shanoa playerCtrl_Shanoa;

		// Token: 0x040051E0 RID: 20960
		public bool subATK;
	}
}
