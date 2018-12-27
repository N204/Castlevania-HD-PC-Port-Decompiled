using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000403 RID: 1027
	public class CharotteTrackingMagic : MonoBehaviour
	{
		// Token: 0x060025A8 RID: 9640 RVA: 0x0037B54C File Offset: 0x0037974C
		private void Awake()
		{
			this.myPV = base.transform.parent.GetComponent<PhotonView>();
			if (this.playerCtrl_Soma == null)
			{
				this.playerCtrl_Charotte = base.transform.parent.GetComponent<PlayerController_Charotte>();
			}
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
			this.col2d = base.transform.Find("AttackCol").GetComponent<CircleCollider2D>();
		}

		// Token: 0x060025A9 RID: 9641 RVA: 0x0037B5C6 File Offset: 0x003797C6
		private void Start()
		{
			if (this.myPV.isMine)
			{
				this.mineSw = 1;
			}
		}

		// Token: 0x060025AA RID: 9642 RVA: 0x0037B5E0 File Offset: 0x003797E0
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody" || other.tag == "EnemyBodyAttackSp" || other.tag == "EnemyBodyAttackBoss01")
			{
				this.hited = true;
				this.targetObj = other.gameObject;
				this.moveX = other.transform.position.x;
				this.moveY = other.transform.position.y;
				this.targetPos = other.transform;
			}
		}

		// Token: 0x060025AB RID: 9643 RVA: 0x0037B694 File Offset: 0x00379894
		private void Action()
		{
			bool flag = this.hited;
			if (!flag)
			{
				if (!flag)
				{
					int num = this.val;
					if (num != 1)
					{
						if (num == 2)
						{
							if (this.playerCtrl_Charotte != null)
							{
								this.instantiateManager.PlayerCurseChaiser(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.playerCtrl_Charotte.playerNumber, this.playerCtrl_Charotte.lvlCurseChaiser, this.mineSw, this.targetPos);
							}
							if (this.playerCtrl_Soma != null)
							{
								this.instantiateManager.PlayerCurseChaiser(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.playerCtrl_Soma.playerNumber, this.playerCtrl_Soma.lvlDurahan, this.mineSw, this.targetPos);
							}
						}
					}
					else
					{
						if (this.playerCtrl_Charotte != null)
						{
							this.instantiateManager.PlayerEnergyLight(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.playerCtrl_Charotte.playerNumber, this.playerCtrl_Charotte.lvlEnergyLight, this.mineSw, this.playerCtrl_Charotte.gameObject);
						}
						if (this.playerCtrl_Soma != null)
						{
							this.instantiateManager.PlayerEnergyLight(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.playerCtrl_Soma.playerNumber, this.playerCtrl_Soma.lvlMajo, this.mineSw, this.playerCtrl_Soma.gameObject);
						}
					}
				}
			}
			else
			{
				int num2 = this.val;
				if (num2 != 1)
				{
					if (num2 == 2)
					{
						if (this.playerCtrl_Charotte != null)
						{
							this.instantiateManager.PlayerCurseChaiser(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.playerCtrl_Charotte.playerNumber, this.playerCtrl_Charotte.lvlCurseChaiser, this.mineSw, this.targetPos);
						}
						if (this.playerCtrl_Soma != null)
						{
							this.instantiateManager.PlayerCurseChaiser(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.playerCtrl_Soma.playerNumber, this.playerCtrl_Soma.lvlDurahan, this.mineSw, this.targetPos);
						}
					}
				}
				else
				{
					if (this.playerCtrl_Charotte != null)
					{
						this.instantiateManager.PlayerEnergyLight(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.playerCtrl_Charotte.playerNumber, this.playerCtrl_Charotte.lvlEnergyLight, this.mineSw, this.targetObj);
					}
					if (this.playerCtrl_Soma != null)
					{
						this.instantiateManager.PlayerEnergyLight(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.playerCtrl_Soma.playerNumber, this.playerCtrl_Soma.lvlMajo, this.mineSw, this.targetObj);
					}
				}
			}
			base.gameObject.SetActive(false);
		}

		// Token: 0x060025AC RID: 9644 RVA: 0x0037BAAC File Offset: 0x00379CAC
		public void GoActiveCol()
		{
			this.targetPos = base.transform;
			this.targetObj = null;
			this.send = false;
			this.hited = false;
			this.moveX = 0f;
			this.moveY = 0f;
			this.timer = 0f;
			base.Invoke("Action", 0.1f);
		}

		// Token: 0x040043CB RID: 17355
		private InstantiateManager instantiateManager;

		// Token: 0x040043CC RID: 17356
		private PlayerController_Charotte playerCtrl_Charotte;

		// Token: 0x040043CD RID: 17357
		public PlayerController_Soma playerCtrl_Soma;

		// Token: 0x040043CE RID: 17358
		private PhotonView myPV;

		// Token: 0x040043CF RID: 17359
		private CircleCollider2D col2d;

		// Token: 0x040043D0 RID: 17360
		public GameObject targetObj;

		// Token: 0x040043D1 RID: 17361
		public Transform targetPos;

		// Token: 0x040043D2 RID: 17362
		public Transform muzzle;

		// Token: 0x040043D3 RID: 17363
		public float moveX;

		// Token: 0x040043D4 RID: 17364
		public float moveY;

		// Token: 0x040043D5 RID: 17365
		public float timer;

		// Token: 0x040043D6 RID: 17366
		public bool colActive;

		// Token: 0x040043D7 RID: 17367
		public bool hited;

		// Token: 0x040043D8 RID: 17368
		public int mineSw;

		// Token: 0x040043D9 RID: 17369
		public bool send;

		// Token: 0x040043DA RID: 17370
		public int val;
	}
}
