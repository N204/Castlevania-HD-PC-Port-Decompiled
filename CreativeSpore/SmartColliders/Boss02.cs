using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200031B RID: 795
	public class Boss02 : EnemyMain
	{
		// Token: 0x06001941 RID: 6465 RVA: 0x001319F8 File Offset: 0x0012FBF8
		protected override void Awake()
		{
			base.Awake();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.mesh = base.transform.Find("TargetText").GetComponent<MeshRenderer>();
			this.cameraCtrl = GameObject.Find("MainCamera").GetComponent<CameraController>();
			this.cameraCtrl.bossTargetText = this.mesh;
			this.door1 = GameObject.Find("StageBase/Stage1/Object/StepSwitch/Door1").GetComponent<Door1TimeLag>();
			this.door2 = GameObject.Find("StageBase/Stage1/Object/StepSwitch/Door2").GetComponent<Door1TimeLag>();
			this.chestPos = GameObject.Find("ChestPos").transform;
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
		}

		// Token: 0x06001942 RID: 6466 RVA: 0x00131AB8 File Offset: 0x0012FCB8
		private void Start()
		{
			int stageDifficult = this.playerStatus.stageDifficult;
			if (stageDifficult != 1)
			{
				if (stageDifficult != 2)
				{
					if (stageDifficult == 3)
					{
						this.rangeWeaponATK1 *= 8f;
						this.rangeWeaponATK2 *= 8f;
					}
				}
				else
				{
					this.rangeWeaponATK1 *= 5f;
					this.rangeWeaponATK2 *= 5f;
				}
			}
			else
			{
				this.rangeWeaponATK1 *= 2f;
				this.rangeWeaponATK2 *= 2f;
			}
			this.muzzle = base.transform.Find("Muzzle");
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
			this.playerSpite = base.transform.Find("Sprite").gameObject;
			this.bodyCol2d = base.transform.Find("Sprite").GetComponent<BoxCollider2D>();
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
			this.bossBGM = PlayerPrefs.GetInt("BGMBoss12");
			if (this.bossBGM == 0)
			{
				this.bossBGM = 800;
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

		// Token: 0x06001943 RID: 6467 RVA: 0x00131D45 File Offset: 0x0012FF45
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.transform.parent != null)
			{
				this.lastDMG = other.transform.parent.gameObject;
			}
		}

		// Token: 0x06001944 RID: 6468 RVA: 0x00131D74 File Offset: 0x0012FF74
		private void Update()
		{
			if (base.GetComponent<Rigidbody2D>() != null && base.GetComponent<Rigidbody2D>().velocity.y < -7f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, -7f);
			}
			if (this.playerStatus == null)
			{
				this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			}
			if (this.playerStatus != null && this.playerSpawn.startLevel && !this.check3 && PhotonNetwork.isMasterClient)
			{
				this.lang = this.playerStatus.language;
				this.myPV.RPC("ReciveSetLanguage", PhotonTargets.Others, new object[]
				{
					this.lang
				});
				this.check3 = true;
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

		// Token: 0x06001945 RID: 6469 RVA: 0x00131FD8 File Offset: 0x001301D8
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
				if (this.targetPlayer.GetComponent<PlayerController>() != null)
				{
					this.playerCtrl = this.targetPlayer.GetComponent<PlayerController>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Shanoa>() != null)
				{
					this.playerCtrl2 = this.targetPlayer.GetComponent<PlayerController_Shanoa>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Jonathan>() != null)
				{
					this.playerCtrl3 = this.targetPlayer.GetComponent<PlayerController_Jonathan>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Charotte>() != null)
				{
					this.playerCtrl4 = this.targetPlayer.GetComponent<PlayerController_Charotte>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Albus>() != null)
				{
					this.playerCtrl5 = this.targetPlayer.GetComponent<PlayerController_Albus>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Soma>() != null)
				{
					this.playerCtrl6 = this.targetPlayer.GetComponent<PlayerController_Soma>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Alucard>() != null)
				{
					this.playerCtrl7 = this.targetPlayer.GetComponent<PlayerController_Alucard>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Julius>() != null)
				{
					this.playerCtrl8 = this.targetPlayer.GetComponent<PlayerController_Julius>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Yoko>() != null)
				{
					this.playerCtrl9 = this.targetPlayer.GetComponent<PlayerController_Yoko>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Maria>() != null)
				{
					this.playerCtrl10 = this.targetPlayer.GetComponent<PlayerController_Maria>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Simon>() != null)
				{
					this.playerCtrl11 = this.targetPlayer.GetComponent<PlayerController_Simon>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Fuma>() != null)
				{
					this.playerCtrl12 = this.targetPlayer.GetComponent<PlayerController_Fuma>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Add1>() != null)
				{
					this.playerCtrl13 = this.targetPlayer.GetComponent<PlayerController_Add1>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Add2>() != null)
				{
					this.playerCtrl14 = this.targetPlayer.GetComponent<PlayerController_Add2>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Add3>() != null)
				{
					this.playerCtrl15 = this.targetPlayer.GetComponent<PlayerController_Add3>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Add4>() != null)
				{
					this.playerCtrl16 = this.targetPlayer.GetComponent<PlayerController_Add4>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Add5>() != null)
				{
					this.playerCtrl17 = this.targetPlayer.GetComponent<PlayerController_Add5>();
				}
			}
			if (PhotonNetwork.isMasterClient && this.activeAI && this.targetPlayer == null)
			{
				this.targetPlayer = this.serchTag(base.gameObject, "Player");
				int num2 = this.ReturnTargetNumber(this.targetPlayer.name);
				this.myPV.RPC("ReciveTarget", PhotonTargets.Others, new object[]
				{
					num2
				});
				if (this.targetPlayer.GetComponent<PlayerController>() != null)
				{
					this.playerCtrl = this.targetPlayer.GetComponent<PlayerController>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Shanoa>() != null)
				{
					this.playerCtrl2 = this.targetPlayer.GetComponent<PlayerController_Shanoa>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Jonathan>() != null)
				{
					this.playerCtrl3 = this.targetPlayer.GetComponent<PlayerController_Jonathan>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Charotte>() != null)
				{
					this.playerCtrl4 = this.targetPlayer.GetComponent<PlayerController_Charotte>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Albus>() != null)
				{
					this.playerCtrl5 = this.targetPlayer.GetComponent<PlayerController_Albus>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Soma>() != null)
				{
					this.playerCtrl6 = this.targetPlayer.GetComponent<PlayerController_Soma>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Alucard>() != null)
				{
					this.playerCtrl7 = this.targetPlayer.GetComponent<PlayerController_Alucard>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Julius>() != null)
				{
					this.playerCtrl8 = this.targetPlayer.GetComponent<PlayerController_Julius>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Yoko>() != null)
				{
					this.playerCtrl9 = this.targetPlayer.GetComponent<PlayerController_Yoko>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Maria>() != null)
				{
					this.playerCtrl10 = this.targetPlayer.GetComponent<PlayerController_Maria>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Simon>() != null)
				{
					this.playerCtrl11 = this.targetPlayer.GetComponent<PlayerController_Simon>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Fuma>() != null)
				{
					this.playerCtrl12 = this.targetPlayer.GetComponent<PlayerController_Fuma>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Add1>() != null)
				{
					this.playerCtrl13 = this.targetPlayer.GetComponent<PlayerController_Add1>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Add2>() != null)
				{
					this.playerCtrl14 = this.targetPlayer.GetComponent<PlayerController_Add2>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Add3>() != null)
				{
					this.playerCtrl15 = this.targetPlayer.GetComponent<PlayerController_Add3>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Add4>() != null)
				{
					this.playerCtrl16 = this.targetPlayer.GetComponent<PlayerController_Add4>();
				}
				if (this.targetPlayer.GetComponent<PlayerController_Add5>() != null)
				{
					this.playerCtrl17 = this.targetPlayer.GetComponent<PlayerController_Add5>();
				}
			}
			if (this.targetPlayer.GetComponent<PlayerController>() != null)
			{
				if (this.playerCtrl != this.targetPlayer.GetComponent<PlayerController>())
				{
					this.playerCtrl = this.targetPlayer.GetComponent<PlayerController>();
				}
				if (!this.playerCtrl.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl.m_isGrounded)
				{
					if (this.playerCtrl.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl.transform.position.x < this.checkRight.position.x && this.playerCtrl.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Shanoa>() != null)
			{
				if (this.playerCtrl2 != this.targetPlayer.GetComponent<PlayerController_Shanoa>())
				{
					this.playerCtrl2 = this.targetPlayer.GetComponent<PlayerController_Shanoa>();
				}
				if (!this.playerCtrl2.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl2.m_isGrounded)
				{
					if (this.playerCtrl2.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl2.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl2.transform.position.x < this.checkRight.position.x && this.playerCtrl2.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Jonathan>() != null)
			{
				if (this.playerCtrl3 != this.targetPlayer.GetComponent<PlayerController_Jonathan>())
				{
					this.playerCtrl3 = this.targetPlayer.GetComponent<PlayerController_Jonathan>();
				}
				if (!this.playerCtrl3.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl3.m_isGrounded)
				{
					if (this.playerCtrl3.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl3.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl3.transform.position.x < this.checkRight.position.x && this.playerCtrl3.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Charotte>() != null)
			{
				if (this.playerCtrl4 != this.targetPlayer.GetComponent<PlayerController_Charotte>())
				{
					this.playerCtrl4 = this.targetPlayer.GetComponent<PlayerController_Charotte>();
				}
				if (!this.playerCtrl4.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl4.m_isGrounded)
				{
					if (this.playerCtrl4.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl4.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl4.transform.position.x < this.checkRight.position.x && this.playerCtrl4.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Albus>() != null)
			{
				if (this.playerCtrl5 != this.targetPlayer.GetComponent<PlayerController_Albus>())
				{
					this.playerCtrl5 = this.targetPlayer.GetComponent<PlayerController_Albus>();
				}
				if (!this.playerCtrl5.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl5.m_isGrounded)
				{
					if (this.playerCtrl5.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl5.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl5.transform.position.x < this.checkRight.position.x && this.playerCtrl5.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Soma>() != null)
			{
				if (this.playerCtrl6 != this.targetPlayer.GetComponent<PlayerController_Soma>())
				{
					this.playerCtrl6 = this.targetPlayer.GetComponent<PlayerController_Soma>();
				}
				if (!this.playerCtrl6.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl6.m_isGrounded)
				{
					if (this.playerCtrl6.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl6.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl6.transform.position.x < this.checkRight.position.x && this.playerCtrl6.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Alucard>() != null)
			{
				if (this.playerCtrl7 != this.targetPlayer.GetComponent<PlayerController_Alucard>())
				{
					this.playerCtrl7 = this.targetPlayer.GetComponent<PlayerController_Alucard>();
				}
				if (!this.playerCtrl7.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl7.m_isGrounded)
				{
					if (this.playerCtrl7.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl7.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl7.transform.position.x < this.checkRight.position.x && this.playerCtrl7.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Julius>() != null)
			{
				if (this.playerCtrl8 != this.targetPlayer.GetComponent<PlayerController_Julius>())
				{
					this.playerCtrl8 = this.targetPlayer.GetComponent<PlayerController_Julius>();
				}
				if (!this.playerCtrl8.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl8.m_isGrounded)
				{
					if (this.playerCtrl8.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl8.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl8.transform.position.x < this.checkRight.position.x && this.playerCtrl8.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Yoko>() != null)
			{
				if (this.playerCtrl9 != this.targetPlayer.GetComponent<PlayerController_Yoko>())
				{
					this.playerCtrl9 = this.targetPlayer.GetComponent<PlayerController_Yoko>();
				}
				if (!this.playerCtrl9.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl9.m_isGrounded)
				{
					if (this.playerCtrl9.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl9.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl9.transform.position.x < this.checkRight.position.x && this.playerCtrl9.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Maria>() != null)
			{
				if (this.playerCtrl10 != this.targetPlayer.GetComponent<PlayerController_Maria>())
				{
					this.playerCtrl10 = this.targetPlayer.GetComponent<PlayerController_Maria>();
				}
				if (!this.playerCtrl10.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl10.m_isGrounded)
				{
					if (this.playerCtrl10.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl10.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl10.transform.position.x < this.checkRight.position.x && this.playerCtrl10.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Simon>() != null)
			{
				if (this.playerCtrl11 != this.targetPlayer.GetComponent<PlayerController_Simon>())
				{
					this.playerCtrl11 = this.targetPlayer.GetComponent<PlayerController_Simon>();
				}
				if (!this.playerCtrl11.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl11.m_isGrounded)
				{
					if (this.playerCtrl11.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl11.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl11.transform.position.x < this.checkRight.position.x && this.playerCtrl11.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Fuma>() != null)
			{
				if (this.playerCtrl12 != this.targetPlayer.GetComponent<PlayerController_Fuma>())
				{
					this.playerCtrl12 = this.targetPlayer.GetComponent<PlayerController_Fuma>();
				}
				if (!this.playerCtrl12.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl12.m_isGrounded)
				{
					if (this.playerCtrl12.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl12.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl12.transform.position.x < this.checkRight.position.x && this.playerCtrl12.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Add1>() != null)
			{
				if (this.playerCtrl13 != this.targetPlayer.GetComponent<PlayerController_Add1>())
				{
					this.playerCtrl13 = this.targetPlayer.GetComponent<PlayerController_Add1>();
				}
				if (!this.playerCtrl13.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl13.m_isGrounded)
				{
					if (this.playerCtrl13.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl13.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl13.transform.position.x < this.checkRight.position.x && this.playerCtrl13.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Add2>() != null)
			{
				if (this.playerCtrl14 != this.targetPlayer.GetComponent<PlayerController_Add2>())
				{
					this.playerCtrl14 = this.targetPlayer.GetComponent<PlayerController_Add2>();
				}
				if (!this.playerCtrl14.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl14.m_isGrounded)
				{
					if (this.playerCtrl14.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl14.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl14.transform.position.x < this.checkRight.position.x && this.playerCtrl14.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Add3>() != null)
			{
				if (this.playerCtrl15 != this.targetPlayer.GetComponent<PlayerController_Add3>())
				{
					this.playerCtrl15 = this.targetPlayer.GetComponent<PlayerController_Add3>();
				}
				if (!this.playerCtrl15.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl15.m_isGrounded)
				{
					if (this.playerCtrl15.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl15.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl15.transform.position.x < this.checkRight.position.x && this.playerCtrl15.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Add4>() != null)
			{
				if (this.playerCtrl16 != this.targetPlayer.GetComponent<PlayerController_Add4>())
				{
					this.playerCtrl16 = this.targetPlayer.GetComponent<PlayerController_Add4>();
				}
				if (!this.playerCtrl16.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl16.m_isGrounded)
				{
					if (this.playerCtrl16.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl16.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl16.transform.position.x < this.checkRight.position.x && this.playerCtrl16.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			else if (this.targetPlayer.GetComponent<PlayerController_Add5>() != null)
			{
				if (this.playerCtrl17 != this.targetPlayer.GetComponent<PlayerController_Add5>())
				{
					this.playerCtrl17 = this.targetPlayer.GetComponent<PlayerController_Add5>();
				}
				if (!this.playerCtrl17.m_isGrounded)
				{
					this.playerInUp = true;
					this.playerInHorizon = false;
					this.playerInDown = false;
				}
				else if (this.playerCtrl17.m_isGrounded)
				{
					if (this.playerCtrl17.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = false;
						this.playerInDown = true;
					}
					else if (!this.playerCtrl17.crouching)
					{
						this.playerInUp = false;
						this.playerInHorizon = true;
						this.playerInDown = false;
					}
				}
				if (this.playerCtrl17.transform.position.x < this.checkRight.position.x && this.playerCtrl17.transform.position.x > this.checkLeft.position.x)
				{
					this.playerOutOfRange = false;
				}
				else
				{
					this.playerOutOfRange = true;
				}
			}
			if (this.goBattle && !this.check)
			{
				this.playerSpite.SetActive(true);
				this.playerSpawn.bossBattle = true;
				this.check = true;
			}
			if (PhotonNetwork.isMasterClient && this.goBattle)
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
					if (this.targetPlayer.GetComponent<PlayerController>() != null)
					{
						this.playerCtrl = this.targetPlayer.GetComponent<PlayerController>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Shanoa>() != null)
					{
						this.playerCtrl2 = this.targetPlayer.GetComponent<PlayerController_Shanoa>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Jonathan>() != null)
					{
						this.playerCtrl3 = this.targetPlayer.GetComponent<PlayerController_Jonathan>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Charotte>() != null)
					{
						this.playerCtrl4 = this.targetPlayer.GetComponent<PlayerController_Charotte>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Albus>() != null)
					{
						this.playerCtrl5 = this.targetPlayer.GetComponent<PlayerController_Albus>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Soma>() != null)
					{
						this.playerCtrl6 = this.targetPlayer.GetComponent<PlayerController_Soma>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Alucard>() != null)
					{
						this.playerCtrl7 = this.targetPlayer.GetComponent<PlayerController_Alucard>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Julius>() != null)
					{
						this.playerCtrl8 = this.targetPlayer.GetComponent<PlayerController_Julius>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Yoko>() != null)
					{
						this.playerCtrl9 = this.targetPlayer.GetComponent<PlayerController_Yoko>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Maria>() != null)
					{
						this.playerCtrl10 = this.targetPlayer.GetComponent<PlayerController_Maria>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Simon>() != null)
					{
						this.playerCtrl11 = this.targetPlayer.GetComponent<PlayerController_Simon>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Fuma>() != null)
					{
						this.playerCtrl12 = this.targetPlayer.GetComponent<PlayerController_Fuma>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Add1>() != null)
					{
						this.playerCtrl13 = this.targetPlayer.GetComponent<PlayerController_Add1>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Add2>() != null)
					{
						this.playerCtrl14 = this.targetPlayer.GetComponent<PlayerController_Add2>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Add3>() != null)
					{
						this.playerCtrl15 = this.targetPlayer.GetComponent<PlayerController_Add3>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Add4>() != null)
					{
						this.playerCtrl16 = this.targetPlayer.GetComponent<PlayerController_Add4>();
					}
					if (this.targetPlayer.GetComponent<PlayerController_Add5>() != null)
					{
						this.playerCtrl17 = this.targetPlayer.GetComponent<PlayerController_Add5>();
					}
					this.searchTargetTimer = 0f;
				}
				if (!this.bgmCheck && PhotonNetwork.isMasterClient)
				{
					this.bgmWorks.ChangeBGMCall(this.bossBGM);
					this.bgmCheck = true;
				}
			}
			if (PhotonNetwork.isMasterClient)
			{
				if (currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_Pose && currentAnimatorStateInfo.normalizedTime > 1f)
				{
					this.animator.SetBool("Pose", false);
					this.canAI = true;
				}
				if ((currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_ATK_Whip_Stand || currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_ATK_Whip_Crouch || currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_ATK_Item || currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_ATK_Item2 || currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_ATK_Item3 || currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_ATK_Special || currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_ATK_GroundCross || currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_ATK_Whip_Stand) && currentAnimatorStateInfo.normalizedTime > 1f)
				{
					this.animator.SetBool("ATKWhip2", false);
					this.animator.SetBool("ATKWhip3", false);
					this.animator.SetBool("ATKItem_Axe", false);
					this.animator.SetBool("ATKItem_Cross", false);
					this.animator.SetBool("ATKItem_HolyWater", false);
					this.animator.SetBool("ATKTackle", false);
					this.animator.SetBool("ATKGroundCross", false);
				}
				if (this.animator.GetBool("ATKWhip1") && this.grounded)
				{
					this.enemyAists = Boss02.ENEMYAISTS.WAIT;
					this.animator.SetBool("ATKWhip1", false);
				}
			}
			if (base.GetComponent<Rigidbody2D>() != null)
			{
				if (currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_Idle || currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_Run_End)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
				}
				else if (currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_Run)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(this.speed * base.transform.localScale.x, base.GetComponent<Rigidbody2D>().velocity.y);
				}
			}
			if (this.targetPlayer != null)
			{
				if (base.transform.localScale.x > 0f)
				{
					if (base.transform.position.x > this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = true;
					}
					else if (base.transform.position.x < this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = false;
					}
				}
				else if (base.transform.localScale.x < 0f)
				{
					if (base.transform.position.x < this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = true;
					}
					else if (base.transform.position.x > this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = false;
					}
				}
			}
			if (this.BeginEnemyCommonWork() && PhotonNetwork.isMasterClient && this.activeAI)
			{
				this.FixedUpdateAI();
				this.EndEnemyCommonWork();
			}
		}

		// Token: 0x06001946 RID: 6470 RVA: 0x001342E4 File Offset: 0x001324E4
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

		// Token: 0x06001947 RID: 6471 RVA: 0x00134351 File Offset: 0x00132551
		public void EndEnemyCommonWork()
		{
			if (PhotonNetwork.isMasterClient && this.enemyAists == Boss02.ENEMYAISTS.WALKFORWARD && this.GetDistancePlayer() <= 1.7f)
			{
				this.animator.SetBool("WalkForward", false);
				this.canAI = true;
			}
		}

		// Token: 0x06001948 RID: 6472 RVA: 0x00134394 File Offset: 0x00132594
		public bool CheckAction()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			return currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_Dead && currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_ATK_Whip_Stand && currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_ATK_Whip_Jump && currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_ATK_Whip_Crouch && currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_ATK_Special && currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_ATK_Item && currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_ATK_Item2 && currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_ATK_Item3 && currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_ATK_GroundCross && currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_Crouch && currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_Crouch_End && currentAnimatorStateInfo.fullPathHash != Boss02.ANISTS_Crouch_Start;
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x00134480 File Offset: 0x00132680
		private void FixedUpdateAI()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if ((this.enemyAists == Boss02.ENEMYAISTS.ATKGROUNDCROSS || this.enemyAists == Boss02.ENEMYAISTS.ATKITEM1 || this.enemyAists == Boss02.ENEMYAISTS.ATKITEM2 || this.enemyAists == Boss02.ENEMYAISTS.ATKITEM3 || this.enemyAists == Boss02.ENEMYAISTS.ATKITEM4 || this.enemyAists == Boss02.ENEMYAISTS.ATKTACKLE || this.enemyAists == Boss02.ENEMYAISTS.ATKWHIP2 || this.enemyAists == Boss02.ENEMYAISTS.ATKWHIP3) && currentAnimatorStateInfo.fullPathHash == Boss02.ANISTS_Idle)
			{
				this.enemyAists = Boss02.ENEMYAISTS.WAIT;
			}
			if (this.goBattle)
			{
				if (!this.check2)
				{
					this.animator.SetBool("Pose", true);
					this.check2 = true;
				}
				if (this.canAI)
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
						this.myPV.RPC("ReciveTurn", PhotonTargets.Others, new object[0]);
					}
					if (!this.playerBackSide)
					{
						if (this.playerOutOfRange)
						{
							int num = this.SelectRandomAIState();
							if (num < 35)
							{
								if (this.GetDistancePlayer() > 1.7f)
								{
									this.enemyAists = Boss02.ENEMYAISTS.WALKFORWARD;
								}
								else if (this.GetDistancePlayer() <= 1.7f)
								{
									this.enemyAists = Boss02.ENEMYAISTS.ATKWHIP1;
								}
							}
							else if (num <= 100)
							{
								if (this.GetDistancePlayer() > 1.7f)
								{
									this.enemyAists = Boss02.ENEMYAISTS.WALKFORWARD;
								}
								else if (this.GetDistancePlayer() <= 1.7f)
								{
									this.enemyAists = Boss02.ENEMYAISTS.ATKGROUNDCROSS;
								}
							}
						}
						else if (!this.playerOutOfRange)
						{
							if (this.playerInUp)
							{
								int num2 = this.SelectRandomAIState();
								if (num2 < 45)
								{
									if (this.GetDistancePlayer() > 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.WALKFORWARD;
									}
									else if (this.GetDistancePlayer() <= 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.ATKWHIP1;
									}
								}
								else if (num2 < 90)
								{
									if (this.GetDistancePlayer() > 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.WALKFORWARD;
									}
									else if (this.GetDistancePlayer() <= 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.ATKITEM1;
									}
								}
								else if (num2 <= 100)
								{
									this.enemyAists = Boss02.ENEMYAISTS.ATKGROUNDCROSS;
								}
							}
							else if (this.playerInHorizon)
							{
								int num3 = this.SelectRandomAIState();
								if (num3 < 30)
								{
									if (this.GetDistancePlayer() > 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.WALKFORWARD;
									}
									else if (this.GetDistancePlayer() <= 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.ATKWHIP2;
									}
								}
								else if (num3 < 60)
								{
									if (this.GetDistancePlayer() > 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.WALKFORWARD;
									}
									else if (this.GetDistancePlayer() <= 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.ATKITEM2;
									}
								}
								else if (num3 < 90)
								{
									if (this.GetDistancePlayer() > 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.WALKFORWARD;
									}
									else if (this.GetDistancePlayer() <= 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.ATKTACKLE;
									}
								}
								else if (num3 <= 100)
								{
									this.enemyAists = Boss02.ENEMYAISTS.ATKGROUNDCROSS;
								}
							}
							else if (this.playerInDown)
							{
								int num4 = this.SelectRandomAIState();
								if (num4 < 30)
								{
									if (this.GetDistancePlayer() > 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.WALKFORWARD;
									}
									if (this.GetDistancePlayer() <= 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.ATKWHIP3;
									}
								}
								else if (num4 < 60)
								{
									if (this.GetDistancePlayer() > 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.WALKFORWARD;
									}
									else if (this.GetDistancePlayer() <= 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.ATKITEM3;
									}
								}
								else if (num4 < 90)
								{
									if (this.GetDistancePlayer() > 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.WALKFORWARD;
									}
									else if (this.GetDistancePlayer() <= 1.7f)
									{
										this.enemyAists = Boss02.ENEMYAISTS.ATKTACKLE;
									}
								}
								else if (num4 <= 100)
								{
									this.enemyAists = Boss02.ENEMYAISTS.ATKGROUNDCROSS;
								}
							}
						}
					}
				}
			}
			switch (this.enemyAists)
			{
			case Boss02.ENEMYAISTS.WAIT:
				this.timetest2 += Time.deltaTime;
				if (this.timetest2 > UnityEngine.Random.Range(this.waitTimeMin, this.waitTimeMax))
				{
					this.canAI = true;
					this.timetest2 = 0f;
				}
				break;
			case Boss02.ENEMYAISTS.WALKFORWARD:
				if (!this.animator.GetBool("WalkForward"))
				{
					this.animator.SetBool("WalkForward", true);
				}
				this.canAI = false;
				break;
			case Boss02.ENEMYAISTS.ATKWHIP1:
				if (!this.animator.GetBool("ATKWhip1"))
				{
					this.animator.SetBool("ATKWhip1", true);
				}
				this.canAI = false;
				break;
			case Boss02.ENEMYAISTS.ATKWHIP2:
				if (!this.animator.GetBool("ATKWhip2"))
				{
					this.animator.SetBool("ATKWhip2", true);
				}
				this.canAI = false;
				break;
			case Boss02.ENEMYAISTS.ATKWHIP3:
				if (!this.animator.GetBool("ATKWhip3"))
				{
					this.animator.SetBool("ATKWhip3", true);
				}
				this.canAI = false;
				break;
			case Boss02.ENEMYAISTS.ATKTACKLE:
				if (!this.animator.GetBool("ATKTackle"))
				{
					this.animator.SetBool("ATKTackle", true);
				}
				this.canAI = false;
				break;
			case Boss02.ENEMYAISTS.ATKGROUNDCROSS:
				if (!this.animator.GetBool("ATKGroundCross"))
				{
					this.animator.SetBool("ATKGroundCross", true);
				}
				this.canAI = false;
				break;
			case Boss02.ENEMYAISTS.ATKITEM1:
				if (!this.animator.GetBool("ATKItem_Axe"))
				{
					this.animator.SetBool("ATKItem_Axe", true);
				}
				this.canAI = false;
				break;
			case Boss02.ENEMYAISTS.ATKITEM2:
				if (!this.animator.GetBool("ATKItem_Cross"))
				{
					this.animator.SetBool("ATKItem_Cross", true);
				}
				this.canAI = false;
				break;
			case Boss02.ENEMYAISTS.ATKITEM3:
				if (!this.animator.GetBool("ATKItem_HolyWater"))
				{
					this.animator.SetBool("ATKItem_HolyWater", true);
				}
				this.canAI = false;
				break;
			case Boss02.ENEMYAISTS.ATKITEM4:
				if (!this.animator.GetBool("ATKItem"))
				{
					this.animator.SetBool("ATKItem", true);
				}
				this.canAI = false;
				break;
			}
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x00134B10 File Offset: 0x00132D10
		public void InstanceRange(int val)
		{
			int num = 0;
			if (base.transform.localScale.x < 0f)
			{
				num++;
			}
			switch (val)
			{
			case 1:
				this.instantiateManager.EnemyBossAxe(this.muzzle.position.x, this.muzzle.position.y, this.rangeWeaponATK1, num);
				break;
			case 2:
				this.instantiateManager.EnemyCross(this.muzzle.position.x, this.muzzle.position.y, this.rangeWeaponATK1, num);
				break;
			case 3:
				this.instantiateManager.EnemyHolyWater(this.muzzle.position.x, this.muzzle.position.y, this.rangeWeaponATK1, num);
				break;
			case 4:
				this.instantiateManager.EnemyGroundCross(this.muzzle.position.x, this.muzzle.position.y + 0.5f, this.rangeWeaponATK2);
				break;
			}
		}

		// Token: 0x0600194B RID: 6475 RVA: 0x00134C60 File Offset: 0x00132E60
		public void EnemyKillsCountPlus()
		{
			this.menuOnOff.enemyKills++;
		}

		// Token: 0x0600194C RID: 6476 RVA: 0x00134C78 File Offset: 0x00132E78
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
			if (this.enemyBody.ownATKHitted)
			{
				this.playerStatus.data_Rihiter++;
				this.playerStatus.score += this.score;
				this.playerStatus.killCount++;
				this.playerStatus.killCountAll++;
			}
			this.door1.up = true;
			this.door2.up = true;
		}

		// Token: 0x0600194D RID: 6477 RVA: 0x001351B8 File Offset: 0x001333B8
		public void Dead()
		{
			this.cVSounds = GameObject.FindGameObjectWithTag("Player").GetComponent<CVSounds>();
			this.cVSounds.KillBoss();
			this.animator.SetBool("Dead", true);
			this.myPV.RPC("AnimationSetBoolTrue", PhotonTargets.Others, new object[]
			{
				"Dead"
			});
			if (PhotonNetwork.isMasterClient)
			{
				base.Invoke("AppearChestBox", 3f);
			}
		}

		// Token: 0x0600194E RID: 6478 RVA: 0x00135230 File Offset: 0x00133430
		public void AppearChestBox()
		{
			GameObject gameObject = PhotonNetwork.Instantiate("Chest_Gold", new Vector3(this.chestPos.position.x, this.chestPos.position.y, 0f), Quaternion.identity, 0);
			ItemsChest component = gameObject.GetComponent<ItemsChest>();
			component.boxLevel = this.playerStatus.stageDifficult;
			ChestGold component2 = gameObject.GetComponent<ChestGold>();
			component2.returnLobbyTime = this.returnLobbyTime;
		}

		// Token: 0x0600194F RID: 6479 RVA: 0x00097E10 File Offset: 0x00096010
		public int SelectRandomAIState()
		{
			return UnityEngine.Random.Range(0, 100);
		}

		// Token: 0x06001950 RID: 6480 RVA: 0x001352AB File Offset: 0x001334AB
		public void SetAIState(Boss02.ENEMYAISTS sts, float t)
		{
			this.aiActionTimeStart = Time.fixedTime;
			this.aiActionTimeLength = t;
			this.enemyAists = sts;
		}

		// Token: 0x06001951 RID: 6481 RVA: 0x001352C8 File Offset: 0x001334C8
		public float GetDistancePlayer()
		{
			float num = base.transform.position.x - this.targetPlayer.transform.position.x;
			if (num < 0f)
			{
				num *= -1f;
			}
			return num;
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x00135318 File Offset: 0x00133518
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

		// Token: 0x06001953 RID: 6483 RVA: 0x0013533C File Offset: 0x0013353C
		public void CVCall(int num)
		{
			int num2 = this.lang;
			if (num2 != 0)
			{
				if (num2 == 1)
				{
					switch (num)
					{
					case 0:
						this.eCV.SoundEffectPlay(1);
						break;
					case 2:
						this.eCV.SoundEffectPlay(3);
						break;
					case 4:
						this.eCV.SoundEffectPlay(5);
						break;
					case 6:
						this.eCV.SoundEffectPlay(7);
						break;
					case 8:
						this.eCV.SoundEffectPlay(9);
						break;
					case 10:
						this.eCV.SoundEffectPlay(11);
						break;
					}
				}
			}
			else
			{
				this.eCV.SoundEffectPlay(num);
			}
		}

		// Token: 0x06001954 RID: 6484 RVA: 0x00135417 File Offset: 0x00133617
		public void SoundEffectCall(int num)
		{
			this.eSE.SoundEffectPlay(num);
		}

		// Token: 0x06001955 RID: 6485 RVA: 0x00135428 File Offset: 0x00133628
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

		// Token: 0x06001956 RID: 6486 RVA: 0x001354C4 File Offset: 0x001336C4
		public void VelocityY(float Vy)
		{
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, Vy);
		}

		// Token: 0x06001957 RID: 6487 RVA: 0x001354F8 File Offset: 0x001336F8
		public void DirTurn()
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x * -1f, base.transform.localScale.y, base.transform.localScale.z);
		}

		// Token: 0x06001958 RID: 6488 RVA: 0x00135554 File Offset: 0x00133754
		public void InstanceDustLeftLeg()
		{
			int i = 1;
			while (i <= 30)
			{
				int num = UnityEngine.Random.Range(0, 10);
				if (num < 5)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.dustPrefab1, new Vector3(base.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f), base.transform.position.y, 0f), Quaternion.identity);
					i++;
				}
				else if (num >= 5)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.dustPrefab2, new Vector3(base.transform.position.x + UnityEngine.Random.Range(-0.5f, 0.5f), base.transform.position.y, 0f), Quaternion.identity);
					i++;
				}
			}
		}

		// Token: 0x06001959 RID: 6489 RVA: 0x0013563A File Offset: 0x0013383A
		[PunRPC]
		private void ReciveTurn()
		{
			this.DirTurn();
		}

		// Token: 0x0600195A RID: 6490 RVA: 0x00135644 File Offset: 0x00133844
		[PunRPC]
		private void ReciveTarget(int num)
		{
			this.targetPlayer = GameObject.Find(this.ReturnTargetName(num));
			if (this.targetPlayer.GetComponent<PlayerController>() != null)
			{
				this.playerCtrl = this.targetPlayer.GetComponent<PlayerController>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Shanoa>() != null)
			{
				this.playerCtrl2 = this.targetPlayer.GetComponent<PlayerController_Shanoa>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Jonathan>() != null)
			{
				this.playerCtrl3 = this.targetPlayer.GetComponent<PlayerController_Jonathan>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Charotte>() != null)
			{
				this.playerCtrl4 = this.targetPlayer.GetComponent<PlayerController_Charotte>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Albus>() != null)
			{
				this.playerCtrl5 = this.targetPlayer.GetComponent<PlayerController_Albus>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Soma>() != null)
			{
				this.playerCtrl6 = this.targetPlayer.GetComponent<PlayerController_Soma>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Alucard>() != null)
			{
				this.playerCtrl7 = this.targetPlayer.GetComponent<PlayerController_Alucard>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Julius>() != null)
			{
				this.playerCtrl8 = this.targetPlayer.GetComponent<PlayerController_Julius>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Yoko>() != null)
			{
				this.playerCtrl9 = this.targetPlayer.GetComponent<PlayerController_Yoko>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Maria>() != null)
			{
				this.playerCtrl10 = this.targetPlayer.GetComponent<PlayerController_Maria>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Simon>() != null)
			{
				this.playerCtrl11 = this.targetPlayer.GetComponent<PlayerController_Simon>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Fuma>() != null)
			{
				this.playerCtrl12 = this.targetPlayer.GetComponent<PlayerController_Fuma>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Add1>() != null)
			{
				this.playerCtrl13 = this.targetPlayer.GetComponent<PlayerController_Add1>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Add2>() != null)
			{
				this.playerCtrl14 = this.targetPlayer.GetComponent<PlayerController_Add2>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Add3>() != null)
			{
				this.playerCtrl15 = this.targetPlayer.GetComponent<PlayerController_Add3>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Add4>() != null)
			{
				this.playerCtrl16 = this.targetPlayer.GetComponent<PlayerController_Add4>();
			}
			if (this.targetPlayer.GetComponent<PlayerController_Add5>() != null)
			{
				this.playerCtrl17 = this.targetPlayer.GetComponent<PlayerController_Add5>();
			}
		}

		// Token: 0x0600195B RID: 6491 RVA: 0x001358FA File Offset: 0x00133AFA
		[PunRPC]
		private void ReciveDead()
		{
			if (!this.deadCheck)
			{
				this.Dead();
				this.deadCheck = true;
			}
		}

		// Token: 0x0600195C RID: 6492 RVA: 0x00135914 File Offset: 0x00133B14
		[PunRPC]
		private void ReciveSetLanguage(int val)
		{
			this.lang = val;
		}

		// Token: 0x0600195D RID: 6493 RVA: 0x00098AA0 File Offset: 0x00096CA0
		[PunRPC]
		private void ReciveCurse()
		{
			this.curseTimer = 0f;
			if (!this.curse)
			{
				this.curse = true;
			}
		}

		// Token: 0x0600195E RID: 6494 RVA: 0x00098ABF File Offset: 0x00096CBF
		[PunRPC]
		private void RecivePoison()
		{
			this.poisonTimer = 0f;
			if (!this.poison)
			{
				this.poison = true;
			}
		}

		// Token: 0x04002477 RID: 9335
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Boss02_Idle");

		// Token: 0x04002478 RID: 9336
		public static readonly int ANISTS_Run = Animator.StringToHash("Base Layer.Boss02_Run");

		// Token: 0x04002479 RID: 9337
		public static readonly int ANISTS_Run_Start = Animator.StringToHash("Base Layer.Boss02_Run_Start");

		// Token: 0x0400247A RID: 9338
		public static readonly int ANISTS_Run_End = Animator.StringToHash("Base Layer.Boss02_Run_End");

		// Token: 0x0400247B RID: 9339
		public static readonly int ANISTS_Crouch = Animator.StringToHash("Base Layer.Boss02_Crouch");

		// Token: 0x0400247C RID: 9340
		public static readonly int ANISTS_Crouch_Start = Animator.StringToHash("Base Layer.Boss02_Crouch_Start");

		// Token: 0x0400247D RID: 9341
		public static readonly int ANISTS_Crouch_End = Animator.StringToHash("Base Layer.Boss02_Crouch_End");

		// Token: 0x0400247E RID: 9342
		public static readonly int ANISTS_Fall = Animator.StringToHash("Base Layer.Boss02_Fall");

		// Token: 0x0400247F RID: 9343
		public static readonly int ANISTS_ATK_Whip_Stand = Animator.StringToHash("Base Layer.Boss02_ATK_Whip_Stand");

		// Token: 0x04002480 RID: 9344
		public static readonly int ANISTS_ATK_Whip_Crouch = Animator.StringToHash("Base Layer.Boss02_ATK_Whip_Crouch");

		// Token: 0x04002481 RID: 9345
		public static readonly int ANISTS_ATK_Whip_Jump = Animator.StringToHash("Base Layer.Boss02_ATK_Whip_Jump");

		// Token: 0x04002482 RID: 9346
		public static readonly int ANISTS_ATK_Special = Animator.StringToHash("Base Layer.Boss02_ATK_Special");

		// Token: 0x04002483 RID: 9347
		public static readonly int ANISTS_ATK_Item = Animator.StringToHash("Base Layer.Boss02_ATK_Item");

		// Token: 0x04002484 RID: 9348
		public static readonly int ANISTS_ATK_Item2 = Animator.StringToHash("Base Layer.Boss02_ATK_Item2");

		// Token: 0x04002485 RID: 9349
		public static readonly int ANISTS_ATK_Item3 = Animator.StringToHash("Base Layer.Boss02_ATK_Item3");

		// Token: 0x04002486 RID: 9350
		public static readonly int ANISTS_ATK_GroundCross = Animator.StringToHash("Base Layer.Boss02_ATK_GroundCross");

		// Token: 0x04002487 RID: 9351
		public static readonly int ANISTS_Dead = Animator.StringToHash("Base Layer.Boss02_Dead");

		// Token: 0x04002488 RID: 9352
		public static readonly int ANISTS_Pose = Animator.StringToHash("Base Layer.Boss02_Pose");

		// Token: 0x04002489 RID: 9353
		public static readonly int ANISTS_Spawn = Animator.StringToHash("Base Layer.Boss02_Spawn");

		// Token: 0x0400248A RID: 9354
		protected float aiActionTimeLength;

		// Token: 0x0400248B RID: 9355
		protected float aiActionTimeStart;

		// Token: 0x0400248C RID: 9356
		public Boss02.ENEMYAISTS enemyAists;

		// Token: 0x0400248D RID: 9357
		public float speed = 1.2f;

		// Token: 0x0400248E RID: 9358
		public bool activeAI;

		// Token: 0x0400248F RID: 9359
		public float dogPileReturnLength = 2f;

		// Token: 0x04002490 RID: 9360
		public float ATKActiveLength = 1f;

		// Token: 0x04002491 RID: 9361
		public float specialATKActiveLength = 0.5f;

		// Token: 0x04002492 RID: 9362
		public float timetest2;

		// Token: 0x04002493 RID: 9363
		public float waitTimeMin = 3f;

		// Token: 0x04002494 RID: 9364
		public float waitTimeMax = 4f;

		// Token: 0x04002495 RID: 9365
		public float searchTargetTimer;

		// Token: 0x04002496 RID: 9366
		public float startHp;

		// Token: 0x04002497 RID: 9367
		public bool playerBackSide;

		// Token: 0x04002498 RID: 9368
		public bool playerInUp;

		// Token: 0x04002499 RID: 9369
		public bool playerInHorizon;

		// Token: 0x0400249A RID: 9370
		public bool playerInDown;

		// Token: 0x0400249B RID: 9371
		public bool playerOutOfRange;

		// Token: 0x0400249C RID: 9372
		public bool canAI;

		// Token: 0x0400249D RID: 9373
		public bool goBattle;

		// Token: 0x0400249E RID: 9374
		public bool deadCheck;

		// Token: 0x0400249F RID: 9375
		public bool bgmCheck;

		// Token: 0x040024A0 RID: 9376
		public EnemyBody enemyBody;

		// Token: 0x040024A1 RID: 9377
		private GameObject[] allPlayer;

		// Token: 0x040024A2 RID: 9378
		public Transform chestPos;

		// Token: 0x040024A3 RID: 9379
		public GameObject dustPrefab1;

		// Token: 0x040024A4 RID: 9380
		public GameObject dustPrefab2;

		// Token: 0x040024A5 RID: 9381
		private EnemySoundEffect eCV;

		// Token: 0x040024A6 RID: 9382
		private EnemySoundEffect eSE;

		// Token: 0x040024A7 RID: 9383
		private Animator targetAnim;

		// Token: 0x040024A8 RID: 9384
		private Text targetText;

		// Token: 0x040024A9 RID: 9385
		private Image targetImage;

		// Token: 0x040024AA RID: 9386
		public Sprite archiveSprite;

		// Token: 0x040024AB RID: 9387
		public Sprite archiveSprite2;

		// Token: 0x040024AC RID: 9388
		public Sprite archiveSprite3;

		// Token: 0x040024AD RID: 9389
		public bool alreadyUnlockArchive;

		// Token: 0x040024AE RID: 9390
		public bool alreadyUnlockArchive2;

		// Token: 0x040024AF RID: 9391
		public bool alreadyUnlockArchive3;

		// Token: 0x040024B0 RID: 9392
		private MenuOnOff menuOnOff;

		// Token: 0x040024B1 RID: 9393
		public int skeltonPlayers;

		// Token: 0x040024B2 RID: 9394
		private PlayerStatus playerStatus;

		// Token: 0x040024B3 RID: 9395
		private PhotonView myPV;

		// Token: 0x040024B4 RID: 9396
		public GameObject targetPlayer;

		// Token: 0x040024B5 RID: 9397
		public PlayerController playerCtrl;

		// Token: 0x040024B6 RID: 9398
		public PlayerController_Shanoa playerCtrl2;

		// Token: 0x040024B7 RID: 9399
		public PlayerController_Jonathan playerCtrl3;

		// Token: 0x040024B8 RID: 9400
		public PlayerController_Charotte playerCtrl4;

		// Token: 0x040024B9 RID: 9401
		public PlayerController_Albus playerCtrl5;

		// Token: 0x040024BA RID: 9402
		public PlayerController_Soma playerCtrl6;

		// Token: 0x040024BB RID: 9403
		public PlayerController_Alucard playerCtrl7;

		// Token: 0x040024BC RID: 9404
		public PlayerController_Julius playerCtrl8;

		// Token: 0x040024BD RID: 9405
		public PlayerController_Yoko playerCtrl9;

		// Token: 0x040024BE RID: 9406
		public PlayerController_Maria playerCtrl10;

		// Token: 0x040024BF RID: 9407
		public PlayerController_Simon playerCtrl11;

		// Token: 0x040024C0 RID: 9408
		public PlayerController_Fuma playerCtrl12;

		// Token: 0x040024C1 RID: 9409
		public PlayerController_Add1 playerCtrl13;

		// Token: 0x040024C2 RID: 9410
		public PlayerController_Add2 playerCtrl14;

		// Token: 0x040024C3 RID: 9411
		public PlayerController_Add3 playerCtrl15;

		// Token: 0x040024C4 RID: 9412
		public PlayerController_Add4 playerCtrl16;

		// Token: 0x040024C5 RID: 9413
		public PlayerController_Add5 playerCtrl17;

		// Token: 0x040024C6 RID: 9414
		private BGMWorks bgmWorks;

		// Token: 0x040024C7 RID: 9415
		public int bossBGM;

		// Token: 0x040024C8 RID: 9416
		public int score;

		// Token: 0x040024C9 RID: 9417
		private PlayerSpwan playerSpawn;

		// Token: 0x040024CA RID: 9418
		public bool check;

		// Token: 0x040024CB RID: 9419
		public bool check2;

		// Token: 0x040024CC RID: 9420
		public bool check3;

		// Token: 0x040024CD RID: 9421
		private GameObject playerSpite;

		// Token: 0x040024CE RID: 9422
		public Transform checkLeft;

		// Token: 0x040024CF RID: 9423
		public Transform checkRight;

		// Token: 0x040024D0 RID: 9424
		private BoxCollider2D bodyCol2d;

		// Token: 0x040024D1 RID: 9425
		public int lang;

		// Token: 0x040024D2 RID: 9426
		public CVSounds cVSounds;

		// Token: 0x040024D3 RID: 9427
		public GameObject lastDMG;

		// Token: 0x040024D4 RID: 9428
		public Door1TimeLag door1;

		// Token: 0x040024D5 RID: 9429
		public Door1TimeLag door2;

		// Token: 0x040024D6 RID: 9430
		public GameObject crossPrefab;

		// Token: 0x040024D7 RID: 9431
		public GameObject holyWaterPrefab;

		// Token: 0x040024D8 RID: 9432
		public GameObject axePrefab;

		// Token: 0x040024D9 RID: 9433
		public GameObject groundCrossPrefab;

		// Token: 0x040024DA RID: 9434
		private Transform muzzle;

		// Token: 0x040024DB RID: 9435
		public float rangeWeaponATK1;

		// Token: 0x040024DC RID: 9436
		public float rangeWeaponATK2;

		// Token: 0x040024DD RID: 9437
		public int boxLevel;

		// Token: 0x040024DE RID: 9438
		public float returnLobbyTime;

		// Token: 0x040024DF RID: 9439
		private MeshRenderer mesh;

		// Token: 0x040024E0 RID: 9440
		private CameraController cameraCtrl;

		// Token: 0x040024E1 RID: 9441
		public InstantiateManager instantiateManager;

		// Token: 0x0200031C RID: 796
		public enum ENEMYAISTS
		{
			// Token: 0x040024E3 RID: 9443
			STAY,
			// Token: 0x040024E4 RID: 9444
			WAIT,
			// Token: 0x040024E5 RID: 9445
			WALKFORWARD,
			// Token: 0x040024E6 RID: 9446
			ATKWHIP1,
			// Token: 0x040024E7 RID: 9447
			ATKWHIP2,
			// Token: 0x040024E8 RID: 9448
			ATKWHIP3,
			// Token: 0x040024E9 RID: 9449
			ATKTACKLE,
			// Token: 0x040024EA RID: 9450
			ATKGROUNDCROSS,
			// Token: 0x040024EB RID: 9451
			ATKITEM1,
			// Token: 0x040024EC RID: 9452
			ATKITEM2,
			// Token: 0x040024ED RID: 9453
			ATKITEM3,
			// Token: 0x040024EE RID: 9454
			ATKITEM4,
			// Token: 0x040024EF RID: 9455
			DEAD
		}
	}
}
