/*John Pope
 6/1/2024
This script should take only the Actor pieces created and selected by the user and randomly generate an actor with them*/
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    public GameObject randomActor;
 
    //Custom Functions

    /// <summary>
    /// creates a list of randomized parts for us to use
    /// </summary>
    /// <returns>Returns a list of randomized parts in the following order:
    /// Legs, Body, Head, L_Arm, R_Arm</returns>
    private GameObject GenerateActor() 
    {
        //This first line spawns the root of the randomly generated actor
        randomActor = Instantiate(randomActor, new Vector3(0f, 0, 0), Quaternion.identity);
        //generates a random number from the size of the legs list
        int randomNum = Random.Range(0, Legs.Count);
        //picks a leg piece using the earlier random number
        GameObject randomLegs = Instantiate(Legs[randomNum], randomActor.transform);
        //generates a random number from the number of Bodies contained in the Bodies List
        randomNum = Random.Range(0, Bodies.Count);
        //generates a random body to place on our actor
        GameObject randomBody = Instantiate(Bodies[randomNum], randomLegs.transform);
        //This generates a random number from the heads list
        randomNum = Random.Range(0, Heads.Count);
        //generates the random head picked from the heads list
        GameObject randomHead = Instantiate(Heads[randomNum], randomBody.transform.GetChild(4));
        //generates a random number from the size of the legs list
        randomNum = Random.Range(0, L_Arms.Count);
        //picks a leg piece using the earlier random number
        GameObject randomL_Arms = Instantiate(L_Arms[randomNum], randomBody.transform.GetChild(2));
        //uses the randomly generated number to pick a prefab from the list
        randomNum = Random.Range(0, R_Arms.Count);
        //picks a leg piece using the earlier random number
        GameObject randomR_Arms = Instantiate(R_Arms[randomNum], randomBody.transform.GetChild(3));
        return randomActor;
    }

    private void Start()
    {
      GenerateActor();
    }
}
