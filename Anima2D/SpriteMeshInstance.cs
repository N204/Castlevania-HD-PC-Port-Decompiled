using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Anima2D
{
	// Token: 0x020000FF RID: 255
	[ExecuteInEditMode]
	public class SpriteMeshInstance : MonoBehaviour
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x00065AB8 File Offset: 0x00063CB8
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x00065AC0 File Offset: 0x00063CC0
		public SpriteMesh spriteMesh
		{
			get
			{
				return this.m_SpriteMesh;
			}
			set
			{
				this.m_SpriteMesh = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x00065AC9 File Offset: 0x00063CC9
		// (set) Token: 0x06000667 RID: 1639 RVA: 0x00065AE3 File Offset: 0x00063CE3
		public Material sharedMaterial
		{
			get
			{
				if (this.m_Materials.Length > 0)
				{
					return this.m_Materials[0];
				}
				return null;
			}
			set
			{
				this.m_Materials = new Material[]
				{
					value
				};
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x00065AF5 File Offset: 0x00063CF5
		// (set) Token: 0x06000669 RID: 1641 RVA: 0x00065AFD File Offset: 0x00063CFD
		public Material[] sharedMaterials
		{
			get
			{
				return this.m_Materials;
			}
			set
			{
				this.m_Materials = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x00065B06 File Offset: 0x00063D06
		// (set) Token: 0x0600066B RID: 1643 RVA: 0x00065B0E File Offset: 0x00063D0E
		public Color color
		{
			get
			{
				return this.m_Color;
			}
			set
			{
				this.m_Color = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x00065B17 File Offset: 0x00063D17
		// (set) Token: 0x0600066D RID: 1645 RVA: 0x00065B1F File Offset: 0x00063D1F
		public int sortingLayerID
		{
			get
			{
				return this.m_SortingLayerID;
			}
			set
			{
				this.m_SortingLayerID = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x00065B28 File Offset: 0x00063D28
		// (set) Token: 0x0600066F RID: 1647 RVA: 0x00065B4B File Offset: 0x00063D4B
		public string sortingLayerName
		{
			get
			{
				if (this.cachedRenderer)
				{
					return this.cachedRenderer.sortingLayerName;
				}
				return "Default";
			}
			set
			{
				if (this.cachedRenderer)
				{
					this.cachedRenderer.sortingLayerName = value;
					this.sortingLayerID = this.cachedRenderer.sortingLayerID;
				}
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x00065B7A File Offset: 0x00063D7A
		// (set) Token: 0x06000671 RID: 1649 RVA: 0x00065B82 File Offset: 0x00063D82
		public int sortingOrder
		{
			get
			{
				return this.m_SortingOrder;
			}
			set
			{
				this.m_SortingOrder = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x00065B8C File Offset: 0x00063D8C
		// (set) Token: 0x06000673 RID: 1651 RVA: 0x00065CFC File Offset: 0x00063EFC
		public List<Bone2D> bones
		{
			get
			{
				if (this.m_Bones != null && this.m_Bones.Length > 0 && this.m_CachedBones.Count == 0)
				{
					this.bones = new List<Bone2D>(this.m_Bones);
				}
				if (this.m_BoneTransforms != null && this.m_CachedBones.Count != this.m_BoneTransforms.Length)
				{
					this.m_CachedBones = new List<Bone2D>(this.m_BoneTransforms.Length);
					for (int i = 0; i < this.m_BoneTransforms.Length; i++)
					{
						Bone2D item = null;
						if (this.m_BoneTransforms[i])
						{
							item = this.m_BoneTransforms[i].GetComponent<Bone2D>();
						}
						this.m_CachedBones.Add(item);
					}
				}
				for (int j = 0; j < this.m_CachedBones.Count; j++)
				{
					if (this.m_CachedBones[j] && this.m_BoneTransforms[j] != this.m_CachedBones[j].transform)
					{
						this.m_CachedBones[j] = null;
					}
					if (!this.m_CachedBones[j] && this.m_BoneTransforms[j])
					{
						this.m_CachedBones[j] = this.m_BoneTransforms[j].GetComponent<Bone2D>();
					}
				}
				return this.m_CachedBones;
			}
			set
			{
				this.m_Bones = null;
				this.m_CachedBones = new List<Bone2D>(value);
				this.m_BoneTransforms = new Transform[this.m_CachedBones.Count];
				for (int i = 0; i < this.m_CachedBones.Count; i++)
				{
					Bone2D bone2D = this.m_CachedBones[i];
					if (bone2D)
					{
						this.m_BoneTransforms[i] = bone2D.transform;
					}
				}
				if (this.cachedSkinnedRenderer)
				{
					this.cachedSkinnedRenderer.bones = this.m_BoneTransforms;
				}
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x00065D95 File Offset: 0x00063F95
		private MaterialPropertyBlock materialPropertyBlock
		{
			get
			{
				if (this.m_MaterialPropertyBlock == null)
				{
					this.m_MaterialPropertyBlock = new MaterialPropertyBlock();
				}
				return this.m_MaterialPropertyBlock;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000675 RID: 1653 RVA: 0x00065DB3 File Offset: 0x00063FB3
		public Renderer cachedRenderer
		{
			get
			{
				if (!this.mCachedRenderer)
				{
					this.mCachedRenderer = base.GetComponent<Renderer>();
				}
				return this.mCachedRenderer;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000676 RID: 1654 RVA: 0x00065DD7 File Offset: 0x00063FD7
		public MeshFilter cachedMeshFilter
		{
			get
			{
				if (!this.mCachedMeshFilter)
				{
					this.mCachedMeshFilter = base.GetComponent<MeshFilter>();
				}
				return this.mCachedMeshFilter;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x00065DFB File Offset: 0x00063FFB
		public SkinnedMeshRenderer cachedSkinnedRenderer
		{
			get
			{
				if (!this.mCachedSkinnedRenderer)
				{
					this.mCachedSkinnedRenderer = base.GetComponent<SkinnedMeshRenderer>();
				}
				return this.mCachedSkinnedRenderer;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x00065E1F File Offset: 0x0006401F
		private Texture2D spriteTexture
		{
			get
			{
				if (this.spriteMesh && this.spriteMesh.sprite)
				{
					return this.spriteMesh.sprite.texture;
				}
				return null;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x00065E58 File Offset: 0x00064058
		public Mesh sharedMesh
		{
			get
			{
				if (this.m_InitialMesh)
				{
					return this.m_InitialMesh;
				}
				return null;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600067A RID: 1658 RVA: 0x00065E72 File Offset: 0x00064072
		public Mesh mesh
		{
			get
			{
				if (this.m_CurrentMesh)
				{
					return UnityEngine.Object.Instantiate<Mesh>(this.m_CurrentMesh);
				}
				return null;
			}
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00065E91 File Offset: 0x00064091
		private void OnDestroy()
		{
			if (this.m_CurrentMesh)
			{
				UnityEngine.Object.Destroy(this.m_CurrentMesh);
			}
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x00065EAE File Offset: 0x000640AE
		private void Awake()
		{
			this.UpdateCurrentMesh();
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00065EB6 File Offset: 0x000640B6
		private void UpdateInitialMesh()
		{
			this.m_InitialMesh = null;
			if (this.spriteMesh && this.spriteMesh.sharedMesh)
			{
				this.m_InitialMesh = this.spriteMesh.sharedMesh;
			}
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00065EF8 File Offset: 0x000640F8
		private void UpdateCurrentMesh()
		{
			this.UpdateInitialMesh();
			if (this.m_InitialMesh)
			{
				if (!this.m_CurrentMesh)
				{
					this.m_CurrentMesh = new Mesh();
					this.m_CurrentMesh.hideFlags = HideFlags.DontSave;
					this.m_CurrentMesh.MarkDynamic();
				}
				this.m_CurrentMesh.Clear();
				this.m_CurrentMesh.name = this.m_InitialMesh.name;
				this.m_CurrentMesh.vertices = this.m_InitialMesh.vertices;
				this.m_CurrentMesh.normals = this.m_InitialMesh.normals;
				this.m_CurrentMesh.tangents = this.m_InitialMesh.tangents;
				this.m_CurrentMesh.boneWeights = this.m_InitialMesh.boneWeights;
				this.m_CurrentMesh.bindposes = this.m_InitialMesh.bindposes;
				this.m_CurrentMesh.uv = this.m_InitialMesh.uv;
				this.m_CurrentMesh.bounds = this.m_InitialMesh.bounds;
				this.m_CurrentMesh.colors = this.m_InitialMesh.colors;
				for (int i = 0; i < this.m_InitialMesh.subMeshCount; i++)
				{
					this.m_CurrentMesh.SetTriangles(this.m_InitialMesh.GetTriangles(i), i);
				}
				this.m_CurrentMesh.ClearBlendShapes();
				for (int j = 0; j < this.m_InitialMesh.blendShapeCount; j++)
				{
					string blendShapeName = this.m_InitialMesh.GetBlendShapeName(j);
					for (int k = 0; k < this.m_InitialMesh.GetBlendShapeFrameCount(j); k++)
					{
						float blendShapeFrameWeight = this.m_InitialMesh.GetBlendShapeFrameWeight(j, k);
						Vector3[] deltaVertices = new Vector3[this.m_InitialMesh.vertexCount];
						this.m_InitialMesh.GetBlendShapeFrameVertices(j, k, deltaVertices, null, null);
						this.m_CurrentMesh.AddBlendShapeFrame(blendShapeName, blendShapeFrameWeight, deltaVertices, null, null);
					}
				}
				this.m_CurrentMesh.hideFlags = HideFlags.DontSave;
			}
			else
			{
				this.m_InitialMesh = null;
				if (this.m_CurrentMesh)
				{
					this.m_CurrentMesh.Clear();
				}
			}
			if (this.m_CurrentMesh)
			{
				if (this.spriteMesh && this.spriteMesh.sprite && this.spriteMesh.sprite.packed)
				{
					this.SetSpriteUVs(this.m_CurrentMesh, this.spriteMesh.sprite);
				}
				this.m_CurrentMesh.UploadMeshData(false);
			}
			this.UpdateRenderers();
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00066190 File Offset: 0x00064390
		private void SetSpriteUVs(Mesh mesh, Sprite sprite)
		{
			Vector2[] uv = sprite.uv;
			if (mesh.vertexCount == uv.Length)
			{
				mesh.uv = sprite.uv;
			}
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x000661C0 File Offset: 0x000643C0
		private void UpdateRenderers()
		{
			Mesh sharedMesh = null;
			if (this.m_InitialMesh)
			{
				sharedMesh = this.m_CurrentMesh;
			}
			if (this.cachedSkinnedRenderer)
			{
				this.cachedSkinnedRenderer.sharedMesh = sharedMesh;
			}
			else if (this.cachedMeshFilter)
			{
				this.cachedMeshFilter.sharedMesh = sharedMesh;
			}
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00066224 File Offset: 0x00064424
		private void LateUpdate()
		{
			if (!this.spriteMesh || (this.spriteMesh && this.spriteMesh.sharedMesh != this.m_InitialMesh))
			{
				this.UpdateCurrentMesh();
			}
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00066274 File Offset: 0x00064474
		private void OnWillRenderObject()
		{
			this.UpdateRenderers();
			if (this.cachedRenderer)
			{
				this.cachedRenderer.sortingLayerID = this.sortingLayerID;
				this.cachedRenderer.sortingOrder = this.sortingOrder;
				this.cachedRenderer.sharedMaterials = this.m_Materials;
				this.cachedRenderer.GetPropertyBlock(this.materialPropertyBlock);
				if (this.spriteTexture)
				{
					this.materialPropertyBlock.SetTexture("_MainTex", this.spriteTexture);
				}
				this.materialPropertyBlock.SetColor("_Color", this.color);
				this.cachedRenderer.SetPropertyBlock(this.materialPropertyBlock);
			}
		}

		// Token: 0x04000B21 RID: 2849
		[FormerlySerializedAs("spriteMesh")]
		[SerializeField]
		private SpriteMesh m_SpriteMesh;

		// Token: 0x04000B22 RID: 2850
		[SerializeField]
		private Color m_Color = Color.white;

		// Token: 0x04000B23 RID: 2851
		[SerializeField]
		private Material[] m_Materials;

		// Token: 0x04000B24 RID: 2852
		[SerializeField]
		private int m_SortingLayerID;

		// Token: 0x04000B25 RID: 2853
		[SerializeField]
		[FormerlySerializedAs("orderInLayer")]
		private int m_SortingOrder;

		// Token: 0x04000B26 RID: 2854
		[SerializeField]
		[FormerlySerializedAs("bones")]
		[HideInInspector]
		private Bone2D[] m_Bones;

		// Token: 0x04000B27 RID: 2855
		[HideInInspector]
		[SerializeField]
		private Transform[] m_BoneTransforms;

		// Token: 0x04000B28 RID: 2856
		private List<Bone2D> m_CachedBones = new List<Bone2D>();

		// Token: 0x04000B29 RID: 2857
		private MaterialPropertyBlock m_MaterialPropertyBlock;

		// Token: 0x04000B2A RID: 2858
		private Renderer mCachedRenderer;

		// Token: 0x04000B2B RID: 2859
		private MeshFilter mCachedMeshFilter;

		// Token: 0x04000B2C RID: 2860
		private SkinnedMeshRenderer mCachedSkinnedRenderer;

		// Token: 0x04000B2D RID: 2861
		private Mesh m_InitialMesh;

		// Token: 0x04000B2E RID: 2862
		private Mesh m_CurrentMesh;
	}
}
