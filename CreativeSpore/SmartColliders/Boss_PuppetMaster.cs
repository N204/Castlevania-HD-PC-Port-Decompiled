using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000240 RID: 576
	public class Boss_PuppetMaster : EnemyMain
	{
		// Token: 0x0600102E RID: 4142 RVA: 0x000AF4BC File Offset: 0x000AD6BC
		protected override void Awake()
		{
			base.Awake();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.mesh = base.transform.Find("TargetText").GetComponent<MeshRenderer>();
			this.cameraCtrl = GameObject.Find("MainCamera").GetComponent<CameraController>();
			this.cameraCtrl.bossTargetText = this.mesh;
			if (this.chestPos == null)
			{
				this.chestPos = GameObject.Find("ChestPos").transform;
			}
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
			this.targetIronMaidenList = new List<IronMaiden>();
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x000AF56C File Offset: 0x000AD76C
		private void Start()
		{
			this.boxWork = GameObject.Find("Stage/Stage02/StageBase/Stage1/Object/BoxWork").GetComponent<BoxWork>();
			this.ironMaiden = this.boxWork.ironMaiden;
			foreach (IronMaiden ironMaiden in this.ironMaiden)
			{
				if (ironMaiden.gameObject.name == "IronMaidenRight")
				{
					this.targetIronMaiden = ironMaiden;
					this.movePos = new Vector2(base.transform.position.x, base.transform.position.y);
				}
			}
			int stageDifficult = this.playerStatus.stageDifficult;
			if (stageDifficult != 1)
			{
				if (stageDifficult != 2)
				{
					if (stageDifficult == 3)
					{
						this.rangeWeaponATK1 *= 8f;
					}
				}
				else
				{
					this.rangeWeaponATK1 *= 5f;
				}
			}
			else
			{
				this.rangeWeaponATK1 *= 2f;
			}
			this.startHp = this.enemyBody.hp;
			this.targetPlayer = GameObject.FindGameObjectWithTag("Player");
			this.myPV = base.GetComponent<PhotonView>();
			this.eCV = base.GetComponent<EnemySoundEffect>();
			this.eSE = base.transform.Find("SoundEffect").GetComponent<EnemySoundEffect>();
			this.targetAnim = GameObject.Find("Canvas_UI/Archive").GetComponent<Animator>();
			this.targetText = GameObject.Find("Canvas_UI/Archive/ArchiveText").GetComponent<Text>();
			this.targetImage = GameObject.Find("Canvas_UI/Archive/UnLockImage").GetComponent<Image>();
			this.menuOnOff = GameObject.Find("Canvas_UI").GetComponent<MenuOnOff>();
			this.bgmWorks = GameObject.Find("Stage/Stage_UI/BGM").GetComponent<BGMWorks>();
			this.playerSpawn = GameObject.Find("StageNetwork").GetComponent<PlayerSpwan>();
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
			int int4 = PlayerPrefs.GetInt("Hard2_Clear");
			if (int4 > 0)
			{
				this.alreadyUnlockArchive4 = true;
			}
			this.bossBGM = PlayerPrefs.GetInt("BGMBoss02");
			if (this.bossBGM == 0)
			{
				this.bossBGM = 1;
			}
			int stageDifficult2 = this.playerStatus.stageDifficult;
			if (stageDifficult2 != 2)
			{
				if (stageDifficult2 == 3)
				{
					this.speed *= 2f;
				}
			}
			else
			{
				this.speed *= 1.5f;
			}
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x000AF830 File Offset: 0x000ADA30
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.transform.parent != null)
			{
				this.lastDMG = other.transform.parent.gameObject;
			}
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x000AF860 File Offset: 0x000ADA60
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (this.activeAI && !this.deadCheck && !this.MyBodyCol.activeSelf)
			{
				this.MyBodyCol.SetActive(true);
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
			if (!this.deadCheck && this.playerSpawn.endGame && !this.cvCheck)
			{
				this.CVCall(8);
				this.cvCheck = true;
			}
			if (this.playerSpawn.startLevel && !this.check2)
			{
				this.animator.SetTrigger("Spawn");
				this.animator.SetBool("Eye", true);
				this.check2 = true;
			}
			if (base.GetComponent<Rigidbody2D>() != null && base.GetComponent<Rigidbody2D>().velocity.y < -7f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, -7f);
			}
			if (this.playerStatus == null)
			{
				this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			}
			if (this.playerStatus != null && this.playerSpawn.startLevel && !this.check && PhotonNetwork.isMasterClient)
			{
				this.lang = this.playerStatus.language;
				this.lang2 = UnityEngine.Random.Range(1, 3);
				this.myPV.RPC("ReciveSetLanguage", PhotonTargets.Others, new object[]
				{
					this.lang,
					this.lang2
				});
				this.check = true;
			}
			int stageDifficult = this.playerStatus.stageDifficult;
			if (stageDifficult != 1)
			{
				if (stageDifficult != 2)
				{
					if (stageDifficult == 3)
					{
						if (this.puppet.dmgCount >= 8 && this.puppet.gameObject.activeSelf)
						{
							this.myPV.RPC("RecivePuppetOff", PhotonTargets.Others, new object[0]);
							this.puppet.gameObject.SetActive(false);
							this.puppet.dmgCount = 0;
							this.puppet.timer = 0f;
							this.puppet.canDMG = false;
						}
					}
				}
				else if (this.puppet.dmgCount >= 6 && this.puppet.gameObject.activeSelf)
				{
					this.myPV.RPC("RecivePuppetOff", PhotonTargets.Others, new object[0]);
					this.puppet.gameObject.SetActive(false);
					this.puppet.dmgCount = 0;
					this.puppet.timer = 0f;
					this.puppet.canDMG = false;
				}
			}
			else if (this.puppet.dmgCount >= 4 && this.puppet.gameObject.activeSelf)
			{
				this.myPV.RPC("RecivePuppetOff", PhotonTargets.Others, new object[0]);
				this.puppet.gameObject.SetActive(false);
				this.puppet.dmgCount = 0;
				this.puppet.timer = 0f;
				this.puppet.canDMG = false;
			}
			if (currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_MoveLeftDown || currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_MoveLeftUp || currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_MoveRightDown || currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_MoveRightUp)
			{
				if (!this.InTargetPositionCheck(this.movePos, 0.05f))
				{
					base.transform.position = Vector2.MoveTowards(base.transform.position, this.movePos, this.speed * Time.deltaTime);
				}
				else if (this.InTargetPositionCheck(this.movePos, 0.05f))
				{
					this.inPotision = true;
					if (this.animator.GetBool("Move_RightUp"))
					{
						this.animator.SetBool("Move_RightUp", false);
					}
					if (this.animator.GetBool("Move_RightDown"))
					{
						this.animator.SetBool("Move_RightDown", false);
					}
					if (this.animator.GetBool("Move_LeftUp"))
					{
						this.animator.SetBool("Move_LeftUp", false);
					}
					if (this.animator.GetBool("Move_LeftDown"))
					{
						this.animator.SetBool("Move_LeftDown", false);
					}
				}
			}
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x000AFE78 File Offset: 0x000AE078
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (PhotonNetwork.isMasterClient && this.playerSpawn.startLevel && this.targetPlayer == null)
			{
				this.targetPlayer = GameObject.FindGameObjectWithTag("Player");
				int num = this.ReturnTargetNumber(this.targetPlayer.name);
				this.myPV.RPC("ReciveTarget", PhotonTargets.Others, new object[]
				{
					num
				});
			}
			if (PhotonNetwork.isMasterClient && this.activeAI && this.targetPlayer == null)
			{
				this.targetPlayer = this.serchTag(base.gameObject, "Player");
				int num2 = this.ReturnTargetNumber(this.targetPlayer.name);
				this.myPV.RPC("ReciveTarget", PhotonTargets.Others, new object[]
				{
					num2
				});
			}
			if (PhotonNetwork.isMasterClient && this.activeAI)
			{
				this.searchTargetTimer += Time.deltaTime;
				if (this.searchTargetTimer > 10f)
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
			if (currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_PuppetRight || currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_PuppetLeft)
			{
				if (currentAnimatorStateInfo.normalizedTime > 1f)
				{
					this.animator.SetBool("PuppetRight", false);
					this.animator.SetBool("PuppetLeft", false);
				}
				if ((currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_PuppetRight || currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_PuppetLeft) && this.targetIronMaiden.onTheBox && this.puppet.gameObject.activeSelf)
				{
					this.myPV.RPC("RecivePuppetOff", PhotonTargets.Others, new object[0]);
					this.puppet.gameObject.SetActive(false);
					this.puppet.dmgCount = 0;
					this.puppet.timer = 0f;
					this.puppet.canDMG = false;
				}
				if (currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_PuppetRight)
				{
					if (this.targetIronMaiden.closed && this.puppet.gameObject.activeSelf)
					{
						this.myPV.RPC("RecivePuppetOff", PhotonTargets.Others, new object[0]);
						this.puppet.gameObject.SetActive(false);
						this.puppet.dmgCount = 0;
						this.puppet.timer = 0f;
						this.puppet.canDMG = false;
					}
				}
				else if (currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_PuppetLeft)
				{
					foreach (IronMaiden ironMaiden in this.ironMaiden)
					{
						if (ironMaiden.gameObject.name == "IronMaidenLeft" && ironMaiden.closed && this.puppet.gameObject.activeSelf)
						{
							this.myPV.RPC("RecivePuppetOff", PhotonTargets.Others, new object[0]);
							this.puppet.gameObject.SetActive(false);
							this.puppet.dmgCount = 0;
							this.puppet.timer = 0f;
							this.puppet.canDMG = false;
						}
					}
				}
			}
			if (this.BeginEnemyCommonWork() && PhotonNetwork.isMasterClient && this.activeAI)
			{
				this.FixedUpdateAI();
				this.EndEnemyCommonWork();
			}
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x000B0294 File Offset: 0x000AE494
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

		// Token: 0x06001034 RID: 4148 RVA: 0x000B0304 File Offset: 0x000AE504
		public void EndEnemyCommonWork()
		{
			float num = Time.fixedTime - this.aiActionTimeStart;
			if (num > this.aiActionTimeLength)
			{
				this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.WAIT;
			}
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x000B0334 File Offset: 0x000AE534
		public bool CheckAction()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			return currentAnimatorStateInfo.fullPathHash != Boss_PuppetMaster.ANISTS_Dead && currentAnimatorStateInfo.fullPathHash != Boss_PuppetMaster.ANISTS_PuppetLeft && currentAnimatorStateInfo.fullPathHash != Boss_PuppetMaster.ANISTS_PuppetRight;
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x000B0384 File Offset: 0x000AE584
		private void FixedUpdateAI()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if ((this.enemyAists == Boss_PuppetMaster.ENEMYAISTS.PUPPETLEFT || this.enemyAists == Boss_PuppetMaster.ENEMYAISTS.PUPPETRIGHT || this.enemyAists == Boss_PuppetMaster.ENEMYAISTS.RANGEATK) && currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_Idle)
			{
				this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.WAIT;
			}
			if (this.activeAI && this.canAI)
			{
				if (this.inPotision)
				{
					if (this.targetIronMaiden.name == "IronMaidenRight")
					{
						int num = this.SelectRandomAIState();
						if (num < 25)
						{
							if (!this.targetIronMaiden.onTheBox)
							{
								this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.PUPPETRIGHT;
							}
							else if (this.targetIronMaiden.onTheBox)
							{
								this.GetTargetIronMaiden();
								this.canAI = false;
								this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.WAIT;
							}
						}
						else if (num < 50)
						{
							if (!this.targetIronMaiden.onTheBox)
							{
								this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.PUPPETLEFT;
							}
							else if (this.targetIronMaiden.onTheBox)
							{
								this.GetTargetIronMaiden();
								this.canAI = false;
								this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.WAIT;
							}
						}
						else if (num < 90)
						{
							this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.RANGEATK;
							this.myPV.RPC("ReciveGoFire", PhotonTargets.Others, new object[0]);
						}
						else if (num <= 100)
						{
							this.GetTargetIronMaiden();
							this.canAI = false;
							this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.WAIT;
						}
					}
					else
					{
						int num2 = this.SelectRandomAIState();
						if (num2 < 50)
						{
							if (!this.targetIronMaiden.onTheBox)
							{
								this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.PUPPETRIGHT;
							}
							else if (this.targetIronMaiden.onTheBox)
							{
								this.GetTargetIronMaiden();
								this.canAI = false;
								this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.WAIT;
							}
						}
						else if (num2 < 90)
						{
							this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.RANGEATK;
							this.myPV.RPC("ReciveGoFire", PhotonTargets.Others, new object[0]);
						}
						else if (num2 <= 100)
						{
							this.GetTargetIronMaiden();
							this.canAI = false;
							this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.WAIT;
						}
					}
				}
				else if (!this.inPotision)
				{
					int num3 = this.SelectRandomAIState();
					if (num3 < 40)
					{
						this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.RANGEATK;
						this.myPV.RPC("ReciveGoFire", PhotonTargets.Others, new object[0]);
					}
					else if (num3 <= 100)
					{
						this.canAI = false;
						this.enemyAists = Boss_PuppetMaster.ENEMYAISTS.WAIT;
					}
				}
			}
			switch (this.enemyAists)
			{
			case Boss_PuppetMaster.ENEMYAISTS.WAIT:
				this.timetest2 += Time.deltaTime;
				if (this.timetest2 > UnityEngine.Random.Range(this.waitTimeMin, this.waitTimeMax))
				{
					this.canAI = true;
					this.timetest2 = 0f;
				}
				break;
			case Boss_PuppetMaster.ENEMYAISTS.PUPPETRIGHT:
				if (!this.animator.GetBool("PuppetRight"))
				{
					this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
					{
						1
					});
					this.animator.SetBool("PuppetRight", true);
				}
				this.canAI = false;
				break;
			case Boss_PuppetMaster.ENEMYAISTS.PUPPETLEFT:
				if (!this.animator.GetBool("PuppetLeft"))
				{
					this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
					{
						2
					});
					this.animator.SetBool("PuppetLeft", true);
				}
				this.canAI = false;
				break;
			case Boss_PuppetMaster.ENEMYAISTS.RANGEATK:
				this.GoFire();
				this.canAI = false;
				break;
			}
		}

		// Token: 0x06001037 RID: 4151 RVA: 0x000B0714 File Offset: 0x000AE914
		private void GetTargetIronMaiden()
		{
			foreach (IronMaiden ironMaiden in this.ironMaiden)
			{
				if (ironMaiden.gameObject.name != "IronMaidenLeft" && !ironMaiden.onTheBox)
				{
					this.targetIronMaidenList.Add(ironMaiden);
				}
			}
			Debug.Log(this.targetIronMaidenList);
			IronMaiden ironMaiden2 = this.targetIronMaidenList[UnityEngine.Random.Range(0, this.targetIronMaidenList.Count)];
			this.targetIronMaiden = ironMaiden2;
			Debug.Log(ironMaiden2.name);
			this.movePos = new Vector2(this.targetIronMaiden.transform.position.x - 1.5f, this.targetIronMaiden.transform.position.y + 2.2f);
			int num = 0;
			string name = ironMaiden2.name;
			switch (name)
			{
			case "IronMaiden01":
				num = 1;
				break;
			case "IronMaiden02":
				num = 2;
				break;
			case "IronMaiden03":
				num = 3;
				break;
			case "IronMaiden04":
				num = 4;
				break;
			case "IronMaiden05":
				num = 5;
				break;
			case "IronMaiden06":
				num = 6;
				break;
			case "IronMaiden07":
				num = 7;
				break;
			case "IronMaidenRight":
				num = 8;
				break;
			}
			this.myPV.RPC("ReciveIronMaiden", PhotonTargets.Others, new object[]
			{
				num
			});
			if (this.targetIronMaiden.transform.position.x > base.transform.position.x)
			{
				if (this.targetIronMaiden.transform.position.y > base.transform.position.y)
				{
					if (!this.animator.GetBool("Move_RightUp"))
					{
						this.animator.SetBool("Move_RightUp", true);
					}
				}
				else if (this.targetIronMaiden.transform.position.y < base.transform.position.y && !this.animator.GetBool("Move_RightDown"))
				{
					this.animator.SetBool("Move_RightDown", true);
				}
			}
			else if (this.targetIronMaiden.transform.position.x < base.transform.position.x)
			{
				if (this.targetIronMaiden.transform.position.y > base.transform.position.y)
				{
					if (!this.animator.GetBool("Move_LeftUp"))
					{
						this.animator.SetBool("Move_LeftUp", true);
					}
				}
				else if (this.targetIronMaiden.transform.position.y < base.transform.position.y && !this.animator.GetBool("Move_LeftDown"))
				{
					this.animator.SetBool("Move_LeftDown", true);
				}
			}
			this.CVCall(5);
			this.inPotision = false;
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x000B0B08 File Offset: 0x000AED08
		public void EnemyKillsCountPlus()
		{
			this.menuOnOff.enemyKills++;
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x000B0B20 File Offset: 0x000AED20
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
				PlayerPrefs.SetInt("Hard2_Clear", 1);
				this.alreadyUnlockArchive4 = true;
			}
			if (this.enemyBody.ownATKHitted)
			{
				this.playerStatus.data_PuppetMaster++;
				this.playerStatus.score += this.score;
				this.playerStatus.killCount++;
				this.playerStatus.killCountAll++;
			}
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x000B1078 File Offset: 0x000AF278
		public void Dead()
		{
			this.cVSounds = GameObject.FindGameObjectWithTag("Player").GetComponent<CVSounds>();
			this.cVSounds.KillBoss();
			this.animator.SetBool("Eye", false);
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
							this.instantiateManager.PlayerSoulRed(base.transform.position.x, base.transform.position.y + 0.5f, gameObject, component2, "パペットマスター");
						}
					}
				}
			}
			if (PhotonNetwork.isMasterClient)
			{
				base.Invoke("AppearChestBox", 3f);
			}
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x000B1198 File Offset: 0x000AF398
		public void AppearChestBox()
		{
			GameObject gameObject = PhotonNetwork.Instantiate("Chest_Gold", new Vector3(this.chestPos.position.x, this.chestPos.position.y, 0f), Quaternion.identity, 0);
			ItemsChest component = gameObject.GetComponent<ItemsChest>();
			component.boxLevel = this.playerStatus.stageDifficult;
			ChestGold component2 = gameObject.GetComponent<ChestGold>();
			component2.returnLobbyTime = this.returnLobbyTime;
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x00097E10 File Offset: 0x00096010
		public int SelectRandomAIState()
		{
			return UnityEngine.Random.Range(0, 100);
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x000B1213 File Offset: 0x000AF413
		public void SetAIState(Boss_PuppetMaster.ENEMYAISTS sts, float t)
		{
			this.aiActionTimeStart = Time.fixedTime;
			this.aiActionTimeLength = t;
			this.enemyAists = sts;
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x000B1230 File Offset: 0x000AF430
		public float GetDistancePlayer()
		{
			float num = base.transform.position.x - this.targetPlayer.transform.position.x;
			if (num < 0f)
			{
				num *= -1f;
			}
			return num;
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x000B1280 File Offset: 0x000AF480
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

		// Token: 0x06001040 RID: 4160 RVA: 0x000B12A2 File Offset: 0x000AF4A2
		public void GoFire()
		{
			this.animator.SetTrigger("OpenMouth");
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x000B12B4 File Offset: 0x000AF4B4
		public void PuppetBomb(int type)
		{
			this.instantiateManager.EnemyPuppetBomb(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, type, this.targetPlayer, this.speed);
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x000B1310 File Offset: 0x000AF510
		public void PuppetActive()
		{
			this.puppet.gameObject.SetActive(true);
			this.puppet.dmgCount = 0;
			this.puppet.timer = 0f;
			this.puppet.canDMG = false;
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x000B134C File Offset: 0x000AF54C
		public void GoExcute()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (this.puppet.gameObject.activeSelf)
			{
				this.CVCall(6);
				this.puppet.gameObject.SetActive(false);
				this.puppet.dmgCount = 0;
				this.puppet.timer = 0f;
				this.puppet.canDMG = false;
				PhotonView component = this.targetPlayer.GetComponent<PhotonView>();
				if (component.isMine)
				{
					BoxCollider2D component2 = component.transform.Find("Collider_Body").GetComponent<BoxCollider2D>();
					if (component2.enabled)
					{
						if (this.targetIronMaiden == null)
						{
							foreach (IronMaiden ironMaiden in this.ironMaiden)
							{
								if (currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_PuppetRight)
								{
									if (ironMaiden.gameObject.name == "IronMaidenRight")
									{
										this.targetIronMaiden = ironMaiden;
									}
								}
								else if (currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_PuppetLeft && ironMaiden.gameObject.name == "IronMaidenLeft")
								{
									this.targetIronMaiden = ironMaiden;
								}
							}
						}
						else if (this.targetIronMaiden != null)
						{
							if (currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_PuppetLeft)
							{
								if (this.targetIronMaiden.name != "IronMaidenLeft")
								{
									foreach (IronMaiden ironMaiden2 in this.ironMaiden)
									{
										if (ironMaiden2.name == "IronMaidenLeft")
										{
											this.targetIronMaiden = ironMaiden2;
										}
									}
								}
							}
							else if (currentAnimatorStateInfo.fullPathHash == Boss_PuppetMaster.ANISTS_PuppetRight && this.targetIronMaiden.name == "IronMaidenLeft")
							{
								foreach (IronMaiden ironMaiden3 in this.ironMaiden)
								{
									if (ironMaiden3.name == "IronMaidenRight")
									{
										this.targetIronMaiden = ironMaiden3;
									}
								}
							}
						}
						this.targetIronMaiden.CloseActionClient();
						this.targetRectCol = component.GetComponent<SmartRectCollider2D>();
						this.targetRectCol.enabled = false;
						if (component.GetComponent<PlayerController>() != null)
						{
							PlayerController component3 = component.GetComponent<PlayerController>();
							component3.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Shanoa>() != null)
						{
							PlayerController_Shanoa component4 = component.GetComponent<PlayerController_Shanoa>();
							component4.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Jonathan>() != null)
						{
							PlayerController_Jonathan component5 = component.GetComponent<PlayerController_Jonathan>();
							component5.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Charotte>() != null)
						{
							PlayerController_Charotte component6 = component.GetComponent<PlayerController_Charotte>();
							component6.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Albus>() != null)
						{
							PlayerController_Albus component7 = component.GetComponent<PlayerController_Albus>();
							component7.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Soma>() != null)
						{
							PlayerController_Soma component8 = component.GetComponent<PlayerController_Soma>();
							component8.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Alucard>() != null)
						{
							PlayerController_Alucard component9 = component.GetComponent<PlayerController_Alucard>();
							component9.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Julius>() != null)
						{
							PlayerController_Julius component10 = component.GetComponent<PlayerController_Julius>();
							component10.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Yoko>() != null)
						{
							PlayerController_Yoko component11 = component.GetComponent<PlayerController_Yoko>();
							component11.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Maria>() != null)
						{
							PlayerController_Maria component12 = component.GetComponent<PlayerController_Maria>();
							component12.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Simon>() != null)
						{
							PlayerController_Simon component13 = component.GetComponent<PlayerController_Simon>();
							component13.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Fuma>() != null)
						{
							PlayerController_Fuma component14 = component.GetComponent<PlayerController_Fuma>();
							component14.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Add1>() != null)
						{
							PlayerController_Add1 component15 = component.GetComponent<PlayerController_Add1>();
							component15.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Add2>() != null)
						{
							PlayerController_Add2 component16 = component.GetComponent<PlayerController_Add2>();
							component16.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Add3>() != null)
						{
							PlayerController_Add3 component17 = component.GetComponent<PlayerController_Add3>();
							component17.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Add4>() != null)
						{
							PlayerController_Add4 component18 = component.GetComponent<PlayerController_Add4>();
							component18.IronMaidenAction(this.targetIronMaiden.level);
						}
						if (component.GetComponent<PlayerController_Add5>() != null)
						{
							PlayerController_Add5 component19 = component.GetComponent<PlayerController_Add5>();
							component19.IronMaidenAction(this.targetIronMaiden.level);
						}
						component.gameObject.transform.position = new Vector2(this.targetIronMaiden.transform.position.x, this.targetIronMaiden.transform.position.y + 0.35f);
						base.Invoke("ReturnCol", 0.1f);
					}
				}
			}
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x000B18F1 File Offset: 0x000AFAF1
		private void ReturnCol()
		{
			this.targetRectCol.enabled = true;
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x000B1900 File Offset: 0x000AFB00
		public void CVCall(int num)
		{
			int num2 = this.lang;
			if (num2 != 0)
			{
				if (num2 == 1)
				{
					switch (num)
					{
					case 1:
					{
						int num3 = this.lang2;
						if (num3 != 1)
						{
							if (num3 == 2)
							{
								this.eCV.SoundEffectPlay(3);
							}
						}
						else
						{
							this.eCV.SoundEffectPlay(1);
						}
						break;
					}
					case 2:
						this.eCV.SoundEffectPlay(5);
						break;
					case 3:
						this.eCV.SoundEffectPlay(7);
						break;
					case 4:
						this.eCV.SoundEffectPlay(9);
						break;
					case 5:
						this.eCV.SoundEffectPlay(11);
						break;
					case 6:
						this.eCV.SoundEffectPlay(13);
						break;
					case 7:
						this.eCV.SoundEffectPlay(15);
						break;
					case 8:
						this.eCV.SoundEffectPlay(17);
						break;
					}
				}
			}
			else
			{
				switch (num)
				{
				case 1:
				{
					int num4 = this.lang2;
					if (num4 != 1)
					{
						if (num4 == 2)
						{
							this.eCV.SoundEffectPlay(2);
						}
					}
					else
					{
						this.eCV.SoundEffectPlay(0);
					}
					break;
				}
				case 2:
					this.eCV.SoundEffectPlay(4);
					break;
				case 3:
					this.eCV.SoundEffectPlay(6);
					break;
				case 4:
					this.eCV.SoundEffectPlay(8);
					break;
				case 5:
					this.eCV.SoundEffectPlay(10);
					break;
				case 6:
					this.eCV.SoundEffectPlay(12);
					break;
				case 7:
					this.eCV.SoundEffectPlay(14);
					break;
				case 8:
					this.eCV.SoundEffectPlay(16);
					break;
				}
			}
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x000B1B03 File Offset: 0x000AFD03
		public void SoundEffectCall(int num)
		{
			this.eSE.SoundEffectPlay(num);
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x000B1B14 File Offset: 0x000AFD14
		public void VelocityX(float Vx)
		{
			if (base.transform.localScale.x > 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(Vx, base.GetComponent<Rigidbody2D>().velocity.y);
			}
			else if (base.transform.localScale.x < 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f * Vx, base.GetComponent<Rigidbody2D>().velocity.y);
			}
		}

		// Token: 0x06001048 RID: 4168 RVA: 0x000B1BB0 File Offset: 0x000AFDB0
		public void VelocityY(float Vy)
		{
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, Vy);
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x000B1BE4 File Offset: 0x000AFDE4
		public void InstanceDust()
		{
			int i = 1;
			while (i <= 30)
			{
				int num = UnityEngine.Random.Range(0, 10);
				if (num < 5)
				{
					this.instantiateManager.Dust(base.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f), base.transform.position.y + UnityEngine.Random.Range(-0.5f, 0.5f));
					i++;
				}
				else if (num >= 5)
				{
					this.instantiateManager.Dust2(base.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f), base.transform.position.y + UnityEngine.Random.Range(-0.5f, 0.5f));
					i++;
				}
			}
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x000B1CCC File Offset: 0x000AFECC
		[PunRPC]
		private void ReciveState(int val)
		{
			if (val != 1)
			{
				if (val == 2)
				{
					if (!this.animator.GetBool("PuppetLeft"))
					{
						this.animator.SetBool("PuppetLeft", true);
					}
				}
			}
			else if (!this.animator.GetBool("PuppetRight"))
			{
				this.animator.SetBool("PuppetRight", true);
			}
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x000B1D44 File Offset: 0x000AFF44
		[PunRPC]
		private void RecivePuppetOff()
		{
			if (this.puppet.gameObject.activeSelf)
			{
				this.puppet.gameObject.SetActive(false);
				this.puppet.dmgCount = 0;
				this.puppet.timer = 0f;
				this.puppet.canDMG = false;
			}
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x000B1D9F File Offset: 0x000AFF9F
		[PunRPC]
		private void ReciveTarget(int num)
		{
			this.targetPlayer = GameObject.Find(this.ReturnTargetName(num));
		}

		// Token: 0x0600104D RID: 4173 RVA: 0x000B1DB4 File Offset: 0x000AFFB4
		[PunRPC]
		private void ReciveIronMaiden(int val)
		{
			switch (val)
			{
			case 1:
				foreach (IronMaiden ironMaiden in this.ironMaiden)
				{
					if (ironMaiden.name == "IronMaiden01")
					{
						this.targetIronMaiden = ironMaiden;
					}
				}
				break;
			case 2:
				foreach (IronMaiden ironMaiden2 in this.ironMaiden)
				{
					if (ironMaiden2.name == "IronMaiden02")
					{
						this.targetIronMaiden = ironMaiden2;
					}
				}
				break;
			case 3:
				foreach (IronMaiden ironMaiden3 in this.ironMaiden)
				{
					if (ironMaiden3.name == "IronMaiden03")
					{
						this.targetIronMaiden = ironMaiden3;
					}
				}
				break;
			case 4:
				foreach (IronMaiden ironMaiden4 in this.ironMaiden)
				{
					if (ironMaiden4.name == "IronMaiden04")
					{
						this.targetIronMaiden = ironMaiden4;
					}
				}
				break;
			case 5:
				foreach (IronMaiden ironMaiden5 in this.ironMaiden)
				{
					if (ironMaiden5.name == "IronMaiden05")
					{
						this.targetIronMaiden = ironMaiden5;
					}
				}
				break;
			case 6:
				foreach (IronMaiden ironMaiden6 in this.ironMaiden)
				{
					if (ironMaiden6.name == "IronMaiden06")
					{
						this.targetIronMaiden = ironMaiden6;
					}
				}
				break;
			case 7:
				foreach (IronMaiden ironMaiden7 in this.ironMaiden)
				{
					if (ironMaiden7.name == "IronMaiden07")
					{
						this.targetIronMaiden = ironMaiden7;
					}
				}
				break;
			case 8:
				foreach (IronMaiden ironMaiden8 in this.ironMaiden)
				{
					if (ironMaiden8.name == "IronMaidenRight")
					{
						this.targetIronMaiden = ironMaiden8;
					}
				}
				break;
			}
			this.movePos = new Vector2(this.targetIronMaiden.transform.position.x - 1.5f, this.targetIronMaiden.transform.position.y + 2.2f);
			if (this.targetIronMaiden.transform.position.x > base.transform.position.x)
			{
				if (this.targetIronMaiden.transform.position.y > base.transform.position.y)
				{
					if (!this.animator.GetBool("Move_RightUp"))
					{
						this.animator.SetBool("Move_RightUp", true);
					}
				}
				else if (this.targetIronMaiden.transform.position.y < base.transform.position.y && !this.animator.GetBool("Move_RightDown"))
				{
					this.animator.SetBool("Move_RightDown", true);
				}
			}
			else if (this.targetIronMaiden.transform.position.x < base.transform.position.x)
			{
				if (this.targetIronMaiden.transform.position.y > base.transform.position.y)
				{
					if (!this.animator.GetBool("Move_LeftUp"))
					{
						this.animator.SetBool("Move_LeftUp", true);
					}
				}
				else if (this.targetIronMaiden.transform.position.y < base.transform.position.y && !this.animator.GetBool("Move_LeftDown"))
				{
					this.animator.SetBool("Move_LeftDown", true);
				}
			}
			this.CVCall(5);
			this.inPotision = false;
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x000B2262 File Offset: 0x000B0462
		[PunRPC]
		private void ReciveGoFire()
		{
			this.GoFire();
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x000B226A File Offset: 0x000B046A
		[PunRPC]
		private void ReciveDead()
		{
			if (!this.deadCheck)
			{
				this.Dead();
				this.deadCheck = true;
			}
		}

		// Token: 0x06001050 RID: 4176 RVA: 0x000B2284 File Offset: 0x000B0484
		[PunRPC]
		private void ReciveSetLanguage(int val, int val2)
		{
			this.lang = val;
			this.lang2 = val2;
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x00098AA0 File Offset: 0x00096CA0
		[PunRPC]
		private void ReciveCurse()
		{
			this.curseTimer = 0f;
			if (!this.curse)
			{
				this.curse = true;
			}
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x00098ABF File Offset: 0x00096CBF
		[PunRPC]
		private void RecivePoison()
		{
			this.poisonTimer = 0f;
			if (!this.poison)
			{
				this.poison = true;
			}
		}

		// Token: 0x040015EC RID: 5612
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.PuppetMaster_Idle");

		// Token: 0x040015ED RID: 5613
		public static readonly int ANISTS_Dead = Animator.StringToHash("Base Layer.PuppetMaster_Dead");

		// Token: 0x040015EE RID: 5614
		public static readonly int ANISTS_PuppetRight = Animator.StringToHash("Base Layer.PuppetMaster_PuppetRight");

		// Token: 0x040015EF RID: 5615
		public static readonly int ANISTS_PuppetLeft = Animator.StringToHash("Base Layer.PuppetMaster_PuppetLeft");

		// Token: 0x040015F0 RID: 5616
		public static readonly int ANISTS_MoveRightUp = Animator.StringToHash("Base Layer.PuppetMaster_MoveRightUp");

		// Token: 0x040015F1 RID: 5617
		public static readonly int ANISTS_MoveRightDown = Animator.StringToHash("Base Layer.PuppetMaster_MoveRightDown");

		// Token: 0x040015F2 RID: 5618
		public static readonly int ANISTS_MoveLeftUp = Animator.StringToHash("Base Layer.PuppetMaster_MoveLeftUp");

		// Token: 0x040015F3 RID: 5619
		public static readonly int ANISTS_MoveLeftDown = Animator.StringToHash("Base Layer.PuppetMaster_MoveLeftDown");

		// Token: 0x040015F4 RID: 5620
		protected float aiActionTimeLength;

		// Token: 0x040015F5 RID: 5621
		protected float aiActionTimeStart;

		// Token: 0x040015F6 RID: 5622
		public Boss_PuppetMaster.ENEMYAISTS enemyAists;

		// Token: 0x040015F7 RID: 5623
		public float speed = 0.4f;

		// Token: 0x040015F8 RID: 5624
		public bool activeAI;

		// Token: 0x040015F9 RID: 5625
		public float dogPileReturnLength = 2f;

		// Token: 0x040015FA RID: 5626
		public float ATKActiveLength = 1f;

		// Token: 0x040015FB RID: 5627
		public float specialATKActiveLength = 0.5f;

		// Token: 0x040015FC RID: 5628
		public float timetest2;

		// Token: 0x040015FD RID: 5629
		public float waitTimeMin = 3f;

		// Token: 0x040015FE RID: 5630
		public float waitTimeMax = 4f;

		// Token: 0x040015FF RID: 5631
		public float searchTargetTimer;

		// Token: 0x04001600 RID: 5632
		public float startHp;

		// Token: 0x04001601 RID: 5633
		public bool canAI;

		// Token: 0x04001602 RID: 5634
		public bool check;

		// Token: 0x04001603 RID: 5635
		public bool deadCheck;

		// Token: 0x04001604 RID: 5636
		public bool bgmCheck;

		// Token: 0x04001605 RID: 5637
		public EnemyBody enemyBody;

		// Token: 0x04001606 RID: 5638
		private GameObject[] allPlayer;

		// Token: 0x04001607 RID: 5639
		public Transform chestPos;

		// Token: 0x04001608 RID: 5640
		public GameObject dustPrefab1;

		// Token: 0x04001609 RID: 5641
		public GameObject dustPrefab2;

		// Token: 0x0400160A RID: 5642
		private EnemySoundEffect eCV;

		// Token: 0x0400160B RID: 5643
		private EnemySoundEffect eSE;

		// Token: 0x0400160C RID: 5644
		private Animator targetAnim;

		// Token: 0x0400160D RID: 5645
		private Text targetText;

		// Token: 0x0400160E RID: 5646
		private Image targetImage;

		// Token: 0x0400160F RID: 5647
		public Sprite archiveSprite;

		// Token: 0x04001610 RID: 5648
		public Sprite archiveSprite2;

		// Token: 0x04001611 RID: 5649
		public Sprite archiveSprite3;

		// Token: 0x04001612 RID: 5650
		public bool alreadyUnlockArchive;

		// Token: 0x04001613 RID: 5651
		public bool alreadyUnlockArchive2;

		// Token: 0x04001614 RID: 5652
		public bool alreadyUnlockArchive3;

		// Token: 0x04001615 RID: 5653
		public bool alreadyUnlockArchive4;

		// Token: 0x04001616 RID: 5654
		private MenuOnOff menuOnOff;

		// Token: 0x04001617 RID: 5655
		public int skeltonPlayers;

		// Token: 0x04001618 RID: 5656
		public PlayerStatus playerStatus;

		// Token: 0x04001619 RID: 5657
		private PhotonView myPV;

		// Token: 0x0400161A RID: 5658
		public GameObject targetPlayer;

		// Token: 0x0400161B RID: 5659
		private BGMWorks bgmWorks;

		// Token: 0x0400161C RID: 5660
		public int bossBGM;

		// Token: 0x0400161D RID: 5661
		public int score;

		// Token: 0x0400161E RID: 5662
		public PlayerSpwan playerSpawn;

		// Token: 0x0400161F RID: 5663
		public GameObject MyBodyCol;

		// Token: 0x04001620 RID: 5664
		public int lang;

		// Token: 0x04001621 RID: 5665
		public int lang2;

		// Token: 0x04001622 RID: 5666
		public CVSounds cVSounds;

		// Token: 0x04001623 RID: 5667
		public GameObject lastDMG;

		// Token: 0x04001624 RID: 5668
		public Transform muzzle;

		// Token: 0x04001625 RID: 5669
		public float rangeWeaponATK1;

		// Token: 0x04001626 RID: 5670
		public int boxLevel;

		// Token: 0x04001627 RID: 5671
		public float returnLobbyTime;

		// Token: 0x04001628 RID: 5672
		private MeshRenderer mesh;

		// Token: 0x04001629 RID: 5673
		private CameraController cameraCtrl;

		// Token: 0x0400162A RID: 5674
		public InstantiateManager instantiateManager;

		// Token: 0x0400162B RID: 5675
		public IronMaiden[] ironMaiden;

		// Token: 0x0400162C RID: 5676
		private BoxWork boxWork;

		// Token: 0x0400162D RID: 5677
		public IronMaiden targetIronMaiden;

		// Token: 0x0400162E RID: 5678
		public Puppet puppet;

		// Token: 0x0400162F RID: 5679
		public Vector2 movePos;

		// Token: 0x04001630 RID: 5680
		public bool check2;

		// Token: 0x04001631 RID: 5681
		public bool inPotision = true;

		// Token: 0x04001632 RID: 5682
		public bool cvCheck;

		// Token: 0x04001633 RID: 5683
		private SmartRectCollider2D targetRectCol;

		// Token: 0x04001634 RID: 5684
		private List<IronMaiden> targetIronMaidenList;

		// Token: 0x02000241 RID: 577
		public enum ENEMYAISTS
		{
			// Token: 0x04001637 RID: 5687
			WAIT,
			// Token: 0x04001638 RID: 5688
			PUPPETRIGHT,
			// Token: 0x04001639 RID: 5689
			PUPPETLEFT,
			// Token: 0x0400163A RID: 5690
			RANGEATK
		}
	}
}
