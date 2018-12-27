using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000478 RID: 1144
	public class ATKSpikeMeiru : MonoBehaviour
	{
		// Token: 0x06002B43 RID: 11075 RVA: 0x0048A554 File Offset: 0x00488754
		private void Awake()
		{
			this.myPV = base.transform.parent.GetComponent<PhotonView>();
			if (base.transform.parent.GetComponent<PlayerController>() != null)
			{
				this.playerCtrl = base.transform.parent.GetComponent<PlayerController>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Shanoa>() != null)
			{
				this.playerCtrl_Shanoa = base.transform.parent.GetComponent<PlayerController_Shanoa>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Jonathan>() != null)
			{
				this.playerCtrl_Jonathan = base.transform.parent.GetComponent<PlayerController_Jonathan>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Charotte>() != null)
			{
				this.playerCtrl_Charotte = base.transform.parent.GetComponent<PlayerController_Charotte>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Albus>() != null)
			{
				this.playerCtrl_Albus = base.transform.parent.GetComponent<PlayerController_Albus>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Soma>() != null)
			{
				this.playerCtrl6 = base.transform.parent.GetComponent<PlayerController_Soma>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Alucard>() != null)
			{
				this.playerCtrl7 = base.transform.parent.GetComponent<PlayerController_Alucard>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Julius>() != null)
			{
				this.playerCtrl8 = base.transform.parent.GetComponent<PlayerController_Julius>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Yoko>() != null)
			{
				this.playerCtrl9 = base.transform.parent.GetComponent<PlayerController_Yoko>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Maria>() != null)
			{
				this.playerCtrl10 = base.transform.parent.GetComponent<PlayerController_Maria>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Simon>() != null)
			{
				this.playerCtrl11 = base.transform.parent.GetComponent<PlayerController_Simon>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Fuma>() != null)
			{
				this.playerCtrl12 = base.transform.parent.GetComponent<PlayerController_Fuma>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Add1>() != null)
			{
				this.playerCtrl13 = base.transform.parent.GetComponent<PlayerController_Add1>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Add2>() != null)
			{
				this.playerCtrl14 = base.transform.parent.GetComponent<PlayerController_Add2>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Add3>() != null)
			{
				this.playerCtrl15 = base.transform.parent.GetComponent<PlayerController_Add3>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Add4>() != null)
			{
				this.playerCtrl16 = base.transform.parent.GetComponent<PlayerController_Add4>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Add5>() != null)
			{
				this.playerCtrl17 = base.transform.parent.GetComponent<PlayerController_Add5>();
			}
		}

		// Token: 0x06002B44 RID: 11076 RVA: 0x0048A8B8 File Offset: 0x00488AB8
		private void Start()
		{
			if (this.playerCtrl != null)
			{
				this.playerNumber = this.playerCtrl.playerNumber;
			}
			if (this.playerCtrl_Shanoa != null)
			{
				this.playerNumber = this.playerCtrl_Shanoa.playerNumber;
			}
			if (this.playerCtrl_Jonathan != null)
			{
				this.playerNumber = this.playerCtrl_Jonathan.playerNumber;
			}
			if (this.playerCtrl_Charotte != null)
			{
				this.playerNumber = this.playerCtrl_Charotte.playerNumber;
			}
			if (this.playerCtrl_Albus != null)
			{
				this.playerNumber = this.playerCtrl_Albus.playerNumber;
			}
			if (this.playerCtrl6 != null)
			{
				this.playerNumber = this.playerCtrl6.playerNumber;
			}
			if (this.playerCtrl7 != null)
			{
				this.playerNumber = this.playerCtrl7.playerNumber;
			}
			if (this.playerCtrl8 != null)
			{
				this.playerNumber = this.playerCtrl8.playerNumber;
			}
			if (this.playerCtrl9 != null)
			{
				this.playerNumber = this.playerCtrl9.playerNumber;
			}
			if (this.playerCtrl10 != null)
			{
				this.playerNumber = this.playerCtrl10.playerNumber;
			}
			if (this.playerCtrl11 != null)
			{
				this.playerNumber = this.playerCtrl11.playerNumber;
			}
			if (this.playerCtrl12 != null)
			{
				this.playerNumber = this.playerCtrl12.playerNumber;
			}
			if (this.playerCtrl13 != null)
			{
				this.playerNumber = this.playerCtrl13.playerNumber;
			}
			if (this.playerCtrl14 != null)
			{
				this.playerNumber = this.playerCtrl14.playerNumber;
			}
			if (this.playerCtrl15 != null)
			{
				this.playerNumber = this.playerCtrl15.playerNumber;
			}
			if (this.playerCtrl16 != null)
			{
				this.playerNumber = this.playerCtrl16.playerNumber;
			}
			if (this.playerCtrl17 != null)
			{
				this.playerNumber = this.playerCtrl17.playerNumber;
			}
		}

		// Token: 0x06002B45 RID: 11077 RVA: 0x0048AB08 File Offset: 0x00488D08
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				EnemyBody component = other.transform.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component) == 1)
				{
					this.ExpPlus(component.enemyLevel);
					Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x = vector.x;
					float y = vector.y;
					if (this.playerCtrl != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl.aTK / 3f, this.playerCtrl.dEX, x, y);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl_Shanoa.aTK / 3f, this.playerCtrl_Shanoa.dEX, x, y);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl_Jonathan.aTK / 3f, this.playerCtrl_Jonathan.dEX, x, y);
					}
					else if (this.playerCtrl_Charotte != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl_Charotte.aTK / 3f, this.playerCtrl_Charotte.dEX, x, y);
					}
					else if (this.playerCtrl_Albus != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl_Albus.aTK / 3f, this.playerCtrl_Albus.dEX, x, y);
					}
					else if (this.playerCtrl6 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl6.aTK / 3f, this.playerCtrl6.dEX, x, y);
					}
					else if (this.playerCtrl7 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl7.aTK / 3f, this.playerCtrl7.dEX, x, y);
					}
					else if (this.playerCtrl8 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl8.aTK / 3f, this.playerCtrl8.dEX, x, y);
					}
					else if (this.playerCtrl9 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl9.aTK / 3f, this.playerCtrl9.dEX, x, y);
					}
					else if (this.playerCtrl10 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl10.aTK / 3f, this.playerCtrl10.dEX, x, y);
					}
					else if (this.playerCtrl11 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl11.aTK / 3f, this.playerCtrl11.dEX, x, y);
					}
					else if (this.playerCtrl12 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl12.aTK / 3f, this.playerCtrl12.dEX, x, y);
					}
					else if (this.playerCtrl13 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl13.aTK / 3f, this.playerCtrl13.dEX, x, y);
					}
					else if (this.playerCtrl14 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl14.aTK / 3f, this.playerCtrl14.dEX, x, y);
					}
					else if (this.playerCtrl15 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl15.aTK / 3f, this.playerCtrl15.dEX, x, y);
					}
					else if (this.playerCtrl16 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl16.aTK / 3f, this.playerCtrl16.dEX, x, y);
					}
					else if (this.playerCtrl17 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl17.aTK / 3f, this.playerCtrl17.dEX, x, y);
					}
					component.ReciveBoolReturn(this.returnTime, "SpikeMeiru", this.playerNumber);
				}
			}
			else if (other.tag == "EnemyBodyAttackSp")
			{
				EnemyBody component2 = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component2) == 1)
				{
					this.ExpPlus(component2.enemyLevel);
					Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x2 = vector2.x;
					float y2 = vector2.y;
					if (this.playerCtrl != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl.aTK / 3f, this.playerCtrl.dEX, x2, y2);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl_Shanoa.aTK / 3f, this.playerCtrl_Shanoa.dEX, x2, y2);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl_Jonathan.aTK / 3f, this.playerCtrl_Jonathan.dEX, x2, y2);
					}
					else if (this.playerCtrl_Charotte != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl_Charotte.aTK / 3f, this.playerCtrl_Charotte.dEX, x2, y2);
					}
					else if (this.playerCtrl_Albus != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl_Albus.aTK / 3f, this.playerCtrl_Albus.dEX, x2, y2);
					}
					else if (this.playerCtrl6 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl6.aTK / 3f, this.playerCtrl6.dEX, x2, y2);
					}
					else if (this.playerCtrl7 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl7.aTK / 3f, this.playerCtrl7.dEX, x2, y2);
					}
					else if (this.playerCtrl8 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl8.aTK / 3f, this.playerCtrl8.dEX, x2, y2);
					}
					else if (this.playerCtrl9 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl9.aTK / 3f, this.playerCtrl9.dEX, x2, y2);
					}
					else if (this.playerCtrl10 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl10.aTK / 3f, this.playerCtrl10.dEX, x2, y2);
					}
					else if (this.playerCtrl11 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl11.aTK / 3f, this.playerCtrl11.dEX, x2, y2);
					}
					else if (this.playerCtrl12 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl12.aTK / 3f, this.playerCtrl12.dEX, x2, y2);
					}
					else if (this.playerCtrl13 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl13.aTK / 3f, this.playerCtrl13.dEX, x2, y2);
					}
					else if (this.playerCtrl14 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl14.aTK / 3f, this.playerCtrl14.dEX, x2, y2);
					}
					else if (this.playerCtrl15 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl15.aTK / 3f, this.playerCtrl15.dEX, x2, y2);
					}
					else if (this.playerCtrl16 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl16.aTK / 3f, this.playerCtrl16.dEX, x2, y2);
					}
					else if (this.playerCtrl17 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl17.aTK / 3f, this.playerCtrl17.dEX, x2, y2);
					}
					component2.ReciveBoolReturn(this.returnTime, "SpikeMeiru", this.playerNumber);
				}
			}
			else if (other.tag == "EnemyBodyAttackBoss01")
			{
				Boss01BodyDetect component3 = other.GetComponent<Boss01BodyDetect>();
				EnemyBody component4 = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component4) == 1)
				{
					this.ExpPlus(component3.enemyLevel);
					Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x3 = vector3.x;
					float y3 = vector3.y;
					if (this.playerCtrl != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl.aTK / 3f, this.playerCtrl.dEX, x3, y3);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl_Shanoa.aTK / 3f, this.playerCtrl_Shanoa.dEX, x3, y3);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl_Jonathan.aTK / 3f, this.playerCtrl_Jonathan.dEX, x3, y3);
					}
					else if (this.playerCtrl_Charotte != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl_Charotte.aTK / 3f, this.playerCtrl_Charotte.dEX, x3, y3);
					}
					else if (this.playerCtrl_Albus != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl_Albus.aTK / 3f, this.playerCtrl_Albus.dEX, x3, y3);
					}
					else if (this.playerCtrl6 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl6.aTK / 3f, this.playerCtrl6.dEX, x3, y3);
					}
					else if (this.playerCtrl7 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl7.aTK / 3f, this.playerCtrl7.dEX, x3, y3);
					}
					else if (this.playerCtrl8 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl8.aTK / 3f, this.playerCtrl8.dEX, x3, y3);
					}
					else if (this.playerCtrl9 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl9.aTK / 3f, this.playerCtrl9.dEX, x3, y3);
					}
					else if (this.playerCtrl10 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl10.aTK / 3f, this.playerCtrl10.dEX, x3, y3);
					}
					else if (this.playerCtrl11 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl11.aTK / 3f, this.playerCtrl11.dEX, x3, y3);
					}
					else if (this.playerCtrl12 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl12.aTK / 3f, this.playerCtrl12.dEX, x3, y3);
					}
					else if (this.playerCtrl13 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl13.aTK / 3f, this.playerCtrl13.dEX, x3, y3);
					}
					else if (this.playerCtrl14 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl14.aTK / 3f, this.playerCtrl14.dEX, x3, y3);
					}
					else if (this.playerCtrl15 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl15.aTK / 3f, this.playerCtrl15.dEX, x3, y3);
					}
					else if (this.playerCtrl16 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl16.aTK / 3f, this.playerCtrl16.dEX, x3, y3);
					}
					else if (this.playerCtrl17 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl17.aTK / 3f, this.playerCtrl17.dEX, x3, y3);
					}
					component4.ReciveBoolReturn(this.returnTime, "SpikeMeiru", this.playerNumber);
				}
			}
		}

		// Token: 0x06002B46 RID: 11078 RVA: 0x0048B8E0 File Offset: 0x00489AE0
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				EnemyBody component = other.transform.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component) == 1)
				{
					this.ExpPlus(component.enemyLevel);
					Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x = vector.x;
					float y = vector.y;
					if (this.playerCtrl != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl.aTK / 3f, this.playerCtrl.dEX, x, y);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl_Shanoa.aTK / 3f, this.playerCtrl_Shanoa.dEX, x, y);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl_Jonathan.aTK / 3f, this.playerCtrl_Jonathan.dEX, x, y);
					}
					else if (this.playerCtrl_Charotte != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl_Charotte.aTK / 3f, this.playerCtrl_Charotte.dEX, x, y);
					}
					else if (this.playerCtrl_Albus != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl_Albus.aTK / 3f, this.playerCtrl_Albus.dEX, x, y);
					}
					else if (this.playerCtrl6 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl6.aTK / 3f, this.playerCtrl6.dEX, x, y);
					}
					else if (this.playerCtrl7 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl7.aTK / 3f, this.playerCtrl7.dEX, x, y);
					}
					else if (this.playerCtrl8 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl8.aTK / 3f, this.playerCtrl8.dEX, x, y);
					}
					else if (this.playerCtrl9 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl9.aTK / 3f, this.playerCtrl9.dEX, x, y);
					}
					else if (this.playerCtrl10 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl10.aTK / 3f, this.playerCtrl10.dEX, x, y);
					}
					else if (this.playerCtrl11 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl11.aTK / 3f, this.playerCtrl11.dEX, x, y);
					}
					else if (this.playerCtrl12 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl12.aTK / 3f, this.playerCtrl12.dEX, x, y);
					}
					else if (this.playerCtrl13 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl13.aTK / 3f, this.playerCtrl13.dEX, x, y);
					}
					else if (this.playerCtrl14 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl14.aTK / 3f, this.playerCtrl14.dEX, x, y);
					}
					else if (this.playerCtrl15 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl15.aTK / 3f, this.playerCtrl15.dEX, x, y);
					}
					else if (this.playerCtrl16 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl16.aTK / 3f, this.playerCtrl16.dEX, x, y);
					}
					else if (this.playerCtrl17 != null)
					{
						component.RPCActionDamageSpikeMeiru(this.playerCtrl17.aTK / 3f, this.playerCtrl17.dEX, x, y);
					}
					component.ReciveBoolReturn(this.returnTime, "SpikeMeiru", this.playerNumber);
				}
			}
			else if (other.tag == "EnemyBodyAttackSp")
			{
				EnemyBody component2 = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component2) == 1)
				{
					this.ExpPlus(component2.enemyLevel);
					Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x2 = vector2.x;
					float y2 = vector2.y;
					if (this.playerCtrl != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl.aTK / 3f, this.playerCtrl.dEX, x2, y2);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl_Shanoa.aTK / 3f, this.playerCtrl_Shanoa.dEX, x2, y2);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl_Jonathan.aTK / 3f, this.playerCtrl_Jonathan.dEX, x2, y2);
					}
					else if (this.playerCtrl_Charotte != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl_Charotte.aTK / 3f, this.playerCtrl_Charotte.dEX, x2, y2);
					}
					else if (this.playerCtrl_Albus != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl_Albus.aTK / 3f, this.playerCtrl_Albus.dEX, x2, y2);
					}
					else if (this.playerCtrl6 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl6.aTK / 3f, this.playerCtrl6.dEX, x2, y2);
					}
					else if (this.playerCtrl7 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl7.aTK / 3f, this.playerCtrl7.dEX, x2, y2);
					}
					else if (this.playerCtrl8 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl8.aTK / 3f, this.playerCtrl8.dEX, x2, y2);
					}
					else if (this.playerCtrl9 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl9.aTK / 3f, this.playerCtrl9.dEX, x2, y2);
					}
					else if (this.playerCtrl10 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl10.aTK / 3f, this.playerCtrl10.dEX, x2, y2);
					}
					else if (this.playerCtrl11 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl11.aTK / 3f, this.playerCtrl11.dEX, x2, y2);
					}
					else if (this.playerCtrl12 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl12.aTK / 3f, this.playerCtrl12.dEX, x2, y2);
					}
					else if (this.playerCtrl13 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl13.aTK / 3f, this.playerCtrl13.dEX, x2, y2);
					}
					else if (this.playerCtrl14 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl14.aTK / 3f, this.playerCtrl14.dEX, x2, y2);
					}
					else if (this.playerCtrl15 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl15.aTK / 3f, this.playerCtrl15.dEX, x2, y2);
					}
					else if (this.playerCtrl16 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl16.aTK / 3f, this.playerCtrl16.dEX, x2, y2);
					}
					else if (this.playerCtrl17 != null)
					{
						component2.RPCActionDamageSpikeMeiru(this.playerCtrl17.aTK / 3f, this.playerCtrl17.dEX, x2, y2);
					}
					component2.ReciveBoolReturn(this.returnTime, "SpikeMeiru", this.playerNumber);
				}
			}
			else if (other.tag == "EnemyBodyAttackBoss01")
			{
				Boss01BodyDetect component3 = other.GetComponent<Boss01BodyDetect>();
				EnemyBody component4 = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component4) == 1)
				{
					this.ExpPlus(component3.enemyLevel);
					Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x3 = vector3.x;
					float y3 = vector3.y;
					if (this.playerCtrl != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl.aTK / 3f, this.playerCtrl.dEX, x3, y3);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl_Shanoa.aTK / 3f, this.playerCtrl_Shanoa.dEX, x3, y3);
					}
					else if (this.playerCtrl_Jonathan != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl_Jonathan.aTK / 3f, this.playerCtrl_Jonathan.dEX, x3, y3);
					}
					else if (this.playerCtrl_Charotte != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl_Charotte.aTK / 3f, this.playerCtrl_Charotte.dEX, x3, y3);
					}
					else if (this.playerCtrl_Albus != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl_Albus.aTK / 3f, this.playerCtrl_Albus.dEX, x3, y3);
					}
					else if (this.playerCtrl6 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl6.aTK / 3f, this.playerCtrl6.dEX, x3, y3);
					}
					else if (this.playerCtrl7 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl7.aTK / 3f, this.playerCtrl7.dEX, x3, y3);
					}
					else if (this.playerCtrl8 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl8.aTK / 3f, this.playerCtrl8.dEX, x3, y3);
					}
					else if (this.playerCtrl9 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl9.aTK / 3f, this.playerCtrl9.dEX, x3, y3);
					}
					else if (this.playerCtrl10 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl10.aTK / 3f, this.playerCtrl10.dEX, x3, y3);
					}
					else if (this.playerCtrl11 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl11.aTK / 3f, this.playerCtrl11.dEX, x3, y3);
					}
					else if (this.playerCtrl12 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl12.aTK / 3f, this.playerCtrl12.dEX, x3, y3);
					}
					else if (this.playerCtrl13 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl13.aTK / 3f, this.playerCtrl13.dEX, x3, y3);
					}
					else if (this.playerCtrl14 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl14.aTK / 3f, this.playerCtrl14.dEX, x3, y3);
					}
					else if (this.playerCtrl15 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl15.aTK / 3f, this.playerCtrl15.dEX, x3, y3);
					}
					else if (this.playerCtrl16 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl16.aTK / 3f, this.playerCtrl16.dEX, x3, y3);
					}
					else if (this.playerCtrl17 != null)
					{
						component3.ActionDamageSpikeMeiru(this.playerCtrl17.aTK / 3f, this.playerCtrl17.dEX, x3, y3);
					}
					component4.ReciveBoolReturn(this.returnTime, "SpikeMeiru", this.playerNumber);
				}
			}
		}

		// Token: 0x06002B47 RID: 11079 RVA: 0x0048C6B8 File Offset: 0x0048A8B8
		private void Update()
		{
			if (this.playerStatus == null)
			{
				this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			}
			if (this.playerCtrl != null && this.playerNumber != this.playerCtrl.playerNumber)
			{
				this.playerNumber = this.playerCtrl.playerNumber;
			}
			if (this.playerCtrl_Shanoa != null && this.playerNumber != this.playerCtrl_Shanoa.playerNumber)
			{
				this.playerNumber = this.playerCtrl_Shanoa.playerNumber;
			}
			if (this.playerCtrl_Jonathan != null && this.playerNumber != this.playerCtrl_Jonathan.playerNumber)
			{
				this.playerNumber = this.playerCtrl_Jonathan.playerNumber;
			}
			if (this.playerCtrl_Charotte != null && this.playerNumber != this.playerCtrl_Charotte.playerNumber)
			{
				this.playerNumber = this.playerCtrl_Charotte.playerNumber;
			}
			if (this.playerCtrl_Albus != null && this.playerNumber != this.playerCtrl_Albus.playerNumber)
			{
				this.playerNumber = this.playerCtrl_Albus.playerNumber;
			}
			if (this.playerCtrl6 != null && this.playerNumber != this.playerCtrl6.playerNumber)
			{
				this.playerNumber = this.playerCtrl6.playerNumber;
			}
			if (this.playerCtrl7 != null && this.playerNumber != this.playerCtrl7.playerNumber)
			{
				this.playerNumber = this.playerCtrl7.playerNumber;
			}
			if (this.playerCtrl8 != null && this.playerNumber != this.playerCtrl8.playerNumber)
			{
				this.playerNumber = this.playerCtrl8.playerNumber;
			}
			if (this.playerCtrl9 != null && this.playerNumber != this.playerCtrl9.playerNumber)
			{
				this.playerNumber = this.playerCtrl9.playerNumber;
			}
			if (this.playerCtrl10 != null && this.playerNumber != this.playerCtrl10.playerNumber)
			{
				this.playerNumber = this.playerCtrl10.playerNumber;
			}
			if (this.playerCtrl11 != null && this.playerNumber != this.playerCtrl11.playerNumber)
			{
				this.playerNumber = this.playerCtrl11.playerNumber;
			}
			if (this.playerCtrl12 != null && this.playerNumber != this.playerCtrl12.playerNumber)
			{
				this.playerNumber = this.playerCtrl12.playerNumber;
			}
			if (this.playerCtrl13 != null && this.playerNumber != this.playerCtrl13.playerNumber)
			{
				this.playerNumber = this.playerCtrl13.playerNumber;
			}
			if (this.playerCtrl14 != null && this.playerNumber != this.playerCtrl14.playerNumber)
			{
				this.playerNumber = this.playerCtrl14.playerNumber;
			}
			if (this.playerCtrl15 != null && this.playerNumber != this.playerCtrl15.playerNumber)
			{
				this.playerNumber = this.playerCtrl15.playerNumber;
			}
			if (this.playerCtrl16 != null && this.playerNumber != this.playerCtrl16.playerNumber)
			{
				this.playerNumber = this.playerCtrl16.playerNumber;
			}
			if (this.playerCtrl17 != null && this.playerNumber != this.playerCtrl17.playerNumber)
			{
				this.playerNumber = this.playerCtrl17.playerNumber;
			}
		}

		// Token: 0x06002B48 RID: 11080 RVA: 0x0048CAA4 File Offset: 0x0048ACA4
		private int ReturnBool(int num, EnemyBody targetEnemyBody)
		{
			int num2 = 0;
			switch (num)
			{
			case 1:
				if (!targetEnemyBody.canRecive_SpikeMeiru)
				{
					num2++;
				}
				break;
			case 2:
				if (!targetEnemyBody.canRecive_SpikeMeiru1)
				{
					num2++;
				}
				break;
			case 3:
				if (!targetEnemyBody.canRecive_SpikeMeiru2)
				{
					num2++;
				}
				break;
			case 4:
				if (!targetEnemyBody.canRecive_SpikeMeiru3)
				{
					num2++;
				}
				break;
			case 5:
				if (!targetEnemyBody.canRecive_SpikeMeiru4)
				{
					num2++;
				}
				break;
			case 6:
				if (!targetEnemyBody.canRecive_SpikeMeiru5)
				{
					num2++;
				}
				break;
			case 7:
				if (!targetEnemyBody.canRecive_SpikeMeiru6)
				{
					num2++;
				}
				break;
			case 8:
				if (!targetEnemyBody.canRecive_SpikeMeiru7)
				{
					num2++;
				}
				break;
			case 9:
				if (!targetEnemyBody.canRecive_SpikeMeiru8)
				{
					num2++;
				}
				break;
			case 10:
				if (!targetEnemyBody.canRecive_SpikeMeiru9)
				{
					num2++;
				}
				break;
			}
			return num2;
		}

		// Token: 0x06002B49 RID: 11081 RVA: 0x0048CBB4 File Offset: 0x0048ADB4
		private void ExpPlus(int lvl)
		{
			if ((this.playerCtrl != null || this.playerCtrl_Jonathan != null || this.playerCtrl8 != null || this.playerCtrl11 != null) && this.myPV.isMine)
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

		// Token: 0x04005207 RID: 20999
		private PlayerStatus playerStatus;

		// Token: 0x04005208 RID: 21000
		private PhotonView myPV;

		// Token: 0x04005209 RID: 21001
		private PlayerController playerCtrl;

		// Token: 0x0400520A RID: 21002
		private PlayerController_Shanoa playerCtrl_Shanoa;

		// Token: 0x0400520B RID: 21003
		private PlayerController_Jonathan playerCtrl_Jonathan;

		// Token: 0x0400520C RID: 21004
		private PlayerController_Charotte playerCtrl_Charotte;

		// Token: 0x0400520D RID: 21005
		private PlayerController_Albus playerCtrl_Albus;

		// Token: 0x0400520E RID: 21006
		private PlayerController_Soma playerCtrl6;

		// Token: 0x0400520F RID: 21007
		private PlayerController_Alucard playerCtrl7;

		// Token: 0x04005210 RID: 21008
		private PlayerController_Julius playerCtrl8;

		// Token: 0x04005211 RID: 21009
		private PlayerController_Yoko playerCtrl9;

		// Token: 0x04005212 RID: 21010
		private PlayerController_Maria playerCtrl10;

		// Token: 0x04005213 RID: 21011
		private PlayerController_Simon playerCtrl11;

		// Token: 0x04005214 RID: 21012
		private PlayerController_Fuma playerCtrl12;

		// Token: 0x04005215 RID: 21013
		private PlayerController_Add1 playerCtrl13;

		// Token: 0x04005216 RID: 21014
		private PlayerController_Add2 playerCtrl14;

		// Token: 0x04005217 RID: 21015
		private PlayerController_Add3 playerCtrl15;

		// Token: 0x04005218 RID: 21016
		private PlayerController_Add4 playerCtrl16;

		// Token: 0x04005219 RID: 21017
		private PlayerController_Add5 playerCtrl17;

		// Token: 0x0400521A RID: 21018
		public int playerNumber;

		// Token: 0x0400521B RID: 21019
		public float returnTime = 0.3f;
	}
}
