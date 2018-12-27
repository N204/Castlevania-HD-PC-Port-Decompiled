using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000471 RID: 1137
	public class ATKHitPlayer : MonoBehaviour
	{
		// Token: 0x06002B20 RID: 11040 RVA: 0x00478591 File Offset: 0x00476791
		private void Awake()
		{
			this.col2d = base.GetComponent<BoxCollider2D>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06002B21 RID: 11041 RVA: 0x004785B4 File Offset: 0x004767B4
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "KirukurusuCol" && this.playerCtrl_Julius != null && this.playerCtrl_Julius.whipStickyAttack)
			{
				this.playerCtrl_Julius.WhipSticky(other.GetComponent<Rigidbody2D>());
			}
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
						this.enemyBody.RPCActionDamageVampireKiller(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.enemyBody.RPCActionDamageHit(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y);
						}
						else if (this.subATK)
						{
							this.enemyBody.RPCActionDamageHit(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y);
						}
					}
					else if (this.playerCtrl_Julius != null)
					{
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageVampireKiller(this.playerCtrl_Julius.aTK * this.playerCtrl_Julius.berserkerMeiruATK, this.playerCtrl_Julius.dEX, x, y);
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
						else if (this.playerCtrl_Julius != null)
						{
							float f3 = Mathf.Round(this.playerCtrl_Julius.aTK * this.playerCtrl_Julius.berserkerMeiruATK);
							int num4 = Mathf.RoundToInt(f3);
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
			else if (other.tag == "EnemyBodyAttackSp")
			{
				if (this.playerCtrl_Shanoa != null && other.transform.parent.parent.name == "Enemy_Kani")
				{
					int num5 = UnityEngine.Random.Range(0, 9);
					if (num5 == 5)
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
						this.enemyBody.RPCActionDamageVampireKiller(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.enemyBody.RPCActionDamageHit(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2);
						}
						else if (this.subATK)
						{
							this.enemyBody.RPCActionDamageHit(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2);
						}
					}
					else if (this.playerCtrl_Julius != null)
					{
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageVampireKiller(this.playerCtrl_Julius.aTK * this.playerCtrl_Julius.berserkerMeiruATK, this.playerCtrl_Julius.dEX, x2, y2);
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f4 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num6 = Mathf.RoundToInt(f4);
							if (num6 < 1)
							{
								num6 = 1;
							}
							this.playerStatus.damage += num6;
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							float f5 = 0f;
							if (!this.subATK)
							{
								f5 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							else if (this.subATK)
							{
								f5 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							int num7 = Mathf.RoundToInt(f5);
							if (num7 < 1)
							{
								num7 = 1;
							}
							this.playerStatus.damage += num7;
						}
						else if (this.playerCtrl_Julius != null)
						{
							float f6 = Mathf.Round(this.playerCtrl_Julius.aTK * this.playerCtrl_Julius.berserkerMeiruATK);
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
						this.bB.ActionDamageVampireKiller(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.bB.ActionDamageHit(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3);
						}
						else if (this.subATK)
						{
							this.bB.ActionDamageHit(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3);
						}
					}
					else if (this.playerCtrl_Julius != null)
					{
						this.ExpPlus(this.bB.enemyLevel);
						this.bB.ActionDamageVampireKiller(this.playerCtrl_Julius.aTK * this.playerCtrl_Julius.berserkerMeiruATK, this.playerCtrl_Julius.dEX, x3, y3);
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f7 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num9 = Mathf.RoundToInt(f7);
							if (num9 < 1)
							{
								num9 = 1;
							}
							this.playerStatus.damage += num9;
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							float f8 = 0f;
							if (!this.subATK)
							{
								f8 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							else if (this.subATK)
							{
								f8 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							int num10 = Mathf.RoundToInt(f8);
							if (num10 < 1)
							{
								num10 = 1;
							}
							this.playerStatus.damage += num10;
						}
						else if (this.playerCtrl_Julius != null)
						{
							float f9 = Mathf.Round(this.playerCtrl_Julius.aTK * this.playerCtrl_Julius.berserkerMeiruATK);
							int num11 = Mathf.RoundToInt(f9);
							if (num11 < 1)
							{
								num11 = 1;
							}
							this.playerStatus.damage += num11;
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

		// Token: 0x06002B22 RID: 11042 RVA: 0x00479138 File Offset: 0x00477338
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

		// Token: 0x06002B23 RID: 11043 RVA: 0x00479279 File Offset: 0x00477479
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

		// Token: 0x040051A6 RID: 20902
		public bool hitedATK;

		// Token: 0x040051A7 RID: 20903
		private PlayerStatus playerStatus;

		// Token: 0x040051A8 RID: 20904
		private BoxCollider2D col2d;

		// Token: 0x040051A9 RID: 20905
		public PhotonView myPV;

		// Token: 0x040051AA RID: 20906
		private EnemyBody enemyBody;

		// Token: 0x040051AB RID: 20907
		private EnemyBody currentEnemyBody;

		// Token: 0x040051AC RID: 20908
		private Boss01BodyDetect bB;

		// Token: 0x040051AD RID: 20909
		private Boss01BodyDetect currentBB;

		// Token: 0x040051AE RID: 20910
		public PlayerController playerCtrl;

		// Token: 0x040051AF RID: 20911
		public PlayerController_Shanoa playerCtrl_Shanoa;

		// Token: 0x040051B0 RID: 20912
		public PlayerController_Julius playerCtrl_Julius;

		// Token: 0x040051B1 RID: 20913
		public bool subATK;
	}
}
