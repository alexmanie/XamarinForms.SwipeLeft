using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SwipeLeft.Common;
using Xamarin.Forms;

namespace SwipeLeft.Templates
{
    public partial class PeopleItemTemplate : ContentView
    {
        private ICommand SwipeLeftCommand => new Command(HandleActionLeft);
        private ICommand SwipeRightCommand => new Command(HandleActionRight);
        private ICommand RemoveCommand => new Command(RemoveCommandMethod);
        private ICommand Action1Command => new Command(ActionOne);
        private ICommand Action2Command => new Command(ActionTwo);

        public PeopleItemTemplate()
        {
            InitializeComponent();
            InitGestures();
            InitControls();
        }

        void InitGestures()
        {
            this.grid.GestureRecognizers.Add(new SwipeGestureRecognizer()
            {
                Direction = SwipeDirection.Left,
                Command = SwipeLeftCommand,
                CommandParameter = this
            });

            this.grid.GestureRecognizers.Add(new SwipeGestureRecognizer()
            {
                Direction = SwipeDirection.Right,
                Command = SwipeRightCommand,
                CommandParameter = this
            });

            this.gridClose.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = RemoveCommand
            });

            this.gridAction1.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = Action1Command
            });

            this.gridAction2.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = Action2Command
            });
        }

        void InitControls()
        {
            this.gridGlobalActions.IsVisible = false; 
        }

        #region [ Commands ]

        /// <summary>
        /// Handles the action of Left Swipe
        /// </summary>
        /// <param name="obj">Object.</param>
        async void HandleActionLeft(object obj)
        {
            this.gridGlobalActions.IsVisible = true;

            //await this.gridGlobalActions.TranslateTo(100, 0, 100);
            //await this.gridGlobalActions.TranslateTo(-100, 0, 1000);
        }

        /// <summary>
        /// Handles the action of Left Swipe
        /// </summary>
        /// <param name="obj">Object.</param>
        void HandleActionRight(object obj)
        {
            this.gridGlobalActions.IsVisible = false;

            //this.gridGlobalActions.Animate("appear", HandleAction, 10, 200);
        }

        void RemoveCommandMethod()
        {
            ActionsHandler.DeleteItem(this.lblEmail.Text);
        }

        private void ActionOne(object obj)
        {

        }

        private void ActionTwo(object obj)
        {

        }

        #endregion

       
    }
}
