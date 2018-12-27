using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000341 RID: 833
	public class AcidBubble : MagicMain
	{
		// Token: 0x06001C47 RID: 7239 RVA: 0x001E2B30 File Offset: 0x001E0D30
		protected override void Awake()
		{
			base.Awake();
			this.eSE = base.GetComponent<EnemySoundEffect>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.col2d = base.transform.Find("ATKCol").GetComponent<CircleCollider2D>();
			this.audioS = base.GetComponent<AudioSource>();
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06001C48 RID: 7240 RVA: 0x001E2B98 File Offset: 0x001E0D98
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (this.enemySW)
			{
				if (other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper")
				{
					this.hitedATK = true;
				}
			}
			else if (!this.enemySW)
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
							this.enemyBody.StatusPoisonRandom(base.transform.position.x, base.transform.position.y);
						}
						Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x = vector.x;
						float y = vector.y;
						switch (this.lvl)
						{
						case 1:
							this.enemyBody.RPCActionDamagePoison(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 2:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.05f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 3:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.1f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 4:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.15f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 5:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 6:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.25f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 7:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.3f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 8:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.35f * this.sWDamage * this.berserk, this.dEX, x, y);
							break;
						case 9:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
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
							this.enemyBody.StatusPoisonRandom(base.transform.position.x, base.transform.position.y);
						}
						Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x2 = vector2.x;
						float y2 = vector2.y;
						switch (this.lvl)
						{
						case 1:
							this.enemyBody.RPCActionDamagePoison(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 2:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.05f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 3:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.1f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 4:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.15f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 5:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 6:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.25f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 7:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.3f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 8:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.35f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							break;
						case 9:
							this.enemyBody.RPCActionDamagePoison(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
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
							this.enemyBody.StatusPoisonRandom(base.transform.position.x, base.transform.position.y);
						}
						Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x3 = vector3.x;
						float y3 = vector3.y;
						switch (this.lvl)
						{
						case 1:
							this.bB.ActionDamagePoison(this.iNT * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 2:
							this.bB.ActionDamagePoison(this.iNT * 1.05f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 3:
							this.bB.ActionDamagePoison(this.iNT * 1.1f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 4:
							this.bB.ActionDamagePoison(this.iNT * 1.15f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 5:
							this.bB.ActionDamagePoison(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 6:
							this.bB.ActionDamagePoison(this.iNT * 1.25f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 7:
							this.bB.ActionDamagePoison(this.iNT * 1.3f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 8:
							this.bB.ActionDamagePoison(this.iNT * 1.35f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						case 9:
							this.bB.ActionDamagePoison(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x3, y3);
							break;
						}
						this.hitedATK = true;
					}
				}
			}
		}

		// Token: 0x06001C49 RID: 7241 RVA: 0x001E37A4 File Offset: 0x001E19A4
		private void Update()
		{
			if (this.hitedATK && !this.destroyCheck)
			{
				this.animator.SetTrigger("Break");
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
				base.Invoke("GameObjectFalse", 2.5f);
				this.destroyCheck = true;
			}
			if (!this.hitedATK && !this.destroyCheck)
			{
				if (base.transform.localScale.x > 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(1.5f, base.GetComponent<Rigidbody2D>().velocity.y);
				}
				else if (base.transform.localScale.x < 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, base.GetComponent<Rigidbody2D>().velocity.y);
				}
				this.moveTimer += Time.deltaTime;
				if (this.moveTimer < 0.5f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, 0.5f);
				}
				else if (this.moveTimer >= 0.5f && this.moveTimer < 1.5f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, -0.5f);
				}
				else if (this.moveTimer >= 1.5f)
				{
					this.moveTimer = 0f;
				}
				if (this.grounded)
				{
					this.animator.SetTrigger("Break");
					base.Invoke("GameObjectFalse", 2.5f);
					this.destroyCheck = true;
				}
				else if (!this.grounded)
				{
					this.timer += Time.deltaTime;
				}
				if (this.timer > 8f)
				{
					this.animator.SetTrigger("Break");
					base.Invoke("GameObjectFalse", 2.5f);
					this.destroyCheck = true;
				}
			}
		}

		// Token: 0x06001C4A RID: 7242 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x06001C4B RID: 7243 RVA: 0x001E39F4 File Offset: 0x001E1BF4
		public void Action()
		{
			this.grounded = false;
			this.enemyBody = null;
			this.currentEnemyBody = null;
			this.bB = null;
			this.currentBB = null;
			this.eSE.SoundEffectPlay(0);
			this.animator.ResetTrigger("Break");
			this.animator.Play("AcidBubble_Idle", 0, 0f);
			this.timer = 0f;
			this.moveTimer = 0f;
			this.destroyCheck = false;
			this.hitedATK = false;
		}

		// Token: 0x06001C4C RID: 7244 RVA: 0x001E3A7A File Offset: 0x001E1C7A
		public void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04002E5D RID: 11869
		private PlayerStatus playerStatus;

		// Token: 0x04002E5E RID: 11870
		private EnemyBody enemyBody;

		// Token: 0x04002E5F RID: 11871
		private EnemyBody currentEnemyBody;

		// Token: 0x04002E60 RID: 11872
		private Boss01BodyDetect bB;

		// Token: 0x04002E61 RID: 11873
		private Boss01BodyDetect currentBB;

		// Token: 0x04002E62 RID: 11874
		public InstantiateManager instantiateManager;

		// Token: 0x04002E63 RID: 11875
		private CircleCollider2D col2d;

		// Token: 0x04002E64 RID: 11876
		private AudioSource audioS;

		// Token: 0x04002E65 RID: 11877
		private Animator animator;

		// Token: 0x04002E66 RID: 11878
		private EnemySoundEffect eSE;

		// Token: 0x04002E67 RID: 11879
		public float timer;

		// Token: 0x04002E68 RID: 11880
		public int lvl;

		// Token: 0x04002E69 RID: 11881
		public float iNT;

		// Token: 0x04002E6A RID: 11882
		public float dEX;

		// Token: 0x04002E6B RID: 11883
		public float sWDamage;

		// Token: 0x04002E6C RID: 11884
		public float berserk;

		// Token: 0x04002E6D RID: 11885
		public bool mineSW;

		// Token: 0x04002E6E RID: 11886
		public bool destroyCheck;

		// Token: 0x04002E6F RID: 11887
		public bool enemySW;

		// Token: 0x04002E70 RID: 11888
		public bool hitedATK;

		// Token: 0x04002E71 RID: 11889
		public float moveTimer;
	}
}
