//----------------------------------------------------//
// プレイヤーの動き（試作）
//                                   2019 sora hanada
//---------------------------------------------------//
using UnityEngine;
using Rewired;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class PlayerMove : MonoBehaviour
    {
        private Player m_player0;
        private ThirdPersonCharacter m_character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_camForward;             // The current forward direction of the camera
        private Vector3 m_move;
        private Rigidbody m_rb;

        private void Start()
        {

            m_rb = GetComponent<Rigidbody>();
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_character = GetComponent<ThirdPersonCharacter>();
        }
        // Fixed update is called in sync with physics
        void FixedUpdate()
        {
            // read inputs
            float h = m_player0.GetAxis("Horizontal");
            float v = m_player0.GetAxis("Vertical");

            // calculate move direction to pass to character
            if (m_cam != null)
            {
                // calculate camera relative direction to move:
                m_camForward = Vector3.Scale(m_cam.forward, new Vector3(1, 0, 1)).normalized;
                m_move = v * m_camForward + h * m_cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_move = v * Vector3.forward + h * Vector3.right;
            }
            // pass all parameters to the character control script
            m_rb.velocity = m_move;
        }
    }
}
