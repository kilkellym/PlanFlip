﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace PlanFlip
{
    internal static class Utils
    {
        public static List<View> GetAllElevationViews(Document doc)
        {
            List<View> returnList = new List<View>();

            FilteredElementCollector colViews = new FilteredElementCollector(doc);
            colViews.OfClass(typeof(View));

            // loop through views and check for elevation views
            foreach (View x in colViews)
            {
                if (x.GetType() == typeof(ViewSection))
                {
                    if (x.IsTemplate == false)
                    {
                        if (x.ViewType == ViewType.Elevation)
                        {
                            // add view to list
                            returnList.Add(x);
                        }
                    }
                }
            }

            return returnList;
        }

        public static List<View> GetAllElevationsByViewFamilyType(Document doc)
        {
            List<View> viewList = new List<View>();
            
            FilteredElementCollector colViews = new FilteredElementCollector(doc);
            colViews.OfClass(typeof(ViewFamilyType));

            // loop through views and check for elevation views
            foreach (ViewFamilyType x in colViews)
            {
                if (x.ViewFamily == ViewFamily.Elevation)
                    viewList.Add(x);              
            }

            return viewList;
        }
    }
}
