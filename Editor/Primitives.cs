/*
 EDITOR CLASS
 PRIMITIVES
 v1.2
 LAST EDITED: FRIDAY DECEMBER 9, 2022
 COPYRIGHT © TECH SKULL STUDIOS
*/

#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

internal static class Primitives
{
    public const string Path = "GameObject/3D Object/";

    private static C CreateGameObject<C>(string name) where C : Component
    => new GameObject(name).AddComponent<C>().GetComponent<C>();
    
    private static void CreateShape(string shape, bool isConvex)
    {
        //Create the blank object
        var meshFilter = CreateGameObject<MeshFilter>(shape);
        meshFilter.transform.position = Vector3.zero;
        meshFilter.gameObject.AddComponent<MeshRenderer>();
        var meshRenderer = meshFilter.GetComponent<MeshRenderer>();
        meshFilter.gameObject.AddComponent<MeshCollider>();
        var meshCollider = meshFilter.GetComponent<MeshCollider>();

        Mesh mesh = Resources.Load<Mesh>("Primitives/" + shape);

        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
        meshCollider.convex = isConvex;
        meshRenderer.material = DefaultMaterial();
        Selection.activeGameObject = meshFilter.gameObject;
    }

    private static Material DefaultMaterial()
    {
        //Standard Renderer
        if(GraphicsSettings.renderPipelineAsset == null)
            return AssetDatabase.GetBuiltinExtraResource<Material>("Default-Material.mat");
        if(GraphicsSettings.renderPipelineAsset.GetType().ToString().Contains("Universal"))
            return AssetDatabase.LoadAssetAtPath<Material>("Packages/com.unity.render-pipelines.universal/Runtime/Materials/Lit.mat");
        if(GraphicsSettings.renderPipelineAsset.GetType().ToString().Contains("HD"))
            return AssetDatabase.LoadAssetAtPath<Material>("Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipelineResources/Material/DefaultHDMaterial.mat");
        return null;
    }

    //[MenuItem(Path + "Cylinder")]
    //static void CreateCylinder() => CreateShape("Cylinder", true);

    [MenuItem(Path + "Cone")]
    static void CreateCone() => CreateShape("Cone", true);

    [MenuItem(Path + "Pyramid")]
    static void CreatePyramid() => CreateShape("Pyramid", true);

    [MenuItem(Path + "Torus")]
    static void CreateTorus() => CreateShape("Torus", false);
    
    [MenuItem(Path + "Inverse Cube")]
    static void CreateInverseCube() => CreateShape("Inverse Cube", false);

    [MenuItem(Path + "Ramp")]
    static void CreateRamp() => CreateShape("Ramp", true);

    [MenuItem(Path + "Open Box")]
    static void CreateOpenBox() => CreateShape("Open Box", false);

    [MenuItem(Path + "Tube")]
    static void CreateTube() => CreateShape("Tube", false);

    [MenuItem(Path + "Arch")]
    static void CreateArch() => CreateShape("Arch", false);

    [MenuItem(Path + "Prism")]
    static void CreatePrism() => CreateShape("Prism", true);

    [MenuItem(Path + "Hexagon")]
    static void CreateHexagon() => CreateShape("Hexagon", true);

    [MenuItem(Path + "Octagon")]
    static void CreateOctagon() => CreateShape("Octagon", true);
    
    [MenuItem(Path + "Octahedron")]
    static void CreateOctahedron() => CreateShape("Octahedron", true);
}

#endif