using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInterraction : MonoBehaviour {
    #region Class level variables

    public GameObject grabber;
    private Joint grabberJoint;

    public float throwForceModifier = 1.5f;    

    public List<GameObject> interractibleObjects;

    #endregion

    #region Initialization

    private void Awake() {
        interractibleObjects = new List<GameObject>();
        grabberJoint = grabber.GetComponent<Joint>();
    }

    #endregion

    #region OnTrigger events

    private void OnTriggerEnter(Collider other) {
        InterractibleObject interractibleObject = other.gameObject.GetComponentInChildren<InterractibleObject>();
        if (interractibleObject != null) {
            interractibleObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        InterractibleObject interractibleObject = other.gameObject.GetComponentInChildren<InterractibleObject>();
        if (interractibleObject != null && interractibleObjects.Contains(other.gameObject)) {
            interractibleObjects.Remove(other.gameObject);
        }
    }

    #endregion

    #region Public interraction methods

    public void InitiateInterraction() {
        if(interractibleObjects != null && interractibleObjects.Count > 0) {
            foreach (GameObject interractibleObject in interractibleObjects) {
                if (interractibleObject != null) {
                    InterractibleObject interractible = interractibleObject.GetComponentInChildren<InterractibleObject>();
                    if (IsGrabbableViaParenting(interractible)) {
                        GrabViaParenting(interractibleObject);
                    } else if (IsGrabbableViaParenting(interractible)) {
                        GrabViaJoint(interractibleObject);
                    }
                }
            }
        }
    }

    public void TerminateInterraction() {
        if (interractibleObjects != null && interractibleObjects.Count > 0) {
            foreach (GameObject interractibleObject in interractibleObjects) {
                if (interractibleObject != null) {
                    InterractibleObject interractible = interractibleObject.GetComponentInChildren<InterractibleObject>();
                    if (IsDroppableViaParenting(interractible)) {
                        DropViaParenting(interractibleObject);
                    } else if (IsDroppableViaJoint(interractible)) {
                        DropViaJoint(interractibleObject);
                    }
                }
            }
        }
    }

    #endregion

    #region Parenting based interractions

    private bool IsGrabbableViaParenting(InterractibleObject interractible) {
        return interractible.interractibleObjectAttatchMethod == InterractibleObjectAttatchMethods.PARENT && interractible.interractibleObjectActions != null && interractible.interractibleObjectActions.Contains(InterractibleObjectActions.GRAB);
    }

    private void GrabViaParenting(GameObject interractibleObject) {
        interractibleObject.transform.SetParent(grabber.transform);
        Rigidbody rb = interractibleObject.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;
    }

    private bool IsDroppableViaParenting(InterractibleObject interractible) {
        return interractible.interractibleObjectAttatchMethod == InterractibleObjectAttatchMethods.PARENT && interractible.interractibleObjectActions != null && interractible.interractibleObjectActions.Contains(InterractibleObjectActions.DROP);
    }

    private void DropViaParenting(GameObject interractibleObject) {
        interractibleObject.transform.SetParent(null);
        Rigidbody rb = interractibleObject.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = false;
    }

    #endregion

    #region Joint based interractions

    private bool IsGrabbableViaJoint(InterractibleObject interractible) {
        return interractible.interractibleObjectAttatchMethod == InterractibleObjectAttatchMethods.JOINT && interractible.interractibleObjectActions != null && interractible.interractibleObjectActions.Contains(InterractibleObjectActions.GRAB);
    }

    private void GrabViaJoint(GameObject interractibleObject) {
        Rigidbody rb = interractibleObject.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.isKinematic = false;
            if (grabberJoint == null) {
                grabber.AddComponent<FixedJoint>();
                grabberJoint = grabber.GetComponent<FixedJoint>();
            }
            grabberJoint.connectedBody = interractibleObject.GetComponent<Rigidbody>();
        }
    }

    private bool IsDroppableViaJoint(InterractibleObject interractible) {
        return interractible.interractibleObjectAttatchMethod == InterractibleObjectAttatchMethods.JOINT && interractible.interractibleObjectActions != null && interractible.interractibleObjectActions.Contains(InterractibleObjectActions.DROP);
    }

    private void DropViaJoint(GameObject interractibleObject) {
        Rigidbody rb = interractibleObject.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.isKinematic = false;
            grabberJoint.connectedBody = null;
        }
    }

    #endregion
}
