using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ManoMotion.UI.Buttons;
namespace ManoMotion.RunTime
{
    public class RunTimeApplication : MonoBehaviour
    {

        List<GameObject> runTimeObjects = new List<GameObject>();
        List<UIIconBehavior.IconFunctionality> defaultFunctionality = new List<UIIconBehavior.IconFunctionality>();

        [SerializeField]
        ManoVisualization manoVisualization;
        [SerializeField]
        GizmoManager gizmoManager;
        [SerializeField]
        GameObject manoMotionCanvas;
        [SerializeField]
        GameObject menuToggleButtonObject;
        [SerializeField]
        GameObject featuresMenu;




        public void InitializeRuntimeComponents()
        {

            if (!manoVisualization)
            {
                try
                {
                    manoVisualization = GameObject.Find("ManoVisualization").GetComponent<ManoVisualization>();

                }
                catch (Exception ex)
                {
                    Debug.LogError("Cannot find the ManoVisualization");
                }
            }

            if (!gizmoManager)
            {
                try
                {
                    gizmoManager = GameObject.Find("GizmoCanvas").GetComponent<GizmoManager>();

                }
                catch (Exception ex)
                {
                    Debug.LogError("Cannot find the GizmoManager");
                }
            }
            if (!manoMotionCanvas)
            {
                try
                {
                    manoMotionCanvas = GameObject.Find("ManoMotionCanvas");
                }
                catch (Exception ex)
                {
                    Debug.Log("Cannot find the ManoMotion Canvas");
                }
            }
            if (!menuToggleButtonObject)
            {
                try
                {
                    menuToggleButtonObject = GameObject.Find("ToggleMenu");
                }
                catch (Exception ex)
                {
                    Debug.Log("Cannot find the Menu Toggle Button");
                }
            }
            if (!featuresMenu)
            {
                try
                {
                    featuresMenu = GameObject.Find("MainFeaturesMenu");
                }
                catch (Exception ex)
                {
                    Debug.Log("Cannot find the Main Features Object");

                }
            }


            runTimeObjects.Add(manoVisualization.gameObject);
            runTimeObjects.Add(gizmoManager.gameObject);
            runTimeObjects.Add(manoMotionCanvas);
            runTimeObjects.Add(menuToggleButtonObject);
            runTimeObjects.Add(featuresMenu);



            if (CategoryManager.Instance)
            {
                CategoryManager.Instance.SetupMenu(GetDefaultListOfFeatures());
            }
            else
            {
                Debug.Log("Cant find Category Manager");
            }


            HideApplicationComponents();


        }

        /// <summary>
        /// Hides the application components.
        /// </summary>
        public void HideApplicationComponents()
        {

            ShouldEnableDisplayScripts(true);
            menuToggleButtonObject.SetActive(false);
            manoMotionCanvas.SetActive(false);
            menuToggleButtonObject.transform.GetChild(0).GetComponent<MenuButton>().CloseMenu();
            DisableManoMotionGizmos();


        }
        /// <summary>
        /// Sets the menu icon visibility.
        /// </summary>
        public void SetMenuIconVisibility()
        {
            if (CategoryManager.Instance)
            {
                CategoryManager.Instance.SetupMenu(GetDefaultListOfFeatures());
                Debug.Log("I executed the category manager");

            }
            else
            {
                Debug.Log("Cant find Category Manager");
            }

            Debug.Log("Super important I have set the lsit of features");
        }

