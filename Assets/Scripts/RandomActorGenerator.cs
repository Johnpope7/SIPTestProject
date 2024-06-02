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
    //transform used to set the root of the actor
    public Transform rootTransform;
    //transform used throughout the assembler the actor with the attach points
    private Transform aPTransform;

    //Custom Functions

    /// <summary>
    /// creates a list of randomized parts for us to use
    /// </summary>
    /// <returns>Returns a list of randomized parts in the following order:
    /// Body, Head, Legs, L_Arm, R_Arm</returns>
    private List<GameObject> GenerateParts() 
    {
        List<GameObject> randomParts = new List<GameObject>();
        //This first line spawns the root of the randomly generated actor
        rootTransform = Instantiate(rootTransform, new Vector3(0f, 0, 0), Quaternion.identity);
        //generates a random number from the number of Bodies contained in the Bodies List
        int randomNum = Random.Range(0, Bodies.Count);
        //generates a random body to place on our actor
        GameObject randomBody = Instantiate(Bodies[randomNum], rootTransform);
        //adds the generated piece to the list
        randomParts.Add(randomBody);
        //This generates a random number from the heads list
        randomNum = Random.Range(0, Heads.Count);
        //generates the random head picked from the heads list
        GameObject randomHead = Instantiate(Heads[randomNum], rootTransform);
        //adds the generated piece to the list
        randomParts.Add(randomHead);
        //generates a random number from the size of the legs list
        randomNum = Random.Range(0, Legs.Count);
        //picks a leg piece using the earlier random number
        GameObject randomLegs = Instantiate(Legs[randomNum], rootTransform);
        //adds the generated piece to the list
        randomParts.Add(randomLegs);
        //generates a random number from the size of the legs list
        randomNum = Random.Range(0, L_Arms.Count);
        //picks a leg piece using the earlier random number
        GameObject randomL_Arms = Instantiate(L_Arms[randomNum], rootTransform);
        //adds the generated piece to the list
        randomParts.Add(randomL_Arms);
        randomNum = Random.Range(0, R_Arms.Count);
        //picks a leg piece using the earlier random number
        GameObject randomR_Arms = Instantiate(R_Arms[randomNum], rootTransform);
        //adds the generated piece to the list
        randomParts.Add(randomR_Arms);
        return randomParts;
    }

    private GameObject ActorAssembler(List<GameObject> randomParts) 
    {
        
    }
}
