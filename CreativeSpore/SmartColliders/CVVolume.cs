using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000622 RID: 1570
	public class CVVolume : MonoBehaviour
	{
		// Token: 0x060037CE RID: 14286 RVA: 0x00686ADA File Offset: 0x00684CDA
		private void Awake()
		{
			this.audioSource = base.GetComponent<AudioSource>();
			this.bgmWorks = GameObject.Find("BGM").GetComponent<BGMWorks>();
		}

		// Token: 0x060037CF RID: 14287 RVA: 0x00686AFD File Offset: 0x00684CFD
		private void Start()
		{
			this.audioSource.volume = this.bgmWorks.cVVolume;
		}

		// Token: 0x060037D0 RID: 14288 RVA: 0x00686B18 File Offset: 0x00684D18
		private void FixedUpdate()
		{
			if (this.bgmWorks == null)
			{
				this.bgmWorks = GameObject.Find("BGM").GetComponent<BGMWorks>();
			}
			if (this.bgmWorks != null && this.audioSource.volume != this.bgmWorks.cVVolume)
			{
				this.audioSource.volume = this.bgmWorks.cVVolume;
			}
		}

		// Token: 0x04007491 RID: 29841
		private AudioSource audioSource;

		// Token: 0x04007492 RID: 29842
		private BGMWorks bgmWorks;
	}
}
