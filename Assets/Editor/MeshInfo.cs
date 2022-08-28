using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class MeshInfo : EditorWindow
    {
        private int vertexCount;
        private int triangleCount;
        private int subMeshCount;

        [MenuItem("Window/Tools/Mesh Info")]
        public static void ShowWindow()
        {
            MeshInfo window = (MeshInfo) GetWindow(typeof(MeshInfo));
            window.titleContent.text = "Mesh Info";
        }

        void OnGUI()
        {
            if (GUILayout.Button("Create Mesh Info"))
            {
                vertexCount = 0;
                triangleCount = 0;
                subMeshCount = 0;
                Debug.Log("Called mesh info");
                if (Selection.activeGameObject != null)
                {
                    foreach (GameObject g in Selection.gameObjects)
                    {
                        foreach (MeshFilter mf in g.GetComponentsInChildren<MeshFilter>())
                        {
                            if (mf != null)
                            {
                                vertexCount += mf.sharedMesh.vertexCount;
                                triangleCount += mf.sharedMesh.triangles.Length / 3;
                                subMeshCount += mf.sharedMesh.subMeshCount;
                            }
                        }
                    } 
                }
            }

            EditorGUILayout.LabelField("Vertex Count: " + vertexCount);
            EditorGUILayout.LabelField("Triangle Count: " + triangleCount);
            EditorGUILayout.LabelField("SubMesh Count: " + subMeshCount);
        }
    }
}