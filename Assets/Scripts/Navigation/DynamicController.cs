using UnityEngine;
using System.Collections;

public class DynamicController : MonoBehaviour {

		public float speed;

		IEnumerator Start () {
			Vector3 pointA = transform.position;
			Vector3 pointB = transform.position + new Vector3 (10, 0, 0);


			while (true) {

					yield return StartCoroutine (MoveObject (transform, pointA, pointB, 1.5f));
					yield return StartCoroutine (MoveObject (transform, pointB, pointA, 1.5f));
				}


		}

		IEnumerator MoveObject (Transform thisTransform, Vector3 start, Vector3 end, float time) {
			float i = 0.0f;
			float rate = (float)(1.0f / time);
			while (i < 1.0f) {
				i += Time.deltaTime * rate;
				thisTransform.position = Vector3.Lerp (start, end, i) * speed;
				yield return null; 
			}
		}
}
