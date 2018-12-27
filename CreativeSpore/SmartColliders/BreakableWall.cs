using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020004E5 RID: 1253
	public class BreakableWall : MonoBehaviour
	{
		// Token: 0x06003098 RID: 12440 RVA: 0x005A8B00 File Offset: 0x005A6D00
		private void Awake()
		{
			this.eSE = base.GetComponent<EnemySoundEffect>();
			this.animator = base.GetComponent<Animator>();
			this.instantPos = base.transform.Find("InstantPos").gameObject;
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
		}

		// Token: 0x06003099 RID: 12441 RVA: 0x005A8B58 File Offset: 0x005A6D58
		private void OnTriggerEnter2D(Collider2D other)
		{
			if ((other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && !this.hitLimit)
			{
				this.animator.SetTrigger("Dust");
				this.breakCount++;
				this.timer = 0f;
				this.hitLimit = true;
			}
		}

		// Token: 0x0600309A RID: 12442 RVA: 0x005A8D44 File Offset: 0x005A6F44
		private void Update()
		{
			if (this.breakCount >= 3)
			{
				if (this.targetSprtie != null && this.targetSprtie.color.a != 0f)
				{
					this.targetSprtie.color = new Color(1f, 1f, 1f, -1f * Time.deltaTime);
				}
				if (!this.destroyCheck)
				{
					this.InstantStone();
					this.animator.SetTrigger("Break");
					if (this.veloDir == 0)
					{
						string text = this.itemName;
						switch (text)
						{
						case "Niku":
							this.instantiateManager.Item14(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 0);
							break;
						case "StrawBerryDounat":
							this.instantiateManager.Item33(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 0);
							break;
						case "Kissyu":
							this.instantiateManager.Item25(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 0);
							break;
						case "UmaiNiku":
							this.instantiateManager.Item12(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 0);
							break;
						case "BonresuHam":
							this.instantiateManager.Item44(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 1);
							break;
						case "RostBeef":
							this.instantiateManager.Item54(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 1);
							break;
						case "Raamen":
							this.instantiateManager.Item51(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 0);
							break;
						case "Karee":
							this.instantiateManager.Item22(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 0);
							break;
						case "KiuiFurute":
							this.instantiateManager.Item24(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 0);
							break;
						case "Esukarugo":
							this.instantiateManager.Item17(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 0);
							break;
						case "Sabitakandume":
							this.instantiateManager.Item58(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 0);
							break;
						case "MangoMuusuCake":
							this.instantiateManager.Item46(this.instantPos.transform.position.x, this.instantPos.transform.position.y, 0);
							break;
						}
						this.destroyCheck = true;
					}
					else if (this.veloDir >= 1)
					{
						int dirVal = 0;
						if (this.veloDir == 2)
						{
							dirVal = 1;
						}
						string text2 = this.itemName;
						switch (text2)
						{
						case "Niku":
							this.instantiateManager.Item14(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						case "StrawBerryDounat":
							this.instantiateManager.Item33(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						case "Kissyu":
							this.instantiateManager.Item25(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						case "UmaiNiku":
							this.instantiateManager.Item12(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						case "BonresuHam":
							this.instantiateManager.Item44(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						case "RostBeef":
							this.instantiateManager.Item54(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						case "Raamen":
							this.instantiateManager.Item51(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						case "Karee":
							this.instantiateManager.Item22(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						case "KiuiFurute":
							this.instantiateManager.Item24(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						case "Esukarugo":
							this.instantiateManager.Item17(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						case "Sabitakandume":
							this.instantiateManager.Item58(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						case "MangoMuusuCake":
							this.instantiateManager.Item46(this.instantPos.transform.position.x, this.instantPos.transform.position.y, dirVal);
							break;
						}
						this.destroyCheck = true;
					}
				}
			}
			if (this.hitLimit)
			{
				this.timer += Time.deltaTime;
				if (this.timer >= 0.2f)
				{
					this.hitLimit = false;
				}
			}
		}

		// Token: 0x0600309B RID: 12443 RVA: 0x005A96C0 File Offset: 0x005A78C0
		private void InstantStone()
		{
			if (this.muzzle != null)
			{
				for (int i = 1; i <= 10; i++)
				{
					int num = UnityEngine.Random.Range(0, 1);
					if (num != 0)
					{
						if (num == 1)
						{
							this.instantiateManager.BreakStone(this.muzzle.transform.position.x + UnityEngine.Random.Range(-this.randomX, this.randomX), this.muzzle.transform.position.y + UnityEngine.Random.Range(-this.randomY, this.randomY), this.type, this.size, this.sprite2, 1);
						}
					}
					else
					{
						this.instantiateManager.BreakStone(this.muzzle.transform.position.x + UnityEngine.Random.Range(-this.randomX, this.randomX), this.muzzle.transform.position.y + UnityEngine.Random.Range(-this.randomY, this.randomY), this.type, this.size, this.sprite1, 1);
					}
				}
			}
		}

		// Token: 0x0600309C RID: 12444 RVA: 0x005A9804 File Offset: 0x005A7A04
		public void InstanceDust()
		{
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
			if (this.breakCount < 3)
			{
				this.eSE.SoundEffectPlay(0);
			}
		}

		// Token: 0x0600309D RID: 12445 RVA: 0x005A9918 File Offset: 0x005A7B18
		public void Reset()
		{
			this.animator.ResetTrigger("Break");
			this.animator.Play(this.animName, 0, 0f);
			this.destroyCheck = false;
			this.breakCount = 0;
			this.timer = 0f;
		}

		// Token: 0x04006198 RID: 24984
		public GameObject muzzle;

		// Token: 0x04006199 RID: 24985
		public float randomX;

		// Token: 0x0400619A RID: 24986
		public float randomY;

		// Token: 0x0400619B RID: 24987
		public int type;

		// Token: 0x0400619C RID: 24988
		public float size;

		// Token: 0x0400619D RID: 24989
		public int breakCount;

		// Token: 0x0400619E RID: 24990
		public bool destroyCheck;

		// Token: 0x0400619F RID: 24991
		public bool hitLimit;

		// Token: 0x040061A0 RID: 24992
		public float timer;

		// Token: 0x040061A1 RID: 24993
		private GameObject instantPos;

		// Token: 0x040061A2 RID: 24994
		public string animName;

		// Token: 0x040061A3 RID: 24995
		private InstantiateManager instantiateManager;

		// Token: 0x040061A4 RID: 24996
		[NonSerialized]
		public Animator animator;

		// Token: 0x040061A5 RID: 24997
		public string itemName;

		// Token: 0x040061A6 RID: 24998
		private EnemySoundEffect eSE;

		// Token: 0x040061A7 RID: 24999
		public Sprite sprite1;

		// Token: 0x040061A8 RID: 25000
		public Sprite sprite2;

		// Token: 0x040061A9 RID: 25001
		public SpriteRenderer targetSprtie;

		// Token: 0x040061AA RID: 25002
		public int veloDir;
	}
}
