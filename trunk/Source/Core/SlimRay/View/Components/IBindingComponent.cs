using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.View.Components
{
    public interface IBindingComponent
    {
        IBindingShape Source { get; set; }

        /// <summary>
        /// init all items, load data for them,
        /// and show all
        /// </summary>
        void Show();

        /// <summary>
        /// 
        /// </summary>
        void Hide();

        /// <summary>
        /// release using data, and destory this component.
        /// </summary>
        void Close();
    }
}
