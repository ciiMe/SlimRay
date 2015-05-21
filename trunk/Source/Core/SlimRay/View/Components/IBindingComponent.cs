using SlimRay.View.Binding;

namespace SlimRay.View.Components
{
    public interface IBindingComponent
    {
        /// <summary>
        /// user data binding config is saved within this field,
        /// a component should call data loader to load data as binding config sets,
        /// and show them.
        /// </summary>
        IBoundUI BindSetting { get; set; }

        /// <summary>
        /// init all items, load data for them,
        /// and show all
        /// </summary>
        void Show();

        /// <summary>
        /// refresh to show the latest data.
        /// </summary>
        void Refresh();

        /// <summary>
        /// stop refreshing, and hide itself.
        /// </summary>
        void Hide();

        /// <summary>
        /// disconnect from using data, and destory this component.
        /// </summary>
        void Close();
    }
}
