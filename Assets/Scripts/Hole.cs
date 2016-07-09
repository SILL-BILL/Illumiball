using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	private bool fallIn;

	//どのボールを吸い寄せるかを返す
	public string activeTag;

	//ボールが入っているかを返す
	public bool IsFallIn(){

		return fallIn;
	}

	private void OnTriggerExit(Collider other){

		if (other.gameObject.tag == activeTag) {

			fallIn = true;
		}
	}

	private void OnTriggerStay(Collider other){

		//コライダーに触れているオブジェクトのRigidbodyコンポーネントを取得
		Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

		//ボールがどの方向にあるかを計算
		Vector3 direction = this.transform.position - other.gameObject.transform.position;
		direction.Normalize ();

		//タグに応じてボールに力を加える
		if (other.gameObject.tag == activeTag) {

			//中心地点でボールを止めるため速度を減速させる
			r.velocity *= 0.9f;

			r.AddForce (direction * r.mass * 20.0f);
		} else {

			r.AddForce (-direction * r.mass * 80.0f);
		}
	}
}