        /// <summary>
        /// Sets the Background Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowBackground(bool condition)
        {
            if (!manoVisualization.enabled)
            {
                manoVisualization.enabled = true;
            }
            manoVisualization.Show_background = condition;
        }
        /// <summary>
        /// Sets the Bounding Box Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowBoundingBox(bool condition)
        {
            if (!manoVisualization.enabled)
            {
                manoVisualization.enabled = true;
            }
            manoVisualization.Show_bounding_box = condition;
        }
        /// <summary>
        /// Sets the Cursor Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowCursor(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowPalmCenter = condition;
        }
        /// <summary>
        /// Sets the Pick Trigger Gesture Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowPick(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowPickTriggerGesture = condition;
        }
        /// <summary>
        /// Sets the Drop Trigger Gesture Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowDrop(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowDropTriggerGesture = condition;
        }
        /// <summary>
        /// Sets the Click Trigger Gesture Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowClick(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowClickTriggerGesture = condition;
        }
        /// <summary>
        /// Sets the Grab Trigger Gesture Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowGrab(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowGrabTriggerGesture = condition;
        }
        /// <summary>
        /// Sets the Release Trigger Gesture Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowRelease(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowReleaseTriggerGesture = condition;
        }
        /// <summary>
        /// Sets the Show hand side Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowHandSide(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowHandSide = condition;
        }
        /// <summary>
        /// Sets the Show Manoclass Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowManoclass(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowManoClass = condition;
        }
        /// <summary>
        /// Sets the Show Continuous Gesture Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowContinousGesture(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowContinuousGestures = condition;
        }
        /// <summary>
        /// Sets the Show Warnings Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowWarnings(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowWarnings = condition;
        }
        /// <summary>
        /// Sets the Show hand states Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowHandStates(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowHandStates = condition;
        }
        /// <summary>
        /// Sets the Show smoothing slider Visualization condition
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        public void ShouldShowSmoothingSlider(bool condition)
        {
            if (!gizmoManager.enabled)
            {
                gizmoManager.enabled = true;
            }
            gizmoManager.ShowSmoothingSlider = condition;
        }


        /// <summary>
        /// Sets the visibility of the ManoMotion components and the Terms and conditions canvas based on the criterion of the boolean.
        /// </summary>
        /// <param name="condition">If set to <c>true</c> Boolean criterion of if the user has seen the instructions.</param>
        public void ShouldEnableDisplayScripts(bool condition)
        {

            for (int i = 0; i < runTimeObjects.Count; i++)
            {
                runTimeObjects[i].SetActive(condition);
            }

        }
        /// <summary>
        /// Starts the main application with default settings.
        /// </summary>
        public void StartMainApplicationWithDefaultSettings()
        {
            //Go through the list instead to see what should be on and what should be off
            manoMotionCanvas.SetActive(true);
            menuToggleButtonObject.SetActive(true);
            menuToggleButtonObject.transform.GetChild(0).GetComponent<MenuButton>().CloseMenuAndShowManoMotionCanvas();

            SetManoMotionFeaturesToDisplay();

        }
        /// <summary>
        /// Disables the mano motion gizmos.
        /// </summary>
        private void DisableManoMotionGizmos()
        {
            ShouldShowHandSide(false);
            ShouldShowBoundingBox(false);
            ShouldShowCursor(false);
            ShouldShowWarnings(false);
            ShouldShowManoclass(false);
            ShouldShowHandStates(false);
            ShouldShowContinousGesture(false);
            ShouldShowSmoothingSlider(false);
        }

        /// <summary>
        /// Sets the mano motion features to display.
        /// </summary>
        private void SetManoMotionFeaturesToDisplay()
        {
            ShouldShowBackground(true);

            ShouldShowHandSide(false);
            ShouldShowBoundingBox(true);
            ShouldShowCursor(true);
            ShouldShowWarnings(false);
            ShouldShowManoclass(false);
            ShouldShowHandStates(false);
            ShouldShowContinousGesture(false);
            ShouldShowSmoothingSlider(false);

            EnableAllTriggers();

        }
        /// <summary>
        /// Gets the default list of features.
        /// </summary>
        /// <returns>The default list of features.</returns>
        public List<UIIconBehavior.IconFunctionality> GetDefaultListOfFeatures()
        {
            if (defaultFunctionality.Count == 0)
            {
                defaultFunctionality.Add(UIIconBehavior.IconFunctionality.Background);
                defaultFunctionality.Add(UIIconBehavior.IconFunctionality.PalmCenter);
                defaultFunctionality.Add(UIIconBehavior.IconFunctionality.BoundingBox);
                defaultFunctionality.Add(UIIconBehavior.IconFunctionality.TriggerDrop);
                defaultFunctionality.Add(UIIconBehavior.IconFunctionality.TriggerPick);
                defaultFunctionality.Add(UIIconBehavior.IconFunctionality.TriggerClick);
                defaultFunctionality.Add(UIIconBehavior.IconFunctionality.TriggerGrab);
                defaultFunctionality.Add(UIIconBehavior.IconFunctionality.TriggerRelease);

            }
            return defaultFunctionality;
        }

        /// <summary>
        /// Disables all triggers from displaying in the screen.
        /// </summary>
        public void DisableAllTriggers()
        {
            ShouldShowDrop(false);
            ShouldShowPick(false);
            ShouldShowClick(false);
            ShouldShowGrab(false);
            ShouldShowRelease(false);
        }
        /// <summary>
        /// Disables all trigers except.
        /// </summary>
        /// <param name="trigger">Trigger.</param>
        public void DisableAllTrigersExcept(ManoGestureTrigger trigger)
        {
            DisableAllTriggers();

            switch (trigger)
            {
                case ManoGestureTrigger.CLICK:
                    ShouldShowClick(true);
                    break;
                case ManoGestureTrigger.GRAB_GESTURE:
                    ShouldShowGrab(true);
                    break;
                case ManoGestureTrigger.RELEASE_GESTURE:
                    ShouldShowRelease(true);
                    break;
                case ManoGestureTrigger.PICK:
                    ShouldShowPick(true);
                    break;
                case ManoGestureTrigger.DROP:
                    ShouldShowDrop(true);
                    break;

                default:
                    break;
            }

        }
        /// <summary>
        /// Enables all triggers.
        /// </summary>
        void EnableAllTriggers()
        {
            ShouldShowDrop(true);
            ShouldShowPick(true);
            ShouldShowClick(true);
            ShouldShowGrab(true);
            ShouldShowRelease(true);
        }

    }
}

