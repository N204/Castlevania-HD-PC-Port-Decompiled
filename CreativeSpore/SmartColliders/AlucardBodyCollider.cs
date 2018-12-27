﻿using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020003EC RID: 1004
	public class AlucardBodyCollider : MonoBehaviour
	{
		// Token: 0x06002457 RID: 9303 RVA: 0x00317180 File Offset: 0x00315380
		private void Awake()
		{
			this.playerCtrl_Alucard = base.transform.parent.GetComponent<PlayerController_Alucard>();
			this.myPV = base.transform.parent.GetComponent<PhotonView>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x003171CE File Offset: 0x003153CE
		private void Start()
		{
			this.instantiateManager = this.playerCtrl_Alucard.instantiateManager;
		}

		// Token: 0x06002459 RID: 9305 RVA: 0x003171E4 File Offset: 0x003153E4
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "IronMaidenBox")
			{
				this.hitMoveBox = true;
			}
			if (this.myPV.isMine && !this.playerCtrl_Alucard.damaged)
			{
				if ((other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && other.transform.root != base.transform.root)
				{
					if (other.transform.root.GetComponent<PlayerController>() != null)
					{
						PlayerController component = other.transform.root.GetComponent<PlayerController>();
						if (component.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Shanoa>() != null)
					{
						PlayerController_Shanoa component2 = other.transform.root.GetComponent<PlayerController_Shanoa>();
						if (component2.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Jonathan>() != null)
					{
						PlayerController_Jonathan component3 = other.transform.root.GetComponent<PlayerController_Jonathan>();
						if (component3.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Charotte>() != null)
					{
						PlayerController_Charotte component4 = other.transform.root.GetComponent<PlayerController_Charotte>();
						if (component4.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Alucard>() != null)
					{
						PlayerController_Alucard component5 = other.transform.root.GetComponent<PlayerController_Alucard>();
						if (component5.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Soma>() != null)
					{
						PlayerController_Soma component6 = other.transform.root.GetComponent<PlayerController_Soma>();
						if (component6.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Alucard>() != null)
					{
						PlayerController_Alucard component7 = other.transform.root.GetComponent<PlayerController_Alucard>();
						if (component7.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Julius>() != null)
					{
						PlayerController_Julius component8 = other.transform.root.GetComponent<PlayerController_Julius>();
						if (component8.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Maria>() != null)
					{
						PlayerController_Maria component9 = other.transform.root.GetComponent<PlayerController_Maria>();
						if (component9.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Yoko>() != null)
					{
						PlayerController_Yoko component10 = other.transform.root.GetComponent<PlayerController_Yoko>();
						if (component10.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Fuma>() != null)
					{
						PlayerController_Fuma component11 = other.transform.root.GetComponent<PlayerController_Fuma>();
						if (component11.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Simon>() != null)
					{
						PlayerController_Simon component12 = other.transform.root.GetComponent<PlayerController_Simon>();
						if (component12.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Add1>() != null)
					{
						PlayerController_Add1 component13 = other.transform.root.GetComponent<PlayerController_Add1>();
						if (component13.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Add2>() != null)
					{
						PlayerController_Add2 component14 = other.transform.root.GetComponent<PlayerController_Add2>();
						if (component14.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Add3>() != null)
					{
						PlayerController_Add3 component15 = other.transform.root.GetComponent<PlayerController_Add3>();
						if (component15.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Add4>() != null)
					{
						PlayerController_Add4 component16 = other.transform.root.GetComponent<PlayerController_Add4>();
						if (component16.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PlayerController_Add5>() != null)
					{
						PlayerController_Add5 component17 = other.transform.root.GetComponent<PlayerController_Add5>();
						if (component17.miryou)
						{
							this.TeamDamage(other.gameObject);
						}
					}
				}
				if ((this.playerStatus.teamDamage || this.playerCtrl_Alucard.miryou) && (other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper"))
				{
					if (other.transform.root.tag == "Player" && other.transform.root != base.transform.root)
					{
						this.TeamDamage(other.gameObject);
						this.playerCtrl_Alucard.HitEffect();
					}
					if (other.transform.root.GetComponent<AgonySphere>() != null)
					{
						AgonySphere component18 = other.transform.root.GetComponent<AgonySphere>();
						if (!component18.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Akerubusu>() != null)
					{
						Akerubusu component19 = other.transform.root.GetComponent<Akerubusu>();
						if (!component19.mineSW)
						{
							this.StatusCurseRandom();
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<RangeSoma>() != null)
					{
						RangeSoma component20 = other.transform.root.GetComponent<RangeSoma>();
						if (!component20.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<RangeSoma2>() != null)
					{
						RangeSoma2 component21 = other.transform.root.GetComponent<RangeSoma2>();
						if (component21.magicNumber != 13 && !component21.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Javelin>() != null)
					{
						Javelin component22 = other.transform.root.GetComponent<Javelin>();
						if (!component22.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<BulletRange>() != null)
					{
						BulletRange component23 = other.transform.root.GetComponent<BulletRange>();
						if (!component23.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<DarkInferno>() != null)
					{
						DarkInferno component24 = other.transform.root.GetComponent<DarkInferno>();
						if (!component24.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<DeathSickle>() != null)
					{
						DeathSickle component25 = other.transform.root.GetComponent<DeathSickle>();
						if (!component25.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<DeltaSpark>() != null)
					{
						DeltaSpark component26 = other.transform.root.GetComponent<DeltaSpark>();
						if (!component26.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<FetherEdge>() != null)
					{
						FetherEdge component27 = other.transform.root.GetComponent<FetherEdge>();
						if (!component27.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Gurando>() != null)
					{
						Gurando component28 = other.transform.root.GetComponent<Gurando>();
						if (!component28.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Gurobusu>() != null)
					{
						Gurobusu component29 = other.transform.root.GetComponent<Gurobusu>();
						if (!component29.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<HellFire>() != null)
					{
						HellFire component30 = other.transform.root.GetComponent<HellFire>();
						if (!component30.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Igunisu>() != null)
					{
						Igunisu component31 = other.transform.root.GetComponent<Igunisu>();
						if (!component31.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<L_DeathSickle>() != null)
					{
						L_DeathSickle component32 = other.transform.root.GetComponent<L_DeathSickle>();
						if (!component32.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<L_FireBall>() != null)
					{
						L_FireBall component33 = other.transform.root.GetComponent<L_FireBall>();
						if (!component33.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<L_SummonSkeltonRange>() != null)
					{
						L_SummonSkeltonRange component34 = other.transform.root.GetComponent<L_SummonSkeltonRange>();
						if (!component34.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<AcidBubble>() != null)
					{
						AcidBubble component35 = other.transform.root.GetComponent<AcidBubble>();
						if (!component35.mineSW)
						{
							this.StatusPoisonRandom();
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<DemoSeed>() != null)
					{
						DemoSeed component36 = other.transform.root.GetComponent<DemoSeed>();
						if (!component36.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Dullahan_Curse>() != null)
					{
						Dullahan_Curse component37 = other.transform.root.GetComponent<Dullahan_Curse>();
						if (!component37.mineSW)
						{
							this.StatusCurseRandom();
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<EnergyLight>() != null)
					{
						EnergyLight component38 = other.transform.root.GetComponent<EnergyLight>();
						if (!component38.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<FireBall>() != null)
					{
						FireBall component39 = other.transform.root.GetComponent<FireBall>();
						if (!component39.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<FlameShot>() != null)
					{
						FlameShot component40 = other.transform.root.GetComponent<FlameShot>();
						if (!component40.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<IceNeedle>() != null)
					{
						IceNeedle component41 = other.transform.root.GetComponent<IceNeedle>();
						if (!component41.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<RagingFire>() != null)
					{
						RagingFire component42 = other.transform.root.GetComponent<RagingFire>();
						if (!component42.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<SickleMoon>() != null)
					{
						SickleMoon component43 = other.transform.root.GetComponent<SickleMoon>();
						if (!component43.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<SplashNeedle>() != null)
					{
						SplashNeedle component44 = other.transform.root.GetComponent<SplashNeedle>();
						if (!component44.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<PoisonSpore>() != null)
					{
						PoisonSpore component45 = other.transform.root.GetComponent<PoisonSpore>();
						if (!component45.mineSW)
						{
							this.StatusPoisonRandom();
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Puneuma>() != null)
					{
						Puneuma component46 = other.transform.root.GetComponent<Puneuma>();
						if (!component46.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Ruminare>() != null)
					{
						Ruminare component47 = other.transform.root.GetComponent<Ruminare>();
						if (!component47.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<SummonSkeltonBone>() != null)
					{
						SummonSkeltonBone component48 = other.transform.root.GetComponent<SummonSkeltonBone>();
						if (!component48.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<ThunderBolt>() != null)
					{
						ThunderBolt component49 = other.transform.root.GetComponent<ThunderBolt>();
						if (!component49.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<TorutonisuPrefab>() != null)
					{
						TorutonisuPrefab component50 = other.transform.root.GetComponent<TorutonisuPrefab>();
						if (!component50.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<WhiteFang>() != null)
					{
						WhiteFang component51 = other.transform.root.GetComponent<WhiteFang>();
						if (!component51.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Axe>() != null)
					{
						Axe component52 = other.transform.root.GetComponent<Axe>();
						if (!component52.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Bible>() != null)
					{
						Bible component53 = other.transform.root.GetComponent<Bible>();
						if (!component53.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<BoneATK>() != null)
					{
						BoneATK component54 = other.transform.root.GetComponent<BoneATK>();
						if (!component54.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Bumeran>() != null)
					{
						Bumeran component55 = other.transform.root.GetComponent<Bumeran>();
						if (!component55.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Cross>() != null)
					{
						Cross component56 = other.transform.root.GetComponent<Cross>();
						if (!component56.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<LCross>() != null)
					{
						LCross component57 = other.transform.root.GetComponent<LCross>();
						if (!component57.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Grenade>() != null)
					{
						Grenade component58 = other.transform.root.GetComponent<Grenade>();
						if (!component58.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<HevensSword>() != null)
					{
						HevensSword component59 = other.transform.root.GetComponent<HevensSword>();
						if (!component59.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<HolyWater>() != null)
					{
						HolyWater component60 = other.transform.root.GetComponent<HolyWater>();
						if (!component60.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Javelin>() != null)
					{
						Javelin component61 = other.transform.root.GetComponent<Javelin>();
						if (!component61.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Kunai>() != null)
					{
						Kunai component62 = other.transform.root.GetComponent<Kunai>();
						if (!component62.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<LAxe>() != null)
					{
						LAxe component63 = other.transform.root.GetComponent<LAxe>();
						if (!component63.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<LHolyWater>() != null)
					{
						LHolyWater component64 = other.transform.root.GetComponent<LHolyWater>();
						if (!component64.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.GetComponent<MienaiPunch>() != null)
					{
						MienaiPunch component65 = other.GetComponent<MienaiPunch>();
						if (!component65.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Nebyura>() != null)
					{
						Nebyura component66 = other.transform.root.GetComponent<Nebyura>();
						if (!component66.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<OpticalShot>() != null)
					{
						OpticalShot component67 = other.transform.root.GetComponent<OpticalShot>();
						if (!component67.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Torupensu>() != null)
					{
						Torupensu component68 = other.transform.root.GetComponent<Torupensu>();
						if (!component68.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<TyoukouIsi>() != null)
					{
						TyoukouIsi component69 = other.transform.root.GetComponent<TyoukouIsi>();
						if (!component69.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<DualCrushSet>() != null)
					{
						DualCrushSet component70 = other.transform.root.GetComponent<DualCrushSet>();
						if (!component70.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<DualCrushSet>() != null)
					{
						DualCrushSet component71 = other.transform.root.GetComponent<DualCrushSet>();
						if (!component71.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<GroundCross>() != null)
					{
						GroundCross component72 = other.transform.root.GetComponent<GroundCross>();
						if (!component72.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Kokyuutosu>() != null)
					{
						Kokyuutosu component73 = other.transform.root.GetComponent<Kokyuutosu>();
						if (!component73.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<Prominence>() != null)
					{
						Prominence component74 = other.transform.root.GetComponent<Prominence>();
						if (!component74.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<ThunderCross>() != null)
					{
						ThunderCross component75 = other.transform.root.GetComponent<ThunderCross>();
						if (!component75.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
					if (other.transform.root.GetComponent<ThunderCross>() != null)
					{
						ThunderCross component76 = other.transform.root.GetComponent<ThunderCross>();
						if (!component76.mineSW)
						{
							this.TeamDamage(other.gameObject);
						}
					}
				}
				if (other.tag == "EnemyBodyAttack" || other.tag == "EnemyBlockCollider")
				{
					if (other.name == "StoneAttackCol")
					{
						this.StatusStoneRandom();
					}
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f = this.playerCtrl_Alucard.hpMax / 5f;
							float f2 = Mathf.Round(f);
							int damage = Mathf.RoundToInt(f2);
							this.playerCtrl_Alucard.ActionDamage(damage);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent = other.GetComponentInParent<EnemyBody>();
							float num = componentInParent.enemyATK / 1.5f;
							float num2 = this.playerCtrl_Alucard.dEF / 10f;
							float f3 = num * this.playerCtrl_Alucard.berserkerMeiru - num2;
							float f4 = Mathf.Round(f3);
							int num3 = Mathf.RoundToInt(f4);
							if (num3 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num3);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num3 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(1);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent2 = other.GetComponentInParent<EnemyBody>();
						float f5 = componentInParent2.enemyATK / 1.5f;
						float f6 = Mathf.Round(f5);
						int num4 = Mathf.RoundToInt(f6);
						if (num4 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num4);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (num4 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(1);
							this.playerCtrl_Alucard.HitEffect();
						}
					}
				}
				else if (other.tag == "EnemyBodyAttackSp" || other.tag == "EnemyBodyAttackBoss01")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f7 = this.playerCtrl_Alucard.hpMax / 5f;
							float f8 = Mathf.Round(f7);
							int damage2 = Mathf.RoundToInt(f8);
							this.playerCtrl_Alucard.ActionDamage(damage2);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent3 = other.transform.parent.parent.GetComponentInParent<EnemyBody>();
							float num5 = componentInParent3.enemyATK / 1.5f;
							float num6 = this.playerCtrl_Alucard.dEF / 10f;
							float f9 = num5 * this.playerCtrl_Alucard.berserkerMeiru - num6;
							float f10 = Mathf.Round(f9);
							int num7 = Mathf.RoundToInt(f10);
							if (num7 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num7);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num7 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(1);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent4 = other.transform.parent.parent.GetComponentInParent<EnemyBody>();
						float f11 = componentInParent4.enemyATK / 1.5f;
						float f12 = Mathf.Round(f11);
						int num8 = Mathf.RoundToInt(f12);
						if (num8 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num8);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (num8 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(1);
							this.playerCtrl_Alucard.HitEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKArm")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f13 = this.playerCtrl_Alucard.hpMax / 5f;
							float f14 = Mathf.Round(f13);
							int damage3 = Mathf.RoundToInt(f14);
							this.playerCtrl_Alucard.ActionDamage(damage3);
							this.playerCtrl_Alucard.HitEffect();
							this.playerCtrl_Alucard.BloodEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent5 = other.GetComponentInParent<EnemyBody>();
							float enemyATK = componentInParent5.enemyATK;
							float num9 = this.playerCtrl_Alucard.dEF / 10f;
							float f15 = enemyATK * this.playerCtrl_Alucard.berserkerMeiru - num9;
							float f16 = Mathf.Round(f15);
							int num10 = Mathf.RoundToInt(f16);
							if (num10 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num10);
								this.playerCtrl_Alucard.HitEffect();
								this.playerCtrl_Alucard.BloodEffect();
							}
							else if (num10 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
								this.playerCtrl_Alucard.BloodEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent6 = other.GetComponentInParent<EnemyBody>();
						float enemyATK2 = componentInParent6.enemyATK;
						float f17 = Mathf.Round(enemyATK2);
						int num11 = Mathf.RoundToInt(f17);
						if (num11 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num11);
							this.playerCtrl_Alucard.HitEffect();
							this.playerCtrl_Alucard.BloodEffect();
						}
						else if (num11 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.HitEffect();
							this.playerCtrl_Alucard.BloodEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKMagic")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f18 = this.playerCtrl_Alucard.hpMax / 5f;
							float f19 = Mathf.Round(f18);
							int damage4 = Mathf.RoundToInt(f19);
							this.playerCtrl_Alucard.ActionDamage(damage4);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent7 = other.GetComponentInParent<EnemyBody>();
							float enemyINT = componentInParent7.enemyINT;
							float num12 = this.playerCtrl_Alucard.mND / 10f;
							float f20 = enemyINT * this.playerCtrl_Alucard.berserkerMeiru - num12;
							float f21 = Mathf.Round(f20);
							int num13 = Mathf.RoundToInt(f21);
							if (num13 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num13);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num13 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent8 = other.GetComponentInParent<EnemyBody>();
						float enemyINT2 = componentInParent8.enemyINT;
						float f22 = Mathf.Round(enemyINT2);
						int num14 = Mathf.RoundToInt(f22);
						if (num14 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num14);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (num14 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.HitEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKHit")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f23 = this.playerCtrl_Alucard.hpMax / 5f;
							float f24 = Mathf.Round(f23);
							int damage5 = Mathf.RoundToInt(f24);
							this.playerCtrl_Alucard.ActionDamage(damage5);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent9 = other.GetComponentInParent<EnemyBody>();
							float enemyATK3 = componentInParent9.enemyATK;
							float num15 = this.playerCtrl_Alucard.dEF / 10f;
							float num16 = enemyATK3 / 100f * this.playerCtrl_Alucard.playerHIT;
							float f25 = enemyATK3 * this.playerCtrl_Alucard.berserkerMeiru - num16 - num15;
							float f26 = Mathf.Round(f25);
							int num17 = Mathf.RoundToInt(f26);
							if (num17 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num17);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num17 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent10 = other.GetComponentInParent<EnemyBody>();
						float enemyATK4 = componentInParent10.enemyATK;
						float f27 = Mathf.Round(enemyATK4);
						int num18 = Mathf.RoundToInt(f27);
						if (num18 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num18);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (num18 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.HitEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKCut")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f28 = this.playerCtrl_Alucard.hpMax / 5f;
							float f29 = Mathf.Round(f28);
							int damage6 = Mathf.RoundToInt(f29);
							this.playerCtrl_Alucard.ActionDamage(damage6);
							this.playerCtrl_Alucard.BloodEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent11 = other.GetComponentInParent<EnemyBody>();
							float enemyATK5 = componentInParent11.enemyATK;
							float num19 = this.playerCtrl_Alucard.dEF / 10f;
							float num20 = enemyATK5 / 100f * this.playerCtrl_Alucard.playerCUT;
							float f30 = enemyATK5 * this.playerCtrl_Alucard.berserkerMeiru - num20 - num19;
							float f31 = Mathf.Round(f30);
							int num21 = Mathf.RoundToInt(f31);
							if (num21 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num21);
								this.playerCtrl_Alucard.BloodEffect();
							}
							else if (num21 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.BloodEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent12 = other.GetComponentInParent<EnemyBody>();
						float enemyATK6 = componentInParent12.enemyATK;
						float f32 = Mathf.Round(enemyATK6);
						int num22 = Mathf.RoundToInt(f32);
						if (num22 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num22);
							this.playerCtrl_Alucard.BloodEffect();
						}
						else if (num22 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.BloodEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKPoke")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f33 = this.playerCtrl_Alucard.hpMax / 5f;
							float f34 = Mathf.Round(f33);
							int damage7 = Mathf.RoundToInt(f34);
							this.playerCtrl_Alucard.ActionDamage(damage7);
							this.playerCtrl_Alucard.BloodEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent13 = other.GetComponentInParent<EnemyBody>();
							float enemyATK7 = componentInParent13.enemyATK;
							float num23 = this.playerCtrl_Alucard.dEF / 10f;
							float num24 = enemyATK7 / 100f * this.playerCtrl_Alucard.playerPOKE;
							float f35 = enemyATK7 * this.playerCtrl_Alucard.berserkerMeiru - num24 - num23;
							float f36 = Mathf.Round(f35);
							int num25 = Mathf.RoundToInt(f36);
							if (num25 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num25);
								this.playerCtrl_Alucard.HitEffect();
								this.playerCtrl_Alucard.BloodEffect();
							}
							else if (num25 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
								this.playerCtrl_Alucard.BloodEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent14 = other.GetComponentInParent<EnemyBody>();
						float enemyATK8 = componentInParent14.enemyATK;
						float f37 = Mathf.Round(enemyATK8);
						int num26 = Mathf.RoundToInt(f37);
						if (num26 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num26);
							this.playerCtrl_Alucard.BloodEffect();
						}
						else if (num26 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.BloodEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKFire" || other.tag == "EnemyFireBullet")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f38 = this.playerCtrl_Alucard.hpMax / 5f;
							float f39 = Mathf.Round(f38);
							int damage8 = Mathf.RoundToInt(f39);
							this.playerCtrl_Alucard.ActionDamage(damage8);
							this.playerCtrl_Alucard.FireEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent15 = other.GetComponentInParent<EnemyBody>();
							float enemyINT3 = componentInParent15.enemyINT;
							float num27 = this.playerCtrl_Alucard.mND / 10f;
							float num28 = enemyINT3 / 100f * this.playerCtrl_Alucard.playerFIRE;
							float f40 = enemyINT3 * this.playerCtrl_Alucard.berserkerMeiru - num28 - num27;
							float f41 = Mathf.Round(f40);
							int num29 = Mathf.RoundToInt(f41);
							if (num29 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num29);
								this.playerCtrl_Alucard.FireEffect();
							}
							else if (num29 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.FireEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent16 = other.GetComponentInParent<EnemyBody>();
						float enemyINT4 = componentInParent16.enemyINT;
						float f42 = Mathf.Round(enemyINT4);
						int num30 = Mathf.RoundToInt(f42);
						if (num30 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num30);
							this.playerCtrl_Alucard.FireEffect();
						}
						else if (num30 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.FireEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKIce")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f43 = this.playerCtrl_Alucard.hpMax / 5f;
							float f44 = Mathf.Round(f43);
							int damage9 = Mathf.RoundToInt(f44);
							this.playerCtrl_Alucard.ActionDamage(damage9);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent17 = other.GetComponentInParent<EnemyBody>();
							float enemyINT5 = componentInParent17.enemyINT;
							float num31 = this.playerCtrl_Alucard.mND / 10f;
							float num32 = enemyINT5 / 100f * this.playerCtrl_Alucard.playerICE;
							float f45 = enemyINT5 * this.playerCtrl_Alucard.berserkerMeiru - num32 - num31;
							float f46 = Mathf.Round(f45);
							int num33 = Mathf.RoundToInt(f46);
							if (num33 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num33);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num33 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent18 = other.GetComponentInParent<EnemyBody>();
						float enemyINT6 = componentInParent18.enemyINT;
						float f47 = Mathf.Round(enemyINT6);
						int num34 = Mathf.RoundToInt(f47);
						if (num34 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num34);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (num34 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.HitEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKLight")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f48 = this.playerCtrl_Alucard.hpMax / 5f;
							float f49 = Mathf.Round(f48);
							int damage10 = Mathf.RoundToInt(f49);
							this.playerCtrl_Alucard.ActionDamage(damage10);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent19 = other.GetComponentInParent<EnemyBody>();
							float enemyINT7 = componentInParent19.enemyINT;
							float num35 = this.playerCtrl_Alucard.mND / 10f;
							float num36 = enemyINT7 / 100f * this.playerCtrl_Alucard.playerLIGH;
							float f50 = enemyINT7 * this.playerCtrl_Alucard.berserkerMeiru - num36 - num35;
							float f51 = Mathf.Round(f50);
							int num37 = Mathf.RoundToInt(f51);
							if (num37 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num37);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num37 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent20 = other.GetComponentInParent<EnemyBody>();
						float enemyINT8 = componentInParent20.enemyINT;
						float f52 = Mathf.Round(enemyINT8);
						int num38 = Mathf.RoundToInt(f52);
						if (num38 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num38);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (num38 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.HitEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKDark")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f53 = this.playerCtrl_Alucard.hpMax / 5f;
							float f54 = Mathf.Round(f53);
							int damage11 = Mathf.RoundToInt(f54);
							this.playerCtrl_Alucard.ActionDamage(damage11);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent21 = other.GetComponentInParent<EnemyBody>();
							float enemyINT9 = componentInParent21.enemyINT;
							float num39 = this.playerCtrl_Alucard.mND / 10f;
							float num40 = enemyINT9 / 100f * this.playerCtrl_Alucard.playerDARK;
							float f55 = enemyINT9 * this.playerCtrl_Alucard.berserkerMeiru - num40 - num39;
							float f56 = Mathf.Round(f55);
							int num41 = Mathf.RoundToInt(f56);
							if (num41 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num41);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num41 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent22 = other.GetComponentInParent<EnemyBody>();
						float enemyINT10 = componentInParent22.enemyINT;
						float f57 = Mathf.Round(enemyINT10);
						int num42 = Mathf.RoundToInt(f57);
						if (num42 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num42);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (num42 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.HitEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKThun")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f58 = this.playerCtrl_Alucard.hpMax / 5f;
							float f59 = Mathf.Round(f58);
							int damage12 = Mathf.RoundToInt(f59);
							this.playerCtrl_Alucard.ActionDamage(damage12);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent23 = other.GetComponentInParent<EnemyBody>();
							float enemyINT11 = componentInParent23.enemyINT;
							float num43 = this.playerCtrl_Alucard.mND / 10f;
							float num44 = enemyINT11 / 100f * this.playerCtrl_Alucard.playerTHUN;
							float f60 = enemyINT11 * this.playerCtrl_Alucard.berserkerMeiru - num44 - num43;
							float f61 = Mathf.Round(f60);
							int num45 = Mathf.RoundToInt(f61);
							if (num45 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num45);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num45 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent24 = other.GetComponentInParent<EnemyBody>();
						float enemyINT12 = componentInParent24.enemyINT;
						float f62 = Mathf.Round(enemyINT12);
						int num46 = Mathf.RoundToInt(f62);
						if (num46 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num46);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (num46 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.HitEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKPoison")
				{
					this.StatusPoisonRandom();
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f63 = this.playerCtrl_Alucard.hpMax / 5f;
							float f64 = Mathf.Round(f63);
							int damage13 = Mathf.RoundToInt(f64);
							this.playerCtrl_Alucard.ActionDamage(damage13);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent25 = other.GetComponentInParent<EnemyBody>();
							float enemyINT13 = componentInParent25.enemyINT;
							float num47 = this.playerCtrl_Alucard.mND / 10f;
							float num48 = enemyINT13 / 100f * this.playerCtrl_Alucard.playerPOIS;
							float f65 = enemyINT13 * this.playerCtrl_Alucard.berserkerMeiru - num48 - num47;
							float f66 = Mathf.Round(f65);
							int num49 = Mathf.RoundToInt(f66);
							if (num49 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num49);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num49 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent26 = other.GetComponentInParent<EnemyBody>();
						float enemyINT14 = componentInParent26.enemyINT;
						float f67 = Mathf.Round(enemyINT14);
						int num50 = Mathf.RoundToInt(f67);
						if (num50 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num50);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (num50 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.HitEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKCurse")
				{
					this.StatusCurseRandom();
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f68 = this.playerCtrl_Alucard.hpMax / 5f;
							float f69 = Mathf.Round(f68);
							int damage14 = Mathf.RoundToInt(f69);
							this.playerCtrl_Alucard.ActionDamage(damage14);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent27 = other.GetComponentInParent<EnemyBody>();
							float enemyINT15 = componentInParent27.enemyINT;
							float num51 = this.playerCtrl_Alucard.mND / 10f;
							float num52 = enemyINT15 / 100f * this.playerCtrl_Alucard.playerCURS;
							float f70 = enemyINT15 * this.playerCtrl_Alucard.berserkerMeiru - num52 - num51;
							float f71 = Mathf.Round(f70);
							int num53 = Mathf.RoundToInt(f71);
							if (num53 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num53);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num53 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent28 = other.GetComponentInParent<EnemyBody>();
						float enemyINT16 = componentInParent28.enemyINT;
						float f72 = Mathf.Round(enemyINT16);
						int num54 = Mathf.RoundToInt(f72);
						if (num54 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num54);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (num54 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.HitEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKStone")
				{
					this.StatusStoneRandom();
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f73 = this.playerCtrl_Alucard.hpMax / 5f;
							float f74 = Mathf.Round(f73);
							int damage15 = Mathf.RoundToInt(f74);
							this.playerCtrl_Alucard.ActionDamage(damage15);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent29 = other.GetComponentInParent<EnemyBody>();
							float enemyINT17 = componentInParent29.enemyINT;
							float num55 = this.playerCtrl_Alucard.mND / 10f;
							float num56 = enemyINT17 / 100f * this.playerCtrl_Alucard.playerSTON;
							float f75 = enemyINT17 * this.playerCtrl_Alucard.berserkerMeiru - num56 - num55;
							float f76 = Mathf.Round(f75);
							int num57 = Mathf.RoundToInt(f76);
							if (num57 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num57);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num57 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						EnemyBody componentInParent30 = other.GetComponentInParent<EnemyBody>();
						float enemyINT18 = componentInParent30.enemyINT;
						float f77 = Mathf.Round(enemyINT18);
						int num58 = Mathf.RoundToInt(f77);
						if (num58 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num58);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (num58 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.HitEffect();
						}
					}
				}
				else if (other.tag == "EnemyATKMiryouMan")
				{
					this.StatusMiryou();
				}
				else if (other.tag == "EnemyATKMiryouWoman")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f78 = this.playerCtrl_Alucard.hpMax / 5f;
							float f79 = Mathf.Round(f78);
							int damage16 = Mathf.RoundToInt(f79);
							this.playerCtrl_Alucard.ActionDamage(damage16);
							this.playerCtrl_Alucard.HitEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							EnemyBody componentInParent31 = other.GetComponentInParent<EnemyBody>();
							float enemyINT19 = componentInParent31.enemyINT;
							float num59 = this.playerCtrl_Alucard.mND / 10f;
							float f80 = enemyINT19 * this.playerCtrl_Alucard.berserkerMeiru - num59;
							float f81 = Mathf.Round(f80);
							int num60 = Mathf.RoundToInt(f81);
							if (num60 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num60);
								this.playerCtrl_Alucard.HitEffect();
							}
							else if (num60 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.HitEffect();
							}
						}
					}
				}
				else if (other.tag == "Trap")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f82 = this.playerCtrl_Alucard.hpMax / 5f;
							float f83 = Mathf.Round(f82);
							int damage17 = Mathf.RoundToInt(f83);
							this.playerCtrl_Alucard.ActionDamage(damage17);
							this.playerCtrl_Alucard.BloodEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							float num61 = 25f;
							int stageDifficult = this.playerStatus.stageDifficult;
							if (stageDifficult != 2)
							{
								if (stageDifficult == 3)
								{
									num61 = 100f;
								}
							}
							else
							{
								num61 = 50f;
							}
							float num62 = this.playerCtrl_Alucard.dEF / 10f;
							float num63 = num61 / 100f * this.playerCtrl_Alucard.playerCUT;
							float f84 = num61 * this.playerCtrl_Alucard.berserkerMeiru - num63 - num62;
							float f85 = Mathf.Round(f84);
							int num64 = Mathf.RoundToInt(f85);
							if (num64 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num64);
								this.playerCtrl_Alucard.BloodEffect();
							}
							else if (num64 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.BloodEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						float f86 = 25f;
						int stageDifficult2 = this.playerStatus.stageDifficult;
						if (stageDifficult2 != 2)
						{
							if (stageDifficult2 == 3)
							{
								f86 = 100f;
							}
						}
						else
						{
							f86 = 50f;
						}
						float f87 = Mathf.Round(f86);
						int num65 = Mathf.RoundToInt(f87);
						if (num65 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num65);
							this.playerCtrl_Alucard.BloodEffect();
						}
						else if (num65 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.BloodEffect();
						}
					}
				}
				else if (other.tag == "TrapFire")
				{
					if (!this.playerCtrl_Alucard.isSkelton)
					{
						if (this.playerCtrl_Alucard.oldTypeArmor == 1)
						{
							float f88 = this.playerCtrl_Alucard.hpMax / 5f;
							float f89 = Mathf.Round(f88);
							int damage18 = Mathf.RoundToInt(f89);
							this.playerCtrl_Alucard.ActionDamage(damage18);
							this.playerCtrl_Alucard.FireEffect();
						}
						else if (this.playerCtrl_Alucard.oldTypeArmor == 0)
						{
							float num66 = 25f;
							int stageDifficult3 = this.playerStatus.stageDifficult;
							if (stageDifficult3 != 2)
							{
								if (stageDifficult3 == 3)
								{
									num66 = 100f;
								}
							}
							else
							{
								num66 = 50f;
							}
							float num67 = this.playerCtrl_Alucard.mND / 10f;
							float num68 = num66 / 100f * this.playerCtrl_Alucard.playerFIRE;
							float f90 = num66 * this.playerCtrl_Alucard.berserkerMeiru - num68 - num67;
							float f91 = Mathf.Round(f90);
							int num69 = Mathf.RoundToInt(f91);
							if (num69 >= 1)
							{
								this.playerCtrl_Alucard.ActionDamage(num69);
								this.playerCtrl_Alucard.FireEffect();
							}
							else if (num69 < 1)
							{
								this.playerCtrl_Alucard.ActionDamage(0);
								this.playerCtrl_Alucard.FireEffect();
							}
						}
					}
					else if (this.playerCtrl_Alucard.isSkelton)
					{
						float f92 = 25f;
						int stageDifficult4 = this.playerStatus.stageDifficult;
						if (stageDifficult4 != 2)
						{
							if (stageDifficult4 == 3)
							{
								f92 = 100f;
							}
						}
						else
						{
							f92 = 50f;
						}
						float f93 = Mathf.Round(f92);
						int num70 = Mathf.RoundToInt(f93);
						if (num70 >= 1)
						{
							this.playerCtrl_Alucard.ActionDamage(num70);
							this.playerCtrl_Alucard.FireEffect();
						}
						else if (num70 < 1)
						{
							this.playerCtrl_Alucard.ActionDamage(0);
							this.playerCtrl_Alucard.FireEffect();
						}
					}
				}
				else if (other.tag == "BalowGrando")
				{
					if (this.myPV.isMine)
					{
						BalowGrando component77 = other.transform.parent.GetComponent<BalowGrando>();
						if (this.playerCtrl_Alucard != null && this.playerCtrl_Alucard.canHitIronMaiden)
						{
							this.playerCtrl_Alucard.IronMaidenAction(component77.level);
						}
					}
				}
				else if (other.tag == "DraculaCatch")
				{
					if (this.myPV.isMine && this.playerCtrl_Alucard != null && this.playerCtrl_Alucard.canHitIronMaiden)
					{
						int stageDifficult5 = this.playerStatus.stageDifficult;
						if (stageDifficult5 != 1)
						{
							if (stageDifficult5 != 2)
							{
								if (stageDifficult5 == 3)
								{
									this.playerCtrl_Alucard.IronMaidenAction(8);
								}
							}
							else
							{
								this.playerCtrl_Alucard.IronMaidenAction(7);
							}
						}
						else
						{
							this.playerCtrl_Alucard.IronMaidenAction(6);
						}
					}
				}
				else if (other.tag == "IronMaiden" && this.myPV.isMine)
				{
					IronMaiden component78 = other.GetComponent<IronMaiden>();
					if (this.playerCtrl_Alucard != null && this.playerCtrl_Alucard.canHitIronMaiden)
					{
						component78.CloseAction();
						this.playerCtrl_Alucard.IronMaidenAction(component78.level);
						this.playerCtrl_Alucard.gameObject.transform.position = new Vector2(component78.transform.position.x, base.transform.position.y);
					}
				}
			}
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x0031AE4C File Offset: 0x0031904C
		private void StatusPoisonRandom()
		{
			float f = this.playerStatus.MND / 2f;
			float f2 = Mathf.Round(f);
			int num = Mathf.RoundToInt(f2);
			if (num < 1)
			{
				num = 1;
			}
			float f3 = Mathf.Round(this.playerStatus.playerPOIS);
			int num2 = Mathf.RoundToInt(f3);
			if (num2 < 1)
			{
				num2 = 1;
			}
			int num3 = UnityEngine.Random.Range(0, 100 + num + num2);
			if (num3 < 35)
			{
				this.playerCtrl_Alucard.StatusPoison();
			}
			else
			{
				this.playerCtrl_Alucard.StatusResist();
			}
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x0031AEDC File Offset: 0x003190DC
		private void StatusCurseRandom()
		{
			float f = this.playerStatus.MND / 2f;
			float f2 = Mathf.Round(f);
			int num = Mathf.RoundToInt(f2);
			if (num < 1)
			{
				num = 1;
			}
			float f3 = Mathf.Round(this.playerStatus.playerCURS);
			int num2 = Mathf.RoundToInt(f3);
			if (num2 < 1)
			{
				num2 = 1;
			}
			int num3 = UnityEngine.Random.Range(0, 100 + num + num2);
			if (num3 < 35)
			{
				this.playerCtrl_Alucard.StatusCurse();
			}
			else
			{
				this.playerCtrl_Alucard.StatusResist();
			}
		}

		// Token: 0x0600245C RID: 9308 RVA: 0x0031AF6C File Offset: 0x0031916C
		private void StatusStoneRandom()
		{
			float f = this.playerStatus.MND / 2f;
			float f2 = Mathf.Round(f);
			int num = Mathf.RoundToInt(f2);
			if (num < 1)
			{
				num = 1;
			}
			float f3 = Mathf.Round(this.playerStatus.playerSTON);
			int num2 = Mathf.RoundToInt(f3);
			if (num2 < 1)
			{
				num2 = 1;
			}
			int num3 = UnityEngine.Random.Range(0, 100 + num + num2);
			if (num3 < 35)
			{
				this.playerCtrl_Alucard.StatusStone();
			}
			else
			{
				this.playerCtrl_Alucard.StatusResist();
			}
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x0031AFF9 File Offset: 0x003191F9
		private void StatusMiryou()
		{
			this.playerCtrl_Alucard.StatusMiryou();
		}

		// Token: 0x0600245E RID: 9310 RVA: 0x0031B008 File Offset: 0x00319208
		private void TeamDamage(GameObject other)
		{
			this.playerCtrl_Alucard.ActionDamage(1);
			this.playerCtrl_Alucard.HitEffect();
			if (other.tag == "PlayerATKStone")
			{
				this.StatusStoneRandom();
			}
			if (other.tag == "PlayerATKPoison")
			{
				this.StatusPoisonRandom();
			}
			if (other.tag == "PlayerATKCurse")
			{
				this.StatusCurseRandom();
			}
		}

		// Token: 0x04004014 RID: 16404
		private PlayerController_Alucard playerCtrl_Alucard;

		// Token: 0x04004015 RID: 16405
		private PhotonView myPV;

		// Token: 0x04004016 RID: 16406
		private PlayerStatus playerStatus;

		// Token: 0x04004017 RID: 16407
		private InstantiateManager instantiateManager;

		// Token: 0x04004018 RID: 16408
		public bool dmgATKBody;

		// Token: 0x04004019 RID: 16409
		public bool dmgATK;

		// Token: 0x0400401A RID: 16410
		public bool dmgATKMagic;

		// Token: 0x0400401B RID: 16411
		public bool dmgATKHit;

		// Token: 0x0400401C RID: 16412
		public bool dmgATKCut;

		// Token: 0x0400401D RID: 16413
		public bool hitMoveBox;
	}
}
