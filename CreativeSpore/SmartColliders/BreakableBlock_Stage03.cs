using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000508 RID: 1288
	public class BreakableBlock_Stage03 : MonoBehaviour
	{
		// Token: 0x06003152 RID: 12626 RVA: 0x005B8DC8 File Offset: 0x005B6FC8
		private void Awake()
		{
			this.boxcol2d3 = base.transform.Find("BodyCol").GetComponent<BoxCollider2D>();
			this.boxcol2d = base.transform.Find("TriggerCol").GetComponent<BoxCollider2D>();
			this.boxcol2d.isTrigger = base.enabled;
			this.animator = base.GetComponent<Animator>();
			this.instantPos = base.transform.Find("InstantPos").gameObject;
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
		}

		// Token: 0x06003153 RID: 12627 RVA: 0x005B8E58 File Offset: 0x005B7058
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" && (other.name == "Neck" || other.name == "HeadUp" || other.name == "HeadDown" || other.name == "Ago" || other.name == "Hip" || other.name == "West" || other.name == "Chest" || other.name == "ArmUp_Front" || other.name == "ArmDown_Front" || other.name == "Hand_Front" || other.name == "ArmUp_Back" || other.name == "ArmDown_Back" || other.name == "Hand_Back" || other.name == "Instep_Front" || other.name == "FootUp_Front" || other.name == "FootDown_Front" || other.name == "Instep_Back" || other.name == "FootUp_Back" || other.name == "FootDown_Back") && !this.check)
			{
				if (this.bigCol2d != null && this.bigCol2d.enabled)
				{
					this.bigCol2d.enabled = false;
				}
				this.animator.SetTrigger("Break");
				this.check = true;
			}
		}

		// Token: 0x06003154 RID: 12628 RVA: 0x005B9058 File Offset: 0x005B7258
		private void Update()
		{
			if (this.boxcol2d2 != null && !this.boxcol2d3.enabled && this.boxcol2d2.enabled)
			{
				this.boxcol2d2.enabled = false;
			}
		}

		// Token: 0x06003155 RID: 12629 RVA: 0x005B9098 File Offset: 0x005B7298
		public void InstanceDust()
		{
			this.instantiateManager.BreakStone(this.instantPos.transform.position.x + UnityEngine.Random.Range(-0.3f, 0.3f), this.instantPos.transform.position.y + UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(1, 3), 2f, this.sprite1, 1);
			this.instantiateManager.BreakStone(this.instantPos.transform.position.x + UnityEngine.Random.Range(-0.3f, 0.3f), this.instantPos.transform.position.y + UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(1, 3), 2f, this.sprite2, 1);
			this.instantiateManager.BreakStone(this.instantPos.transform.position.x + UnityEngine.Random.Range(-0.3f, 0.3f), this.instantPos.transform.position.y + UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(1, 3), 2f, this.sprite1, 1);
			this.instantiateManager.BreakStone(this.instantPos.transform.position.x + UnityEngine.Random.Range(-0.3f, 0.3f), this.instantPos.transform.position.y + UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(1, 3), 2f, this.sprite2, 1);
			int i = 1;
			while (i <= 30)
			{
				int num = UnityEngine.Random.Range(0, 10);
				if (num < 5)
				{
					this.instantiateManager.Dust(this.instantPos.transform.position.x + UnityEngine.Random.Range(-0.3f, 0.3f), this.instantPos.transform.position.y + UnityEngine.Random.Range(-0.5f, 0.5f));
					i++;
				}
				else if (num >= 5)
				{
					this.instantiateManager.Dust2(this.instantPos.transform.position.x + UnityEngine.Random.Range(-0.3f, 0.3f), this.instantPos.transform.position.y + UnityEngine.Random.Range(-0.5f, 0.5f));
					i++;
				}
			}
		}

		// Token: 0x06003156 RID: 12630 RVA: 0x005B9360 File Offset: 0x005B7560
		public void Reset()
		{
			if (this.bigCol2d != null && !this.bigCol2d.enabled)
			{
				this.bigCol2d.enabled = true;
			}
			if (this.boxcol2d2 != null && !this.boxcol2d2.enabled)
			{
				this.boxcol2d2.enabled = true;
			}
			this.animator.ResetTrigger("Break");
			this.animator.Play("BreakableBlock_Stage03_Idle", 0, 0f);
			this.check = false;
		}

		// Token: 0x0400630D RID: 25357
		private Animator animator;

		// Token: 0x0400630E RID: 25358
		public bool check;

		// Token: 0x0400630F RID: 25359
		private InstantiateManager instantiateManager;

		// Token: 0x04006310 RID: 25360
		private GameObject instantPos;

		// Token: 0x04006311 RID: 25361
		private BoxCollider2D boxcol2d;

		// Token: 0x04006312 RID: 25362
		public BoxCollider2D boxcol2d2;

		// Token: 0x04006313 RID: 25363
		private BoxCollider2D boxcol2d3;

		// Token: 0x04006314 RID: 25364
		public BoxCollider2D bigCol2d;

		// Token: 0x04006315 RID: 25365
		public Sprite sprite1;

		// Token: 0x04006316 RID: 25366
		public Sprite sprite2;
	}
}
