using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000201 RID: 513
	public class ArrowArmorDead : MonoBehaviour
	{
		// Token: 0x06000DF1 RID: 3569 RVA: 0x00098CBF File Offset: 0x00096EBF
		private void Start()
		{
			this.enemyArrowArmor = base.transform.parent.GetComponent<EnemyArrowArmor>();
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x00098CD8 File Offset: 0x00096ED8
		private void Update()
		{
			if (this.enemyArrowArmor.dead && !this.goVelo)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(1f, 7f));
				this.goVelo = true;
			}
		}

		// Token: 0x040012CC RID: 4812
		private EnemyArrowArmor enemyArrowArmor;

		// Token: 0x040012CD RID: 4813
		public bool goVelo;
	}
}
