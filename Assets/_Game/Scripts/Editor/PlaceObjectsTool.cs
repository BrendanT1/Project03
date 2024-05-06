using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

[EditorTool("Place Objects Tool")]
public class PlaceObjectsTool : EditorTool
{
    [SerializeField] Texture2D _toolIcon;
    GUIContent _iconContent;

    private void OnEnable()
    {
        _iconContent = new GUIContent()
        {
            image = _toolIcon,
            text = "Place Objects Tool",
            tooltip = "Place Objects Tool"
        };
    }

    public override GUIContent toolbarIcon
    {
        get { return _iconContent; }
    }

    public override void OnToolGUI(EditorWindow window)
    {
        //return when not in scene view
        if (!(window is SceneView))
            return;

        //return if we're not active tool
        if (!ToolManager.IsActiveTool(this))
            return;

        //return if there's no placeable object in scene
        if (!HasPlaceableObject)
            return;

        //draw positional handle
        Handles.DrawWireDisc(GetCurrentMousePositionInScene(), Vector3.up, 0.5f);
    }
    Vector3 GetCurrentMousePositionInScene()
    {
        Vector3 mousePosition = Event.current.mousePosition;
        var placeObject = HandleUtility.PlaceObject(mousePosition, out var newPosition, out var normal);
        return placeObject ? newPosition :
            HandleUtility.GUIPointToWorldRay(mousePosition).GetPoint(10);
    }
}
