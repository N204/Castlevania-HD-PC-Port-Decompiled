using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200047B RID: 1147
	public class ATKUpper : MonoBehaviour
	{
		// Token: 0x06002B56 RID: 11094 RVA: 0x0048E15C File Offset: 0x0048C35C
		private void Awake()
		{
			this.col2d = base.GetComponent<CircleCollider2D>();
			this.myPV = base.transform.parent.GetComponent<PhotonView>();
			if (base.transform.parent.GetComponent<PlayerController>() != null)
			{
				this.playerCtrl = base.transform.parent.GetComponent<PlayerController>();
			}
		}

		// Token: 0x06002B57 RID: 11095 RVA: 0x0048E1BC File Offset: 0x0048C3BC
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
					if (this.playerCtrl != null)
					{
						this.enemyBody.RPCActionDamageUpper(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
					}
					if (this.playerCtrl2 != null)
					{
						this.enemyBody.RPCActionDamageUpper(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK, this.playerCtrl2.dEX, x, y);
					}
					if (this.playerCtrl3 != null)
					{
						this.enemyBody.RPCActionDamageUpper(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK, this.playerCtrl3.dEX, x, y);
					}
					if (this.myPV.isMine)
					{
						float f = 0f;
						if (this.playerCtrl != null)
						{
							f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.8f);
						}
						if (this.playerCtrl2 != null)
						{
							f = Mathf.Round(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK * 2.8f);
						}
						if (this.playerCtrl3 != null)
						{
							f = Mathf.Round(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK * 2.8f);
						}
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
					if (this.playerCtrl != null)
					{
						this.enemyBody.RPCActionDamageUpper(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
					}
					if (this.playerCtrl2 != null)
					{
						this.enemyBody.RPCActionDamageUpper(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK, this.playerCtrl2.dEX, x2, y2);
					}
					if (this.playerCtrl3 != null)
					{
						this.enemyBody.RPCActionDamageUpper(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK, this.playerCtrl3.dEX, x2, y2);
					}
					if (this.myPV.isMine)
					{
						float f2 = 0f;
						if (this.playerCtrl != null)
						{
							f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.8f);
						}
						if (this.playerCtrl2 != null)
						{
							f2 = Mathf.Round(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK * 2.8f);
						}
						if (this.playerCtrl3 != null)
						{
							f2 = Mathf.Round(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK * 2.8f);
						}
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
					if (this.playerCtrl != null)
					{
						this.bB.ActionDamageUpper(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
					}
					if (this.playerCtrl2 != null)
					{
						this.bB.ActionDamageUpper(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK, this.playerCtrl2.dEX, x3, y3);
					}
					if (this.playerCtrl3 != null)
					{
						this.bB.ActionDamageUpper(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK, this.playerCtrl3.dEX, x3, y3);
					}
					if (this.myPV.isMine)
					{
						float f3 = 0f;
						if (this.playerCtrl != null)
						{
							f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.8f);
						}
						if (this.playerCtrl2 != null)
						{
							f3 = Mathf.Round(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK * 2.8f);
						}
						if (this.playerCtrl3 != null)
						{
							f3 = Mathf.Round(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK * 2.8f);
						}
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

		// Token: 0x06002B58 RID: 11096 RVA: 0x0048E980 File Offset: 0x0048CB80
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

		// Token: 0x06002B59 RID: 11097 RVA: 0x0048E9F4 File Offset: 0x0048CBF4
		private void ExpPlus(int lvl)
		{
			if (this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expMainWeapon01 += 1.5f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expMainWeapon01 += 3f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expMainWeapon01 += 4.5f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expMainWeapon01 += 6f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expMainWeapon01 += 7.5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expMainWeapon01 += 9f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x04005231 RID: 21041
		public bool hitedATK;

		// Token: 0x04005232 RID: 21042
		private PlayerStatus playerStatus;

		// Token: 0x04005233 RID: 21043
		private CircleCollider2D col2d;

		// Token: 0x04005234 RID: 21044
		private PhotonView myPV;

		// Token: 0x04005235 RID: 21045
		private EnemyBody enemyBody;

		// Token: 0x04005236 RID: 21046
		private EnemyBody currentEnemyBody;

		// Token: 0x04005237 RID: 21047
		private Boss01BodyDetect bB;

		// Token: 0x04005238 RID: 21048
		private Boss01BodyDetect currentBB;

		// Token: 0x04005239 RID: 21049
		private PlayerController playerCtrl;

		// Token: 0x0400523A RID: 21050
		public PlayerController_Jonathan playerCtrl2;

		// Token: 0x0400523B RID: 21051
		public PlayerController_Julius playerCtrl3;
	}
}
