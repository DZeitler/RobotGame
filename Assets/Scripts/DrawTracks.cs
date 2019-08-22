using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTracks : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Shader _drawShader;
    [SerializeField] Transform _tank;
    [SerializeField] bool _debug;
    [SerializeField] private RenderTexture _splatMap;
    [SerializeField] private Material _groundMat;
    [SerializeField] private Material _drawMat;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        _drawMat = new Material(_drawShader);
        _drawMat.SetVector("_MainColor", Color.red);

        _groundMat = GetComponent<MeshRenderer>().material;
        _splatMap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
        _groundMat.SetTexture("_Splat", _splatMap);
    }

    // Update is called once per frame
    void Update()
    {
      

     if(Physics.Raycast(_tank.position, new Vector3 (0,-1,0),out _hit))
        {
            _drawMat.SetVector("_Coordinate", new Vector4(_hit.textureCoord.x, _hit.textureCoord.y, 0, 0));
            RenderTexture temp = RenderTexture.GetTemporary(_splatMap.width, _splatMap.height, 0, RenderTextureFormat.ARGBFloat);
            Graphics.Blit(_splatMap, temp);
            Graphics.Blit(temp, _splatMap, _drawMat);
            RenderTexture.ReleaseTemporary(temp);

        }
    }

    private void OnGUI()
    {
        if (_debug)
        {
            GUI.DrawTexture(new Rect(0, 0, 256, 256), _splatMap, ScaleMode.ScaleToFit, false, 1);
        }
       
    }

}
