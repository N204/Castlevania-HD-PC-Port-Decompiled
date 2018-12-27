using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000479 RID: 1145
	public class ATKSpinningKick : MonoBehaviour
	{
		// Token: 0x06002B4B RID: 11083 RVA: 0x0048CD28 File Offset: 0x0048AF28
		private void Awake()
		{
			this.playerCtrl = base.transform.parent.GetComponent<PlayerController>();
			this.col2d = base.GetComponent<CircleCollider2D>();
			this.myPV = base.transform.parent.GetComponent<PhotonView>();
		}

		// Token: 0x06002B4C RID: 11084 RVA: 0x0048CD64 File Offset: 0x0048AF64
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
					this.ExpPlus(this.enemyBody.enemyLevel);
					Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x = vector.x;
					float y = vector.y;
					this.enemyBody.RPCActionDamageSpinningKick(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
					if (this.myPV.isMine)
					{
						float f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK * 1.7f);
						int num = Mathf.RoundToInt(f);
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
					this.ExpPlus(this.enemyBody.enemyLevel);
					Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x2 = vector2.x;
					float y2 = vector2.y;
					this.enemyBody.RPCActionDamageSpinningKick(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
					if (this.myPV.isMine)
					{
						float f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK * 1.7f);
						int num2 = Mathf.RoundToInt(f2);
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
					this.ExpPlus(this.bB.enemyLevel);
					Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x3 = vector3.x;
					float y3 = vector3.y;
					this.bB.ActionDamageSpinningKick(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
					if (this.myPV.isMine)
					{
						float f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK * 1.7f);
						int num3 = Mathf.RoundToInt(f3);
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

		// Token: 0x06002B4D RID: 11085 RVA: 0x0048D234 File Offset: 0x0048B434
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

		// Token: 0x06002B4E RID: 11086 RVA: 0x0048D2A8 File Offset: 0x0048B4A8
		private void ExpPlus(int lvl)
		{
			if (this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expMainWeapon01 += 0.5f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expMainWeapon01 += 1f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expMainWeapon01 += 1.5f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expMainWeapon01 += 2f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expMainWeapon01 += 2.5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expMainWeapon01 += 3f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x0400521C RID: 21020
		public bool hitedATK;

		// Token: 0x0400521D RID: 21021
		private PlayerStatus playerStatus;

		// Token: 0x0400521E RID: 21022
		private CircleCollider2D col2d;

		// Token: 0x0400521F RID: 21023
		private PhotonView myPV;

		// Token: 0x04005220 RID: 21024
		private EnemyBody enemyBody;

		// Token: 0x04005221 RID: 21025
		private EnemyBody currentEnemyBody;

		// Token: 0x04005222 RID: 21026
		private Boss01BodyDetect bB;

		// Token: 0x04005223 RID: 21027
		private Boss01BodyDetect currentBB;

		// Token: 0x04005224 RID: 21028
		private PlayerController playerCtrl;
	}
}
