using UnityEngine;
using System.Collections;

public class Draw2DBounds : MonoBehaviour {
	
	public GUIStyle guiStyle;
	
	Mesh mesh;
	Camera mainCamera;
	
	void Start() {
		mesh = gameObject.GetComponentInChildren<MeshFilter>().mesh;
		mainCamera = Camera.main;
	}

	void OnGUI()
	{
		if (mesh != null && mesh.vertices.Length > 0) {
			Vector3[] v = mesh.vertices;
			// Take each vertex in the mesh, get its position in the world given the transform of this object
			// and from that calculate the position on the screen according to the camera.
			// Find the min/max of all those 2D points to get the bounds in screen space.
			Vector3 p0 = mainCamera.WorldToScreenPoint(transform.localToWorldMatrix.MultiplyPoint(v[0]));
			float xMin = p0.x, xMax = p0.x, yMin = p0.y, yMax = p0.y;
			for(int i = 1; i < v.Length; ++i) {
				Vector3 p = mainCamera.WorldToScreenPoint(transform.localToWorldMatrix.MultiplyPoint(v[i]));
				xMin = Mathf.Min(xMin, p.x);
				xMax = Mathf.Max(xMax, p.x);
				yMin = Mathf.Min(yMin, p.y);
				yMax = Mathf.Max(yMax, p.y);
			}
			float width = xMax - xMin;
			float height = yMax - yMin;
			float x = xMin;
			float y = Screen.height - yMax;
			// This is the rectangle that defines the bounds of the object in screen space
			Rect bounds = new Rect(x, y, width, height);
			GUI.Box(bounds, "", guiStyle);
		}
	}
}
