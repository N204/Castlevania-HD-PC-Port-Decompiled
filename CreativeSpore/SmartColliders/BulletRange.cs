using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000344 RID: 836
	public class BulletRange : MagicMain
	{
		// Token: 0x06001C64 RID: 7268 RVA: 0x001E6FE5 File Offset: 0x001E51E5
		protected override void Awake()
		{
			base.Awake();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.eSE = base.GetComponent<EnemySoundEffect>();
		}

		// Token: 0x06001C65 RID: 7269 RVA: 0x001E7010 File Offset: 0x001E5210
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!this.enemySW)
			{
				if (other.tag == "PlayerBodyEvent" && !this.destroyCheck && !this.soundPlay)
				{
					this.eSE.SoundEffectPlay(0);
					this.soundPlay = true;
				}
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
						if (this.mineSW)
						{
							float f = Mathf.Round(this.iNT * this.sWDamage * this.berserk);
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
						if (this.albusBullet)
						{
							this.ExpPlus(this.enemyBody.enemyLevel);
						}
						Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x = vector.x;
						float y = vector.y;
						switch (this.lvl)
						{
						case 1:
							this.enemyBody.RPCActionDamageCut(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y, 1);
							break;
						case 2:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.05f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
							break;
						case 3:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.1f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
							break;
						case 4:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.15f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
							break;
						case 5:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
							break;
						case 6:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.25f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
							break;
						case 7:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.3f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
							break;
						case 8:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.35f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
							break;
						case 9:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
							break;
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
						if (this.mineSW)
						{
							float f2 = Mathf.Round(this.iNT * this.sWDamage * this.berserk);
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
						if (this.albusBullet)
						{
							this.ExpPlus(this.enemyBody.enemyLevel);
						}
						Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x2 = vector2.x;
						float y2 = vector2.y;
						switch (this.lvl)
						{
						case 1:
							this.enemyBody.RPCActionDamageCut(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
							break;
						case 2:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.05f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
							break;
						case 3:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.1f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
							break;
						case 4:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.15f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
							break;
						case 5:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
							break;
						case 6:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.25f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
							break;
						case 7:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.3f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
							break;
						case 8:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.35f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
							break;
						case 9:
							this.enemyBody.RPCActionDamageCut(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
							break;
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
						if (this.mineSW)
						{
							float f3 = Mathf.Round(this.iNT * this.sWDamage * this.berserk);
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
						if (this.albusBullet)
						{
							this.ExpPlus(this.bB.enemyLevel);
						}
						Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x3 = vector3.x;
						float y3 = vector3.y;
						switch (this.lvl)
						{
						case 1:
							this.bB.ActionDamageCut(this.iNT * this.sWDamage * this.berserk, this.dEX, x3, y3, 1);
							break;
						case 2:
							this.bB.ActionDamageCut(this.iNT * 1.05f * this.sWDamage * this.berserk, this.dEX, x3, y3, 1);
							break;
						case 3:
							this.bB.ActionDamageCut(this.iNT * 1.1f * this.sWDamage * this.berserk, this.dEX, x3, y3, 1);
							break;
						case 4:
							this.bB.ActionDamageCut(this.iNT * 1.15f * this.sWDamage * this.berserk, this.dEX, x3, y3, 1);
							break;
						case 5:
							this.bB.ActionDamageCut(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x3, y3, 1);
							break;
						case 6:
							this.bB.ActionDamageCut(this.iNT * 1.25f * this.sWDamage * this.berserk, this.dEX, x3, y3, 1);
							break;
						case 7:
							this.bB.ActionDamageCut(this.iNT * 1.3f * this.sWDamage * this.berserk, this.dEX, x3, y3, 1);
							break;
						case 8:
							this.bB.ActionDamageCut(this.iNT * 1.35f * this.sWDamage * this.berserk, this.dEX, x3, y3, 1);
							break;
						case 9:
							this.bB.ActionDamageCut(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x3, y3, 1);
							break;
						}
						this.hitedATK = true;
					}
				}
			}
		}

		// Token: 0x06001C66 RID: 7270 RVA: 0x001E7A6C File Offset: 0x001E5C6C
		private void Update()
		{
			if (!this.destroyCheck)
			{
				this.gensuiTimer += Time.deltaTime;
			}
			if (this.gensuiTimer >= 0.15f && !this.trailOn)
			{
				this.trailOn = true;
			}
			if (this.albusBullet)
			{
				if (this.gensuiTimer >= 0.1f && this.gensuiTimer < 0.2f)
				{
					if (this.iNT != this.iNT2)
					{
						this.iNT = this.iNT2;
					}
				}
				else if (this.gensuiTimer >= 0.2f && this.gensuiTimer < 0.3f)
				{
					if (this.iNT != this.iNT3)
					{
						this.iNT = this.iNT3;
					}
				}
				else if (this.gensuiTimer >= 0.3f && this.iNT != this.iNT4)
				{
					this.iNT = this.iNT4;
				}
			}
			if (this.hitedATK && !this.destroyCheck)
			{
				if (this.lvl1_Material.gameObject.activeSelf)
				{
					this.lvl1_Material.enabled = false;
				}
				if (this.lvl2_Material.gameObject.activeSelf)
				{
					this.lvl2_Material.enabled = false;
				}
				if (this.lvl3_Material.gameObject.activeSelf)
				{
					this.lvl3_Material.enabled = false;
				}
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
				base.Invoke("GameObjectFalse", 0.8f);
				this.destroyCheck = true;
			}
			if (!this.hitedATK)
			{
				if (!this.grounded && !this.destroyCheck)
				{
					if (!this.enemySW)
					{
						if (base.transform.localScale.x > 0f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(15f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
						else if (base.transform.localScale.x < 0f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(-15f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
					}
					else if (this.enemySW)
					{
						if (base.transform.localScale.x > 0f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(9f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
						else if (base.transform.localScale.x < 0f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(-9f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
					}
				}
				if (!this.destroyCheck)
				{
					if (this.grounded)
					{
						if (this.lvl1_Material.gameObject.activeSelf)
						{
							this.lvl1_Material.enabled = false;
						}
						if (this.lvl2_Material.gameObject.activeSelf)
						{
							this.lvl2_Material.enabled = false;
						}
						if (this.lvl3_Material.gameObject.activeSelf)
						{
							this.lvl3_Material.enabled = false;
						}
						this.instantiateManager.BulletHitEffect(base.transform.position.x, base.transform.position.y);
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
						base.Invoke("GameObjectFalse", 0.8f);
						this.destroyCheck = true;
					}
					else if (!this.grounded)
					{
						this.timer += Time.deltaTime;
					}
					if (this.timer > 10f)
					{
						if (this.lvl1_Material.gameObject.activeSelf)
						{
							this.lvl1_Material.enabled = false;
						}
						if (this.lvl2_Material.gameObject.activeSelf)
						{
							this.lvl2_Material.enabled = false;
						}
						if (this.lvl3_Material.gameObject.activeSelf)
						{
							this.lvl3_Material.enabled = false;
						}
						base.Invoke("GameObjectFalse", 0.8f);
						this.destroyCheck = true;
					}
				}
			}
		}

		// Token: 0x06001C67 RID: 7271 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x06001C68 RID: 7272 RVA: 0x001E7F08 File Offset: 0x001E6108
		private void ExpPlus(int lvl)
		{
			if (this.mineSW)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expAlbusGun += 1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expAlbusGun += 2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expAlbusGun += 3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expAlbusGun += 4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expAlbusGun += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expAlbusGun += 6f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x06001C69 RID: 7273 RVA: 0x001E8034 File Offset: 0x001E6234
		public void Action()
		{
			this.lvl1_Material.Clear();
			this.lvl2_Material.Clear();
			this.lvl3_Material.Clear();
			this.grounded = false;
			this.trailOn = false;
			this.timer = 0f;
			this.gensuiTimer = 0f;
			this.destroyCheck = false;
			this.hitedATK = false;
			this.soundPlay = false;
			this.enemyBody = null;
			this.currentEnemyBody = null;
			this.bB = null;
			this.currentBB = null;
			float f = this.iNT / 1.5f;
			float f2 = this.iNT / 2f;
			float f3 = this.iNT / 3f;
			this.iNT2 = Mathf.Round(f);
			if (this.iNT2 < 1f)
			{
				this.iNT2 = 1f;
			}
			this.iNT3 = Mathf.Round(f2);
			if (this.iNT3 < 1f)
			{
				this.iNT3 = 1f;
			}
			this.iNT4 = Mathf.Round(f3);
			if (this.iNT4 < 1f)
			{
				this.iNT4 = 1f;
			}
			if (!this.enemySW)
			{
				if (this.albusBullet)
				{
					if (this.lvl < 5)
					{
						this.lvl1_Material.gameObject.SetActive(true);
						this.lvl2_Material.gameObject.SetActive(false);
						this.lvl3_Material.gameObject.SetActive(false);
						if (!this.lvl1_Material.enabled)
						{
							this.lvl1_Material.enabled = true;
						}
					}
					else if (this.lvl >= 5 && this.lvl < 9)
					{
						this.lvl1_Material.gameObject.SetActive(false);
						this.lvl2_Material.gameObject.SetActive(true);
						this.lvl3_Material.gameObject.SetActive(false);
						if (!this.lvl2_Material.enabled)
						{
							this.lvl2_Material.enabled = true;
						}
					}
					else if (this.lvl >= 9)
					{
						this.lvl1_Material.gameObject.SetActive(false);
						this.lvl2_Material.gameObject.SetActive(false);
						this.lvl3_Material.gameObject.SetActive(true);
						if (!this.lvl3_Material.enabled)
						{
							this.lvl3_Material.enabled = true;
						}
					}
				}
				else if (!this.albusBullet)
				{
					this.lvl1_Material.gameObject.SetActive(true);
					this.lvl2_Material.gameObject.SetActive(false);
					this.lvl3_Material.gameObject.SetActive(false);
					if (!this.lvl1_Material.enabled)
					{
						this.lvl1_Material.enabled = true;
					}
				}
			}
		}

		// Token: 0x06001C6A RID: 7274 RVA: 0x001E82F1 File Offset: 0x001E64F1
		public void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04002E97 RID: 11927
		public bool hitedATK;

		// Token: 0x04002E98 RID: 11928
		private PlayerStatus playerStatus;

		// Token: 0x04002E99 RID: 11929
		private EnemyBody enemyBody;

		// Token: 0x04002E9A RID: 11930
		private EnemyBody currentEnemyBody;

		// Token: 0x04002E9B RID: 11931
		private Boss01BodyDetect bB;

		// Token: 0x04002E9C RID: 11932
		private Boss01BodyDetect currentBB;

		// Token: 0x04002E9D RID: 11933
		public InstantiateManager instantiateManager;

		// Token: 0x04002E9E RID: 11934
		private EnemySoundEffect eSE;

		// Token: 0x04002E9F RID: 11935
		public float timer;

		// Token: 0x04002EA0 RID: 11936
		public float gensuiTimer;

		// Token: 0x04002EA1 RID: 11937
		public int lvl;

		// Token: 0x04002EA2 RID: 11938
		public float iNT;

		// Token: 0x04002EA3 RID: 11939
		public float iNT2;

		// Token: 0x04002EA4 RID: 11940
		public float iNT3;

		// Token: 0x04002EA5 RID: 11941
		public float iNT4;

		// Token: 0x04002EA6 RID: 11942
		public float dEX;

		// Token: 0x04002EA7 RID: 11943
		public float sWDamage;

		// Token: 0x04002EA8 RID: 11944
		public float berserk;

		// Token: 0x04002EA9 RID: 11945
		public bool mineSW;

		// Token: 0x04002EAA RID: 11946
		public bool destroyCheck;

		// Token: 0x04002EAB RID: 11947
		public bool enemySW;

		// Token: 0x04002EAC RID: 11948
		public bool soundPlay;

		// Token: 0x04002EAD RID: 11949
		public bool albusBullet;

		// Token: 0x04002EAE RID: 11950
		public bool trailOn;

		// Token: 0x04002EAF RID: 11951
		public TrailRenderer lvl1_Material;

		// Token: 0x04002EB0 RID: 11952
		public TrailRenderer lvl2_Material;

		// Token: 0x04002EB1 RID: 11953
		public TrailRenderer lvl3_Material;
	}
}
