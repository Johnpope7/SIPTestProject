using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RandomActorGenerator))]
public class RandomActorEditor : Editor
{
    //Variables

    //lists
    /*you will have to specify and serialize the list of objects the user wants to use
     for their actors. These lists can be changed, new ones can be added, or deleted
    whatever fits what youre generating. After the lists satisfy what is being generated,
    attach this script to an empty in the editor and manually place objects into these lists.*/
    [SerializeField]
    List<GameObject> Heads;
    [SerializeField]
    List<GameObject> Legs;
    [SerializeField]
    List<GameObject> Bodies;
    [SerializeField]
    List<GameObject> L_Arms;
    [SerializeField]
    List<GameObject> R_Arms;

    //decides where the generated actor will be
    [SerializeField]
    //transform used to set the root of the actor
    public GameObject randomActor;
    public override void OnInspectorGUI() 
    {
        DrawDefaultInspector();
        GUILayout.Label("The Magic Button");
        RandomActorGenerator randomActorGenerator = (RandomActorGenerator)target;
        if (GUILayout.Button("Spawn Random Actor"))
        {
            randomActorGenerator.GenerateActor();
        }
    }
}
