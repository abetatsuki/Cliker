using UnityEngine;

public　abstract class IEntity : MonoBehaviour
{
    public virtual int  Id => GetInstanceID();
}
