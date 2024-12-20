using System.Collections.Generic;
using UnityEngine;

namespace VrGorka.UI
{
    public class RouteControlsMenu : MonoBehaviour
    {
        public class Context
        {
            public TrainViewGeneration.TrainViewData trainViewData;
            public RouteControls.IController routeControlsController;
            public RouteControls.IModel routeControlsModel;
        }
        
        [SerializeField] private List<RouteControlWidget> routeControlWidgets;
        
        RouteControls.IController _routeControlsController;
        RouteControls.IModel _routeControlsModel;
        TrainViewGeneration.TrainViewData _trainViewData;

        public void Prepare(Context context)
        {
            PrepareWidgets();
            _routeControlsController = context.routeControlsController;
            _routeControlsModel = context.routeControlsModel;
            _trainViewData = context.trainViewData;
        }

        public void EnableInteraction()
        {
            foreach (var widget in routeControlWidgets)
            {
                widget.routeChangeRequired += OnRouteChangeRequired;
            }
        }

        public void DisableInteraction()
        {
            foreach (var widget in routeControlWidgets)
            {
                widget.routeChangeRequired -= OnRouteChangeRequired;
            }
        }

        private void PrepareWidgets()
        {
            routeControlWidgets[0].isHighlighted = true;
            
            for (var index = 0; index < routeControlWidgets.Count; index++)
            {
                var widget = routeControlWidgets[index];
                
                widget.Prepare(new RouteControlWidget.Context
                {
                    routeIndex = index
                });
            }
        }

        private void OnRouteChangeRequired(int routeIndex)
        {
            for (var i = 0; i < routeControlWidgets.Count; i++)
            {
                routeControlWidgets[i].isHighlighted = i == routeIndex;
            }
            
            if (_routeControlsModel.activeRoute == routeIndex)
            {
                return;
            }

            _routeControlsController.SetRoute(_trainViewData, routeIndex);
        }
    }
}