using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;



public class UIElementsEditorWindow : EditorWindow
{
    // getter and setter not yet nescessary but may be needed for the procedural algo
    public int length  { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int iterationDepth { get; set; }
    public float cornerShrinkPercentage {get; set;}
    public bool activateCorners {get; set;}
    public Vector2 heightVarForChildren {get;set;}
    public bool randomiseHeightOfChildren {get;set;}
    public bool allowBoxesOnBoxes{get;set;}
    public bool activateChildrenHeightControl{get;set;}

    public bool activateChildrenDimensionControl{get;set;}
    public Vector2 childLengthWidthFactor{get;set;}
    public bool randomiseDimensionsofAllChildren{get;set;}

    //Editor Only
    public string saveParameterName; 
    public object fileWhereParametersToLoadFrom;

    [MenuItem("Plugins/Architecton Builder")]
    public static void ShowExample()
    {
        UIElementsEditorWindow wnd = GetWindow<UIElementsEditorWindow>();
        wnd.titleContent = new GUIContent("Architecton Builder");
    }

    private void OnGUI()
    {
        length = EditorGUILayout.IntSlider("Length", length, 0, 20);
        width = EditorGUILayout.IntSlider("Width", width, 0, 20);
        height = EditorGUILayout.IntSlider("Height", height, 0, 20);
        iterationDepth = EditorGUILayout.IntField("Iteration Depth", iterationDepth);
        
        //Children Height Control
        activateChildrenHeightControl = EditorGUILayout.Toggle("Activate height Control", activateChildrenHeightControl);
        if(activateChildrenHeightControl)
        {
            EditorGUI.indentLevel++;
            drawRectLineHere(Color.black);
            randomiseHeightOfChildren = EditorGUILayout.Toggle("Randomise all childs", randomiseHeightOfChildren);
            drawRectLineHere(Color.black);
            EditorGUI.indentLevel--;
        }
        else
        {
            heightVarForChildren = new Vector2(1,1);
            randomiseHeightOfChildren = false;
        }
        //Children Dimension
        activateChildrenDimensionControl = EditorGUILayout.Toggle("Activate Dimension Contrl", activateChildrenDimensionControl);
        if(activateChildrenDimensionControl)
        {
            EditorGUI.indentLevel++;
            drawRectLineHere(Color.black);
            activateChildrenDimensionControl = EditorGUILayout.Toggle("Activate Dimension Contrl", activateChildrenDimensionControl);
            childLengthWidthFactor = EditorGUILayout.Vector2Field("Child length/width factor", childLengthWidthFactor);
            randomiseDimensionsofAllChildren = EditorGUILayout.Toggle("Randomise all childs", randomiseDimensionsofAllChildren);
            drawRectLineHere(Color.black);
            EditorGUI.indentLevel--;
        }
        else
        {
            childLengthWidthFactor = new Vector2(.5f,.5f);
            randomiseDimensionsofAllChildren = false;
        }
        //Corner Control
        activateCorners = EditorGUILayout.Toggle("Activate Corners", activateCorners);
        if(activateCorners)
        {
            EditorGUI.indentLevel++;
            drawRectLineHere(Color.black);
            cornerShrinkPercentage = EditorGUILayout.FloatField("Corner shrink %", cornerShrinkPercentage);
            drawRectLineHere(Color.black);
            EditorGUI.indentLevel--;
        }
        //Boxes On Top
        allowBoxesOnBoxes = EditorGUILayout.Toggle("Boxes ontop", allowBoxesOnBoxes);
        
        if (GUILayout.Button("Generate"))
            OnGenerateButtonClick();

        GUILayout.Space(20);
        drawRectLineHere(Color.white);
        GUILayout.Label("Save or Load Values");

        if (GUILayout.Button("Save"))
            OnSaveButtonClick();
        saveParameterName = EditorGUILayout.TextField("Parameter Save Name", saveParameterName);
        if (GUILayout.Button("Load"))
            OnLoadButtonClick();
        GUILayout.Space(20);
        drawRectLineHere(Color.black);
        if (GUILayout.Button("Load Default Values"))
            OnLoadDefaultVales();

        // Refreshes WireCube when variables are changed
        SceneView.RepaintAll();
    }

    public void OnGenerateButtonClick()
    {
        GameObject architektonRef = GameObject.Find("Architekton");
        if(architektonRef == null)
        {
            GameObject Architekton = new GameObject();
            Architekton.name = "Architekton";
            Architekton.AddComponent<ArchitektonBuilder>();
            architektonRef = GameObject.Find("Architekton");
        }
        else if(architektonRef.GetComponent<ArchitektonBuilder>() == null)
        {
            architektonRef.AddComponent<ArchitektonBuilder>();
        }
        ArchitektonBuilder controllerRef = architektonRef.GetComponent<ArchitektonBuilder>();

        controllerRef.cleanUpAndArchitektonBuildage(new Vector3(0,0,0), new Vector3(length,height,width), iterationDepth, heightVarForChildren, randomiseHeightOfChildren, cornerShrinkPercentage, activateCorners, allowBoxesOnBoxes, childLengthWidthFactor, randomiseDimensionsofAllChildren);
    }

    public void OnSaveButtonClick()
	{
        if(!string.IsNullOrEmpty(saveParameterName))
            SaveParameters.saveCurrentParameters(this, saveParameterName);
            AssetDatabase.Refresh();
            Debug.Log("Parameters saved succesfully under Assets/SavedParameters" + name);
            saveParameterName = "";
            SceneView.RepaintAll();
	}

    public void OnLoadButtonClick()
	{
        ArchitektonBuilderParameter loadedParameters = SaveParameters.loadParameters(EditorUtility.OpenFilePanel("Select Parameter File", Application.dataPath + "/ArchitektonBuilder/SavedParameters", ""));
        applyGivenParameters(loadedParameters);
	}

    public void OnLoadDefaultVales()
    {
        length = 1;
        width = 1;
        height = 2;
        iterationDepth = 4;
        heightVarForChildren = new Vector2(.8f,1.2f);
        cornerShrinkPercentage = .3f;
        randomiseHeightOfChildren = true;
        activateChildrenHeightControl = true;
        activateCorners = true;
        allowBoxesOnBoxes = true;
        activateChildrenDimensionControl = false;
        childLengthWidthFactor = new Vector2(.5f,.5f);
    }

    public void applyGivenParameters(ArchitektonBuilderParameter parameters)
    {
        length = parameters.length;
        width = parameters.width;
        height = parameters.height;
        iterationDepth = parameters.iterationDepth;
        cornerShrinkPercentage = parameters.cornerShrinkPercentage;
        activateCorners = parameters.activateCorners;
        heightVarForChildren = new Vector2(parameters.heightVarForChildren[0], parameters.heightVarForChildren[1]);
        randomiseHeightOfChildren = parameters.randomiseHeightOfChildren;
        allowBoxesOnBoxes = parameters.allowBoxesOnBoxes;
        activateChildrenHeightControl = parameters.activateChildrenHeightControl;
        activateChildrenDimensionControl = parameters.activateChildrenDimensionControl;
        childLengthWidthFactor = new Vector2(parameters.childLengthWidthFactor[0], parameters.childLengthWidthFactor[1]);
        randomiseDimensionsofAllChildren = parameters.randomiseDimensionsofAllChildren;
        
    }

    private void drawRectLineHere(Color c)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(12));
        r.height = 2;
        r.y += 5;
        r.x-= 2;
        r.width +=6;
        EditorGUI.DrawRect(r,c);
    }


}
