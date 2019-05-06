using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace SwipeLeft.ViewModels
{
    public class ViewModelBase : BindableBase, IDestructible
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// The IDestructible interface provides the Destroy method and 
        /// allows for the ViewModel to clean up any resource when the view it 
        /// popped off the navigation stack and is ready for garbage collection.
        /// </summary>
        public void Destroy()
        {

        }
    }
}
