using System;
using UnityEngine;

namespace UnityStandardAssets._2D{
	public class CamFollow : MonoBehaviour {
			Transform target;
			public float retardo = 0f;
			float lookAheadFactor = 0f;
			float elasticidadVel = 0f;
			float lookAheadMoveThreshold = 0f;
			private float m_OffsetZ;
			private Vector3 m_LastTargetPosition;
			private Vector3 m_CurrentVelocity;
			private Vector3 m_LookAheadPos;
			
			private void Start(){
				target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
				m_LastTargetPosition = target.transform.position;
				m_OffsetZ = (transform.position - target.transform.position).z;
				transform.parent = null;
			}

			private void Update(){
				float xMoveDelta = (target.transform.position - m_LastTargetPosition).x;
				bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
				if (updateLookAheadTarget) {
					m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
				} else {
					m_LookAheadPos = Vector3.MoveTowards (m_LookAheadPos, Vector3.zero, Time.deltaTime * elasticidadVel);
				}
				if (target.transform.position.x >= 0 && target.transform.position.x <= 8.7 && target.transform.position.y >= -5.56 && target.transform.position.y <= 0.02) {
					Vector3 aheadTargetPos = target.transform.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
					Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref m_CurrentVelocity, retardo);
					transform.position = newPos;
					m_LastTargetPosition = target.transform.position;
				}else{
					float a=0,b=0;
				if (target.transform.position.x >= -1.57 && target.transform.position.x <= 10.26) {	
						Vector3 aheadTargetPos = target.transform.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
						Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref m_CurrentVelocity, retardo);
						a = newPos.x;
						b = transform.position.y;
						transform.position = new Vector3 (a, b, -10);
						m_LastTargetPosition = target.transform.position;
					}
				if (target.transform.position.y >= -7.12 && target.transform.position.y <= 1.55) {	
						Vector3 aheadTargetPos = target.transform.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
						Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref m_CurrentVelocity, retardo);
						b = newPos.y;
						a = transform.position.x;
						transform.position = new Vector3 (a, b, -10);
						m_LastTargetPosition = target.transform.position;
					}
				}
			}
		}
	}
