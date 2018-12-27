using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020002ED RID: 749
	public class BalowGrando : MagicMain
	{
		// Token: 0x06001779 RID: 6009 RVA: 0x0011F73A File Offset: 0x0011D93A
		protected override void Awake()
		{
			base.Awake();
			this.eSe = base.GetComponent<EnemySoundEffect>();
		}

		// Token: 0x0600177A RID: 6010 RVA: 0x0011F750 File Offset: 0x0011D950
		private void Update()
		{
			this.timer += Time.deltaTime;
			if (!this.destroyCheck)
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
			if (this.timer > 10f && !this.destroyCheck)
			{
				this.DestroyCall();
				this.destroyCheck = true;
			}
			if (this.grounded && !this.destroyCheck)
			{
				this.DestroyCall();
				this.destroyCheck = true;
			}
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x0600177C RID: 6012 RVA: 0x0011F854 File Offset: 0x0011DA54
		public void Action()
		{
			this.timer = 0f;
			this.grounded = false;
			this.destroyCheck = false;
			this.eSe.SoundEffectPlay(0);
			foreach (ParticleSystem particleSystem in this.targetParticle)
			{
				particleSystem.Play();
			}
			this.col2d.enabled = true;
		}

		// Token: 0x0600177D RID: 6013 RVA: 0x0011F8B8 File Offset: 0x0011DAB8
		public void DestroyCall()
		{
			this.col2d.enabled = false;
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
			foreach (ParticleSystem particleSystem in this.targetParticle)
			{
				particleSystem.Stop();
			}
			base.Invoke("GameObjectFalse", 1f);
		}

		// Token: 0x0600177E RID: 6014 RVA: 0x0011F92E File Offset: 0x0011DB2E
		public void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04002221 RID: 8737
		public InstantiateManager instantiateManager;

		// Token: 0x04002222 RID: 8738
		private EnemySoundEffect eSe;

		// Token: 0x04002223 RID: 8739
		public bool destroyCheck;

		// Token: 0x04002224 RID: 8740
		public int level;

		// Token: 0x04002225 RID: 8741
		public float timer;

		// Token: 0x04002226 RID: 8742
		public ParticleSystem[] targetParticle;

		// Token: 0x04002227 RID: 8743
		public CircleCollider2D col2d;
	}
}
