using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000476 RID: 1142
	public class ATKSlidingKick : MonoBehaviour
	{
		// Token: 0x06002B38 RID: 11064 RVA: 0x00481F4C File Offset: 0x0048014C
		private void Awake()
		{
			this.col2d = base.GetComponent<CircleCollider2D>();
			this.myPV = base.transform.parent.GetComponent<PhotonView>();
			if (base.transform.parent.GetComponent<PlayerController>() != null)
			{
				this.playerCtrl = base.transform.parent.GetComponent<PlayerController>();
			}
		}

		// Token: 0x06002B39 RID: 11065 RVA: 0x00481FAC File Offset: 0x004801AC
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
						this.enemyBody.RPCActionDamageSlidingKick(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageSlidingKick(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK, this.playerCtrl_Jonathan.dEX, x, y);
					}
					this.enemyBody.hitSlidingKickTimer = 0f;
					this.enemyBody.hitSlidingKick = true;
					if (this.myPV.isMine)
					{
						int num = 0;
						if (this.playerCtrl != null)
						{
							float f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK * 2.4f);
							num = Mathf.RoundToInt(f);
						}
						else if (this.playerCtrl_Jonathan != null)
						{
							float f = Mathf.Round(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK * 2.4f);
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
						this.enemyBody.RPCActionDamageSlidingKick(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageSlidingKick(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK, this.playerCtrl_Jonathan.dEX, x2, y2);
					}
					this.enemyBody.hitSlidingKickTimer = 0f;
					this.enemyBody.hitSlidingKick = true;
					if (this.myPV.isMine)
					{
						int num2 = 0;
						if (this.playerCtrl != null)
						{
							float f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK * 2.4f);
							num2 = Mathf.RoundToInt(f2);
						}
						else if (this.playerCtrl_Jonathan != null)
						{
							float f2 = Mathf.Round(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK * 2.4f);
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
						this.bB.ActionDamageSlidingKick(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						this.ExpPlus(this.bB.enemyLevel);
						this.bB.ActionDamageSlidingKick(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK, this.playerCtrl_Jonathan.dEX, x3, y3);
					}
					this.enemyBody.hitSlidingKickTimer = 0f;
					this.enemyBody.hitSlidingKick = true;
					if (this.myPV.isMine)
					{
						int num3 = 0;
						if (this.playerCtrl != null)
						{
							float f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK * 2.4f);
							num3 = Mathf.RoundToInt(f3);
						}
						else if (this.playerCtrl_Jonathan != null)
						{
							float f3 = Mathf.Round(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK * 2.4f);
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

		// Token: 0x06002B3A RID: 11066 RVA: 0x00482768 File Offset: 0x00480968
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

		// Token: 0x06002B3B RID: 11067 RVA: 0x004827DC File Offset: 0x004809DC
		private void ExpPlus(int lvl)
		{
			if (this.myPV.isMine)
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

		// Token: 0x040051ED RID: 20973
		public bool hitedATK;

		// Token: 0x040051EE RID: 20974
		private PlayerStatus playerStatus;

		// Token: 0x040051EF RID: 20975
		private CircleCollider2D col2d;

		// Token: 0x040051F0 RID: 20976
		private PhotonView myPV;

		// Token: 0x040051F1 RID: 20977
		private EnemyBody enemyBody;

		// Token: 0x040051F2 RID: 20978
		private EnemyBody currentEnemyBody;

		// Token: 0x040051F3 RID: 20979
		private Boss01BodyDetect bB;

		// Token: 0x040051F4 RID: 20980
		private Boss01BodyDetect currentBB;

		// Token: 0x040051F5 RID: 20981
		private PlayerController playerCtrl;

		// Token: 0x040051F6 RID: 20982
		public PlayerController_Jonathan playerCtrl_Jonathan;
	}
}
