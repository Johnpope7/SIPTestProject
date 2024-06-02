/*John Pope
 6/1/2024
This script should take only the Actor pieces created and selected by the user and randomly generate an actor with them*/
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomActorGenerator : MonoBehaviour
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
    public Transform rootTransform;

    //Custom Functions
    public void ActorAssembler() 
    {
        //This first line spawns the root of the randomly generated actor
       rootTransform = Instantiate(rootTransform, new Vector3(0f, 0, 0), Quaternion.identity);
        //this renames the object to something more fitting
       rootTransform.name = "actorRoot";
        //generates a random number from the number of Bodies contained in the Bodies List
        int randomNum = Random.Range(0, Bodies.Count);
        //generates a random body to place on our actor
        GameObject randomBody = Instantiate(Bodies[randomNum], rootTransform);
        //This generates a random number from the heads list
        randomNum = Random.Range(0, Heads.Count);
        GameObject randomHead = Instantiate(Heads[randomNum], randomBody.GetComponentsInChildren<>
    }


}
