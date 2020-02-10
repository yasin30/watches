using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox2D : MonoBehaviour
{
    [SerializeField]
    RectTransform topLeft;
    [SerializeField]
    RectTransform topRight;
    [SerializeField]
    RectTransform botRight;
    [SerializeField]
    RectTransform botLeft;

    // Update is called once per frame
    void Update()
    {
        TrackingInfo trackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;
        Warning warning = ManomotionManager.Instance.Hand_infos[0].hand_info.warning;
        Display2DBoundingBox(warning, trackingInfo);
    }


    /// <summary>
    /// Display2s the Bounding Box Information
    /// </summary>
    /// <param name="warning">Warning.</param>
    /// <param name="trackingInfo">Tracking info.</param>
    void Display2DBoundingBox(Warning warning, TrackingInfo trackingInfo)
    {
        if (warning != Warning.WARNING_HAND_NOT_FOUND)
        {
            topLeft.position = Camera.main.ViewportToScreenPoint(trackingInfo.bounding_box.top_left);
            topRight.position = Camera.main.ViewportToScreenPoint(new Vector2(trackingInfo.bounding_box.top_left.x + trackingInfo.bounding_box.width, trackingInfo.bounding_box.top_left.y));
            botRight.position = Camera.main.ViewportToScreenPoint(new Vector2(trackingInfo.bounding_box.top_left.x + trackingInfo.bounding_box.width, trackingInfo.bounding_box.top_left.y - trackingInfo.bounding_box.height));
            botLeft.position = Camera.main.ViewportToScreenPoint(new Vector2(trackingInfo.bounding_box.top_left.x, trackingInfo.bounding_box.top_left.y - trackingInfo.bounding_box.height));

        }
    }
}
