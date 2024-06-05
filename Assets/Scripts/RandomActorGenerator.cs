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
    public Transform rootTransform;
 
    //Custom Functions

    /// <summary>
    /// creates a list of randomized parts for us to use
    /// </summary>
    /// <returns>Returns a list of randomized parts in the following order:
    /// Legs, Body, Head, L_Arm, R_Arm</returns>
    private List<GameObject> GenerateParts() 
    {
        List<GameObject> randomParts = new List<GameObject>();
        //generates a random number from the size of the legs list
        int randomNum = Random.Range(0, Legs.Count);
        //picks a leg piece using the earlier random number
        GameObject randomLegs = Instantiate(Legs[randomNum], rootTransform);
        //adds the generated piece to the list
        randomParts.Add(randomLegs);
        //This first line spawns the root of the randomly generated actor
        rootTransform = Instantiate(rootTransform, new Vector3(0f, 0, 0), Quaternion.identity);
        //generates a random number from the number of Bodies contained in the Bodies List
        randomNum = Random.Range(0, Bodies.Count);
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
        randomNum = Random.Range(0, L_Arms.Count);
        //picks a leg piece using the earlier random number
        GameObject randomL_Arms = Instantiate(L_Arms[randomNum], rootTransform);
        //adds the generated piece to the list
        randomParts.Add(randomL_Arms);
        //uses the randomly generated number to pick a prefab from the list
        randomNum = Random.Range(0, R_Arms.Count);
        //picks a leg piece using the earlier random number
        GameObject randomR_Arms = Instantiate(R_Arms[randomNum], rootTransform);
        //adds the generated piece to the list
        randomParts.Add(randomR_Arms);
        return randomParts;
    }

    /// <summary>
    /// The function below takes the list of random parts made above
    /// and uses it to completely assemble a random game object.
    /// pay very close attention to how you ordered the Attach Points in the editor
    /// that order is how the numbers for the attach points are determined when using GetChild()
    /// list of randomized parts are in the following order:
    /// Legs, Body, Head, L_Arm, R_Arm
    /// </summary>
    /// <returns>returns a fully randomized game object</returns>

    private void ActorAssembler(List<GameObject> randomParts) 
    {
        Transform aPTransform0;
        Transform aPTransform1;
        GameObject tempObject0;
        GameObject tempObject1;

        //This gets the desired start piece from the list prepared in Generated Parts
        tempObject0 = randomParts[0];
        //the AttachPoint created on the prefab is referenced here for attachment
        aPTransform0 = tempObject0.transform.GetChild(0);
        //Next we reference the next piece which the rest will be built off of
        tempObject1 = randomParts[1];
        //and grab the desired Attach Point
        aPTransform1 = tempObject1.transform.GetChild(0);
        //sets one attach point on top of the other
        aPTransform1.position = aPTransform0.position;

        //This continues on connecting the next two pieces
        tempObject0 = randomParts[2];
        //sets the variable equal to the next attach point needed
        aPTransform0 = tempObject0.transform.GetChild(0);
        //selects a new attach point on the body piece
        aPTransform1 = tempObject1.transform.GetChild(1);
        //sets one attach point on top of the other
        aPTransform1.position = aPTransform0.position;

        //This continues on connecting the next two pieces
        tempObject0 = randomParts[3];
        //sets the variable equal to the next attach point needed
        aPTransform0 = tempObject0.transform.GetChild(0);
        //selects a new attach point on the body piece
        aPTransform1 = tempObject1.transform.GetChild(2);
        //sets one attach point on top of the other
        aPTransform1.position = aPTransform0.position;

        //This continues on connecting the next two pieces
        tempObject0 = randomParts[4];
        //sets the variable equal to the next attach point needed
        aPTransform0 = tempObject0.transform.GetChild(0);
        //selects a new attach point on the body piece
        aPTransform1 = tempObject1.transform.GetChild(3);
        //sets one attach point on top of the other
        aPTransform1.position = aPTransform0.position;

        return;
    }

    private void Start()
    {
       List<GameObject> tempList = GenerateParts();
        ActorAssembler(tempList);
    }
}
