using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour {

	public GameObject chaseCam;

	public float pitchPower;
	public float yawPower;
	public float rollPower;
	public float maxRoll = 30;
	public float throttle;
	public float thrust;
	public GameObject ship;

	void Update(){
	}

	void FixedUpdate(){
		float rollHorizontal = Input.GetAxis ("Horizontal")*rollPower*Time.deltaTime;
		float yawHorizontal = Input.GetAxis ("Horizontal")*yawPower*Time.deltaTime;
		float pitchVertical = Input.GetAxis ("Vertical")*-pitchPower*Time.deltaTime;

		if(Input.GetAxis ("Horizontal")==0){
			ship.transform.rotation = Quaternion.RotateTowards(ship.transform.rotation, Quaternion.Euler (0.0f, 0.0f, 0.0f), rollPower*Time.deltaTime);
		}

		Rigidbody rigidbody = GetComponent<Rigidbody>();

		rigidbody.AddRelativeTorque(pitchVertical,yawHorizontal,0.0f);
		if(Input.GetAxis ("Horizontal") > 0){
			ship.transform.rotation = Quaternion.RotateTowards(ship.transform.rotation, Quaternion.Euler (ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, -maxRoll), rollHorizontal);
		}else{
			ship.transform.rotation = Quaternion.RotateTowards(ship.transform.rotation, Quaternion.Euler (ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, maxRoll), -rollHorizontal);
		}

		//rigidbody.AddRelativeTorque(1 * pitchPower * Time.deltaTime, 1 * yawPower * Time.deltaTime, -1 * rollPower * Time.deltaTime);
		//rigidbody.AddRelativeForce(0, 0, throttle * Thrust * Time.deltaTime);

		//print("Horizontal Axis: "+moveHorizontal);
		/*Vector3 movement= new Vector3 (0.0f, 0.0f, moveVertical);
		//GetComponent<Rigidbody>().velocity = movement*speed;
		GetComponent<Rigidbody>().velocity += transform.forward * speed * moveVertical;


		//Vector3 newPosition = GetComponent<Rigidbody> ().position;

		//chaseCam.transform.position = new Vector3(newPosition.x,newPosition.y + 1.0f,newPosition.z-2.0f);
		//print(GetComponent<Rigidbody>().velocity.x);
		//GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
		//GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, moveHorizontal * -maxTilt * Time.deltaTime);
		if(moveHorizontal!=0){
			transform.Rotate ( Vector3.up * ( moveHorizontal * turnSpeed * Time.deltaTime ) );
			//print("Horz. Move: " + moveHorizontal);
			print("Z-Rotation: " + ship.transform.rotation.z);
			//print("Qauternion: "+Quaternion.Euler (0.0f, 0.0f, 330));
			if((moveHorizontal>0 && ship.transform.rotation.z > -0.3f) || (moveHorizontal<0 && ship.transform.rotation.z < 0.3f)){
			ship.transform.Rotate ( Vector3.forward * ( moveHorizontal * -turnSpeed * Time.deltaTime ) );
			//ship.transform.rotation = Quaternion.Euler (0.0f, 0.0f, Mathf.Clamp(ship.transform.rotation.z,0,30));
			}else{
				if(moveHorizontal>0 && ship.transform.rotation.z < -0.3f){
					ship.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 330);
				}else{
					ship.transform.rotation = Quaternion.Euler (0.0f, 0.0f, 30);
				}
			}
		}*/
	}
}
