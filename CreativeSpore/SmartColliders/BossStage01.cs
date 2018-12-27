using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020001FE RID: 510
	public class BossStage01 : EnemyMain
	{
		// Token: 0x06000DC2 RID: 3522 RVA: 0x000958EC File Offset: 0x00093AEC
		protected override void Awake()
		{
			base.Awake();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.door1 = GameObject.Find("StageBase/Stage4/Object/StepSwitch/Door1").GetComponent<Door1TimeLag>();
			this.door2 = GameObject.Find("StageBase/Stage4/Object/StepSwitch2/Door1").GetComponent<Door1TimeLag>();
			this.chestPos = GameObject.Find("ChestPos").transform;
			this.pS = base.transform.Find("Boss01_BeamBlueEffect").GetComponent<ParticleSystem>();
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
			this.beamParent.transform.parent = GameObject.Find("Stage_Enemy01").transform;
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x000959A4 File Offset: 0x00093BA4
		private void Start()
		{
			this.startHp = this.enemyBody.hp;
			this.myPV = base.GetComponent<PhotonView>();
			this.veloLeftCol2d = base.transform.Find("VelocityLeft").GetComponent<BoxCollider2D>();
			this.veloRightCol2d = base.transform.Find("VelocityRight").GetComponent<BoxCollider2D>();
			this.headPos = base.transform.Find("Head/Head_face");
			this.rightLegPos = base.transform.Find("Legs/Legs_Back03/RightLegPos");
			this.leftLegPos = base.transform.Find("Legs/Legs_Front03/LeftLegPos");
			this.eSE = base.transform.Find("SoundEffect").GetComponent<EnemySoundEffect>();
			this.targetAnim = GameObject.Find("Canvas_UI/Archive").GetComponent<Animator>();
			this.targetText = GameObject.Find("Canvas_UI/Archive/ArchiveText").GetComponent<Text>();
			this.targetImage = GameObject.Find("Canvas_UI/Archive/UnLockImage").GetComponent<Image>();
			this.menuOnOff = GameObject.Find("Canvas_UI").GetComponent<MenuOnOff>();
			this.bgmWorks = GameObject.Find("Stage/Stage_UI/BGM").GetComponent<BGMWorks>();
			this.playerSpawn = GameObject.Find("StageNetwork").GetComponent<PlayerSpwan>();
			this.meshRen = base.transform.Find("TargetText").GetComponent<MeshRenderer>();
			this.cameraCtrl = GameObject.Find("MainCamera").GetComponent<CameraController>();
			int @int = PlayerPrefs.GetInt("SatsujinSliding");
			if (@int > 0)
			{
				this.alreadyUnlockArchive = true;
			}
			int int2 = PlayerPrefs.GetInt("SkeltonFive");
			if (int2 > 0)
			{
				this.alreadyUnlockArchive2 = true;
			}
			int int3 = PlayerPrefs.GetInt("JigokunoCombination");
			if (int3 > 0)
			{
				this.alreadyUnlockArchive3 = true;
			}
			int int4 = PlayerPrefs.GetInt("Hard1_Clear");
			if (int4 > 0)
			{
				this.alreadyUnlockArchive4 = true;
			}
			this.bossBGM = PlayerPrefs.GetInt("BGMBoss01");
			if (this.bossBGM == 0)
			{
				this.bossBGM = 1;
			}
			this.cameraCtrl.bossTargetText = this.meshRen;
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x00095BA6 File Offset: 0x00093DA6
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.transform.parent != null)
			{
				this.lastDMG = other.transform.parent.gameObject;
			}
		}

		// Token: 0x06000DC5 RID: 3525 RVA: 0x00095BD4 File Offset: 0x00093DD4
		private void Update()
		{
			if (this.canShotBeam)
			{
				this.beamShotTimer += Time.deltaTime;
				if (this.beamShotTimer >= 2f && this.beamShotTimer < 5f)
				{
					if (this.beamState != 1)
					{
						BoxCollider2D boxCollider2D = this.beamLine.gameObject.AddComponent<BoxCollider2D>();
						boxCollider2D.isTrigger = true;
						boxCollider2D.size = new Vector2(100f, 0.5f);
						this.beamState = 1;
					}
				}
				else if (this.beamShotTimer >= 5f && this.beamState != 2)
				{
					this.beamWidth = 2.5f;
					if (this.beamLine.gameObject.GetComponent<BoxCollider2D>() != null)
					{
						UnityEngine.Object.Destroy(this.beamLine.gameObject.GetComponent<BoxCollider2D>());
					}
					this.beamState = 2;
				}
				int num = this.beamState;
				if (num != 0)
				{
					if (num != 1)
					{
						if (num == 2)
						{
							this.beamWidth -= Time.deltaTime * 3f;
							if (this.beamWidth >= 0f)
							{
								this.beamLine.SetWidth(this.beamWidth, this.beamWidth);
							}
							else if (this.beamWidth <= 0f)
							{
								this.beamLine.SetWidth(0f, 0f);
								this.beamLine.enabled = this.falled;
								this.canShotBeam = false;
							}
						}
					}
					else
					{
						this.beamLine.SetWidth(2.5f, 2.5f);
					}
				}
				else
				{
					if (this.beamWidth < 0.3f)
					{
						this.beamWidth += Time.deltaTime;
					}
					this.beamLine.SetWidth(this.beamWidth, this.beamWidth);
				}
			}
			if (base.GetComponent<Rigidbody2D>().velocity.y < -7f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, -7f);
			}
			if (!this.curse && this.enemyBody.canCurse)
			{
				this.myPV.RPC("ReciveCurse", PhotonTargets.Others, new object[0]);
				this.curseTimer = 0f;
				this.curse = true;
			}
			if (this.curse)
			{
				if (!this.animator.GetBool("Curse"))
				{
					this.animator.SetBool("Curse", true);
				}
			}
			else if (!this.curse && this.animator.GetBool("Curse"))
			{
				this.animator.SetBool("Curse", false);
			}
			if (!this.poison && this.enemyBody.canPoison)
			{
				this.myPV.RPC("RecivePoison", PhotonTargets.Others, new object[0]);
				base.StartCoroutine(this.EnumPoisonDamage(3f));
				this.poisonTimer = 0f;
				this.poison = true;
			}
			if (this.poison)
			{
				if (!this.animator.GetBool("Poison"))
				{
					this.animator.SetBool("Poison", true);
				}
			}
			else if (!this.poison && this.animator.GetBool("Poison"))
			{
				this.animator.SetBool("Poison", false);
			}
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x00095F6C File Offset: 0x0009416C
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			this.instanceBlood = false;
			if (PhotonNetwork.isMasterClient && this.activeAI && this.targetPlayer == null)
			{
				this.targetPlayer = this.serchTag(base.gameObject, "Player");
				int num = this.ReturnTargetNumber(this.targetPlayer.name);
				this.myPV.RPC("ReciveTarget", PhotonTargets.Others, new object[]
				{
					num
				});
			}
			if (!this.activeAI)
			{
				this.animator.SetBool("Sleep", true);
			}
			if (this.wakeUp)
			{
				this.animator.SetBool("Sleep", false);
				this.activeAI = true;
			}
			if (this.goBattle && !this.check)
			{
				this.playerSpawn.bossBattle = true;
				this.check = true;
			}
			if (!this.goBattle && this.startHp > this.enemyBody.hp)
			{
				this.targetPlayer = this.serchTag(base.gameObject, "Player");
				int num2 = this.ReturnTargetNumber(this.targetPlayer.name);
				this.myPV.RPC("ReciveTarget", PhotonTargets.Others, new object[]
				{
					num2
				});
				this.goBattle = true;
			}
			if (this.goBattle)
			{
				this.searchTargetTimer += Time.deltaTime;
				if (this.searchTargetTimer > 30f)
				{
					this.targetPlayer = this.serchTag(base.gameObject, "Player");
					int num3 = this.ReturnTargetNumber(this.targetPlayer.name);
					this.myPV.RPC("ReciveTarget", PhotonTargets.Others, new object[]
					{
						num3
					});
					this.searchTargetTimer = 0f;
				}
				if (!this.bgmCheck && PhotonNetwork.isMasterClient)
				{
					this.bgmWorks.ChangeBGMCall(this.bossBGM);
					this.bgmCheck = true;
				}
			}
			if (this.accumulationPoint <= 0f)
			{
				this.goBrakeLegsAcce = true;
			}
			if (this.goBrakeLegsAcce && !this.acceBrakeCheck)
			{
				this.myPV.RPC("GoBrakeAcce", PhotonTargets.Others, new object[0]);
				this.AcceBrake();
				this.acceBrakeCheck = true;
			}
			if (this.enemyBody.hp <= this.startHp / 2f)
			{
				this.halfHp = true;
				this.goFall = true;
			}
			if (currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_Walk || currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_WalkBack || currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_Idle)
			{
				this.instanceBlood = true;
				if (this.instanceBlood)
				{
					this.bloodTimer += Time.deltaTime;
				}
				if (this.bloodTimer > UnityEngine.Random.Range(0f, 3f))
				{
					this.instantiateManager.EnemyBlood(UnityEngine.Random.Range(this.bloodLimitLeftDown.transform.position.x, this.bloodLimitRightTop.transform.position.x), UnityEngine.Random.Range(this.bloodLimitLeftDown.transform.position.y, this.bloodLimitRightTop.transform.position.y));
					this.bloodTimer = 0f;
				}
			}
			if ((currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_Beam || currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_BeamDia || currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_BeamDiaUp || currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_JumpATK || currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_Turn || currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_JumpATK || currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_GoFall || currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_InhaleATK || currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_IntestineATK) && currentAnimatorStateInfo.normalizedTime > 1f && PhotonNetwork.isMasterClient)
			{
				this.animator.SetBool("SlideATK", false);
				this.animator.SetBool("Turn", false);
				this.animator.SetBool("BeamUp", false);
				this.animator.SetBool("BeamDown", false);
				this.animator.SetBool("BeamMiddle", false);
				this.animator.SetBool("InhaleATK", false);
				this.animator.SetBool("IntestineATK", false);
			}
			if (currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_InFall && this.eventGround && PhotonNetwork.isMasterClient)
			{
				this.animator.SetBool("GoFall", false);
			}
			if (currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_Idle)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
			}
			else if (currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_Walk)
			{
				if (base.transform.localScale.x > 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(this.speed * -1f, base.GetComponent<Rigidbody2D>().velocity.y);
				}
				else if (base.transform.localScale.x < 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(this.speed, base.GetComponent<Rigidbody2D>().velocity.y);
				}
			}
			else if (currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_WalkBack)
			{
				if (base.transform.localScale.x > 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(this.speed, base.GetComponent<Rigidbody2D>().velocity.y);
				}
				else if (base.transform.localScale.x < 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(this.speed * -1f, base.GetComponent<Rigidbody2D>().velocity.y);
				}
			}
			if (this.targetPlayer != null)
			{
				if (base.transform.localScale.x > 0f)
				{
					if (base.transform.position.x > this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = false;
					}
					else if (base.transform.position.x < this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = true;
					}
				}
				else if (base.transform.localScale.x < 0f)
				{
					if (base.transform.position.x < this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = false;
					}
					else if (base.transform.position.x > this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = true;
					}
				}
			}
			if (this.dogPile != null)
			{
				if (this.GetDistanceDogPile() > this.dogPileReturnLength)
				{
					this.canWalkZone = false;
				}
				else if (this.GetDistanceDogPile() < this.dogPileReturnLength)
				{
					this.canWalkZone = true;
				}
			}
			if (this.dogPile != null)
			{
				if (this.GetDistanceDogPile() > this.specialATKActiveLength)
				{
					this.canSpecialATKZone = false;
				}
				else if (this.GetDistanceDogPile() < this.specialATKActiveLength)
				{
					this.canSpecialATKZone = true;
				}
			}
			if (this.dogPile != null)
			{
				if (this.GetDistanceDogPile() > this.ATKActiveLength)
				{
					this.canATKZone = false;
				}
				else if (this.GetDistanceDogPile() < this.ATKActiveLength)
				{
					this.canATKZone = true;
				}
			}
			if (this.BeginEnemyCommonWork() && PhotonNetwork.isMasterClient && this.activeAI)
			{
				this.FixedUpdateAI();
				this.EndEnemyCommonWork();
			}
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x00096838 File Offset: 0x00094A38
		public bool BeginEnemyCommonWork()
		{
			if (this.enemyBody.hp <= 0f)
			{
				if (!this.deadCheck)
				{
					this.Dead();
					this.myPV.RPC("ReciveDead", PhotonTargets.Others, new object[0]);
					this.deadCheck = true;
				}
				return false;
			}
			this.animator.enabled = true;
			return this.CheckAction();
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x000968A8 File Offset: 0x00094AA8
		public void EndEnemyCommonWork()
		{
			if (PhotonNetwork.isMasterClient)
			{
				float num = Time.fixedTime - this.aiActionTimeStart;
				if (num > this.aiActionTimeLength)
				{
					this.animator.SetBool("WalkForward", false);
					this.animator.SetBool("WalkBack", false);
					this.enemyAists = BossStage01.ENEMYAISTS.WAIT;
				}
			}
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00096904 File Offset: 0x00094B04
		public bool CheckAction()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			return currentAnimatorStateInfo.fullPathHash != BossStage01.ANISTS_Dead && currentAnimatorStateInfo.fullPathHash != BossStage01.ANISTS_Turn && currentAnimatorStateInfo.fullPathHash != BossStage01.ANISTS_Beam && currentAnimatorStateInfo.fullPathHash != BossStage01.ANISTS_BeamDia && currentAnimatorStateInfo.fullPathHash != BossStage01.ANISTS_BeamDiaUp && currentAnimatorStateInfo.fullPathHash != BossStage01.ANISTS_JumpATK && currentAnimatorStateInfo.fullPathHash != BossStage01.ANISTS_GoFall && currentAnimatorStateInfo.fullPathHash != BossStage01.ANISTS_InFall && currentAnimatorStateInfo.fullPathHash != BossStage01.ANISTS_EndFall && currentAnimatorStateInfo.fullPathHash != BossStage01.ANISTS_InhaleATK && currentAnimatorStateInfo.fullPathHash != BossStage01.ANISTS_IntestineATK;
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x000969DC File Offset: 0x00094BDC
		private void FixedUpdateAI()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if ((this.enemyAists == BossStage01.ENEMYAISTS.SLIDEATK || this.enemyAists == BossStage01.ENEMYAISTS.BEAMDOWN || this.enemyAists == BossStage01.ENEMYAISTS.BEAMMIDDLE || this.enemyAists == BossStage01.ENEMYAISTS.BEAMUP || this.enemyAists == BossStage01.ENEMYAISTS.BEAMUP || this.enemyAists == BossStage01.ENEMYAISTS.GOFALL || this.enemyAists == BossStage01.ENEMYAISTS.INHALE || this.enemyAists == BossStage01.ENEMYAISTS.INTESTINE || this.enemyAists == BossStage01.ENEMYAISTS.RETURNTODOGPILE || this.enemyAists == BossStage01.ENEMYAISTS.TURN) && currentAnimatorStateInfo.fullPathHash == BossStage01.ANISTS_Idle)
			{
				this.enemyAists = BossStage01.ENEMYAISTS.WAIT;
			}
			if (this.goFall && !this.falled)
			{
				this.enemyAists = BossStage01.ENEMYAISTS.GOFALL;
				this.myPV.RPC("ReciveFall", PhotonTargets.Others, new object[0]);
				this.falled = true;
			}
			if (!this.falled && !this.goBattle && this.canAI && this.canWalkZone && (this.targetLeftDownPos || (this.targetRightDownPos && !this.targetLeftUpPos && !this.targetRightUpPos)))
			{
				this.enemyAists = BossStage01.ENEMYAISTS.BEAMDOWN;
			}
			if (!this.goBattle && this.canAI)
			{
				if (!this.canWalkZone)
				{
					this.enemyAists = BossStage01.ENEMYAISTS.RETURNTODOGPILE;
				}
				if (this.playerBackSide)
				{
					this.enemyAists = BossStage01.ENEMYAISTS.TURN;
				}
				if (this.playerInBeamZoneDown)
				{
					this.enemyAists = BossStage01.ENEMYAISTS.BEAMDOWN;
				}
				if (this.playerInBeamZoneUp)
				{
					this.enemyAists = BossStage01.ENEMYAISTS.BEAMUP;
				}
				if (this.canWalkZone)
				{
					if (this.targetLeftDownPos && !this.targetLeftUpPos && !this.targetRightUpPos)
					{
						int num = this.SelectRandomAIState();
						if (num < 20)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(1f, 4f));
						}
						else if (num < 40)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(1f, 3f));
						}
						else if (num < 100)
						{
							if (base.transform.localScale.x > 0f)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.BEAMDOWN;
							}
							else
							{
								this.enemyAists = BossStage01.ENEMYAISTS.TURN;
							}
						}
					}
					else if (this.targetRightDownPos && !this.targetLeftUpPos && !this.targetRightUpPos)
					{
						int num2 = this.SelectRandomAIState();
						if (num2 < 20)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(1f, 4f));
						}
						else if (num2 < 40)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(1f, 3f));
						}
						else if (num2 < 100)
						{
							if (base.transform.localScale.x < 0f)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.BEAMDOWN;
							}
							else
							{
								this.enemyAists = BossStage01.ENEMYAISTS.TURN;
							}
						}
					}
					else if (this.targetLeftUpPos)
					{
						int num3 = this.SelectRandomAIState();
						if (num3 < 20)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(1f, 4f));
						}
						else if (num3 < 40)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(1f, 3f));
						}
						else if (num3 < 100)
						{
							if (base.transform.localScale.x > 0f)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.BEAMUP;
							}
							else
							{
								this.enemyAists = BossStage01.ENEMYAISTS.TURN;
							}
						}
					}
					else if (this.targetRightUpPos)
					{
						int num4 = this.SelectRandomAIState();
						if (num4 < 20)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(1f, 4f));
						}
						else if (num4 < 40)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(1f, 3f));
						}
						else if (num4 < 100)
						{
							if (base.transform.localScale.x < 0f)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.BEAMUP;
							}
							else
							{
								this.enemyAists = BossStage01.ENEMYAISTS.TURN;
							}
						}
					}
					else if (!this.targetLeftDownPos || (!this.targetRightDownPos && !this.targetLeftUpPos && !this.targetRightUpPos))
					{
						int num5 = this.SelectRandomAIState();
						if (num5 < 50)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(1f, 4f));
						}
						else if (num5 < 100)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(1f, 3f));
						}
					}
				}
			}
			if (this.goBattle && this.canAI)
			{
				if (!this.canWalkZone)
				{
					this.enemyAists = BossStage01.ENEMYAISTS.RETURNTODOGPILE;
				}
				if (this.playerBackSide)
				{
					this.enemyAists = BossStage01.ENEMYAISTS.TURN;
				}
				if (!this.halfHp)
				{
					if (this.canSpecialATKZone)
					{
						if (!this.playerBackSide)
						{
							int num6 = this.SelectRandomAIState();
							if (num6 < 20)
							{
								this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(1f, 4f));
							}
							else if (num6 < 40)
							{
								this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(1f, 3f));
							}
							else if (num6 < 60)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.SLIDEATK;
							}
							else if (num6 < 75)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.BEAMDOWN;
							}
							else if (num6 < 85)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.BEAMMIDDLE;
							}
							else if (num6 < 100)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.INTESTINE;
							}
						}
					}
					else if (this.canWalkZone)
					{
						if (!this.targetLeftUpPos && !this.targetRightUpPos)
						{
							int num7 = this.SelectRandomAIState();
							if (num7 < 30)
							{
								this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(1f, 4f));
							}
							else if (num7 < 60)
							{
								this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(1f, 3f));
							}
							else if (num7 < 80)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.SLIDEATK;
							}
							else if (num7 < 80)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.INHALE;
							}
						}
						else if (this.targetLeftUpPos)
						{
							int num8 = this.SelectRandomAIState();
							if (num8 < 20)
							{
								this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(1f, 4f));
							}
							else if (num8 < 40)
							{
								this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(1f, 3f));
							}
							else if (num8 < 100)
							{
								if (base.transform.localScale.x > 0f)
								{
									this.enemyAists = BossStage01.ENEMYAISTS.BEAMUP;
								}
								else
								{
									this.enemyAists = BossStage01.ENEMYAISTS.TURN;
								}
							}
						}
						else if (this.targetRightUpPos)
						{
							int num9 = this.SelectRandomAIState();
							if (num9 < 20)
							{
								this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(1f, 4f));
							}
							else if (num9 < 40)
							{
								this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(1f, 3f));
							}
							else if (num9 < 100)
							{
								if (base.transform.localScale.x < 0f)
								{
									this.enemyAists = BossStage01.ENEMYAISTS.BEAMUP;
								}
								else
								{
									this.enemyAists = BossStage01.ENEMYAISTS.TURN;
								}
							}
						}
					}
				}
				if (this.halfHp)
				{
					if (this.canSpecialATKZone)
					{
						if (!this.playerBackSide)
						{
							int num10 = this.SelectRandomAIState();
							if (num10 < 20)
							{
								this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(1f, 4f));
							}
							else if (num10 < 40)
							{
								this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(1f, 3f));
							}
							else if (num10 < 50)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.SLIDEATK;
							}
							else if (num10 < 60)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.BEAMDOWN;
							}
							else if (num10 < 70)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.BEAMMIDDLE;
							}
							else if (num10 < 85)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.INTESTINE;
							}
							else if (num10 < 100)
							{
								this.enemyAists = BossStage01.ENEMYAISTS.INHALE;
							}
						}
					}
					else if (this.canWalkZone)
					{
						int num11 = this.SelectRandomAIState();
						if (num11 < 10)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(1f, 4f));
						}
						else if (num11 < 20)
						{
							this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(1f, 3f));
						}
						else if (num11 < 40)
						{
							this.enemyAists = BossStage01.ENEMYAISTS.SLIDEATK;
						}
						else if (num11 < 60)
						{
							this.enemyAists = BossStage01.ENEMYAISTS.INHALE;
						}
						else if (num11 < 80)
						{
							this.enemyAists = BossStage01.ENEMYAISTS.BEAMDOWN;
						}
						else if (num11 < 100)
						{
							this.enemyAists = BossStage01.ENEMYAISTS.BEAMMIDDLE;
						}
					}
				}
			}
			switch (this.enemyAists)
			{
			case BossStage01.ENEMYAISTS.WAIT:
				this.timetest2 += Time.deltaTime;
				if (this.timetest2 > UnityEngine.Random.Range(this.waitTimeMin, this.waitTimeMax))
				{
					this.canAI = true;
					this.timetest2 = 0f;
				}
				break;
			case BossStage01.ENEMYAISTS.WALKFORWARD:
				if (!this.animator.GetBool("WalkForward"))
				{
					this.animator.SetBool("WalkForward", true);
				}
				this.canAI = false;
				break;
			case BossStage01.ENEMYAISTS.WALKBACK:
				if (!this.animator.GetBool("WalkBack"))
				{
					this.animator.SetBool("WalkBack", true);
				}
				this.canAI = false;
				break;
			case BossStage01.ENEMYAISTS.TURN:
				if (!this.animator.GetBool("Turn"))
				{
					this.animator.SetBool("Turn", true);
				}
				this.canAI = false;
				break;
			case BossStage01.ENEMYAISTS.RETURNTODOGPILE:
				if (base.transform.position.x > this.dogPile.transform.position.x)
				{
					if (base.transform.localScale.x < 0f)
					{
						this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(3f, 4f));
					}
					else if (base.transform.localScale.x > 0f)
					{
						this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(3f, 4f));
					}
				}
				else if (base.transform.position.x < this.dogPile.transform.position.x)
				{
					if (base.transform.localScale.x > 0f)
					{
						this.SetAIState(BossStage01.ENEMYAISTS.WALKBACK, UnityEngine.Random.Range(3f, 4f));
					}
					else if (base.transform.localScale.x < 0f)
					{
						this.SetAIState(BossStage01.ENEMYAISTS.WALKFORWARD, UnityEngine.Random.Range(3f, 4f));
					}
				}
				this.canAI = false;
				break;
			case BossStage01.ENEMYAISTS.SLIDEATK:
				if (!this.animator.GetBool("SlideATK"))
				{
					this.animator.SetBool("SlideATK", true);
				}
				this.canAI = false;
				break;
			case BossStage01.ENEMYAISTS.BEAMDOWN:
				if (!this.animator.GetBool("BeamDown"))
				{
					this.animator.SetBool("BeamDown", true);
				}
				this.canAI = false;
				break;
			case BossStage01.ENEMYAISTS.BEAMMIDDLE:
				if (!this.animator.GetBool("BeamMiddle"))
				{
					this.animator.SetBool("BeamMiddle", true);
				}
				this.canAI = false;
				break;
			case BossStage01.ENEMYAISTS.BEAMUP:
				if (!this.animator.GetBool("BeamUp"))
				{
					this.animator.SetBool("BeamUp", true);
				}
				this.canAI = false;
				break;
			case BossStage01.ENEMYAISTS.GOFALL:
				if (!this.animator.GetBool("GoFall"))
				{
					this.animator.SetBool("GoFall", true);
				}
				this.canAI = false;
				break;
			case BossStage01.ENEMYAISTS.INHALE:
				if (!this.animator.GetBool("InhaleATK"))
				{
					this.animator.SetBool("InhaleATK", true);
				}
				this.canAI = false;
				break;
			case BossStage01.ENEMYAISTS.INTESTINE:
				if (!this.animator.GetBool("IntestineATK"))
				{
					this.animator.SetBool("IntestineATK", true);
				}
				this.canAI = false;
				break;
			}
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x000976CB File Offset: 0x000958CB
		public void EnemyKillsCountPlus()
		{
			this.menuOnOff.enemyKills++;
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x000976E0 File Offset: 0x000958E0
		public void ArchiveCheck()
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
			foreach (GameObject gameObject in array)
			{
				if (gameObject.GetComponent<PlayerController>() != null)
				{
					PlayerController component = gameObject.GetComponent<PlayerController>();
					if (component.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Shanoa>() != null)
				{
					PlayerController_Shanoa component2 = gameObject.GetComponent<PlayerController_Shanoa>();
					if (component2.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Jonathan>() != null)
				{
					PlayerController_Jonathan component3 = gameObject.GetComponent<PlayerController_Jonathan>();
					if (component3.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Charotte>() != null)
				{
					PlayerController_Charotte component4 = gameObject.GetComponent<PlayerController_Charotte>();
					if (component4.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Albus>() != null)
				{
					PlayerController_Albus component5 = gameObject.GetComponent<PlayerController_Albus>();
					if (component5.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Soma>() != null)
				{
					PlayerController_Soma component6 = gameObject.GetComponent<PlayerController_Soma>();
					if (component6.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Alucard>() != null)
				{
					PlayerController_Alucard component7 = gameObject.GetComponent<PlayerController_Alucard>();
					if (component7.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Julius>() != null)
				{
					PlayerController_Julius component8 = gameObject.GetComponent<PlayerController_Julius>();
					if (component8.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Yoko>() != null)
				{
					PlayerController_Yoko component9 = gameObject.GetComponent<PlayerController_Yoko>();
					if (component9.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Maria>() != null)
				{
					PlayerController_Maria component10 = gameObject.GetComponent<PlayerController_Maria>();
					if (component10.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Simon>() != null)
				{
					PlayerController_Simon component11 = gameObject.GetComponent<PlayerController_Simon>();
					if (component11.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Fuma>() != null)
				{
					PlayerController_Fuma component12 = gameObject.GetComponent<PlayerController_Fuma>();
					if (component12.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Add1>() != null)
				{
					PlayerController_Add1 component13 = gameObject.GetComponent<PlayerController_Add1>();
					if (component13.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Add2>() != null)
				{
					PlayerController_Add2 component14 = gameObject.GetComponent<PlayerController_Add2>();
					if (component14.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Add3>() != null)
				{
					PlayerController_Add3 component15 = gameObject.GetComponent<PlayerController_Add3>();
					if (component15.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Add4>() != null)
				{
					PlayerController_Add4 component16 = gameObject.GetComponent<PlayerController_Add4>();
					if (component16.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Add5>() != null)
				{
					PlayerController_Add5 component17 = gameObject.GetComponent<PlayerController_Add5>();
					if (component17.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
			}
			if (this.skeltonPlayers >= 5 && !this.alreadyUnlockArchive2)
			{
				this.targetText.text = "スケルトンファイブ";
				this.targetImage.sprite = this.archiveSprite2;
				this.targetAnim.SetTrigger("UnLock");
				PlayerPrefs.SetInt("SkeltonFive", 1);
				this.alreadyUnlockArchive2 = true;
			}
			if (!this.alreadyUnlockArchive && this.enemyBody.hitSlidingKick)
			{
				this.targetText.text = "殺人スライディング";
				this.targetImage.sprite = this.archiveSprite;
				this.targetAnim.SetTrigger("UnLock");
				PlayerPrefs.SetInt("SatsujinSliding", 1);
				this.alreadyUnlockArchive = true;
			}
			if (!this.alreadyUnlockArchive3 && this.lastDMG != null && this.lastDMG.tag == "DualCrush")
			{
				this.targetText.text = "地獄のコンビネーション";
				this.targetImage.sprite = this.archiveSprite3;
				this.targetAnim.SetTrigger("UnLock");
				PlayerPrefs.SetInt("JigokunoCombination", 1);
				this.alreadyUnlockArchive3 = true;
			}
			if (this.playerStatus.stageDifficult >= 2 && !this.alreadyUnlockArchive4)
			{
				PlayerPrefs.SetInt("Hard1_Clear", 1);
				this.alreadyUnlockArchive4 = true;
			}
			if (this.enemyBody.ownATKHitted)
			{
				this.playerStatus.data_Gergos++;
				this.playerStatus.score += this.score;
				this.playerStatus.killCount++;
				this.playerStatus.killCountAll++;
			}
			this.door1.up = true;
			this.door2.up = true;
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x00097C50 File Offset: 0x00095E50
		public void Dead()
		{
			this.InhaleVelocityDisabled();
			this.cVSounds = GameObject.FindGameObjectWithTag("Player").GetComponent<CVSounds>();
			this.cVSounds.KillBoss();
			this.animator.SetBool("Dead", true);
			if (this.playerStatus.charaNumber == 5)
			{
				float soul = this.GetSoul(this.playerStatus.soulEaterRing);
				if (soul > 99.5f)
				{
					GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
					foreach (GameObject gameObject in array)
					{
						PhotonView component = gameObject.GetComponent<PhotonView>();
						if (component.isMine)
						{
							PlayerController_Soma component2 = gameObject.GetComponent<PlayerController_Soma>();
							this.instantiateManager.PlayerSoulRed(base.transform.position.x, base.transform.position.y + 0.5f, gameObject, component2, "ゲーゴス");
						}
					}
				}
			}
			if (PhotonNetwork.isMasterClient)
			{
				base.Invoke("AppearChestBox", 3f);
			}
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x00097D64 File Offset: 0x00095F64
		public void AppearChestBox()
		{
			GameObject gameObject = PhotonNetwork.Instantiate("Chest_Gold", new Vector3(this.chestPos.position.x, this.chestPos.position.y, 0f), Quaternion.identity, 0);
			ItemsChest component = gameObject.GetComponent<ItemsChest>();
			component.boxLevel = this.playerStatus.stageDifficult;
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x00097DCC File Offset: 0x00095FCC
		public void AcceBrake()
		{
			foreach (GameObject gameObject in this.targetDestroyObj)
			{
				gameObject.SetActive(false);
			}
			this.animator.SetBool("AcceBrake", true);
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x00097E10 File Offset: 0x00096010
		public int SelectRandomAIState()
		{
			return UnityEngine.Random.Range(0, 100);
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x00097E1A File Offset: 0x0009601A
		public void SetAIState(BossStage01.ENEMYAISTS sts, float t)
		{
			this.aiActionTimeStart = Time.fixedTime;
			this.aiActionTimeLength = t;
			this.enemyAists = sts;
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x00097E38 File Offset: 0x00096038
		public float GetDistanceDogPile()
		{
			float num = base.transform.position.x - this.dogPile.transform.position.x;
			if (num < 0f)
			{
				num *= -1f;
			}
			return num;
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x00097E86 File Offset: 0x00096086
		public void SendAcceDamage(float val)
		{
			this.accumulationPoint -= val;
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x00097E98 File Offset: 0x00096098
		private IEnumerator EnumPoisonDamage(float delay)
		{
			yield return new WaitForSeconds(delay);
			if (this.poison)
			{
				this.enemyBody.ActionDamagePoison(base.transform.position.x, base.transform.position.y + 0.5f);
				base.StartCoroutine(this.EnumPoisonDamage(3f));
			}
			yield break;
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x00097EBA File Offset: 0x000960BA
		public void SoundEffectCall(int num)
		{
			this.eSE.SoundEffectPlay(num);
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x00097EC8 File Offset: 0x000960C8
		public void VelocityX(float Vx)
		{
			if (base.transform.localScale.x < 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(Vx, base.GetComponent<Rigidbody2D>().velocity.y);
			}
			else if (base.transform.localScale.x > 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f * Vx, base.GetComponent<Rigidbody2D>().velocity.y);
			}
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x00097F64 File Offset: 0x00096164
		public void VelocityY(float Vy)
		{
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, Vy);
		}

		// Token: 0x06000DD8 RID: 3544 RVA: 0x00097F98 File Offset: 0x00096198
		public void DirTurn()
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x * -1f, base.transform.localScale.y, base.transform.localScale.z);
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x00097FF4 File Offset: 0x000961F4
		public void BeamGoWidth()
		{
			this.beamGoWidth = true;
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x00098000 File Offset: 0x00096200
		public void InstanceBeamBall()
		{
			this.pS.transform.position = new Vector2(this.beamDiaPos.position.x, this.beamDiaPos.position.y);
			this.pS.Play();
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x00098058 File Offset: 0x00096258
		public void InstanceBeamDia()
		{
			if (!this.falled)
			{
				if (base.transform.localScale.x > 0f)
				{
					this.beamLine.gameObject.transform.position = new Vector2(this.beamDiaPos.position.x, this.beamDiaPos.position.y);
					this.beamLine.gameObject.transform.LookAt2D(this.leftBeamDiaLookAt);
					this.beamShotTimer = 0f;
					this.beamState = 0;
					this.beamWidth = 0f;
					this.beamLine.SetWidth(0f, 0f);
					this.beamLine.enabled = true;
					this.canShotBeam = true;
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.beamLine.gameObject.transform.position = new Vector2(this.beamDiaPos.position.x, this.beamDiaPos.position.y);
					this.beamLine.gameObject.transform.LookAt2D(this.rightBeamDiaLookAt);
					this.beamShotTimer = 0f;
					this.beamState = 0;
					this.beamWidth = 0f;
					this.beamLine.SetWidth(0f, 0f);
					this.beamLine.enabled = true;
					this.canShotBeam = true;
				}
			}
			else if (this.falled)
			{
				if (base.transform.localScale.x > 0f)
				{
					this.beamLine.gameObject.transform.position = new Vector2(this.beamDiaPos.position.x, this.beamDiaPos.position.y);
					this.beamLine.gameObject.transform.LookAt2D(this.leftBeamDiaLookAt2);
					this.beamShotTimer = 0f;
					this.beamState = 0;
					this.beamWidth = 0f;
					this.beamLine.SetWidth(0f, 0f);
					this.beamLine.enabled = true;
					this.canShotBeam = true;
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.beamLine.gameObject.transform.position = new Vector2(this.beamDiaPos.position.x, this.beamDiaPos.position.y);
					this.beamLine.gameObject.transform.LookAt2D(this.rightBeamDiaLookAt2);
					this.beamShotTimer = 0f;
					this.beamState = 0;
					this.beamWidth = 0f;
					this.beamLine.SetWidth(0f, 0f);
					this.beamLine.enabled = true;
					this.canShotBeam = true;
				}
			}
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x0009839C File Offset: 0x0009659C
		public void InstanceBeamUpDia()
		{
			if (base.transform.localScale.x > 0f)
			{
				this.beamLine.gameObject.transform.position = new Vector2(this.beamDiaPos.position.x, this.beamDiaPos.position.y);
				this.beamLine.gameObject.transform.LookAt2D(this.leftBeamDiaUpLookAt);
				this.beamShotTimer = 0f;
				this.beamState = 0;
				this.beamWidth = 0f;
				this.beamLine.SetWidth(0f, 0f);
				this.beamLine.enabled = true;
				this.canShotBeam = true;
			}
			else if (base.transform.localScale.x < 0f)
			{
				this.beamLine.gameObject.transform.position = new Vector2(this.beamDiaPos.position.x, this.beamDiaPos.position.y);
				this.beamLine.gameObject.transform.LookAt2D(this.rightBeamDiaUpLookAt);
				this.beamShotTimer = 0f;
				this.beamState = 0;
				this.beamWidth = 0f;
				this.beamLine.SetWidth(0f, 0f);
				this.beamLine.enabled = true;
				this.canShotBeam = true;
			}
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x00098534 File Offset: 0x00096734
		public void InstanceBeamFront()
		{
			if (base.transform.localScale.x > 0f)
			{
				this.beamLine.gameObject.transform.position = new Vector2(this.beamDiaPos.position.x, this.beamDiaPos.position.y);
				this.beamLine.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
				this.beamShotTimer = 0f;
				this.beamState = 0;
				this.beamWidth = 0f;
				this.beamLine.SetWidth(0f, 0f);
				this.beamLine.enabled = true;
				this.canShotBeam = true;
			}
			else if (base.transform.localScale.x < 0f)
			{
				this.beamLine.gameObject.transform.position = new Vector2(this.beamDiaPos.position.x, this.beamDiaPos.position.y);
				this.beamLine.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				this.beamShotTimer = 0f;
				this.beamState = 0;
				this.beamWidth = 0f;
				this.beamLine.SetWidth(0f, 0f);
				this.beamLine.enabled = true;
				this.canShotBeam = true;
			}
		}

		// Token: 0x06000DDE RID: 3550 RVA: 0x000986E8 File Offset: 0x000968E8
		public void InhaleVelocityEnable()
		{
			if (base.transform.localScale.x > 0f)
			{
				this.veloRightCol2d.enabled = true;
			}
			else if (base.transform.localScale.x < 0f)
			{
				this.veloLeftCol2d.enabled = true;
			}
		}

		// Token: 0x06000DDF RID: 3551 RVA: 0x0009874C File Offset: 0x0009694C
		public void InstanceDustHead()
		{
			int i = 1;
			while (i <= 30)
			{
				int num = UnityEngine.Random.Range(0, 10);
				if (num < 5)
				{
					this.instantiateManager.Dust(this.headPos.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f), this.headPos.transform.position.y + UnityEngine.Random.Range(0f, 0.3f));
					i++;
				}
				else if (num >= 5)
				{
					this.instantiateManager.Dust2(this.headPos.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f), this.headPos.transform.position.y + UnityEngine.Random.Range(0f, 0.3f));
					i++;
				}
			}
		}

		// Token: 0x06000DE0 RID: 3552 RVA: 0x00098848 File Offset: 0x00096A48
		public void InstanceDustLeftLeg()
		{
			int i = 1;
			while (i <= 30)
			{
				int num = UnityEngine.Random.Range(0, 10);
				if (num < 5)
				{
					this.instantiateManager.Dust(this.leftLegPos.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f), this.leftLegPos.transform.position.y + UnityEngine.Random.Range(0f, 0.3f));
					i++;
				}
				else if (num >= 5)
				{
					this.instantiateManager.Dust2(this.leftLegPos.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f), this.leftLegPos.transform.position.y + UnityEngine.Random.Range(0f, 0.3f));
					i++;
				}
			}
		}

		// Token: 0x06000DE1 RID: 3553 RVA: 0x00098944 File Offset: 0x00096B44
		public void InstanceDustRightLeg()
		{
			int i = 1;
			while (i <= 30)
			{
				int num = UnityEngine.Random.Range(0, 10);
				if (num < 5)
				{
					this.instantiateManager.Dust(this.rightLegPos.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f), this.rightLegPos.transform.position.y + UnityEngine.Random.Range(0f, 0.3f));
					i++;
				}
				else if (num >= 5)
				{
					this.instantiateManager.Dust2(this.rightLegPos.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f), this.rightLegPos.transform.position.y + UnityEngine.Random.Range(0f, 0.3f));
					i++;
				}
			}
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x00098A3E File Offset: 0x00096C3E
		public void InhaleVelocityDisabled()
		{
			this.veloRightCol2d.enabled = false;
			this.veloLeftCol2d.enabled = false;
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x00098A58 File Offset: 0x00096C58
		[PunRPC]
		private void ReciveTarget(int num)
		{
			this.targetPlayer = GameObject.Find(this.ReturnTargetName(num));
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x00098A6C File Offset: 0x00096C6C
		[PunRPC]
		private void ReciveDead()
		{
			if (!this.deadCheck)
			{
				this.Dead();
				this.deadCheck = true;
			}
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x00098A86 File Offset: 0x00096C86
		[PunRPC]
		private void GoBrakeAcce()
		{
			if (!this.acceBrakeCheck)
			{
				this.AcceBrake();
				this.acceBrakeCheck = true;
			}
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x00098AA0 File Offset: 0x00096CA0
		[PunRPC]
		private void ReciveCurse()
		{
			this.curseTimer = 0f;
			if (!this.curse)
			{
				this.curse = true;
			}
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x00098ABF File Offset: 0x00096CBF
		[PunRPC]
		private void RecivePoison()
		{
			this.poisonTimer = 0f;
			if (!this.poison)
			{
				this.poison = true;
			}
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x00098ADE File Offset: 0x00096CDE
		[PunRPC]
		private void ReciveFall()
		{
			this.falled = true;
		}

		// Token: 0x04001239 RID: 4665
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Boss01_Idle");

		// Token: 0x0400123A RID: 4666
		public static readonly int ANISTS_Walk = Animator.StringToHash("Base Layer.Boss01_Walk");

		// Token: 0x0400123B RID: 4667
		public static readonly int ANISTS_WalkBack = Animator.StringToHash("Base Layer.Boss01_WalkBack");

		// Token: 0x0400123C RID: 4668
		public static readonly int ANISTS_Turn = Animator.StringToHash("Base Layer.Boss01_Turn");

		// Token: 0x0400123D RID: 4669
		public static readonly int ANISTS_BeamDia = Animator.StringToHash("Base Layer.Boss01_BeamDia");

		// Token: 0x0400123E RID: 4670
		public static readonly int ANISTS_Beam = Animator.StringToHash("Base Layer.Boss01_Beam");

		// Token: 0x0400123F RID: 4671
		public static readonly int ANISTS_BeamDiaUp = Animator.StringToHash("Base Layer.Boss01_BeamDiaUp");

		// Token: 0x04001240 RID: 4672
		public static readonly int ANISTS_JumpATK = Animator.StringToHash("Base Layer.Boss01_BackJumpATK");

		// Token: 0x04001241 RID: 4673
		public static readonly int ANISTS_GoFall = Animator.StringToHash("Base Layer.Boss01_GoFall");

		// Token: 0x04001242 RID: 4674
		public static readonly int ANISTS_InFall = Animator.StringToHash("Base Layer.Boss01_InFall");

		// Token: 0x04001243 RID: 4675
		public static readonly int ANISTS_EndFall = Animator.StringToHash("Base Layer.Boss01_EndFall");

		// Token: 0x04001244 RID: 4676
		public static readonly int ANISTS_InhaleATK = Animator.StringToHash("Base Layer.Boss01_InhaleATK");

		// Token: 0x04001245 RID: 4677
		public static readonly int ANISTS_IntestineATK = Animator.StringToHash("Base Layer.Boss01_IntestineATK");

		// Token: 0x04001246 RID: 4678
		public static readonly int ANISTS_Dead = Animator.StringToHash("Base Layer.Boss01_Dead");

		// Token: 0x04001247 RID: 4679
		public static readonly int ANISTS_AcceBrake = Animator.StringToHash("Base Layer.Boss01_AcceBrake");

		// Token: 0x04001248 RID: 4680
		public int aiIfSTAY = 10;

		// Token: 0x04001249 RID: 4681
		public int aiIfWALKFORWARD = 10;

		// Token: 0x0400124A RID: 4682
		public int aiIFWALKBACK = 10;

		// Token: 0x0400124B RID: 4683
		public int aiIfTURN = 50;

		// Token: 0x0400124C RID: 4684
		public int aiIfBEAMDOWN = 10;

		// Token: 0x0400124D RID: 4685
		public int aiIfBEAMMIDDLE = 10;

		// Token: 0x0400124E RID: 4686
		public int aiIfBEAMUP = 10;

		// Token: 0x0400124F RID: 4687
		public int aiIfJUMPATK = 10;

		// Token: 0x04001250 RID: 4688
		public int aiIfGOOFALL = 10;

		// Token: 0x04001251 RID: 4689
		public int aiIfINHALE = 10;

		// Token: 0x04001252 RID: 4690
		public int aiIfINTESTINE = 10;

		// Token: 0x04001253 RID: 4691
		public int aiIfRETURNDOGPILE = 30;

		// Token: 0x04001254 RID: 4692
		protected float aiActionTimeLength;

		// Token: 0x04001255 RID: 4693
		protected float aiActionTimeStart;

		// Token: 0x04001256 RID: 4694
		public BossStage01.ENEMYAISTS enemyAists;

		// Token: 0x04001257 RID: 4695
		public float speed = 1f;

		// Token: 0x04001258 RID: 4696
		public bool activeAI;

		// Token: 0x04001259 RID: 4697
		public float dogPileReturnLength = 2f;

		// Token: 0x0400125A RID: 4698
		public float ATKActiveLength = 1f;

		// Token: 0x0400125B RID: 4699
		public float specialATKActiveLength = 0.5f;

		// Token: 0x0400125C RID: 4700
		public float timetest2;

		// Token: 0x0400125D RID: 4701
		public float bloodTimer;

		// Token: 0x0400125E RID: 4702
		public float waitTimeMin = 3f;

		// Token: 0x0400125F RID: 4703
		public float waitTimeMax = 4f;

		// Token: 0x04001260 RID: 4704
		public float searchTargetTimer;

		// Token: 0x04001261 RID: 4705
		public float startHp;

		// Token: 0x04001262 RID: 4706
		public bool playerBackSide;

		// Token: 0x04001263 RID: 4707
		public bool canWalkZone;

		// Token: 0x04001264 RID: 4708
		public bool canATKZone;

		// Token: 0x04001265 RID: 4709
		public bool canSpecialATKZone;

		// Token: 0x04001266 RID: 4710
		public bool halfHp;

		// Token: 0x04001267 RID: 4711
		public bool goFall;

		// Token: 0x04001268 RID: 4712
		public bool falled;

		// Token: 0x04001269 RID: 4713
		public bool canAI;

		// Token: 0x0400126A RID: 4714
		public bool wakeUp;

		// Token: 0x0400126B RID: 4715
		public bool goBattle;

		// Token: 0x0400126C RID: 4716
		public bool instanceBlood;

		// Token: 0x0400126D RID: 4717
		public bool playerInBeamZoneDown;

		// Token: 0x0400126E RID: 4718
		public bool playerInBeamZoneUp;

		// Token: 0x0400126F RID: 4719
		public bool beamGoWidth;

		// Token: 0x04001270 RID: 4720
		public bool targetLeftDownPos;

		// Token: 0x04001271 RID: 4721
		public bool targetRightDownPos;

		// Token: 0x04001272 RID: 4722
		public bool targetLeftUpPos;

		// Token: 0x04001273 RID: 4723
		public bool targetRightUpPos;

		// Token: 0x04001274 RID: 4724
		public bool deadCheck;

		// Token: 0x04001275 RID: 4725
		public bool bgmCheck;

		// Token: 0x04001276 RID: 4726
		public GameObject dogPile;

		// Token: 0x04001277 RID: 4727
		public EnemyBody enemyBody;

		// Token: 0x04001278 RID: 4728
		public GameObject[] targetDestroyObj;

		// Token: 0x04001279 RID: 4729
		public GameObject bloodPrefab;

		// Token: 0x0400127A RID: 4730
		public GameObject beamPrefab;

		// Token: 0x0400127B RID: 4731
		public GameObject beamBall;

		// Token: 0x0400127C RID: 4732
		public Transform bloodLimitLeftDown;

		// Token: 0x0400127D RID: 4733
		public Transform bloodLimitRightTop;

		// Token: 0x0400127E RID: 4734
		public Transform beamDiaPos;

		// Token: 0x0400127F RID: 4735
		public Transform leftBeamDiaLookAt;

		// Token: 0x04001280 RID: 4736
		public Transform rightBeamDiaLookAt;

		// Token: 0x04001281 RID: 4737
		public Transform leftBeamDiaLookAt2;

		// Token: 0x04001282 RID: 4738
		public Transform rightBeamDiaLookAt2;

		// Token: 0x04001283 RID: 4739
		public Transform leftBeamDiaUpLookAt;

		// Token: 0x04001284 RID: 4740
		public Transform rightBeamDiaUpLookAt;

		// Token: 0x04001285 RID: 4741
		public float accumulationPoint = 300f;

		// Token: 0x04001286 RID: 4742
		public bool goBrakeLegsAcce;

		// Token: 0x04001287 RID: 4743
		public bool acceBrakeCheck;

		// Token: 0x04001288 RID: 4744
		private GameObject[] allPlayer;

		// Token: 0x04001289 RID: 4745
		private GameObject beamClone;

		// Token: 0x0400128A RID: 4746
		public Transform chestPos;

		// Token: 0x0400128B RID: 4747
		private BoxCollider2D veloRightCol2d;

		// Token: 0x0400128C RID: 4748
		private BoxCollider2D veloLeftCol2d;

		// Token: 0x0400128D RID: 4749
		public GameObject dustPrefab1;

		// Token: 0x0400128E RID: 4750
		public GameObject dustPrefab2;

		// Token: 0x0400128F RID: 4751
		private Transform headPos;

		// Token: 0x04001290 RID: 4752
		private Transform rightLegPos;

		// Token: 0x04001291 RID: 4753
		private Transform leftLegPos;

		// Token: 0x04001292 RID: 4754
		private EnemySoundEffect eSE;

		// Token: 0x04001293 RID: 4755
		private Animator targetAnim;

		// Token: 0x04001294 RID: 4756
		private Text targetText;

		// Token: 0x04001295 RID: 4757
		private Image targetImage;

		// Token: 0x04001296 RID: 4758
		public Sprite archiveSprite;

		// Token: 0x04001297 RID: 4759
		public Sprite archiveSprite2;

		// Token: 0x04001298 RID: 4760
		public Sprite archiveSprite3;

		// Token: 0x04001299 RID: 4761
		public bool alreadyUnlockArchive;

		// Token: 0x0400129A RID: 4762
		public bool alreadyUnlockArchive2;

		// Token: 0x0400129B RID: 4763
		public bool alreadyUnlockArchive3;

		// Token: 0x0400129C RID: 4764
		public bool alreadyUnlockArchive4;

		// Token: 0x0400129D RID: 4765
		private MenuOnOff menuOnOff;

		// Token: 0x0400129E RID: 4766
		public int skeltonPlayers;

		// Token: 0x0400129F RID: 4767
		private PlayerStatus playerStatus;

		// Token: 0x040012A0 RID: 4768
		private PhotonView myPV;

		// Token: 0x040012A1 RID: 4769
		public GameObject targetPlayer;

		// Token: 0x040012A2 RID: 4770
		private BGMWorks bgmWorks;

		// Token: 0x040012A3 RID: 4771
		public int bossBGM;

		// Token: 0x040012A4 RID: 4772
		public int score;

		// Token: 0x040012A5 RID: 4773
		private PlayerSpwan playerSpawn;

		// Token: 0x040012A6 RID: 4774
		public bool check;

		// Token: 0x040012A7 RID: 4775
		public CVSounds cVSounds;

		// Token: 0x040012A8 RID: 4776
		public GameObject lastDMG;

		// Token: 0x040012A9 RID: 4777
		public Door1TimeLag door1;

		// Token: 0x040012AA RID: 4778
		public Door1TimeLag door2;

		// Token: 0x040012AB RID: 4779
		public int boxLevel;

		// Token: 0x040012AC RID: 4780
		private CameraController cameraCtrl;

		// Token: 0x040012AD RID: 4781
		private MeshRenderer meshRen;

		// Token: 0x040012AE RID: 4782
		private ParticleSystem pS;

		// Token: 0x040012AF RID: 4783
		public GameObject beamParent;

		// Token: 0x040012B0 RID: 4784
		public LineRenderer beamLine;

		// Token: 0x040012B1 RID: 4785
		public float beamShotTimer;

		// Token: 0x040012B2 RID: 4786
		public float beamWidth;

		// Token: 0x040012B3 RID: 4787
		public bool canShotBeam;

		// Token: 0x040012B4 RID: 4788
		public int beamState;

		// Token: 0x040012B5 RID: 4789
		private InstantiateManager instantiateManager;

		// Token: 0x020001FF RID: 511
		public enum ENEMYAISTS
		{
			// Token: 0x040012B7 RID: 4791
			SLEAP,
			// Token: 0x040012B8 RID: 4792
			WAKE,
			// Token: 0x040012B9 RID: 4793
			STAY,
			// Token: 0x040012BA RID: 4794
			WAIT,
			// Token: 0x040012BB RID: 4795
			WALKFORWARD,
			// Token: 0x040012BC RID: 4796
			WALKBACK,
			// Token: 0x040012BD RID: 4797
			TURN,
			// Token: 0x040012BE RID: 4798
			RETURNTODOGPILE,
			// Token: 0x040012BF RID: 4799
			SLIDEATK,
			// Token: 0x040012C0 RID: 4800
			BEAMDOWN,
			// Token: 0x040012C1 RID: 4801
			BEAMMIDDLE,
			// Token: 0x040012C2 RID: 4802
			BEAMUP,
			// Token: 0x040012C3 RID: 4803
			GOFALL,
			// Token: 0x040012C4 RID: 4804
			INHALE,
			// Token: 0x040012C5 RID: 4805
			INTESTINE,
			// Token: 0x040012C6 RID: 4806
			DEAD
		}
	}
}
