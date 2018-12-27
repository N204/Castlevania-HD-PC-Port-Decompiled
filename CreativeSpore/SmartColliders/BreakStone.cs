using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200050C RID: 1292
	public class BreakStone : MonoBehaviour
	{
		// Token: 0x06003165 RID: 12645 RVA: 0x005B9E0C File Offset: 0x005B800C
		private void Awake()
		{
			this.rigid2d = base.GetComponent<Rigidbody2D>();
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
			this.groundCheck_R = base.transform.Find("GroundCheck_R");
			this.groundCheck_C = base.transform.Find("GroundCheck_C");
			this.groundCheck_L = base.transform.Find("GroundCheck_L");
			this.groundCheckCollider[0] = new Collider2D[16];
			this.groundCheckCollider[1] = new Collider2D[16];
			this.groundCheckCollider[2] = new Collider2D[16];
		}

		// Token: 0x06003166 RID: 12646 RVA: 0x005B9EAC File Offset: 0x005B80AC
		private void Update()
		{
			if (this.grounded && !this.destroyCheck)
			{
				this.InstanceDust();
				this.GameObjectFalse();
				this.destroyCheck = true;
			}
			if (!this.grounded)
			{
				this.timer += Time.deltaTime;
				if (this.timer > 10f && !this.destroyCheck)
				{
					this.InstanceDust();
					this.GameObjectFalse();
					this.destroyCheck = true;
				}
			}
		}

		// Token: 0x06003167 RID: 12647 RVA: 0x005B9F30 File Offset: 0x005B8130
		private void FixedUpdate()
		{
			this.grounded = false;
			this.gccMax[0] = Physics2D.OverlapPointNonAlloc(this.groundCheck_L.position, this.groundCheckCollider[0]);
			this.gccMax[1] = Physics2D.OverlapPointNonAlloc(this.groundCheck_C.position, this.groundCheckCollider[1]);
			this.gccMax[2] = Physics2D.OverlapPointNonAlloc(this.groundCheck_R.position, this.groundCheckCollider[2]);
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < this.gccMax[i]; j++)
				{
					if (this.groundCheckCollider[i][j] != null && !this.groundCheckCollider[i][j].isTrigger && (this.groundCheckCollider[i][j].tag == "Road" || this.groundCheckCollider[i][j].tag == "Slope" || this.groundCheckCollider[i][j].tag == "EventGround"))
					{
						this.grounded = true;
					}
				}
			}
		}

		// Token: 0x06003168 RID: 12648 RVA: 0x005BA068 File Offset: 0x005B8268
		public void Action()
		{
			this.grounded = false;
			this.timer = 0f;
			this.destroyCheck = false;
			base.transform.localScale = new Vector2(this.size, this.size);
			this.rigid2d.angularVelocity = (float)UnityEngine.Random.Range(-100, 100);
			switch (this.val)
			{
			case 1:
				this.rigid2d.velocity = new Vector2((float)UnityEngine.Random.Range(-2, 2), (float)UnityEngine.Random.Range(2, 5));
				break;
			case 2:
				this.rigid2d.velocity = new Vector2((float)UnityEngine.Random.Range(2, 5), (float)UnityEngine.Random.Range(-2, 2));
				break;
			case 3:
				this.rigid2d.velocity = new Vector2((float)UnityEngine.Random.Range(-2, -5), (float)UnityEngine.Random.Range(-2, 2));
				break;
			case 4:
				this.rigid2d.velocity = new Vector2((float)UnityEngine.Random.Range(-5, 5), (float)UnityEngine.Random.Range(1, 10));
				break;
			case 5:
				this.rigid2d.velocity = new Vector2((float)UnityEngine.Random.Range(-2, 2), (float)UnityEngine.Random.Range(-2, -5));
				break;
			case 6:
				this.rigid2d.velocity = new Vector2((float)UnityEngine.Random.Range(1, 5), (float)UnityEngine.Random.Range(1, 5));
				break;
			case 7:
				this.rigid2d.velocity = new Vector2((float)UnityEngine.Random.Range(-1, -5), (float)UnityEngine.Random.Range(1, 5));
				break;
			}
			if (this.type == 3)
			{
				this.startPS.Play();
			}
		}

		// Token: 0x06003169 RID: 12649 RVA: 0x005BA21C File Offset: 0x005B841C
		private void InstanceDust()
		{
			int num = this.type;
			if (num != 1)
			{
				if (num != 2)
				{
					if (num == 3)
					{
						this.instantiateManager.BloodEffect2(base.transform.position.x, base.transform.position.y);
						if (this.startPS.isPlaying)
						{
							this.startPS.Stop();
						}
					}
				}
				else
				{
					this.instantiateManager.FireEffect(base.transform.position.x, base.transform.position.y);
				}
			}
			else
			{
				int i = 1;
				while (i <= 5)
				{
					int num2 = UnityEngine.Random.Range(0, 10);
					if (num2 < 5)
					{
						this.instantiateManager.Dust(base.transform.position.x + UnityEngine.Random.Range(-0.2f, 0.2f), base.transform.position.y + UnityEngine.Random.Range(-0.2f, 0.2f));
						i++;
					}
					else if (num2 >= 5)
					{
						this.instantiateManager.Dust2(base.transform.position.x + UnityEngine.Random.Range(-0.2f, 0.2f), base.transform.position.y + UnityEngine.Random.Range(-0.2f, 0.2f));
						i++;
					}
				}
			}
		}

		// Token: 0x0600316A RID: 12650 RVA: 0x005BA3B5 File Offset: 0x005B85B5
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04006325 RID: 25381
		public bool grounded;

		// Token: 0x04006326 RID: 25382
		public bool destroyCheck;

		// Token: 0x04006327 RID: 25383
		public int val;

		// Token: 0x04006328 RID: 25384
		public float size;

		// Token: 0x04006329 RID: 25385
		public float timer;

		// Token: 0x0400632A RID: 25386
		public InstantiateManager instantiateManager;

		// Token: 0x0400632B RID: 25387
		private Rigidbody2D rigid2d;

		// Token: 0x0400632C RID: 25388
		public SpriteRenderer spriteRen;

		// Token: 0x0400632D RID: 25389
		public int type;

		// Token: 0x0400632E RID: 25390
		protected Transform groundCheck_R;

		// Token: 0x0400632F RID: 25391
		protected Transform groundCheck_C;

		// Token: 0x04006330 RID: 25392
		protected Transform groundCheck_L;

		// Token: 0x04006331 RID: 25393
		public ParticleSystem startPS;

		// Token: 0x04006332 RID: 25394
		protected Collider2D[][] groundCheckCollider = new Collider2D[3][];

		// Token: 0x04006333 RID: 25395
		protected int[] gccMax = new int[3];
	}
}
