using UnityEngine;
/// <summary>
/// UI的方向控制(已给出，无需修改)
/// </summary>
public class UIDirectionControl : MonoBehaviour
{
    public bool m_UseRelativeRotation = true;


    private Quaternion m_RelativeRotation;


    private void Start()
    {
        m_RelativeRotation = transform.parent.localRotation;
    }


    private void Update()
    {
        if (m_UseRelativeRotation)
            transform.rotation = m_RelativeRotation;
    }
}
