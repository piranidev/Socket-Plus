//Created by Baha Pirani
//Email: pirani@blacave.com
//Youtube: https://youtube.com/@piranidev
//Linkedin: https://linkedin.com/in/bahadorpirani
//Github: https://github/piranidev
//This script assists in locating a specific parent by identifying a component attached to it.

using UnityEngine;

namespace GameWorkerUtilities
{
    public class GameWorker
    {
        protected internal Transform FindSpeceificParent(string type, Transform Object)
        {
            Transform parent = Object.parent;
            while (parent.GetComponent(type) == null)
            {
                parent = parent.parent;
            }
            return parent;
        }
    }
}
