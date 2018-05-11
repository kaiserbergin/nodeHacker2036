using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterractibleObjectAttatchMethods { PARENT, JOINT, FOLLOW }
public enum InterractibleObjectActions { GRAB, DROP, THROW }

public class InterractibleObject : MonoBehaviour {
    public InterractibleObjectAttatchMethods interractibleObjectAttatchMethod;
    public List<InterractibleObjectActions> interractibleObjectActions;
}
