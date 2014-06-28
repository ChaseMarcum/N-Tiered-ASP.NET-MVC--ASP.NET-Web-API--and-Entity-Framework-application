using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AIM.Web.ClientApp.Helper
{
    public static class HtmlExtensions
    {
        /// <summary>
        /// To create an observable HTML Control.
        /// </summary>
        /// <typeparam name="TModel">The model object</typeparam>
        /// <typeparam name="TProperty">The property name</typeparam>
        /// <param name="htmlHelper">The <see cref="HtmlHelper<T>"/></param>
        /// <param name="expression">The property expression</param>
        /// <param name="controlType">The <see cref="ControlTypeConstants"/></param>
        /// <param name="htmlAttributes">The html attributes</param>
        /// <returns>Returns computed HTML string.</returns>
        public static IHtmlString ObservableControlFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string controlType = ControlTypeConstants.TextBox, object htmlAttributes = null)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string jsObjectName = null;
            string generalWidth = null;

            // This will be useful, if the same extension has to share with multiple pages (i.e. each with different view models).
            switch (metaData.ContainerType.Name)
            {
                case "ApplicationViewModel":
                    jsObjectName = "Application.ViewModel."; // Where Application is the Javascript object name (namespace in theory). 
                    generalWidth = "width: 380px";
                    break;
                default:
                    throw new Exception(string.Format("The container type {0} is not supported yet.", metaData.ContainerType.Name));
            }

            var propertyObject = jsObjectName + metaData.PropertyName;

            TagBuilder controlBuilder = null;

            // Various control type creation.
            switch (controlType)
            {
                case ControlTypeConstants.TextBox:
                    controlBuilder = new TagBuilder("input");
                    controlBuilder.Attributes.Add("type", "text");
                    controlBuilder.Attributes.Add("style", generalWidth);
                    break;
                case ControlTypeConstants.Html5NumberInput:
                    controlBuilder = new TagBuilder("input");
                    controlBuilder.Attributes.Add("type", "number");
                    controlBuilder.Attributes.Add("style", generalWidth);
                    break;
                case ControlTypeConstants.Html5UrlInput:
                    controlBuilder = new TagBuilder("input");
                    controlBuilder.Attributes.Add("type", "url");
                    controlBuilder.Attributes.Add("style", generalWidth);
                    break;
                case ControlTypeConstants.TextArea:
                    controlBuilder = new TagBuilder("textarea");
                    controlBuilder.Attributes.Add("rows", "5");
                    break;
                case ControlTypeConstants.DropDownList:
                    controlBuilder = new TagBuilder("select");
                    controlBuilder.Attributes.Add("style", generalWidth);
                    break;
                case ControlTypeConstants.JqueryUIDateInput:
                    controlBuilder = new TagBuilder("input");
                    controlBuilder.Attributes.Add("type", "text");
                    controlBuilder.Attributes.Add("style", generalWidth);
                    controlBuilder.Attributes.Add("class", "dateInput");
                    controlBuilder.Attributes.Add("data-bind", "date: " + propertyObject); // date is the customized knockout binding handler. Check PrepareKo method of Application.
                    break;
                default:
                    throw new Exception(string.Format("The control type {0} is not supported yet.", controlType));
            }

            controlBuilder.Attributes.Add("id", metaData.PropertyName);
            controlBuilder.Attributes.Add("name", metaData.PropertyName);

            // Check data-bind already exists, add if not.
            if (!controlBuilder.Attributes.ContainsKey("data-bind"))
            {
                controlBuilder.Attributes.Add("data-bind", "value: " + propertyObject);
            }

            // Merge provided custom html attributes. This overrides the previously defined attributes, if any.
            if (htmlAttributes != null)
            {
                controlBuilder.MergeAttributes(HtmlExtensions.AnonymousObjectToHtmlAttributes(htmlAttributes), true);
            }

            return MvcHtmlString.Create(controlBuilder.ToString());
        }

        /// <summary>
        /// To convert '_' into '-'.
        /// </summary>
        /// <param name="htmlAttributes">The html attributes.</param>
        /// <returns>Returns converted <see cref="RouteValueDictionary"/>.</returns>
        private static RouteValueDictionary AnonymousObjectToHtmlAttributes(object htmlAttributes)
        {
            RouteValueDictionary result = new RouteValueDictionary();
            if (htmlAttributes != null)
            {
                foreach (System.ComponentModel.PropertyDescriptor property in System.ComponentModel.TypeDescriptor.GetProperties(htmlAttributes))
                {
                    result.Add(property.Name.Replace('_', '-'), property.GetValue(htmlAttributes));
                }
            }
            return result;
        }
    }
}