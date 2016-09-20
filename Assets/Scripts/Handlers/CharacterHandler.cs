using UnityEngine;
using Assets.Scripts.Resource;
using Assets.Scripts.Core;

namespace Assets.Scripts.Handlers
{
    class CharacterHandler : MonoBehaviour
    {
        private float speed;
        private float shift;
        private float gravity;
        private float jumpHeight;

        private Animator animator;
        private Vector3 moveDirection;
        private bool animationStarted;
        private CharacterController characterController;
        private CharacterAnimationState characterAnimationState;

        public Transform character;

        public CharacterHandler()
        {
            shift = 1f;
            speed = 2f;
            gravity = 20f;
            jumpHeight = 6f;
            animationStarted = false;
            moveDirection = Vector3.zero;
        }

        private void run()
        {
            characterController.Move(moveDirection * Time.deltaTime);
        }

        // initalizaion
        void Start()
        {
            moveDirection = transform.forward;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            animator = character.GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
        }

        // update
        void Update()
        {
            switch (Game.getGame().getState())
            {
                case State.Started:
                    {
                        if (!animationStarted)
                            animator.SetBool(CharacterAnimationState.STARTED, animationStarted = !animationStarted);

                        if (Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            moveDirection.y = jumpHeight;
                        }
                        else if(Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            transform.Rotate(0, 90, 0);
                            moveDirection = Quaternion.AngleAxis(90, Vector3.up) * moveDirection;
                        }
                        else if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            transform.Rotate(0, -90, 0);
                            moveDirection = Quaternion.AngleAxis(-90, Vector3.up) * moveDirection;
                        }
                        else if (Input.GetKeyDown(KeyCode.A))
                        {
                            moveDirection.x -= shift;
                        }
                        else if (Input.GetKeyDown(KeyCode.D))
                        {
                            moveDirection.x += shift;
                        }
                        else
                        {
                            moveDirection.y -= gravity * Time.deltaTime;
                        }

                        run();
                    }
                    break;
                case State.Stopped:
                    {
                        if (animationStarted)
                            animator.SetBool(CharacterAnimationState.STARTED, animationStarted = !animationStarted);
                    }
                    break;
            }
        }
    }
}
