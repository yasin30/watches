using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ManoMotion.Example.InteractionPoints
{
	public class InteractionPointsExample : MonoBehaviour
	{
		public enum InteractionPoint

		{
			Pointer,
			Pinch,
			Center

		}

		public RectTransform cursorRectTransform;
		public GameObject cursor;
		float cursorDepth = 1;

		public InteractionPoint currentInteractionPoint;
		// Start is called before the first frame update
		void Start()
		{
			ManomotionManager.OnManoMotionFrameProcessed += HandleManoMotionFrameUpdated;
		}


		/// <summary>
		/// Handles the information from the processed frame in order to use the tracking information to illustrate the cursor position.
		/// </summary>
		void HandleManoMotionFrameUpdated()
		{
			Warning currentWarning = ManomotionManager.Instance.Hand_infos[0].hand_info.warning;
			TrackingInfo currentTrackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;

			MoveInteractionPoint(currentWarning, currentTrackingInfo);
		}

		/// <summary>
		/// Handles the movement of the interaction point according to the type.
		/// </summary>
		/// <param name="warning">Warning.</param>
		/// <param name="trackingInfo">Tracking info.</param>
		public void MoveInteractionPoint(Warning warning, TrackingInfo trackingInfo)
		{

			if (warning == Warning.WARNING_HAND_NOT_FOUND)
			{
				if (cursor.activeInHierarchy)
				{
					cursor.SetActive(false);
				}
			}
			else
			{
				if (!cursor.activeInHierarchy)
				{
					cursor.SetActive(true);
				}


				switch (currentInteractionPoint)
				{

					case InteractionPoint.Center:
						cursorRectTransform.position = Camera.main.ViewportToScreenPoint(trackingInfo.palm_center);


						break;

					case InteractionPoint.Pointer:
						cursorRectTransform.position = Camera.main.ViewportToScreenPoint(trackingInfo.bounding_box.top_left);
						break;

					case InteractionPoint.Pinch:

						Vector2 pinchPosition = new Vector2(trackingInfo.bounding_box.top_left.x, trackingInfo.palm_center.y);
						cursorRectTransform.position = Camera.main.ViewportToScreenPoint(pinchPosition);
						break;

					default:
						break;
				}
			}


		}

		/// <summary>
		/// Sets the interaction point to follow pointer.
		/// </summary>
		public void SetInteractionPointPointer()
		{
			currentInteractionPoint = InteractionPoint.Pointer;

		}
		/// <summary>
		/// Sets the interaction point to follow pinch.
		/// </summary>
		public void SetInteractionPointPinch()
		{
			currentInteractionPoint = InteractionPoint.Pinch;

		}

		/// <summary>
		/// Sets the interaction point to follow center.
		/// </summary>
		public void SetInteractionPointCenter()
		{
			currentInteractionPoint = InteractionPoint.Center;

		}




	}

}
