using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200046D RID: 1133
	public class ATKCharotte : MonoBehaviour
	{
		// Token: 0x06002B0D RID: 11021 RVA: 0x00475683 File Offset: 0x00473883
		private void Awake()
		{
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06002B0E RID: 11022 RVA: 0x0047569C File Offset: 0x0047389C
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
						switch (this.weaponSwitch)
						{
						case 1:
							this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 2:
							this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 1);
							break;
						case 3:
							this.enemyBody.RPCActionDamageIce(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 4:
							this.enemyBody.RPCActionDamageFire(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 5:
							this.enemyBody.RPCActionDamageDark(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 6:
							this.enemyBody.RPCActionDamageLigh(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 7:
							this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 8:
							this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
							break;
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num = Mathf.RoundToInt(f);
							if (num < 1)
							{
								num = 1;
							}
							this.playerStatus.damage += num;
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
							this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 2:
							this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 1);
							break;
						case 3:
							this.enemyBody.RPCActionDamageIce(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 4:
							this.enemyBody.RPCActionDamageFire(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 5:
							this.enemyBody.RPCActionDamageDark(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 6:
							this.enemyBody.RPCActionDamageLigh(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 7:
							this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 8:
							this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
							break;
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num2 = Mathf.RoundToInt(f2);
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
					this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
					Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x3 = vector3.x;
					float y3 = vector3.y;
					if (this.playerCtrl != null)
					{
						switch (this.weaponSwitch)
						{
						case 1:
							this.bB.ActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 2:
							this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 1);
							break;
						case 3:
							this.bB.ActionDamageIce(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 4:
							this.bB.ActionDamageFire(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 5:
							this.bB.ActionDamageDark(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 6:
							this.bB.ActionDamageLigh(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 7:
							this.bB.ActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 8:
							this.bB.ActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 2);
							break;
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num3 = Mathf.RoundToInt(f3);
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
		}

		// Token: 0x06002B0F RID: 11023 RVA: 0x00476059 File Offset: 0x00474259
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

		// Token: 0x04005179 RID: 20857
		public bool hitedATK;

		// Token: 0x0400517A RID: 20858
		private PlayerStatus playerStatus;

		// Token: 0x0400517B RID: 20859
		public BoxCollider2D col2d;

		// Token: 0x0400517C RID: 20860
		public PhotonView myPV;

		// Token: 0x0400517D RID: 20861
		private EnemyBody enemyBody;

		// Token: 0x0400517E RID: 20862
		private EnemyBody currentEnemyBody;

		// Token: 0x0400517F RID: 20863
		private Boss01BodyDetect bB;

		// Token: 0x04005180 RID: 20864
		private Boss01BodyDetect currentBB;

		// Token: 0x04005181 RID: 20865
		public PlayerController_Charotte playerCtrl;

		// Token: 0x04005182 RID: 20866
		public int weaponSwitch;
	}
}
