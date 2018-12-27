using System;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200053A RID: 1338
	public class BGMWorks : MonoBehaviour
	{
		// Token: 0x06003245 RID: 12869 RVA: 0x005CD060 File Offset: 0x005CB260
		private void Awake()
		{
			if (!this.testPlayStage)
			{
				this.audioSorce = base.GetComponent<AudioSource>();
				this.myPV = base.GetComponent<PhotonView>();
				this.targetAnim = GameObject.Find("Stage/Stage_UI/Canvas_UI/BGM_Text").GetComponent<Animator>();
				this.text = GameObject.Find("Stage/Stage_UI/Canvas_UI/BGM_Text/BGMNameText").GetComponent<Text>();
				this.settingChange = GameObject.Find("Stage/Stage_UI/SettingChanger").GetComponent<SettingChange>();
			}
		}

		// Token: 0x06003246 RID: 12870 RVA: 0x005CD0D0 File Offset: 0x005CB2D0
		private void Update()
		{
			if (!this.testPlayStage)
			{
				if (PhotonNetwork.isMasterClient && this.cameraCtrl.cameraStart && !this.check)
				{
					this.ChangeBGMCall(this.currentSongNumber);
					this.check = true;
				}
				if (this.introPlayed && !this.audioSorce.isPlaying)
				{
					this.audioSorce.loop = true;
					int num = this.currentSongNumber;
					switch (num)
					{
					case 800:
						this.audioSorce.clip = this.BGM_OTHERS01;
						this.audioSorce.Play();
						break;
					case 801:
						this.audioSorce.clip = this.BGM_OTHERS02;
						this.audioSorce.Stop();
						break;
					case 802:
						this.audioSorce.clip = this.BGM_OOE01;
						this.audioSorce.Stop();
						break;
					case 803:
						this.audioSorce.clip = this.BGM_OOE02;
						this.audioSorce.Stop();
						break;
					case 804:
						this.audioSorce.clip = this.BGM_OOE03;
						this.audioSorce.Stop();
						break;
					case 805:
						this.audioSorce.clip = this.BGM_OOE04;
						this.audioSorce.Stop();
						break;
					case 806:
						this.audioSorce.clip = this.BGM_OOE05;
						this.audioSorce.Stop();
						break;
					case 807:
						this.audioSorce.clip = this.BGM_OOE06;
						this.audioSorce.Play();
						break;
					case 808:
						this.audioSorce.clip = this.BGM_OOE07;
						this.audioSorce.Play();
						break;
					case 809:
						this.audioSorce.clip = this.BGM_OOE08;
						this.audioSorce.Play();
						break;
					case 810:
						this.audioSorce.clip = this.BGM_OOE09;
						this.audioSorce.Play();
						break;
					case 811:
						this.audioSorce.clip = this.BGM_OOE10;
						this.audioSorce.Play();
						break;
					case 812:
						this.audioSorce.clip = this.BGM_OOE11;
						this.audioSorce.Play();
						break;
					case 813:
						this.audioSorce.clip = this.BGM_OOE12;
						this.audioSorce.Play();
						break;
					case 814:
						this.audioSorce.clip = this.BGM_OOE13;
						this.audioSorce.Play();
						break;
					case 815:
						this.audioSorce.clip = this.BGM_OOE14;
						this.audioSorce.Play();
						break;
					case 816:
						this.audioSorce.clip = this.BGM_OOE15;
						this.audioSorce.Play();
						break;
					case 817:
						this.audioSorce.clip = this.BGM_OOE16;
						this.audioSorce.Play();
						break;
					case 818:
						this.audioSorce.clip = this.BGM_OOE17;
						this.audioSorce.Play();
						break;
					case 819:
						this.audioSorce.clip = this.BGM_OOE18;
						this.audioSorce.Play();
						break;
					case 820:
						this.audioSorce.clip = this.BGM_OOE19;
						this.audioSorce.Play();
						break;
					case 821:
						this.audioSorce.clip = this.BGM_OOE20;
						this.audioSorce.Play();
						break;
					case 822:
						this.audioSorce.clip = this.BGM_OOE21;
						this.audioSorce.Play();
						break;
					case 823:
						this.audioSorce.clip = this.BGM_OOE22;
						this.audioSorce.Play();
						break;
					case 824:
						this.audioSorce.clip = this.BGM_OOE23;
						this.audioSorce.Play();
						break;
					case 825:
						this.audioSorce.clip = this.BGM_OOE24;
						this.audioSorce.Play();
						break;
					case 826:
						this.audioSorce.clip = this.BGM_OOE25;
						this.audioSorce.Play();
						break;
					case 827:
						this.audioSorce.clip = this.BGM_OOE26;
						this.audioSorce.Play();
						break;
					case 828:
						this.audioSorce.clip = this.BGM_OOE27;
						this.audioSorce.Play();
						break;
					case 829:
						this.audioSorce.clip = this.BGM_OOE28;
						this.audioSorce.Play();
						break;
					case 830:
						this.audioSorce.clip = this.BGM_OOE29;
						this.audioSorce.Play();
						break;
					case 831:
						this.audioSorce.clip = this.BGM_OOE30;
						this.audioSorce.Play();
						break;
					case 832:
						this.audioSorce.clip = this.BGM_OOE31;
						this.audioSorce.Play();
						break;
					case 833:
						this.audioSorce.clip = this.BGM_OOE32;
						this.audioSorce.Play();
						break;
					case 834:
						this.audioSorce.clip = this.BGM_OOE33;
						this.audioSorce.Play();
						break;
					case 835:
						this.audioSorce.clip = this.BGM_OOE34;
						this.audioSorce.Play();
						break;
					case 836:
						this.audioSorce.clip = this.BGM_OOE35;
						this.audioSorce.Play();
						break;
					case 837:
						this.audioSorce.clip = this.BGM_OOE36;
						this.audioSorce.Play();
						break;
					case 838:
						this.audioSorce.clip = this.BGM_OOE37;
						this.audioSorce.Play();
						break;
					case 839:
						this.audioSorce.clip = this.BGM_OOE38;
						this.audioSorce.Play();
						break;
					case 840:
						this.audioSorce.clip = this.BGM_OOE39;
						this.audioSorce.Play();
						break;
					case 841:
						this.audioSorce.clip = this.BGM_OOE40;
						this.audioSorce.Play();
						break;
					case 842:
						this.audioSorce.clip = this.BGM_OOE41;
						this.audioSorce.Play();
						break;
					case 843:
						this.audioSorce.clip = this.BGM_OOE42;
						this.audioSorce.Play();
						break;
					case 844:
						this.audioSorce.clip = this.BGM_OOE43;
						this.audioSorce.Play();
						break;
					case 845:
						this.audioSorce.clip = this.BGM_OOE44;
						this.audioSorce.Play();
						break;
					case 846:
						this.audioSorce.clip = this.BGM_OOE45;
						this.audioSorce.Play();
						break;
					case 847:
						this.audioSorce.clip = this.BGM_OOE46;
						this.audioSorce.Play();
						break;
					case 848:
						this.audioSorce.clip = this.BGM_OOE47;
						this.audioSorce.Play();
						break;
					case 849:
						this.audioSorce.clip = this.BGM_OOE48;
						this.audioSorce.Play();
						break;
					case 850:
						this.audioSorce.clip = this.BGM_OOE49;
						this.audioSorce.Play();
						break;
					case 851:
						this.audioSorce.clip = this.BGM_OOE50;
						this.audioSorce.Play();
						break;
					case 852:
						this.audioSorce.clip = this.BGM_OOE51;
						this.audioSorce.Play();
						break;
					case 853:
						this.audioSorce.clip = this.BGM_OOE52;
						this.audioSorce.Play();
						break;
					case 854:
						this.audioSorce.clip = this.BGM_OOE53;
						this.audioSorce.Play();
						break;
					case 855:
						this.audioSorce.clip = this.BGM_OOE54;
						this.audioSorce.Play();
						break;
					default:
						switch (num)
						{
						case 400:
							this.audioSorce.clip = this.BGM_SOTN01;
							this.audioSorce.Stop();
							break;
						case 401:
							this.audioSorce.clip = this.BGM_SOTN02;
							this.audioSorce.Play();
							break;
						case 402:
							this.audioSorce.clip = this.BGM_SOTN03;
							this.audioSorce.Play();
							break;
						case 403:
							this.audioSorce.clip = this.BGM_SOTN04;
							this.audioSorce.Stop();
							break;
						case 404:
							this.audioSorce.clip = this.BGM_SOTN05;
							this.audioSorce.Play();
							break;
						case 405:
							this.audioSorce.clip = this.BGM_SOTN06;
							this.audioSorce.Play();
							break;
						case 406:
							this.audioSorce.clip = this.BGM_SOTN07;
							this.audioSorce.Play();
							break;
						case 407:
							this.audioSorce.clip = this.BGM_SOTN08;
							this.audioSorce.Play();
							break;
						case 408:
							this.audioSorce.clip = this.BGM_SOTN09;
							this.audioSorce.Play();
							break;
						case 409:
							this.audioSorce.clip = this.BGM_SOTN10;
							this.audioSorce.Play();
							break;
						case 410:
							this.audioSorce.clip = this.BGM_SOTN11;
							this.audioSorce.Play();
							break;
						case 411:
							this.audioSorce.clip = this.BGM_SOTN12;
							this.audioSorce.Stop();
							break;
						case 412:
							this.audioSorce.clip = this.BGM_SOTN13;
							this.audioSorce.Play();
							break;
						case 413:
							this.audioSorce.clip = this.BGM_SOTN14;
							this.audioSorce.Play();
							break;
						case 414:
							this.audioSorce.clip = this.BGM_SOTN15;
							this.audioSorce.Play();
							break;
						case 415:
							this.audioSorce.clip = this.BGM_SOTN16;
							this.audioSorce.Play();
							break;
						case 416:
							this.audioSorce.clip = this.BGM_SOTN17;
							this.audioSorce.Play();
							break;
						case 417:
							this.audioSorce.clip = this.BGM_SOTN18;
							this.audioSorce.Play();
							break;
						case 418:
							this.audioSorce.clip = this.BGM_SOTN19;
							this.audioSorce.Play();
							break;
						case 419:
							this.audioSorce.clip = this.BGM_SOTN20;
							this.audioSorce.Play();
							break;
						case 420:
							this.audioSorce.clip = this.BGM_SOTN21;
							this.audioSorce.Play();
							break;
						case 421:
							this.audioSorce.clip = this.BGM_SOTN22;
							this.audioSorce.Play();
							break;
						case 422:
							this.audioSorce.clip = this.BGM_SOTN23;
							this.audioSorce.Play();
							break;
						case 423:
							this.audioSorce.clip = this.BGM_SOTN24;
							this.audioSorce.Play();
							break;
						case 424:
							this.audioSorce.clip = this.BGM_SOTN25;
							this.audioSorce.Play();
							break;
						case 425:
							this.audioSorce.clip = this.BGM_SOTN26;
							this.audioSorce.Play();
							break;
						case 426:
							this.audioSorce.clip = this.BGM_SOTN27;
							this.audioSorce.Play();
							break;
						case 427:
							this.audioSorce.clip = this.BGM_SOTN28;
							this.audioSorce.Play();
							break;
						case 428:
							this.audioSorce.clip = this.BGM_SOTN29;
							this.audioSorce.Play();
							break;
						case 429:
							this.audioSorce.clip = this.BGM_SOTN30;
							this.audioSorce.Play();
							break;
						case 430:
							this.audioSorce.clip = this.BGM_SOTN31;
							this.audioSorce.Stop();
							break;
						case 431:
							this.audioSorce.clip = this.BGM_SOTN32;
							this.audioSorce.Play();
							break;
						case 432:
							this.audioSorce.clip = this.BGM_SOTN33;
							this.audioSorce.Play();
							break;
						case 433:
							this.audioSorce.clip = this.BGM_SOTN34;
							this.audioSorce.Play();
							break;
						case 434:
							this.audioSorce.clip = this.BGM_SOTN35;
							this.audioSorce.Play();
							break;
						case 435:
							this.audioSorce.clip = this.BGM_SOTN36;
							this.audioSorce.Play();
							break;
						case 436:
							this.audioSorce.clip = this.BGM_SOTN37;
							this.audioSorce.Stop();
							break;
						case 437:
							this.audioSorce.clip = this.BGM_SOTN38;
							this.audioSorce.Play();
							break;
						case 438:
							this.audioSorce.clip = this.BGM_SOTN39;
							this.audioSorce.Play();
							break;
						case 439:
							this.audioSorce.clip = this.BGM_SOTN40;
							this.audioSorce.Stop();
							break;
						case 440:
							this.audioSorce.clip = this.BGM_SOTN41;
							this.audioSorce.Stop();
							break;
						case 441:
							this.audioSorce.clip = this.BGM_SOTN42;
							this.audioSorce.Stop();
							break;
						case 442:
							this.audioSorce.clip = this.BGM_SOTN43;
							this.audioSorce.Stop();
							break;
						case 443:
							this.audioSorce.clip = this.BGM_SOTN44;
							this.audioSorce.Stop();
							break;
						case 444:
							this.audioSorce.clip = this.BGM_SOTN45;
							this.audioSorce.Play();
							break;
						case 445:
							this.audioSorce.clip = this.BGM_SOTN46;
							this.audioSorce.Play();
							break;
						case 446:
							this.audioSorce.clip = this.BGM_SOTN47;
							this.audioSorce.Play();
							break;
						case 447:
							this.audioSorce.clip = this.BGM_SOTN48;
							this.audioSorce.Play();
							break;
						case 448:
							this.audioSorce.clip = this.BGM_SOTN49;
							this.audioSorce.Stop();
							break;
						default:
							switch (num)
							{
							case 0:
								this.audioSorce.clip = this.BGM_HD01;
								this.audioSorce.Play();
								break;
							case 1:
								this.audioSorce.clip = this.BGM_HD02;
								this.audioSorce.Play();
								break;
							case 2:
								this.audioSorce.clip = this.BGM_HD03;
								this.audioSorce.Play();
								break;
							case 3:
								this.audioSorce.clip = this.BGM_HD04;
								this.audioSorce.Play();
								break;
							case 4:
								this.audioSorce.clip = this.BGM_HD05;
								this.audioSorce.Play();
								break;
							case 5:
								this.audioSorce.clip = this.BGM_HD06;
								this.audioSorce.Play();
								break;
							case 6:
								this.audioSorce.clip = this.BGM_HD07;
								this.audioSorce.Play();
								break;
							case 7:
								this.audioSorce.clip = this.BGM_HD08;
								this.audioSorce.Play();
								break;
							case 8:
								this.audioSorce.clip = this.BGM_HD09;
								this.audioSorce.Play();
								break;
							case 9:
								this.audioSorce.clip = this.BGM_HD10;
								this.audioSorce.Play();
								break;
							case 10:
								this.audioSorce.clip = this.BGM_HD11;
								this.audioSorce.Play();
								break;
							case 11:
								this.audioSorce.clip = this.BGM_HD12;
								this.audioSorce.Play();
								break;
							case 12:
								this.audioSorce.clip = this.BGM_HD13;
								this.audioSorce.Play();
								break;
							case 13:
								this.audioSorce.clip = this.BGM_HD14;
								this.audioSorce.Play();
								break;
							case 14:
								this.audioSorce.clip = this.BGM_HD15;
								this.audioSorce.Play();
								break;
							case 15:
								this.audioSorce.clip = this.BGM_HD16;
								this.audioSorce.Play();
								break;
							case 16:
								this.audioSorce.clip = this.BGM_HD17;
								this.audioSorce.Play();
								break;
							case 17:
								this.audioSorce.clip = this.BGM_HD18;
								this.audioSorce.Play();
								break;
							case 18:
								this.audioSorce.clip = this.BGM_HD19;
								this.audioSorce.Play();
								break;
							case 19:
								this.audioSorce.clip = this.BGM_HD20;
								this.audioSorce.Play();
								break;
							case 20:
								this.audioSorce.clip = this.BGM_HD21;
								this.audioSorce.Play();
								break;
							case 21:
								this.audioSorce.clip = this.BGM_HD22;
								this.audioSorce.Play();
								break;
							case 22:
								this.audioSorce.clip = this.BGM_HD23;
								this.audioSorce.Play();
								break;
							case 23:
								this.audioSorce.clip = this.BGM_HD24;
								this.audioSorce.Play();
								break;
							case 24:
								this.audioSorce.clip = this.BGM_HD25;
								this.audioSorce.Play();
								break;
							case 25:
								this.audioSorce.clip = this.BGM_HD26;
								this.audioSorce.Play();
								break;
							case 26:
								this.audioSorce.clip = this.BGM_HD27;
								this.audioSorce.Play();
								break;
							case 27:
								this.audioSorce.clip = this.BGM_HD28;
								this.audioSorce.Play();
								break;
							case 28:
								this.audioSorce.clip = this.BGM_HD29;
								this.audioSorce.Play();
								break;
							case 29:
								this.audioSorce.clip = this.BGM_HD30;
								this.audioSorce.Play();
								break;
							case 30:
								this.audioSorce.clip = this.BGM_HD31;
								this.audioSorce.Play();
								break;
							case 31:
								this.audioSorce.clip = this.BGM_HD32;
								this.audioSorce.Play();
								break;
							case 32:
								this.audioSorce.clip = this.BGM_HD33;
								this.audioSorce.Play();
								break;
							case 33:
								this.audioSorce.clip = this.BGM_HD34;
								this.audioSorce.Play();
								break;
							case 34:
								this.audioSorce.clip = this.BGM_HD35;
								this.audioSorce.Play();
								break;
							case 35:
								this.audioSorce.clip = this.BGM_GOLDBOX;
								this.audioSorce.Play();
								break;
							default:
								switch (num)
								{
								case 200:
									this.audioSorce.clip = this.BGM_DOS01_Once;
									this.audioSorce.Play();
									break;
								case 201:
									this.audioSorce.clip = this.BGM_DOS02;
									this.audioSorce.Play();
									break;
								case 202:
									this.audioSorce.clip = this.BGM_DOS03;
									this.audioSorce.Play();
									break;
								case 203:
									this.audioSorce.clip = this.BGM_DOS04;
									this.audioSorce.Play();
									break;
								case 204:
									this.audioSorce.clip = this.BGM_DOS05;
									this.audioSorce.Play();
									break;
								case 205:
									this.audioSorce.clip = this.BGM_DOS06;
									this.audioSorce.Play();
									break;
								case 206:
									this.audioSorce.clip = this.BGM_DOS07;
									this.audioSorce.Play();
									break;
								case 207:
									this.audioSorce.clip = this.BGM_DOS08;
									this.audioSorce.Play();
									break;
								case 208:
									this.audioSorce.clip = this.BGM_DOS09;
									this.audioSorce.Play();
									break;
								case 209:
									this.audioSorce.clip = this.BGM_DOS10;
									this.audioSorce.Play();
									break;
								case 210:
									this.audioSorce.clip = this.BGM_DOS11;
									this.audioSorce.Play();
									break;
								case 211:
									this.audioSorce.clip = this.BGM_DOS12;
									this.audioSorce.Play();
									break;
								case 212:
									this.audioSorce.clip = this.BGM_DOS13;
									this.audioSorce.Play();
									break;
								case 213:
									this.audioSorce.clip = this.BGM_DOS14;
									this.audioSorce.Play();
									break;
								case 214:
									this.audioSorce.clip = this.BGM_DOS15;
									this.audioSorce.Play();
									break;
								case 215:
									this.audioSorce.clip = this.BGM_DOS16;
									this.audioSorce.Play();
									break;
								case 216:
									this.audioSorce.clip = this.BGM_DOS17;
									this.audioSorce.Play();
									break;
								case 217:
									this.audioSorce.clip = this.BGM_DOS18;
									this.audioSorce.Play();
									break;
								case 218:
									this.audioSorce.clip = this.BGM_DOS19;
									this.audioSorce.Play();
									break;
								case 219:
									this.audioSorce.clip = this.BGM_DOS20;
									this.audioSorce.Play();
									break;
								case 220:
									this.audioSorce.clip = this.BGM_DOS21;
									this.audioSorce.Play();
									break;
								case 221:
									this.audioSorce.clip = this.BGM_DOS22;
									this.audioSorce.Play();
									break;
								case 222:
									this.audioSorce.clip = this.BGM_DOS23;
									this.audioSorce.Play();
									break;
								case 223:
									this.audioSorce.clip = this.BGM_DOS24;
									this.audioSorce.Play();
									break;
								case 224:
									this.audioSorce.clip = this.BGM_DOS25;
									this.audioSorce.Play();
									break;
								case 225:
									this.audioSorce.clip = this.BGM_DOS26;
									this.audioSorce.Play();
									break;
								case 226:
									this.audioSorce.clip = this.BGM_DOS27;
									this.audioSorce.Play();
									break;
								case 227:
									this.audioSorce.clip = this.BGM_DOS28;
									this.audioSorce.Play();
									break;
								case 228:
									this.audioSorce.clip = this.BGM_DOS29;
									this.audioSorce.Play();
									break;
								case 229:
									this.audioSorce.clip = this.BGM_DOS30;
									this.audioSorce.Play();
									break;
								case 230:
									this.audioSorce.clip = this.BGM_DOS31;
									this.audioSorce.Stop();
									break;
								default:
									switch (num)
									{
									case 300:
										this.audioSorce.clip = this.BGM_AOS01;
										this.audioSorce.Play();
										break;
									case 301:
										this.audioSorce.clip = this.BGM_AOS02;
										this.audioSorce.Play();
										break;
									case 302:
										this.audioSorce.clip = this.BGM_AOS03;
										this.audioSorce.Play();
										break;
									case 303:
										this.audioSorce.clip = this.BGM_AOS04;
										this.audioSorce.Play();
										break;
									case 304:
										this.audioSorce.clip = this.BGM_AOS05;
										this.audioSorce.Play();
										break;
									case 305:
										this.audioSorce.clip = this.BGM_AOS06;
										this.audioSorce.Play();
										break;
									case 306:
										this.audioSorce.clip = this.BGM_AOS07;
										this.audioSorce.Play();
										break;
									case 307:
										this.audioSorce.clip = this.BGM_AOS08;
										this.audioSorce.Play();
										break;
									case 308:
										this.audioSorce.clip = this.BGM_AOS09;
										this.audioSorce.Play();
										break;
									case 309:
										this.audioSorce.clip = this.BGM_AOS10;
										this.audioSorce.Play();
										break;
									case 310:
										this.audioSorce.clip = this.BGM_AOS11;
										this.audioSorce.Play();
										break;
									case 311:
										this.audioSorce.clip = this.BGM_AOS12;
										this.audioSorce.Play();
										break;
									case 312:
										this.audioSorce.clip = this.BGM_AOS13;
										this.audioSorce.Play();
										break;
									case 313:
										this.audioSorce.clip = this.BGM_AOS14;
										this.audioSorce.Play();
										break;
									case 314:
										this.audioSorce.clip = this.BGM_AOS15;
										this.audioSorce.Play();
										break;
									case 315:
										this.audioSorce.clip = this.BGM_AOS16;
										this.audioSorce.Play();
										break;
									case 316:
										this.audioSorce.clip = this.BGM_AOS17;
										this.audioSorce.Play();
										break;
									case 317:
										this.audioSorce.clip = this.BGM_AOS18;
										this.audioSorce.Play();
										break;
									case 318:
										this.audioSorce.clip = this.BGM_AOS19;
										this.audioSorce.Play();
										break;
									case 319:
										this.audioSorce.clip = this.BGM_AOS20;
										this.audioSorce.Play();
										break;
									case 320:
										this.audioSorce.clip = this.BGM_AOS21;
										this.audioSorce.Play();
										break;
									case 321:
										this.audioSorce.clip = this.BGM_AOS22;
										this.audioSorce.Play();
										break;
									case 322:
										this.audioSorce.clip = this.BGM_AOS23;
										this.audioSorce.Play();
										break;
									case 323:
										this.audioSorce.clip = this.BGM_AOS24;
										this.audioSorce.Play();
										break;
									case 324:
										this.audioSorce.clip = this.BGM_AOS25;
										this.audioSorce.Play();
										break;
									case 325:
										this.audioSorce.clip = this.BGM_AOS26;
										this.audioSorce.Play();
										break;
									case 326:
										this.audioSorce.clip = this.BGM_AOS27;
										this.audioSorce.Play();
										break;
									case 327:
										this.audioSorce.clip = this.BGM_AOS28;
										this.audioSorce.Stop();
										break;
									default:
										switch (num)
										{
										case 500:
											this.audioSorce.clip = this.BGM_ROB01;
											this.audioSorce.Stop();
											break;
										case 501:
											this.audioSorce.clip = this.BGM_ROB02;
											this.audioSorce.Play();
											break;
										case 502:
											this.audioSorce.clip = this.BGM_ROB03;
											this.audioSorce.Play();
											break;
										case 503:
											this.audioSorce.clip = this.BGM_ROB04;
											this.audioSorce.Play();
											break;
										case 504:
											this.audioSorce.clip = this.BGM_ROB05;
											this.audioSorce.Play();
											break;
										case 505:
											this.audioSorce.clip = this.BGM_ROB06;
											this.audioSorce.Play();
											break;
										case 506:
											this.audioSorce.clip = this.BGM_ROB07;
											this.audioSorce.Play();
											break;
										case 507:
											this.audioSorce.clip = this.BGM_ROB08;
											this.audioSorce.Play();
											break;
										case 508:
											this.audioSorce.clip = this.BGM_ROB09;
											this.audioSorce.Play();
											break;
										case 509:
											this.audioSorce.clip = this.BGM_ROB10;
											this.audioSorce.Play();
											break;
										case 510:
											this.audioSorce.clip = this.BGM_ROB11;
											this.audioSorce.Play();
											break;
										case 511:
											this.audioSorce.clip = this.BGM_ROB12;
											this.audioSorce.Play();
											break;
										case 512:
											this.audioSorce.clip = this.BGM_ROB13;
											this.audioSorce.Play();
											break;
										case 513:
											this.audioSorce.clip = this.BGM_ROB14;
											this.audioSorce.Play();
											break;
										case 514:
											this.audioSorce.clip = this.BGM_ROB15;
											this.audioSorce.Play();
											break;
										case 515:
											this.audioSorce.clip = this.BGM_ROB16;
											this.audioSorce.Play();
											break;
										case 516:
											this.audioSorce.clip = this.BGM_ROB17;
											this.audioSorce.Stop();
											break;
										case 517:
											this.audioSorce.clip = this.BGM_ROB18;
											this.audioSorce.Stop();
											break;
										case 518:
											this.audioSorce.clip = this.BGM_ROB19;
											this.audioSorce.Stop();
											break;
										case 519:
											this.audioSorce.clip = this.BGM_ROB20;
											this.audioSorce.Stop();
											break;
										case 520:
											this.audioSorce.clip = this.BGM_ROB21;
											this.audioSorce.Stop();
											break;
										case 521:
											this.audioSorce.clip = this.BGM_ROB22;
											this.audioSorce.Stop();
											break;
										default:
											switch (num)
											{
											case 600:
												this.audioSorce.clip = this.BGM_XX01;
												this.audioSorce.Stop();
												break;
											case 601:
												this.audioSorce.clip = this.BGM_XX02;
												this.audioSorce.Stop();
												break;
											case 602:
												this.audioSorce.clip = this.BGM_XX03;
												this.audioSorce.Play();
												break;
											case 603:
												this.audioSorce.clip = this.BGM_XX04;
												this.audioSorce.Play();
												break;
											case 604:
												this.audioSorce.clip = this.BGM_XX05;
												this.audioSorce.Play();
												break;
											case 605:
												this.audioSorce.clip = this.BGM_XX06;
												this.audioSorce.Play();
												break;
											case 606:
												this.audioSorce.clip = this.BGM_XX07;
												this.audioSorce.Play();
												break;
											case 607:
												this.audioSorce.clip = this.BGM_XX08;
												this.audioSorce.Play();
												break;
											case 608:
												this.audioSorce.clip = this.BGM_XX09;
												this.audioSorce.Play();
												break;
											case 609:
												this.audioSorce.clip = this.BGM_XX10;
												this.audioSorce.Play();
												break;
											case 610:
												this.audioSorce.clip = this.BGM_XX11;
												this.audioSorce.Play();
												break;
											case 611:
												this.audioSorce.clip = this.BGM_XX12;
												this.audioSorce.Play();
												break;
											case 612:
												this.audioSorce.clip = this.BGM_XX13;
												this.audioSorce.Play();
												break;
											case 613:
												this.audioSorce.clip = this.BGM_XX14;
												this.audioSorce.Play();
												break;
											case 614:
												this.audioSorce.clip = this.BGM_XX15;
												this.audioSorce.Play();
												break;
											case 615:
												this.audioSorce.clip = this.BGM_XX16;
												this.audioSorce.Stop();
												break;
											case 616:
												this.audioSorce.clip = this.BGM_XX17;
												this.audioSorce.Stop();
												break;
											case 617:
												this.audioSorce.clip = this.BGM_XX18;
												this.audioSorce.Stop();
												break;
											case 618:
												this.audioSorce.clip = this.BGM_XX19;
												this.audioSorce.Stop();
												break;
											case 619:
												this.audioSorce.clip = this.BGM_XX20;
												this.audioSorce.Stop();
												break;
											default:
												switch (num)
												{
												case 700:
													this.audioSorce.clip = this.BGM_HC01;
													this.audioSorce.Stop();
													break;
												case 701:
													this.audioSorce.clip = this.BGM_HC02;
													this.audioSorce.Stop();
													break;
												case 702:
													this.audioSorce.clip = this.BGM_HC03;
													this.audioSorce.Stop();
													break;
												case 703:
													this.audioSorce.clip = this.BGM_HC04;
													this.audioSorce.Play();
													break;
												case 704:
													this.audioSorce.clip = this.BGM_HC05;
													this.audioSorce.Play();
													break;
												case 705:
													this.audioSorce.clip = this.BGM_HC06;
													this.audioSorce.Play();
													break;
												case 706:
													this.audioSorce.clip = this.BGM_HC07;
													this.audioSorce.Stop();
													break;
												case 707:
													this.audioSorce.clip = this.BGM_HC08;
													this.audioSorce.Play();
													break;
												case 708:
													this.audioSorce.clip = this.BGM_HC09;
													this.audioSorce.Play();
													break;
												case 709:
													this.audioSorce.clip = this.BGM_HC10;
													this.audioSorce.Play();
													break;
												case 710:
													this.audioSorce.clip = this.BGM_HC11;
													this.audioSorce.Play();
													break;
												case 711:
													this.audioSorce.clip = this.BGM_HC12;
													this.audioSorce.Play();
													break;
												case 712:
													this.audioSorce.clip = this.BGM_HC13;
													this.audioSorce.Play();
													break;
												case 713:
													this.audioSorce.clip = this.BGM_HC14;
													this.audioSorce.Play();
													break;
												case 714:
													this.audioSorce.clip = this.BGM_HC15;
													this.audioSorce.Play();
													break;
												case 715:
													this.audioSorce.clip = this.BGM_HC16;
													this.audioSorce.Stop();
													break;
												case 716:
													this.audioSorce.clip = this.BGM_HC17;
													this.audioSorce.Stop();
													break;
												case 717:
													this.audioSorce.clip = this.BGM_HC18;
													this.audioSorce.Stop();
													break;
												default:
													switch (num)
													{
													case 100:
														this.audioSorce.clip = this.BGM_CV01;
														this.audioSorce.Play();
														break;
													case 101:
														this.audioSorce.clip = this.BGM_CV02;
														this.audioSorce.Play();
														break;
													case 102:
														this.audioSorce.clip = this.BGM_CV03;
														this.audioSorce.Play();
														break;
													case 103:
														this.audioSorce.clip = this.BGM_CV04;
														this.audioSorce.Play();
														break;
													case 104:
														this.audioSorce.clip = this.BGM_CV05;
														this.audioSorce.Play();
														break;
													case 105:
														this.audioSorce.clip = this.BGM_CV06;
														this.audioSorce.Play();
														break;
													case 106:
														this.audioSorce.clip = this.BGM_CV07;
														this.audioSorce.Play();
														break;
													case 107:
														this.audioSorce.clip = this.BGM_CV08;
														this.audioSorce.Play();
														break;
													case 108:
														this.audioSorce.clip = this.BGM_CV09;
														this.audioSorce.Play();
														break;
													case 109:
														this.audioSorce.clip = this.BGM_CV10;
														this.audioSorce.Play();
														break;
													case 110:
														this.audioSorce.clip = this.BGM_CV11_Once;
														this.audioSorce.Stop();
														break;
													}
													break;
												}
												break;
											}
											break;
										}
										break;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					this.introPlayed = false;
				}
			}
		}

		// Token: 0x06003247 RID: 12871 RVA: 0x005CF8E8 File Offset: 0x005CDAE8
		private void FixedUpdate()
		{
			if (!this.testPlayStage && this.settingChange.changedVolumeSet)
			{
				this.audioSorce.volume = this.settingChange.bgmVolume / 100f;
				this.cVVolume = this.settingChange.cvVolume / 100f;
				this.sEVolume = this.settingChange.seVolume / 100f;
			}
		}

		// Token: 0x06003248 RID: 12872 RVA: 0x005CF95C File Offset: 0x005CDB5C
		public void SystemBGMCall(int num)
		{
			this.audioSorce.loop = false;
			this.currentSongNumber = num;
			if (num != 35)
			{
				if (num != 36)
				{
					if (num == 37)
					{
						string text = this.startBGMStageName;
						switch (text)
						{
						case "BGMStage01":
							this.audioSorce.clip = this.BGM_FAILED01;
							this.audioSorce.Play();
							break;
						case "BGMStage02":
							this.audioSorce.clip = this.BGM_FAILED01;
							this.audioSorce.Play();
							break;
						case "BGMStage03":
							this.audioSorce.clip = this.BGM_FAILED01;
							this.audioSorce.Play();
							break;
						case "BGMStage04":
							this.audioSorce.clip = this.BGM_FAILED01;
							this.audioSorce.Play();
							break;
						case "BGMStage05":
							this.audioSorce.clip = this.BGM_FAILED01;
							this.audioSorce.Play();
							break;
						case "BGMStage06":
							this.audioSorce.clip = this.BGM_FAILED01;
							this.audioSorce.Play();
							break;
						case "BGMStage06_Alternative":
							this.audioSorce.clip = this.BGM_FAILED03;
							this.audioSorce.Play();
							break;
						case "BGMStage07":
							this.audioSorce.clip = this.BGM_FAILED01;
							this.audioSorce.Play();
							break;
						case "BGMStage08":
							this.audioSorce.clip = this.BGM_FAILED01;
							this.audioSorce.Play();
							break;
						case "BGMStage12":
							this.audioSorce.clip = this.BGM_FAILED02;
							this.audioSorce.Play();
							break;
						case "BGMStage13":
							this.audioSorce.clip = this.BGM_FAILED03;
							this.audioSorce.Play();
							break;
						case "BGMStageTest":
							this.audioSorce.clip = this.BGM_FAILED03;
							this.audioSorce.Play();
							break;
						}
					}
				}
				else
				{
					string text2 = this.startBGMStageName;
					switch (text2)
					{
					case "BGMStage01":
						this.audioSorce.clip = this.BGM_SUCCESS01;
						this.audioSorce.Play();
						break;
					case "BGMStage02":
						this.audioSorce.clip = this.BGM_SUCCESS01;
						this.audioSorce.Play();
						break;
					case "BGMStage03":
						this.audioSorce.clip = this.BGM_SUCCESS01;
						this.audioSorce.Play();
						break;
					case "BGMStage04":
						this.audioSorce.clip = this.BGM_SUCCESS01;
						this.audioSorce.Play();
						break;
					case "BGMStage05":
						this.audioSorce.clip = this.BGM_SUCCESS01;
						this.audioSorce.Play();
						break;
					case "BGMStage06":
						this.audioSorce.clip = this.BGM_SUCCESS01;
						this.audioSorce.Play();
						break;
					case "BGMStage06_Alternative":
						this.audioSorce.clip = this.BGM_SUCCESS03;
						this.audioSorce.Play();
						break;
					case "BGMStage07":
						this.audioSorce.clip = this.BGM_SUCCESS01;
						this.audioSorce.Play();
						break;
					case "BGMStage08":
						this.audioSorce.clip = this.BGM_SUCCESS01;
						this.audioSorce.Play();
						break;
					case "BGMStage12":
						this.audioSorce.clip = this.BGM_SUCCESS02;
						this.audioSorce.Play();
						break;
					case "BGMStage13":
						this.audioSorce.clip = this.BGM_SUCCESS03;
						this.audioSorce.Play();
						break;
					case "BGMStageTest":
						this.audioSorce.clip = this.BGM_SUCCESS03;
						this.audioSorce.Play();
						break;
					}
				}
			}
			else
			{
				this.audioSorce.clip = this.BGM_GOLDBOX;
				this.audioSorce.Play();
				this.introPlayed = true;
			}
		}

		// Token: 0x06003249 RID: 12873 RVA: 0x005CFEED File Offset: 0x005CE0ED
		public void ChangeBGMCall(int num)
		{
			this.myPV.RPC("ReciveChangeBGMCall", PhotonTargets.All, new object[]
			{
				num
			});
		}

		// Token: 0x0600324A RID: 12874 RVA: 0x005CFF10 File Offset: 0x005CE110
		public void CurrentBGMCall(int num)
		{
			this.audioSorce.loop = false;
			this.currentSongNumber = num;
			switch (num)
			{
			case 800:
				this.audioSorce.clip = this.BGM_OTHERS01_Intro;
				this.audioSorce.Play();
				this.text.text = "飛翔月影";
				break;
			case 801:
				this.audioSorce.clip = this.BGM_OTHERS02;
				this.audioSorce.Play();
				this.text.text = "Transcend fear and despair";
				break;
			case 802:
				this.audioSorce.clip = this.BGM_OOE01;
				this.audioSorce.Play();
				this.text.text = "An Empty Tome";
				break;
			case 803:
				this.audioSorce.clip = this.BGM_OOE02;
				this.audioSorce.Play();
				this.text.text = "Consummation";
				break;
			case 804:
				this.audioSorce.clip = this.BGM_OOE03;
				this.audioSorce.Play();
				this.text.text = "Ecclesia";
				break;
			case 805:
				this.audioSorce.clip = this.BGM_OOE04;
				this.audioSorce.Play();
				this.text.text = "Requiem of Star-Crossed Nights";
				break;
			case 806:
				this.audioSorce.clip = this.BGM_OOE05;
				this.audioSorce.Play();
				this.text.text = "Suspicions";
				break;
			case 807:
				this.audioSorce.clip = this.BGM_OOE06;
				this.audioSorce.Play();
				this.text.text = "A Clashing of Waves";
				break;
			case 808:
				this.audioSorce.clip = this.BGM_OOE07_Intro;
				this.audioSorce.Play();
				this.text.text = "A Prologue";
				break;
			case 809:
				this.audioSorce.clip = this.BGM_OOE08_Intro;
				this.audioSorce.Play();
				this.text.text = "An Empty Tome(In Game)";
				break;
			case 810:
				this.audioSorce.clip = this.BGM_OOE09_Intro;
				this.audioSorce.Play();
				this.text.text = "An Empty Tome(Unused Track)";
				break;
			case 811:
				this.audioSorce.clip = this.BGM_OOE10;
				this.audioSorce.Play();
				this.text.text = "Armory Arabesque";
				break;
			case 812:
				this.audioSorce.clip = this.BGM_OOE11;
				this.audioSorce.Play();
				this.text.text = "Cantus Montetten -1";
				break;
			case 813:
				this.audioSorce.clip = this.BGM_OOE12_Intro;
				this.audioSorce.Play();
				this.text.text = "Chamber of Ruin";
				break;
			case 814:
				this.audioSorce.clip = this.BGM_OOE13_Intro;
				this.audioSorce.Play();
				this.text.text = "Chapel Hidden in Smoke";
				break;
			case 815:
				this.audioSorce.clip = this.BGM_OOE14;
				this.audioSorce.Play();
				this.text.text = "Dark Holy Road";
				break;
			case 816:
				this.audioSorce.clip = this.BGM_OOE15_Intro;
				this.audioSorce.Play();
				this.text.text = "Destiny's Stage";
				break;
			case 817:
				this.audioSorce.clip = this.BGM_OOE16_Intro;
				this.audioSorce.Play();
				this.text.text = "Dissonant Courage";
				break;
			case 818:
				this.audioSorce.clip = this.BGM_OOE17_Intro;
				this.audioSorce.Play();
				this.text.text = "Dissonant Courage(Unused Track)";
				break;
			case 819:
				this.audioSorce.clip = this.BGM_OOE18_Intro;
				this.audioSorce.Play();
				this.text.text = "Deliberate Blink";
				break;
			case 820:
				this.audioSorce.clip = this.BGM_OOE19_Intro;
				this.audioSorce.Play();
				this.text.text = "Ebony Wings";
				break;
			case 821:
				this.audioSorce.clip = this.BGM_OOE20;
				this.audioSorce.Play();
				this.text.text = "Edge of the Sky";
				break;
			case 822:
				this.audioSorce.clip = this.BGM_OOE21;
				this.audioSorce.Play();
				this.text.text = "Edge of the Sky(Unused Track)";
				break;
			case 823:
				this.audioSorce.clip = this.BGM_OOE22_Intro;
				this.audioSorce.Play();
				this.text.text = "Emerald Mist";
				break;
			case 824:
				this.audioSorce.clip = this.BGM_OOE23;
				this.audioSorce.Play();
				this.text.text = "Enterprising Mercantilism";
				break;
			case 825:
				this.audioSorce.clip = this.BGM_OOE24_Intro;
				this.audioSorce.Play();
				this.text.text = "Former Room 2";
				break;
			case 826:
				this.audioSorce.clip = this.BGM_OOE25_Intro;
				this.audioSorce.Play();
				this.text.text = "Gate of the Underworld(Unused Track)";
				break;
			case 827:
				this.audioSorce.clip = this.BGM_OOE26_Intro;
				this.audioSorce.Play();
				this.text.text = "Hard Won Nobility";
				break;
			case 828:
				this.audioSorce.clip = this.BGM_OOE27;
				this.audioSorce.Play();
				this.text.text = "Heroic Dawing";
				break;
			case 829:
				this.audioSorce.clip = this.BGM_OOE28;
				this.audioSorce.Play();
				this.text.text = "Jaw of a Scorched Earth";
				break;
			case 830:
				this.audioSorce.clip = this.BGM_OOE29_Intro;
				this.audioSorce.Play();
				this.text.text = "Lament to the Master";
				break;
			case 831:
				this.audioSorce.clip = this.BGM_OOE30_Intro;
				this.audioSorce.Play();
				this.text.text = "Lone Challenger";
				break;
			case 832:
				this.audioSorce.clip = this.BGM_OOE31_Intro;
				this.audioSorce.Play();
				this.text.text = "Malak's Labyrinth";
				break;
			case 833:
				this.audioSorce.clip = this.BGM_OOE32_Intro;
				this.audioSorce.Play();
				this.text.text = "Oncoming Dread";
				break;
			case 834:
				this.audioSorce.clip = this.BGM_OOE33_Intro;
				this.audioSorce.Play();
				this.text.text = "Order of the Demon";
				break;
			case 835:
				this.audioSorce.clip = this.BGM_OOE34_Intro;
				this.audioSorce.Play();
				this.text.text = "Order of the Demon(Unused Track)";
				break;
			case 836:
				this.audioSorce.clip = this.BGM_OOE35;
				this.audioSorce.Play();
				this.text.text = "Passing Into the Night";
				break;
			case 837:
				this.audioSorce.clip = this.BGM_OOE36_Intro;
				this.audioSorce.Play();
				this.text.text = "Reunion";
				break;
			case 838:
				this.audioSorce.clip = this.BGM_OOE37_Intro;
				this.audioSorce.Play();
				this.text.text = "Rhapsody of the Forsaken(Unused Track)";
				break;
			case 839:
				this.audioSorce.clip = this.BGM_OOE38_Intro;
				this.audioSorce.Play();
				this.text.text = "Rhapsody of the Forsaken";
				break;
			case 840:
				this.audioSorce.clip = this.BGM_OOE39_Intro;
				this.audioSorce.Play();
				this.text.text = "Riddle";
				break;
			case 841:
				this.audioSorce.clip = this.BGM_OOE40;
				this.audioSorce.Play();
				this.text.text = "Rituals";
				break;
			case 842:
				this.audioSorce.clip = this.BGM_OOE41;
				this.audioSorce.Play();
				this.text.text = "Sapphire Elegy";
				break;
			case 843:
				this.audioSorce.clip = this.BGM_OOE42_Intro;
				this.audioSorce.Play();
				this.text.text = "Serenade of the Hearth";
				break;
			case 844:
				this.audioSorce.clip = this.BGM_OOE43_Intro;
				this.audioSorce.Play();
				this.text.text = "Shadow's Stronghold";
				break;
			case 845:
				this.audioSorce.clip = this.BGM_OOE44_Intro;
				this.audioSorce.Play();
				this.text.text = "Sorrow's Distortion";
				break;
			case 846:
				this.audioSorce.clip = this.BGM_OOE45_Intro;
				this.audioSorce.Play();
				this.text.text = "Symphony of Battle";
				break;
			case 847:
				this.audioSorce.clip = this.BGM_OOE46_Intro;
				this.audioSorce.Play();
				this.text.text = "The Colossus";
				break;
			case 848:
				this.audioSorce.clip = this.BGM_OOE47;
				this.audioSorce.Play();
				this.text.text = "Tower of Dolls";
				break;
			case 849:
				this.audioSorce.clip = this.BGM_OOE48_Intro;
				this.audioSorce.Play();
				this.text.text = "Trace of Rage";
				break;
			case 850:
				this.audioSorce.clip = this.BGM_OOE49_Intro;
				this.audioSorce.Play();
				this.text.text = "Tragedy's Pulse";
				break;
			case 851:
				this.audioSorce.clip = this.BGM_OOE50_Intro;
				this.audioSorce.Play();
				this.text.text = "Unholy Vespers";
				break;
			case 852:
				this.audioSorce.clip = this.BGM_OOE51_Intro;
				this.audioSorce.Play();
				this.text.text = "Vanishing";
				break;
			case 853:
				this.audioSorce.clip = this.BGM_OOE52_Intro;
				this.audioSorce.Play();
				this.text.text = "Wandering the Crystal Blue";
				break;
			case 854:
				this.audioSorce.clip = this.BGM_OOE53_Intro;
				this.audioSorce.Play();
				this.text.text = "Wandering the Crystal Blue(Unused Track)";
				break;
			case 855:
				this.audioSorce.clip = this.BGM_OOE54;
				this.audioSorce.Play();
				this.text.text = "Welcome to Legend";
				break;
			default:
				switch (num)
				{
				case 400:
					this.audioSorce.clip = this.BGM_SOTN01;
					this.audioSorce.Play();
					this.text.text = "Metamorphosis";
					break;
				case 401:
					this.audioSorce.clip = this.BGM_SOTN02_Intro;
					this.audioSorce.Play();
					this.text.text = "Prologue";
					break;
				case 402:
					this.audioSorce.clip = this.BGM_SOTN03_Intro;
					this.audioSorce.Play();
					this.text.text = "Dance of Illusions";
					break;
				case 403:
					this.audioSorce.clip = this.BGM_SOTN04;
					this.audioSorce.Play();
					this.text.text = "Moonlight Nocturne";
					break;
				case 404:
					this.audioSorce.clip = this.BGM_SOTN05;
					this.audioSorce.Play();
					this.text.text = "Prayer";
					break;
				case 405:
					this.audioSorce.clip = this.BGM_SOTN06_Intro;
					this.audioSorce.Play();
					this.text.text = "Bloody Tears (Remix 2)";
					break;
				case 406:
					this.audioSorce.clip = this.BGM_SOTN07_Intro;
					this.audioSorce.Play();
					this.text.text = "Dracula's Castle";
					break;
				case 407:
					this.audioSorce.clip = this.BGM_SOTN08_Intro;
					this.audioSorce.Play();
					this.text.text = "Vampire Killer (Remix 2)";
					break;
				case 408:
					this.audioSorce.clip = this.BGM_SOTN09_Intro;
					this.audioSorce.Play();
					this.text.text = "Dance of Gold";
					break;
				case 409:
					this.audioSorce.clip = this.BGM_SOTN10_Intro;
					this.audioSorce.Play();
					this.text.text = "Festival of Servants";
					break;
				case 410:
					this.audioSorce.clip = this.BGM_SOTN11_Intro;
					this.audioSorce.Play();
					this.text.text = "Marble Gallery";
					break;
				case 411:
					this.audioSorce.clip = this.BGM_SOTN12;
					this.audioSorce.Play();
					this.text.text = "Chaconne C'Moll";
					break;
				case 412:
					this.audioSorce.clip = this.BGM_SOTN13_Intro;
					this.audioSorce.Play();
					this.text.text = "Tower of Mist";
					break;
				case 413:
					this.audioSorce.clip = this.BGM_SOTN14_Intro;
					this.audioSorce.Play();
					this.text.text = "Nocturne";
					break;
				case 414:
					this.audioSorce.clip = this.BGM_SOTN15_Intro;
					this.audioSorce.Play();
					this.text.text = "Wood Carving Partita";
					break;
				case 415:
					this.audioSorce.clip = this.BGM_SOTN16_Intro;
					this.audioSorce.Play();
					this.text.text = "The Master Librarian";
					break;
				case 416:
					this.audioSorce.clip = this.BGM_SOTN17_Intro;
					this.audioSorce.Play();
					this.text.text = "Crystal Teardrops";
					break;
				case 417:
					this.audioSorce.clip = this.BGM_SOTN18_Intro;
					this.audioSorce.Play();
					this.text.text = "Enchanted Banquet";
					break;
				case 418:
					this.audioSorce.clip = this.BGM_SOTN19;
					this.audioSorce.Play();
					this.text.text = "Abandoned Pit";
					break;
				case 419:
					this.audioSorce.clip = this.BGM_SOTN20_Intro;
					this.audioSorce.Play();
					this.text.text = "Raindbow Cemetery";
					break;
				case 420:
					this.audioSorce.clip = this.BGM_SOTN21_Intro;
					this.audioSorce.Play();
					this.text.text = "Death Ballad";
					break;
				case 421:
					this.audioSorce.clip = this.BGM_SOTN22_Intro;
					this.audioSorce.Play();
					this.text.text = "Vampire Killer (Remix 1)";
					break;
				case 422:
					this.audioSorce.clip = this.BGM_SOTN23_Intro;
					this.audioSorce.Play();
					this.text.text = "Bloody Tears (Remix 1)";
					break;
				case 423:
					this.audioSorce.clip = this.BGM_SOTN24_Intro;
					this.audioSorce.Play();
					this.text.text = "Requiem for the Gods";
					break;
				case 424:
					this.audioSorce.clip = this.BGM_SOTN25;
					this.audioSorce.Play();
					this.text.text = "Bloody Confession";
					break;
				case 425:
					this.audioSorce.clip = this.BGM_SOTN26_Intro;
					this.audioSorce.Play();
					this.text.text = "Dance of Pales";
					break;
				case 426:
					this.audioSorce.clip = this.BGM_SOTN27_Intro;
					this.audioSorce.Play();
					this.text.text = "Wandering Ghosts";
					break;
				case 427:
					this.audioSorce.clip = this.BGM_SOTN28_Intro;
					this.audioSorce.Play();
					this.text.text = "The Tragic Prince";
					break;
				case 428:
					this.audioSorce.clip = this.BGM_SOTN29_Intro;
					this.audioSorce.Play();
					this.text.text = "Heavenly Doorway";
					break;
				case 429:
					this.audioSorce.clip = this.BGM_SOTN30_Intro;
					this.audioSorce.Play();
					this.text.text = "Blood Relations";
					break;
				case 430:
					this.audioSorce.clip = this.BGM_SOTN31;
					this.audioSorce.Play();
					this.text.text = "Metamorphosis 2";
					break;
				case 431:
					this.audioSorce.clip = this.BGM_SOTN32_Intro;
					this.audioSorce.Play();
					this.text.text = "Final Toccata";
					break;
				case 432:
					this.audioSorce.clip = this.BGM_SOTN33_Intro;
					this.audioSorce.Play();
					this.text.text = "Lost Painting";
					break;
				case 433:
					this.audioSorce.clip = this.BGM_SOTN34_Intro;
					this.audioSorce.Play();
					this.text.text = "Beginning";
					break;
				case 434:
					this.audioSorce.clip = this.BGM_SOTN35_Intro;
					this.audioSorce.Play();
					this.text.text = "Curse Zone";
					break;
				case 435:
					this.audioSorce.clip = this.BGM_SOTN36_Intro;
					this.audioSorce.Play();
					this.text.text = "Door of Holy Spirits";
					break;
				case 436:
					this.audioSorce.clip = this.BGM_SOTN37;
					this.audioSorce.Play();
					this.text.text = "The Door to the Abyss";
					break;
				case 437:
					this.audioSorce.clip = this.BGM_SOTN38_Intro;
					this.audioSorce.Play();
					this.text.text = "Guardian";
					break;
				case 438:
					this.audioSorce.clip = this.BGM_SOTN39_Intro;
					this.audioSorce.Play();
					this.text.text = "Black Banquet";
					break;
				case 439:
					this.audioSorce.clip = this.BGM_SOTN40;
					this.audioSorce.Play();
					this.text.text = "Metamorphosis 3";
					break;
				case 440:
					this.audioSorce.clip = this.BGM_SOTN41;
					this.audioSorce.Play();
					this.text.text = "I Am the Wind";
					break;
				case 441:
					this.audioSorce.clip = this.BGM_SOTN42;
					this.audioSorce.Play();
					this.text.text = "I Am the Wind (Instrumental)";
					break;
				case 442:
					this.audioSorce.clip = this.BGM_SOTN43;
					this.audioSorce.Play();
					this.text.text = "Land of Benediction";
					break;
				case 443:
					this.audioSorce.clip = this.BGM_SOTN44;
					this.audioSorce.Play();
					this.text.text = "Silence";
					break;
				case 444:
					this.audioSorce.clip = this.BGM_SOTN45_Intro;
					this.audioSorce.Play();
					this.text.text = "Beginning (Inverted)";
					break;
				case 445:
					this.audioSorce.clip = this.BGM_SOTN46_Intro;
					this.audioSorce.Play();
					this.text.text = "Unknown Track";
					break;
				case 446:
					this.audioSorce.clip = this.BGM_SOTN47_Intro;
					this.audioSorce.Play();
					this.text.text = "Dracula's Castle (Remix)";
					break;
				case 447:
					this.audioSorce.clip = this.BGM_SOTN48_Intro;
					this.audioSorce.Play();
					this.text.text = "Nocturne";
					break;
				case 448:
					this.audioSorce.clip = this.BGM_SOTN49;
					this.audioSorce.Play();
					this.text.text = "Mournful Serenade";
					break;
				default:
					switch (num)
					{
					case 0:
						this.audioSorce.clip = this.BGM_HD01_Intro;
						this.audioSorce.Play();
						this.text.text = "荒城回廊";
						break;
					case 1:
						this.audioSorce.clip = this.BGM_HD02_Intro;
						this.audioSorce.Play();
						this.text.text = "闇夜の激突";
						break;
					case 2:
						this.audioSorce.clip = this.BGM_HD03_Intro;
						this.audioSorce.Play();
						this.text.text = "懺悔の後に";
						break;
					case 3:
						this.audioSorce.clip = this.BGM_HD04;
						this.audioSorce.Play();
						this.text.text = "PHANTOM OF FEAR";
						break;
					case 4:
						this.audioSorce.clip = this.BGM_HD05_Intro;
						this.audioSorce.Play();
						this.text.text = "尖白の闘志";
						break;
					case 5:
						this.audioSorce.clip = this.BGM_HD06_Intro;
						this.audioSorce.Play();
						this.text.text = "見上げよ、闇を";
						break;
					case 6:
						this.audioSorce.clip = this.BGM_HD07;
						this.audioSorce.Play();
						this.text.text = "暴虐のエスキース";
						break;
					case 7:
						this.audioSorce.clip = this.BGM_HD08_Intro;
						this.audioSorce.Play();
						this.text.text = "漆黒の翼";
						break;
					case 8:
						this.audioSorce.clip = this.BGM_HD09_Intro;
						this.audioSorce.Play();
						this.text.text = "闘魂狂詩曲";
						break;
					case 9:
						this.audioSorce.clip = this.BGM_HD10_Intro;
						this.audioSorce.Play();
						this.text.text = "ガルガンチュア";
						break;
					case 10:
						this.audioSorce.clip = this.BGM_HD11_Intro;
						this.audioSorce.Play();
						this.text.text = "繻紗魔交響詩";
						break;
					case 11:
						this.audioSorce.clip = this.BGM_HD12_Intro;
						this.audioSorce.Play();
						this.text.text = "幻想的舞曲";
						break;
					case 12:
						this.audioSorce.clip = this.BGM_HD13_Intro;
						this.audioSorce.Play();
						this.text.text = "Tanz mit einem Clown";
						break;
					case 13:
						this.audioSorce.clip = this.BGM_HD14_Intro;
						this.audioSorce.Play();
						this.text.text = "CRIMSON BLOOD";
						break;
					case 14:
						this.audioSorce.clip = this.BGM_HD15_Intro;
						this.audioSorce.Play();
						this.text.text = "Ein Weltherrscher";
						break;
					case 15:
						this.audioSorce.clip = this.BGM_HD16_Intro;
						this.audioSorce.Play();
						this.text.text = "Hail from the Past";
						break;
					case 16:
						this.audioSorce.clip = this.BGM_HD17_Intro;
						this.audioSorce.Play();
						this.text.text = "切り裂かれた静寂";
						break;
					case 17:
						this.audioSorce.clip = this.BGM_HD18_Intro;
						this.audioSorce.Play();
						this.text.text = "失われた彩画";
						break;
					case 18:
						this.audioSorce.clip = this.BGM_HD19_Intro;
						this.audioSorce.Play();
						this.text.text = "死の詩曲";
						break;
					case 19:
						this.audioSorce.clip = this.BGM_HD20_Intro;
						this.audioSorce.Play();
						this.text.text = "ドラキュラ城";
						break;
					case 20:
						this.audioSorce.clip = this.BGM_HD21_Intro;
						this.audioSorce.Play();
						this.text.text = "しもべたちの祭典";
						break;
					case 21:
						this.audioSorce.clip = this.BGM_HD22_Intro;
						this.audioSorce.Play();
						this.text.text = "Vampire Killer";
						break;
					case 22:
						this.audioSorce.clip = this.BGM_HD23_Intro;
						this.audioSorce.Play();
						this.text.text = "Nothing to Lose";
						break;
					case 23:
						this.audioSorce.clip = this.BGM_HD24_Intro;
						this.audioSorce.Play();
						this.text.text = "いけ！月風魔";
						break;
					case 24:
						this.audioSorce.clip = this.BGM_HD25_Intro;
						this.audioSorce.Play();
						this.text.text = "龍骨鬼";
						break;
					case 25:
						this.audioSorce.clip = this.BGM_HD26_Intro;
						this.audioSorce.Play();
						this.text.text = "漆黒の進攻";
						break;
					case 26:
						this.audioSorce.clip = this.BGM_HD27_Intro;
						this.audioSorce.Play();
						this.text.text = "悲境の貴公子";
						break;
					case 27:
						this.audioSorce.clip = this.BGM_HD28_Intro;
						this.audioSorce.Play();
						this.text.text = "狂月の招き";
						break;
					case 28:
						this.audioSorce.clip = this.BGM_HD29_Intro;
						this.audioSorce.Play();
						this.text.text = "隠された呪禁";
						break;
					case 29:
						this.audioSorce.clip = this.BGM_HD30_Intro;
						this.audioSorce.Play();
						this.text.text = "黄昏の聖痕";
						break;
					case 30:
						this.audioSorce.clip = this.BGM_HD31_Intro;
						this.audioSorce.Play();
						this.text.text = "夜まで待てない";
						break;
					case 31:
						this.audioSorce.clip = this.BGM_HD32_Intro;
						this.audioSorce.Play();
						this.text.text = "Aquarius";
						break;
					case 32:
						this.audioSorce.clip = this.BGM_HD33_Intro;
						this.audioSorce.Play();
						this.text.text = "Slash";
						break;
					case 33:
						this.audioSorce.clip = this.BGM_HD34_Intro;
						this.audioSorce.Play();
						this.text.text = "乾坤の血族";
						break;
					case 34:
						this.audioSorce.clip = this.BGM_HD35_Intro;
						this.audioSorce.Play();
						this.text.text = "シモンのテーマ";
						break;
					default:
						switch (num)
						{
						case 200:
							this.audioSorce.clip = this.BGM_DOS01_Once;
							this.audioSorce.Play();
							this.text.text = "Cross of the Blue Moon";
							break;
						case 201:
							this.audioSorce.clip = this.BGM_DOS02;
							this.audioSorce.Play();
							this.text.text = "A Fleeting Respite";
							break;
						case 202:
							this.audioSorce.clip = this.BGM_DOS03;
							this.audioSorce.Play();
							this.text.text = "Gloomy Memories";
							break;
						case 203:
							this.audioSorce.clip = this.BGM_DOS04;
							this.audioSorce.Play();
							this.text.text = "Evil Invitation";
							break;
						case 204:
							this.audioSorce.clip = this.BGM_DOS05;
							this.audioSorce.Play();
							this.text.text = "Pitch Black Intrustion";
							break;
						case 205:
							this.audioSorce.clip = this.BGM_DOS06_Intro;
							this.audioSorce.Play();
							this.text.text = "Equipment's Tale";
							break;
						case 206:
							this.audioSorce.clip = this.BGM_DOS07_Intro;
							this.audioSorce.Play();
							this.text.text = "Dracula's Tears";
							break;
						case 207:
							this.audioSorce.clip = this.BGM_DOS08;
							this.audioSorce.Play();
							this.text.text = "Dark Clouds";
							break;
						case 208:
							this.audioSorce.clip = this.BGM_DOS09;
							this.audioSorce.Play();
							this.text.text = "Black Shudder";
							break;
						case 209:
							this.audioSorce.clip = this.BGM_DOS10;
							this.audioSorce.Play();
							this.text.text = "Platinum Moonlight";
							break;
						case 210:
							this.audioSorce.clip = this.BGM_DOS11_Intro;
							this.audioSorce.Play();
							this.text.text = "After Confession";
							break;
						case 211:
							this.audioSorce.clip = this.BGM_DOS12_Intro;
							this.audioSorce.Play();
							this.text.text = "Scarlet Battle Soul";
							break;
						case 212:
							this.audioSorce.clip = this.BGM_DOS13;
							this.audioSorce.Play();
							this.text.text = "Demon Guest House";
							break;
						case 213:
							this.audioSorce.clip = this.BGM_DOS14_Intro;
							this.audioSorce.Play();
							this.text.text = "Echoes of Darkness";
							break;
						case 214:
							this.audioSorce.clip = this.BGM_DOS15;
							this.audioSorce.Play();
							this.text.text = "Condemned Tower";
							break;
						case 215:
							this.audioSorce.clip = this.BGM_DOS16;
							this.audioSorce.Play();
							this.text.text = "Into the Dark Night";
							break;
						case 216:
							this.audioSorce.clip = this.BGM_DOS17_Intro;
							this.audioSorce.Play();
							this.text.text = "Cursed Clock Tower";
							break;
						case 217:
							this.audioSorce.clip = this.BGM_DOS18_Intro;
							this.audioSorce.Play();
							this.text.text = "Subterranean Hell";
							break;
						case 218:
							this.audioSorce.clip = this.BGM_DOS19_Intro;
							this.audioSorce.Play();
							this.text.text = "Vampire Killer";
							break;
						case 219:
							this.audioSorce.clip = this.BGM_DOS20_Intro;
							this.audioSorce.Play();
							this.text.text = "The Pinnacle";
							break;
						case 220:
							this.audioSorce.clip = this.BGM_DOS21_Intro;
							this.audioSorce.Play();
							this.text.text = "Portal to Dark Bravery";
							break;
						case 221:
							this.audioSorce.clip = this.BGM_DOS22;
							this.audioSorce.Play();
							this.text.text = "Underground Melodies";
							break;
						case 222:
							this.audioSorce.clip = this.BGM_DOS23_Intro;
							this.audioSorce.Play();
							this.text.text = "The Abyss";
							break;
						case 223:
							this.audioSorce.clip = this.BGM_DOS24_Intro;
							this.audioSorce.Play();
							this.text.text = "Piercing Battle Fury";
							break;
						case 224:
							this.audioSorce.clip = this.BGM_DOS25_Intro;
							this.audioSorce.Play();
							this.text.text = "Beginning";
							break;
						case 225:
							this.audioSorce.clip = this.BGM_DOS26_Intro;
							this.audioSorce.Play();
							this.text.text = "Bloody Tears";
							break;
						case 226:
							this.audioSorce.clip = this.BGM_DOS27_Intro;
							this.audioSorce.Play();
							this.text.text = "Illusionary Song";
							break;
						case 227:
							this.audioSorce.clip = this.BGM_DOS28_Intro;
							this.audioSorce.Play();
							this.text.text = "After Battle - Blue Memories";
							break;
						case 228:
							this.audioSorce.clip = this.BGM_DOS29;
							this.audioSorce.Play();
							this.text.text = "Momentary Moonlight";
							break;
						case 229:
							this.audioSorce.clip = this.BGM_DOS30;
							this.audioSorce.Play();
							this.text.text = "Amber Scenery (Remix)";
							break;
						case 230:
							this.audioSorce.clip = this.BGM_DOS31;
							this.audioSorce.Play();
							this.text.text = "GameOver";
							break;
						default:
							switch (num)
							{
							case 300:
								this.audioSorce.clip = this.BGM_AOS01;
								this.audioSorce.Play();
								this.text.text = "The Black Sun";
								break;
							case 301:
								this.audioSorce.clip = this.BGM_AOS02;
								this.audioSorce.Play();
								this.text.text = "Name Entry";
								break;
							case 302:
								this.audioSorce.clip = this.BGM_AOS03;
								this.audioSorce.Play();
								this.text.text = "Prologue - Mina's Theme";
								break;
							case 303:
								this.audioSorce.clip = this.BGM_AOS04_Intro;
								this.audioSorce.Play();
								this.text.text = "Castle Corridor";
								break;
							case 304:
								this.audioSorce.clip = this.BGM_AOS05;
								this.audioSorce.Play();
								this.text.text = "Premonition";
								break;
							case 305:
								this.audioSorce.clip = this.BGM_AOS06_Intro;
								this.audioSorce.Play();
								this.text.text = "Chapel";
								break;
							case 306:
								this.audioSorce.clip = this.BGM_AOS07_Intro;
								this.audioSorce.Play();
								this.text.text = "Formidable Enemy";
								break;
							case 307:
								this.audioSorce.clip = this.BGM_AOS08_Intro;
								this.audioSorce.Play();
								this.text.text = "Study";
								break;
							case 308:
								this.audioSorce.clip = this.BGM_AOS09_Intro;
								this.audioSorce.Play();
								this.text.text = "Hammer's Shop";
								break;
							case 309:
								this.audioSorce.clip = this.BGM_AOS10;
								this.audioSorce.Play();
								this.text.text = "Dance Hall";
								break;
							case 310:
								this.audioSorce.clip = this.BGM_AOS11;
								this.audioSorce.Play();
								this.text.text = "Inner Quarters";
								break;
							case 311:
								this.audioSorce.clip = this.BGM_AOS12;
								this.audioSorce.Play();
								this.text.text = "Floating Garden";
								break;
							case 312:
								this.audioSorce.clip = this.BGM_AOS13_Intro;
								this.audioSorce.Play();
								this.text.text = "Clock Tower";
								break;
							case 313:
								this.audioSorce.clip = this.BGM_AOS14_Intro;
								this.audioSorce.Play();
								this.text.text = "Confrontation";
								break;
							case 314:
								this.audioSorce.clip = this.BGM_AOS15_Intro;
								this.audioSorce.Play();
								this.text.text = "Underground Reservoir";
								break;
							case 315:
								this.audioSorce.clip = this.BGM_AOS16_Intro;
								this.audioSorce.Play();
								this.text.text = "The Arena";
								break;
							case 316:
								this.audioSorce.clip = this.BGM_AOS17_Intro;
								this.audioSorce.Play();
								this.text.text = "Forbidden Area";
								break;
							case 317:
								this.audioSorce.clip = this.BGM_AOS18_Intro;
								this.audioSorce.Play();
								this.text.text = "Top Floor";
								break;
							case 318:
								this.audioSorce.clip = this.BGM_AOS19_Intro;
								this.audioSorce.Play();
								this.text.text = "Throne Fights";
								break;
							case 319:
								this.audioSorce.clip = this.BGM_AOS20_Intro;
								this.audioSorce.Play();
								this.text.text = "Dracula's Fate";
								break;
							case 320:
								this.audioSorce.clip = this.BGM_AOS21_Intro;
								this.audioSorce.Play();
								this.text.text = "Don't Wait Until Night";
								break;
							case 321:
								this.audioSorce.clip = this.BGM_AOS22_Intro;
								this.audioSorce.Play();
								this.text.text = "Chaotic Realm";
								break;
							case 322:
								this.audioSorce.clip = this.BGM_AOS23_Intro;
								this.audioSorce.Play();
								this.text.text = "You're Not Alone";
								break;
							case 323:
								this.audioSorce.clip = this.BGM_AOS24_Intro;
								this.audioSorce.Play();
								this.text.text = "Battle With Chaos";
								break;
							case 324:
								this.audioSorce.clip = this.BGM_AOS25_Intro;
								this.audioSorce.Play();
								this.text.text = "Last Battle";
								break;
							case 325:
								this.audioSorce.clip = this.BGM_AOS26_Intro;
								this.audioSorce.Play();
								this.text.text = "Purification - Ending";
								break;
							case 326:
								this.audioSorce.clip = this.BGM_AOS27;
								this.audioSorce.Play();
								this.text.text = "Credits";
								break;
							case 327:
								this.audioSorce.clip = this.BGM_AOS28;
								this.audioSorce.Play();
								this.text.text = "GameOver";
								break;
							default:
								switch (num)
								{
								case 500:
									this.audioSorce.clip = this.BGM_ROB01;
									this.audioSorce.Play();
									this.text.text = "Overture";
									break;
								case 501:
									this.audioSorce.clip = this.BGM_ROB02;
									this.audioSorce.Play();
									this.text.text = "Prayer";
									break;
								case 502:
									this.audioSorce.clip = this.BGM_ROB03_Intro;
									this.audioSorce.Play();
									this.text.text = "Opposing Bloodlines";
									break;
								case 503:
									this.audioSorce.clip = this.BGM_ROB04_Intro;
									this.audioSorce.Play();
									this.text.text = "Vampire Killer";
									break;
								case 504:
									this.audioSorce.clip = this.BGM_ROB05_Intro;
									this.audioSorce.Play();
									this.text.text = "Cross a Fear";
									break;
								case 505:
									this.audioSorce.clip = this.BGM_ROB06_Intro;
									this.audioSorce.Play();
									this.text.text = "Bloody Tears";
									break;
								case 506:
									this.audioSorce.clip = this.BGM_ROB07_Intro;
									this.audioSorce.Play();
									this.text.text = "Cemetery";
									break;
								case 507:
									this.audioSorce.clip = this.BGM_ROB08_Intro;
									this.audioSorce.Play();
									this.text.text = "Beginning";
									break;
								case 508:
									this.audioSorce.clip = this.BGM_ROB09_Intro;
									this.audioSorce.Play();
									this.text.text = "Opus 13";
									break;
								case 509:
									this.audioSorce.clip = this.BGM_ROB10_Intro;
									this.audioSorce.Play();
									this.text.text = "Picture of a Ghost Ship";
									break;
								case 510:
									this.audioSorce.clip = this.BGM_ROB11_Intro;
									this.audioSorce.Play();
									this.text.text = "Slash";
									break;
								case 511:
									this.audioSorce.clip = this.BGM_ROB12;
									this.audioSorce.Play();
									this.text.text = "Road to the Enemy";
									break;
								case 512:
									this.audioSorce.clip = this.BGM_ROB13_Intro;
									this.audioSorce.Play();
									this.text.text = "Dancing in Phantasmic Hell";
									break;
								case 513:
									this.audioSorce.clip = this.BGM_ROB14;
									this.audioSorce.Play();
									this.text.text = "The Den";
									break;
								case 514:
									this.audioSorce.clip = this.BGM_ROB15;
									this.audioSorce.Play();
									this.text.text = "Poison Mind";
									break;
								case 515:
									this.audioSorce.clip = this.BGM_ROB16_Intro;
									this.audioSorce.Play();
									this.text.text = "Illusionary Dance";
									break;
								case 516:
									this.audioSorce.clip = this.BGM_ROB17;
									this.audioSorce.Play();
									this.text.text = "March of the Holy Man";
									break;
								case 517:
									this.audioSorce.clip = this.BGM_ROB18;
									this.audioSorce.Play();
									this.text.text = "Mary Samba";
									break;
								case 518:
									this.audioSorce.clip = this.BGM_ROB19;
									this.audioSorce.Play();
									this.text.text = "Stage Clear";
									break;
								case 519:
									this.audioSorce.clip = this.BGM_ROB20;
									this.audioSorce.Play();
									this.text.text = "All Clear";
									break;
								case 520:
									this.audioSorce.clip = this.BGM_ROB21;
									this.audioSorce.Play();
									this.text.text = "Death";
									break;
								case 521:
									this.audioSorce.clip = this.BGM_ROB22;
									this.audioSorce.Play();
									this.text.text = "Game Over";
									break;
								default:
									switch (num)
									{
									case 600:
										this.audioSorce.clip = this.BGM_XX01;
										this.audioSorce.Play();
										this.text.text = "Prologue";
										break;
									case 601:
										this.audioSorce.clip = this.BGM_XX02;
										this.audioSorce.Play();
										this.text.text = "Welcome to Hell";
										break;
									case 602:
										this.audioSorce.clip = this.BGM_XX03_Intro;
										this.audioSorce.Play();
										this.text.text = "Intro/Map";
										break;
									case 603:
										this.audioSorce.clip = this.BGM_XX04_Intro;
										this.audioSorce.Play();
										this.text.text = "Opposing Bloodlines";
										break;
									case 604:
										this.audioSorce.clip = this.BGM_XX05_Intro;
										this.audioSorce.Play();
										this.text.text = "Road to the Enemy";
										break;
									case 605:
										this.audioSorce.clip = this.BGM_XX06;
										this.audioSorce.Play();
										this.text.text = "Dancing in Phantasmic Hell";
										break;
									case 606:
										this.audioSorce.clip = this.BGM_XX07_Intro;
										this.audioSorce.Play();
										this.text.text = "Vampire Killer";
										break;
									case 607:
										this.audioSorce.clip = this.BGM_XX08_Intro;
										this.audioSorce.Play();
										this.text.text = "Bloody Tears";
										break;
									case 608:
										this.audioSorce.clip = this.BGM_XX09_Intro;
										this.audioSorce.Play();
										this.text.text = "Cemetery";
										break;
									case 609:
										this.audioSorce.clip = this.BGM_XX10;
										this.audioSorce.Play();
										this.text.text = "Rescue";
										break;
									case 610:
										this.audioSorce.clip = this.BGM_XX11_Intro;
										this.audioSorce.Play();
										this.text.text = "Opus 13";
										break;
									case 611:
										this.audioSorce.clip = this.BGM_XX12_Intro;
										this.audioSorce.Play();
										this.text.text = "Picture of a Ghost Ship";
										break;
									case 612:
										this.audioSorce.clip = this.BGM_XX13_Intro;
										this.audioSorce.Play();
										this.text.text = "Beginning";
										break;
									case 613:
										this.audioSorce.clip = this.BGM_XX14;
										this.audioSorce.Play();
										this.text.text = "The Den";
										break;
									case 614:
										this.audioSorce.clip = this.BGM_XX15_Intro;
										this.audioSorce.Play();
										this.text.text = "Illusionary Dance";
										break;
									case 615:
										this.audioSorce.clip = this.BGM_XX16;
										this.audioSorce.Play();
										this.text.text = "Ending";
										break;
									case 616:
										this.audioSorce.clip = this.BGM_XX17;
										this.audioSorce.Play();
										this.text.text = "Credits";
										break;
									case 617:
										this.audioSorce.clip = this.BGM_XX18;
										this.audioSorce.Play();
										this.text.text = "Stage Clear";
										break;
									case 618:
										this.audioSorce.clip = this.BGM_XX19;
										this.audioSorce.Play();
										this.text.text = "Player Miss";
										break;
									case 619:
										this.audioSorce.clip = this.BGM_XX20;
										this.audioSorce.Play();
										this.text.text = "Game Over";
										break;
									default:
										switch (num)
										{
										case 700:
											this.audioSorce.clip = this.BGM_HC01;
											this.audioSorce.Play();
											this.text.text = "Dracula's Resurrection";
											break;
										case 701:
											this.audioSorce.clip = this.BGM_HC02;
											this.audioSorce.Play();
											this.text.text = "Welcome to Hell";
											break;
										case 702:
											this.audioSorce.clip = this.BGM_HC03;
											this.audioSorce.Play();
											this.text.text = "Wedding March Tragedy";
											break;
										case 703:
											this.audioSorce.clip = this.BGM_HC04;
											this.audioSorce.Play();
											this.text.text = "Cross Your Heart";
											break;
										case 704:
											this.audioSorce.clip = this.BGM_HC05_Intro;
											this.audioSorce.Play();
											this.text.text = "Devil's Resurrection";
											break;
										case 705:
											this.audioSorce.clip = this.BGM_HC06_Intro;
											this.audioSorce.Play();
											this.text.text = "Devil's Revival";
											break;
										case 706:
											this.audioSorce.clip = this.BGM_HC07;
											this.audioSorce.Play();
											this.text.text = "No Return";
											break;
										case 707:
											this.audioSorce.clip = this.BGM_HC08;
											this.audioSorce.Play();
											this.text.text = "Bloody Tears";
											break;
										case 708:
											this.audioSorce.clip = this.BGM_HC09;
											this.audioSorce.Play();
											this.text.text = "Den of Worship";
											break;
										case 709:
											this.audioSorce.clip = this.BGM_HC10;
											this.audioSorce.Play();
											this.text.text = "Beat of The ClockTower";
											break;
										case 710:
											this.audioSorce.clip = this.BGM_HC11;
											this.audioSorce.Play();
											this.text.text = "Don't Wait Until Night";
											break;
										case 711:
											this.audioSorce.clip = this.BGM_HC12;
											this.audioSorce.Play();
											this.text.text = "Dracula's Room";
											break;
										case 712:
											this.audioSorce.clip = this.BGM_HC13;
											this.audioSorce.Play();
											this.text.text = "Final Battle";
											break;
										case 713:
											this.audioSorce.clip = this.BGM_HC14;
											this.audioSorce.Play();
											this.text.text = "Ending";
											break;
										case 714:
											this.audioSorce.clip = this.BGM_HC15;
											this.audioSorce.Play();
											this.text.text = "Sent to the Devil's Requiem";
											break;
										case 715:
											this.audioSorce.clip = this.BGM_HC16;
											this.audioSorce.Play();
											this.text.text = "The Haunted Castle Medley";
											break;
										case 716:
											this.audioSorce.clip = this.BGM_HC17;
											this.audioSorce.Play();
											this.text.text = "Stage Clear";
											break;
										case 717:
											this.audioSorce.clip = this.BGM_HC18;
											this.audioSorce.Play();
											this.text.text = "Game Over";
											break;
										default:
											switch (num)
											{
											case 100:
												this.audioSorce.clip = this.BGM_CV01;
												this.audioSorce.Play();
												this.text.text = "Underground";
												break;
											case 101:
												this.audioSorce.clip = this.BGM_CV02;
												this.audioSorce.Play();
												this.text.text = "Vampire Killer";
												break;
											case 102:
												this.audioSorce.clip = this.BGM_CV03;
												this.audioSorce.Play();
												this.text.text = "Poison Mind";
												break;
											case 103:
												this.audioSorce.clip = this.BGM_CV04_Intro;
												this.audioSorce.Play();
												this.text.text = "Stalker";
												break;
											case 104:
												this.audioSorce.clip = this.BGM_CV05_Intro;
												this.audioSorce.Play();
												this.text.text = "Wicked Child";
												break;
											case 105:
												this.audioSorce.clip = this.BGM_CV06_Intro;
												this.audioSorce.Play();
												this.text.text = "Walking on the Edge";
												break;
											case 106:
												this.audioSorce.clip = this.BGM_CV07_Intro;
												this.audioSorce.Play();
												this.text.text = "Heart of Fire";
												break;
											case 107:
												this.audioSorce.clip = this.BGM_CV08;
												this.audioSorce.Play();
												this.text.text = "Out of Time";
												break;
											case 108:
												this.audioSorce.clip = this.BGM_CV09;
												this.audioSorce.Play();
												this.text.text = "Nothing to Lose";
												break;
											case 109:
												this.audioSorce.clip = this.BGM_CV10_Intro;
												this.audioSorce.Play();
												this.text.text = "Black Knight";
												break;
											case 110:
												this.audioSorce.clip = this.BGM_CV11_Once;
												this.audioSorce.Play();
												this.text.text = "Voyager";
												break;
											}
											break;
										}
										break;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				break;
			}
			this.introPlayed = true;
			this.targetAnim.SetTrigger("TextOut");
		}

		// Token: 0x0600324B RID: 12875 RVA: 0x005D3798 File Offset: 0x005D1998
		[PunRPC]
		private void ReciveChangeBGMCall(int num)
		{
			this.audioSorce.loop = false;
			this.currentSongNumber = num;
			switch (num)
			{
			case 800:
				this.audioSorce.clip = this.BGM_OTHERS01_Intro;
				this.audioSorce.Play();
				this.text.text = "飛翔月影";
				break;
			case 801:
				this.audioSorce.clip = this.BGM_OTHERS02;
				this.audioSorce.Play();
				this.text.text = "Transcend fear and despair";
				break;
			case 802:
				this.audioSorce.clip = this.BGM_OOE01;
				this.audioSorce.Play();
				this.text.text = "An Empty Tome";
				break;
			case 803:
				this.audioSorce.clip = this.BGM_OOE02;
				this.audioSorce.Play();
				this.text.text = "Consummation";
				break;
			case 804:
				this.audioSorce.clip = this.BGM_OOE03;
				this.audioSorce.Play();
				this.text.text = "Ecclesia";
				break;
			case 805:
				this.audioSorce.clip = this.BGM_OOE04;
				this.audioSorce.Play();
				this.text.text = "Requiem of Star-Crossed Nights";
				break;
			case 806:
				this.audioSorce.clip = this.BGM_OOE05;
				this.audioSorce.Play();
				this.text.text = "Suspicions";
				break;
			case 807:
				this.audioSorce.clip = this.BGM_OOE06;
				this.audioSorce.Play();
				this.text.text = "A Clashing of Waves";
				break;
			case 808:
				this.audioSorce.clip = this.BGM_OOE07_Intro;
				this.audioSorce.Play();
				this.text.text = "A Prologue";
				break;
			case 809:
				this.audioSorce.clip = this.BGM_OOE08_Intro;
				this.audioSorce.Play();
				this.text.text = "An Empty Tome(In Game)";
				break;
			case 810:
				this.audioSorce.clip = this.BGM_OOE09_Intro;
				this.audioSorce.Play();
				this.text.text = "An Empty Tome(Unused Track)";
				break;
			case 811:
				this.audioSorce.clip = this.BGM_OOE10;
				this.audioSorce.Play();
				this.text.text = "Armory Arabesque";
				break;
			case 812:
				this.audioSorce.clip = this.BGM_OOE11;
				this.audioSorce.Play();
				this.text.text = "Cantus Montetten -1";
				break;
			case 813:
				this.audioSorce.clip = this.BGM_OOE12_Intro;
				this.audioSorce.Play();
				this.text.text = "Chamber of Ruin";
				break;
			case 814:
				this.audioSorce.clip = this.BGM_OOE13_Intro;
				this.audioSorce.Play();
				this.text.text = "Chapel Hidden in Smoke";
				break;
			case 815:
				this.audioSorce.clip = this.BGM_OOE14;
				this.audioSorce.Play();
				this.text.text = "Dark Holy Road";
				break;
			case 816:
				this.audioSorce.clip = this.BGM_OOE15_Intro;
				this.audioSorce.Play();
				this.text.text = "Destiny's Stage";
				break;
			case 817:
				this.audioSorce.clip = this.BGM_OOE16_Intro;
				this.audioSorce.Play();
				this.text.text = "Dissonant Courage";
				break;
			case 818:
				this.audioSorce.clip = this.BGM_OOE17_Intro;
				this.audioSorce.Play();
				this.text.text = "Dissonant Courage(Unused Track)";
				break;
			case 819:
				this.audioSorce.clip = this.BGM_OOE18_Intro;
				this.audioSorce.Play();
				this.text.text = "Deliberate Blink";
				break;
			case 820:
				this.audioSorce.clip = this.BGM_OOE19_Intro;
				this.audioSorce.Play();
				this.text.text = "Ebony Wings";
				break;
			case 821:
				this.audioSorce.clip = this.BGM_OOE20;
				this.audioSorce.Play();
				this.text.text = "Edge of the Sky";
				break;
			case 822:
				this.audioSorce.clip = this.BGM_OOE21;
				this.audioSorce.Play();
				this.text.text = "Edge of the Sky(Unused Track)";
				break;
			case 823:
				this.audioSorce.clip = this.BGM_OOE22_Intro;
				this.audioSorce.Play();
				this.text.text = "Emerald Mist";
				break;
			case 824:
				this.audioSorce.clip = this.BGM_OOE23;
				this.audioSorce.Play();
				this.text.text = "Enterprising Mercantilism";
				break;
			case 825:
				this.audioSorce.clip = this.BGM_OOE24_Intro;
				this.audioSorce.Play();
				this.text.text = "Former Room 2";
				break;
			case 826:
				this.audioSorce.clip = this.BGM_OOE25_Intro;
				this.audioSorce.Play();
				this.text.text = "Gate of the Underworld(Unused Track)";
				break;
			case 827:
				this.audioSorce.clip = this.BGM_OOE26_Intro;
				this.audioSorce.Play();
				this.text.text = "Hard Won Nobility";
				break;
			case 828:
				this.audioSorce.clip = this.BGM_OOE27;
				this.audioSorce.Play();
				this.text.text = "Heroic Dawing";
				break;
			case 829:
				this.audioSorce.clip = this.BGM_OOE28;
				this.audioSorce.Play();
				this.text.text = "Jaw of a Scorched Earth";
				break;
			case 830:
				this.audioSorce.clip = this.BGM_OOE29_Intro;
				this.audioSorce.Play();
				this.text.text = "Lament to the Master";
				break;
			case 831:
				this.audioSorce.clip = this.BGM_OOE30_Intro;
				this.audioSorce.Play();
				this.text.text = "Lone Challenger";
				break;
			case 832:
				this.audioSorce.clip = this.BGM_OOE31_Intro;
				this.audioSorce.Play();
				this.text.text = "Malak's Labyrinth";
				break;
			case 833:
				this.audioSorce.clip = this.BGM_OOE32_Intro;
				this.audioSorce.Play();
				this.text.text = "Oncoming Dread";
				break;
			case 834:
				this.audioSorce.clip = this.BGM_OOE33_Intro;
				this.audioSorce.Play();
				this.text.text = "Order of the Demon";
				break;
			case 835:
				this.audioSorce.clip = this.BGM_OOE34_Intro;
				this.audioSorce.Play();
				this.text.text = "Order of the Demon(Unused Track)";
				break;
			case 836:
				this.audioSorce.clip = this.BGM_OOE35;
				this.audioSorce.Play();
				this.text.text = "Passing Into the Night";
				break;
			case 837:
				this.audioSorce.clip = this.BGM_OOE36_Intro;
				this.audioSorce.Play();
				this.text.text = "Reunion";
				break;
			case 838:
				this.audioSorce.clip = this.BGM_OOE37_Intro;
				this.audioSorce.Play();
				this.text.text = "Rhapsody of the Forsaken(Unused Track)";
				break;
			case 839:
				this.audioSorce.clip = this.BGM_OOE38_Intro;
				this.audioSorce.Play();
				this.text.text = "Rhapsody of the Forsaken";
				break;
			case 840:
				this.audioSorce.clip = this.BGM_OOE39_Intro;
				this.audioSorce.Play();
				this.text.text = "Riddle";
				break;
			case 841:
				this.audioSorce.clip = this.BGM_OOE40;
				this.audioSorce.Play();
				this.text.text = "Rituals";
				break;
			case 842:
				this.audioSorce.clip = this.BGM_OOE41;
				this.audioSorce.Play();
				this.text.text = "Sapphire Elegy";
				break;
			case 843:
				this.audioSorce.clip = this.BGM_OOE42_Intro;
				this.audioSorce.Play();
				this.text.text = "Serenade of the Hearth";
				break;
			case 844:
				this.audioSorce.clip = this.BGM_OOE43_Intro;
				this.audioSorce.Play();
				this.text.text = "Shadow's Stronghold";
				break;
			case 845:
				this.audioSorce.clip = this.BGM_OOE44_Intro;
				this.audioSorce.Play();
				this.text.text = "Sorrow's Distortion";
				break;
			case 846:
				this.audioSorce.clip = this.BGM_OOE45_Intro;
				this.audioSorce.Play();
				this.text.text = "Symphony of Battle";
				break;
			case 847:
				this.audioSorce.clip = this.BGM_OOE46_Intro;
				this.audioSorce.Play();
				this.text.text = "The Colossus";
				break;
			case 848:
				this.audioSorce.clip = this.BGM_OOE47;
				this.audioSorce.Play();
				this.text.text = "Tower of Dolls";
				break;
			case 849:
				this.audioSorce.clip = this.BGM_OOE48_Intro;
				this.audioSorce.Play();
				this.text.text = "Trace of Rage";
				break;
			case 850:
				this.audioSorce.clip = this.BGM_OOE49_Intro;
				this.audioSorce.Play();
				this.text.text = "Tragedy's Pulse";
				break;
			case 851:
				this.audioSorce.clip = this.BGM_OOE50_Intro;
				this.audioSorce.Play();
				this.text.text = "Unholy Vespers";
				break;
			case 852:
				this.audioSorce.clip = this.BGM_OOE51_Intro;
				this.audioSorce.Play();
				this.text.text = "Vanishing";
				break;
			case 853:
				this.audioSorce.clip = this.BGM_OOE52_Intro;
				this.audioSorce.Play();
				this.text.text = "Wandering the Crystal Blue";
				break;
			case 854:
				this.audioSorce.clip = this.BGM_OOE53_Intro;
				this.audioSorce.Play();
				this.text.text = "Wandering the Crystal Blue(Unused Track)";
				break;
			case 855:
				this.audioSorce.clip = this.BGM_OOE54;
				this.audioSorce.Play();
				this.text.text = "Welcome to Legend";
				break;
			default:
				switch (num)
				{
				case 400:
					this.audioSorce.clip = this.BGM_SOTN01;
					this.audioSorce.Play();
					this.text.text = "Metamorphosis";
					break;
				case 401:
					this.audioSorce.clip = this.BGM_SOTN02_Intro;
					this.audioSorce.Play();
					this.text.text = "Prologue";
					break;
				case 402:
					this.audioSorce.clip = this.BGM_SOTN03_Intro;
					this.audioSorce.Play();
					this.text.text = "Dance of Illusions";
					break;
				case 403:
					this.audioSorce.clip = this.BGM_SOTN04;
					this.audioSorce.Play();
					this.text.text = "Moonlight Nocturne";
					break;
				case 404:
					this.audioSorce.clip = this.BGM_SOTN05;
					this.audioSorce.Play();
					this.text.text = "Prayer";
					break;
				case 405:
					this.audioSorce.clip = this.BGM_SOTN06_Intro;
					this.audioSorce.Play();
					this.text.text = "Bloody Tears (Remix 2)";
					break;
				case 406:
					this.audioSorce.clip = this.BGM_SOTN07_Intro;
					this.audioSorce.Play();
					this.text.text = "Dracula's Castle";
					break;
				case 407:
					this.audioSorce.clip = this.BGM_SOTN08_Intro;
					this.audioSorce.Play();
					this.text.text = "Vampire Killer (Remix 2)";
					break;
				case 408:
					this.audioSorce.clip = this.BGM_SOTN09_Intro;
					this.audioSorce.Play();
					this.text.text = "Dance of Gold";
					break;
				case 409:
					this.audioSorce.clip = this.BGM_SOTN10_Intro;
					this.audioSorce.Play();
					this.text.text = "Festival of Servants";
					break;
				case 410:
					this.audioSorce.clip = this.BGM_SOTN11_Intro;
					this.audioSorce.Play();
					this.text.text = "Marble Gallery";
					break;
				case 411:
					this.audioSorce.clip = this.BGM_SOTN12;
					this.audioSorce.Play();
					this.text.text = "Chaconne C'Moll";
					break;
				case 412:
					this.audioSorce.clip = this.BGM_SOTN13_Intro;
					this.audioSorce.Play();
					this.text.text = "Tower of Mist";
					break;
				case 413:
					this.audioSorce.clip = this.BGM_SOTN14_Intro;
					this.audioSorce.Play();
					this.text.text = "Nocturne";
					break;
				case 414:
					this.audioSorce.clip = this.BGM_SOTN15_Intro;
					this.audioSorce.Play();
					this.text.text = "Wood Carving Partita";
					break;
				case 415:
					this.audioSorce.clip = this.BGM_SOTN16_Intro;
					this.audioSorce.Play();
					this.text.text = "The Master Librarian";
					break;
				case 416:
					this.audioSorce.clip = this.BGM_SOTN17_Intro;
					this.audioSorce.Play();
					this.text.text = "Crystal Teardrops";
					break;
				case 417:
					this.audioSorce.clip = this.BGM_SOTN18_Intro;
					this.audioSorce.Play();
					this.text.text = "Enchanted Banquet";
					break;
				case 418:
					this.audioSorce.clip = this.BGM_SOTN19;
					this.audioSorce.Play();
					this.text.text = "Abandoned Pit";
					break;
				case 419:
					this.audioSorce.clip = this.BGM_SOTN20_Intro;
					this.audioSorce.Play();
					this.text.text = "Raindbow Cemetery";
					break;
				case 420:
					this.audioSorce.clip = this.BGM_SOTN21_Intro;
					this.audioSorce.Play();
					this.text.text = "Death Ballad";
					break;
				case 421:
					this.audioSorce.clip = this.BGM_SOTN22_Intro;
					this.audioSorce.Play();
					this.text.text = "Vampire Killer (Remix 1)";
					break;
				case 422:
					this.audioSorce.clip = this.BGM_SOTN23_Intro;
					this.audioSorce.Play();
					this.text.text = "Bloody Tears (Remix 1)";
					break;
				case 423:
					this.audioSorce.clip = this.BGM_SOTN24_Intro;
					this.audioSorce.Play();
					this.text.text = "Requiem for the Gods";
					break;
				case 424:
					this.audioSorce.clip = this.BGM_SOTN25;
					this.audioSorce.Play();
					this.text.text = "Bloody Confession";
					break;
				case 425:
					this.audioSorce.clip = this.BGM_SOTN26_Intro;
					this.audioSorce.Play();
					this.text.text = "Dance of Pales";
					break;
				case 426:
					this.audioSorce.clip = this.BGM_SOTN27_Intro;
					this.audioSorce.Play();
					this.text.text = "Wandering Ghosts";
					break;
				case 427:
					this.audioSorce.clip = this.BGM_SOTN28_Intro;
					this.audioSorce.Play();
					this.text.text = "The Tragic Prince";
					break;
				case 428:
					this.audioSorce.clip = this.BGM_SOTN29_Intro;
					this.audioSorce.Play();
					this.text.text = "Heavenly Doorway";
					break;
				case 429:
					this.audioSorce.clip = this.BGM_SOTN30_Intro;
					this.audioSorce.Play();
					this.text.text = "Blood Relations";
					break;
				case 430:
					this.audioSorce.clip = this.BGM_SOTN31;
					this.audioSorce.Play();
					this.text.text = "Metamorphosis 2";
					break;
				case 431:
					this.audioSorce.clip = this.BGM_SOTN32_Intro;
					this.audioSorce.Play();
					this.text.text = "Final Toccata";
					break;
				case 432:
					this.audioSorce.clip = this.BGM_SOTN33_Intro;
					this.audioSorce.Play();
					this.text.text = "Lost Painting";
					break;
				case 433:
					this.audioSorce.clip = this.BGM_SOTN34_Intro;
					this.audioSorce.Play();
					this.text.text = "Beginning";
					break;
				case 434:
					this.audioSorce.clip = this.BGM_SOTN35_Intro;
					this.audioSorce.Play();
					this.text.text = "Curse Zone";
					break;
				case 435:
					this.audioSorce.clip = this.BGM_SOTN36_Intro;
					this.audioSorce.Play();
					this.text.text = "Door of Holy Spirits";
					break;
				case 436:
					this.audioSorce.clip = this.BGM_SOTN37;
					this.audioSorce.Play();
					this.text.text = "The Door to the Abyss";
					break;
				case 437:
					this.audioSorce.clip = this.BGM_SOTN38_Intro;
					this.audioSorce.Play();
					this.text.text = "Guardian";
					break;
				case 438:
					this.audioSorce.clip = this.BGM_SOTN39_Intro;
					this.audioSorce.Play();
					this.text.text = "Black Banquet";
					break;
				case 439:
					this.audioSorce.clip = this.BGM_SOTN40;
					this.audioSorce.Play();
					this.text.text = "Metamorphosis 3";
					break;
				case 440:
					this.audioSorce.clip = this.BGM_SOTN41;
					this.audioSorce.Play();
					this.text.text = "I Am the Wind";
					break;
				case 441:
					this.audioSorce.clip = this.BGM_SOTN42;
					this.audioSorce.Play();
					this.text.text = "I Am the Wind (Instrumental)";
					break;
				case 442:
					this.audioSorce.clip = this.BGM_SOTN43;
					this.audioSorce.Play();
					this.text.text = "Land of Benediction";
					break;
				case 443:
					this.audioSorce.clip = this.BGM_SOTN44;
					this.audioSorce.Play();
					this.text.text = "Silence";
					break;
				case 444:
					this.audioSorce.clip = this.BGM_SOTN45_Intro;
					this.audioSorce.Play();
					this.text.text = "Beginning (Inverted)";
					break;
				case 445:
					this.audioSorce.clip = this.BGM_SOTN46_Intro;
					this.audioSorce.Play();
					this.text.text = "Unknown Track";
					break;
				case 446:
					this.audioSorce.clip = this.BGM_SOTN47_Intro;
					this.audioSorce.Play();
					this.text.text = "Dracula's Castle (Remix)";
					break;
				case 447:
					this.audioSorce.clip = this.BGM_SOTN48_Intro;
					this.audioSorce.Play();
					this.text.text = "Nocturne";
					break;
				case 448:
					this.audioSorce.clip = this.BGM_SOTN49;
					this.audioSorce.Play();
					this.text.text = "Mournful Serenade";
					break;
				default:
					switch (num)
					{
					case 0:
						this.audioSorce.clip = this.BGM_HD01_Intro;
						this.audioSorce.Play();
						this.text.text = "荒城回廊";
						break;
					case 1:
						this.audioSorce.clip = this.BGM_HD02_Intro;
						this.audioSorce.Play();
						this.text.text = "闇夜の激突";
						break;
					case 2:
						this.audioSorce.clip = this.BGM_HD03_Intro;
						this.audioSorce.Play();
						this.text.text = "懺悔の後に";
						break;
					case 3:
						this.audioSorce.clip = this.BGM_HD04;
						this.audioSorce.Play();
						this.text.text = "PHANTOM OF FEAR";
						break;
					case 4:
						this.audioSorce.clip = this.BGM_HD05_Intro;
						this.audioSorce.Play();
						this.text.text = "尖白の闘志";
						break;
					case 5:
						this.audioSorce.clip = this.BGM_HD06_Intro;
						this.audioSorce.Play();
						this.text.text = "見上げよ、闇を";
						break;
					case 6:
						this.audioSorce.clip = this.BGM_HD07;
						this.audioSorce.Play();
						this.text.text = "暴虐のエスキース";
						break;
					case 7:
						this.audioSorce.clip = this.BGM_HD08_Intro;
						this.audioSorce.Play();
						this.text.text = "漆黒の翼";
						break;
					case 8:
						this.audioSorce.clip = this.BGM_HD09_Intro;
						this.audioSorce.Play();
						this.text.text = "闘魂狂詩曲";
						break;
					case 9:
						this.audioSorce.clip = this.BGM_HD10_Intro;
						this.audioSorce.Play();
						this.text.text = "ガルガンチュア";
						break;
					case 10:
						this.audioSorce.clip = this.BGM_HD11_Intro;
						this.audioSorce.Play();
						this.text.text = "繻紗魔交響詩";
						break;
					case 11:
						this.audioSorce.clip = this.BGM_HD12_Intro;
						this.audioSorce.Play();
						this.text.text = "幻想的舞曲";
						break;
					case 12:
						this.audioSorce.clip = this.BGM_HD13_Intro;
						this.audioSorce.Play();
						this.text.text = "Tanz mit einem Clown";
						break;
					case 13:
						this.audioSorce.clip = this.BGM_HD14_Intro;
						this.audioSorce.Play();
						this.text.text = "CRIMSON BLOOD";
						break;
					case 14:
						this.audioSorce.clip = this.BGM_HD15_Intro;
						this.audioSorce.Play();
						this.text.text = "Ein Weltherrscher";
						break;
					case 15:
						this.audioSorce.clip = this.BGM_HD16_Intro;
						this.audioSorce.Play();
						this.text.text = "Hail from the Past";
						break;
					case 16:
						this.audioSorce.clip = this.BGM_HD17_Intro;
						this.audioSorce.Play();
						this.text.text = "切り裂かれた静寂";
						break;
					case 17:
						this.audioSorce.clip = this.BGM_HD18_Intro;
						this.audioSorce.Play();
						this.text.text = "失われた彩画";
						break;
					case 18:
						this.audioSorce.clip = this.BGM_HD19_Intro;
						this.audioSorce.Play();
						this.text.text = "死の詩曲";
						break;
					case 19:
						this.audioSorce.clip = this.BGM_HD20_Intro;
						this.audioSorce.Play();
						this.text.text = "ドラキュラ城";
						break;
					case 20:
						this.audioSorce.clip = this.BGM_HD21_Intro;
						this.audioSorce.Play();
						this.text.text = "しもべたちの祭典";
						break;
					case 21:
						this.audioSorce.clip = this.BGM_HD22_Intro;
						this.audioSorce.Play();
						this.text.text = "Vampire Killer";
						break;
					case 22:
						this.audioSorce.clip = this.BGM_HD23_Intro;
						this.audioSorce.Play();
						this.text.text = "Nothing to Lose";
						break;
					case 23:
						this.audioSorce.clip = this.BGM_HD24_Intro;
						this.audioSorce.Play();
						this.text.text = "いけ！月風魔";
						break;
					case 24:
						this.audioSorce.clip = this.BGM_HD25_Intro;
						this.audioSorce.Play();
						this.text.text = "龍骨鬼";
						break;
					case 25:
						this.audioSorce.clip = this.BGM_HD26_Intro;
						this.audioSorce.Play();
						this.text.text = "漆黒の進攻";
						break;
					case 26:
						this.audioSorce.clip = this.BGM_HD27_Intro;
						this.audioSorce.Play();
						this.text.text = "悲境の貴公子";
						break;
					case 27:
						this.audioSorce.clip = this.BGM_HD28_Intro;
						this.audioSorce.Play();
						this.text.text = "狂月の招き";
						break;
					case 28:
						this.audioSorce.clip = this.BGM_HD29_Intro;
						this.audioSorce.Play();
						this.text.text = "隠された呪禁";
						break;
					case 29:
						this.audioSorce.clip = this.BGM_HD30_Intro;
						this.audioSorce.Play();
						this.text.text = "黄昏の聖痕";
						break;
					case 30:
						this.audioSorce.clip = this.BGM_HD31_Intro;
						this.audioSorce.Play();
						this.text.text = "夜まで待てない";
						break;
					case 31:
						this.audioSorce.clip = this.BGM_HD32_Intro;
						this.audioSorce.Play();
						this.text.text = "Aquarius";
						break;
					case 32:
						this.audioSorce.clip = this.BGM_HD33_Intro;
						this.audioSorce.Play();
						this.text.text = "Slash";
						break;
					case 33:
						this.audioSorce.clip = this.BGM_HD34_Intro;
						this.audioSorce.Play();
						this.text.text = "乾坤の血族";
						break;
					case 34:
						this.audioSorce.clip = this.BGM_HD35_Intro;
						this.audioSorce.Play();
						this.text.text = "シモンのテーマ";
						break;
					default:
						switch (num)
						{
						case 200:
							this.audioSorce.clip = this.BGM_DOS01_Once;
							this.audioSorce.Play();
							this.text.text = "Cross of the Blue Moon";
							break;
						case 201:
							this.audioSorce.clip = this.BGM_DOS02;
							this.audioSorce.Play();
							this.text.text = "A Fleeting Respite";
							break;
						case 202:
							this.audioSorce.clip = this.BGM_DOS03;
							this.audioSorce.Play();
							this.text.text = "Gloomy Memories";
							break;
						case 203:
							this.audioSorce.clip = this.BGM_DOS04;
							this.audioSorce.Play();
							this.text.text = "Evil Invitation";
							break;
						case 204:
							this.audioSorce.clip = this.BGM_DOS05;
							this.audioSorce.Play();
							this.text.text = "Pitch Black Intrustion";
							break;
						case 205:
							this.audioSorce.clip = this.BGM_DOS06_Intro;
							this.audioSorce.Play();
							this.text.text = "Equipment's Tale";
							break;
						case 206:
							this.audioSorce.clip = this.BGM_DOS07_Intro;
							this.audioSorce.Play();
							this.text.text = "Dracula's Tears";
							break;
						case 207:
							this.audioSorce.clip = this.BGM_DOS08;
							this.audioSorce.Play();
							this.text.text = "Dark Clouds";
							break;
						case 208:
							this.audioSorce.clip = this.BGM_DOS09;
							this.audioSorce.Play();
							this.text.text = "Black Shudder";
							break;
						case 209:
							this.audioSorce.clip = this.BGM_DOS10;
							this.audioSorce.Play();
							this.text.text = "Platinum Moonlight";
							break;
						case 210:
							this.audioSorce.clip = this.BGM_DOS11_Intro;
							this.audioSorce.Play();
							this.text.text = "After Confession";
							break;
						case 211:
							this.audioSorce.clip = this.BGM_DOS12_Intro;
							this.audioSorce.Play();
							this.text.text = "Scarlet Battle Soul";
							break;
						case 212:
							this.audioSorce.clip = this.BGM_DOS13;
							this.audioSorce.Play();
							this.text.text = "Demon Guest House";
							break;
						case 213:
							this.audioSorce.clip = this.BGM_DOS14_Intro;
							this.audioSorce.Play();
							this.text.text = "Echoes of Darkness";
							break;
						case 214:
							this.audioSorce.clip = this.BGM_DOS15;
							this.audioSorce.Play();
							this.text.text = "Condemned Tower";
							break;
						case 215:
							this.audioSorce.clip = this.BGM_DOS16;
							this.audioSorce.Play();
							this.text.text = "Into the Dark Night";
							break;
						case 216:
							this.audioSorce.clip = this.BGM_DOS17_Intro;
							this.audioSorce.Play();
							this.text.text = "Cursed Clock Tower";
							break;
						case 217:
							this.audioSorce.clip = this.BGM_DOS18_Intro;
							this.audioSorce.Play();
							this.text.text = "Subterranean Hell";
							break;
						case 218:
							this.audioSorce.clip = this.BGM_DOS19_Intro;
							this.audioSorce.Play();
							this.text.text = "Vampire Killer";
							break;
						case 219:
							this.audioSorce.clip = this.BGM_DOS20_Intro;
							this.audioSorce.Play();
							this.text.text = "The Pinnacle";
							break;
						case 220:
							this.audioSorce.clip = this.BGM_DOS21_Intro;
							this.audioSorce.Play();
							this.text.text = "Portal to Dark Bravery";
							break;
						case 221:
							this.audioSorce.clip = this.BGM_DOS22;
							this.audioSorce.Play();
							this.text.text = "Underground Melodies";
							break;
						case 222:
							this.audioSorce.clip = this.BGM_DOS23_Intro;
							this.audioSorce.Play();
							this.text.text = "The Abyss";
							break;
						case 223:
							this.audioSorce.clip = this.BGM_DOS24_Intro;
							this.audioSorce.Play();
							this.text.text = "Piercing Battle Fury";
							break;
						case 224:
							this.audioSorce.clip = this.BGM_DOS25_Intro;
							this.audioSorce.Play();
							this.text.text = "Beginning";
							break;
						case 225:
							this.audioSorce.clip = this.BGM_DOS26_Intro;
							this.audioSorce.Play();
							this.text.text = "Bloody Tears";
							break;
						case 226:
							this.audioSorce.clip = this.BGM_DOS27_Intro;
							this.audioSorce.Play();
							this.text.text = "Illusionary Song";
							break;
						case 227:
							this.audioSorce.clip = this.BGM_DOS28_Intro;
							this.audioSorce.Play();
							this.text.text = "After Battle - Blue Memories";
							break;
						case 228:
							this.audioSorce.clip = this.BGM_DOS29;
							this.audioSorce.Play();
							this.text.text = "Momentary Moonlight";
							break;
						case 229:
							this.audioSorce.clip = this.BGM_DOS30;
							this.audioSorce.Play();
							this.text.text = "Amber Scenery (Remix)";
							break;
						case 230:
							this.audioSorce.clip = this.BGM_DOS31;
							this.audioSorce.Play();
							this.text.text = "GameOver";
							break;
						default:
							switch (num)
							{
							case 300:
								this.audioSorce.clip = this.BGM_AOS01;
								this.audioSorce.Play();
								this.text.text = "The Black Sun";
								break;
							case 301:
								this.audioSorce.clip = this.BGM_AOS02;
								this.audioSorce.Play();
								this.text.text = "Name Entry";
								break;
							case 302:
								this.audioSorce.clip = this.BGM_AOS03;
								this.audioSorce.Play();
								this.text.text = "Prologue - Mina's Theme";
								break;
							case 303:
								this.audioSorce.clip = this.BGM_AOS04_Intro;
								this.audioSorce.Play();
								this.text.text = "Castle Corridor";
								break;
							case 304:
								this.audioSorce.clip = this.BGM_AOS05;
								this.audioSorce.Play();
								this.text.text = "Premonition";
								break;
							case 305:
								this.audioSorce.clip = this.BGM_AOS06_Intro;
								this.audioSorce.Play();
								this.text.text = "Chapel";
								break;
							case 306:
								this.audioSorce.clip = this.BGM_AOS07_Intro;
								this.audioSorce.Play();
								this.text.text = "Formidable Enemy";
								break;
							case 307:
								this.audioSorce.clip = this.BGM_AOS08_Intro;
								this.audioSorce.Play();
								this.text.text = "Study";
								break;
							case 308:
								this.audioSorce.clip = this.BGM_AOS09_Intro;
								this.audioSorce.Play();
								this.text.text = "Hammer's Shop";
								break;
							case 309:
								this.audioSorce.clip = this.BGM_AOS10;
								this.audioSorce.Play();
								this.text.text = "Dance Hall";
								break;
							case 310:
								this.audioSorce.clip = this.BGM_AOS11;
								this.audioSorce.Play();
								this.text.text = "Inner Quarters";
								break;
							case 311:
								this.audioSorce.clip = this.BGM_AOS12;
								this.audioSorce.Play();
								this.text.text = "Floating Garden";
								break;
							case 312:
								this.audioSorce.clip = this.BGM_AOS13_Intro;
								this.audioSorce.Play();
								this.text.text = "Clock Tower";
								break;
							case 313:
								this.audioSorce.clip = this.BGM_AOS14_Intro;
								this.audioSorce.Play();
								this.text.text = "Confrontation";
								break;
							case 314:
								this.audioSorce.clip = this.BGM_AOS15_Intro;
								this.audioSorce.Play();
								this.text.text = "Underground Reservoir";
								break;
							case 315:
								this.audioSorce.clip = this.BGM_AOS16_Intro;
								this.audioSorce.Play();
								this.text.text = "The Arena";
								break;
							case 316:
								this.audioSorce.clip = this.BGM_AOS17_Intro;
								this.audioSorce.Play();
								this.text.text = "Forbidden Area";
								break;
							case 317:
								this.audioSorce.clip = this.BGM_AOS18_Intro;
								this.audioSorce.Play();
								this.text.text = "Top Floor";
								break;
							case 318:
								this.audioSorce.clip = this.BGM_AOS19_Intro;
								this.audioSorce.Play();
								this.text.text = "Throne Fights";
								break;
							case 319:
								this.audioSorce.clip = this.BGM_AOS20_Intro;
								this.audioSorce.Play();
								this.text.text = "Dracula's Fate";
								break;
							case 320:
								this.audioSorce.clip = this.BGM_AOS21_Intro;
								this.audioSorce.Play();
								this.text.text = "Don't Wait Until Night";
								break;
							case 321:
								this.audioSorce.clip = this.BGM_AOS22_Intro;
								this.audioSorce.Play();
								this.text.text = "Chaotic Realm";
								break;
							case 322:
								this.audioSorce.clip = this.BGM_AOS23_Intro;
								this.audioSorce.Play();
								this.text.text = "You're Not Alone";
								break;
							case 323:
								this.audioSorce.clip = this.BGM_AOS24_Intro;
								this.audioSorce.Play();
								this.text.text = "Battle With Chaos";
								break;
							case 324:
								this.audioSorce.clip = this.BGM_AOS25_Intro;
								this.audioSorce.Play();
								this.text.text = "Last Battle";
								break;
							case 325:
								this.audioSorce.clip = this.BGM_AOS26_Intro;
								this.audioSorce.Play();
								this.text.text = "Purification - Ending";
								break;
							case 326:
								this.audioSorce.clip = this.BGM_AOS27;
								this.audioSorce.Play();
								this.text.text = "Credits";
								break;
							case 327:
								this.audioSorce.clip = this.BGM_AOS28;
								this.audioSorce.Play();
								this.text.text = "GameOver";
								break;
							default:
								switch (num)
								{
								case 500:
									this.audioSorce.clip = this.BGM_ROB01;
									this.audioSorce.Play();
									this.text.text = "Overture";
									break;
								case 501:
									this.audioSorce.clip = this.BGM_ROB02;
									this.audioSorce.Play();
									this.text.text = "Prayer";
									break;
								case 502:
									this.audioSorce.clip = this.BGM_ROB03_Intro;
									this.audioSorce.Play();
									this.text.text = "Opposing Bloodlines";
									break;
								case 503:
									this.audioSorce.clip = this.BGM_ROB04_Intro;
									this.audioSorce.Play();
									this.text.text = "Vampire Killer";
									break;
								case 504:
									this.audioSorce.clip = this.BGM_ROB05_Intro;
									this.audioSorce.Play();
									this.text.text = "Cross a Fear";
									break;
								case 505:
									this.audioSorce.clip = this.BGM_ROB06_Intro;
									this.audioSorce.Play();
									this.text.text = "Bloody Tears";
									break;
								case 506:
									this.audioSorce.clip = this.BGM_ROB07_Intro;
									this.audioSorce.Play();
									this.text.text = "Cemetery";
									break;
								case 507:
									this.audioSorce.clip = this.BGM_ROB08_Intro;
									this.audioSorce.Play();
									this.text.text = "Beginning";
									break;
								case 508:
									this.audioSorce.clip = this.BGM_ROB09_Intro;
									this.audioSorce.Play();
									this.text.text = "Opus 13";
									break;
								case 509:
									this.audioSorce.clip = this.BGM_ROB10_Intro;
									this.audioSorce.Play();
									this.text.text = "Picture of a Ghost Ship";
									break;
								case 510:
									this.audioSorce.clip = this.BGM_ROB11_Intro;
									this.audioSorce.Play();
									this.text.text = "Slash";
									break;
								case 511:
									this.audioSorce.clip = this.BGM_ROB12;
									this.audioSorce.Play();
									this.text.text = "Road to the Enemy";
									break;
								case 512:
									this.audioSorce.clip = this.BGM_ROB13_Intro;
									this.audioSorce.Play();
									this.text.text = "Dancing in Phantasmic Hell";
									break;
								case 513:
									this.audioSorce.clip = this.BGM_ROB14;
									this.audioSorce.Play();
									this.text.text = "The Den";
									break;
								case 514:
									this.audioSorce.clip = this.BGM_ROB15;
									this.audioSorce.Play();
									this.text.text = "Poison Mind";
									break;
								case 515:
									this.audioSorce.clip = this.BGM_ROB16_Intro;
									this.audioSorce.Play();
									this.text.text = "Illusionary Dance";
									break;
								case 516:
									this.audioSorce.clip = this.BGM_ROB17;
									this.audioSorce.Play();
									this.text.text = "March of the Holy Man";
									break;
								case 517:
									this.audioSorce.clip = this.BGM_ROB18;
									this.audioSorce.Play();
									this.text.text = "Mary Samba";
									break;
								case 518:
									this.audioSorce.clip = this.BGM_ROB19;
									this.audioSorce.Play();
									this.text.text = "Stage Clear";
									break;
								case 519:
									this.audioSorce.clip = this.BGM_ROB20;
									this.audioSorce.Play();
									this.text.text = "All Clear";
									break;
								case 520:
									this.audioSorce.clip = this.BGM_ROB21;
									this.audioSorce.Play();
									this.text.text = "Death";
									break;
								case 521:
									this.audioSorce.clip = this.BGM_ROB22;
									this.audioSorce.Play();
									this.text.text = "Game Over";
									break;
								default:
									switch (num)
									{
									case 600:
										this.audioSorce.clip = this.BGM_XX01;
										this.audioSorce.Play();
										this.text.text = "Prologue";
										break;
									case 601:
										this.audioSorce.clip = this.BGM_XX02;
										this.audioSorce.Play();
										this.text.text = "Welcome to Hell";
										break;
									case 602:
										this.audioSorce.clip = this.BGM_XX03_Intro;
										this.audioSorce.Play();
										this.text.text = "Intro/Map";
										break;
									case 603:
										this.audioSorce.clip = this.BGM_XX04_Intro;
										this.audioSorce.Play();
										this.text.text = "Opposing Bloodlines";
										break;
									case 604:
										this.audioSorce.clip = this.BGM_XX05_Intro;
										this.audioSorce.Play();
										this.text.text = "Road to the Enemy";
										break;
									case 605:
										this.audioSorce.clip = this.BGM_XX06;
										this.audioSorce.Play();
										this.text.text = "Dancing in Phantasmic Hell";
										break;
									case 606:
										this.audioSorce.clip = this.BGM_XX07_Intro;
										this.audioSorce.Play();
										this.text.text = "Vampire Killer";
										break;
									case 607:
										this.audioSorce.clip = this.BGM_XX08_Intro;
										this.audioSorce.Play();
										this.text.text = "Bloody Tears";
										break;
									case 608:
										this.audioSorce.clip = this.BGM_XX09_Intro;
										this.audioSorce.Play();
										this.text.text = "Cemetery";
										break;
									case 609:
										this.audioSorce.clip = this.BGM_XX10;
										this.audioSorce.Play();
										this.text.text = "Rescue";
										break;
									case 610:
										this.audioSorce.clip = this.BGM_XX11_Intro;
										this.audioSorce.Play();
										this.text.text = "Opus 13";
										break;
									case 611:
										this.audioSorce.clip = this.BGM_XX12_Intro;
										this.audioSorce.Play();
										this.text.text = "Picture of a Ghost Ship";
										break;
									case 612:
										this.audioSorce.clip = this.BGM_XX13_Intro;
										this.audioSorce.Play();
										this.text.text = "Beginning";
										break;
									case 613:
										this.audioSorce.clip = this.BGM_XX14;
										this.audioSorce.Play();
										this.text.text = "The Den";
										break;
									case 614:
										this.audioSorce.clip = this.BGM_XX15_Intro;
										this.audioSorce.Play();
										this.text.text = "Illusionary Dance";
										break;
									case 615:
										this.audioSorce.clip = this.BGM_XX16;
										this.audioSorce.Play();
										this.text.text = "Ending";
										break;
									case 616:
										this.audioSorce.clip = this.BGM_XX17;
										this.audioSorce.Play();
										this.text.text = "Credits";
										break;
									case 617:
										this.audioSorce.clip = this.BGM_XX18;
										this.audioSorce.Play();
										this.text.text = "Stage Clear";
										break;
									case 618:
										this.audioSorce.clip = this.BGM_XX19;
										this.audioSorce.Play();
										this.text.text = "Player Miss";
										break;
									case 619:
										this.audioSorce.clip = this.BGM_XX20;
										this.audioSorce.Play();
										this.text.text = "Game Over";
										break;
									default:
										switch (num)
										{
										case 700:
											this.audioSorce.clip = this.BGM_HC01;
											this.audioSorce.Play();
											this.text.text = "Dracula's Resurrection";
											break;
										case 701:
											this.audioSorce.clip = this.BGM_HC02;
											this.audioSorce.Play();
											this.text.text = "Welcome to Hell";
											break;
										case 702:
											this.audioSorce.clip = this.BGM_HC03;
											this.audioSorce.Play();
											this.text.text = "Wedding March Tragedy";
											break;
										case 703:
											this.audioSorce.clip = this.BGM_HC04;
											this.audioSorce.Play();
											this.text.text = "Cross Your Heart";
											break;
										case 704:
											this.audioSorce.clip = this.BGM_HC05_Intro;
											this.audioSorce.Play();
											this.text.text = "Devil's Resurrection";
											break;
										case 705:
											this.audioSorce.clip = this.BGM_HC06_Intro;
											this.audioSorce.Play();
											this.text.text = "Devil's Revival";
											break;
										case 706:
											this.audioSorce.clip = this.BGM_HC07;
											this.audioSorce.Play();
											this.text.text = "No Return";
											break;
										case 707:
											this.audioSorce.clip = this.BGM_HC08;
											this.audioSorce.Play();
											this.text.text = "Bloody Tears";
											break;
										case 708:
											this.audioSorce.clip = this.BGM_HC09;
											this.audioSorce.Play();
											this.text.text = "Den of Worship";
											break;
										case 709:
											this.audioSorce.clip = this.BGM_HC10;
											this.audioSorce.Play();
											this.text.text = "Beat of The ClockTower";
											break;
										case 710:
											this.audioSorce.clip = this.BGM_HC11;
											this.audioSorce.Play();
											this.text.text = "Don't Wait Until Night";
											break;
										case 711:
											this.audioSorce.clip = this.BGM_HC12;
											this.audioSorce.Play();
											this.text.text = "Dracula's Room";
											break;
										case 712:
											this.audioSorce.clip = this.BGM_HC13;
											this.audioSorce.Play();
											this.text.text = "Final Battle";
											break;
										case 713:
											this.audioSorce.clip = this.BGM_HC14;
											this.audioSorce.Play();
											this.text.text = "Ending";
											break;
										case 714:
											this.audioSorce.clip = this.BGM_HC15;
											this.audioSorce.Play();
											this.text.text = "Sent to the Devil's Requiem";
											break;
										case 715:
											this.audioSorce.clip = this.BGM_HC16;
											this.audioSorce.Play();
											this.text.text = "The Haunted Castle Medley";
											break;
										case 716:
											this.audioSorce.clip = this.BGM_HC17;
											this.audioSorce.Play();
											this.text.text = "Stage Clear";
											break;
										case 717:
											this.audioSorce.clip = this.BGM_HC18;
											this.audioSorce.Play();
											this.text.text = "Game Over";
											break;
										default:
											switch (num)
											{
											case 100:
												this.audioSorce.clip = this.BGM_CV01;
												this.audioSorce.Play();
												this.text.text = "Underground";
												break;
											case 101:
												this.audioSorce.clip = this.BGM_CV02;
												this.audioSorce.Play();
												this.text.text = "Vampire Killer";
												break;
											case 102:
												this.audioSorce.clip = this.BGM_CV03;
												this.audioSorce.Play();
												this.text.text = "Poison Mind";
												break;
											case 103:
												this.audioSorce.clip = this.BGM_CV04_Intro;
												this.audioSorce.Play();
												this.text.text = "Stalker";
												break;
											case 104:
												this.audioSorce.clip = this.BGM_CV05_Intro;
												this.audioSorce.Play();
												this.text.text = "Wicked Child";
												break;
											case 105:
												this.audioSorce.clip = this.BGM_CV06_Intro;
												this.audioSorce.Play();
												this.text.text = "Walking on the Edge";
												break;
											case 106:
												this.audioSorce.clip = this.BGM_CV07_Intro;
												this.audioSorce.Play();
												this.text.text = "Heart of Fire";
												break;
											case 107:
												this.audioSorce.clip = this.BGM_CV08;
												this.audioSorce.Play();
												this.text.text = "Out of Time";
												break;
											case 108:
												this.audioSorce.clip = this.BGM_CV09;
												this.audioSorce.Play();
												this.text.text = "Nothing to Lose";
												break;
											case 109:
												this.audioSorce.clip = this.BGM_CV10_Intro;
												this.audioSorce.Play();
												this.text.text = "Black Knight";
												break;
											case 110:
												this.audioSorce.clip = this.BGM_CV11_Once;
												this.audioSorce.Play();
												this.text.text = "Voyager";
												break;
											}
											break;
										}
										break;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				break;
			}
			this.introPlayed = true;
			this.targetAnim.SetTrigger("TextOut");
		}

		// Token: 0x0600324C RID: 12876 RVA: 0x005D7020 File Offset: 0x005D5220
		public void Reset()
		{
			this.currentSongNumber = PlayerPrefs.GetInt(this.startBGMStageName);
			string text = this.startBGMStageName;
			switch (text)
			{
			case "BGMStage01":
				this.defalutSongNumber = 0;
				break;
			case "BGMStage02":
				this.defalutSongNumber = 2;
				break;
			case "BGMStage03":
				this.defalutSongNumber = 3;
				break;
			case "BGMStage04":
				this.defalutSongNumber = 5;
				break;
			case "BGMStage05":
				this.defalutSongNumber = 7;
				break;
			case "BGMStage06":
				this.defalutSongNumber = 9;
				break;
			case "BGMStage06_Alternative":
				this.defalutSongNumber = 847;
				break;
			case "BGMStage07":
				this.defalutSongNumber = 15;
				break;
			case "BGMStage08":
				this.defalutSongNumber = 17;
				break;
			case "BGMStage12":
				this.defalutSongNumber = 426;
				break;
			case "BGMStage13":
				this.defalutSongNumber = 839;
				break;
			}
			int @int = PlayerPrefs.GetInt("SoundSetChanged");
			float @float = PlayerPrefs.GetFloat("BGMVolume");
			float float2 = PlayerPrefs.GetFloat("CVVolume");
			float float3 = PlayerPrefs.GetFloat("SEVolume");
			if (this.currentSongNumber == 0)
			{
				this.currentSongNumber = this.defalutSongNumber;
			}
			float volume = @float / 100f;
			float num2 = float2 / 100f;
			float num3 = float3 / 100f;
			if (@int != 0)
			{
				if (@int == 1)
				{
					this.audioSorce.volume = volume;
					this.cVVolume = num2;
					this.sEVolume = num3;
				}
			}
			else
			{
				this.audioSorce.volume = 0.6f;
				this.cVVolume = 1f;
				this.sEVolume = 1f;
			}
			this.check = false;
			this.introPlayed = false;
		}

		// Token: 0x040064C8 RID: 25800
		public AudioClip BGM_GOLDBOX;

		// Token: 0x040064C9 RID: 25801
		public AudioClip BGM_SUCCESS01;

		// Token: 0x040064CA RID: 25802
		public AudioClip BGM_FAILED01;

		// Token: 0x040064CB RID: 25803
		public AudioClip BGM_SUCCESS02;

		// Token: 0x040064CC RID: 25804
		public AudioClip BGM_FAILED02;

		// Token: 0x040064CD RID: 25805
		public AudioClip BGM_SUCCESS03;

		// Token: 0x040064CE RID: 25806
		public AudioClip BGM_FAILED03;

		// Token: 0x040064CF RID: 25807
		public AudioClip BGM_HD01_Intro;

		// Token: 0x040064D0 RID: 25808
		public AudioClip BGM_HD01;

		// Token: 0x040064D1 RID: 25809
		public AudioClip BGM_HD02_Intro;

		// Token: 0x040064D2 RID: 25810
		public AudioClip BGM_HD02;

		// Token: 0x040064D3 RID: 25811
		public AudioClip BGM_HD03_Intro;

		// Token: 0x040064D4 RID: 25812
		public AudioClip BGM_HD03;

		// Token: 0x040064D5 RID: 25813
		public AudioClip BGM_HD04;

		// Token: 0x040064D6 RID: 25814
		public AudioClip BGM_HD05_Intro;

		// Token: 0x040064D7 RID: 25815
		public AudioClip BGM_HD05;

		// Token: 0x040064D8 RID: 25816
		public AudioClip BGM_HD06_Intro;

		// Token: 0x040064D9 RID: 25817
		public AudioClip BGM_HD06;

		// Token: 0x040064DA RID: 25818
		public AudioClip BGM_HD07;

		// Token: 0x040064DB RID: 25819
		public AudioClip BGM_HD08_Intro;

		// Token: 0x040064DC RID: 25820
		public AudioClip BGM_HD08;

		// Token: 0x040064DD RID: 25821
		public AudioClip BGM_HD09_Intro;

		// Token: 0x040064DE RID: 25822
		public AudioClip BGM_HD09;

		// Token: 0x040064DF RID: 25823
		public AudioClip BGM_HD10_Intro;

		// Token: 0x040064E0 RID: 25824
		public AudioClip BGM_HD10;

		// Token: 0x040064E1 RID: 25825
		public AudioClip BGM_HD11_Intro;

		// Token: 0x040064E2 RID: 25826
		public AudioClip BGM_HD11;

		// Token: 0x040064E3 RID: 25827
		public AudioClip BGM_HD12_Intro;

		// Token: 0x040064E4 RID: 25828
		public AudioClip BGM_HD12;

		// Token: 0x040064E5 RID: 25829
		public AudioClip BGM_HD13_Intro;

		// Token: 0x040064E6 RID: 25830
		public AudioClip BGM_HD13;

		// Token: 0x040064E7 RID: 25831
		public AudioClip BGM_HD14_Intro;

		// Token: 0x040064E8 RID: 25832
		public AudioClip BGM_HD14;

		// Token: 0x040064E9 RID: 25833
		public AudioClip BGM_HD15_Intro;

		// Token: 0x040064EA RID: 25834
		public AudioClip BGM_HD15;

		// Token: 0x040064EB RID: 25835
		public AudioClip BGM_HD16_Intro;

		// Token: 0x040064EC RID: 25836
		public AudioClip BGM_HD16;

		// Token: 0x040064ED RID: 25837
		public AudioClip BGM_HD17_Intro;

		// Token: 0x040064EE RID: 25838
		public AudioClip BGM_HD17;

		// Token: 0x040064EF RID: 25839
		public AudioClip BGM_HD18_Intro;

		// Token: 0x040064F0 RID: 25840
		public AudioClip BGM_HD18;

		// Token: 0x040064F1 RID: 25841
		public AudioClip BGM_HD19_Intro;

		// Token: 0x040064F2 RID: 25842
		public AudioClip BGM_HD19;

		// Token: 0x040064F3 RID: 25843
		public AudioClip BGM_HD20_Intro;

		// Token: 0x040064F4 RID: 25844
		public AudioClip BGM_HD20;

		// Token: 0x040064F5 RID: 25845
		public AudioClip BGM_HD21_Intro;

		// Token: 0x040064F6 RID: 25846
		public AudioClip BGM_HD21;

		// Token: 0x040064F7 RID: 25847
		public AudioClip BGM_HD22_Intro;

		// Token: 0x040064F8 RID: 25848
		public AudioClip BGM_HD22;

		// Token: 0x040064F9 RID: 25849
		public AudioClip BGM_HD23_Intro;

		// Token: 0x040064FA RID: 25850
		public AudioClip BGM_HD23;

		// Token: 0x040064FB RID: 25851
		public AudioClip BGM_HD24_Intro;

		// Token: 0x040064FC RID: 25852
		public AudioClip BGM_HD24;

		// Token: 0x040064FD RID: 25853
		public AudioClip BGM_HD25_Intro;

		// Token: 0x040064FE RID: 25854
		public AudioClip BGM_HD25;

		// Token: 0x040064FF RID: 25855
		public AudioClip BGM_HD26_Intro;

		// Token: 0x04006500 RID: 25856
		public AudioClip BGM_HD26;

		// Token: 0x04006501 RID: 25857
		public AudioClip BGM_HD27_Intro;

		// Token: 0x04006502 RID: 25858
		public AudioClip BGM_HD27;

		// Token: 0x04006503 RID: 25859
		public AudioClip BGM_HD28_Intro;

		// Token: 0x04006504 RID: 25860
		public AudioClip BGM_HD28;

		// Token: 0x04006505 RID: 25861
		public AudioClip BGM_HD29_Intro;

		// Token: 0x04006506 RID: 25862
		public AudioClip BGM_HD29;

		// Token: 0x04006507 RID: 25863
		public AudioClip BGM_HD30_Intro;

		// Token: 0x04006508 RID: 25864
		public AudioClip BGM_HD30;

		// Token: 0x04006509 RID: 25865
		public AudioClip BGM_HD31_Intro;

		// Token: 0x0400650A RID: 25866
		public AudioClip BGM_HD31;

		// Token: 0x0400650B RID: 25867
		public AudioClip BGM_HD32_Intro;

		// Token: 0x0400650C RID: 25868
		public AudioClip BGM_HD32;

		// Token: 0x0400650D RID: 25869
		public AudioClip BGM_HD33_Intro;

		// Token: 0x0400650E RID: 25870
		public AudioClip BGM_HD33;

		// Token: 0x0400650F RID: 25871
		public AudioClip BGM_HD34_Intro;

		// Token: 0x04006510 RID: 25872
		public AudioClip BGM_HD34;

		// Token: 0x04006511 RID: 25873
		public AudioClip BGM_HD35_Intro;

		// Token: 0x04006512 RID: 25874
		public AudioClip BGM_HD35;

		// Token: 0x04006513 RID: 25875
		public AudioClip BGM_CV01;

		// Token: 0x04006514 RID: 25876
		public AudioClip BGM_CV02;

		// Token: 0x04006515 RID: 25877
		public AudioClip BGM_CV03;

		// Token: 0x04006516 RID: 25878
		public AudioClip BGM_CV04_Intro;

		// Token: 0x04006517 RID: 25879
		public AudioClip BGM_CV04;

		// Token: 0x04006518 RID: 25880
		public AudioClip BGM_CV05_Intro;

		// Token: 0x04006519 RID: 25881
		public AudioClip BGM_CV05;

		// Token: 0x0400651A RID: 25882
		public AudioClip BGM_CV06_Intro;

		// Token: 0x0400651B RID: 25883
		public AudioClip BGM_CV06;

		// Token: 0x0400651C RID: 25884
		public AudioClip BGM_CV07_Intro;

		// Token: 0x0400651D RID: 25885
		public AudioClip BGM_CV07;

		// Token: 0x0400651E RID: 25886
		public AudioClip BGM_CV08;

		// Token: 0x0400651F RID: 25887
		public AudioClip BGM_CV09;

		// Token: 0x04006520 RID: 25888
		public AudioClip BGM_CV10_Intro;

		// Token: 0x04006521 RID: 25889
		public AudioClip BGM_CV10;

		// Token: 0x04006522 RID: 25890
		public AudioClip BGM_CV11_Once;

		// Token: 0x04006523 RID: 25891
		public AudioClip BGM_DOS01_Once;

		// Token: 0x04006524 RID: 25892
		public AudioClip BGM_DOS02;

		// Token: 0x04006525 RID: 25893
		public AudioClip BGM_DOS03;

		// Token: 0x04006526 RID: 25894
		public AudioClip BGM_DOS04;

		// Token: 0x04006527 RID: 25895
		public AudioClip BGM_DOS05;

		// Token: 0x04006528 RID: 25896
		public AudioClip BGM_DOS06_Intro;

		// Token: 0x04006529 RID: 25897
		public AudioClip BGM_DOS06;

		// Token: 0x0400652A RID: 25898
		public AudioClip BGM_DOS07_Intro;

		// Token: 0x0400652B RID: 25899
		public AudioClip BGM_DOS07;

		// Token: 0x0400652C RID: 25900
		public AudioClip BGM_DOS08;

		// Token: 0x0400652D RID: 25901
		public AudioClip BGM_DOS09;

		// Token: 0x0400652E RID: 25902
		public AudioClip BGM_DOS10;

		// Token: 0x0400652F RID: 25903
		public AudioClip BGM_DOS11_Intro;

		// Token: 0x04006530 RID: 25904
		public AudioClip BGM_DOS11;

		// Token: 0x04006531 RID: 25905
		public AudioClip BGM_DOS12_Intro;

		// Token: 0x04006532 RID: 25906
		public AudioClip BGM_DOS12;

		// Token: 0x04006533 RID: 25907
		public AudioClip BGM_DOS13;

		// Token: 0x04006534 RID: 25908
		public AudioClip BGM_DOS14_Intro;

		// Token: 0x04006535 RID: 25909
		public AudioClip BGM_DOS14;

		// Token: 0x04006536 RID: 25910
		public AudioClip BGM_DOS15;

		// Token: 0x04006537 RID: 25911
		public AudioClip BGM_DOS16;

		// Token: 0x04006538 RID: 25912
		public AudioClip BGM_DOS17_Intro;

		// Token: 0x04006539 RID: 25913
		public AudioClip BGM_DOS17;

		// Token: 0x0400653A RID: 25914
		public AudioClip BGM_DOS18_Intro;

		// Token: 0x0400653B RID: 25915
		public AudioClip BGM_DOS18;

		// Token: 0x0400653C RID: 25916
		public AudioClip BGM_DOS19_Intro;

		// Token: 0x0400653D RID: 25917
		public AudioClip BGM_DOS19;

		// Token: 0x0400653E RID: 25918
		public AudioClip BGM_DOS20_Intro;

		// Token: 0x0400653F RID: 25919
		public AudioClip BGM_DOS20;

		// Token: 0x04006540 RID: 25920
		public AudioClip BGM_DOS21_Intro;

		// Token: 0x04006541 RID: 25921
		public AudioClip BGM_DOS21;

		// Token: 0x04006542 RID: 25922
		public AudioClip BGM_DOS22;

		// Token: 0x04006543 RID: 25923
		public AudioClip BGM_DOS23_Intro;

		// Token: 0x04006544 RID: 25924
		public AudioClip BGM_DOS23;

		// Token: 0x04006545 RID: 25925
		public AudioClip BGM_DOS24_Intro;

		// Token: 0x04006546 RID: 25926
		public AudioClip BGM_DOS24;

		// Token: 0x04006547 RID: 25927
		public AudioClip BGM_DOS25_Intro;

		// Token: 0x04006548 RID: 25928
		public AudioClip BGM_DOS25;

		// Token: 0x04006549 RID: 25929
		public AudioClip BGM_DOS26_Intro;

		// Token: 0x0400654A RID: 25930
		public AudioClip BGM_DOS26;

		// Token: 0x0400654B RID: 25931
		public AudioClip BGM_DOS27_Intro;

		// Token: 0x0400654C RID: 25932
		public AudioClip BGM_DOS27;

		// Token: 0x0400654D RID: 25933
		public AudioClip BGM_DOS28_Intro;

		// Token: 0x0400654E RID: 25934
		public AudioClip BGM_DOS28;

		// Token: 0x0400654F RID: 25935
		public AudioClip BGM_DOS29;

		// Token: 0x04006550 RID: 25936
		public AudioClip BGM_DOS30;

		// Token: 0x04006551 RID: 25937
		public AudioClip BGM_DOS31;

		// Token: 0x04006552 RID: 25938
		public AudioClip BGM_AOS01;

		// Token: 0x04006553 RID: 25939
		public AudioClip BGM_AOS02;

		// Token: 0x04006554 RID: 25940
		public AudioClip BGM_AOS03;

		// Token: 0x04006555 RID: 25941
		public AudioClip BGM_AOS04_Intro;

		// Token: 0x04006556 RID: 25942
		public AudioClip BGM_AOS04;

		// Token: 0x04006557 RID: 25943
		public AudioClip BGM_AOS05;

		// Token: 0x04006558 RID: 25944
		public AudioClip BGM_AOS06_Intro;

		// Token: 0x04006559 RID: 25945
		public AudioClip BGM_AOS06;

		// Token: 0x0400655A RID: 25946
		public AudioClip BGM_AOS07_Intro;

		// Token: 0x0400655B RID: 25947
		public AudioClip BGM_AOS07;

		// Token: 0x0400655C RID: 25948
		public AudioClip BGM_AOS08_Intro;

		// Token: 0x0400655D RID: 25949
		public AudioClip BGM_AOS08;

		// Token: 0x0400655E RID: 25950
		public AudioClip BGM_AOS09_Intro;

		// Token: 0x0400655F RID: 25951
		public AudioClip BGM_AOS09;

		// Token: 0x04006560 RID: 25952
		public AudioClip BGM_AOS10;

		// Token: 0x04006561 RID: 25953
		public AudioClip BGM_AOS11;

		// Token: 0x04006562 RID: 25954
		public AudioClip BGM_AOS12;

		// Token: 0x04006563 RID: 25955
		public AudioClip BGM_AOS13_Intro;

		// Token: 0x04006564 RID: 25956
		public AudioClip BGM_AOS13;

		// Token: 0x04006565 RID: 25957
		public AudioClip BGM_AOS14_Intro;

		// Token: 0x04006566 RID: 25958
		public AudioClip BGM_AOS14;

		// Token: 0x04006567 RID: 25959
		public AudioClip BGM_AOS15_Intro;

		// Token: 0x04006568 RID: 25960
		public AudioClip BGM_AOS15;

		// Token: 0x04006569 RID: 25961
		public AudioClip BGM_AOS16_Intro;

		// Token: 0x0400656A RID: 25962
		public AudioClip BGM_AOS16;

		// Token: 0x0400656B RID: 25963
		public AudioClip BGM_AOS17_Intro;

		// Token: 0x0400656C RID: 25964
		public AudioClip BGM_AOS17;

		// Token: 0x0400656D RID: 25965
		public AudioClip BGM_AOS18_Intro;

		// Token: 0x0400656E RID: 25966
		public AudioClip BGM_AOS18;

		// Token: 0x0400656F RID: 25967
		public AudioClip BGM_AOS19_Intro;

		// Token: 0x04006570 RID: 25968
		public AudioClip BGM_AOS19;

		// Token: 0x04006571 RID: 25969
		public AudioClip BGM_AOS20_Intro;

		// Token: 0x04006572 RID: 25970
		public AudioClip BGM_AOS20;

		// Token: 0x04006573 RID: 25971
		public AudioClip BGM_AOS21_Intro;

		// Token: 0x04006574 RID: 25972
		public AudioClip BGM_AOS21;

		// Token: 0x04006575 RID: 25973
		public AudioClip BGM_AOS22_Intro;

		// Token: 0x04006576 RID: 25974
		public AudioClip BGM_AOS22;

		// Token: 0x04006577 RID: 25975
		public AudioClip BGM_AOS23_Intro;

		// Token: 0x04006578 RID: 25976
		public AudioClip BGM_AOS23;

		// Token: 0x04006579 RID: 25977
		public AudioClip BGM_AOS24_Intro;

		// Token: 0x0400657A RID: 25978
		public AudioClip BGM_AOS24;

		// Token: 0x0400657B RID: 25979
		public AudioClip BGM_AOS25_Intro;

		// Token: 0x0400657C RID: 25980
		public AudioClip BGM_AOS25;

		// Token: 0x0400657D RID: 25981
		public AudioClip BGM_AOS26_Intro;

		// Token: 0x0400657E RID: 25982
		public AudioClip BGM_AOS26;

		// Token: 0x0400657F RID: 25983
		public AudioClip BGM_AOS27;

		// Token: 0x04006580 RID: 25984
		public AudioClip BGM_AOS28;

		// Token: 0x04006581 RID: 25985
		public AudioClip BGM_SOTN01;

		// Token: 0x04006582 RID: 25986
		public AudioClip BGM_SOTN02_Intro;

		// Token: 0x04006583 RID: 25987
		public AudioClip BGM_SOTN02;

		// Token: 0x04006584 RID: 25988
		public AudioClip BGM_SOTN03_Intro;

		// Token: 0x04006585 RID: 25989
		public AudioClip BGM_SOTN03;

		// Token: 0x04006586 RID: 25990
		public AudioClip BGM_SOTN04;

		// Token: 0x04006587 RID: 25991
		public AudioClip BGM_SOTN05;

		// Token: 0x04006588 RID: 25992
		public AudioClip BGM_SOTN06_Intro;

		// Token: 0x04006589 RID: 25993
		public AudioClip BGM_SOTN06;

		// Token: 0x0400658A RID: 25994
		public AudioClip BGM_SOTN07_Intro;

		// Token: 0x0400658B RID: 25995
		public AudioClip BGM_SOTN07;

		// Token: 0x0400658C RID: 25996
		public AudioClip BGM_SOTN08_Intro;

		// Token: 0x0400658D RID: 25997
		public AudioClip BGM_SOTN08;

		// Token: 0x0400658E RID: 25998
		public AudioClip BGM_SOTN09_Intro;

		// Token: 0x0400658F RID: 25999
		public AudioClip BGM_SOTN09;

		// Token: 0x04006590 RID: 26000
		public AudioClip BGM_SOTN10_Intro;

		// Token: 0x04006591 RID: 26001
		public AudioClip BGM_SOTN10;

		// Token: 0x04006592 RID: 26002
		public AudioClip BGM_SOTN11_Intro;

		// Token: 0x04006593 RID: 26003
		public AudioClip BGM_SOTN11;

		// Token: 0x04006594 RID: 26004
		public AudioClip BGM_SOTN12;

		// Token: 0x04006595 RID: 26005
		public AudioClip BGM_SOTN13_Intro;

		// Token: 0x04006596 RID: 26006
		public AudioClip BGM_SOTN13;

		// Token: 0x04006597 RID: 26007
		public AudioClip BGM_SOTN14_Intro;

		// Token: 0x04006598 RID: 26008
		public AudioClip BGM_SOTN14;

		// Token: 0x04006599 RID: 26009
		public AudioClip BGM_SOTN15_Intro;

		// Token: 0x0400659A RID: 26010
		public AudioClip BGM_SOTN15;

		// Token: 0x0400659B RID: 26011
		public AudioClip BGM_SOTN16_Intro;

		// Token: 0x0400659C RID: 26012
		public AudioClip BGM_SOTN16;

		// Token: 0x0400659D RID: 26013
		public AudioClip BGM_SOTN17_Intro;

		// Token: 0x0400659E RID: 26014
		public AudioClip BGM_SOTN17;

		// Token: 0x0400659F RID: 26015
		public AudioClip BGM_SOTN18_Intro;

		// Token: 0x040065A0 RID: 26016
		public AudioClip BGM_SOTN18;

		// Token: 0x040065A1 RID: 26017
		public AudioClip BGM_SOTN19;

		// Token: 0x040065A2 RID: 26018
		public AudioClip BGM_SOTN20_Intro;

		// Token: 0x040065A3 RID: 26019
		public AudioClip BGM_SOTN20;

		// Token: 0x040065A4 RID: 26020
		public AudioClip BGM_SOTN21_Intro;

		// Token: 0x040065A5 RID: 26021
		public AudioClip BGM_SOTN21;

		// Token: 0x040065A6 RID: 26022
		public AudioClip BGM_SOTN22_Intro;

		// Token: 0x040065A7 RID: 26023
		public AudioClip BGM_SOTN22;

		// Token: 0x040065A8 RID: 26024
		public AudioClip BGM_SOTN23_Intro;

		// Token: 0x040065A9 RID: 26025
		public AudioClip BGM_SOTN23;

		// Token: 0x040065AA RID: 26026
		public AudioClip BGM_SOTN24_Intro;

		// Token: 0x040065AB RID: 26027
		public AudioClip BGM_SOTN24;

		// Token: 0x040065AC RID: 26028
		public AudioClip BGM_SOTN25;

		// Token: 0x040065AD RID: 26029
		public AudioClip BGM_SOTN26_Intro;

		// Token: 0x040065AE RID: 26030
		public AudioClip BGM_SOTN26;

		// Token: 0x040065AF RID: 26031
		public AudioClip BGM_SOTN27_Intro;

		// Token: 0x040065B0 RID: 26032
		public AudioClip BGM_SOTN27;

		// Token: 0x040065B1 RID: 26033
		public AudioClip BGM_SOTN28_Intro;

		// Token: 0x040065B2 RID: 26034
		public AudioClip BGM_SOTN28;

		// Token: 0x040065B3 RID: 26035
		public AudioClip BGM_SOTN29_Intro;

		// Token: 0x040065B4 RID: 26036
		public AudioClip BGM_SOTN29;

		// Token: 0x040065B5 RID: 26037
		public AudioClip BGM_SOTN30_Intro;

		// Token: 0x040065B6 RID: 26038
		public AudioClip BGM_SOTN30;

		// Token: 0x040065B7 RID: 26039
		public AudioClip BGM_SOTN31;

		// Token: 0x040065B8 RID: 26040
		public AudioClip BGM_SOTN32_Intro;

		// Token: 0x040065B9 RID: 26041
		public AudioClip BGM_SOTN32;

		// Token: 0x040065BA RID: 26042
		public AudioClip BGM_SOTN33_Intro;

		// Token: 0x040065BB RID: 26043
		public AudioClip BGM_SOTN33;

		// Token: 0x040065BC RID: 26044
		public AudioClip BGM_SOTN34_Intro;

		// Token: 0x040065BD RID: 26045
		public AudioClip BGM_SOTN34;

		// Token: 0x040065BE RID: 26046
		public AudioClip BGM_SOTN35_Intro;

		// Token: 0x040065BF RID: 26047
		public AudioClip BGM_SOTN35;

		// Token: 0x040065C0 RID: 26048
		public AudioClip BGM_SOTN36_Intro;

		// Token: 0x040065C1 RID: 26049
		public AudioClip BGM_SOTN36;

		// Token: 0x040065C2 RID: 26050
		public AudioClip BGM_SOTN37;

		// Token: 0x040065C3 RID: 26051
		public AudioClip BGM_SOTN38_Intro;

		// Token: 0x040065C4 RID: 26052
		public AudioClip BGM_SOTN38;

		// Token: 0x040065C5 RID: 26053
		public AudioClip BGM_SOTN39_Intro;

		// Token: 0x040065C6 RID: 26054
		public AudioClip BGM_SOTN39;

		// Token: 0x040065C7 RID: 26055
		public AudioClip BGM_SOTN40;

		// Token: 0x040065C8 RID: 26056
		public AudioClip BGM_SOTN41;

		// Token: 0x040065C9 RID: 26057
		public AudioClip BGM_SOTN42;

		// Token: 0x040065CA RID: 26058
		public AudioClip BGM_SOTN43;

		// Token: 0x040065CB RID: 26059
		public AudioClip BGM_SOTN44;

		// Token: 0x040065CC RID: 26060
		public AudioClip BGM_SOTN45_Intro;

		// Token: 0x040065CD RID: 26061
		public AudioClip BGM_SOTN45;

		// Token: 0x040065CE RID: 26062
		public AudioClip BGM_SOTN46_Intro;

		// Token: 0x040065CF RID: 26063
		public AudioClip BGM_SOTN46;

		// Token: 0x040065D0 RID: 26064
		public AudioClip BGM_SOTN47_Intro;

		// Token: 0x040065D1 RID: 26065
		public AudioClip BGM_SOTN47;

		// Token: 0x040065D2 RID: 26066
		public AudioClip BGM_SOTN48_Intro;

		// Token: 0x040065D3 RID: 26067
		public AudioClip BGM_SOTN48;

		// Token: 0x040065D4 RID: 26068
		public AudioClip BGM_SOTN49;

		// Token: 0x040065D5 RID: 26069
		public AudioClip BGM_ROB01;

		// Token: 0x040065D6 RID: 26070
		public AudioClip BGM_ROB02;

		// Token: 0x040065D7 RID: 26071
		public AudioClip BGM_ROB03_Intro;

		// Token: 0x040065D8 RID: 26072
		public AudioClip BGM_ROB03;

		// Token: 0x040065D9 RID: 26073
		public AudioClip BGM_ROB04_Intro;

		// Token: 0x040065DA RID: 26074
		public AudioClip BGM_ROB04;

		// Token: 0x040065DB RID: 26075
		public AudioClip BGM_ROB05_Intro;

		// Token: 0x040065DC RID: 26076
		public AudioClip BGM_ROB05;

		// Token: 0x040065DD RID: 26077
		public AudioClip BGM_ROB06_Intro;

		// Token: 0x040065DE RID: 26078
		public AudioClip BGM_ROB06;

		// Token: 0x040065DF RID: 26079
		public AudioClip BGM_ROB07_Intro;

		// Token: 0x040065E0 RID: 26080
		public AudioClip BGM_ROB07;

		// Token: 0x040065E1 RID: 26081
		public AudioClip BGM_ROB08_Intro;

		// Token: 0x040065E2 RID: 26082
		public AudioClip BGM_ROB08;

		// Token: 0x040065E3 RID: 26083
		public AudioClip BGM_ROB09_Intro;

		// Token: 0x040065E4 RID: 26084
		public AudioClip BGM_ROB09;

		// Token: 0x040065E5 RID: 26085
		public AudioClip BGM_ROB10_Intro;

		// Token: 0x040065E6 RID: 26086
		public AudioClip BGM_ROB10;

		// Token: 0x040065E7 RID: 26087
		public AudioClip BGM_ROB11_Intro;

		// Token: 0x040065E8 RID: 26088
		public AudioClip BGM_ROB11;

		// Token: 0x040065E9 RID: 26089
		public AudioClip BGM_ROB12;

		// Token: 0x040065EA RID: 26090
		public AudioClip BGM_ROB13_Intro;

		// Token: 0x040065EB RID: 26091
		public AudioClip BGM_ROB13;

		// Token: 0x040065EC RID: 26092
		public AudioClip BGM_ROB14;

		// Token: 0x040065ED RID: 26093
		public AudioClip BGM_ROB15;

		// Token: 0x040065EE RID: 26094
		public AudioClip BGM_ROB16_Intro;

		// Token: 0x040065EF RID: 26095
		public AudioClip BGM_ROB16;

		// Token: 0x040065F0 RID: 26096
		public AudioClip BGM_ROB17;

		// Token: 0x040065F1 RID: 26097
		public AudioClip BGM_ROB18;

		// Token: 0x040065F2 RID: 26098
		public AudioClip BGM_ROB19;

		// Token: 0x040065F3 RID: 26099
		public AudioClip BGM_ROB20;

		// Token: 0x040065F4 RID: 26100
		public AudioClip BGM_ROB21;

		// Token: 0x040065F5 RID: 26101
		public AudioClip BGM_ROB22;

		// Token: 0x040065F6 RID: 26102
		public AudioClip BGM_XX01;

		// Token: 0x040065F7 RID: 26103
		public AudioClip BGM_XX02;

		// Token: 0x040065F8 RID: 26104
		public AudioClip BGM_XX03_Intro;

		// Token: 0x040065F9 RID: 26105
		public AudioClip BGM_XX03;

		// Token: 0x040065FA RID: 26106
		public AudioClip BGM_XX04_Intro;

		// Token: 0x040065FB RID: 26107
		public AudioClip BGM_XX04;

		// Token: 0x040065FC RID: 26108
		public AudioClip BGM_XX05_Intro;

		// Token: 0x040065FD RID: 26109
		public AudioClip BGM_XX05;

		// Token: 0x040065FE RID: 26110
		public AudioClip BGM_XX06;

		// Token: 0x040065FF RID: 26111
		public AudioClip BGM_XX07_Intro;

		// Token: 0x04006600 RID: 26112
		public AudioClip BGM_XX07;

		// Token: 0x04006601 RID: 26113
		public AudioClip BGM_XX08_Intro;

		// Token: 0x04006602 RID: 26114
		public AudioClip BGM_XX08;

		// Token: 0x04006603 RID: 26115
		public AudioClip BGM_XX09_Intro;

		// Token: 0x04006604 RID: 26116
		public AudioClip BGM_XX09;

		// Token: 0x04006605 RID: 26117
		public AudioClip BGM_XX10;

		// Token: 0x04006606 RID: 26118
		public AudioClip BGM_XX11_Intro;

		// Token: 0x04006607 RID: 26119
		public AudioClip BGM_XX11;

		// Token: 0x04006608 RID: 26120
		public AudioClip BGM_XX12_Intro;

		// Token: 0x04006609 RID: 26121
		public AudioClip BGM_XX12;

		// Token: 0x0400660A RID: 26122
		public AudioClip BGM_XX13_Intro;

		// Token: 0x0400660B RID: 26123
		public AudioClip BGM_XX13;

		// Token: 0x0400660C RID: 26124
		public AudioClip BGM_XX14;

		// Token: 0x0400660D RID: 26125
		public AudioClip BGM_XX15_Intro;

		// Token: 0x0400660E RID: 26126
		public AudioClip BGM_XX15;

		// Token: 0x0400660F RID: 26127
		public AudioClip BGM_XX16;

		// Token: 0x04006610 RID: 26128
		public AudioClip BGM_XX17;

		// Token: 0x04006611 RID: 26129
		public AudioClip BGM_XX18;

		// Token: 0x04006612 RID: 26130
		public AudioClip BGM_XX19;

		// Token: 0x04006613 RID: 26131
		public AudioClip BGM_XX20;

		// Token: 0x04006614 RID: 26132
		public AudioClip BGM_HC01;

		// Token: 0x04006615 RID: 26133
		public AudioClip BGM_HC02;

		// Token: 0x04006616 RID: 26134
		public AudioClip BGM_HC03;

		// Token: 0x04006617 RID: 26135
		public AudioClip BGM_HC04;

		// Token: 0x04006618 RID: 26136
		public AudioClip BGM_HC05_Intro;

		// Token: 0x04006619 RID: 26137
		public AudioClip BGM_HC05;

		// Token: 0x0400661A RID: 26138
		public AudioClip BGM_HC06_Intro;

		// Token: 0x0400661B RID: 26139
		public AudioClip BGM_HC06;

		// Token: 0x0400661C RID: 26140
		public AudioClip BGM_HC07;

		// Token: 0x0400661D RID: 26141
		public AudioClip BGM_HC08;

		// Token: 0x0400661E RID: 26142
		public AudioClip BGM_HC09;

		// Token: 0x0400661F RID: 26143
		public AudioClip BGM_HC10;

		// Token: 0x04006620 RID: 26144
		public AudioClip BGM_HC11;

		// Token: 0x04006621 RID: 26145
		public AudioClip BGM_HC12;

		// Token: 0x04006622 RID: 26146
		public AudioClip BGM_HC13_Intro;

		// Token: 0x04006623 RID: 26147
		public AudioClip BGM_HC13;

		// Token: 0x04006624 RID: 26148
		public AudioClip BGM_HC14;

		// Token: 0x04006625 RID: 26149
		public AudioClip BGM_HC15;

		// Token: 0x04006626 RID: 26150
		public AudioClip BGM_HC16;

		// Token: 0x04006627 RID: 26151
		public AudioClip BGM_HC17;

		// Token: 0x04006628 RID: 26152
		public AudioClip BGM_HC18;

		// Token: 0x04006629 RID: 26153
		public AudioClip BGM_OTHERS01_Intro;

		// Token: 0x0400662A RID: 26154
		public AudioClip BGM_OTHERS01;

		// Token: 0x0400662B RID: 26155
		public AudioClip BGM_OTHERS02;

		// Token: 0x0400662C RID: 26156
		public AudioClip BGM_OOE01;

		// Token: 0x0400662D RID: 26157
		public AudioClip BGM_OOE02;

		// Token: 0x0400662E RID: 26158
		public AudioClip BGM_OOE03;

		// Token: 0x0400662F RID: 26159
		public AudioClip BGM_OOE04;

		// Token: 0x04006630 RID: 26160
		public AudioClip BGM_OOE05;

		// Token: 0x04006631 RID: 26161
		public AudioClip BGM_OOE06;

		// Token: 0x04006632 RID: 26162
		public AudioClip BGM_OOE07_Intro;

		// Token: 0x04006633 RID: 26163
		public AudioClip BGM_OOE07;

		// Token: 0x04006634 RID: 26164
		public AudioClip BGM_OOE08_Intro;

		// Token: 0x04006635 RID: 26165
		public AudioClip BGM_OOE08;

		// Token: 0x04006636 RID: 26166
		public AudioClip BGM_OOE09_Intro;

		// Token: 0x04006637 RID: 26167
		public AudioClip BGM_OOE09;

		// Token: 0x04006638 RID: 26168
		public AudioClip BGM_OOE10;

		// Token: 0x04006639 RID: 26169
		public AudioClip BGM_OOE11;

		// Token: 0x0400663A RID: 26170
		public AudioClip BGM_OOE12_Intro;

		// Token: 0x0400663B RID: 26171
		public AudioClip BGM_OOE12;

		// Token: 0x0400663C RID: 26172
		public AudioClip BGM_OOE13_Intro;

		// Token: 0x0400663D RID: 26173
		public AudioClip BGM_OOE13;

		// Token: 0x0400663E RID: 26174
		public AudioClip BGM_OOE14;

		// Token: 0x0400663F RID: 26175
		public AudioClip BGM_OOE15_Intro;

		// Token: 0x04006640 RID: 26176
		public AudioClip BGM_OOE15;

		// Token: 0x04006641 RID: 26177
		public AudioClip BGM_OOE16_Intro;

		// Token: 0x04006642 RID: 26178
		public AudioClip BGM_OOE16;

		// Token: 0x04006643 RID: 26179
		public AudioClip BGM_OOE17_Intro;

		// Token: 0x04006644 RID: 26180
		public AudioClip BGM_OOE17;

		// Token: 0x04006645 RID: 26181
		public AudioClip BGM_OOE18_Intro;

		// Token: 0x04006646 RID: 26182
		public AudioClip BGM_OOE18;

		// Token: 0x04006647 RID: 26183
		public AudioClip BGM_OOE19_Intro;

		// Token: 0x04006648 RID: 26184
		public AudioClip BGM_OOE19;

		// Token: 0x04006649 RID: 26185
		public AudioClip BGM_OOE20;

		// Token: 0x0400664A RID: 26186
		public AudioClip BGM_OOE21;

		// Token: 0x0400664B RID: 26187
		public AudioClip BGM_OOE22_Intro;

		// Token: 0x0400664C RID: 26188
		public AudioClip BGM_OOE22;

		// Token: 0x0400664D RID: 26189
		public AudioClip BGM_OOE23;

		// Token: 0x0400664E RID: 26190
		public AudioClip BGM_OOE24_Intro;

		// Token: 0x0400664F RID: 26191
		public AudioClip BGM_OOE24;

		// Token: 0x04006650 RID: 26192
		public AudioClip BGM_OOE25_Intro;

		// Token: 0x04006651 RID: 26193
		public AudioClip BGM_OOE25;

		// Token: 0x04006652 RID: 26194
		public AudioClip BGM_OOE26_Intro;

		// Token: 0x04006653 RID: 26195
		public AudioClip BGM_OOE26;

		// Token: 0x04006654 RID: 26196
		public AudioClip BGM_OOE27;

		// Token: 0x04006655 RID: 26197
		public AudioClip BGM_OOE28;

		// Token: 0x04006656 RID: 26198
		public AudioClip BGM_OOE29_Intro;

		// Token: 0x04006657 RID: 26199
		public AudioClip BGM_OOE29;

		// Token: 0x04006658 RID: 26200
		public AudioClip BGM_OOE30_Intro;

		// Token: 0x04006659 RID: 26201
		public AudioClip BGM_OOE30;

		// Token: 0x0400665A RID: 26202
		public AudioClip BGM_OOE31_Intro;

		// Token: 0x0400665B RID: 26203
		public AudioClip BGM_OOE31;

		// Token: 0x0400665C RID: 26204
		public AudioClip BGM_OOE32_Intro;

		// Token: 0x0400665D RID: 26205
		public AudioClip BGM_OOE32;

		// Token: 0x0400665E RID: 26206
		public AudioClip BGM_OOE33_Intro;

		// Token: 0x0400665F RID: 26207
		public AudioClip BGM_OOE33;

		// Token: 0x04006660 RID: 26208
		public AudioClip BGM_OOE34_Intro;

		// Token: 0x04006661 RID: 26209
		public AudioClip BGM_OOE34;

		// Token: 0x04006662 RID: 26210
		public AudioClip BGM_OOE35;

		// Token: 0x04006663 RID: 26211
		public AudioClip BGM_OOE36_Intro;

		// Token: 0x04006664 RID: 26212
		public AudioClip BGM_OOE36;

		// Token: 0x04006665 RID: 26213
		public AudioClip BGM_OOE37_Intro;

		// Token: 0x04006666 RID: 26214
		public AudioClip BGM_OOE37;

		// Token: 0x04006667 RID: 26215
		public AudioClip BGM_OOE38_Intro;

		// Token: 0x04006668 RID: 26216
		public AudioClip BGM_OOE38;

		// Token: 0x04006669 RID: 26217
		public AudioClip BGM_OOE39_Intro;

		// Token: 0x0400666A RID: 26218
		public AudioClip BGM_OOE39;

		// Token: 0x0400666B RID: 26219
		public AudioClip BGM_OOE40;

		// Token: 0x0400666C RID: 26220
		public AudioClip BGM_OOE41;

		// Token: 0x0400666D RID: 26221
		public AudioClip BGM_OOE42_Intro;

		// Token: 0x0400666E RID: 26222
		public AudioClip BGM_OOE42;

		// Token: 0x0400666F RID: 26223
		public AudioClip BGM_OOE43_Intro;

		// Token: 0x04006670 RID: 26224
		public AudioClip BGM_OOE43;

		// Token: 0x04006671 RID: 26225
		public AudioClip BGM_OOE44_Intro;

		// Token: 0x04006672 RID: 26226
		public AudioClip BGM_OOE44;

		// Token: 0x04006673 RID: 26227
		public AudioClip BGM_OOE45_Intro;

		// Token: 0x04006674 RID: 26228
		public AudioClip BGM_OOE45;

		// Token: 0x04006675 RID: 26229
		public AudioClip BGM_OOE46_Intro;

		// Token: 0x04006676 RID: 26230
		public AudioClip BGM_OOE46;

		// Token: 0x04006677 RID: 26231
		public AudioClip BGM_OOE47;

		// Token: 0x04006678 RID: 26232
		public AudioClip BGM_OOE48_Intro;

		// Token: 0x04006679 RID: 26233
		public AudioClip BGM_OOE48;

		// Token: 0x0400667A RID: 26234
		public AudioClip BGM_OOE49_Intro;

		// Token: 0x0400667B RID: 26235
		public AudioClip BGM_OOE49;

		// Token: 0x0400667C RID: 26236
		public AudioClip BGM_OOE50_Intro;

		// Token: 0x0400667D RID: 26237
		public AudioClip BGM_OOE50;

		// Token: 0x0400667E RID: 26238
		public AudioClip BGM_OOE51_Intro;

		// Token: 0x0400667F RID: 26239
		public AudioClip BGM_OOE51;

		// Token: 0x04006680 RID: 26240
		public AudioClip BGM_OOE52_Intro;

		// Token: 0x04006681 RID: 26241
		public AudioClip BGM_OOE52;

		// Token: 0x04006682 RID: 26242
		public AudioClip BGM_OOE53_Intro;

		// Token: 0x04006683 RID: 26243
		public AudioClip BGM_OOE53;

		// Token: 0x04006684 RID: 26244
		public AudioClip BGM_OOE54;

		// Token: 0x04006685 RID: 26245
		private AudioSource audioSorce;

		// Token: 0x04006686 RID: 26246
		private AudioClip clip;

		// Token: 0x04006687 RID: 26247
		private PhotonView myPV;

		// Token: 0x04006688 RID: 26248
		public string startBGMStageName;

		// Token: 0x04006689 RID: 26249
		public int currentSongNumber;

		// Token: 0x0400668A RID: 26250
		public int defalutSongNumber;

		// Token: 0x0400668B RID: 26251
		public bool check;

		// Token: 0x0400668C RID: 26252
		public bool introPlayed;

		// Token: 0x0400668D RID: 26253
		private Animator targetAnim;

		// Token: 0x0400668E RID: 26254
		private Text text;

		// Token: 0x0400668F RID: 26255
		public CameraController cameraCtrl;

		// Token: 0x04006690 RID: 26256
		public float cVVolume;

		// Token: 0x04006691 RID: 26257
		public float sEVolume;

		// Token: 0x04006692 RID: 26258
		private SettingChange settingChange;

		// Token: 0x04006693 RID: 26259
		public bool testPlayStage;
	}
}
