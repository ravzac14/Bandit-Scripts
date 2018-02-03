namespace entities.player {
  using generic;
  using hud;
	using UnityEngine;

	public class PlayerInput : MonoBehaviour {

		Rigidbody2D rb;
		Animator animator;
    EventLog eventLog;
		public float moveSpeedModifier = 1.0f;
		public float nonFacingPercentDeter = 0.8f;
		public float blockingPercentDeter = 0.3f;
		public float diagPercentDeter = 0.9f;

		void Start() {
			rb = GetComponent<Rigidbody2D>();
			animator = GetComponent<Animator>();
      eventLog = GetComponent<EventLog>();
		}

    /* Input Helpers */
		bool hasFacingInputFromPad() {
			return (Input.GetAxis("HorizontalTurn") != 0f) || (Input.GetAxis("VerticalTurn") != 0f);
		}
	
		bool hasFacingInputFromMouse() {
			return (Input.GetAxis("Mouse X") != 0f) || (Input.GetAxis("Mouse Y") != 0f);
		}

    bool hasBlockingInputFromPad() {
      return Input.GetAxis("Block") > 0f;
    }

    bool hasBlockingInputFromMouse() {
      return Input.GetButton("Block");
    }

    // NOTE(zack): Add any animation names to this function
    Option<string> hasAttackInput() {
      // TODO(zack): Get the occupied gear slots of the person, in order to see what they're using
      // to attack with, and therefore which animation we should use. Ideally this "getting gear slots"
      // function would be generic bc it will be used by something else.
      if (Input.GetButton("BasicAttack")) {
        return new Some<string>("attack2");
      } else {
        return new None<string>();
      }
    }

    /* Animation Helpers */
    bool isCurrentlyAttacking() {
      return animator.GetCurrentAnimatorStateInfo(0).IsTag("attackAnim");
    }

    bool isCurrentlyBlocking() {
      return animator.GetCurrentAnimatorStateInfo(0).IsTag("blockAnim");
    }

    /* Movement Helpers */
		bool applyFacingDeterPercent(Vector2 currentFacing, Vector2 movementVector) {
			return DirectionHelpers.vectorToDirection(currentFacing) != DirectionHelpers.vectorToDirection(movementVector);
		}
	
		void Update() {

			/* Update Facing */
			Vector2 direction = Vector2.zero;
			if (hasFacingInputFromPad()) {
				direction = 
					new Vector2(
						Input.GetAxisRaw("HorizontalTurn"),
						Input.GetAxisRaw("VerticalTurn"));
			} else if (hasFacingInputFromMouse()) {
				Vector2 mousePosition = Input.mousePosition;
				mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
				direction = mousePosition - rb.position;
			}

			if (direction != Vector2.zero) {
				animator.SetFloat("facingDirectionX", direction.x);
				animator.SetFloat("facingDirectionY", direction.y);
			}

      /* Update blocking */
      bool isBlocking = hasBlockingInputFromPad() || hasBlockingInputFromMouse(); //isCurrentlyBlocking();
      animator.SetBool("isBlocking", isBlocking);

      /* Maybe trigger attack if not blocking*/
      Option<string> isAttacking = hasAttackInput();
      if (isAttacking.isDefined() && !isBlocking && !isCurrentlyAttacking()) {
        // TODO(zack): Change 1st/2nd args when this is used by all entities
        eventLog.logAttack("Player", "NONE", isAttacking.get());
        animator.SetTrigger(isAttacking.get());
      } else if (isAttacking.isDefined() && isBlocking) {
        eventLog.logAlert("Player attack prohibited while blocking!");
      }
		
			/* Update movement */
			Vector2 movementVector = 
          new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			bool hasMovementInput = movementVector != Vector2.zero;

			animator.SetBool("isWalking", hasMovementInput);
			if (hasMovementInput) {
        eventLog.logMovement("Player", DirectionHelpers.vectorToDirection(movementVector));
				animator.SetFloat("lStickInputX", movementVector.x);
				animator.SetFloat("lStickInputY", movementVector.y);
      }
		
			float facingDeterPercent = 1.0f;
			if (
          applyFacingDeterPercent(
            new Vector2(animator.GetFloat("facingDirectionX"), animator.GetFloat("facingDirectionY")), 
            movementVector)) {
				facingDeterPercent = nonFacingPercentDeter;
			}
      float blockDeterPercent = 1.0f;
      if (isBlocking) {
        blockDeterPercent = blockingPercentDeter;
      }
      float diagDeterPercent = 1.0f;
      if (movementVector.y != 0f && movementVector.x != 0f) {
        diagDeterPercent = diagPercentDeter;
      }

			rb.MovePosition(
          rb.position + 
            (
             (movementVector * moveSpeedModifier * facingDeterPercent * blockDeterPercent * diagDeterPercent) * 
             Time.deltaTime));
		}
	}
}
