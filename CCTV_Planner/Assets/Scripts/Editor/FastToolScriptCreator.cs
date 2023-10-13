using UnityEngine;
using UnityEditor;
using System.IO;

public class FastToolScriptCreator : Editor
{
    [MenuItem("Assets/Create/Tool Script")]
    public static void CreateToolScript()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "")
        {
            path = "Assets";
        }
        else if (Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        string className = UnityEditor.EditorUtility.SaveFilePanelInProject("New Tool Script", "NewTool", "cs", "Please the new tool class name");
        className = Path.GetFileNameWithoutExtension(className);

        if (!string.IsNullOrEmpty(className))
        {
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + className + ".cs");

            using (StreamWriter writer = new StreamWriter(assetPathAndName))
            {
                writer.WriteLine("using System.Collections;");
                writer.WriteLine("using System.Collections.Generic;");
                writer.WriteLine("using UnityEngine;");
                writer.WriteLine("");
                writer.WriteLine("[System.Serializable]");
                writer.WriteLine("public class " + className + " : Tool");
                writer.WriteLine("{");

                writer.WriteLine("public " + className + "() : base()");
                writer.WriteLine("{");
                writer.WriteLine("");
                 writer.WriteLine("}");
                writer.WriteLine("public override void start() { }");
                writer.WriteLine("public override void update() { }");
                writer.WriteLine("public override void selectTool(){}");
                writer.WriteLine("public override void deselectTool(){}");

                writer.WriteLine("}");
            }

            AssetDatabase.Refresh();
        }
    }
}