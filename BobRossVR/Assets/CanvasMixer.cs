using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMixer : MonoBehaviour
{
	public RenderTexture srcTex;
	public ComputeShader shader;

	RenderTexture dstTex;
	Renderer renderer_;

	int kernelID;

	void Start()
	{
		var width = srcTex.width;
		var height = srcTex.height;
		var depth = 24;
		dstTex = new RenderTexture(width, height, depth);
		dstTex.enableRandomWrite = true;
		dstTex.Create();

		kernelID = shader.FindKernel("CSMain");
		shader.SetTexture(kernelID, "srcTex", srcTex);
		shader.SetTexture(kernelID, "dstTex", dstTex);

		renderer_ = GetComponent<Renderer>();
		renderer_.enabled = true;
	}

	void Update()
	{
		UpdateShader();
	}

	void UpdateShader()
	{
		var xThreads = dstTex.width / 8;
		var yThreads = dstTex.height / 8;
		var zThreads = 1;
		shader.Dispatch(kernelID,
			xThreads, yThreads, zThreads);
		renderer_.material.SetTexture("_MainTex", dstTex);
	}
}
