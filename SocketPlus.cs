//Created by Baha Pirani
//Youtube: https://youtube.com/@piranidev
//Linkedin: https://linkedin.com/in/bahadorpirani
//Github: https://github/piranidev
//This code automatically sends any variable or component from the current game object to a script
//on its parent object. This eliminates the need to manually search for child objects in the parent
//script, as the children will pass their information to the parent. Just attach this script to the
//relevant game object and follow the additional comments for implementation.

using GameWorkerUtilities;
using UnityEngine;

public class SocketPlus : MonoBehaviour
{
    //The variable is defined in the parent game object. For instance, if you have a variable named
    //'gun1' of type 'Gun', you need to write the variable name here and write 'Gun' in the
    //selfVariableName.
    [SerializeField]
    private string parentVariableName;
    //This refers to the component you want to pass to the parent, such as the transform or any specific component.
    [SerializeField]
    private string selfVariableName;

    //If you're sending something like the transform or the game object itself, leave this option disabled.
    //However, if you need to send a specific component attached to the current game object, make sure to
    //enable this field.
    [SerializeField]
    private bool bIsComponent = false;

    //When this option is enabled, the current game object will be disabled after its component is sent to the parent.
    [SerializeField]
    private bool bDisableAfterIntrodcution = false;

    //This is the type of the component on the parent game object. For example, if you want to reference the
    //Gun component, you should specify it here.
    [SerializeField]
    private string parentName;

    private void Awake()
    {
        //This is a helper class designed to locate game objects and their child game objects.
        GameWorker gameWorker = new GameWorker();

        var parent = gameWorker.FindSpeceificParent(parentName, transform).GetComponent(parentName);

        if (parent)
        {
            //Locating the parent's variable through reflection.
            var parentVar = parent.GetType().GetProperty(parentVariableName);

            //If the variable name for the current game object is not specified, the current component will
            //be sent to the parent game object.
            if (selfVariableName == "")
                parentVar.SetValue(parent, this);
            else
            {
                //Transferring a local variable to the parent.
                if (!bIsComponent)
                    parentVar.SetValue(parent, GetType().GetProperty(selfVariableName).GetValue(this));
                //Transferring a component that is attached to the current game object to the parent.
                else
                    parentVar.SetValue(parent, GetComponent(selfVariableName));
            }
        }

        gameObject.SetActive(!bDisableAfterIntrodcution);
    }
}
