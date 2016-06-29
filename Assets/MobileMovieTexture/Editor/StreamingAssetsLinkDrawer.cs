/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using UnityEngine;
using UnityEditor;

namespace MMT
{
	[CustomPropertyDrawer(typeof(StreamingAssetsLinkAttribute))]
	public class StreaminAssetsLinkDrawer : PropertyDrawer 
	{
        public override void OnGUI (Rect pos, SerializedProperty prop, GUIContent label)
	    {
	        var linkAttribute = attribute as StreamingAssetsLinkAttribute;

            var currentObject = AssetDatabase.LoadAssetAtPath("Assets/StreamingAssets/" + prop.stringValue, linkAttribute.LinkType);

			EditorGUI.BeginChangeCheck();

			var newObject = EditorGUI.ObjectField(pos, linkAttribute.Label, currentObject, linkAttribute.LinkType, false);

			if (EditorGUI.EndChangeCheck())
			{
	            var path = AssetDatabase.GetAssetPath(newObject);

				if (path.Contains("Assets/StreamingAssets/") || string.IsNullOrEmpty(path))
	            {
					path = path.Replace("Assets/StreamingAssets/", "");

					//Undo.RecordObjects(targets, "Change movie reference");

	                prop.stringValue = path;
	            }
	            else
	            {
					Debug.LogError("Link must be in the StreamingAssets directory, path " + path + " is not ");
	            }
	        }
		}
	}
}
