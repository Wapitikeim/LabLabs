using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArchitektonBuilderParameter
{
    public int length  { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int iterationDepth { get; set; }
    public float cornerShrinkPercentage {get; set;}
    public bool activateCorners {get; set;}
    public float[] heightVarForChildren {get;set;}
    public bool randomiseHeightOfChildren {get;set;}
    public bool allowBoxesOnBoxes{get;set;}
    public bool activateChildrenHeightControl{get;set;}
    public bool activateChildrenDimensionControl{get;set;}
    public float[] childLengthWidthFactor{get;set;}
    public bool randomiseDimensionsofAllChildren{get;set;}

    public ArchitektonBuilderParameter(UIElementsEditorWindow currentParameters)
    {
        length = currentParameters.length;
        width = currentParameters.width;
        height = currentParameters.height;
        iterationDepth = currentParameters.iterationDepth;
        cornerShrinkPercentage = currentParameters.cornerShrinkPercentage;
        activateCorners = currentParameters.activateCorners;
        heightVarForChildren = new float [2];
        heightVarForChildren[0] = currentParameters.heightVarForChildren.x;
        heightVarForChildren[1] = currentParameters.heightVarForChildren.y;
        randomiseHeightOfChildren = currentParameters.randomiseHeightOfChildren;
        allowBoxesOnBoxes = currentParameters.allowBoxesOnBoxes;
        activateChildrenHeightControl = currentParameters.activateChildrenHeightControl;
        activateChildrenDimensionControl = currentParameters.activateChildrenDimensionControl;
        childLengthWidthFactor = new float[2];
        childLengthWidthFactor[0] = currentParameters.childLengthWidthFactor.x;
        childLengthWidthFactor[1] = currentParameters.childLengthWidthFactor.y;
        randomiseDimensionsofAllChildren = currentParameters.randomiseDimensionsofAllChildren;
    }
}
